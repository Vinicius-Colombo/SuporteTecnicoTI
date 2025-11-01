using SuporteTI.Web.DTOs;

namespace SuporteTI.Web.Models
{
    public class ChatViewModel
    {
        public ChamadoReadDto Chamado { get; set; } = new ChamadoReadDto();
        public List<InteracaoReadDto> Interacoes { get; set; } = new();
        public List<AnexoReadDto> Anexos { get; set; } = new();
        public string NovaMensagem { get; set; } = string.Empty;
        public List<SolucaoSugeridaReadDto> Solucoes { get; set; } = new();
        public List<ChamadoReadDto> ChamadosRecentes { get; set; } = new();


    }
}
