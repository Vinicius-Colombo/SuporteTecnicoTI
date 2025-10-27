using SuporteTI.Desktop.DTOs;
using SuporteTI.Desktop.Services;
using System.Text.Json;

namespace SuporteTI.Desktop
{
    public partial class MainFormAdmin : Form
    {
        private readonly LoginResponseDto _usuarioLogado;
        private readonly ApiService _apiService;
    
        public MainFormAdmin(LoginResponseDto usuarioLogado)
        {
            InitializeComponent();
            _usuarioLogado = usuarioLogado;
            _apiService = new ApiService();

            this.Text = $"Painel do Administrador - {_usuarioLogado.Nome}";

            // 🔹 Evento do clique no ícone de perfil
            pbPerfil.Click += PbPerfil_Click;

            // 🔹 Eventos já existentes
            this.Load += MainFormAdmin_Load;
            dgvResultadoPesquisa.CellContentClick += DgvResultadoPesquisa_CellContentClick;
            dgvDesativadas.CellContentClick += dgvDesativadas_CellContentClick;
            dgvResultadoPesquisa.CellPainting += DgvResultadoPesquisa_CellPainting;
            dgvDesativadas.CellPainting += DgvDesativadas_CellPainting;

            btnAdicionarUsuario.Click += BtnAdicionarUsuario_Click;
            txbPesquisar.TextChanged += txbPesquisar_TextChanged;

            txbProcurarDesativadas.TextChanged += async (s, e) =>
            {
                await FiltrarUsuariosDesativadosAsync(txbProcurarDesativadas.Text.Trim());
            };


            btnGerarRelatorio.Click += btnGerarRelatorio_Click;

        }

        // 🔹 Exibe o mini formulário de perfil ao clicar no ícone
        private void PbPerfil_Click(object? sender, EventArgs e)
        {
            // Cria o mini perfil e mostra próximo ao ícone
            var perfilForm = new PerfilMiniForm(_usuarioLogado);

            // Define a posição — ao lado do ícone de perfil
            var pos = pbPerfil.PointToScreen(Point.Empty);
            perfilForm.StartPosition = FormStartPosition.Manual;
            perfilForm.Location = new Point(pos.X + pbPerfil.Width - perfilForm.Width, pos.Y + pbPerfil.Height);
            perfilForm.Show();
        }


        private async void MainFormAdmin_Load(object? sender, EventArgs e)
        {
            await CarregarUsuariosDesativadosAsync();
            await CarregarUsuariosAsync();
            CarregarGraficoDiarioAsync();

            await CarregarTecnicosAsync();
            await CarregarCategoriasAsync();
            CarregarPrioridades();
        }



        // AREA DE GESTÃO DE USUARIOS

        private bool _pesquisando = false;

        private async void txbPesquisar_TextChanged(object? sender, EventArgs e)
        {
            if (_pesquisando) return; // Evita chamadas simultâneas duplicadas
            _pesquisando = true;

            try
            {
                string termo = txbPesquisar.Text.Trim();

                // 🔹 Se o campo estiver vazio → mostra todos os ativos
                if (string.IsNullOrWhiteSpace(termo))
                {
                    dgvResultadoPesquisa.Rows.Clear();
                    await CarregarUsuariosAsync();
                }
                else
                {
                    // 🔹 Pesquisa filtrando somente usuários ativos
                    await BuscarUsuariosAsync(termo);
                }
            }
            finally
            {
                _pesquisando = false;
            }
        }



        private async Task BuscarUsuariosAsync(string termo)
        {
            try
            {
                dgvResultadoPesquisa.Rows.Clear();

                var response = await _apiService.GetAsync("Usuario");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var usuarios = System.Text.Json.JsonSerializer.Deserialize<List<UsuarioReadDto>>(json,
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var filtrados = usuarios?
                    .Where(u => u.Ativo &&
                               (u.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase)
                             || u.Email.Contains(termo, StringComparison.OrdinalIgnoreCase)
                             || u.IdUsuario.ToString().Contains(termo)))
                    .ToList() ?? new();

                foreach (var u in filtrados)
                {
                    dgvResultadoPesquisa.Rows.Add(
                        u.IdUsuario, u.Nome, u.Email, u.Tipo, "Ativo", "Editar", "Desativar"
                    );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar usuários:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Adicionar Usuário
        private void BtnAdicionarUsuario_Click(object? sender, EventArgs e)
        {
            var form = new FormAdicionarUsuario();

            // 🔹 Atualiza as listas somente se o cadastro for concluído com sucesso
            form.FormClosed += async (sender, args) =>
            {
                if (form.DialogResult == DialogResult.OK)
                    await AtualizarListasUsuariosAsync();
            };

            form.ShowDialog();
        }



        // 🔹 Carrega todos os usuários no grid principal (dgvResultadoPesquisa)
        // 🔹 Carrega e filtra os usuários
        private async Task CarregarUsuariosAsync(string? filtro = null)
        {
            try
            {
                dgvResultadoPesquisa.Rows.Clear();

                var response = await _apiService.GetAsync("Usuario");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var usuarios = JsonSerializer.Deserialize<List<UsuarioReadDto>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();

                // ✅ mostra apenas ATIVOS
                usuarios = usuarios.Where(u => u.Ativo).ToList();

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    var f = filtro.ToLower();
                    usuarios = usuarios.Where(u =>
                        u.IdUsuario.ToString().Contains(f) ||
                        (u.Nome ?? "").ToLower().Contains(f) ||
                        (u.Email ?? "").ToLower().Contains(f) ||
                        (u.Tipo ?? "").ToLower().Contains(f)
                    ).ToList();
                }

                foreach (var u in usuarios)
                {
                    dgvResultadoPesquisa.Rows.Add(
                        u.IdUsuario,
                        u.Nome,
                        u.Email,
                        u.Tipo,
                        "Ativo",
                        "Editar",
                        "Desativar"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar usuários:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async void DgvResultadoPesquisa_CellContentClick(object sender, DataGridViewCellEventArgs e)
{
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
             return;

            var coluna = dgvResultadoPesquisa.Columns[e.ColumnIndex].Name;

            int idUsuario = Convert.ToInt32(dgvResultadoPesquisa.Rows[e.RowIndex].Cells["IdUsuario"].Value);
            string tipo = dgvResultadoPesquisa.Rows[e.RowIndex].Cells["Tipo"].Value?.ToString() ?? "";

            try
            {
                if (coluna == "Editar")
                {
                    Form formEdicao;

                    // 🟢 Abre o form correto
                    if (tipo.Equals("Técnico", StringComparison.OrdinalIgnoreCase) ||
                        tipo.Equals("Tecnico", StringComparison.OrdinalIgnoreCase))
                        formEdicao = new FormEditarTecnico(idUsuario);
                    else
                        formEdicao = new FormEditarUsuario(idUsuario);

                    var result = formEdicao.ShowDialog();

                    // 🔄 Só atualiza se realmente editou (OK)
                    if (result == DialogResult.OK)
                        await AtualizarListasUsuariosAsync();
                }
                else if (coluna == "Desativar")
                {
                    var row = dgvResultadoPesquisa.Rows[e.RowIndex];
                    string nome = row.Cells["Nome"].Value?.ToString() ?? "";

                    var confirmar = MessageBox.Show(
                        $"Deseja desativar {nome}?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmar != DialogResult.Yes) return;

                    try
                    {
                        // 1) Obter dados atuais do usuário
                        var respGet = await _apiService.GetAsync($"Usuario/{idUsuario}");
                        if (!respGet.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Não foi possível ler os dados do usuário.", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var jsonUser = await respGet.Content.ReadAsStringAsync();
                        var usuario = JsonSerializer.Deserialize<UsuarioReadDto>(
                            jsonUser, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                        if (usuario == null)
                        {
                            MessageBox.Show("Usuário não encontrado.", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // 2) Montar DTO completo com Ativo=false
                        var dto = new UsuarioUpdateDto
                        {
                            IdUsuario = usuario.IdUsuario,
                            Nome = usuario.Nome,
                            Email = usuario.Email,
                            Cpf = usuario.Cpf,
                            Telefone = usuario.Telefone,
                            Ativo = false
                        };

                        // 3) Atualizar
                        var respPut = await _apiService.PutAsync($"Usuario/{idUsuario}", dto);
                        if (!respPut.IsSuccessStatusCode)
                        {
                            var erro = await respPut.Content.ReadAsStringAsync();
                            MessageBox.Show($"Erro ao desativar:\n{erro}", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        MessageBox.Show("Conta desativada com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Atualiza ambos os grids
                        await CarregarUsuariosAsync(txbPesquisar.Text.Trim());
                        await CarregarUsuariosDesativadosAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao desativar:\n{ex.Message}", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
            MessageBox.Show($"Erro ao processar ação:\n{ex.Message}", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // 🔹 Carrega usuários desativados
        private async Task CarregarUsuariosDesativadosAsync()
        {
            try
            {
                dgvDesativadas.Rows.Clear();

                var response = await _apiService.GetAsync("Usuario");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var usuarios = JsonSerializer.Deserialize<List<UsuarioReadDto>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var desativados = usuarios?.Where(u => !u.Ativo).ToList() ?? new();

                // 🔹 Preenche apenas com as colunas desejadas: Id, Nome, Email
                foreach (var u in desativados)
                {
                    dgvDesativadas.Rows.Add(u.IdUsuario, u.Nome, u.Email);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar contas desativadas:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task FiltrarUsuariosDesativadosAsync(string termo = "")
        {
            try
            {
                dgvDesativadas.Rows.Clear();

                var resp = await _apiService.GetAsync("Usuario");
                resp.EnsureSuccessStatusCode();

                var json = await resp.Content.ReadAsStringAsync();
                var usuarios = JsonSerializer.Deserialize<List<UsuarioReadDto>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                // 🔹 Filtra apenas desativados
                var desativados = usuarios?
                    .Where(u => !u.Ativo &&
                                (string.IsNullOrWhiteSpace(termo)
                                 || u.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase)
                                 || u.Email.Contains(termo, StringComparison.OrdinalIgnoreCase)
                                 || u.IdUsuario.ToString().Contains(termo)))
                    .ToList() ?? new();

                // 🔹 Preenche a grid sem duplicar
                foreach (var u in desativados)
                {
                    dgvDesativadas.Rows.Add(u.IdUsuario, u.Nome, u.Email);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao filtrar desativadas:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnProcurarDesativadas_Click(object? sender, EventArgs e)
        {
            await FiltrarUsuariosDesativadosAsync(txbProcurarDesativadas.Text.Trim());
        }



        // 🔹 Clique nas colunas ReativarConta / ApagarConta
        private async void dgvDesativadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var coluna = dgvDesativadas.Columns[e.ColumnIndex].Name;
            var row = dgvDesativadas.Rows[e.RowIndex];

            // ✅ Lê o ID direto da coluna "IdDesativado"
            if (!int.TryParse(row.Cells["IdDesativado"].Value?.ToString(), out int id))
            {
                MessageBox.Show("Não foi possível identificar o usuário (ID inválido).", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nome = row.Cells["NomeDesativado"].Value?.ToString() ?? "";

            // 🟩 Reativar Conta
            if (coluna == "ReativarConta")
            {
                var confirmar = MessageBox.Show(
                    $"Deseja reativar a conta de {nome}?",
                    "Confirmar Reativação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmar != DialogResult.Yes) return;

                try
                {
                    // 🔹 Primeiro busca o usuário atual
                    var respGet = await _apiService.GetAsync($"Usuario/{id}");
                    if (!respGet.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Não foi possível obter os dados do usuário.", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var jsonUser = await respGet.Content.ReadAsStringAsync();
                    var usuario = JsonSerializer.Deserialize<UsuarioReadDto>(
                        jsonUser, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (usuario == null)
                    {
                        MessageBox.Show("Usuário não encontrado.", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 🔹 Monta o DTO completo com os dados existentes
                    var dto = new UsuarioUpdateDto
                    {
                        IdUsuario = usuario.IdUsuario,
                        Nome = usuario.Nome,
                        Email = usuario.Email,
                        Cpf = usuario.Cpf,
                        Telefone = usuario.Telefone,
                        Ativo = true
                    };

                    // 🔹 Envia para a API
                    var response = await _apiService.PutAsync($"Usuario/{id}", dto);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Conta reativada com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Atualiza os dois grids
                        await CarregarUsuariosDesativadosAsync();
                        await CarregarUsuariosAsync(txbPesquisar.Text.Trim());
                    }
                    else
                    {
                        var erro = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Erro ao reativar conta:\n{erro}", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao reativar conta:\n{ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // 🟥 Apagar Conta
            else if (coluna == "ApagarConta")
            {
                var confirmar = MessageBox.Show(
                    $"Tem certeza que deseja apagar permanentemente a conta de {nome}?\n\nEssa ação não pode ser desfeita!",
                    "Confirmar Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmar != DialogResult.Yes) return;

                try
                {
                    var response = await _apiService.DeleteAsync($"Usuario/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Conta excluída com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Atualiza os dois grids
                        await CarregarUsuariosDesativadosAsync();
                        await CarregarUsuariosAsync(txbPesquisar.Text.Trim());
                    }
                    else
                    {
                        var erro = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Erro ao excluir conta:\n{erro}", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir conta:\n{ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvResultadoPesquisa_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string columnName = dgvResultadoPesquisa.Columns[e.ColumnIndex].Name;

            if (columnName != "Editar" && columnName != "Desativar")
                return; // ✅ só pinta essas duas colunas

            e.Paint(e.CellBounds, DataGridViewPaintParts.All);

            Color backColor = columnName == "Editar" ? Color.SeaGreen : Color.Orange;
            string text = columnName == "Editar" ? "Editar" : "Desativar";

            Rectangle buttonRect = new Rectangle(e.CellBounds.X + 3, e.CellBounds.Y + 3, e.CellBounds.Width - 6, e.CellBounds.Height - 6);

            ButtonRenderer.DrawButton(e.Graphics, buttonRect, text, new Font("Segoe UI", 9, FontStyle.Bold),
                false, System.Windows.Forms.VisualStyles.PushButtonState.Normal);

            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, buttonRect);
            }

            TextRenderer.DrawText(e.Graphics, text, new Font("Segoe UI", 9, FontStyle.Bold),
                buttonRect, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            e.Handled = true;
        }

        private void DgvDesativadas_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string columnName = dgvDesativadas.Columns[e.ColumnIndex].Name;

            if (columnName != "ReativarConta" && columnName != "ApagarConta")
                return; // ✅ só pinta essas duas colunas

            e.Paint(e.CellBounds, DataGridViewPaintParts.All);

            Color backColor = columnName == "ReativarConta" ? Color.SeaGreen : Color.Firebrick;
            string text = columnName == "ReativarConta" ? "Reativar" : "Apagar";

            Rectangle buttonRect = new Rectangle(e.CellBounds.X + 3, e.CellBounds.Y + 3, e.CellBounds.Width - 6, e.CellBounds.Height - 6);

            ButtonRenderer.DrawButton(e.Graphics, buttonRect, text, new Font("Segoe UI", 9, FontStyle.Bold),
                false, System.Windows.Forms.VisualStyles.PushButtonState.Normal);

            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, buttonRect);
            }

            TextRenderer.DrawText(e.Graphics, text, new Font("Segoe UI", 9, FontStyle.Bold),
                buttonRect, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            e.Handled = true;
        }


        // 🔄 Atualiza todos os grids após qualquer mudança em usuários
        public async Task AtualizarListasUsuariosAsync()
        {
            await CarregarUsuariosAsync();
            await CarregarUsuariosDesativadosAsync();

            string termo = txbPesquisar.Text.Trim();

            // 🔹 Só pesquisa se tiver texto digitado
            if (!string.IsNullOrWhiteSpace(termo))
                await BuscarUsuariosAsync(termo);
        }


        // AREA DE RELATÓRIOS

        // 🔹 Carrega técnicos no ComboBox
        private async Task CarregarTecnicosAsync()
        {
            try
            {
                var response = await _apiService.GetAsync("Usuario");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var usuarios = JsonSerializer.Deserialize<List<UsuarioReadDto>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();

                // 🔹 Filtra apenas técnicos
                var tecnicos = usuarios
                    .Where(u => u.Tipo.Equals("Técnico", StringComparison.OrdinalIgnoreCase) ||
                                u.Tipo.Equals("Tecnico", StringComparison.OrdinalIgnoreCase))
                    .Select(t => new
                    {
                        Nome = t.Nome,
                        Id = t.IdUsuario
                    })
                    .ToList();

                // 🔹 Insere opção "Todos" no início
                tecnicos.Insert(0, new { Nome = "Todos", Id = 0 });

                // 🔹 Liga o combo com DataSource (certo jeito)
                cmbTecnico.DataSource = tecnicos;
                cmbTecnico.DisplayMember = "Nome";
                cmbTecnico.ValueMember = "Id";
                cmbTecnico.SelectedIndex = 0;

                // 🔹 Configura o auto complete
                cmbTecnico.DropDownStyle = ComboBoxStyle.DropDown;
                cmbTecnico.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbTecnico.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar técnicos: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // 🔹 Carrega categorias no ComboBox
        private async Task CarregarCategoriasAsync()
        {
            try
            {
                var response = await _apiService.GetAsync("Categoria");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var categorias = JsonSerializer.Deserialize<List<CategoriaReadDto>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();

                // 🔹 Monta lista com "Todas" no topo
                var listaCategorias = categorias
                    .Select(c => new { Nome = c.Nome, Id = c.IdCategoria })
                    .ToList();

                listaCategorias.Insert(0, new { Nome = "Todas", Id = 0 });

                // 🔹 Liga o ComboBox de forma segura (igual ao de técnico)
                cmbCategoria.DataSource = listaCategorias;
                cmbCategoria.DisplayMember = "Nome";
                cmbCategoria.ValueMember = "Id";
                cmbCategoria.SelectedIndex = 0;

                // 🔹 AutoComplete
                cmbCategoria.DropDownStyle = ComboBoxStyle.DropDown;
                cmbCategoria.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar categorias: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // 🔹 Carrega opções de prioridade
        private void CarregarPrioridades()
        {
            cmbPrioridade.Items.Clear();
            cmbPrioridade.Items.Add("Todas");
            cmbPrioridade.Items.Add("Alta");
            cmbPrioridade.Items.Add("Média");
            cmbPrioridade.Items.Add("Baixa");
            cmbPrioridade.SelectedIndex = 0;
        }


        private async void CarregarGraficoDiarioAsync()
        {
            try
            {
                var response = await _apiService.GetAsync("Relatorio/chamados-diarios");

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Erro ao carregar os dados do gráfico diário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();
                var lista = JsonSerializer.Deserialize<List<ChamadoStatusResumoDto>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (lista == null || lista.Count == 0)
                {
                    MessageBox.Show("Nenhum dado disponível para hoje.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Limpa os dados antigos do gráfico
                chartChamadosDiarios.Series["SerieChamados"].Points.Clear();

                // Adiciona os novos dados
                foreach (var item in lista)
                {
                    int idx = chartChamadosDiarios.Series["SerieChamados"].Points.AddXY(item.Status, item.Quantidade);

                    // Define cor conforme o status
                    switch (item.Status.ToLower())
                    {
                        case "aberto":
                            chartChamadosDiarios.Series["SerieChamados"].Points[idx].Color = Color.DodgerBlue;
                            break;
                        case "em atendimento":
                            chartChamadosDiarios.Series["SerieChamados"].Points[idx].Color = Color.Orange;
                            break;
                        case "resolvido":
                            chartChamadosDiarios.Series["SerieChamados"].Points[idx].Color = Color.MediumSeaGreen;
                            break;
                        case "encerrado":
                            chartChamadosDiarios.Series["SerieChamados"].Points[idx].Color = Color.Gray;
                            break;
                        default:
                            chartChamadosDiarios.Series["SerieChamados"].Points[idx].Color = Color.LightGray;
                            break;
                    }
                }

                chartChamadosDiarios.Titles[0].Text = $"Chamados do dia {DateTime.Now:dd/MM/yyyy}";
                chartChamadosDiarios.Refresh();

                // 🔹 Mostra o valor acima de cada barra (rótulo)
                chartChamadosDiarios.Series["SerieChamados"].IsValueShownAsLabel = true;

                // 🔹 Ajusta estilo do texto dos valores
                chartChamadosDiarios.Series["SerieChamados"].Font = new Font("Segoe UI", 9, FontStyle.Bold);
                chartChamadosDiarios.Series["SerieChamados"].LabelForeColor = Color.Black;

                // 🔹 Centraliza o texto acima das barras
                chartChamadosDiarios.Series["SerieChamados"]["LabelStyle"] = "Top";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar gráfico diário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            if (cmbPeriodo.SelectedItem == null)
            {
                MessageBox.Show("Selecione um período para gerar o relatório.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var filtros = new RelatorioRequestDto
            {
                Tipo = cmbPeriodo.SelectedItem?.ToString(),
                IdTecnico = (cmbTecnico.SelectedIndex > 0) ? (int?)cmbTecnico.SelectedValue : null,
                IdCategoria = (cmbCategoria.SelectedIndex > 0) ? (int?)cmbCategoria.SelectedValue : null,
                Prioridade = (cmbPrioridade.SelectedIndex > 0) ? cmbPrioridade.SelectedItem?.ToString() : null
            };

            var form = new FormRelatorioDetalhado(filtros);
            form.ShowDialog();
        }

    }

}
