using Microsoft.AspNetCore.Mvc;
using SuporteTI.Web.DTOs;
using SuporteTI.Web.Models;
using SuporteTI.Web.Services;
using static System.Net.WebRequestMethods;

namespace SuporteTI.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApiService _api;

        public ClienteController(ApiService api)
        {
            _api = api;
        }

        // Verifica sessão do cliente logado
        private int? ObterIdCliente()
        {
            return HttpContext.Session.GetInt32("IdUsuario");
        }

        private IActionResult VerificarLogin()
        {
            if (ObterIdCliente() == null)
                return RedirectToAction("Login", "AuthWeb");
            return null!;
        }

        // ABRIR CHAMADO
        [HttpGet]
        public IActionResult Novo()
        {
            var redir = VerificarLogin();
            if (redir != null) return redir;

            ViewBag.Nav = "Novo";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AbrirChamado(string titulo, string descricao, IFormFile? anexo)
        {
            var redir = VerificarLogin();
            if (redir != null) return redir;

            try
            {
                var idUsuario = ObterIdCliente()!.Value;
                var idChamado = await _api.AbrirChamadoAsync(idUsuario, titulo, descricao, anexo);

                if (idChamado != null && idChamado > 0)
                    return RedirectToAction("Chat", new { id = idChamado });
                else
                    TempData["Erro"] = "Erro ao criar chamado.";
            }
            catch (Exception ex)
            {
                TempData["Erro"] = $"Erro inesperado: {ex.Message}";
            }

            return RedirectToAction("Novo");
        }

        // HISTÓRICO
        public async Task<IActionResult> Historico()
        {
            var redir = VerificarLogin();
            if (redir != null) return redir;

            ViewBag.Nav = "Historico";
            var idUsuario = ObterIdCliente()!.Value;

            var chamados = await _api.ObterChamadosAsync(idUsuario);
            return View(chamados);
        }

        // PERFIL DO CLIENTE
        [HttpGet]
        public async Task<IActionResult> Perfil()
        {
            ViewBag.Nav = "Perfil";

            int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");
            if (idUsuario == null)
                return RedirectToAction("Login", "AuthWeb");

            var usuario = await _api.ObterUsuarioPorIdAsync(idUsuario.Value);
            if (usuario == null)
            {
                TempData["Erro"] = "Não foi possível carregar seus dados de perfil.";
                return RedirectToAction("Novo");
            }

            return View(usuario);
        }

        public async Task<IActionResult> Chat(int id)
        {
            var redir = VerificarLogin();
            if (redir != null) return redir;

            ViewBag.Nav = "Historico";

            var chamado = await _api.ObterChamadoPorIdAsync(id);
            var interacoes = await _api.ObterInteracoesPorChamadoAsync(id);
            var anexos = await _api.ObterAnexosPorChamadoAsync(id);
            var solucoes = await _api.ObterSolucoesPorChamadoAsync(id);

            if (chamado?.StatusChamado?.ToLower() == "aberto")
            {
                bool clienteRejeitou = interacoes.Any(i =>
                    i.Origem?.ToLower() == "cliente" &&
                    (i.Mensagem.ToLower().Contains("não") || i.Mensagem.ToLower().Contains("nao")));

                bool tecnicoRespondeu = interacoes.Any(i =>
                    i.Origem?.ToLower() == "técnico" || i.Origem?.ToLower() == "tecnico");

                if (clienteRejeitou && !tecnicoRespondeu)
                    ViewBag.AvisoPermanente = "🔄 Sua solicitação foi encaminhada para um técnico. Aguarde o atendimento.";
            }

            var model = new ChatViewModel
            {
                Chamado = chamado!,
                Interacoes = interacoes,
                Solucoes = solucoes,
                Anexos = anexos
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EnviarMensagem(int IdChamado, string Mensagem)
        {
            var redir = VerificarLogin();
            if (redir != null) return redir;

            var idUsuario = ObterIdCliente()!.Value;

            await _api.EnviarMensagemAsync(new InteracaoCreateDto
            {
                IdChamado = IdChamado,
                IdUsuario = idUsuario,
                Mensagem = Mensagem,
                Origem = "Cliente"
            });

            return RedirectToAction("Chat", new { id = IdChamado });
        }

        [HttpPost]
        public async Task<IActionResult> EnviarAnexo(int idChamado, IFormFile arquivo)
        {
            var redir = VerificarLogin();
            if (redir != null) return redir;

            if (arquivo == null || arquivo.Length == 0)
            {
                TempData["Erro"] = "Nenhum arquivo selecionado.";
                return RedirectToAction("Chat", new { id = idChamado });
            }

            bool sucesso = await _api.EnviarAnexoAsync(idChamado, arquivo);
            TempData["Mensagem"] = sucesso
                ? "Anexo enviado com sucesso!"
                : "Erro ao enviar o anexo.";

            return RedirectToAction("Chat", new { id = idChamado });
        }

        [HttpPost]
        public async Task<IActionResult> BaixarAnexo(int idAnexo, int idChamado)
        {
            var redir = VerificarLogin();
            if (redir != null) return redir;

            var (bytes, nome, tipo) = await _api.BaixarAnexoAsync(idAnexo);
            if (bytes == null || bytes.Length == 0)
            {
                TempData["Erro"] = "Erro ao baixar o anexo.";
                return RedirectToAction("Chat", new { id = idChamado });
            }

            return File(bytes, tipo ?? "application/octet-stream", nome ?? $"anexo_{idAnexo}.bin");
        }

        [HttpGet]
        public async Task<IActionResult> StatusChamado(int id)
        {
            var redir = VerificarLogin();
            if (redir != null) return redir;

            var c = await _api.ObterChamadoPorIdAsync(id);
            var status = c?.StatusChamado?.Trim() ?? "";

            bool resolvidoOuEncerrado =
                status.Equals("Resolvido", StringComparison.OrdinalIgnoreCase) ||
                status.Equals("Encerrado", StringComparison.OrdinalIgnoreCase);

            bool precisaAvaliar = false;
            if (resolvidoOuEncerrado)
            {
                var av = await _api.ObterAvaliacaoPorChamadoAsync(id);
                precisaAvaliar = (av == null);
            }

            return Json(new { status, precisaAvaliar });
        }

        [HttpPost]
        public async Task<IActionResult> EnviarAvaliacao(int idChamado, int nota, string? comentario)
        {
            var redir = VerificarLogin();
            if (redir != null) return redir;

            var ok = await _api.EnviarAvaliacaoAsync(idChamado, nota, comentario);

            TempData[ok ? "Mensagem" : "Erro"] =
                ok ? "Avaliação enviada. Obrigado pelo feedback!" : "Não foi possível enviar a avaliação.";

            return RedirectToAction("Chat", new { id = idChamado, avaliarEnviado = ok });
        }

        [HttpGet]
        public async Task<IActionResult> Notificacoes()
        {
            int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");
            if (idUsuario == null)
                return Json(Array.Empty<object>());

            var chamados = await _api.ObterChamadosAsync(idUsuario.Value);
            if (chamados == null || chamados.Count == 0)
                return Json(Array.Empty<object>());

            var pendentes = new List<object>();

            foreach (var c in chamados)
            {
                if (c.StatusChamado == null)
                    continue;

                bool resolvidoOuEncerrado =
                    c.StatusChamado.Equals("Resolvido", StringComparison.OrdinalIgnoreCase) ||
                    c.StatusChamado.Equals("Encerrado", StringComparison.OrdinalIgnoreCase);

                if (resolvidoOuEncerrado)
                {
                    var avaliacao = await _api.ObterAvaliacaoPorChamadoAsync(c.IdChamado);
                    if (avaliacao == null)
                    {
                        pendentes.Add(new
                        {
                            IdChamado = c.IdChamado,
                            Titulo = $"Chamado #{c.IdChamado} {c.StatusChamado}",
                            Mensagem = "Avalie o atendimento.",
                            Data = c.DataAbertura.ToString("dd/MM/yyyy HH:mm")
                        });
                    }
                }
            }

            return Json(pendentes);
        }

        [HttpPost]
        public async Task<IActionResult> ResponderIA(int idChamado, string resposta)
        {
            var redir = VerificarLogin();
            if (redir != null) return redir;

            var idUsuario = ObterIdCliente()!.Value;

            await _api.EnviarMensagemAsync(new InteracaoCreateDto
            {
                IdChamado = idChamado,
                IdUsuario = idUsuario,
                Mensagem = resposta,
                Origem = "Cliente"
            });

            if (string.IsNullOrWhiteSpace(resposta))
            {
                TempData["Erro"] = "Não foi possível registrar a resposta. Tente novamente.";
                return RedirectToAction("Chat", new { id = idChamado });
            }

            resposta = resposta.Trim().ToLower();

            if (resposta == "sim")
            {
                var ok = await _api.AceitarSolucaoAsync(idChamado);
                TempData["Aviso"] = "✅ Chamado resolvido com sucesso! Obrigado pelo seu feedback 🎉";

                if (ok)
                {
                    await Task.Delay(500);
                    return RedirectToAction("Chat", new { id = idChamado, avaliar = true });
                }
            }
            else if (resposta == "não" || resposta == "nao")
            {
                var ok = await _api.RejeitarSolucaoAsync(idChamado);
                TempData["Aviso"] = "🔄 Sua solicitação foi encaminhada para um técnico. Aguarde o atendimento.";

                if (ok)
                    return RedirectToAction("Chat", new { id = idChamado });
            }

            return RedirectToAction("Chat", new { id = idChamado });
        }

        [HttpGet]
        public async Task<IActionResult> ChatPartial(int id)
        {
            var redir = VerificarLogin();
            if (redir != null) return redir;

            var chamado = await _api.ObterChamadoPorIdAsync(id);
            var interacoes = await _api.ObterInteracoesPorChamadoAsync(id);
            var solucoes = await _api.ObterSolucoesPorChamadoAsync(id);

            var model = new ChatViewModel
            {
                Chamado = chamado!,
                Interacoes = interacoes,
                Solucoes = solucoes
            };

            return PartialView("_ChatMensagens", model);
        }

        [HttpGet]
        public async Task<IActionResult> ChamadosRecentes()
        {
            var redir = VerificarLogin();
            if (redir != null) return redir;

            var idUsuario = ObterIdCliente()!.Value;
            var todos = await _api.ObterChamadosAsync(idUsuario);

            var top5 = todos
                .OrderByDescending(c => c.DataAbertura)
                .Take(5)
                .ToList();

            return PartialView("_ChamadosRecentes", top5);
        }

        [HttpGet]
        public async Task<IActionResult> NotificacoesMensagens()
        {
            int? idCliente = HttpContext.Session.GetInt32("IdUsuario");
            if (idCliente == null)
                return Json(Array.Empty<object>());

            // 🔹 Chama o novo endpoint da API pelo ApiService
            var notificacoes = await _api.GetAsync<List<object>>(
                $"Chamado/notificacoes/mensagens/{idCliente}");

            if (notificacoes == null)
                return Json(Array.Empty<object>());

            return Json(notificacoes);

        }




    }
}
