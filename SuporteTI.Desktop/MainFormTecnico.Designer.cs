namespace SuporteTI.Desktop
{
    partial class MainFormTecnico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormTecnico));
            pnlHeader = new Panel();
            pbLogo = new PictureBox();
            lblLogo = new Label();
            pbPerfil = new PictureBox();
            pnlConteudo = new Panel();
            splitContainerMain = new SplitContainer();
            lvChamados = new ListView();
            cmbPrioridade = new ComboBox();
            cmbStatus = new ComboBox();
            lblLista = new Label();
            tblDireita = new TableLayoutPanel();
            pnlDetalhesChamado = new Panel();
            lblStaConteudo = new Label();
            lblCliConteudo = new Label();
            lblDesConteudo = new Label();
            lblTiConteudo = new Label();
            btnEncerrar = new Button();
            btnAnexo = new Button();
            lblStatusAtual = new Label();
            lblCliente = new Label();
            lblDescricao = new Label();
            lblTitulo = new Label();
            lblChamado = new Label();
            pnlChat = new Panel();
            rtbHistorico = new RichTextBox();
            pnlEnvio = new Panel();
            txtMensagem = new TextBox();
            btnEnviar = new Button();
            lblFiltroStatus = new Label();
            lblFiltroPrioridade = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPerfil).BeginInit();
            pnlConteudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            tblDireita.SuspendLayout();
            pnlDetalhesChamado.SuspendLayout();
            pnlChat.SuspendLayout();
            pnlEnvio.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = SystemColors.Highlight;
            pnlHeader.Controls.Add(pbLogo);
            pnlHeader.Controls.Add(lblLogo);
            pnlHeader.Controls.Add(pbPerfil);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.MaximumSize = new Size(0, 68);
            pnlHeader.MinimumSize = new Size(0, 68);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(10, 10, 20, 10);
            pnlHeader.Size = new Size(1216, 68);
            pnlHeader.TabIndex = 0;
            // 
            // pbLogo
            // 
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(15, 13);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(44, 35);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 3;
            pbLogo.TabStop = false;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(65, 15);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(179, 30);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "Suporte Técnico";
            // 
            // pbPerfil
            // 
            pbPerfil.Cursor = Cursors.Hand;
            pbPerfil.Dock = DockStyle.Right;
            pbPerfil.Image = Properties.Resources.user_icon;
            pbPerfil.Location = new Point(1166, 10);
            pbPerfil.Name = "pbPerfil";
            pbPerfil.Size = new Size(30, 48);
            pbPerfil.SizeMode = PictureBoxSizeMode.Zoom;
            pbPerfil.TabIndex = 2;
            pbPerfil.TabStop = false;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(splitContainerMain);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 68);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(1216, 593);
            pnlConteudo.TabIndex = 1;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(lblFiltroPrioridade);
            splitContainerMain.Panel1.Controls.Add(lblFiltroStatus);
            splitContainerMain.Panel1.Controls.Add(lvChamados);
            splitContainerMain.Panel1.Controls.Add(cmbPrioridade);
            splitContainerMain.Panel1.Controls.Add(cmbStatus);
            splitContainerMain.Panel1.Controls.Add(lblLista);
            splitContainerMain.Panel1MinSize = 350;
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(tblDireita);
            splitContainerMain.Panel2MinSize = 600;
            splitContainerMain.Size = new Size(1216, 593);
            splitContainerMain.SplitterDistance = 380;
            splitContainerMain.TabIndex = 0;
            // 
            // lvChamados
            // 
            lvChamados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvChamados.BackColor = Color.White;
            lvChamados.BorderStyle = BorderStyle.FixedSingle;
            lvChamados.FullRowSelect = true;
            lvChamados.GridLines = true;
            lvChamados.Location = new Point(0, 158);
            lvChamados.Name = "lvChamados";
            lvChamados.Size = new Size(380, 432);
            lvChamados.TabIndex = 3;
            lvChamados.UseCompatibleStateImageBehavior = false;
            lvChamados.View = View.Details;
            lvChamados.SelectedIndexChanged += lvChamados_SelectedIndexChanged;
            // 
            // cmbPrioridade
            // 
            cmbPrioridade.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbPrioridade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrioridade.FormattingEnabled = true;
            cmbPrioridade.Items.AddRange(new object[] { "Todas", "Alta", "Media", "Baixa" });
            cmbPrioridade.Location = new Point(15, 107);
            cmbPrioridade.MaximumSize = new Size(330, 0);
            cmbPrioridade.MinimumSize = new Size(330, 0);
            cmbPrioridade.Name = "cmbPrioridade";
            cmbPrioridade.Size = new Size(330, 25);
            cmbPrioridade.TabIndex = 2;
            // 
            // cmbStatus
            // 
            cmbStatus.AccessibleDescription = "";
            cmbStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Filtrar por Status", "Todos", "Aberto", "Em Andamento" });
            cmbStatus.Location = new Point(15, 53);
            cmbStatus.MaximumSize = new Size(330, 0);
            cmbStatus.MinimumSize = new Size(330, 0);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(330, 25);
            cmbStatus.TabIndex = 1;
            // 
            // lblLista
            // 
            lblLista.AutoSize = true;
            lblLista.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLista.ForeColor = SystemColors.Highlight;
            lblLista.Location = new Point(15, 10);
            lblLista.Name = "lblLista";
            lblLista.Size = new Size(152, 21);
            lblLista.TabIndex = 0;
            lblLista.Text = "Lista de Chamados";
            // 
            // tblDireita
            // 
            tblDireita.ColumnCount = 1;
            tblDireita.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblDireita.Controls.Add(pnlDetalhesChamado, 0, 0);
            tblDireita.Controls.Add(pnlChat, 0, 1);
            tblDireita.Dock = DockStyle.Fill;
            tblDireita.Location = new Point(0, 0);
            tblDireita.Name = "tblDireita";
            tblDireita.RowCount = 2;
            tblDireita.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tblDireita.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tblDireita.Size = new Size(832, 593);
            tblDireita.TabIndex = 0;
            // 
            // pnlDetalhesChamado
            // 
            pnlDetalhesChamado.BackColor = Color.WhiteSmoke;
            pnlDetalhesChamado.Controls.Add(lblStaConteudo);
            pnlDetalhesChamado.Controls.Add(lblCliConteudo);
            pnlDetalhesChamado.Controls.Add(lblDesConteudo);
            pnlDetalhesChamado.Controls.Add(lblTiConteudo);
            pnlDetalhesChamado.Controls.Add(btnEncerrar);
            pnlDetalhesChamado.Controls.Add(btnAnexo);
            pnlDetalhesChamado.Controls.Add(lblStatusAtual);
            pnlDetalhesChamado.Controls.Add(lblCliente);
            pnlDetalhesChamado.Controls.Add(lblDescricao);
            pnlDetalhesChamado.Controls.Add(lblTitulo);
            pnlDetalhesChamado.Controls.Add(lblChamado);
            pnlDetalhesChamado.Dock = DockStyle.Fill;
            pnlDetalhesChamado.Location = new Point(3, 3);
            pnlDetalhesChamado.Name = "pnlDetalhesChamado";
            pnlDetalhesChamado.Size = new Size(826, 231);
            pnlDetalhesChamado.TabIndex = 0;
            // 
            // lblStaConteudo
            // 
            lblStaConteudo.AutoSize = true;
            lblStaConteudo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStaConteudo.ForeColor = Color.Black;
            lblStaConteudo.Location = new Point(82, 135);
            lblStaConteudo.Name = "lblStaConteudo";
            lblStaConteudo.Size = new Size(0, 19);
            lblStaConteudo.TabIndex = 10;
            // 
            // lblCliConteudo
            // 
            lblCliConteudo.AutoSize = true;
            lblCliConteudo.Font = new Font("Segoe UI", 10F);
            lblCliConteudo.ForeColor = Color.Black;
            lblCliConteudo.Location = new Point(84, 110);
            lblCliConteudo.Name = "lblCliConteudo";
            lblCliConteudo.Size = new Size(0, 19);
            lblCliConteudo.TabIndex = 9;
            // 
            // lblDesConteudo
            // 
            lblDesConteudo.AutoSize = true;
            lblDesConteudo.Font = new Font("Segoe UI", 10F);
            lblDesConteudo.ForeColor = Color.Black;
            lblDesConteudo.Location = new Point(103, 65);
            lblDesConteudo.Name = "lblDesConteudo";
            lblDesConteudo.Size = new Size(0, 19);
            lblDesConteudo.TabIndex = 8;
            // 
            // lblTiConteudo
            // 
            lblTiConteudo.AutoSize = true;
            lblTiConteudo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTiConteudo.ForeColor = Color.Black;
            lblTiConteudo.Location = new Point(76, 40);
            lblTiConteudo.Name = "lblTiConteudo";
            lblTiConteudo.Size = new Size(0, 19);
            lblTiConteudo.TabIndex = 7;
            // 
            // btnEncerrar
            // 
            btnEncerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEncerrar.BackColor = SystemColors.Highlight;
            btnEncerrar.FlatStyle = FlatStyle.Flat;
            btnEncerrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEncerrar.ForeColor = Color.White;
            btnEncerrar.Location = new Point(180, 170);
            btnEncerrar.Name = "btnEncerrar";
            btnEncerrar.Size = new Size(200, 40);
            btnEncerrar.TabIndex = 6;
            btnEncerrar.Text = "Encerrar Chamado";
            btnEncerrar.UseVisualStyleBackColor = false;
            btnEncerrar.Click += btnEncerrar_Click;
            // 
            // btnAnexo
            // 
            btnAnexo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnexo.BackColor = SystemColors.Highlight;
            btnAnexo.FlatStyle = FlatStyle.Flat;
            btnAnexo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAnexo.ForeColor = Color.White;
            btnAnexo.Location = new Point(15, 170);
            btnAnexo.Name = "btnAnexo";
            btnAnexo.Size = new Size(150, 40);
            btnAnexo.TabIndex = 5;
            btnAnexo.Text = "Ver Anexos";
            btnAnexo.UseVisualStyleBackColor = false;
            btnAnexo.Click += btnAnexo_Click;
            // 
            // lblStatusAtual
            // 
            lblStatusAtual.AutoSize = true;
            lblStatusAtual.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatusAtual.ForeColor = SystemColors.Highlight;
            lblStatusAtual.Location = new Point(15, 135);
            lblStatusAtual.Name = "lblStatusAtual";
            lblStatusAtual.Size = new Size(61, 19);
            lblStatusAtual.TabIndex = 4;
            lblStatusAtual.Text = "Status : ";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCliente.ForeColor = SystemColors.Highlight;
            lblCliente.Location = new Point(15, 110);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(63, 19);
            lblCliente.TabIndex = 3;
            lblCliente.Text = "Cliente: ";
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDescricao.ForeColor = SystemColors.Highlight;
            lblDescricao.Location = new Point(15, 65);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(82, 19);
            lblDescricao.TabIndex = 2;
            lblDescricao.Text = "Descrição: ";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitulo.ForeColor = SystemColors.Highlight;
            lblTitulo.Location = new Point(15, 40);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(55, 19);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Título: ";
            // 
            // lblChamado
            // 
            lblChamado.AutoSize = true;
            lblChamado.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblChamado.ForeColor = SystemColors.Highlight;
            lblChamado.Location = new Point(15, 10);
            lblChamado.Name = "lblChamado";
            lblChamado.Size = new Size(96, 21);
            lblChamado.TabIndex = 0;
            lblChamado.Text = "Chamado #";
            // 
            // pnlChat
            // 
            pnlChat.Controls.Add(rtbHistorico);
            pnlChat.Controls.Add(pnlEnvio);
            pnlChat.Dock = DockStyle.Fill;
            pnlChat.Location = new Point(3, 240);
            pnlChat.Name = "pnlChat";
            pnlChat.Size = new Size(826, 350);
            pnlChat.TabIndex = 1;
            // 
            // rtbHistorico
            // 
            rtbHistorico.BackColor = Color.White;
            rtbHistorico.Dock = DockStyle.Fill;
            rtbHistorico.Location = new Point(0, 0);
            rtbHistorico.Name = "rtbHistorico";
            rtbHistorico.ReadOnly = true;
            rtbHistorico.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbHistorico.Size = new Size(826, 270);
            rtbHistorico.TabIndex = 0;
            rtbHistorico.Text = "";
            // 
            // pnlEnvio
            // 
            pnlEnvio.BackColor = Color.WhiteSmoke;
            pnlEnvio.Controls.Add(txtMensagem);
            pnlEnvio.Controls.Add(btnEnviar);
            pnlEnvio.Dock = DockStyle.Bottom;
            pnlEnvio.Location = new Point(0, 270);
            pnlEnvio.Name = "pnlEnvio";
            pnlEnvio.Padding = new Padding(10);
            pnlEnvio.Size = new Size(826, 80);
            pnlEnvio.TabIndex = 1;
            // 
            // txtMensagem
            // 
            txtMensagem.BackColor = Color.White;
            txtMensagem.BorderStyle = BorderStyle.FixedSingle;
            txtMensagem.Dock = DockStyle.Fill;
            txtMensagem.Location = new Point(10, 10);
            txtMensagem.Multiline = true;
            txtMensagem.Name = "txtMensagem";
            txtMensagem.Size = new Size(686, 60);
            txtMensagem.TabIndex = 0;
            // 
            // btnEnviar
            // 
            btnEnviar.BackColor = SystemColors.Highlight;
            btnEnviar.Dock = DockStyle.Right;
            btnEnviar.FlatStyle = FlatStyle.Flat;
            btnEnviar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEnviar.ForeColor = Color.White;
            btnEnviar.Location = new Point(696, 10);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(120, 60);
            btnEnviar.TabIndex = 1;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = false;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // lblFiltroStatus
            // 
            lblFiltroStatus.AutoSize = true;
            lblFiltroStatus.Font = new Font("Segoe UI", 9F);
            lblFiltroStatus.Location = new Point(15, 35);
            lblFiltroStatus.Name = "lblFiltroStatus";
            lblFiltroStatus.Size = new Size(39, 15);
            lblFiltroStatus.TabIndex = 4;
            lblFiltroStatus.Text = "Status";
            // 
            // lblFiltroPrioridade
            // 
            lblFiltroPrioridade.AutoSize = true;
            lblFiltroPrioridade.Font = new Font("Segoe UI", 9F);
            lblFiltroPrioridade.Location = new Point(15, 89);
            lblFiltroPrioridade.Name = "lblFiltroPrioridade";
            lblFiltroPrioridade.Size = new Size(61, 15);
            lblFiltroPrioridade.TabIndex = 5;
            lblFiltroPrioridade.Text = "Prioridade";
            // 
            // MainFormTecnico
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1216, 661);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1200, 700);
            Name = "MainFormTecnico";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Suporte Técnico";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPerfil).EndInit();
            pnlConteudo.ResumeLayout(false);
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel1.PerformLayout();
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            tblDireita.ResumeLayout(false);
            pnlDetalhesChamado.ResumeLayout(false);
            pnlDetalhesChamado.PerformLayout();
            pnlChat.ResumeLayout(false);
            pnlEnvio.ResumeLayout(false);
            pnlEnvio.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblLogo;
        private Panel pnlConteudo;
        private SplitContainer splitContainerMain;
        private Label lblLista;
        private ListView lvChamados;
        private ComboBox cmbPrioridade;
        private ComboBox cmbStatus;
        private TableLayoutPanel tblDireita;
        private Panel pnlDetalhesChamado;
        private Label lblTitulo;
        private Label lblChamado;
        private Button btnAnexo;
        private Label lblStatusAtual;
        private Label lblCliente;
        private Label lblDescricao;
        private Button btnEncerrar;
        private Panel pnlChat;
        private RichTextBox rtbHistorico;
        private Panel pnlEnvio;
        private Button btnEnviar;
        private TextBox txtMensagem;
        public PictureBox pbPerfil;
        private PictureBox pbLogo;
        private Label lblStaConteudo;
        private Label lblCliConteudo;
        private Label lblDesConteudo;
        private Label lblTiConteudo;
        private Label lblFiltroPrioridade;
        private Label lblFiltroStatus;
    }
}