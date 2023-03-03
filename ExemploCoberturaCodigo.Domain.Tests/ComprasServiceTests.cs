using ExemploCoberturaCodigo.Data.Repositories;
using ExemploCoberturaCodigo.Domain.Interfaces.Services;
using ExemploCoberturaCodigo.Domain.Models;
using ExemploCoberturaCodigo.Domain.Services;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace ExemploCoberturaCodigo.Domain.Tests
{
    //[Trait("Categoria", "Compras")]
    public class ComprasServiceTests
    {
        private readonly ComprasService _ComprasService;
        private readonly ITestOutputHelper _TestOutputHelper;

        public ComprasServiceTests(ITestOutputHelper testOutputHelper)
        {
            _ComprasService = new ComprasService(new ComprasRepository());
            _TestOutputHelper = testOutputHelper;
        }

        [Fact]
        //[Trait("Categoria","OrdemCompra")]
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
        public async Task TupleRetornaFalsoSeIdOrdemCompraNaoForEncontrado()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Name = "Bertuzzi",
                PermissaoAprovar = true
            };

            var retorno = await _ComprasService.AprovarOrdemCompra(5, usuario);
            Assert.False(retorno.Item1);
        }

        [Fact]
        //[Trait("Categoria", "Usuario")]
        public async Task TupleRetornaFalsoSeUsuarioNaoForFornecido()
        {
            _TestOutputHelper.WriteLine("Usuario não fornecido");
            var retorno = await _ComprasService.AprovarOrdemCompra(1, new Usuario());
            Assert.False(retorno.Item1);
        }

        [Fact]
        //[Fact(Skip = "Essa regra sera validada em outro momento")]
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

        #region Mais Testes
        //[Fact]
        //public async Task TupleRetornaFalsoSeIdusuarioForNegativo()
        //{
        //    var usuario = new Usuario
        //    {
        //        Id = -1,
        //        Name = "Bertuzzi",
        //        PermissaoAprovar = true
        //    };

        //    var retorno = await _ComprasService.AprovarOrdemCompra(1, usuario);
        //    Assert.False(retorno.Item1);
        //}
        #endregion

        #region Data Driven
        //[Theory]
        //[InlineData(1)]
        //[InlineData(2)]
        //[InlineData(3)]
        //[InlineData(4)]
        //[InlineData(5)]
        //public async Task TupleRetornaFalsoSeIdsOrdemCompraNaoForemEncontrados(int ordemCompra)
        //{
        //    var usuario = new Usuario
        //    {
        //        Id = 1,
        //        Name = "Bertuzzi",
        //        PermissaoAprovar = true
        //    };

        //    var retorno = await _ComprasService.AprovarOrdemCompra(ordemCompra, usuario);
        //    Assert.False(retorno.Item1);
        //}
        #endregion

    }
}