using ExemploCoberturaCodigo.Data.Repositories;
using ExemploCoberturaCodigo.Domain.Interfaces.Services;
using ExemploCoberturaCodigo.Domain.Models;
using ExemploCoberturaCodigo.Domain.Services;

namespace ExemploCoberturaCodigo.Domain.Tests
{
    public class ComprasServiceTests
    {
        private ComprasService _ComprasService;

        public ComprasServiceTests()
        {
            _ComprasService = new ComprasService(new ComprasRepository());
        }

        [Fact]
        public async Task TupleRetornaFalsoSeIdOrdemCompraNaoForFornecido()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Name = "Bertuzzi",
                PermissaoAprovar = true
            };

            var retorno = await _ComprasService.AprovarOrdemCompra(0, usuario);
            Assert.False(retorno.Item1);
        }

        [Fact]
        public async Task TupleRetornaFalsoSeUsuarioNaoForFornecido()
        {
            var retorno = await _ComprasService.AprovarOrdemCompra(1, new Usuario());
            Assert.False(retorno.Item1);
        }

        [Fact]
        public async Task TupleRetornaFalsoSeUsuarioNaoTiverPermissao()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Name = "Bertuzzi",
                PermissaoAprovar = false
            };

            var retorno = await _ComprasService.AprovarOrdemCompra(1, usuario);
            Assert.False(retorno.Item1);
        }


    }
}