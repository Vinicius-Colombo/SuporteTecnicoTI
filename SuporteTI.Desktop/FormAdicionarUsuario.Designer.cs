namespace SuporteTI.Desktop
{
    partial class FormAdicionarUsuario
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
            tblCampos = new TableLayoutPanel();
            clbCategorias = new CheckedListBox();
            lblCategorias = new Label();
            lblDataNascimento = new Label();
            maskedTextBox1 = new MaskedTextBox();
            textBox1 = new TextBox();
            lblEndereco = new Label();
            lblTipo = new Label();
            cmbTipo = new ComboBox();
            lblNome = new Label();
            txbNome = new TextBox();
            lblEmail = new Label();
            lblCpf = new Label();
            lblTelefone = new Label();
            txbEmail = new TextBox();
            mtbCpf = new MaskedTextBox();
            mtbTelefone = new MaskedTextBox();
            lblCabecalho = new Label();
            flpRodape = new FlowLayoutPanel();
            btnCancelar = new Button();
            btnSalvar = new Button();
            tblPrincipal.SuspendLayout();
            tblCampos.SuspendLayout();
            flpRodape.SuspendLayout();
            SuspendLayout();
            // 
            // tblPrincipal
            // 
            tblPrincipal.ColumnCount = 1;
            tblPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPrincipal.Controls.Add(tblCampos, 0, 1);
            tblPrincipal.Controls.Add(lblCabecalho, 0, 0);
            tblPrincipal.Controls.Add(flpRodape, 0, 2);
            tblPrincipal.Dock = DockStyle.Fill;
            tblPrincipal.Location = new Point(0, 0);
            tblPrincipal.Name = "tblPrincipal";
            tblPrincipal.Padding = new Padding(20);
            tblPrincipal.RowCount = 3;
            tblPrincipal.RowStyles.Add(new RowStyle());
            tblPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblPrincipal.RowStyles.Add(new RowStyle());
            tblPrincipal.Size = new Size(584, 561);
            tblPrincipal.TabIndex = 0;
            // 
            // tblCampos
            // 
            tblCampos.ColumnCount = 2;
            tblCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tblCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tblCampos.Controls.Add(clbCategorias, 1, 7);
            tblCampos.Controls.Add(lblCategorias, 0, 7);
            tblCampos.Controls.Add(lblDataNascimento, 0, 6);
            tblCampos.Controls.Add(maskedTextBox1, 1, 6);
            tblCampos.Controls.Add(textBox1, 1, 5);
            tblCampos.Controls.Add(lblEndereco, 0, 5);
            tblCampos.Controls.Add(lblTipo, 0, 0);
            tblCampos.Controls.Add(cmbTipo, 1, 0);
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
            tblCampos.RowStyles.Add(new RowStyle());
            tblCampos.RowStyles.Add(new RowStyle());
            tblCampos.RowStyles.Add(new RowStyle());
            tblCampos.RowStyles.Add(new RowStyle());
            tblCampos.RowStyles.Add(new RowStyle());
            tblCampos.RowStyles.Add(new RowStyle());
            tblCampos.RowStyles.Add(new RowStyle());
            tblCampos.RowStyles.Add(new RowStyle());
            tblCampos.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblCampos.Size = new Size(538, 414);
            tblCampos.TabIndex = 3;
            // 
            // clbCategorias
            // 
            clbCategorias.BackColor = Color.White;
            clbCategorias.BorderStyle = BorderStyle.FixedSingle;
            clbCategorias.CheckOnClick = true;
            clbCategorias.Dock = DockStyle.Fill;
            clbCategorias.FormattingEnabled = true;
            clbCategorias.Location = new Point(194, 216);
            clbCategorias.Name = "clbCategorias";
            clbCategorias.Size = new Size(331, 185);
            clbCategorias.TabIndex = 16;
            clbCategorias.Visible = false;
            // 
            // lblCategorias
            // 
            lblCategorias.AutoSize = true;
            lblCategorias.Dock = DockStyle.Fill;
            lblCategorias.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCategorias.Location = new Point(13, 213);
            lblCategorias.Name = "lblCategorias";
            lblCategorias.Padding = new Padding(0, 3, 0, 3);
            lblCategorias.Size = new Size(175, 191);
            lblCategorias.TabIndex = 15;
            lblCategorias.Text = "Categorias do Técnico:";
            lblCategorias.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDataNascimento
            // 
            lblDataNascimento.AutoSize = true;
            lblDataNascimento.Dock = DockStyle.Fill;
            lblDataNascimento.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDataNascimento.Location = new Point(13, 184);
            lblDataNascimento.Name = "lblDataNascimento";
            lblDataNascimento.Padding = new Padding(0, 3, 0, 3);
            lblDataNascimento.Size = new Size(175, 29);
            lblDataNascimento.TabIndex = 14;
            lblDataNascimento.Text = "Data de Nascimento:";
            lblDataNascimento.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.BorderStyle = BorderStyle.FixedSingle;
            maskedTextBox1.Location = new Point(194, 187);
            maskedTextBox1.Mask = "00/00/0000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(120, 23);
            maskedTextBox1.TabIndex = 13;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(194, 158);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Insira endereço, nº - Cidade";
            textBox1.Size = new Size(331, 23);
            textBox1.TabIndex = 11;
            // 
            // lblEndereco
            // 
            lblEndereco.AutoSize = true;
            lblEndereco.Dock = DockStyle.Fill;
            lblEndereco.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblEndereco.Location = new Point(13, 155);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Padding = new Padding(0, 3, 0, 3);
            lblEndereco.Size = new Size(175, 29);
            lblEndereco.TabIndex = 10;
            lblEndereco.Text = "Endereço:";
            lblEndereco.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Dock = DockStyle.Fill;
            lblTipo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblTipo.Location = new Point(13, 10);
            lblTipo.Name = "lblTipo";
            lblTipo.Padding = new Padding(0, 3, 0, 3);
            lblTipo.Size = new Size(175, 29);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo de Usuário:";
            lblTipo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbTipo
            // 
            cmbTipo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Técnico", "Cliente", "Administrador" });
            cmbTipo.Location = new Point(194, 13);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(331, 23);
            cmbTipo.TabIndex = 1;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Dock = DockStyle.Fill;
            lblNome.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblNome.Location = new Point(13, 39);
            lblNome.Name = "lblNome";
            lblNome.Padding = new Padding(0, 3, 0, 3);
            lblNome.Size = new Size(175, 29);
            lblNome.TabIndex = 2;
            lblNome.Text = "Nome Completo:";
            lblNome.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txbNome
            // 
            txbNome.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txbNome.BorderStyle = BorderStyle.FixedSingle;
            txbNome.Location = new Point(194, 42);
            txbNome.Name = "txbNome";
            txbNome.Size = new Size(331, 23);
            txbNome.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Dock = DockStyle.Fill;
            lblEmail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(13, 68);
            lblEmail.Name = "lblEmail";
            lblEmail.Padding = new Padding(0, 3, 0, 3);
            lblEmail.Size = new Size(175, 29);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "E-mail:";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCpf
            // 
            lblCpf.AutoSize = true;
            lblCpf.Dock = DockStyle.Fill;
            lblCpf.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCpf.Location = new Point(13, 97);
            lblCpf.Name = "lblCpf";
            lblCpf.Padding = new Padding(0, 3, 0, 3);
            lblCpf.Size = new Size(175, 29);
            lblCpf.TabIndex = 5;
            lblCpf.Text = "CPF:";
            lblCpf.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.Dock = DockStyle.Fill;
            lblTelefone.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblTelefone.Location = new Point(13, 126);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Padding = new Padding(0, 3, 0, 3);
            lblTelefone.Size = new Size(175, 29);
            lblTelefone.TabIndex = 6;
            lblTelefone.Text = "Telefone:";
            lblTelefone.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txbEmail
            // 
            txbEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txbEmail.BorderStyle = BorderStyle.FixedSingle;
            txbEmail.Location = new Point(194, 71);
            txbEmail.Name = "txbEmail";
            txbEmail.Size = new Size(331, 23);
            txbEmail.TabIndex = 7;
            // 
            // mtbCpf
            // 
            mtbCpf.BorderStyle = BorderStyle.FixedSingle;
            mtbCpf.Location = new Point(194, 100);
            mtbCpf.Mask = "000.000.000-00";
            mtbCpf.Name = "mtbCpf";
            mtbCpf.Size = new Size(120, 23);
            mtbCpf.TabIndex = 8;
            // 
            // mtbTelefone
            // 
            mtbTelefone.BorderStyle = BorderStyle.FixedSingle;
            mtbTelefone.Location = new Point(194, 129);
            mtbTelefone.Mask = "(00) 00000-0000";
            mtbTelefone.Name = "mtbTelefone";
            mtbTelefone.Size = new Size(130, 23);
            mtbTelefone.TabIndex = 9;
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
            lblCabecalho.Text = "Cadastro de Usuário";
            // 
            // flpRodape
            // 
            flpRodape.Controls.Add(btnCancelar);
            flpRodape.Controls.Add(btnSalvar);
            flpRodape.Dock = DockStyle.Bottom;
            flpRodape.Location = new Point(23, 478);
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
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.ForestGreen;
            btnSalvar.BackgroundImageLayout = ImageLayout.None;
            btnSalvar.Cursor = Cursors.Hand;
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Font = new Font("Segoe UI Semibold", 9F);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(90, 15);
            btnSalvar.Margin = new Padding(5);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 2;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            // 
            // FormAdicionarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(584, 561);
            Controls.Add(tblPrincipal);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormAdicionarUsuario";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastrar Usuário";
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
        private FlowLayoutPanel flpRodape;
        private Button btnCancelar;
        private Button btnSalvar;
        private TableLayoutPanel tblCampos;
        private CheckedListBox clbCategorias;
        private Label lblCategorias;
        private Label lblDataNascimento;
        private MaskedTextBox maskedTextBox1;
        private TextBox textBox1;
        private Label lblEndereco;
        private Label lblTipo;
        private ComboBox cmbTipo;
        private Label lblNome;
        private TextBox txbNome;
        private Label lblEmail;
        private Label lblCpf;
        private Label lblTelefone;
        private TextBox txbEmail;
        private MaskedTextBox mtbCpf;
        private MaskedTextBox mtbTelefone;
    }
}