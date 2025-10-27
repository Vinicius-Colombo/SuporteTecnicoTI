using SuporteTI.Desktop.DTOs;
using SuporteTI.Desktop.Services;
using System;
using System.Windows.Forms;

namespace SuporteTI.Desktop
{
    public partial class LoginForm : Form
    {
        private readonly ApiService _apiService;
        private string _email; // Armazena o e-mail para validação do código

        public LoginForm()
        {
            InitializeComponent();
            _apiService = new ApiService();

            this.Load += LoginForm_Load; // centraliza ao abrir
            this.Resize += LoginForm_Resize; // centraliza ao redimensionar
        }

        // Centraliza o TabControl
        private void CentralizarTabControl()
        {
            tabCLogin.Left = (this.ClientSize.Width - tabCLogin.Width) / 2;
            tabCLogin.Top = (this.ClientSize.Height - tabCLogin.Height) / 2;
        }

        // Chama centralização no Load
        private void LoginForm_Load(object sender, EventArgs e)
        {
            CentralizarTabControl();
        }

        // Chama centralização quando redimensionar (ou maximizar)
        private void LoginForm_Resize(object sender, EventArgs e)
        {
            CentralizarTabControl();
        }


        // 📩 Botão "Entrar" (Solicita envio do código)
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var senha = txtSenha.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Preencha o e-mail e a senha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var loginRequest = new LoginRequestDto
            {
                Email = email,
                Senha = senha
            };

            try
            {
                // 1️⃣ Valida usuário (sem gerar código ainda)
                var usuario = await _apiService.ValidarUsuarioAsync(loginRequest);

                if (usuario == null)
                {
                    MessageBox.Show("Usuário ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2️⃣ Se for cliente, bloqueia imediatamente
                if (usuario.Tipo.Equals("Cliente", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Você não tem permissão para acessar o sistema.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3️⃣ Solicita envio do código (somente Técnico/Admin)
                var resposta = await _apiService.SolicitarCodigoAsync(loginRequest);

                _email = email;

                // 🔹 Se retornou LoginResponseDto → login direto
                if (resposta is LoginResponseDto loginDireto)
                {
                    MessageBox.Show($"Bem-vindo, {loginDireto.Nome}!", "Login realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AbrirTelaPorTipo(loginDireto);
                }
                // 🔹 Se retornou string (mensagem normal)
                else if (resposta is string mensagem)
                {
                    MessageBox.Show(mensagem, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabCLogin.SelectedIndex = 1;
                }
                else
                {
                    MessageBox.Show("Erro ao solicitar código de verificação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao enviar código: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // ✅ Botão "Confirmar Código" (valida o código)
        private async void btnConfirmarCodigo_Click(object sender, EventArgs e)
        {
            var codigo = txtCodigo.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Digite o código recebido por e-mail.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var result = await _apiService.ValidarLoginAsync(_email, codigo);

                if (result == null)
                {
                    MessageBox.Show("Código inválido ou expirado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 🎯 Direciona conforme o tipo de usuário
                MessageBox.Show($"Tipo retornado: {result.Tipo}", "Depuração");

                if (result.Tipo.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
                {
                    var mainAdmin = new MainFormAdmin(result);
                    mainAdmin.Show();
                    this.Hide();
                }
                else if (result.Tipo.Equals("Tecnico", StringComparison.OrdinalIgnoreCase))
                {
                    var mainTecnico = new MainFormTecnico(result);
                    mainTecnico.Show();
                    this.Hide();
                }
                else if (result.Tipo.Equals("Cliente", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Usuário não tem permissão de acesso.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Tipo desconhecido: {result.Tipo}", "Erro de Tipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao validar o código: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirTelaPorTipo(LoginResponseDto result)
        {
            if (result.Tipo.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                var adminForm = new MainFormAdmin(result);
                adminForm.Show();
                this.Hide();
            }
            else if (result.Tipo.Equals("Tecnico", StringComparison.OrdinalIgnoreCase))
            {
                var tecnicoForm = new MainFormTecnico(result);
                tecnicoForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário não possui permissão de acesso ao sistema desktop.",
                    "Acesso negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
