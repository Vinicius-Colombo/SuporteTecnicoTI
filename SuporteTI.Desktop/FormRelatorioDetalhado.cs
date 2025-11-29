using iTextSharp.text;
using iTextSharp.text.pdf;
using SuporteTI.Desktop.DTOs;
using SuporteTI.Desktop.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SuporteTI.Desktop
{
    public partial class FormRelatorioDetalhado : Form
    {
        private readonly ApiService _apiService;
        private readonly RelatorioRequestDto _filtros;

        public FormRelatorioDetalhado(RelatorioRequestDto filtros)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _filtros = filtros;

            this.Load += FormRelatorioDetalhado_Load;
            btnFechar.Click += BtnFechar_Click;
            btnBaixarPDF.Click += BtnBaixarPDF_Click;
        }

        private async void FormRelatorioDetalhado_Load(object? sender, EventArgs e)
        {
            await CarregarRelatorioAsync();
            await CarregarAvaliacoesAsync();
        }

        // RELATÓRIO PRINCIPAL 
        private async Task CarregarRelatorioAsync()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                var resultado = await _apiService.ObterRelatorioFiltradoAsync(_filtros);

                if (resultado == null)
                {
                    MessageBox.Show("Não foi possível carregar o relatório.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // RESUMO
                lblTotalChamadosValor.Text = resultado.Resumo.TotalChamados.ToString();
                lTempoMedioValor.Text = resultado.Resumo.TempoMedioResolucao;
                lblResolvidoPrazoValor.Text = resultado.Resumo.ResolvidosPrazo.ToString();
                lblCategoriaValor.Text = resultado.Resumo.CategoriaMaisIncidente ?? "-";
                lblTotalAvaliacoesValor.Text = resultado.Resumo.TotalAvaliacoes.ToString();

                // TABELA DE CHAMADOS
                dgvChamadosDetalhados.Rows.Clear();
                foreach (var c in resultado.Chamados)
                {
                    dgvChamadosDetalhados.Rows.Add(
                        c.IdChamado,
                        c.DataAbertura.ToString("dd/MM/yyyy HH:mm"),
                        c.Tecnico,
                        c.Categoria,
                        c.Prioridade,
                        c.TempoAtendimento,
                        c.Cliente
                    );
                }


                AtualizarRankings(resultado.Rankings);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar relatório:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // RANKINGS 
        private void AtualizarRankings(RankingsRelatorioDto rankings)
        {
            lvlDetalhesTecnicos.Items.Clear();
            lvlCategoriaMais.Items.Clear();

            foreach (var t in rankings.Tecnicos)
                lvlDetalhesTecnicos.Items.Add(new ListViewItem(new[] { t.Nome, t.Quantidade.ToString() }));

            foreach (var c in rankings.Categorias)
                lvlCategoriaMais.Items.Add(new ListViewItem(new[] { c.Nome, c.Quantidade.ToString() }));
        }


        // AVALIAÇÕES 
        private async Task CarregarAvaliacoesAsync()
        {
            try
            {
                var response = await _apiService.GetAsync("Relatorio/avaliacoes");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);

                var avaliacoes = new List<AvaliacaoDto>();

                foreach (var item in doc.RootElement.EnumerateArray())
                {
                    int idChamado = 0;

                    if (item.TryGetProperty("chamadoId", out var id))
                        idChamado = id.GetInt32();
                    else if (item.TryGetProperty("idChamado", out var id2))
                        idChamado = id2.GetInt32();
                    else if (item.TryGetProperty("chamado", out var ch) && ch.TryGetProperty("idChamado", out var id3))
                        idChamado = id3.GetInt32();

                    avaliacoes.Add(new AvaliacaoDto
                    {
                        ChamadoId = idChamado,
                        TituloChamado = item.GetProperty("tituloChamado").GetString() ?? "",
                        Tecnico = item.GetProperty("tecnico").GetString() ?? "",
                        Nota = item.GetProperty("nota").GetInt32(),
                        Comentario = item.GetProperty("comentario").GetString() ?? ""
                    });
                }


                if (avaliacoes == null) return;

                dgvAvaliacoes.Rows.Clear();
                int totalAvaliacoes = 0;

                foreach (var a in avaliacoes)
                {
                    if (a.Nota > 0) totalAvaliacoes++;

                    dgvAvaliacoes.Rows.Add(a.ChamadoId, a.TituloChamado, a.Tecnico, a.Nota, a.Comentario);
                }

                lblTotalAvaliacoesValor.Text = totalAvaliacoes.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar avaliações: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // PDF 
        private void BtnBaixarPDF_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                string filePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    $"Relatorio_SuporteTI_{DateTime.Now:ddMMyyyy_HHmm}.pdf"
                );

                var doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 40, 40, 60, 60);
                var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                // FONTES PADRÃO
                var fonteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                var fonteSubtitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(30, 60, 150));
                var fonteTexto = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                var fontePequena = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.GRAY);

                // CABEÇALHO
                var titulo = new iTextSharp.text.Paragraph("SUPORTE TÉCNICO", fonteSubtitulo)
                {
                    Alignment = iTextSharp.text.Element.ALIGN_RIGHT
                };
                doc.Add(titulo);

                var subtitulo = new iTextSharp.text.Paragraph("Relatório Detalhado", fonteTitulo)
                {
                    Alignment = iTextSharp.text.Element.ALIGN_CENTER
                };
                doc.Add(subtitulo);

                doc.Add(new iTextSharp.text.Paragraph($"Gerado em {DateTime.Now:dd/MM/yyyy HH:mm}", fonteTexto));
                doc.Add(new iTextSharp.text.Paragraph("\n"));

                var linha = new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, new iTextSharp.text.BaseColor(0, 102, 204), iTextSharp.text.Element.ALIGN_CENTER, -1);
                doc.Add(new iTextSharp.text.Chunk(linha));
                doc.Add(new iTextSharp.text.Paragraph("\nResumo Geral", fonteSubtitulo));

                // RESUMO
                doc.Add(new iTextSharp.text.Paragraph($"• Total de Chamados: {lblTotalChamadosValor.Text}", fonteTexto));
                doc.Add(new iTextSharp.text.Paragraph($"• Tempo Médio de Resolução: {lTempoMedioValor.Text}", fonteTexto));
                doc.Add(new iTextSharp.text.Paragraph($"• Resolvidos no Prazo: {lblResolvidoPrazoValor.Text}", fonteTexto));
                doc.Add(new iTextSharp.text.Paragraph($"• Categoria Mais Incidente: {lblCategoriaValor.Text}", fonteTexto));
                doc.Add(new iTextSharp.text.Paragraph($"• Total de Avaliações: {lblTotalAvaliacoesValor.Text}\n\n", fonteTexto));

                // TABELA DE CHAMADOS
                doc.Add(new iTextSharp.text.Paragraph("\nChamados Detalhados", fonteSubtitulo));
                var tabela = new iTextSharp.text.pdf.PdfPTable(dgvChamadosDetalhados.ColumnCount)
                {
                    WidthPercentage = 100
                };

                foreach (DataGridViewColumn col in dgvChamadosDetalhados.Columns)
                    tabela.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(col.HeaderText, fonteTexto))
                    { BackgroundColor = new iTextSharp.text.BaseColor(230, 230, 250) });

                foreach (DataGridViewRow row in dgvChamadosDetalhados.Rows)
                    foreach (DataGridViewCell cell in row.Cells)
                        tabela.AddCell(cell.Value?.ToString() ?? "");

                doc.Add(tabela);

                // RANKINGS
                doc.Add(new iTextSharp.text.Paragraph("\nRankings", fonteSubtitulo));
                doc.Add(new iTextSharp.text.Paragraph("\nTécnicos com mais chamados:", fonteTexto));
                foreach (ListViewItem item in lvlDetalhesTecnicos.Items)
                    doc.Add(new iTextSharp.text.Paragraph($" - {item.SubItems[0].Text}: {item.SubItems[1].Text}", fonteTexto));

                doc.Add(new iTextSharp.text.Paragraph("\nCategorias mais incidentes:", fonteTexto));
                foreach (ListViewItem item in lvlCategoriaMais.Items)
                    doc.Add(new iTextSharp.text.Paragraph($" - {item.SubItems[0].Text}: {item.SubItems[1].Text}", fonteTexto));

                doc.Add(new iTextSharp.text.Paragraph("\nRelatório gerado automaticamente pelo sistema SuporteTI.", fontePequena));
                doc.Close();

                Process.Start(new ProcessStartInfo { FileName = filePath, UseShellExecute = true });

                MessageBox.Show("PDF gerado com sucesso na área de trabalho!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar PDF:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }


        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // DTO interno
        private class AvaliacaoDto
        {
            public int ChamadoId { get; set; }
            public string TituloChamado { get; set; } = string.Empty;
            public string Tecnico { get; set; } = string.Empty;
            public int Nota { get; set; }
            public string Comentario { get; set; } = string.Empty;
        }
    }
}
