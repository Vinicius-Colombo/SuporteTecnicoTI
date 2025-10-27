namespace SuporteTI.Desktop
{
    partial class FormRelatorioDetalhado
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            tblRelatorio = new TableLayoutPanel();
            pnlResumo = new Panel();
            flpCardsResumo = new FlowLayoutPanel();
            pnlTotalChamados = new Panel();
            lblTotalChamadosValor = new Label();
            lblTotalChamados = new Label();
            pnlTempomedio = new Panel();
            lTempoMedioValor = new Label();
            lblTempoMedio = new Label();
            pnlResolvidosPrazo = new Panel();
            lblResolvidoPrazoValor = new Label();
            lblResolvidosPrazo = new Label();
            pnlTopCategoria = new Panel();
            lblCategoriaValor = new Label();
            lblTopCategoria = new Label();
            pnlTotalAvaliacoes = new Panel();
            lblTotalAvaliacoesValor = new Label();
            lblTotalAvaliacoes = new Label();
            tabRelatorio = new TabControl();
            Tabela = new TabPage();
            dgvChamadosDetalhados = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            DataAbertura = new DataGridViewTextBoxColumn();
            Tecnico = new DataGridViewTextBoxColumn();
            Categoria = new DataGridViewTextBoxColumn();
            Prioridade = new DataGridViewTextBoxColumn();
            TempoAtendimento = new DataGridViewTextBoxColumn();
            Cliente = new DataGridViewTextBoxColumn();
            Rankings = new TabPage();
            tblRankings = new TableLayoutPanel();
            lblRankingTecnicos = new Label();
            lvlCategoriaMais = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            lvlDetalhesTecnicos = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            lblRankingCategoria = new Label();
            Avaliacoes = new TabPage();
            dgvAvaliacoes = new DataGridView();
            IdChamado = new DataGridViewTextBoxColumn();
            Titulo = new DataGridViewTextBoxColumn();
            Técnico = new DataGridViewTextBoxColumn();
            Nota = new DataGridViewTextBoxColumn();
            Comentario = new DataGridViewTextBoxColumn();
            flwRodape = new FlowLayoutPanel();
            btnFechar = new Button();
            btnBaixarPDF = new Button();
            chartEvolucao = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartPrioridade = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartCategorias = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tblRelatorio.SuspendLayout();
            pnlResumo.SuspendLayout();
            flpCardsResumo.SuspendLayout();
            pnlTotalChamados.SuspendLayout();
            pnlTempomedio.SuspendLayout();
            pnlResolvidosPrazo.SuspendLayout();
            pnlTopCategoria.SuspendLayout();
            pnlTotalAvaliacoes.SuspendLayout();
            tabRelatorio.SuspendLayout();
            Tabela.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChamadosDetalhados).BeginInit();
            Rankings.SuspendLayout();
            tblRankings.SuspendLayout();
            Avaliacoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAvaliacoes).BeginInit();
            flwRodape.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartEvolucao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartPrioridade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartCategorias).BeginInit();
            SuspendLayout();
            // 
            // tblRelatorio
            // 
            tblRelatorio.ColumnCount = 1;
            tblRelatorio.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblRelatorio.Controls.Add(pnlResumo, 0, 0);
            tblRelatorio.Controls.Add(tabRelatorio, 0, 1);
            tblRelatorio.Controls.Add(flwRodape, 0, 2);
            tblRelatorio.Dock = DockStyle.Fill;
            tblRelatorio.Location = new Point(0, 0);
            tblRelatorio.Name = "tblRelatorio";
            tblRelatorio.Padding = new Padding(10);
            tblRelatorio.RowCount = 3;
            tblRelatorio.RowStyles.Add(new RowStyle());
            tblRelatorio.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblRelatorio.RowStyles.Add(new RowStyle());
            tblRelatorio.Size = new Size(1233, 636);
            tblRelatorio.TabIndex = 0;
            // 
            // pnlResumo
            // 
            pnlResumo.BackColor = SystemColors.Control;
            pnlResumo.Controls.Add(flpCardsResumo);
            pnlResumo.Dock = DockStyle.Top;
            pnlResumo.Location = new Point(13, 13);
            pnlResumo.Name = "pnlResumo";
            pnlResumo.Padding = new Padding(10);
            pnlResumo.Size = new Size(1207, 120);
            pnlResumo.TabIndex = 0;
            // 
            // flpCardsResumo
            // 
            flpCardsResumo.AutoSize = true;
            flpCardsResumo.BackColor = Color.Transparent;
            flpCardsResumo.Controls.Add(pnlTotalChamados);
            flpCardsResumo.Controls.Add(pnlTempomedio);
            flpCardsResumo.Controls.Add(pnlResolvidosPrazo);
            flpCardsResumo.Controls.Add(pnlTopCategoria);
            flpCardsResumo.Controls.Add(pnlTotalAvaliacoes);
            flpCardsResumo.Dock = DockStyle.Fill;
            flpCardsResumo.Location = new Point(10, 10);
            flpCardsResumo.Name = "flpCardsResumo";
            flpCardsResumo.Padding = new Padding(10, 0, 0, 0);
            flpCardsResumo.Size = new Size(1187, 100);
            flpCardsResumo.TabIndex = 0;
            flpCardsResumo.WrapContents = false;
            // 
            // pnlTotalChamados
            // 
            pnlTotalChamados.BackColor = Color.White;
            pnlTotalChamados.BorderStyle = BorderStyle.FixedSingle;
            pnlTotalChamados.Controls.Add(lblTotalChamadosValor);
            pnlTotalChamados.Controls.Add(lblTotalChamados);
            pnlTotalChamados.Location = new Point(20, 8);
            pnlTotalChamados.Margin = new Padding(10, 8, 10, 8);
            pnlTotalChamados.Name = "pnlTotalChamados";
            pnlTotalChamados.Padding = new Padding(8);
            pnlTotalChamados.Size = new Size(200, 80);
            pnlTotalChamados.TabIndex = 0;
            // 
            // lblTotalChamadosValor
            // 
            lblTotalChamadosValor.AutoSize = true;
            lblTotalChamadosValor.Dock = DockStyle.Bottom;
            lblTotalChamadosValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalChamadosValor.ForeColor = SystemColors.Highlight;
            lblTotalChamadosValor.Location = new Point(8, 45);
            lblTotalChamadosValor.Name = "lblTotalChamadosValor";
            lblTotalChamadosValor.Size = new Size(23, 25);
            lblTotalChamadosValor.TabIndex = 1;
            lblTotalChamadosValor.Text = "0";
            // 
            // lblTotalChamados
            // 
            lblTotalChamados.AutoSize = true;
            lblTotalChamados.Dock = DockStyle.Top;
            lblTotalChamados.Font = new Font("Segoe UI Semibold", 9F);
            lblTotalChamados.ForeColor = Color.Gray;
            lblTotalChamados.Location = new Point(8, 8);
            lblTotalChamados.Name = "lblTotalChamados";
            lblTotalChamados.Size = new Size(108, 15);
            lblTotalChamados.TabIndex = 0;
            lblTotalChamados.Text = "Total de Chamados";
            // 
            // pnlTempomedio
            // 
            pnlTempomedio.BackColor = Color.White;
            pnlTempomedio.BorderStyle = BorderStyle.FixedSingle;
            pnlTempomedio.Controls.Add(lTempoMedioValor);
            pnlTempomedio.Controls.Add(lblTempoMedio);
            pnlTempomedio.Location = new Point(240, 8);
            pnlTempomedio.Margin = new Padding(10, 8, 10, 8);
            pnlTempomedio.Name = "pnlTempomedio";
            pnlTempomedio.Padding = new Padding(8);
            pnlTempomedio.Size = new Size(200, 80);
            pnlTempomedio.TabIndex = 1;
            // 
            // lTempoMedioValor
            // 
            lTempoMedioValor.AutoSize = true;
            lTempoMedioValor.Dock = DockStyle.Bottom;
            lTempoMedioValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lTempoMedioValor.ForeColor = SystemColors.Highlight;
            lTempoMedioValor.Location = new Point(8, 45);
            lTempoMedioValor.Name = "lTempoMedioValor";
            lTempoMedioValor.Size = new Size(23, 25);
            lTempoMedioValor.TabIndex = 1;
            lTempoMedioValor.Text = "0";
            // 
            // lblTempoMedio
            // 
            lblTempoMedio.AutoSize = true;
            lblTempoMedio.Dock = DockStyle.Top;
            lblTempoMedio.Font = new Font("Segoe UI Semibold", 9F);
            lblTempoMedio.ForeColor = Color.Gray;
            lblTempoMedio.Location = new Point(8, 8);
            lblTempoMedio.Name = "lblTempoMedio";
            lblTempoMedio.Size = new Size(154, 15);
            lblTempoMedio.TabIndex = 0;
            lblTempoMedio.Text = "Tempo Médio de Resolução";
            // 
            // pnlResolvidosPrazo
            // 
            pnlResolvidosPrazo.BackColor = Color.White;
            pnlResolvidosPrazo.BorderStyle = BorderStyle.FixedSingle;
            pnlResolvidosPrazo.Controls.Add(lblResolvidoPrazoValor);
            pnlResolvidosPrazo.Controls.Add(lblResolvidosPrazo);
            pnlResolvidosPrazo.Location = new Point(460, 8);
            pnlResolvidosPrazo.Margin = new Padding(10, 8, 10, 8);
            pnlResolvidosPrazo.Name = "pnlResolvidosPrazo";
            pnlResolvidosPrazo.Padding = new Padding(8);
            pnlResolvidosPrazo.Size = new Size(200, 80);
            pnlResolvidosPrazo.TabIndex = 2;
            // 
            // lblResolvidoPrazoValor
            // 
            lblResolvidoPrazoValor.AutoSize = true;
            lblResolvidoPrazoValor.Dock = DockStyle.Bottom;
            lblResolvidoPrazoValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblResolvidoPrazoValor.ForeColor = SystemColors.Highlight;
            lblResolvidoPrazoValor.Location = new Point(8, 45);
            lblResolvidoPrazoValor.Name = "lblResolvidoPrazoValor";
            lblResolvidoPrazoValor.Size = new Size(23, 25);
            lblResolvidoPrazoValor.TabIndex = 1;
            lblResolvidoPrazoValor.Text = "0";
            // 
            // lblResolvidosPrazo
            // 
            lblResolvidosPrazo.AutoSize = true;
            lblResolvidosPrazo.Dock = DockStyle.Top;
            lblResolvidosPrazo.Font = new Font("Segoe UI Semibold", 9F);
            lblResolvidosPrazo.ForeColor = Color.Gray;
            lblResolvidosPrazo.Location = new Point(8, 8);
            lblResolvidosPrazo.Name = "lblResolvidosPrazo";
            lblResolvidosPrazo.Size = new Size(113, 15);
            lblResolvidosPrazo.TabIndex = 0;
            lblResolvidosPrazo.Text = "Resolvidos no Prazo";
            // 
            // pnlTopCategoria
            // 
            pnlTopCategoria.BackColor = Color.White;
            pnlTopCategoria.BorderStyle = BorderStyle.FixedSingle;
            pnlTopCategoria.Controls.Add(lblCategoriaValor);
            pnlTopCategoria.Controls.Add(lblTopCategoria);
            pnlTopCategoria.Location = new Point(680, 8);
            pnlTopCategoria.Margin = new Padding(10, 8, 10, 8);
            pnlTopCategoria.Name = "pnlTopCategoria";
            pnlTopCategoria.Padding = new Padding(8);
            pnlTopCategoria.Size = new Size(200, 80);
            pnlTopCategoria.TabIndex = 3;
            // 
            // lblCategoriaValor
            // 
            lblCategoriaValor.AutoSize = true;
            lblCategoriaValor.Dock = DockStyle.Bottom;
            lblCategoriaValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCategoriaValor.ForeColor = SystemColors.Highlight;
            lblCategoriaValor.Location = new Point(8, 45);
            lblCategoriaValor.Name = "lblCategoriaValor";
            lblCategoriaValor.Size = new Size(23, 25);
            lblCategoriaValor.TabIndex = 1;
            lblCategoriaValor.Text = "0";
            // 
            // lblTopCategoria
            // 
            lblTopCategoria.AutoSize = true;
            lblTopCategoria.Dock = DockStyle.Top;
            lblTopCategoria.Font = new Font("Segoe UI Semibold", 9F);
            lblTopCategoria.ForeColor = Color.Gray;
            lblTopCategoria.Location = new Point(8, 8);
            lblTopCategoria.Name = "lblTopCategoria";
            lblTopCategoria.Size = new Size(138, 15);
            lblTopCategoria.TabIndex = 0;
            lblTopCategoria.Text = "Categoria Mais Incidente";
            // 
            // pnlTotalAvaliacoes
            // 
            pnlTotalAvaliacoes.BackColor = Color.White;
            pnlTotalAvaliacoes.BorderStyle = BorderStyle.FixedSingle;
            pnlTotalAvaliacoes.Controls.Add(lblTotalAvaliacoesValor);
            pnlTotalAvaliacoes.Controls.Add(lblTotalAvaliacoes);
            pnlTotalAvaliacoes.Location = new Point(900, 8);
            pnlTotalAvaliacoes.Margin = new Padding(10, 8, 10, 8);
            pnlTotalAvaliacoes.Name = "pnlTotalAvaliacoes";
            pnlTotalAvaliacoes.Padding = new Padding(8);
            pnlTotalAvaliacoes.Size = new Size(200, 80);
            pnlTotalAvaliacoes.TabIndex = 4;
            // 
            // lblTotalAvaliacoesValor
            // 
            lblTotalAvaliacoesValor.AutoSize = true;
            lblTotalAvaliacoesValor.Dock = DockStyle.Bottom;
            lblTotalAvaliacoesValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalAvaliacoesValor.ForeColor = SystemColors.Highlight;
            lblTotalAvaliacoesValor.Location = new Point(8, 45);
            lblTotalAvaliacoesValor.Name = "lblTotalAvaliacoesValor";
            lblTotalAvaliacoesValor.Size = new Size(23, 25);
            lblTotalAvaliacoesValor.TabIndex = 1;
            lblTotalAvaliacoesValor.Text = "0";
            // 
            // lblTotalAvaliacoes
            // 
            lblTotalAvaliacoes.AutoSize = true;
            lblTotalAvaliacoes.Dock = DockStyle.Top;
            lblTotalAvaliacoes.Font = new Font("Segoe UI Semibold", 9F);
            lblTotalAvaliacoes.ForeColor = Color.Gray;
            lblTotalAvaliacoes.Location = new Point(8, 8);
            lblTotalAvaliacoes.Name = "lblTotalAvaliacoes";
            lblTotalAvaliacoes.Size = new Size(108, 15);
            lblTotalAvaliacoes.TabIndex = 0;
            lblTotalAvaliacoes.Text = "Total de Avaliações";
            // 
            // tabRelatorio
            // 
            tabRelatorio.Controls.Add(Tabela);
            tabRelatorio.Controls.Add(Rankings);
            tabRelatorio.Controls.Add(Avaliacoes);
            tabRelatorio.Dock = DockStyle.Fill;
            tabRelatorio.Location = new Point(13, 139);
            tabRelatorio.Name = "tabRelatorio";
            tabRelatorio.SelectedIndex = 0;
            tabRelatorio.Size = new Size(1207, 418);
            tabRelatorio.TabIndex = 1;
            // 
            // Tabela
            // 
            Tabela.Controls.Add(dgvChamadosDetalhados);
            Tabela.Location = new Point(4, 24);
            Tabela.Name = "Tabela";
            Tabela.Padding = new Padding(3);
            Tabela.Size = new Size(1199, 390);
            Tabela.TabIndex = 0;
            Tabela.Text = "Tabelas";
            Tabela.UseVisualStyleBackColor = true;
            // 
            // dgvChamadosDetalhados
            // 
            dgvChamadosDetalhados.AllowUserToAddRows = false;
            dgvChamadosDetalhados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChamadosDetalhados.BackgroundColor = Color.WhiteSmoke;
            dgvChamadosDetalhados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChamadosDetalhados.Columns.AddRange(new DataGridViewColumn[] { Id, DataAbertura, Tecnico, Categoria, Prioridade, TempoAtendimento, Cliente });
            dgvChamadosDetalhados.Dock = DockStyle.Fill;
            dgvChamadosDetalhados.Location = new Point(3, 3);
            dgvChamadosDetalhados.Name = "dgvChamadosDetalhados";
            dgvChamadosDetalhados.ReadOnly = true;
            dgvChamadosDetalhados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChamadosDetalhados.Size = new Size(1193, 384);
            dgvChamadosDetalhados.TabIndex = 0;
            // 
            // Id
            // 
            Id.HeaderText = "Nº Chamado";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // DataAbertura
            // 
            DataAbertura.HeaderText = "Abertura";
            DataAbertura.Name = "DataAbertura";
            DataAbertura.ReadOnly = true;
            // 
            // Tecnico
            // 
            Tecnico.HeaderText = "Técnico";
            Tecnico.Name = "Tecnico";
            Tecnico.ReadOnly = true;
            // 
            // Categoria
            // 
            Categoria.HeaderText = "Categoria";
            Categoria.Name = "Categoria";
            Categoria.ReadOnly = true;
            // 
            // Prioridade
            // 
            Prioridade.HeaderText = "Prioridade";
            Prioridade.Name = "Prioridade";
            Prioridade.ReadOnly = true;
            // 
            // TempoAtendimento
            // 
            TempoAtendimento.HeaderText = "Tempo de Atendimento";
            TempoAtendimento.Name = "TempoAtendimento";
            TempoAtendimento.ReadOnly = true;
            // 
            // Cliente
            // 
            Cliente.HeaderText = "Cliente";
            Cliente.Name = "Cliente";
            Cliente.ReadOnly = true;
            // 
            // Rankings
            // 
            Rankings.Controls.Add(tblRankings);
            Rankings.Location = new Point(4, 24);
            Rankings.Name = "Rankings";
            Rankings.Padding = new Padding(3);
            Rankings.Size = new Size(1199, 390);
            Rankings.TabIndex = 2;
            Rankings.Text = "Rankings";
            Rankings.UseVisualStyleBackColor = true;
            // 
            // tblRankings
            // 
            tblRankings.ColumnCount = 2;
            tblRankings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblRankings.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblRankings.Controls.Add(lblRankingTecnicos, 0, 0);
            tblRankings.Controls.Add(lvlCategoriaMais, 1, 1);
            tblRankings.Controls.Add(lvlDetalhesTecnicos, 0, 1);
            tblRankings.Controls.Add(lblRankingCategoria, 1, 0);
            tblRankings.Dock = DockStyle.Fill;
            tblRankings.Location = new Point(3, 3);
            tblRankings.Name = "tblRankings";
            tblRankings.Padding = new Padding(10);
            tblRankings.RowCount = 2;
            tblRankings.RowStyles.Add(new RowStyle());
            tblRankings.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblRankings.Size = new Size(1193, 384);
            tblRankings.TabIndex = 0;
            // 
            // lblRankingTecnicos
            // 
            lblRankingTecnicos.AutoSize = true;
            lblRankingTecnicos.Dock = DockStyle.Fill;
            lblRankingTecnicos.Font = new Font("Segoe UI Semibold", 10F);
            lblRankingTecnicos.Location = new Point(15, 10);
            lblRankingTecnicos.Margin = new Padding(5, 0, 5, 5);
            lblRankingTecnicos.Name = "lblRankingTecnicos";
            lblRankingTecnicos.Padding = new Padding(0, 5, 0, 5);
            lblRankingTecnicos.Size = new Size(576, 29);
            lblRankingTecnicos.TabIndex = 6;
            lblRankingTecnicos.Text = "Técnicos com mais chamados";
            lblRankingTecnicos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lvlCategoriaMais
            // 
            lvlCategoriaMais.BorderStyle = BorderStyle.FixedSingle;
            lvlCategoriaMais.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6 });
            lvlCategoriaMais.Dock = DockStyle.Fill;
            lvlCategoriaMais.FullRowSelect = true;
            lvlCategoriaMais.GridLines = true;
            lvlCategoriaMais.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvlCategoriaMais.Location = new Point(601, 49);
            lvlCategoriaMais.Margin = new Padding(5);
            lvlCategoriaMais.Name = "lvlCategoriaMais";
            lvlCategoriaMais.Size = new Size(577, 320);
            lvlCategoriaMais.TabIndex = 3;
            lvlCategoriaMais.UseCompatibleStateImageBehavior = false;
            lvlCategoriaMais.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Nome";
            columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Quantidade";
            columnHeader6.Width = 100;
            // 
            // lvlDetalhesTecnicos
            // 
            lvlDetalhesTecnicos.BorderStyle = BorderStyle.FixedSingle;
            lvlDetalhesTecnicos.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4 });
            lvlDetalhesTecnicos.Dock = DockStyle.Fill;
            lvlDetalhesTecnicos.FullRowSelect = true;
            lvlDetalhesTecnicos.GridLines = true;
            lvlDetalhesTecnicos.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvlDetalhesTecnicos.Location = new Point(15, 49);
            lvlDetalhesTecnicos.Margin = new Padding(5);
            lvlDetalhesTecnicos.Name = "lvlDetalhesTecnicos";
            lvlDetalhesTecnicos.Size = new Size(576, 320);
            lvlDetalhesTecnicos.TabIndex = 2;
            lvlDetalhesTecnicos.UseCompatibleStateImageBehavior = false;
            lvlDetalhesTecnicos.View = View.Details;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Nome";
            columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Quantidade";
            columnHeader4.Width = 100;
            // 
            // lblRankingCategoria
            // 
            lblRankingCategoria.AutoSize = true;
            lblRankingCategoria.Dock = DockStyle.Fill;
            lblRankingCategoria.Font = new Font("Segoe UI Semibold", 10F);
            lblRankingCategoria.Location = new Point(601, 10);
            lblRankingCategoria.Margin = new Padding(5, 0, 5, 5);
            lblRankingCategoria.Name = "lblRankingCategoria";
            lblRankingCategoria.Padding = new Padding(0, 5, 0, 5);
            lblRankingCategoria.Size = new Size(577, 29);
            lblRankingCategoria.TabIndex = 5;
            lblRankingCategoria.Text = "Categorias mais incidentes";
            lblRankingCategoria.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Avaliacoes
            // 
            Avaliacoes.Controls.Add(dgvAvaliacoes);
            Avaliacoes.Location = new Point(4, 24);
            Avaliacoes.Name = "Avaliacoes";
            Avaliacoes.Padding = new Padding(3);
            Avaliacoes.Size = new Size(1199, 390);
            Avaliacoes.TabIndex = 3;
            Avaliacoes.Text = "Avaliações";
            Avaliacoes.UseVisualStyleBackColor = true;
            // 
            // dgvAvaliacoes
            // 
            dgvAvaliacoes.AllowUserToAddRows = false;
            dgvAvaliacoes.AllowUserToDeleteRows = false;
            dgvAvaliacoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAvaliacoes.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAvaliacoes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAvaliacoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAvaliacoes.Columns.AddRange(new DataGridViewColumn[] { IdChamado, Titulo, Técnico, Nota, Comentario });
            dgvAvaliacoes.Dock = DockStyle.Fill;
            dgvAvaliacoes.GridColor = Color.Gray;
            dgvAvaliacoes.Location = new Point(3, 3);
            dgvAvaliacoes.Name = "dgvAvaliacoes";
            dgvAvaliacoes.ReadOnly = true;
            dgvAvaliacoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAvaliacoes.Size = new Size(1193, 384);
            dgvAvaliacoes.TabIndex = 0;
            // 
            // IdChamado
            // 
            IdChamado.HeaderText = "Nº Chamado";
            IdChamado.Name = "IdChamado";
            IdChamado.ReadOnly = true;
            // 
            // Titulo
            // 
            Titulo.HeaderText = "Titulo";
            Titulo.Name = "Titulo";
            Titulo.ReadOnly = true;
            // 
            // Técnico
            // 
            Técnico.HeaderText = "Técnico Responsável";
            Técnico.Name = "Técnico";
            Técnico.ReadOnly = true;
            // 
            // Nota
            // 
            Nota.HeaderText = "Nota";
            Nota.Name = "Nota";
            Nota.ReadOnly = true;
            // 
            // Comentario
            // 
            Comentario.HeaderText = "Comentário";
            Comentario.Name = "Comentario";
            Comentario.ReadOnly = true;
            // 
            // flwRodape
            // 
            flwRodape.Controls.Add(btnFechar);
            flwRodape.Controls.Add(btnBaixarPDF);
            flwRodape.Dock = DockStyle.Bottom;
            flwRodape.FlowDirection = FlowDirection.RightToLeft;
            flwRodape.Location = new Point(13, 563);
            flwRodape.Name = "flwRodape";
            flwRodape.Padding = new Padding(10);
            flwRodape.Size = new Size(1207, 60);
            flwRodape.TabIndex = 2;
            // 
            // btnFechar
            // 
            btnFechar.BackColor = SystemColors.ButtonShadow;
            btnFechar.Cursor = Cursors.Hand;
            btnFechar.FlatAppearance.BorderSize = 0;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Font = new Font("Segoe UI Semibold", 9F);
            btnFechar.ForeColor = Color.White;
            btnFechar.Location = new Point(1109, 13);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(75, 23);
            btnFechar.TabIndex = 0;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = false;
            // 
            // btnBaixarPDF
            // 
            btnBaixarPDF.BackColor = Color.ForestGreen;
            btnBaixarPDF.Cursor = Cursors.Hand;
            btnBaixarPDF.FlatAppearance.BorderSize = 0;
            btnBaixarPDF.FlatStyle = FlatStyle.Flat;
            btnBaixarPDF.Font = new Font("Segoe UI Semibold", 9F);
            btnBaixarPDF.ForeColor = Color.White;
            btnBaixarPDF.Location = new Point(1028, 13);
            btnBaixarPDF.Name = "btnBaixarPDF";
            btnBaixarPDF.Size = new Size(75, 23);
            btnBaixarPDF.TabIndex = 1;
            btnBaixarPDF.Text = "Baixar PDF";
            btnBaixarPDF.UseVisualStyleBackColor = false;
            // 
            // chartEvolucao
            // 
            chartArea1.Name = "ChartArea1";
            chartEvolucao.ChartAreas.Add(chartArea1);
            chartEvolucao.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartEvolucao.Legends.Add(legend1);
            chartEvolucao.Location = new Point(3, 259);
            chartEvolucao.Name = "chartEvolucao";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartEvolucao.Series.Add(series1);
            chartEvolucao.Size = new Size(1187, 122);
            chartEvolucao.TabIndex = 2;
            title1.Font = new Font("Segoe UI Semibold", 8F);
            title1.Name = "Title1";
            title1.Text = "Evolução de chamados no tempo";
            chartEvolucao.Titles.Add(title1);
            // 
            // chartPrioridade
            // 
            chartArea2.Name = "ChartArea1";
            chartPrioridade.ChartAreas.Add(chartArea2);
            chartPrioridade.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            chartPrioridade.Legends.Add(legend2);
            chartPrioridade.Location = new Point(3, 131);
            chartPrioridade.Name = "chartPrioridade";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartPrioridade.Series.Add(series2);
            chartPrioridade.Size = new Size(1187, 122);
            chartPrioridade.TabIndex = 1;
            title2.Font = new Font("Segoe UI Semibold", 8F);
            title2.Name = "Title1";
            title2.Text = "Distribuição por prioridade";
            chartPrioridade.Titles.Add(title2);
            // 
            // chartCategorias
            // 
            chartArea3.Name = "ChartArea1";
            chartCategorias.ChartAreas.Add(chartArea3);
            chartCategorias.Dock = DockStyle.Fill;
            legend3.Name = "Legend1";
            chartCategorias.Legends.Add(legend3);
            chartCategorias.Location = new Point(3, 3);
            chartCategorias.Name = "chartCategorias";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chartCategorias.Series.Add(series3);
            chartCategorias.Size = new Size(1187, 122);
            chartCategorias.TabIndex = 0;
            title3.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title3.Name = "Title1";
            title3.Text = "Chamados por Categoria";
            chartCategorias.Titles.Add(title3);
            // 
            // FormRelatorioDetalhado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 636);
            Controls.Add(tblRelatorio);
            Name = "FormRelatorioDetalhado";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Relatório Detalhado";
            tblRelatorio.ResumeLayout(false);
            pnlResumo.ResumeLayout(false);
            pnlResumo.PerformLayout();
            flpCardsResumo.ResumeLayout(false);
            pnlTotalChamados.ResumeLayout(false);
            pnlTotalChamados.PerformLayout();
            pnlTempomedio.ResumeLayout(false);
            pnlTempomedio.PerformLayout();
            pnlResolvidosPrazo.ResumeLayout(false);
            pnlResolvidosPrazo.PerformLayout();
            pnlTopCategoria.ResumeLayout(false);
            pnlTopCategoria.PerformLayout();
            pnlTotalAvaliacoes.ResumeLayout(false);
            pnlTotalAvaliacoes.PerformLayout();
            tabRelatorio.ResumeLayout(false);
            Tabela.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChamadosDetalhados).EndInit();
            Rankings.ResumeLayout(false);
            tblRankings.ResumeLayout(false);
            tblRankings.PerformLayout();
            Avaliacoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAvaliacoes).EndInit();
            flwRodape.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartEvolucao).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartPrioridade).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartCategorias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblRelatorio;
        private Panel pnlResumo;
        private FlowLayoutPanel flpCardsResumo;
        private Panel pnlTotalChamados;
        private Label lblTotalChamadosValor;
        private Label lblTotalChamados;
        private Panel pnlTempomedio;
        private Label lTempoMedioValor;
        private Label lblTempoMedio;
        private Panel pnlResolvidosPrazo;
        private Label lblResolvidoPrazoValor;
        private Label lblResolvidosPrazo;
        private Panel pnlTopCategoria;
        private Label lblCategoriaValor;
        private Label lblTopCategoria;
        private TabControl tabRelatorio;
        private TabPage Tabela;
        private TabPage Rankings;
        private DataGridView dgvChamadosDetalhados;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn DataAbertura;
        private DataGridViewTextBoxColumn Tecnico;
        private DataGridViewTextBoxColumn Categoria;
        private DataGridViewTextBoxColumn Prioridade;
        private DataGridViewTextBoxColumn TempoAtendimento;
        private DataGridViewTextBoxColumn Cliente;
        private FlowLayoutPanel flwRodape;
        private TableLayoutPanel tblRankings;
        private ListView lvlCategoriaMais;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ListView lvlDetalhesTecnicos;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Label lblTotalAvaliacoesValor;
        private Label lblRankingCategoria;
        private Label lblRankingTecnicos;
        private Button btnFechar;
        private Button btnBaixarPDF;
        private TabPage Avaliacoes;
        private DataGridView dgvAvaliacoes;
        private DataGridViewTextBoxColumn IdChamado;
        private DataGridViewTextBoxColumn Titulo;
        private DataGridViewTextBoxColumn Técnico;
        private DataGridViewTextBoxColumn Nota;
        private DataGridViewTextBoxColumn Comentario;
        private Panel pnlTotalAvaliacoes;
        private Label lblTotalAvaliacoes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEvolucao;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPrioridade;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCategorias;
    }
}