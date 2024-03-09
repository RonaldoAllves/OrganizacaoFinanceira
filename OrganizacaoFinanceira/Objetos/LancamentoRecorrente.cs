using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizacaoFinanceira.Objetos
{
    public class LancamentoRecorrente
    {
        public int chave {  get; set; }
        public int chaveCategoria { get; set; }
        public string descricao { get; set; }
        public double valor { get; set; }
        public byte tipoLancamento { get; set; }
        public bool obrigatorio { get; set; }
    }
}
