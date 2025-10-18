namespace SuporteTI.Desktop
{
    partial class PerfilMiniForm
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
            pnlPerfil = new Panel();
            btnSair = new Button();
            lblTelefone = new Label();
            lblCpf = new Label();
            lblEmail = new Label();
            lblNome = new Label();
            pnlPerfil.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPerfil
            // 
            pnlPerfil.BackColor = Color.WhiteSmoke;
            pnlPerfil.Controls.Add(btnSair);
            pnlPerfil.Controls.Add(lblTelefone);
            pnlPerfil.Controls.Add(lblCpf);
            pnlPerfil.Controls.Add(lblEmail);
            pnlPerfil.Controls.Add(lblNome);
            pnlPerfil.Dock = DockStyle.Fill;
            pnlPerfil.Location = new Point(0, 0);
            pnlPerfil.Name = "pnlPerfil";
            pnlPerfil.Size = new Size(234, 201);
            pnlPerfil.TabIndex = 0;
            // 
            // btnSair
            // 
            btnSair.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSair.BackColor = SystemColors.Highlight;
            btnSair.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSair.ForeColor = Color.White;
            btnSair.Location = new Point(11, 166);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(210, 23);
            btnSair.TabIndex = 4;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = false;
            btnSair.Click += BtnSair_Click;
            // 
            // lblTelefone
            // 
            lblTelefone.Dock = DockStyle.Top;
            lblTelefone.Location = new Point(0, 105);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Padding = new Padding(10);
            lblTelefone.Size = new Size(234, 35);
            lblTelefone.TabIndex = 3;
            lblTelefone.Text = "Telefone: ...";
            // 
            // lblCpf
            // 
            lblCpf.Dock = DockStyle.Top;
            lblCpf.Location = new Point(0, 70);
            lblCpf.Name = "lblCpf";
            lblCpf.Padding = new Padding(10);
            lblCpf.Size = new Size(234, 35);
            lblCpf.TabIndex = 2;
            lblCpf.Text = "CPF: ...";
            // 
            // lblEmail
            // 
            lblEmail.Dock = DockStyle.Top;
            lblEmail.Location = new Point(0, 35);
            lblEmail.Name = "lblEmail";
            lblEmail.Padding = new Padding(10);
            lblEmail.Size = new Size(234, 35);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email: .....";
            // 
            // lblNome
            // 
            lblNome.Dock = DockStyle.Top;
            lblNome.Location = new Point(0, 0);
            lblNome.Name = "lblNome";
            lblNome.Padding = new Padding(10);
            lblNome.Size = new Size(234, 35);
            lblNome.TabIndex = 0;
            lblNome.Text = "Nome: ....";
            // 
            // PerfilMiniForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(234, 201);
            ControlBox = false;
            Controls.Add(pnlPerfil);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PerfilMiniForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Perfil do Usuario";
            TopMost = true;
            pnlPerfil.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPerfil;
        private Button btnSair;
        private Label lblTelefone;
        private Label lblCpf;
        private Label lblEmail;
        private Label lblNome;
    }
}