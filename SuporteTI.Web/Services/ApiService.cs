using SuporteTI.Web.DTOs;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;


namespace SuporteTI.Web.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl;

        public ApiService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _baseUrl = config["Api:BaseUrl"] ?? "https://localhost:7177/api";
        }


        public async Task<LoginResponseDto?> ObterUsuarioPorIdAsync(int idUsuario)
        {
            var response = await _http.GetAsync($"{_baseUrl}/Usuario/{idUsuario}");
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<LoginResponseDto>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }


        // 🔹 Abrir Chamado (com ou sem anexo)
        public async Task<int?> AbrirChamadoAsync(int idUsuario, string titulo, string descricao, IFormFile? anexo)
        {
            // 🔹 Sanitiza a descrição (remove caracteres quebrados e espaços invisíveis)
            descricao = descricao?.Normalize().Trim() ?? "";
            descricao = descricao.Replace("\r", " ").Replace("\n", " ");

            // 🔹 Monta o objeto compatível com ChamadoCreateDto
            var dto = new
            {
                Titulo = titulo,
                Descricao = descricao,
                IdUsuario = idUsuario,
                Prioridade = "Media",
                Categoria = ""
            };

            // 🔹 Serializa e envia
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _http.PostAsync($"{_baseUrl}/Chamado", content);

            if (!response.IsSuccessStatusCode)
                return null;

            var jsonResult = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(jsonResult);
            var idChamado = doc.RootElement.GetProperty("idChamado").GetInt32();

            // 🔹 Anexo opcional
            if (anexo != null)
            {
                using var form = new MultipartFormDataContent();
                var stream = anexo.OpenReadStream();

                form.Add(new StreamContent(stream)
                {
                    Headers = { ContentType = new MediaTypeHeaderValue(anexo.ContentType) }
                }, "arquivo", anexo.FileName);

                await _http.PostAsync($"{_baseUrl}/Anexo/{idChamado}", form);
            }

            return idChamado;
        }


        // 🔹 Histórico de Chamados
        public async Task<List<ChamadoReadDto>> ObterChamadosAsync(int idUsuario)
        {
            var response = await _http.GetAsync($"{_baseUrl}/Chamado");
            if (!response.IsSuccessStatusCode)
                return new List<ChamadoReadDto>();

            var json = await response.Content.ReadAsStringAsync();
            var chamados = JsonSerializer.Deserialize<List<ChamadoReadDto>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<ChamadoReadDto>();

            return chamados.Where(c => c.Usuario != null && c.Usuario.IdUsuario == idUsuario).ToList();
        }


        // 🔹 Detalhes do Chamado
        public async Task<ChamadoReadDto?> ObterChamadoPorIdAsync(int id)
        {
            var response = await _http.GetAsync($"{_baseUrl}/Chamado/{id}");
            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ChamadoReadDto>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        // 🔹 Obter mensagens do chat
        public async Task<List<InteracaoReadDto>> ObterInteracoesPorChamadoAsync(int idChamado)
        {
            var response = await _http.GetAsync($"{_baseUrl}/Interacao/chamado/{idChamado}");
            if (!response.IsSuccessStatusCode)
                return new List<InteracaoReadDto>();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<InteracaoReadDto>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<InteracaoReadDto>();
        }

        // 🔹 Enviar mensagem
        public async Task<bool> EnviarMensagemAsync(InteracaoCreateDto dto)
        {
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync($"{_baseUrl}/Interacao", content);
            return response.IsSuccessStatusCode;
        }

        // 🔹 Obter anexos
        public async Task<List<AnexoReadDto>> ObterAnexosPorChamadoAsync(int idChamado)
        {
            var response = await _http.GetAsync($"{_baseUrl}/Anexo/{idChamado}");
            if (!response.IsSuccessStatusCode)
                return new List<AnexoReadDto>();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<AnexoReadDto>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<AnexoReadDto>();
        }

        // 🔹 Enviar anexo
        public async Task<bool> EnviarAnexoAsync(int idChamado, IFormFile arquivo)
        {
            using var form = new MultipartFormDataContent();
            var stream = arquivo.OpenReadStream();

            form.Add(new StreamContent(stream)
            {
                Headers = { ContentType = new MediaTypeHeaderValue(arquivo.ContentType) }
            }, "arquivo", arquivo.FileName);

            var response = await _http.PostAsync($"{_baseUrl}/Anexo/{idChamado}", form);
            return response.IsSuccessStatusCode;
        }

        // 🔹 Baixar anexo
        public async Task<(byte[] bytes, string nome, string tipo)> BaixarAnexoAsync(int idAnexo)
        {
            var response = await _http.GetAsync($"{_baseUrl}/Anexo/download/{idAnexo}");
            if (!response.IsSuccessStatusCode)
                return (Array.Empty<byte>(), string.Empty, string.Empty);

            var bytes = await response.Content.ReadAsByteArrayAsync();
            var fileName = response.Content.Headers.ContentDisposition?.FileName?.Trim('"')
                ?? $"anexo_{idAnexo}.bin";
            var contentType = response.Content.Headers.ContentType?.ToString()
                ?? "application/octet-stream";

            return (bytes, fileName, contentType);
        }

        // 🔹 Avaliações
        public async Task<AvaliacaoReadDto?> ObterAvaliacaoPorChamadoAsync(int idChamado)
        {
            var resp = await _http.GetAsync($"{_baseUrl}/Avaliacao/{idChamado}");
            if (resp.StatusCode == System.Net.HttpStatusCode.NotFound) return null;
            resp.EnsureSuccessStatusCode();

            var json = await resp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AvaliacaoReadDto>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> EnviarAvaliacaoAsync(int idChamado, int nota, string? comentario)
        {
            var dto = new { IdChamado = idChamado, Nota = nota, Comentario = comentario ?? "" };
            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
            var resp = await _http.PostAsync($"{_baseUrl}/Avaliacao", content);
            return resp.IsSuccessStatusCode;
        }

        // ✅ Aceitar solução sugerida (ALTERADO)
        public async Task<bool> AceitarSolucaoAsync(int idChamado)
        {
            var response = await _http.PutAsync($"{_baseUrl}/SolucaoSugerida/aceitar/{idChamado}", null);
            return response.IsSuccessStatusCode;
        }

        // ✅ Rejeitar solução sugerida (ALTERADO)
        public async Task<bool> RejeitarSolucaoAsync(int idChamado)
        {
            var response = await _http.PutAsync($"{_baseUrl}/SolucaoSugerida/rejeitar/{idChamado}", null);
            return response.IsSuccessStatusCode;
        }

        // 🔹 Obter soluções sugeridas
        public async Task<List<SolucaoSugeridaReadDto>> ObterSolucoesPorChamadoAsync(int idChamado)
        {
            var response = await _http.GetAsync($"{_baseUrl}/SolucaoSugerida/{idChamado}");
            if (!response.IsSuccessStatusCode)
                return new List<SolucaoSugeridaReadDto>();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<SolucaoSugeridaReadDto>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new List<SolucaoSugeridaReadDto>();
        }

        public async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            return await _http.GetAsync($"{_baseUrl}/{endpoint}");
        }

    }
}
