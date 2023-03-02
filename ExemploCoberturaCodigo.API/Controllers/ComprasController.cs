using ExemploCoberturaCodigo.API.Helpers;
using ExemploCoberturaCodigo.Domain.Interfaces.Services;
using ExemploCoberturaCodigo.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExemploCoberturaCodigo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComprasController : ControllerBase
    {
        public readonly IComprasService _ComprasService;
        public ComprasController(IComprasService comprasService)
        {
            _ComprasService = comprasService;
        }

        [HttpPost("InserirOrdemCompra")]
        public async Task<IActionResult> AprovarOrdemCompra([FromBody] int id)
        {
            //Aqui você Poderia Obter o usuario enviado pela API (um JWT Bearer por exemplo)
            var usuario = new Usuario
            {
                Id = 1,
                Name = "Bertuzzi",
                PermissaoAprovar = true
            };

            var aprovacao = await _ComprasService.AprovarOrdemCompra(id,usuario);

            var retorno = new Retorno
            {
                Mensagem = aprovacao.Item2,
                Sucesso = aprovacao.Item1
            };

            return new CustomResult(HttpStatusCode.OK, retorno);
        }
    }
}
