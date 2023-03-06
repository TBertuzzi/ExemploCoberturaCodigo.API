using ExemploCoberturaCodigo.Domain.Interfaces.Repositories;
using ExemploCoberturaCodigo.Domain.Models;
using ExemploCoberturaCodigo.Domain.Services;
using Moq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace ExemploCoberturaCodigo.Domain.Mock.Tests.Services
{
    public class ComprasServiceTests
    {
        private readonly ComprasService _ComprasService;

        public ComprasServiceTests(ITestOutputHelper testOutputHelper)
        {
            var mockComprasRepository = new Mock<IComprasRepository>();

            #region Configurando MOCK
            //var mockComprasRepository = new Mock<IComprasRepository>(MockBehavior.Strict);
            //    mockComprasRepository.Setup(x => x.
            //    ObterOrdemCompraPorId(It.IsNotIn<int>(1,2))).Returns(Task.FromResult<OrdemCompra>(null));
            #endregion

            _ComprasService = new ComprasService(mockComprasRepository.Object);
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
        public async Task TupleRetornaFalsoSeUsuarioNaoForFornecido()
        {
            var retorno = await _ComprasService.AprovarOrdemCompra(1, new Usuario());
            Assert.False(retorno.Item1);
        }

        [Fact]
        public async Task TupleRetornaFalsoSeUsuarioNaoTiverPermissao()
        {
            var mockUsuario = new Mock<Usuario>();
            mockUsuario.Object.PermissaoAprovar = false;

           var retorno = await _ComprasService.AprovarOrdemCompra(1, mockUsuario.Object);
           Assert.False(retorno.Item1);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public async Task TupleRetornaFalsoSeIdsOrdemCompraNaoForemEncontrados(int ordemCompra)
        {
            var usuario = new Usuario
            {
                Id = 1,
                Name = "Bertuzzi",
                PermissaoAprovar = true
            };

            var retorno = await _ComprasService.AprovarOrdemCompra(ordemCompra, usuario);
            Assert.False(retorno.Item1);
        }

        #region Mais Mock

        //[Theory]
        //[InlineData(1)]
        //[InlineData(2)]
        //[InlineData(3)]
        //[InlineData(4)]
        //[InlineData(5)]
        //public async Task TupleRetornaFalsoSeIdsOrdemCompraNaoForemEncontrados(int ordemCompra)
        //{
        //    var mockComprasRepository = new Mock<IComprasRepository>(MockBehavior.Strict);

        //    mockComprasRepository.Setup(x => x.
        //    ObterOrdemCompraPorId(It.IsIn<int>(1,2,3,4))).Returns(Task.FromResult<OrdemCompra>(null));

        //    var comprasService = new ComprasService(mockComprasRepository.Object);

        //    var usuario = new Usuario
        //    {
        //        Id = 1,
        //        Name = "Bertuzzi",
        //        PermissaoAprovar = true
        //    };

        //    var retorno = await comprasService.AprovarOrdemCompra(ordemCompra, usuario);
        //    Assert.False(retorno.Item1);
        //}
        #endregion
    }
}