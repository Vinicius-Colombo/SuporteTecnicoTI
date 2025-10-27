using SuporteTI.Desktop.DTOs;
using SuporteTI.Desktop.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuporteTI.Desktop
{
    public partial class FormAdicionarUsuario : Form
    {
        private readonly ApiService _apiService;
        private List<CategoriaReadDto> _categorias = new();

        public FormAdicionarUsuario()
        {
            InitializeComponent();
            _apiService = new ApiService();

            // Eventos
            this.Load += FormAdicionarUsuario_Load;
            cmbTipo.SelectedIndexChanged += cmbTipo_SelectedIndexChanged;
            btnSalvar.Click += btnSalvar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        // 🔹 Evento de carregamento
        private async void FormAdicionarUsuario_Load(object? sender, EventArgs e)
        {
            await CarregarCategoriasAsync();
            clbCategorias.Visible = false;
            lblCategorias.Visible = false;
        }

        // 🔹 Exibir campo de categorias apenas se for Técnico
        private void cmbTipo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string tipoSelecionado = cmbTipo.SelectedItem?.ToString() ?? "";
            bool isTecnico = tipoSelecionado.Equals("Técnico", StringComparison.OrdinalIgnoreCase);

            lblCategorias.Visible = isTecnico;
            clbCategorias.Visible = isTecnico;
        }


        // 🔹 Carrega categorias
        private async Task CarregarCategoriasAsync()
        {
            try
            {
                var response = await _apiService.GetAsync("Categoria");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                _categorias = JsonSerializer.Deserialize<List<CategoriaReadDto>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();

                clbCategorias.Items.Clear();
                foreach (var categoria in _categorias)
                    clbCategorias.Items.Add(categoria.Nome);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar categorias:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 Botão Cancelar
        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // 🔹 Botão Salvar
        private async void btnSalvar_Click(object? sender, EventArgs e)
        {
            try
            {
                // Validação básica
                if (string.IsNullOrWhiteSpace(txbNome.Text))
                {
                    MessageBox.Show("Informe o nome do usuário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txbEmail.Text))
                {
                    MessageBox.Show("Informe o e-mail do usuário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbTipo.SelectedItem == null)
                {
                    MessageBox.Show("Selecione o tipo de usuário.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 Limpa o CPF e telefone (remove caracteres não numéricos)
                string cpfLimpo = new string(mtbCpf.Text.Where(char.IsDigit).ToArray());
                string telefoneLimpo = new string(mtbTelefone.Text.Where(char.IsDigit).ToArray());
                string endereco = textBox1.Text.Trim();

                // 🔹 Converte data (MaskedTextBox → yyyy-MM-dd)
                DateTime dataNascimento;
                if (!DateTime.TryParseExact(maskedTextBox1.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascimento))
                {
                    MessageBox.Show("Data de nascimento inválida. Use o formato dd/mm/aaaa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cria DTO
                var usuarioDto = new UsuarioCreateDto
                {
                    Nome = txbNome.Text.Trim(),
                    Email = txbEmail.Text.Trim(),
                    Tipo = (cmbTipo.SelectedItem?.ToString()?.Normalize(NormalizationForm.FormD)
                        .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                        .Aggregate("", (current, c) => current + c)
                        ?? "Cliente"),
                    Cpf = string.IsNullOrWhiteSpace(cpfLimpo) ? null : cpfLimpo,
                    Telefone = string.IsNullOrWhiteSpace(telefoneLimpo) ? null : telefoneLimpo,
                    Endereco = endereco,
                    DataNascimento = dataNascimento,
                    Senha = "senha@123"
                };

                // Envia requisição para criar o usuário
                var response = await _apiService.PostAsync("Usuario", usuarioDto);
                if (!response.IsSuccessStatusCode)
                {
                    var erro = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Erro ao criar usuário:\n{erro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();

                // 🔹 Tenta extrair o ID diretamente do JSON retornado
                int idUsuarioCriado = 0;
                try
                {
                    using (var doc = JsonDocument.Parse(json))
                    {
                        if (doc.RootElement.TryGetProperty("idUsuario", out var idProp))
                            idUsuarioCriado = idProp.GetInt32();
                    }
                }
                catch { idUsuarioCriado = 0; }

                // 🔹 Se falhar, tenta deserializar como DTO (fallback)
                if (idUsuarioCriado == 0)
                {
                    try
                    {
                        var usuarioCriado = JsonSerializer.Deserialize<UsuarioReadDto>(json,
                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        idUsuarioCriado = usuarioCriado?.IdUsuario ?? 0;
                    }
                    catch { }
                }

                if (idUsuarioCriado == 0)
                {
                    MessageBox.Show("Não foi possível identificar o ID do usuário criado.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 🔹 Se for técnico, vincula as categorias selecionadas
                if (usuarioDto.Tipo == "Tecnico") // sem acento aqui!
                {
                    // Aguarda o EF terminar de persistir no banco
                    await Task.Delay(1000);

                    // Revalida se o técnico existe
                    var verificaResp = await _apiService.GetAsync($"Usuario/{idUsuarioCriado}");
                    if (!verificaResp.IsSuccessStatusCode)
                    {
                        MessageBox.Show("O técnico ainda não foi confirmado pelo banco. Tente novamente em alguns segundos.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Vincula as categorias selecionadas
                    var categoriasSelecionadas = clbCategorias.CheckedItems.Cast<string>().ToList();
                    var idsSelecionados = _categorias
                        .Where(c => categoriasSelecionadas.Contains(c.Nome))
                        .Select(c => c.IdCategoria)
                        .ToList();

                    foreach (var idCategoria in idsSelecionados)
                    {
                        var vinculo = new TecnicoCategoriaCreateDto
                        {
                            IdTecnico = idUsuarioCriado,
                            IdCategoria = idCategoria
                        };

                        var respVinculo = await _apiService.PostAsync("TecnicoCategoria", vinculo);
                        if (!respVinculo.IsSuccessStatusCode)
                        {
                            var erro = await respVinculo.Content.ReadAsStringAsync();
                            Console.WriteLine($"Erro ao vincular categoria {idCategoria}: {erro}");
                        }
                        else
                        {
                            Console.WriteLine($"✅ Categoria {idCategoria} vinculada com sucesso!");
                        }
                    }
                }



                MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar usuário:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
