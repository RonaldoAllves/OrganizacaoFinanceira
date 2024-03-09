using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizacaoFinanceira.Objetos
{
    internal class Categoria
    {
        public int chave { get; set; }
        public string descricao { get; set;}
        public double verbaPadrao { get; set; }
        public double saldoTotal { get; set; }
    }
}
