using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SuporteTI.Desktop.DTOs; // Para acessar o DTO do usuário logado

namespace SuporteTI.Desktop
{
    public partial class PerfilMiniForm : Form
    {
        private readonly LoginResponseDto _usuario;

        // Permite arrastar a janela clicando no painel do topo
        [DllImport("user32.dll")] public static extern bool ReleaseCapture();
        [DllImport("user32.dll")] public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public PerfilMiniForm(LoginResponseDto usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            ConfigurarEstilo();
            CarregarDadosUsuario();

            // Fechar ao clicar fora
            Deactivate += (s, e) => Close();
            btnSair.Click += BtnSair_Click;
        }

        private void ConfigurarEstilo()
        {
            // Remover bordas padrão e adicionar sombra
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.White;
            Padding = new Padding(1);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            Paint += (s, e) =>
            {
                using var pen = new Pen(Color.Silver, 1);
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            };

            // Painel de topo (título)
            var pnlTopo = new Panel
            {
                Dock = DockStyle.Top,
                Height = 35,
                BackColor = SystemColors.Highlight
            };
            pnlTopo.MouseDown += (s, e) =>
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            };
            Controls.Add(pnlTopo);

            var lblTitulo = new Label
            {
                Text = "Perfil do Usuário",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlTopo.Controls.Add(lblTitulo);

            // 🔹 Move o painel principal para baixo do topo
            pnlPerfil.Top = pnlTopo.Bottom + 5;
            pnlPerfil.Height = Height - pnlTopo.Height - 10;

            // Estilo dos labels
            foreach (var label in new[] { lblNome, lblEmail, })
            {
                label.Font = new Font("Segoe UI", 9.5F);
                label.ForeColor = Color.DimGray;
                label.Padding = new Padding(10, 5, 10, 0);
            }

            // 🔹 Botão sair fixo na parte inferior
            btnSair.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSair.Top = pnlPerfil.Height - btnSair.Height - 10;
            btnSair.Left = 10;
            btnSair.Width = pnlPerfil.Width - 20;
            btnSair.BackColor = SystemColors.Highlight;
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.FlatAppearance.BorderSize = 0;
            btnSair.ForeColor = Color.White;
            btnSair.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSair.BringToFront();
        }


        private void CarregarDadosUsuario()
        {
            lblNome.Text = $"Nome: {_usuario.Nome}";
            lblEmail.Text = $"E-mail: {_usuario.Email}";
        }



        private void BtnSair_Click(object? sender, EventArgs e)
        {
            // Confirma antes de sair
            var confirm = MessageBox.Show(
                "Deseja realmente sair do sistema?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                // Fecha a tela principal
                foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                {
                    if (form is MainFormTecnico || form is MainFormAdmin)
                        form.Close();
                }

                // Abre novamente a tela de Login
                var loginForm = new LoginForm();
                loginForm.Show();

                // Fecha o mini perfil
                this.Close();
            }
        }

        // Método WinAPI para bordas arredondadas
        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        private void PerfilMiniForm_Load(object sender, EventArgs e)
        {

        }
    }
}
