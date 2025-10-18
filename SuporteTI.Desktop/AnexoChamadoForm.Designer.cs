namespace SuporteTI.Desktop
{
    partial class AnexoChamadoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnexoChamadoForm));
            pnlHeader = new Panel();
            pnlAnexo = new Panel();
            lblNaoSuporta = new Label();
            btnVoltar = new Button();
            lblChamado = new Label();
            panel1 = new Panel();
            lblArquivo = new Label();
            btnBaixar = new Button();
            pnlPrincipal = new Panel();
            tblAnexos = new TableLayoutPanel();
            pnlListaAnexo = new Panel();
            lvListaAnexos = new ListView();
            lblListaAnexo = new Label();
            pcbAnexo = new PictureBox();
            pbLogo = new PictureBox();
            lblLogo = new Label();
            pnlHeader.SuspendLayout();
            pnlAnexo.SuspendLayout();
            panel1.SuspendLayout();
            pnlPrincipal.SuspendLayout();
            tblAnexos.SuspendLayout();
            pnlListaAnexo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcbAnexo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.Highlight;
            pnlHeader.Controls.Add(pbLogo);
            pnlHeader.Controls.Add(lblLogo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.MaximumSize = new Size(0, 68);
            pnlHeader.MinimumSize = new Size(0, 68);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(10, 10, 20, 10);
            pnlHeader.Size = new Size(1231, 68);
            pnlHeader.TabIndex = 1;
            // 
            // pnlAnexo
            // 
            pnlAnexo.BackColor = Color.Gainsboro;
            pnlAnexo.Controls.Add(lblNaoSuporta);
            pnlAnexo.Controls.Add(btnVoltar);
            pnlAnexo.Controls.Add(lblChamado);
            pnlAnexo.Dock = DockStyle.Top;
            pnlAnexo.Location = new Point(0, 68);
            pnlAnexo.Name = "pnlAnexo";
            pnlAnexo.Size = new Size(1231, 50);
            pnlAnexo.TabIndex = 2;
            // 
            // lblNaoSuporta
            // 
            lblNaoSuporta.AutoSize = true;
            lblNaoSuporta.BackColor = Color.Gainsboro;
            lblNaoSuporta.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblNaoSuporta.ForeColor = Color.Black;
            lblNaoSuporta.Location = new Point(558, 0);
            lblNaoSuporta.MaximumSize = new Size(0, 50);
            lblNaoSuporta.MinimumSize = new Size(0, 50);
            lblNaoSuporta.Name = "lblNaoSuporta";
            lblNaoSuporta.Padding = new Padding(10, 20, 10, 0);
            lblNaoSuporta.Size = new Size(573, 50);
            lblNaoSuporta.TabIndex = 9;
            lblNaoSuporta.Text = "Visualização de arquivos tipo DOC e PDF não suportada nesta tela. Clique em 'Baixar Anexo' para abrir.";
            // 
            // btnVoltar
            // 
            btnVoltar.BackColor = SystemColors.Highlight;
            btnVoltar.Cursor = Cursors.Hand;
            btnVoltar.Dock = DockStyle.Right;
            btnVoltar.FlatStyle = FlatStyle.Flat;
            btnVoltar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnVoltar.ForeColor = Color.White;
            btnVoltar.Location = new Point(1131, 0);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(100, 50);
            btnVoltar.TabIndex = 8;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = false;
            // 
            // lblChamado
            // 
            lblChamado.AutoSize = true;
            lblChamado.BackColor = Color.Gainsboro;
            lblChamado.Dock = DockStyle.Left;
            lblChamado.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblChamado.ForeColor = SystemColors.Highlight;
            lblChamado.Location = new Point(0, 0);
            lblChamado.MaximumSize = new Size(0, 50);
            lblChamado.MinimumSize = new Size(0, 50);
            lblChamado.Name = "lblChamado";
            lblChamado.Padding = new Padding(10, 15, 0, 0);
            lblChamado.Size = new Size(117, 50);
            lblChamado.TabIndex = 1;
            lblChamado.Text = "Chamado .....";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(lblArquivo);
            panel1.Controls.Add(btnBaixar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 579);
            panel1.Name = "panel1";
            panel1.Size = new Size(1231, 60);
            panel1.TabIndex = 1;
            // 
            // lblArquivo
            // 
            lblArquivo.BackColor = Color.Gainsboro;
            lblArquivo.Dock = DockStyle.Fill;
            lblArquivo.Font = new Font("Segoe UI", 10F);
            lblArquivo.ForeColor = SystemColors.Highlight;
            lblArquivo.Location = new Point(0, 0);
            lblArquivo.Name = "lblArquivo";
            lblArquivo.Padding = new Padding(10, 20, 0, 0);
            lblArquivo.Size = new Size(1131, 60);
            lblArquivo.TabIndex = 1;
            lblArquivo.Text = "Arquivo: ";
            // 
            // btnBaixar
            // 
            btnBaixar.BackColor = SystemColors.Highlight;
            btnBaixar.Cursor = Cursors.Hand;
            btnBaixar.Dock = DockStyle.Right;
            btnBaixar.FlatStyle = FlatStyle.Flat;
            btnBaixar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBaixar.ForeColor = Color.White;
            btnBaixar.Location = new Point(1131, 0);
            btnBaixar.Name = "btnBaixar";
            btnBaixar.Size = new Size(100, 60);
            btnBaixar.TabIndex = 9;
            btnBaixar.Text = "Baixar Anexo";
            btnBaixar.UseVisualStyleBackColor = false;
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.Controls.Add(tblAnexos);
            pnlPrincipal.Dock = DockStyle.Fill;
            pnlPrincipal.Location = new Point(0, 118);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.Size = new Size(1231, 461);
            pnlPrincipal.TabIndex = 3;
            // 
            // tblAnexos
            // 
            tblAnexos.ColumnCount = 2;
            tblAnexos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tblAnexos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tblAnexos.Controls.Add(pnlListaAnexo, 0, 0);
            tblAnexos.Controls.Add(pcbAnexo, 1, 0);
            tblAnexos.Dock = DockStyle.Fill;
            tblAnexos.Location = new Point(0, 0);
            tblAnexos.Name = "tblAnexos";
            tblAnexos.RowCount = 1;
            tblAnexos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblAnexos.Size = new Size(1231, 461);
            tblAnexos.TabIndex = 4;
            // 
            // pnlListaAnexo
            // 
            pnlListaAnexo.Controls.Add(lvListaAnexos);
            pnlListaAnexo.Controls.Add(lblListaAnexo);
            pnlListaAnexo.Dock = DockStyle.Fill;
            pnlListaAnexo.Location = new Point(3, 3);
            pnlListaAnexo.Name = "pnlListaAnexo";
            pnlListaAnexo.Size = new Size(363, 455);
            pnlListaAnexo.TabIndex = 0;
            // 
            // lvListaAnexos
            // 
            lvListaAnexos.BackColor = Color.White;
            lvListaAnexos.BorderStyle = BorderStyle.FixedSingle;
            lvListaAnexos.Dock = DockStyle.Fill;
            lvListaAnexos.FullRowSelect = true;
            lvListaAnexos.GridLines = true;
            lvListaAnexos.Location = new Point(0, 30);
            lvListaAnexos.Name = "lvListaAnexos";
            lvListaAnexos.Size = new Size(363, 425);
            lvListaAnexos.TabIndex = 4;
            lvListaAnexos.UseCompatibleStateImageBehavior = false;
            lvListaAnexos.View = View.Details;
            // 
            // lblListaAnexo
            // 
            lblListaAnexo.BackColor = SystemColors.ControlLight;
            lblListaAnexo.Dock = DockStyle.Top;
            lblListaAnexo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblListaAnexo.ForeColor = SystemColors.Highlight;
            lblListaAnexo.Location = new Point(0, 0);
            lblListaAnexo.Name = "lblListaAnexo";
            lblListaAnexo.Padding = new Padding(10, 5, 10, 0);
            lblListaAnexo.Size = new Size(363, 30);
            lblListaAnexo.TabIndex = 0;
            lblListaAnexo.Text = "Anexos disponíveis";
            // 
            // pcbAnexo
            // 
            pcbAnexo.Dock = DockStyle.Fill;
            pcbAnexo.Location = new Point(372, 3);
            pcbAnexo.Name = "pcbAnexo";
            pcbAnexo.Size = new Size(856, 455);
            pcbAnexo.TabIndex = 1;
            pcbAnexo.TabStop = false;
            // 
            // pbLogo
            // 
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(13, 17);
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
            lblLogo.Location = new Point(63, 19);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(179, 30);
            lblLogo.TabIndex = 4;
            lblLogo.Text = "Suporte Técnico";
            // 
            // AnexoChamadoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1231, 639);
            Controls.Add(pnlPrincipal);
            Controls.Add(panel1);
            Controls.Add(pnlAnexo);
            Controls.Add(pnlHeader);
            Name = "AnexoChamadoForm";
            Text = "Suporte Técnico";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlAnexo.ResumeLayout(false);
            pnlAnexo.PerformLayout();
            panel1.ResumeLayout(false);
            pnlPrincipal.ResumeLayout(false);
            tblAnexos.ResumeLayout(false);
            pnlListaAnexo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcbAnexo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Panel pnlAnexo;
        private Label lblChamado;
        private Button btnVoltar;
        private Label lblNaoSuporta;
        private Panel panel1;
        private Label lblArquivo;
        private Button btnBaixar;
        private Panel pnlPrincipal;
        private TableLayoutPanel tblAnexos;
        private Panel pnlListaAnexo;
        private ListView lvListaAnexos;
        private Label lblListaAnexo;
        private PictureBox pcbAnexo;
        private PictureBox pbLogo;
        private Label lblLogo;
    }
}