using Microsoft.AspNetCore.Mvc;
using SuporteTI.Web.DTOs;
using SuporteTI.Web.Models;
using SuporteTI.Web.Services;

namespace SuporteTI.Web.Controllers
{
    public class AuthWebController : Controller
    {
        private readonly ApiService _api;
        private readonly ILogger<AuthWebController> _logger;

        public AuthWebController(ApiService api, ILogger<AuthWebController> logger)
        {
            _api = api;
            _logger = logger;
        }

        // =====================================
        // 🧩 LOGIN (GET)
        // =====================================
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("IdUsuario") != null)
                return RedirectToAction("Novo", "Cliente");

            return View();
        }

        // =====================================
        // 🧩 LOGIN (POST)
        // =====================================
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Valida credenciais via API Azure
            var usuario = await _api.PostAsync<LoginResponseDto>("Auth/validar-usuario", new
            {
                Email = model.Email,
                Senha = model.Senha
            });

            if (usuario == null)
            {
                ModelState.AddModelError("", "E-mail ou senha inválidos.");
                return View(model);
            }

            // Somente cliente acessa web
            if (!usuario.Tipo.Equals("Cliente", StringComparison.OrdinalIgnoreCase))
            {
                ModelState.AddModelError("", "Somente clientes podem acessar o portal web.");
                return View(model);
            }

            // Se já validado, entra direto
            if (usuario.CodigoValidado)
            {
                CriarSessao(usuario);
                HttpContext.Session.SetString("UltimaValidacao", DateTime.Now.ToString());
                return RedirectToAction("Novo", "Cliente");
            }

            // Solicita envio de código
            var codigoResp = await _api.PostAsync<object>("Auth/solicitar-codigo", new
            {
                Email = model.Email,
                Senha = model.Senha
            });

            if (codigoResp == null)
            {
                ModelState.AddModelError("", "Erro ao solicitar código de verificação.");
                return View(model);
            }

            TempData["EmailCliente"] = model.Email;
            TempData["SenhaCliente"] = model.Senha;

            return RedirectToAction("ValidarCodigo");
        }

        // =====================================
        // 🔐 VALIDAR CÓDIGO (GET)
        // =====================================
        [HttpGet]
        public IActionResult ValidarCodigo()
        {
            if (TempData["EmailCliente"] == null)
                return RedirectToAction("Login");

            ViewBag.Email = TempData["EmailCliente"];
            TempData.Keep();
            return View();
        }

        // =====================================
        // 🔐 VALIDAR CÓDIGO (POST)
        // =====================================
        [HttpPost]
        public async Task<IActionResult> ValidarCodigo(string codigo)
        {
            var email = TempData["EmailCliente"]?.ToString();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                ModelState.AddModelError("", "Digite o código de verificação.");
                TempData.Keep();
                return View();
            }

            var usuario = await _api.PostAsync<LoginResponseDto>("Auth/login", new
            {
                Email = email,
                Codigo = codigo
            });

            if (usuario == null)
            {
                ModelState.AddModelError("", "Código inválido ou expirado.");
                TempData.Keep();
                return View();
            }

            CriarSessao(usuario);
            HttpContext.Session.SetString("UltimaValidacao", DateTime.Now.ToString());

            return RedirectToAction("Novo", "Cliente");
        }

        // =====================================
        // 🧱 CONTROLE DE SESSÃO
        // =====================================
        private void CriarSessao(LoginResponseDto usuario)
        {
            HttpContext.Session.SetInt32("IdUsuario", usuario.IdUsuario);
            HttpContext.Session.SetString("Nome", usuario.Nome);
            HttpContext.Session.SetString("Email", usuario.Email);
            HttpContext.Session.SetString("Tipo", usuario.Tipo ?? "Cliente");
            HttpContext.Session.SetString("Token", usuario.Token ?? "");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete(".AspNetCore.Session");
            return RedirectToAction("Login", "AuthWeb");
        }
    }
}
