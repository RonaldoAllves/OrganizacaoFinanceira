using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizacaoFinanceira.Objetos
{
    public class LancamentoRecorrenteDetalhado
    {
        public int chave { get; set; }
        public int chaveLancRecorrente { get; set; }
        public string descricao { get; set; }
        public double valor { get; set; }
        public byte tipoLancamento { get; set; }
        public byte mes { get; set; }
    }
}
