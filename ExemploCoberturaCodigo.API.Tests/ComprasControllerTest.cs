using ExemploCoberturaCodigo.API.Controllers;
using ExemploCoberturaCodigo.API.Helpers;
using ExemploCoberturaCodigo.Data.Repositories;
using ExemploCoberturaCodigo.Domain.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExemploCoberturaCodigo.API.Tests
{
    public class ComprasControllerTest
    {
        [Fact]
        public async Task  ComprasRetornaFalsoSeIdOrdemCompraNaoForEncontrado()
        {
            var comprasRepository = new ComprasRepository();
            var controller = new ComprasController(new ComprasService(comprasRepository),
                comprasRepository);

            var result = await controller.ObterOrdemCompra(5);

            var statusCode = (HttpStatusCode)((CustomResult)result)?.StatusCode;

            Assert.Equal(statusCode, HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task ComprasRetornaFalsoSeIdOrdemCompraNaoForFornecido()
        {
            var comprasRepository = new ComprasRepository();
            var controller = new ComprasController(new ComprasService(comprasRepository),
                comprasRepository);

            var result = await controller.ObterOrdemCompra(0);

            var statusCode = (HttpStatusCode)((CustomResult)result)?.StatusCode;

            Assert.Equal(statusCode, HttpStatusCode.BadRequest);
        }

        
    }
}