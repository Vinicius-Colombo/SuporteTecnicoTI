using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SuporteTI.API.Services
{
    public class IAService
    {
        private readonly HttpClient _httpClient;
        private readonly string _huggingFaceApiKey;

        public IAService(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _huggingFaceApiKey = config["HuggingFace:ApiKey"] ?? throw new Exception("Chave da HuggingFace não configurada.");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _huggingFaceApiKey);
        }

        public async Task<(string categoria, string solucao, string prioridade)> AnalisarChamadoAsync(string descricao)
        {
            // 🔹 1️⃣ Mapeamento simples baseado em palavras-chave
            string categoria = "Outros";
            string prioridade = "Média";

            string descLower = descricao.ToLower();

            if (descLower.Contains("computador") || descLower.Contains("placa") || descLower.Contains("energia") || descLower.Contains("monitor"))
                categoria = "Hardware";
            else if (descLower.Contains("internet") || descLower.Contains("rede") || descLower.Contains("wifi"))
                categoria = "Rede";
            else if (descLower.Contains("sistema") || descLower.Contains("erro") || descLower.Contains("programa"))
                categoria = "Software";
            else if (descLower.Contains("senha") || descLower.Contains("login"))
                categoria = "Acesso";

            // 🔹 2️⃣ Ajuste da prioridade
            if (descLower.Contains("urgente") || descLower.Contains("não liga") || descLower.Contains("parou"))
                prioridade = "Alta";

            // 🔹 3️⃣ Solicita sugestão textual à IA (opcional)
            var body = new
            {
                inputs = $"Usuário descreveu: {descricao}. Sugira uma breve solução em português."
            };

            var response = await _httpClient.PostAsync(
                "https://api-inference.huggingface.co/models/google/flan-t5-base",
                new StringContent(JsonSerializer.Serialize(body), System.Text.Encoding.UTF8, "application/json")
            );

            string output = await response.Content.ReadAsStringAsync();

            // 🔹 Extrai texto da resposta
            string solucao = "Verifique as conexões e tente reiniciar o dispositivo.";
            try
            {
                using var doc = JsonDocument.Parse(output);
                solucao = doc.RootElement[0].GetProperty("generated_text").GetString() ?? solucao;
            }
            catch { }

            return (categoria, solucao, prioridade);
        }
    

        private static string? ExtrairCampo(string texto, string campo)
        {
            var marcador = campo + ":";
            var inicio = texto.IndexOf(marcador, StringComparison.OrdinalIgnoreCase);
            if (inicio == -1) return null;

            inicio += marcador.Length;
            var fim = texto.IndexOf("\n", inicio);
            if (fim == -1) fim = texto.Length;

            return texto.Substring(inicio, fim - inicio).Trim();
        }
    }
}
