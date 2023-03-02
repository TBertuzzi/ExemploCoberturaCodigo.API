using ExemploCoberturaCodigo.Domain.Interfaces.Repositories;
using ExemploCoberturaCodigo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploCoberturaCodigo.Data.Repositories
{
    public class ComprasRepository : IComprasRepository
    {
        public Task AtualizaOrdemCompra(OrdemCompra ordemCompra)
        {
            //Simulando que deu Certo
            return Task.CompletedTask;
        }

        public Task<OrdemCompra> ObterOrdemCompraPorId(int idOrdemCompra)
        {
            OrdemCompra retorno = null;
            switch (idOrdemCompra)
            {
                case 1:
                    retorno = new OrdemCompra
                    {
                        Aprovada = false,
                        Descricao = "Notebook Gamer Asus",
                        Fornecedor = "Asus",
                        Solicitante = "Gilberto",
                        Valor = 15000,
                        Id = 1
                    };
                    break;
                case 2:
                    retorno = new OrdemCompra
                    {
                        Aprovada = false,
                        Descricao = "Chicote para Bater em Dev Junior",
                        Fornecedor = "Chicotes LTDA",
                        Solicitante = "Dev Senior",
                        Valor = 2000,
                        Id = 1
                    };
                    break;
                    
            }

            return Task.FromResult<OrdemCompra>(retorno);
        }
    }
}
