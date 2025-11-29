using SuporteTI.Desktop.DTOs;
using SuporteTI.Desktop.Services;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuporteTI.Desktop
{
    public partial class FormEditarUsuario : Form
    {
        private readonly ApiService _apiService;
        private readonly int _idUsuario;

        public FormEditarUsuario(int idUsuario)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _idUsuario = idUsuario;

            this.Load += FormEditarUsuario_Load;
            btnCancelar.Click += (s, e) => this.Close();
            btnAtualizar.Click += btnAtualizar_Click;
        }

        private async void FormEditarUsuario_Load(object? sender, EventArgs e)
        {
            await CarregarDadosUsuarioAsync();
        }

        private async Task CarregarDadosUsuarioAsync()
        {
            try
            {
                var response = await _apiService.GetAsync($"Usuario/{_idUsuario}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var usuario = JsonSerializer.Deserialize<UsuarioReadDto>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (usuario == null)
                {
                    MessageBox.Show("Usuário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txbId.Text = usuario.IdUsuario.ToString();
                txbNome.Text = usuario.Nome;
                txbEmail.Text = usuario.Email;
                mtbCpf.Text = usuario.Cpf;
                mtbTelefone.Text = usuario.Telefone;
                txbEndereco.Text = usuario.Endereco ?? "";
                msbDataNascimento.Text = usuario.DataNascimento.HasValue
                    ? usuario.DataNascimento.Value.ToString("ddMMyyyy")
                    : "";
                cmbStatus.SelectedItem = usuario.Ativo ? "Ativo" : "Desativado";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados do usuário:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnAtualizar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txbNome.Text))
                {
                    MessageBox.Show("Informe o nome do usuário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cpfLimpo = new string(mtbCpf.Text.Where(char.IsDigit).ToArray());
                var telefoneLimpo = new string(mtbTelefone.Text.Where(char.IsDigit).ToArray());

                DateTime? dataNasc = null;
                if (DateTime.TryParseExact(msbDataNascimento.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var dataValida))
                    dataNasc = dataValida;

                var dto = new UsuarioUpdateDto
                {
                    IdUsuario = _idUsuario,
                    Nome = txbNome.Text.Trim(),
                    Email = txbEmail.Text.Trim(),
                    Cpf = string.IsNullOrWhiteSpace(cpfLimpo) ? null : cpfLimpo,
                    Telefone = string.IsNullOrWhiteSpace(telefoneLimpo) ? null : telefoneLimpo,
                    Endereco = string.IsNullOrWhiteSpace(txbEndereco.Text) ? null : txbEndereco.Text.Trim(),
                    DataNascimento = dataNasc,
                    Ativo = cmbStatus.SelectedItem?.ToString() == "Ativo"
                };

                var response = await _apiService.PutAsync($"Usuario/{_idUsuario}", dto);

                if (!response.IsSuccessStatusCode)
                {
                    var erro = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Erro ao atualizar usuário:\n{erro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar alterações:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
