using System.Net.Http.Json;
using System.Text.Json;
using SuporteTI.Desktop.DTOs;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SuporteTI.Desktop.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7177/api/")
            };
        }

        // AREA RELACIONADA AO LOGIN

        // Valida email+senha e retorna dados básicos do usuário (Id, Nome, Email, Tipo)
        public async Task<LoginResponseDto?> ValidarUsuarioAsync(LoginRequestDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Auth/validar-usuario", loginDto);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<LoginResponseDto>();
        }

        public async Task<object?> SolicitarCodigoAsync(LoginRequestDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Auth/solicitar-codigo", loginDto);

            if (!response.IsSuccessStatusCode)
                return null;

            // ✅ Lê o conteúdo como string primeiro (para evitar o erro do Stream fechado)
            var json = await response.Content.ReadAsStringAsync();

            try
            {
                // ✅ Tenta converter para LoginResponseDto
                var dto = System.Text.Json.JsonSerializer.Deserialize<LoginResponseDto>(json, new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (dto != null && !string.IsNullOrEmpty(dto.Email))
                    return dto;
            }
            catch
            {
                // ignora e tenta como mensagem simples
            }

            // ✅ Se não for um DTO, tenta ler mensagem simples
            try
            {
                var messageObj = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                if (messageObj != null && messageObj.ContainsKey("Mensagem"))
                    return messageObj["Mensagem"];
            }
            catch
            {
                // fallback: retorna o próprio JSON se nada funcionar
            }

            return json;
        }


        // Valida o login por código e retorna token + dados do usuário
        public async Task<LoginResponseDto?> ValidarLoginAsync(string email, string codigo)
        {
            var payload = new { Email = email, Codigo = codigo };
            var response = await _httpClient.PostAsJsonAsync("Auth/login", payload);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<LoginResponseDto>();
        }

        //------------------------------------------------------------------------------------------------

        // AREA RELACIONADA AOS CHAMADOS/TECNICO

        public async Task<List<ChamadoReadDto>> ObterChamadosTecnicoAsync(int idTecnico)
        {
            var response = await _httpClient.GetAsync($"ChamadoTecnico/{idTecnico}");
            response.EnsureSuccessStatusCode();
            var lista = await response.Content.ReadFromJsonAsync<List<ChamadoReadDto>>();
            return lista ?? new List<ChamadoReadDto>();
        }

        public async Task<List<InteracaoReadDto>> GetInteracoesPorChamadoAsync(int idChamado)
        {
            var response = await _httpClient.GetAsync($"Interacao/chamado/{idChamado}");
            response.EnsureSuccessStatusCode();
            var lista = await response.Content.ReadFromJsonAsync<List<InteracaoReadDto>>();
            return lista ?? new List<InteracaoReadDto>();
        }


        public async Task<bool> EnviarInteracaoAsync(InteracaoCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"ChamadoTecnico/mensagem/{dto.IdChamado}", dto);
            return response.IsSuccessStatusCode;
            if (!response.IsSuccessStatusCode)
            {
                var msg = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Erro ao enviar: {msg}");
                return false;
            }
            return true;
        }


        public async Task<bool> AtualizarStatusChamadoAsync(int idChamado, string novoStatus)
        {
            var dto = new
            {
                StatusChamado = novoStatus
            };

            var response = await _httpClient.PutAsJsonAsync($"Chamado/{idChamado}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EncerrarChamadoAsync(int idChamado, EncerrarChamadoDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"ChamadoTecnico/encerrar/{idChamado}", dto);
            return response.IsSuccessStatusCode;
        }


        public async Task<List<AnexoReadDto>> ObterAnexosPorChamadoAsync(int chamadoId)
        {
            var response = await _httpClient.GetAsync($"Anexo/{chamadoId}");
            response.EnsureSuccessStatusCode();

            var anexos = await response.Content.ReadFromJsonAsync<List<AnexoReadDto>>(
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return anexos ?? new List<AnexoReadDto>();
        }






    }
}
