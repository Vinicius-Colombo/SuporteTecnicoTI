namespace SuporteTI.Desktop
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblSenha = new Label();
            txtEmail = new TextBox();
            txtSenha = new TextBox();
            btnLogin = new Button();
            lblStatus = new Label();
            lblCodigo = new Label();
            txtCodigo = new TextBox();
            lblDescricao = new Label();
            btnCodigo = new Button();
            lblEmail = new Label();
            tabCLogin = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            lblCodigo2 = new Label();
            label1 = new Label();
            tabCLogin.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTitulo.BackColor = Color.WhiteSmoke;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = SystemColors.Highlight;
            lblTitulo.Location = new Point(25, 26);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(294, 47);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Login - Suporte Técnico";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSenha.ForeColor = SystemColors.Highlight;
            lblSenha.Location = new Point(25, 159);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(49, 19);
            lblSenha.TabIndex = 1;
            lblSenha.Text = "Senha";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(25, 120);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Digite seu Email";
            txtEmail.Size = new Size(294, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(25, 181);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.PlaceholderText = "Digite sua Senha";
            txtSenha.Size = new Size(294, 23);
            txtSenha.TabIndex = 3;
            txtSenha.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Highlight;
            btnLogin.ForeColor = SystemColors.Window;
            btnLogin.Location = new Point(25, 302);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(294, 41);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Entrar";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(281, 309);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 5;
            // 
            // lblCodigo
            // 
            lblCodigo.Anchor = AnchorStyles.None;
            lblCodigo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblCodigo.Location = new Point(20, 15);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(294, 32);
            lblCodigo.TabIndex = 8;
            lblCodigo.Text = "Código de Verificação";
            lblCodigo.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(20, 155);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.PlaceholderText = "Digite o Código de Verificação";
            txtCodigo.Size = new Size(294, 23);
            txtCodigo.TabIndex = 7;
            // 
            // lblDescricao
            // 
            lblDescricao.Font = new Font("Segoe UI", 9F);
            lblDescricao.Location = new Point(19, 216);
            lblDescricao.MinimumSize = new Size(300, 0);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(300, 50);
            lblDescricao.TabIndex = 6;
            lblDescricao.Text = "Ao clicar no botão \"Entrar\" um código de validação vai ser enviado para o seu email.\r\n\r\n\r\n";
            lblDescricao.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnCodigo
            // 
            btnCodigo.BackColor = SystemColors.Highlight;
            btnCodigo.ForeColor = SystemColors.Window;
            btnCodigo.Location = new Point(20, 199);
            btnCodigo.Name = "btnCodigo";
            btnCodigo.Size = new Size(294, 32);
            btnCodigo.TabIndex = 5;
            btnCodigo.Text = "Confirmar Código";
            btnCodigo.UseVisualStyleBackColor = false;
            btnCodigo.Click += btnConfirmarCodigo_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.ForeColor = SystemColors.Highlight;
            lblEmail.Location = new Point(25, 98);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(45, 19);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // tabCLogin
            // 
            tabCLogin.Anchor = AnchorStyles.None;
            tabCLogin.Appearance = TabAppearance.FlatButtons;
            tabCLogin.Controls.Add(tabPage1);
            tabCLogin.Controls.Add(tabPage2);
            tabCLogin.ItemSize = new Size(0, 1);
            tabCLogin.Location = new Point(473, 123);
            tabCLogin.Name = "tabCLogin";
            tabCLogin.SelectedIndex = 0;
            tabCLogin.Size = new Size(350, 400);
            tabCLogin.SizeMode = TabSizeMode.Fixed;
            tabCLogin.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.WhiteSmoke;
            tabPage1.Controls.Add(lblTitulo);
            tabPage1.Controls.Add(lblEmail);
            tabPage1.Controls.Add(lblDescricao);
            tabPage1.Controls.Add(txtEmail);
            tabPage1.Controls.Add(lblSenha);
            tabPage1.Controls.Add(btnLogin);
            tabPage1.Controls.Add(txtSenha);
            tabPage1.Location = new Point(4, 5);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(342, 391);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Login";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.WhiteSmoke;
            tabPage2.Controls.Add(lblCodigo2);
            tabPage2.Controls.Add(btnCodigo);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(lblCodigo);
            tabPage2.Controls.Add(txtCodigo);
            tabPage2.Location = new Point(4, 5);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(342, 391);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Verificação";
            // 
            // lblCodigo2
            // 
            lblCodigo2.Anchor = AnchorStyles.None;
            lblCodigo2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCodigo2.Location = new Point(20, 132);
            lblCodigo2.Name = "lblCodigo2";
            lblCodigo2.Size = new Size(294, 20);
            lblCodigo2.TabIndex = 10;
            lblCodigo2.Text = "Código de Verificação";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(20, 58);
            label1.MinimumSize = new Size(300, 0);
            label1.Name = "label1";
            label1.Size = new Size(300, 50);
            label1.TabIndex = 9;
            label1.Text = "Para que você possar ter um acesso seguro enviamos um código de segurança para o seu email. Por favor, digite o código no campo abaixo.\r\n\r\n\r\n";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(1234, 621);
            Controls.Add(tabCLogin);
            Controls.Add(lblStatus);
            Name = "LoginForm";
            Text = "Suporte Técnico";
            tabCLogin.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSenha;
        private TextBox txtEmail;
        private TextBox txtSenha;
        private Button btnLogin;
        private Label lblStatus;
        private Label lblEmail;
        private Button btnCodigo;
        private Label lblDescricao;
        private TextBox txtCodigo;
        private Label lblCodigo;
        private TabControl tabCLogin;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private Label lblCodigo2;
    }
}