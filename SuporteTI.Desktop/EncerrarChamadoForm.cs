using System.Data;
using SuporteTI.Desktop.DTOs;
using SuporteTI.Desktop.Services;


namespace SuporteTI.Desktop
{
    public partial class EncerrarChamadoForm : Form
    {
        private readonly ApiService _apiService;
        private readonly ChamadoReadDto _chamado;

        public EncerrarChamadoForm(ChamadoReadDto chamado)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _chamado = chamado;

            lblTitulo.Text = $"Título do Chamado: {chamado.Titulo}";
            lblChamado.Text = $"Encerrar Chamado #{chamado.IdChamado}";
            rtbHistorico.ReadOnly = true;

            this.Load += EncerrarChamadoForm_Load;
            btnEncerrar.Click += BtnEncerrar_Click;
            btnCancelar.Click += (s, e) => this.Close();
        }

        private async void EncerrarChamadoForm_Load(object? sender, EventArgs e)
        {
            await CarregarHistoricoAsync();
        }

        private async Task CarregarHistoricoAsync()
        {
            try
            {
                rtbHistorico.Clear();
                var interacoes = await _apiService.GetInteracoesPorChamadoAsync(_chamado.IdChamado);

                if (interacoes == null || interacoes.Count == 0)
                {
                    rtbHistorico.Text = "Nenhuma interação registrada neste chamado.";
                    return;
                }

                foreach (var i in interacoes.OrderBy(x => x.DataHora))
                {
                    // Determina cor com base no tipo de usuário
                    Color corNome;
                    if (i.NomeUsuario.Contains("IA", StringComparison.OrdinalIgnoreCase))
                        corNome = Color.ForestGreen; // Verde para IA
                    else if (i.NomeUsuario.Contains("Técnico", StringComparison.OrdinalIgnoreCase))
                        corNome = Color.RoyalBlue; // Azul para técnico
                    else
                        corNome = Color.DimGray; // Cinza escuro para cliente

                    // Nome + hora
                    rtbHistorico.SelectionFont = new Font(rtbHistorico.Font, FontStyle.Bold);
                    rtbHistorico.SelectionColor = corNome;
                    rtbHistorico.AppendText($"{i.NomeUsuario} ({i.DataHora:dd/MM/yyyy HH:mm}):\n");

                    // Mensagem
                    rtbHistorico.SelectionFont = new Font(rtbHistorico.Font, FontStyle.Regular);
                    rtbHistorico.SelectionColor = Color.Black;
                    rtbHistorico.AppendText($"{i.Mensagem}\n\n");
                }


                rtbHistorico.SelectionStart = rtbHistorico.TextLength;
                rtbHistorico.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar histórico: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnEncerrar_Click(object? sender, EventArgs e)
        {
            try
            {
                bool resolvido = radioButton1.Checked;
                if (!resolvido && !rdbEncerrado.Checked)
                {
                    MessageBox.Show("Selecione uma das opções para encerrar o chamado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dto = new EncerrarChamadoDto
                {
                    Resolvido = resolvido
                };

                var response = await _apiService.EncerrarChamadoAsync(_chamado.IdChamado, dto);

                if (response)
                {
                    MessageBox.Show("Chamado encerrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao encerrar chamado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

