using SuporteTI.Desktop.DTOs;
using SuporteTI.Desktop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuporteTI.Desktop
{
    public partial class FormEditarTecnico : Form
    {
        private readonly ApiService _apiService;
        private readonly int _idUsuario;
        private List<CategoriaReadDto> _todasCategorias = new();
        private List<TecnicoCategoriaReadDto> _categoriasVinculadas = new();

        public FormEditarTecnico(int idUsuario)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _idUsuario = idUsuario;

            this.Load += FormEditarTecnico_Load;
            btnCancelar.Click += (s, e) => this.Close();
            btnAtualizar.Click += btnAtualizar_Click;
        }

        // 🔹 Ao carregar o formulário
        private async void FormEditarTecnico_Load(object? sender, EventArgs e)
        {
            await CarregarCategoriasAsync();
            await CarregarDadosTecnicoAsync();
        }

        // 🔹 Carrega os dados do técnico selecionado
        private async Task CarregarDadosTecnicoAsync()
        {
            try
            {
                var response = await _apiService.GetAsync($"Usuario/{_idUsuario}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var tecnico = JsonSerializer.Deserialize<UsuarioReadDto>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (tecnico == null)
                {
                    MessageBox.Show("Técnico não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // 🔹 Preenche os campos
                txbId.Text = tecnico.IdUsuario.ToString();
                txbNome.Text = tecnico.Nome ?? "";
                txbEmail.Text = tecnico.Email ?? "";
                mtbCpf.Text = tecnico.Cpf ?? "";
                mtbTelefone.Text = tecnico.Telefone ?? "";
                txbEndereco.Text = tecnico.Endereco ?? "";
                cmbStatus.SelectedItem = tecnico.Ativo ? "Ativo" : "Desativado";

                // 🔹 Preenche a data de nascimento formatada
                if (tecnico.DataNascimento.HasValue)
                    msbDataNascimento.Text = tecnico.DataNascimento.Value.ToString("dd/MM/yyyy");
                else
                    msbDataNascimento.Clear();

                // 🔹 Carrega categorias já vinculadas
                await CarregarCategoriasVinculadasAsync(tecnico.IdUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados do técnico:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // 🔹 Carrega todas as categorias disponíveis
        private async Task CarregarCategoriasAsync()
        {
            try
            {
                var response = await _apiService.GetAsync("Categoria");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                _todasCategorias = JsonSerializer.Deserialize<List<CategoriaReadDto>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();

                clbCategorias.Items.Clear();
                foreach (var categoria in _todasCategorias)
                    clbCategorias.Items.Add(categoria.Nome);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar categorias:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Carrega categorias já vinculadas ao técnico
        private async Task CarregarCategoriasVinculadasAsync(int idTecnico)
        {
            try
            {
                var response = await _apiService.GetAsync("TecnicoCategoria");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                _categoriasVinculadas = JsonSerializer.Deserialize<List<TecnicoCategoriaReadDto>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();

                var idsVinculados = _categoriasVinculadas
                    .Where(tc => tc.IdTecnico == idTecnico)
                    .Select(tc => tc.IdCategoria)
                    .ToList();

                // Marca as categorias vinculadas
                for (int i = 0; i < _todasCategorias.Count; i++)
                {
                    if (idsVinculados.Contains(_todasCategorias[i].IdCategoria))
                        clbCategorias.SetItemChecked(i, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar vínculos do técnico:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Botão Atualizar
        private async void btnAtualizar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txbNome.Text))
                {
                    MessageBox.Show("Informe o nome do técnico.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Limpa CPF e telefone
                var cpfLimpo = new string(mtbCpf.Text.Where(char.IsDigit).ToArray());
                var telefoneLimpo = new string(mtbTelefone.Text.Where(char.IsDigit).ToArray());
                string? endereco = string.IsNullOrWhiteSpace(txbEndereco.Text) ? null : txbEndereco.Text.Trim();

                // 🔹 Converte data de nascimento
                DateTime? dataNascimento = null;
                var txtData = msbDataNascimento.Text?.Trim();
                if (DateTime.TryParse(msbDataNascimento.Text, out var parsedDate))
                    dataNascimento = parsedDate;

                // 🔹 Monta DTO de atualização
                var dto = new UsuarioUpdateDto
                {
                    IdUsuario = _idUsuario,
                    Nome = txbNome.Text.Trim(),
                    Email = txbEmail.Text.Trim(),
                    Cpf = string.IsNullOrWhiteSpace(cpfLimpo) ? null : cpfLimpo,
                    Telefone = string.IsNullOrWhiteSpace(telefoneLimpo) ? null : telefoneLimpo,
                    Endereco = endereco,
                    DataNascimento = dataNascimento,
                    Ativo = cmbStatus.SelectedItem?.ToString() == "Ativo"
                };

                // 🔹 Atualiza os dados básicos
                var response = await _apiService.PutAsync($"Usuario/{_idUsuario}", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var erro = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Erro ao atualizar técnico:\n{erro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 🔹 Atualiza vínculos das categorias
                await SincronizarCategoriasAsync();

                MessageBox.Show("Técnico atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar alterações:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Sincroniza categorias do técnico
        private async Task SincronizarCategoriasAsync()
        {
            var selecionadas = clbCategorias.CheckedItems.Cast<string>().ToList();
            var idsSelecionados = _todasCategorias
                .Where(c => selecionadas.Contains(c.Nome))
                .Select(c => c.IdCategoria)
                .ToList();

            var idsAtuais = _categoriasVinculadas
                .Where(tc => tc.IdTecnico == _idUsuario)
                .Select(tc => tc.IdCategoria)
                .ToList();

            // Adiciona novas categorias
            var novas = idsSelecionados.Except(idsAtuais).ToList();
            foreach (var idCategoria in novas)
            {
                var vinculo = new TecnicoCategoriaCreateDto
                {
                    IdTecnico = _idUsuario,
                    IdCategoria = idCategoria
                };
                await _apiService.PostAsync("TecnicoCategoria", vinculo);
            }

            // Remove categorias desmarcadas
            var removidas = idsAtuais.Except(idsSelecionados).ToList();
            foreach (var idCategoria in removidas)
                await _apiService.DeleteAsync($"TecnicoCategoria/{_idUsuario}/{idCategoria}");
        }
    }
}
