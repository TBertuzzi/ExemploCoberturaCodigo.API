using ExemploCoberturaCodigo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploCoberturaCodigo.Domain.Interfaces.Services
{
    public interface IComprasService
    {
        Task<Tuple<bool, string>> AprovarOrdemCompra(int idOrdemCompra, Usuario usuario);
    }
}
