using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizacaoFinanceira.Objetos
{
    internal class Entrada
    {
        public int chave { get; set; }
        public int chaveConta { get; set; }
        public int chaveCategoria { get; set; }
        public string descricao { get; set; }
        public double valor { get; set; }
        public DateTime mesReferencia { get; set; }
        public DateTime data { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataAlteracao { get; set; }
    }
}
