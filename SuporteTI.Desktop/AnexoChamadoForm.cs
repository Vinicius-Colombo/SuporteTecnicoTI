
using SuporteTI.Desktop.DTOs;
using SuporteTI.Desktop.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuporteTI.Desktop
{
    public partial class AnexoChamadoForm : Form
    {
        private readonly ApiService _apiService;
        private readonly ChamadoReadDto _chamado;

        public AnexoChamadoForm(ChamadoReadDto chamado)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _chamado = chamado;

            // configurações visuais
            ConfigurarListView();
            lblChamado.Text = $"Chamado #{_chamado.IdChamado}";
            lblArquivo.Text = "Arquivo:";

            this.Load += AnexoChamadoForm_Load;
            lvListaAnexos.SelectedIndexChanged += lvListaAnexos_SelectedIndexChanged;
            btnVoltar.Click += (s, e) => this.Close();
            btnBaixar.Click += btnBaixar_Click;
        }

        private async void AnexoChamadoForm_Load(object sender, EventArgs e)
        {
            await CarregarAnexosAsync();
        }

        // Configura o visual e as colunas do ListView
        private void ConfigurarListView()
        {
            lvListaAnexos.View = View.Details;
            lvListaAnexos.FullRowSelect = true;
            lvListaAnexos.GridLines = true;
            lvListaAnexos.HideSelection = false;
            lvListaAnexos.MultiSelect = false;
            lvListaAnexos.Font = new Font("Segoe UI", 10);
            lvListaAnexos.BackColor = Color.White;

            lvListaAnexos.Columns.Add("ID", 60, HorizontalAlignment.Left);
            lvListaAnexos.Columns.Add("Arquivo", 230, HorizontalAlignment.Left);
            lvListaAnexos.Columns.Add("Tipo", 100, HorizontalAlignment.Center);
            lvListaAnexos.Columns.Add("Data Envio", 150, HorizontalAlignment.Center);
        }

        // Carrega os anexos do chamado
        private async Task CarregarAnexosAsync()
        {
            try
            {
                lvListaAnexos.Items.Clear();
                pcbAnexo.Image = null;
                lblArquivo.Text = "Arquivo:";

                var anexos = await _apiService.ObterAnexosPorChamadoAsync(_chamado.IdChamado);

                if (anexos == null || !anexos.Any())
                {
                    var item = new ListViewItem("Nenhum anexo encontrado.");
                    lvListaAnexos.Items.Add(item);
                    return;
                }

                foreach (var anexo in anexos)
                {
                    var item = new ListViewItem(anexo.IdAnexo.ToString());
                    item.SubItems.Add(anexo.NomeArquivo);
                    var extensao = Path.GetExtension(anexo.NomeArquivo);
                    item.SubItems.Add(extensao);
                    item.SubItems.Add(anexo.DataEnvio.ToString("dd/MM/yyyy HH:mm"));
                    item.Tag = anexo;
                    lvListaAnexos.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar anexos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Quando o usuário seleciona um anexo
        private async void lvListaAnexos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvListaAnexos.SelectedItems.Count == 0)
            {
                pcbAnexo.Image = null;
                lblArquivo.Text = "Arquivo:";
                return;
            }

            var item = lvListaAnexos.SelectedItems[0];
            if (item.Tag is not AnexoReadDto anexo) return;

            lblArquivo.Text = $"Arquivo: {anexo.NomeArquivo}";

            try
            {
                if (anexo.Extensao.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
                    anexo.Extensao.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    anexo.Extensao.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    using var ms = new MemoryStream(anexo.Conteudo);
                    pcbAnexo.Image = Image.FromStream(ms);
                    pcbAnexo.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pcbAnexo.Image = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exibir anexo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        // Botão Baixar Anexo
        private async void btnBaixar_Click(object sender, EventArgs e)
        {
            if (lvListaAnexos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um anexo para baixar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = lvListaAnexos.SelectedItems[0];
            if (item.Tag is not AnexoReadDto anexo)
                return;

            if (anexo.Conteudo == null || anexo.Conteudo.Length == 0)
            {
                MessageBox.Show("O conteúdo do anexo está vazio ou não foi carregado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = anexo.NomeArquivo,
                Filter = "Todos os arquivos|*.*"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await File.WriteAllBytesAsync(sfd.FileName, anexo.Conteudo);
                    MessageBox.Show("Anexo baixado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



    }
}
