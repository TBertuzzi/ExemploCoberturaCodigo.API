using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploCoberturaCodigo.Domain.Models
{
    public class OrdemCompra
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Fornecedor { get; set; }
        public string Solicitante { get; set; }
        public bool Aprovada { get; set; }
    }
}
