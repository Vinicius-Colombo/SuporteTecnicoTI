namespace SuporteTI.Desktop
{
    partial class MainFormAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormAdmin));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 25D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 20D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            pnlHeader = new Panel();
            pbLogo = new PictureBox();
            lblLogo = new Label();
            pbPerfil = new PictureBox();
            tblPrincipal = new TableLayoutPanel();
            tblGestao = new TableLayoutPanel();
            lblGestao = new Label();
            flpPesquisar = new FlowLayoutPanel();
            btnAdicionarUsuario = new Button();
            txbPesquisar = new TextBox();
            lblPesquisar = new Label();
            grbResultaPesquisa = new GroupBox();
            dgvResultadoPesquisa = new DataGridView();
            IdUsuario = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Tipo = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Editar = new DataGridViewButtonColumn();
            Desativar = new DataGridViewButtonColumn();
            grbDesativadas = new GroupBox();
            tblDesativadas = new TableLayoutPanel();
            dgvDesativadas = new DataGridView();
            IdDesativado = new DataGridViewTextBoxColumn();
            NomeDesativado = new DataGridViewTextBoxColumn();
            EmailDesativado = new DataGridViewTextBoxColumn();
            ReativarConta = new DataGridViewButtonColumn();
            ApagarConta = new DataGridViewButtonColumn();
            flpDesativadas = new FlowLayoutPanel();
            txbProcurarDesativadas = new TextBox();
            btnProcurarDesativadas = new Button();
            tblRelatorio = new TableLayoutPanel();
            grpFiltroRelatorio = new GroupBox();
            tblFiltros = new TableLayoutPanel();
            lblPeriodo = new Label();
            cmbPeriodo = new ComboBox();
            cmbTecnico = new ComboBox();
            lblTecnico = new Label();
            lblCategoria = new Label();
            cmbCategoria = new ComboBox();
            lblPrioridade = new Label();
            cmbPrioridade = new ComboBox();
            btnGerarRelatorio = new Button();
            grpGraficoChamado = new GroupBox();
            chartChamadosDiarios = new System.Windows.Forms.DataVisualization.Charting.Chart();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPerfil).BeginInit();
            tblPrincipal.SuspendLayout();
            tblGestao.SuspendLayout();
            flpPesquisar.SuspendLayout();
            grbResultaPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultadoPesquisa).BeginInit();
            grbDesativadas.SuspendLayout();
            tblDesativadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDesativadas).BeginInit();
            flpDesativadas.SuspendLayout();
            tblRelatorio.SuspendLayout();
            grpFiltroRelatorio.SuspendLayout();
            tblFiltros.SuspendLayout();
            grpGraficoChamado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartChamadosDiarios).BeginInit();
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
            pnlHeader.Size = new Size(1233, 68);
            pnlHeader.TabIndex = 1;
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
            lblLogo.Location = new Point(65, 18);
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
            pbPerfil.Location = new Point(1183, 10);
            pbPerfil.Name = "pbPerfil";
            pbPerfil.Size = new Size(30, 48);
            pbPerfil.SizeMode = PictureBoxSizeMode.Zoom;
            pbPerfil.TabIndex = 2;
            pbPerfil.TabStop = false;
            // 
            // tblPrincipal
            // 
            tblPrincipal.ColumnCount = 2;
            tblPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblPrincipal.Controls.Add(tblGestao, 0, 0);
            tblPrincipal.Controls.Add(tblRelatorio, 1, 0);
            tblPrincipal.Dock = DockStyle.Fill;
            tblPrincipal.Location = new Point(0, 68);
            tblPrincipal.Name = "tblPrincipal";
            tblPrincipal.Padding = new Padding(10);
            tblPrincipal.RowCount = 1;
            tblPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblPrincipal.Size = new Size(1233, 568);
            tblPrincipal.TabIndex = 2;
            // 
            // tblGestao
            // 
            tblGestao.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tblGestao.ColumnCount = 1;
            tblGestao.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblGestao.Controls.Add(lblGestao, 0, 0);
            tblGestao.Controls.Add(flpPesquisar, 0, 1);
            tblGestao.Controls.Add(grbResultaPesquisa, 0, 2);
            tblGestao.Controls.Add(grbDesativadas, 0, 3);
            tblGestao.Dock = DockStyle.Fill;
            tblGestao.Location = new Point(13, 13);
            tblGestao.Name = "tblGestao";
            tblGestao.RowCount = 4;
            tblGestao.RowStyles.Add(new RowStyle());
            tblGestao.RowStyles.Add(new RowStyle());
            tblGestao.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblGestao.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblGestao.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblGestao.Size = new Size(600, 542);
            tblGestao.TabIndex = 0;
            // 
            // lblGestao
            // 
            lblGestao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblGestao.AutoSize = true;
            lblGestao.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblGestao.ForeColor = SystemColors.Highlight;
            lblGestao.Location = new Point(3, 0);
            lblGestao.Name = "lblGestao";
            lblGestao.Padding = new Padding(0, 8, 0, 8);
            lblGestao.Size = new Size(594, 46);
            lblGestao.TabIndex = 1;
            lblGestao.Text = "Gerenciamento de Usuários";
            // 
            // flpPesquisar
            // 
            flpPesquisar.AutoSize = true;
            flpPesquisar.Controls.Add(btnAdicionarUsuario);
            flpPesquisar.Controls.Add(txbPesquisar);
            flpPesquisar.Controls.Add(lblPesquisar);
            flpPesquisar.Dock = DockStyle.Left;
            flpPesquisar.FlowDirection = FlowDirection.RightToLeft;
            flpPesquisar.Location = new Point(3, 49);
            flpPesquisar.Name = "flpPesquisar";
            flpPesquisar.Size = new Size(594, 41);
            flpPesquisar.TabIndex = 2;
            flpPesquisar.WrapContents = false;
            // 
            // btnAdicionarUsuario
            // 
            btnAdicionarUsuario.BackColor = SystemColors.Highlight;
            btnAdicionarUsuario.FlatAppearance.BorderSize = 0;
            btnAdicionarUsuario.FlatStyle = FlatStyle.Flat;
            btnAdicionarUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdicionarUsuario.ForeColor = Color.White;
            btnAdicionarUsuario.Location = new Point(446, 3);
            btnAdicionarUsuario.Name = "btnAdicionarUsuario";
            btnAdicionarUsuario.Size = new Size(145, 35);
            btnAdicionarUsuario.TabIndex = 3;
            btnAdicionarUsuario.Text = "Adicionar Usuário";
            btnAdicionarUsuario.UseVisualStyleBackColor = false;
            // 
            // txbPesquisar
            // 
            txbPesquisar.Anchor = AnchorStyles.Left;
            txbPesquisar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txbPesquisar.Location = new Point(178, 8);
            txbPesquisar.Margin = new Padding(1, 3, 15, 3);
            txbPesquisar.Name = "txbPesquisar";
            txbPesquisar.PlaceholderText = "Pesquise por ID, nome ou e-mail";
            txbPesquisar.Size = new Size(250, 25);
            txbPesquisar.TabIndex = 1;
            txbPesquisar.TextChanged += txbPesquisar_TextChanged;
            // 
            // lblPesquisar
            // 
            lblPesquisar.AutoSize = true;
            lblPesquisar.Dock = DockStyle.Left;
            lblPesquisar.Font = new Font("Segoe UI", 8F);
            lblPesquisar.Location = new Point(-2, 0);
            lblPesquisar.Name = "lblPesquisar";
            lblPesquisar.Size = new Size(176, 41);
            lblPesquisar.TabIndex = 4;
            lblPesquisar.Text = "Pesquise por ID, nome ou e-mail:";
            lblPesquisar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grbResultaPesquisa
            // 
            grbResultaPesquisa.Controls.Add(dgvResultadoPesquisa);
            grbResultaPesquisa.Dock = DockStyle.Fill;
            grbResultaPesquisa.Font = new Font("Segoe UI Semibold", 10F);
            grbResultaPesquisa.ForeColor = SystemColors.Highlight;
            grbResultaPesquisa.Location = new Point(5, 98);
            grbResultaPesquisa.Margin = new Padding(5);
            grbResultaPesquisa.Name = "grbResultaPesquisa";
            grbResultaPesquisa.Padding = new Padding(10);
            grbResultaPesquisa.Size = new Size(590, 214);
            grbResultaPesquisa.TabIndex = 3;
            grbResultaPesquisa.TabStop = false;
            grbResultaPesquisa.Text = "Resultado da Pesquisa";
            // 
            // dgvResultadoPesquisa
            // 
            dgvResultadoPesquisa.AllowUserToAddRows = false;
            dgvResultadoPesquisa.AllowUserToDeleteRows = false;
            dgvResultadoPesquisa.AllowUserToResizeRows = false;
            dgvResultadoPesquisa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultadoPesquisa.BackgroundColor = Color.White;
            dgvResultadoPesquisa.BorderStyle = BorderStyle.None;
            dgvResultadoPesquisa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultadoPesquisa.Columns.AddRange(new DataGridViewColumn[] { IdUsuario, Nome, Email, Tipo, Status, Editar, Desativar });
            dgvResultadoPesquisa.Dock = DockStyle.Fill;
            dgvResultadoPesquisa.GridColor = Color.LightGray;
            dgvResultadoPesquisa.Location = new Point(10, 28);
            dgvResultadoPesquisa.Name = "dgvResultadoPesquisa";
            dgvResultadoPesquisa.ReadOnly = true;
            dgvResultadoPesquisa.RowHeadersVisible = false;
            dgvResultadoPesquisa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultadoPesquisa.Size = new Size(570, 176);
            dgvResultadoPesquisa.TabIndex = 0;
            // 
            // IdUsuario
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.ForeColor = SystemColors.Highlight;
            IdUsuario.DefaultCellStyle = dataGridViewCellStyle1;
            IdUsuario.HeaderText = "Id";
            IdUsuario.Name = "IdUsuario";
            IdUsuario.ReadOnly = true;
            // 
            // Nome
            // 
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            Nome.ReadOnly = true;
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.Name = "Email";
            Email.ReadOnly = true;
            // 
            // Tipo
            // 
            Tipo.HeaderText = "Tipo";
            Tipo.Name = "Tipo";
            Tipo.ReadOnly = true;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // Editar
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 192, 0);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 192, 0);
            Editar.DefaultCellStyle = dataGridViewCellStyle2;
            Editar.HeaderText = "Editar";
            Editar.Name = "Editar";
            Editar.ReadOnly = true;
            Editar.UseColumnTextForButtonValue = true;
            // 
            // Desativar
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 128, 0);
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 128, 0);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            Desativar.DefaultCellStyle = dataGridViewCellStyle3;
            Desativar.HeaderText = "Desativar";
            Desativar.Name = "Desativar";
            Desativar.ReadOnly = true;
            Desativar.UseColumnTextForButtonValue = true;
            // 
            // grbDesativadas
            // 
            grbDesativadas.Controls.Add(tblDesativadas);
            grbDesativadas.Dock = DockStyle.Fill;
            grbDesativadas.Font = new Font("Segoe UI Semibold", 10F);
            grbDesativadas.ForeColor = SystemColors.Highlight;
            grbDesativadas.Location = new Point(5, 322);
            grbDesativadas.Margin = new Padding(5);
            grbDesativadas.Name = "grbDesativadas";
            grbDesativadas.Size = new Size(590, 215);
            grbDesativadas.TabIndex = 5;
            grbDesativadas.TabStop = false;
            grbDesativadas.Text = "Contas Desativadas";
            // 
            // tblDesativadas
            // 
            tblDesativadas.ColumnCount = 1;
            tblDesativadas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblDesativadas.Controls.Add(dgvDesativadas, 0, 1);
            tblDesativadas.Controls.Add(flpDesativadas, 0, 0);
            tblDesativadas.Dock = DockStyle.Fill;
            tblDesativadas.Location = new Point(3, 21);
            tblDesativadas.Name = "tblDesativadas";
            tblDesativadas.RowCount = 2;
            tblDesativadas.RowStyles.Add(new RowStyle());
            tblDesativadas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblDesativadas.Size = new Size(584, 191);
            tblDesativadas.TabIndex = 0;
            // 
            // dgvDesativadas
            // 
            dgvDesativadas.AllowUserToAddRows = false;
            dgvDesativadas.AllowUserToDeleteRows = false;
            dgvDesativadas.AllowUserToResizeRows = false;
            dgvDesativadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDesativadas.BackgroundColor = Color.White;
            dgvDesativadas.BorderStyle = BorderStyle.None;
            dgvDesativadas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDesativadas.Columns.AddRange(new DataGridViewColumn[] { IdDesativado, NomeDesativado, EmailDesativado, ReativarConta, ApagarConta });
            dgvDesativadas.Dock = DockStyle.Fill;
            dgvDesativadas.GridColor = Color.LightGray;
            dgvDesativadas.Location = new Point(3, 50);
            dgvDesativadas.Name = "dgvDesativadas";
            dgvDesativadas.ReadOnly = true;
            dgvDesativadas.RowHeadersVisible = false;
            dgvDesativadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDesativadas.Size = new Size(578, 138);
            dgvDesativadas.TabIndex = 4;
            // 
            // IdDesativado
            // 
            IdDesativado.HeaderText = "Id";
            IdDesativado.Name = "IdDesativado";
            IdDesativado.ReadOnly = true;
            // 
            // NomeDesativado
            // 
            NomeDesativado.HeaderText = "Nome";
            NomeDesativado.Name = "NomeDesativado";
            NomeDesativado.ReadOnly = true;
            // 
            // EmailDesativado
            // 
            EmailDesativado.HeaderText = "Email";
            EmailDesativado.Name = "EmailDesativado";
            EmailDesativado.ReadOnly = true;
            // 
            // ReativarConta
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(0, 192, 0);
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 192, 0);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            ReativarConta.DefaultCellStyle = dataGridViewCellStyle4;
            ReativarConta.FlatStyle = FlatStyle.Flat;
            ReativarConta.HeaderText = "Reativar Conta";
            ReativarConta.Name = "ReativarConta";
            ReativarConta.ReadOnly = true;
            ReativarConta.Resizable = DataGridViewTriState.True;
            ReativarConta.SortMode = DataGridViewColumnSortMode.Automatic;
            ReativarConta.UseColumnTextForButtonValue = true;
            // 
            // ApagarConta
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.Red;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.Red;
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            ApagarConta.DefaultCellStyle = dataGridViewCellStyle5;
            ApagarConta.FlatStyle = FlatStyle.Flat;
            ApagarConta.HeaderText = "Apagar Conta";
            ApagarConta.Name = "ApagarConta";
            ApagarConta.ReadOnly = true;
            ApagarConta.Resizable = DataGridViewTriState.True;
            ApagarConta.SortMode = DataGridViewColumnSortMode.Automatic;
            ApagarConta.UseColumnTextForButtonValue = true;
            // 
            // flpDesativadas
            // 
            flpDesativadas.AutoSize = true;
            flpDesativadas.Controls.Add(txbProcurarDesativadas);
            flpDesativadas.Controls.Add(btnProcurarDesativadas);
            flpDesativadas.Dock = DockStyle.Fill;
            flpDesativadas.Location = new Point(3, 3);
            flpDesativadas.Name = "flpDesativadas";
            flpDesativadas.Size = new Size(578, 41);
            flpDesativadas.TabIndex = 3;
            flpDesativadas.WrapContents = false;
            // 
            // txbProcurarDesativadas
            // 
            txbProcurarDesativadas.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txbProcurarDesativadas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txbProcurarDesativadas.Font = new Font("Segoe UI", 10F);
            txbProcurarDesativadas.Location = new Point(3, 8);
            txbProcurarDesativadas.Name = "txbProcurarDesativadas";
            txbProcurarDesativadas.PlaceholderText = "Pesquise por ID, nome ou e-mail";
            txbProcurarDesativadas.Size = new Size(300, 25);
            txbProcurarDesativadas.TabIndex = 1;
            // 
            // btnProcurarDesativadas
            // 
            btnProcurarDesativadas.BackColor = SystemColors.Highlight;
            btnProcurarDesativadas.FlatAppearance.BorderSize = 0;
            btnProcurarDesativadas.FlatStyle = FlatStyle.Flat;
            btnProcurarDesativadas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProcurarDesativadas.ForeColor = Color.White;
            btnProcurarDesativadas.Location = new Point(309, 3);
            btnProcurarDesativadas.Name = "btnProcurarDesativadas";
            btnProcurarDesativadas.Size = new Size(100, 35);
            btnProcurarDesativadas.TabIndex = 1;
            btnProcurarDesativadas.Text = "Procurar";
            btnProcurarDesativadas.UseVisualStyleBackColor = false;
            btnProcurarDesativadas.Click += BtnProcurarDesativadas_Click;
            // 
            // tblRelatorio
            // 
            tblRelatorio.ColumnCount = 1;
            tblRelatorio.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRelatorio.Controls.Add(grpFiltroRelatorio, 0, 0);
            tblRelatorio.Controls.Add(grpGraficoChamado, 0, 1);
            tblRelatorio.Dock = DockStyle.Fill;
            tblRelatorio.Location = new Point(619, 13);
            tblRelatorio.Name = "tblRelatorio";
            tblRelatorio.Padding = new Padding(10);
            tblRelatorio.RowCount = 2;
            tblRelatorio.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tblRelatorio.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tblRelatorio.Size = new Size(601, 542);
            tblRelatorio.TabIndex = 1;
            // 
            // grpFiltroRelatorio
            // 
            grpFiltroRelatorio.AutoSize = true;
            grpFiltroRelatorio.Controls.Add(tblFiltros);
            grpFiltroRelatorio.Dock = DockStyle.Top;
            grpFiltroRelatorio.Font = new Font("Segoe UI Semibold", 12F);
            grpFiltroRelatorio.ForeColor = SystemColors.Highlight;
            grpFiltroRelatorio.Location = new Point(15, 15);
            grpFiltroRelatorio.Margin = new Padding(5);
            grpFiltroRelatorio.Name = "grpFiltroRelatorio";
            grpFiltroRelatorio.Padding = new Padding(10);
            grpFiltroRelatorio.Size = new Size(571, 198);
            grpFiltroRelatorio.TabIndex = 0;
            grpFiltroRelatorio.TabStop = false;
            grpFiltroRelatorio.Text = "Filtros de Relatórios";
            // 
            // tblFiltros
            // 
            tblFiltros.ColumnCount = 2;
            tblFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblFiltros.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblFiltros.Controls.Add(lblPeriodo, 0, 0);
            tblFiltros.Controls.Add(cmbPeriodo, 1, 0);
            tblFiltros.Controls.Add(cmbTecnico, 1, 1);
            tblFiltros.Controls.Add(lblTecnico, 0, 1);
            tblFiltros.Controls.Add(lblCategoria, 0, 2);
            tblFiltros.Controls.Add(cmbCategoria, 1, 2);
            tblFiltros.Controls.Add(lblPrioridade, 0, 3);
            tblFiltros.Controls.Add(cmbPrioridade, 1, 3);
            tblFiltros.Controls.Add(btnGerarRelatorio, 1, 4);
            tblFiltros.Dock = DockStyle.Top;
            tblFiltros.Location = new Point(10, 32);
            tblFiltros.Name = "tblFiltros";
            tblFiltros.Padding = new Padding(5);
            tblFiltros.RowCount = 5;
            tblFiltros.RowStyles.Add(new RowStyle());
            tblFiltros.RowStyles.Add(new RowStyle());
            tblFiltros.RowStyles.Add(new RowStyle());
            tblFiltros.RowStyles.Add(new RowStyle());
            tblFiltros.RowStyles.Add(new RowStyle());
            tblFiltros.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblFiltros.Size = new Size(551, 158);
            tblFiltros.TabIndex = 0;
            // 
            // lblPeriodo
            // 
            lblPeriodo.AutoSize = true;
            lblPeriodo.Dock = DockStyle.Fill;
            lblPeriodo.Font = new Font("Segoe UI Semibold", 9F);
            lblPeriodo.ForeColor = Color.Black;
            lblPeriodo.Location = new Point(8, 5);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Padding = new Padding(0, 4, 0, 4);
            lblPeriodo.Size = new Size(264, 29);
            lblPeriodo.TabIndex = 0;
            lblPeriodo.Text = "Período";
            lblPeriodo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbPeriodo
            // 
            cmbPeriodo.Dock = DockStyle.Fill;
            cmbPeriodo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriodo.Font = new Font("Segoe UI", 9F);
            cmbPeriodo.FormattingEnabled = true;
            cmbPeriodo.Items.AddRange(new object[] { "Diário", "Semanal", "Mensal", "Semestral", "Anual" });
            cmbPeriodo.Location = new Point(278, 8);
            cmbPeriodo.Name = "cmbPeriodo";
            cmbPeriodo.Size = new Size(265, 23);
            cmbPeriodo.TabIndex = 1;
            // 
            // cmbTecnico
            // 
            cmbTecnico.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTecnico.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbTecnico.Dock = DockStyle.Fill;
            cmbTecnico.Font = new Font("Segoe UI", 9F);
            cmbTecnico.FormattingEnabled = true;
            cmbTecnico.Location = new Point(278, 37);
            cmbTecnico.Name = "cmbTecnico";
            cmbTecnico.Size = new Size(265, 23);
            cmbTecnico.TabIndex = 3;
            // 
            // lblTecnico
            // 
            lblTecnico.AutoSize = true;
            lblTecnico.Dock = DockStyle.Fill;
            lblTecnico.Font = new Font("Segoe UI Semibold", 9F);
            lblTecnico.ForeColor = Color.Black;
            lblTecnico.Location = new Point(8, 34);
            lblTecnico.Name = "lblTecnico";
            lblTecnico.Padding = new Padding(0, 4, 0, 4);
            lblTecnico.Size = new Size(264, 29);
            lblTecnico.TabIndex = 2;
            lblTecnico.Text = "Técnico (opicional)";
            lblTecnico.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Dock = DockStyle.Fill;
            lblCategoria.Font = new Font("Segoe UI Semibold", 9F);
            lblCategoria.ForeColor = Color.Black;
            lblCategoria.Location = new Point(8, 63);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Padding = new Padding(0, 4, 0, 4);
            lblCategoria.Size = new Size(264, 29);
            lblCategoria.TabIndex = 4;
            lblCategoria.Text = "Categoria (opcional)";
            lblCategoria.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbCategoria
            // 
            cmbCategoria.Dock = DockStyle.Fill;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Font = new Font("Segoe UI", 9F);
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(278, 66);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(265, 23);
            cmbCategoria.TabIndex = 5;
            // 
            // lblPrioridade
            // 
            lblPrioridade.AutoSize = true;
            lblPrioridade.Dock = DockStyle.Fill;
            lblPrioridade.Font = new Font("Segoe UI Semibold", 9F);
            lblPrioridade.ForeColor = Color.Black;
            lblPrioridade.Location = new Point(8, 92);
            lblPrioridade.Name = "lblPrioridade";
            lblPrioridade.Padding = new Padding(0, 4, 0, 4);
            lblPrioridade.Size = new Size(264, 29);
            lblPrioridade.TabIndex = 7;
            lblPrioridade.Text = "Prioridade (opcional)";
            lblPrioridade.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbPrioridade
            // 
            cmbPrioridade.Dock = DockStyle.Fill;
            cmbPrioridade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrioridade.Font = new Font("Segoe UI", 9F);
            cmbPrioridade.FormattingEnabled = true;
            cmbPrioridade.Location = new Point(278, 95);
            cmbPrioridade.Name = "cmbPrioridade";
            cmbPrioridade.Size = new Size(265, 23);
            cmbPrioridade.TabIndex = 8;
            // 
            // btnGerarRelatorio
            // 
            btnGerarRelatorio.Anchor = AnchorStyles.None;
            btnGerarRelatorio.AutoSize = true;
            btnGerarRelatorio.BackColor = SystemColors.Highlight;
            tblFiltros.SetColumnSpan(btnGerarRelatorio, 2);
            btnGerarRelatorio.Cursor = Cursors.Hand;
            btnGerarRelatorio.FlatAppearance.BorderSize = 0;
            btnGerarRelatorio.FlatStyle = FlatStyle.Flat;
            btnGerarRelatorio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGerarRelatorio.ForeColor = Color.White;
            btnGerarRelatorio.Location = new Point(214, 124);
            btnGerarRelatorio.Name = "btnGerarRelatorio";
            btnGerarRelatorio.Size = new Size(123, 26);
            btnGerarRelatorio.TabIndex = 9;
            btnGerarRelatorio.Text = "Gerar Relatório";
            btnGerarRelatorio.UseVisualStyleBackColor = false;
            // 
            // grpGraficoChamado
            // 
            grpGraficoChamado.Controls.Add(chartChamadosDiarios);
            grpGraficoChamado.Dock = DockStyle.Fill;
            grpGraficoChamado.Font = new Font("Segoe UI Semibold", 10F);
            grpGraficoChamado.Location = new Point(15, 223);
            grpGraficoChamado.Margin = new Padding(5);
            grpGraficoChamado.Name = "grpGraficoChamado";
            grpGraficoChamado.Padding = new Padding(10);
            grpGraficoChamado.Size = new Size(571, 304);
            grpGraficoChamado.TabIndex = 1;
            grpGraficoChamado.TabStop = false;
            grpGraficoChamado.Text = "Resumo Diário de Chamados";
            // 
            // chartChamadosDiarios
            // 
            chartChamadosDiarios.BackColor = Color.Transparent;
            chartChamadosDiarios.BorderlineColor = Color.LightGray;
            chartChamadosDiarios.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Title = "Status";
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.Title = "Chamados";
            chartArea1.Name = "MainArea";
            chartChamadosDiarios.ChartAreas.Add(chartArea1);
            chartChamadosDiarios.Dock = DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            chartChamadosDiarios.Legends.Add(legend1);
            chartChamadosDiarios.Location = new Point(10, 28);
            chartChamadosDiarios.Name = "chartChamadosDiarios";
            chartChamadosDiarios.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "MainArea";
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "SerieChamados";
            dataPoint1.AxisLabel = "Aberto";
            dataPoint1.Color = Color.DodgerBlue;
            dataPoint2.AxisLabel = "Em Atendimento";
            dataPoint2.Color = Color.Orange;
            dataPoint3.AxisLabel = "Resolvido";
            dataPoint3.Color = Color.MediumSeaGreen;
            dataPoint4.AxisLabel = "Encerrado";
            dataPoint4.Color = Color.Gray;
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            chartChamadosDiarios.Series.Add(series1);
            chartChamadosDiarios.Size = new Size(551, 266);
            chartChamadosDiarios.TabIndex = 0;
            chartChamadosDiarios.Text = "chart1";
            title1.Font = new Font("Segoe UI Semibold", 12F);
            title1.Name = "Title1";
            title1.Text = "Chamados Diários";
            chartChamadosDiarios.Titles.Add(title1);
            // 
            // MainFormAdmin
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1233, 636);
            Controls.Add(tblPrincipal);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10F);
            Name = "MainFormAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Suporte Técnico";
            WindowState = FormWindowState.Maximized;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPerfil).EndInit();
            tblPrincipal.ResumeLayout(false);
            tblGestao.ResumeLayout(false);
            tblGestao.PerformLayout();
            flpPesquisar.ResumeLayout(false);
            flpPesquisar.PerformLayout();
            grbResultaPesquisa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResultadoPesquisa).EndInit();
            grbDesativadas.ResumeLayout(false);
            tblDesativadas.ResumeLayout(false);
            tblDesativadas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDesativadas).EndInit();
            flpDesativadas.ResumeLayout(false);
            flpDesativadas.PerformLayout();
            tblRelatorio.ResumeLayout(false);
            tblRelatorio.PerformLayout();
            grpFiltroRelatorio.ResumeLayout(false);
            tblFiltros.ResumeLayout(false);
            tblFiltros.PerformLayout();
            grpGraficoChamado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartChamadosDiarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private PictureBox pbLogo;
        private Label lblLogo;
        public PictureBox pbPerfil;
        private TableLayoutPanel tblPrincipal;
        private TableLayoutPanel tblGestao;
        private Label lblGestao;
        private FlowLayoutPanel flpPesquisar;
        private GroupBox grbResultaPesquisa;
        private TextBox txbPesquisar;
        private DataGridView dgvResultadoPesquisa;
        private TableLayoutPanel tblRelatorio;
        private GroupBox grpFiltroRelatorio;
        private GroupBox grpGraficoChamado;
        private TableLayoutPanel tblFiltros;
        private Label lblPeriodo;
        private ComboBox cmbPeriodo;
        private Label lblTecnico;
        private ComboBox cmbTecnico;
        private Label lblCategoria;
        private ComboBox cmbCategoria;
        private Label lblPrioridade;
        private ComboBox cmbPrioridade;
        private Button btnGerarRelatorio;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartChamadosDiarios;
        private Button btnAdicionarUsuario;
        private GroupBox grbDesativadas;
        private TableLayoutPanel tblDesativadas;
        private DataGridView dgvDesativadas;
        private FlowLayoutPanel flpDesativadas;
        private TextBox txbProcurarDesativadas;
        private Button btnProcurarDesativadas;
        private Label lblPesquisar;
        private DataGridViewTextBoxColumn IdUsuario;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Tipo;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewButtonColumn Editar;
        private DataGridViewButtonColumn Desativar;
        private DataGridViewTextBoxColumn IdDesativado;
        private DataGridViewTextBoxColumn NomeDesativado;
        private DataGridViewTextBoxColumn EmailDesativado;
        private DataGridViewButtonColumn ReativarConta;
        private DataGridViewButtonColumn ApagarConta;
    }
}