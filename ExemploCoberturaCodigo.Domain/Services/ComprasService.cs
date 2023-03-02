using ExemploCoberturaCodigo.Domain.Interfaces.Repositories;
using ExemploCoberturaCodigo.Domain.Interfaces.Services;
using ExemploCoberturaCodigo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploCoberturaCodigo.Domain.Services
{
    public class ComprasService : IComprasService
    {
        private readonly IComprasRepository _comprasRepository;
        public ComprasService(IComprasRepository comprasRepository) 
        {
            _comprasRepository = comprasRepository;
        }

        public async Task<Tuple<bool, string>> AprovarOrdemCompra(int idOrdemCompra, Usuario usuario)
        {
            if(usuario == null || usuario?.Id == 0)
            {
                return Tuple.Create(false, "Usuario não encontrado");
            }
            else if(!usuario.PermissaoAprovar)
            {
                return Tuple.Create(false, "Usuario não possui permissão de aprovador");
            }

            var ordemCompra = await _comprasRepository.ObterOrdemCompraPorId(idOrdemCompra);

            if (ordemCompra == null)
            {
                return Tuple.Create(false, "Ordem de Compra não encontrada");
            }

            ordemCompra.Aprovada = true;
            await _comprasRepository.AtualizaOrdemCompra(ordemCompra);

            return Tuple.Create(true, "Ordem de Compra Aprovada");
        }
    }
}
