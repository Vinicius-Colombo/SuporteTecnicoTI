namespace SuporteTI.Desktop
{
    partial class EncerrarChamadoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncerrarChamadoForm));
            pnlHeader = new Panel();
            tblPrincipal = new TableLayoutPanel();
            pnlEncerrarChamado = new Panel();
            rtbHistorico = new RichTextBox();
            lblChamado = new Label();
            pnlEncerramento = new Panel();
            btnCancelar = new Button();
            btnEncerrar = new Button();
            lblAviso = new Label();
            radioButton1 = new RadioButton();
            rdbEncerrado = new RadioButton();
            lblTitulo = new Label();
            pbLogo = new PictureBox();
            lblLogo = new Label();
            pnlHeader.SuspendLayout();
            tblPrincipal.SuspendLayout();
            pnlEncerrarChamado.SuspendLayout();
            pnlEncerramento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.Highlight;
            pnlHeader.Controls.Add(pbLogo);
            pnlHeader.Controls.Add(lblLogo);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.MaximumSize = new Size(0, 68);
            pnlHeader.MinimumSize = new Size(0, 68);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(10, 10, 20, 10);
            pnlHeader.Size = new Size(1231, 68);
            pnlHeader.TabIndex = 1;
            // 
            // tblPrincipal
            // 
            tblPrincipal.ColumnCount = 1;
            tblPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblPrincipal.Controls.Add(pnlEncerrarChamado, 0, 0);
            tblPrincipal.Controls.Add(pnlEncerramento, 0, 1);
            tblPrincipal.Location = new Point(0, 68);
            tblPrincipal.Name = "tblPrincipal";
            tblPrincipal.RowCount = 2;
            tblPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblPrincipal.Size = new Size(1231, 570);
            tblPrincipal.TabIndex = 2;
            // 
            // pnlEncerrarChamado
            // 
            pnlEncerrarChamado.BackColor = Color.WhiteSmoke;
            pnlEncerrarChamado.Controls.Add(rtbHistorico);
            pnlEncerrarChamado.Controls.Add(lblChamado);
            pnlEncerrarChamado.Location = new Point(3, 3);
            pnlEncerrarChamado.Name = "pnlEncerrarChamado";
            pnlEncerrarChamado.Size = new Size(1225, 279);
            pnlEncerrarChamado.TabIndex = 0;
            // 
            // rtbHistorico
            // 
            rtbHistorico.BackColor = Color.White;
            rtbHistorico.Location = new Point(0, 41);
            rtbHistorico.Name = "rtbHistorico";
            rtbHistorico.ReadOnly = true;
            rtbHistorico.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbHistorico.Size = new Size(1225, 238);
            rtbHistorico.TabIndex = 1;
            rtbHistorico.Text = "";
            // 
            // lblChamado
            // 
            lblChamado.BackColor = Color.Gainsboro;
            lblChamado.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblChamado.ForeColor = SystemColors.Highlight;
            lblChamado.Location = new Point(0, 0);
            lblChamado.Name = "lblChamado";
            lblChamado.Padding = new Padding(20, 10, 10, 10);
            lblChamado.Size = new Size(1225, 41);
            lblChamado.TabIndex = 0;
            lblChamado.Text = "Encerrar Chamado .....";
            // 
            // pnlEncerramento
            // 
            pnlEncerramento.Controls.Add(btnCancelar);
            pnlEncerramento.Controls.Add(btnEncerrar);
            pnlEncerramento.Controls.Add(lblAviso);
            pnlEncerramento.Controls.Add(radioButton1);
            pnlEncerramento.Controls.Add(rdbEncerrado);
            pnlEncerramento.Controls.Add(lblTitulo);
            pnlEncerramento.Location = new Point(3, 288);
            pnlEncerramento.Name = "pnlEncerramento";
            pnlEncerramento.Size = new Size(1225, 279);
            pnlEncerramento.TabIndex = 1;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ControlDark;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(232, 185);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 40);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnEncerrar
            // 
            btnEncerrar.BackColor = SystemColors.Highlight;
            btnEncerrar.FlatStyle = FlatStyle.Flat;
            btnEncerrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEncerrar.ForeColor = Color.White;
            btnEncerrar.Location = new Point(12, 185);
            btnEncerrar.Name = "btnEncerrar";
            btnEncerrar.Size = new Size(200, 40);
            btnEncerrar.TabIndex = 7;
            btnEncerrar.Text = "Encerrar Chamado";
            btnEncerrar.UseVisualStyleBackColor = false;
            // 
            // lblAviso
            // 
            lblAviso.AutoSize = true;
            lblAviso.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblAviso.ForeColor = SystemColors.ControlDarkDark;
            lblAviso.Location = new Point(12, 163);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(621, 19);
            lblAviso.TabIndex = 4;
            lblAviso.Text = "AVISO: Ao encerrar o chamado não sera possivel continuar conversas ou interações com o cliente.";
            // 
            // radioButton1
            // 
            radioButton1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            radioButton1.Location = new Point(0, 84);
            radioButton1.Name = "radioButton1";
            radioButton1.Padding = new Padding(20, 10, 10, 10);
            radioButton1.Size = new Size(227, 43);
            radioButton1.TabIndex = 3;
            radioButton1.TabStop = true;
            radioButton1.Text = "O chamado foi resolvido.";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // rdbEncerrado
            // 
            rdbEncerrado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            rdbEncerrado.AutoSize = true;
            rdbEncerrado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            rdbEncerrado.Location = new Point(0, 41);
            rdbEncerrado.Name = "rdbEncerrado";
            rdbEncerrado.Padding = new Padding(20, 10, 10, 10);
            rdbEncerrado.Size = new Size(329, 43);
            rdbEncerrado.TabIndex = 2;
            rdbEncerrado.TabStop = true;
            rdbEncerrado.Text = "O chamado foi encerrado (sem solução).";
            rdbEncerrado.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblTitulo.BackColor = Color.WhiteSmoke;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitulo.ForeColor = SystemColors.Highlight;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Padding = new Padding(20, 10, 10, 10);
            lblTitulo.Size = new Size(1225, 41);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Título do Chamado: ....";
            // 
            // pbLogo
            // 
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(16, 17);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(44, 35);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 5;
            pbLogo.TabStop = false;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(66, 19);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(179, 30);
            lblLogo.TabIndex = 4;
            lblLogo.Text = "Suporte Técnico";
            // 
            // EncerrarChamadoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1231, 638);
            Controls.Add(tblPrincipal);
            Controls.Add(pnlHeader);
            Name = "EncerrarChamadoForm";
            Text = "Suporte Técnico";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tblPrincipal.ResumeLayout(false);
            pnlEncerrarChamado.ResumeLayout(false);
            pnlEncerramento.ResumeLayout(false);
            pnlEncerramento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private TableLayoutPanel tblPrincipal;
        private Panel pnlEncerrarChamado;
        private Label lblChamado;
        private RichTextBox rtbHistorico;
        private Panel pnlEncerramento;
        private RadioButton rdbEncerrado;
        private Label lblTitulo;
        private Label lblAviso;
        private RadioButton radioButton1;
        private Button btnEncerrar;
        private Button btnCancelar;
        private PictureBox pbLogo;
        private Label lblLogo;
    }
}