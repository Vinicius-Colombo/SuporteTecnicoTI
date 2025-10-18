using SuporteTI.Desktop.DTOs;

namespace SuporteTI.Desktop
{
    public partial class MainFormAdmin : Form
    {
        private readonly LoginResponseDto _usuarioLogado;

        public MainFormAdmin(LoginResponseDto usuarioLogado)
        {
            InitializeComponent();
            _usuarioLogado = usuarioLogado;

            // 👇 Exemplo: exibir nome no título
            this.Text = $"Painel do Administrador - {_usuarioLogado.Nome}";
        }
    }
}
