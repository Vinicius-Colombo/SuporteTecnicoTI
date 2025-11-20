using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SuporteTI.API.Services
{
    // Classe responsável pela comunicação com a API da OpenAI.
    public class IAService
    {
        private readonly HttpClient _httpClient;
        private readonly string _openAiApiKey;

        public IAService(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _openAiApiKey = config["OpenAI:ApiKey"] ?? throw new Exception("Chave da OpenAI não configurada.");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _openAiApiKey);
        }

        // Método para analisar a descrição do chamado e retornar categoria, solução e prioridade.
        public async Task<(string categoria, string solucao, string prioridade)> AnalisarChamadoAsync(string descricao)
        {
            string categoria = "Outros";
            string prioridade = "Média";
            string solucao = "Não foi possível gerar uma solução.";

            if (string.IsNullOrWhiteSpace(descricao))
                descricao = "O usuário não forneceu detalhes do problema.";

            // Prompt estruturado
            var prompt = $@"
                        Você é um assistente técnico especializado em suporte de TI.
                        Analise a descrição do chamado abaixo e gere uma resposta estruturada.
                        Responda **apenas** no formato:

                        Categoria: [Hardware | Software | Rede | Acesso | Outros]
                        Prioridade: [Alta | Média | Baixa]
                        Solução: [descrição curta da solução]

                        Descrição do chamado: {descricao}
                        ";

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "Você é um assistente técnico de suporte de TI." },
                    new { role = "user", content = prompt }
                },
                temperature = 0.4,
                max_tokens = 300
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var json = await response.Content.ReadAsStringAsync();

            

            if (!response.IsSuccessStatusCode)
                return (categoria, $"Erro ao consultar OpenAI: {response.ReasonPhrase}", prioridade);

            try
            {
                using var doc = JsonDocument.Parse(json);
                var message = doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();

                if (!string.IsNullOrWhiteSpace(message))
                {
                    var cate = ExtrairCampo(message, "Categoria");
                    var prio = ExtrairCampo(message, "Prioridade");
                    var solu = ExtrairCampo(message, "Solução");

                    if (!string.IsNullOrWhiteSpace(cate)) categoria = cate;
                    if (!string.IsNullOrWhiteSpace(prio)) prioridade = prio;
                    if (!string.IsNullOrWhiteSpace(solu)) solucao = solu;
                    else solucao = message.Trim();
                }
            }
            catch (Exception ex)
            {
                solucao = $"Erro ao interpretar resposta da IA: {ex.Message}";
            }

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
