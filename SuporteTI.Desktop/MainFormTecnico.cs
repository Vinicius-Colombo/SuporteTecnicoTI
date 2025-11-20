using SuporteTI.Desktop.DTOs;
using SuporteTI.Desktop.Services;

namespace SuporteTI.Desktop
{
    public partial class MainFormTecnico : Form
    {
        private readonly LoginResponseDto _usuarioLogado;
        private readonly ApiService _apiService;

        public MainFormTecnico(LoginResponseDto usuarioLogado)
        {
            InitializeComponent();
            _usuarioLogado = usuarioLogado;
            _apiService = new ApiService();

            ConfigurarListView();
            this.Load += MainFormTecnico_Load;
            this.Resize += (s, e) => AjustarLarguraColunas();
            cmbStatus.SelectedIndexChanged += async (s, e) => await CarregarChamadosAsync();
            cmbPrioridade.SelectedIndexChanged += async (s, e) => await CarregarChamadosAsync();
            pbPerfil.Click += PbPerfil_Click;
        }

        // ✅ Ao abrir a tela, carrega os chamados do técnico logado
        private async void MainFormTecnico_Load(object? sender, EventArgs e)
        {
            try
            {
                await CarregarChamadosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar chamados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Configura visual e colunas do ListView
        private void ConfigurarListView()
        {
            lvChamados.View = View.Details;
            lvChamados.FullRowSelect = true;
            lvChamados.GridLines = true;
            lvChamados.HideSelection = false;
            lvChamados.MultiSelect = false;
            lvChamados.Font = new Font("Segoe UI", 10);
            lvChamados.BackColor = Color.FromArgb(245, 245, 245);

            lvChamados.Columns.Add("ID", 60, HorizontalAlignment.Left);
            lvChamados.Columns.Add("Título", 250, HorizontalAlignment.Left);
            lvChamados.Columns.Add("Prioridade", 100, HorizontalAlignment.Center);
            lvChamados.Columns.Add("Status", 120, HorizontalAlignment.Center);
            lvChamados.Columns.Add("Abertura", 150, HorizontalAlignment.Center);
        }

        // 🔹 Ajusta largura automaticamente ao redimensionar
        private void AjustarLarguraColunas()
        {
            if (lvChamados.Columns.Count == 0) return;

            int larguraTotal = lvChamados.ClientSize.Width;
            int larguraID = 60;
            int larguraPrioridade = 100;
            int larguraStatus = 120;
            int larguraAbertura = 150;

            int larguraTitulo = larguraTotal - (larguraID + larguraPrioridade + larguraStatus + larguraAbertura + 10);
            if (larguraTitulo < 150) larguraTitulo = 150;

            lvChamados.Columns[0].Width = larguraID;
            lvChamados.Columns[1].Width = larguraTitulo;
            lvChamados.Columns[2].Width = larguraPrioridade;
            lvChamados.Columns[3].Width = larguraStatus;
            lvChamados.Columns[4].Width = larguraAbertura;
        }

        // 🔹 Busca os chamados do técnico via API
        private async Task CarregarChamadosAsync()
        {
            lvChamados.Items.Clear();
            var itemLoading = new ListViewItem("Carregando chamados...");
            lvChamados.Items.Add(itemLoading);

            try
            {
                var chamados = await _apiService.ObterChamadosTecnicoAsync(_usuarioLogado.IdUsuario);
                lvChamados.Items.Clear();

                // 🔹 Aplicar filtros de Status e Prioridade
                string filtroStatus = cmbStatus.SelectedItem?.ToString();
                string filtroPrioridade = cmbPrioridade.SelectedItem?.ToString();

                if (!string.IsNullOrWhiteSpace(filtroStatus) && filtroStatus != "Todos")
                    chamados = chamados.Where(c => c.StatusChamado.Equals(filtroStatus, StringComparison.OrdinalIgnoreCase)).ToList();

                if (!string.IsNullOrWhiteSpace(filtroPrioridade) && filtroPrioridade != "Todas")
                    chamados = chamados.Where(c => c.Prioridade.Equals(filtroPrioridade, StringComparison.OrdinalIgnoreCase)).ToList();

                if (!chamados.Any())
                {
                    lvChamados.Items.Add(new ListViewItem("Nenhum chamado encontrado com os filtros aplicados."));
                    return;
                }

                // 🔹 Popular lista
                foreach (var chamado in chamados)
                {
                    var item = new ListViewItem(chamado.IdChamado.ToString());
                    item.SubItems.Add(chamado.Titulo);
                    item.SubItems.Add(chamado.Prioridade);
                    item.SubItems.Add(chamado.StatusChamado);
                    item.SubItems.Add(chamado.DataAbertura.ToString("dd/MM/yyyy HH:mm"));
                    item.Tag = chamado;

                    if (chamado.StatusChamado.Equals("Aberto", StringComparison.OrdinalIgnoreCase))
                        item.BackColor = Color.FromArgb(220, 245, 255);
                    else if (chamado.StatusChamado.Equals("Em Andamento", StringComparison.OrdinalIgnoreCase))
                        item.BackColor = Color.FromArgb(255, 250, 220);

                    lvChamados.Items.Add(item);
                }

                AjustarLarguraColunas();
            }
            catch (Exception ex)
            {
                lvChamados.Items.Clear();
                lvChamados.Items.Add(new ListViewItem($"Erro: {ex.Message}"));
            }
        }


        private async void lvChamados_SelectedIndexChanged(object sender, EventArgs e)
        {
            // se nada selecionado, limpa os campos
            if (lvChamados.SelectedItems.Count == 0)
            {
                lblTitulo.Text = "Título:";
                lblDescricao.Text = "Descrição:";
                lblCliente.Text = "Cliente:";
                lblStatusAtual.Text = "Status:";
                rtbHistorico.Clear();
                return;
            }

            var item = lvChamados.SelectedItems[0];
            var chamado = item.Tag as ChamadoReadDto;
            if (chamado == null) return;

            // Preencher labels (adapte os textos conforme seu design)
            lblChamado.Text = $"Chamado #{chamado.IdChamado}";
            lblTiConteudo.Text = $" {chamado.Titulo}";
            lblDesConteudo.Text = $" {chamado.Descricao}";
            lblCliConteudo.Text = $" {chamado.Usuario?.Nome ?? "—"}";
            lblStaConteudo.Text = chamado.StatusChamado ?? "—";

            // Colore o label de status (consistência com ListView)
            if (string.Equals(chamado.StatusChamado, "Aberto", StringComparison.OrdinalIgnoreCase))
            {
                lblStaConteudo.ForeColor = SystemColors.HotTrack; // azul (Highlight)
                lblStaConteudo.BackColor = Color.Transparent;
            }
            else if (string.Equals(chamado.StatusChamado, "Em Andamento", StringComparison.OrdinalIgnoreCase))
            {
                lblStaConteudo.ForeColor = Color.FromArgb(200, 120, 0); // laranja/amarelo escuro
                lblStaConteudo.BackColor = Color.Transparent;
            }
            else
            {
                lblStaConteudo.ForeColor = Color.Black;
                lblStaConteudo.BackColor = Color.Transparent;
            }

            // Carrega histórico de interações do chamado (faz uma chamada ao serviço API)
            await CarregarHistoricoAsync(chamado.IdChamado);

        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvChamados.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecione um chamado antes de enviar uma mensagem.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var mensagem = txtMensagem.Text.Trim();
                if (string.IsNullOrWhiteSpace(mensagem))
                {
                    MessageBox.Show("Digite uma mensagem antes de enviar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var chamado = (ChamadoReadDto)lvChamados.SelectedItems[0].Tag;

                // 🔹 1. Envia a mensagem normalmente
                var dto = new InteracaoCreateDto
                {
                    IdChamado = chamado.IdChamado,
                    IdUsuario = _usuarioLogado.IdUsuario,
                    Mensagem = mensagem,
                    Origem = "Tecnico"
                };

                bool sucesso = await _apiService.EnviarInteracaoAsync(dto);

                if (sucesso)
                {
                    txtMensagem.Clear();

                    // 🔹 2. Se o chamado ainda está "Aberto", muda automaticamente para "Em Andamento"
                    if (chamado.StatusChamado.Equals("Aberto", StringComparison.OrdinalIgnoreCase))
                    {
                        chamado.StatusChamado = "Em Andamento";
                        await _apiService.AtualizarStatusChamadoAsync(chamado.IdChamado, "Em Andamento");

                        // Atualiza o item da ListView visualmente
                        lvChamados.SelectedItems[0].SubItems[3].Text = "Em Andamento";
                        lvChamados.SelectedItems[0].BackColor = Color.FromArgb(220, 245, 255);
                        lblStaConteudo.Text = " Em Andamento";
                        lblStaConteudo.ForeColor = Color.FromArgb(200, 120, 0);
                        lblStaConteudo.BackColor = Color.Transparent;
                    }

                    await CarregarHistoricoAsync(chamado.IdChamado);
                }
                else
                {
                    MessageBox.Show("Erro ao enviar mensagem.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao enviar mensagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task CarregarHistoricoAsync(int idChamado)
        {
            try
            {
                var interacoes = await _apiService.GetInteracoesPorChamadoAsync(idChamado);
                rtbHistorico.Clear();

                foreach (var i in interacoes)
                {
                    string remetente = i.NomeUsuario?.Trim() ?? "Desconhecido";
                    string mensagem = i.Mensagem;
                    string horario = i.DataHora.ToString("HH:mm");

                    string remetenteNormalizado = remetente.ToLowerInvariant();
                    string tecnicoAtual = _usuarioLogado.Nome?.Trim().ToLowerInvariant() ?? "";

                    Color cor;

                    if (remetenteNormalizado.Contains(tecnicoAtual))
                        cor = Color.RoyalBlue; // Técnico logado
                    else if (remetenteNormalizado.Contains("assistente ia") || remetenteNormalizado.Contains("ia"))
                        cor = Color.DarkGreen; // IA
                    else
                        cor = Color.DarkRed; // Cliente

                    // Mostra [hora] remetente: mensagem
                    rtbHistorico.SelectionColor = Color.Gray;
                    rtbHistorico.AppendText($"[{horario}] ");
                    rtbHistorico.SelectionColor = cor;
                    rtbHistorico.AppendText($"{remetente}: ");
                    rtbHistorico.SelectionColor = Color.Black;
                    rtbHistorico.AppendText($"{mensagem}\n\n");
                }

                rtbHistorico.SelectionStart = rtbHistorico.Text.Length;
                rtbHistorico.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar histórico: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnEncerrar_Click(object? sender, EventArgs e)
        {
            if (lvChamados.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um chamado para encerrar.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var chamado = (ChamadoReadDto)lvChamados.SelectedItems[0].Tag;

                using var formEncerrar = new EncerrarChamadoForm(chamado);
                if (formEncerrar.ShowDialog(this) == DialogResult.OK)
                {
                    btnEncerrar.Enabled = false;

                    await CarregarChamadosAsync(); // recarrega a lista
                    LimparDetalhesChamado();       // limpa labels/histórico
                    lvChamados.SelectedItems.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao encerrar: {ex.Message}", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEncerrar.Enabled = true;
            }
        }


        private void PbPerfil_Click(object? sender, EventArgs e)
        {
            // Cria o mini perfil e mostra próximo ao ícone
            var perfilForm = new PerfilMiniForm(_usuarioLogado);

            // Define a posição — ao lado do ícone de perfil
            var pos = pbPerfil.PointToScreen(Point.Empty);
            perfilForm.StartPosition = FormStartPosition.Manual;
            perfilForm.Location = new Point(pos.X + pbPerfil.Width - perfilForm.Width, pos.Y + pbPerfil.Height);
            perfilForm.Show();
        }

        private void btnAnexo_Click(object sender, EventArgs e)
        {
            if (lvChamados.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um chamado antes de abrir os anexos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var chamado = (ChamadoReadDto)lvChamados.SelectedItems[0].Tag;
            var formAnexo = new AnexoChamadoForm(chamado);

            formAnexo.ShowDialog();
        }

        private void LimparDetalhesChamado()
        {
            lblChamado.Text = "Chamado ...";
            lblTiConteudo.Text = string.Empty;
            lblDesConteudo.Text = string.Empty;
            lblCliConteudo.Text = string.Empty;
            lblStaConteudo.Text = string.Empty;
            rtbHistorico.Clear();
        }


    }
}