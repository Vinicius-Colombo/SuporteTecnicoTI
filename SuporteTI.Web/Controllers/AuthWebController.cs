using Microsoft.AspNetCore.Mvc;
using SuporteTI.Web.DTOs;
using SuporteTI.Web.Models;
using System.Text.Json;

namespace SuporteTI.Web.Controllers
{
    public class AuthWebController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AuthWebController> _logger;

        public AuthWebController(ILogger<AuthWebController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7177/api/")
            };
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

            // 1️⃣ Valida usuário e senha
            var response = await _httpClient.PostAsJsonAsync("Auth/validar-usuario", new
            {
                Email = model.Email,
                Senha = model.Senha
            });

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "E-mail ou senha inválidos.");
                return View(model);
            }

            var json = await response.Content.ReadAsStringAsync();
            var usuario = JsonSerializer.Deserialize<LoginResponseDto>(
                json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (usuario == null)
            {
                ModelState.AddModelError("", "Erro ao obter dados do usuário.");
                return View(model);
            }

            // 🔒 Apenas clientes podem acessar a Web
            if (!usuario.Tipo.Equals("Cliente", StringComparison.OrdinalIgnoreCase))
            {
                ModelState.AddModelError("", "Somente clientes podem acessar o portal web.");
                return View(model);
            }

            // 2️⃣ Verifica se já foi validado anteriormente
            if (usuario.CodigoValidado)
            {
                CriarSessao(usuario);
                HttpContext.Session.SetString("UltimaValidacao", DateTime.Now.ToString());
                return RedirectToAction("Novo", "Cliente");
            }

            // 3️⃣ Solicita envio do código se ainda não foi validado
            var responseCodigo = await _httpClient.PostAsJsonAsync("Auth/solicitar-codigo", new
            {
                Email = model.Email,
                Senha = model.Senha
            });

            if (!responseCodigo.IsSuccessStatusCode)
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

            var response = await _httpClient.PostAsJsonAsync("Auth/login", new
            {
                Email = email,
                Codigo = codigo
            });

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Código inválido ou expirado.");
                TempData.Keep();
                return View();
            }

            var json = await response.Content.ReadAsStringAsync();
            var usuario = JsonSerializer.Deserialize<LoginResponseDto>(
                json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (usuario == null)
            {
                ModelState.AddModelError("", "Erro ao validar o código.");
                return View();
            }

            // ✅ Marca como validado na sessão e entra no sistema
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
            // 🔹 Remove tudo da sessão atual
            HttpContext.Session.Clear();

            // 🔹 Cria um novo cookie de sessão vazio
            Response.Cookies.Delete(".AspNetCore.Session");

            // 🔹 Redireciona para tela de login limpa
            return RedirectToAction("Login", "AuthWeb");
        }

    }
}
