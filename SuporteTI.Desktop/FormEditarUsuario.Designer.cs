namespace SuporteTI.Desktop
{
    partial class FormEditarUsuario
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
            tblPrincipal = new TableLayoutPanel();
            lblCabecalho = new Label();
            tblCampos = new TableLayoutPanel();
            txbId = new TextBox();
            lblId = new Label();
            lblNome = new Label();
            txbNome = new TextBox();
            lblEmail = new Label();
            lblCpf = new Label();
            lblTelefone = new Label();
            txbEmail = new TextBox();
            mtbCpf = new MaskedTextBox();
            mtbTelefone = new MaskedTextBox();
            flpRodape = new FlowLayoutPanel();
            btnCancelar = new Button();
            btnAtualizar = new Button();
            lblEndereco = new Label();
            txbEndereco = new TextBox();
            lblDataNascimento = new Label();
            msbDataNascimento = new MaskedTextBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            tblPrincipal.SuspendLayout();
            tblCampos.SuspendLayout();
            flpRodape.SuspendLayout();
            SuspendLayout();
            // 
            // tblPrincipal
            // 
            tblPrincipal.ColumnCount = 1;
            tblPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPrincipal.Controls.Add(lblCabecalho, 0, 0);
            tblPrincipal.Controls.Add(tblCampos, 0, 1);
            tblPrincipal.Controls.Add(flpRodape, 0, 2);
            tblPrincipal.Dock = DockStyle.Fill;
            tblPrincipal.Location = new Point(0, 0);
            tblPrincipal.Name = "tblPrincipal";
            tblPrincipal.Padding = new Padding(20);
            tblPrincipal.RowCount = 3;
            tblPrincipal.RowStyles.Add(new RowStyle());
            tblPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPrincipal.RowStyles.Add(new RowStyle());
            tblPrincipal.Size = new Size(584, 511);
            tblPrincipal.TabIndex = 1;
            // 
            // lblCabecalho
            // 
            lblCabecalho.AutoSize = true;
            lblCabecalho.Dock = DockStyle.Top;
            lblCabecalho.Font = new Font("Segoe UI Semibold", 14F);
            lblCabecalho.ForeColor = SystemColors.Highlight;
            lblCabecalho.Location = new Point(23, 20);
            lblCabecalho.Name = "lblCabecalho";
            lblCabecalho.Padding = new Padding(0, 0, 0, 10);
            lblCabecalho.Size = new Size(538, 35);
            lblCabecalho.TabIndex = 0;
            lblCabecalho.Text = "Editar Usuário";
            // 
            // tblCampos
            // 
            tblCampos.ColumnCount = 2;
            tblCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tblCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tblCampos.Controls.Add(cmbStatus, 1, 7);
            tblCampos.Controls.Add(lblStatus, 0, 7);
            tblCampos.Controls.Add(msbDataNascimento, 1, 6);
            tblCampos.Controls.Add(lblDataNascimento, 0, 6);
            tblCampos.Controls.Add(txbEndereco, 1, 5);
            tblCampos.Controls.Add(lblEndereco, 0, 5);
            tblCampos.Controls.Add(txbId, 1, 0);
            tblCampos.Controls.Add(lblId, 0, 0);
            tblCampos.Controls.Add(lblNome, 0, 1);
            tblCampos.Controls.Add(txbNome, 1, 1);
            tblCampos.Controls.Add(lblEmail, 0, 2);
            tblCampos.Controls.Add(lblCpf, 0, 3);
            tblCampos.Controls.Add(lblTelefone, 0, 4);
            tblCampos.Controls.Add(txbEmail, 1, 2);
            tblCampos.Controls.Add(mtbCpf, 1, 3);
            tblCampos.Controls.Add(mtbTelefone, 1, 4);
            tblCampos.Dock = DockStyle.Fill;
            tblCampos.Location = new Point(23, 58);
            tblCampos.Name = "tblCampos";
            tblCampos.Padding = new Padding(10);
            tblCampos.RowCount = 8;
            tblCampos.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblCampos.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblCampos.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblCampos.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblCampos.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblCampos.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblCampos.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblCampos.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tblCampos.Size = new Size(538, 364);
            tblCampos.TabIndex = 1;
            // 
            // txbId
            // 
            txbId.Anchor = AnchorStyles.Left;
            txbId.BorderStyle = BorderStyle.FixedSingle;
            txbId.Location = new Point(194, 20);
            txbId.Name = "txbId";
            txbId.ReadOnly = true;
            txbId.Size = new Size(100, 23);
            txbId.TabIndex = 12;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Dock = DockStyle.Fill;
            lblId.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblId.Location = new Point(13, 10);
            lblId.Name = "lblId";
            lblId.Padding = new Padding(0, 3, 0, 3);
            lblId.Size = new Size(175, 43);
            lblId.TabIndex = 0;
            lblId.Text = "ID do Usuário:";
            lblId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Dock = DockStyle.Fill;
            lblNome.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblNome.Location = new Point(13, 53);
            lblNome.Name = "lblNome";
            lblNome.Padding = new Padding(0, 3, 0, 3);
            lblNome.Size = new Size(175, 43);
            lblNome.TabIndex = 2;
            lblNome.Text = "Nome Completo:";
            lblNome.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txbNome
            // 
            txbNome.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txbNome.BorderStyle = BorderStyle.FixedSingle;
            txbNome.Location = new Point(194, 63);
            txbNome.Name = "txbNome";
            txbNome.Size = new Size(331, 23);
            txbNome.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Dock = DockStyle.Fill;
            lblEmail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(13, 96);
            lblEmail.Name = "lblEmail";
            lblEmail.Padding = new Padding(0, 3, 0, 3);
            lblEmail.Size = new Size(175, 43);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "E-mail:";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCpf
            // 
            lblCpf.AutoSize = true;
            lblCpf.Dock = DockStyle.Fill;
            lblCpf.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCpf.Location = new Point(13, 139);
            lblCpf.Name = "lblCpf";
            lblCpf.Padding = new Padding(0, 3, 0, 3);
            lblCpf.Size = new Size(175, 43);
            lblCpf.TabIndex = 5;
            lblCpf.Text = "CPF:";
            lblCpf.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.Dock = DockStyle.Fill;
            lblTelefone.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblTelefone.Location = new Point(13, 182);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Padding = new Padding(0, 3, 0, 3);
            lblTelefone.Size = new Size(175, 43);
            lblTelefone.TabIndex = 6;
            lblTelefone.Text = "Telefone:";
            lblTelefone.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txbEmail
            // 
            txbEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txbEmail.BorderStyle = BorderStyle.FixedSingle;
            txbEmail.Location = new Point(194, 106);
            txbEmail.Name = "txbEmail";
            txbEmail.Size = new Size(331, 23);
            txbEmail.TabIndex = 7;
            // 
            // mtbCpf
            // 
            mtbCpf.BorderStyle = BorderStyle.FixedSingle;
            mtbCpf.Location = new Point(194, 142);
            mtbCpf.Mask = "000.000.000-00";
            mtbCpf.Name = "mtbCpf";
            mtbCpf.Size = new Size(120, 23);
            mtbCpf.TabIndex = 8;
            // 
            // mtbTelefone
            // 
            mtbTelefone.BorderStyle = BorderStyle.FixedSingle;
            mtbTelefone.Location = new Point(194, 185);
            mtbTelefone.Mask = "(00) 00000-0000";
            mtbTelefone.Name = "mtbTelefone";
            mtbTelefone.Size = new Size(130, 23);
            mtbTelefone.TabIndex = 9;
            // 
            // flpRodape
            // 
            flpRodape.Controls.Add(btnCancelar);
            flpRodape.Controls.Add(btnAtualizar);
            flpRodape.Dock = DockStyle.Bottom;
            flpRodape.Location = new Point(23, 428);
            flpRodape.Name = "flpRodape";
            flpRodape.Padding = new Padding(0, 10, 0, 0);
            flpRodape.Size = new Size(538, 60);
            flpRodape.TabIndex = 2;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.ButtonShadow;
            btnCancelar.BackgroundImageLayout = ImageLayout.None;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI Semibold", 9F);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(5, 15);
            btnCancelar.Margin = new Padding(5);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAtualizar
            // 
            btnAtualizar.BackColor = Color.ForestGreen;
            btnAtualizar.BackgroundImageLayout = ImageLayout.None;
            btnAtualizar.Cursor = Cursors.Hand;
            btnAtualizar.FlatAppearance.BorderSize = 0;
            btnAtualizar.FlatStyle = FlatStyle.Flat;
            btnAtualizar.Font = new Font("Segoe UI Semibold", 9F);
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.Location = new Point(90, 15);
            btnAtualizar.Margin = new Padding(5);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(75, 23);
            btnAtualizar.TabIndex = 2;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = false;
            // 
            // lblEndereco
            // 
            lblEndereco.AutoSize = true;
            lblEndereco.Dock = DockStyle.Fill;
            lblEndereco.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblEndereco.Location = new Point(13, 225);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Padding = new Padding(0, 3, 0, 3);
            lblEndereco.Size = new Size(175, 43);
            lblEndereco.TabIndex = 19;
            lblEndereco.Text = "Endereço:";
            lblEndereco.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txbEndereco
            // 
            txbEndereco.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txbEndereco.BorderStyle = BorderStyle.FixedSingle;
            txbEndereco.Location = new Point(194, 235);
            txbEndereco.Name = "txbEndereco";
            txbEndereco.Size = new Size(331, 23);
            txbEndereco.TabIndex = 20;
            // 
            // lblDataNascimento
            // 
            lblDataNascimento.AutoSize = true;
            lblDataNascimento.Dock = DockStyle.Fill;
            lblDataNascimento.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDataNascimento.Location = new Point(13, 268);
            lblDataNascimento.Name = "lblDataNascimento";
            lblDataNascimento.Padding = new Padding(0, 3, 0, 3);
            lblDataNascimento.Size = new Size(175, 43);
            lblDataNascimento.TabIndex = 21;
            lblDataNascimento.Text = "Data de Nascimento:";
            lblDataNascimento.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // msbDataNascimento
            // 
            msbDataNascimento.BorderStyle = BorderStyle.FixedSingle;
            msbDataNascimento.Location = new Point(194, 271);
            msbDataNascimento.Mask = "00/00/0000";
            msbDataNascimento.Name = "msbDataNascimento";
            msbDataNascimento.Size = new Size(120, 23);
            msbDataNascimento.TabIndex = 22;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI Semibold", 9F);
            lblStatus.Location = new Point(13, 311);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(0, 3, 0, 3);
            lblStatus.Size = new Size(175, 43);
            lblStatus.TabIndex = 23;
            lblStatus.Text = "Status da Conta:";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbStatus
            // 
            cmbStatus.Anchor = AnchorStyles.Left;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Ativo", "Desativado" });
            cmbStatus.Location = new Point(194, 321);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(150, 23);
            cmbStatus.TabIndex = 24;
            // 
            // FormEditarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(584, 511);
            Controls.Add(tblPrincipal);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormEditarUsuario";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Editar Usuário";
            tblPrincipal.ResumeLayout(false);
            tblPrincipal.PerformLayout();
            tblCampos.ResumeLayout(false);
            tblCampos.PerformLayout();
            flpRodape.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblPrincipal;
        private Label lblCabecalho;
        private TableLayoutPanel tblCampos;
        private Label lblId;
        private Label lblNome;
        private TextBox txbNome;
        private Label lblEmail;
        private Label lblCpf;
        private Label lblTelefone;
        private TextBox txbEmail;
        private MaskedTextBox mtbCpf;
        private MaskedTextBox mtbTelefone;
        private FlowLayoutPanel flpRodape;
        private Button btnCancelar;
        private Button btnAtualizar;
        private TextBox txbId;
        private Label lblEndereco;
        private TextBox txbEndereco;
        private Label lblDataNascimento;
        private MaskedTextBox msbDataNascimento;
        private Label lblStatus;
        private ComboBox cmbStatus;
    }
}