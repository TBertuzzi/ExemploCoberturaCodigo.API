using ExemploCoberturaCodigo.API.Helpers;
using ExemploCoberturaCodigo.Domain.Interfaces.Repositories;
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
        private readonly IComprasService _ComprasService;
        private readonly IComprasRepository _ComprasRepository;
        public ComprasController(IComprasService comprasService,
            IComprasRepository comprasRepository)
        {
            _ComprasService = comprasService;
            _ComprasRepository = comprasRepository;
        }

        [HttpPost("InserirOrdemCompra")]
        public async Task<IActionResult> AprovarOrdemCompra([FromBody] int idOrdemCompra)
        {
            //Aqui você Poderia Obter o usuario enviado pela API (um JWT Bearer por exemplo)
            var usuario = new Usuario
            {
                Id = 1,
                Name = "Bertuzzi",
                PermissaoAprovar = true
            };

            var aprovacao = await _ComprasService.AprovarOrdemCompra(idOrdemCompra, usuario);

            var retorno = new Retorno
            {
                Mensagem = aprovacao.Item2,
                Sucesso = aprovacao.Item1
            };

            return new CustomResult(HttpStatusCode.OK, retorno);
        }

        [HttpGet("ObterOrdemCompra/{idOrdemCompra}")]
        public async Task<IActionResult> ObterOrdemCompra(int idOrdemCompra)
        {
            if (idOrdemCompra == 0)
                return new CustomResult(HttpStatusCode.BadRequest);

            var ordemCompra = await _ComprasRepository.ObterOrdemCompraPorId(idOrdemCompra);

            if(ordemCompra == null)
            {
                return new CustomResult(HttpStatusCode.NotFound);
            }
            else
            {
                return new CustomResult(HttpStatusCode.OK, ordemCompra);
            }
        }
    }
}
