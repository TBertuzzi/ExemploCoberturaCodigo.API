using ExemploCoberturaCodigo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploCoberturaCodigo.Domain.Interfaces.Repositories
{
    public interface IComprasRepository
    {
        Task<OrdemCompra> ObterOrdemCompraPorId(int idOrdemCompra);
        Task AtualizaOrdemCompra(OrdemCompra ordemCompra);
    }
}
