using SuporteTI.Data.Models;

namespace SuporteTI.API.Strategies
{
    public static class AutenticacaoStrategyFactory
    {
        public static IAutenticacaoStrategy ObterStrategy(Usuario usuario, SuporteTiDbContext context, IConfiguration configuration)
        {
            // Se expirou ou não existe -> gera novo
            if (!usuario.ExpiracaoCodigo.HasValue || usuario.ExpiracaoCodigo <= DateTime.Now)
                return new CodigoExpiradoStrategy(context, configuration);

            // Se já validado e ainda dentro do prazo -> entra direto
            if (usuario.CodigoValidado)
                return new CodigoAtivoValidadoStrategy(configuration);

            // Senão -> já existe código ativo mas não validado -> pede pra digitar
            return new CodigoAtivoNaoValidadoStrategy();
        }
    }

}
