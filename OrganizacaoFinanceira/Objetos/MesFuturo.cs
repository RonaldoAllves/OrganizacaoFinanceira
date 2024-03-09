using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizacaoFinanceira.Objetos
{
    internal class MesFuturo
    {
        public DateTime mes {  get; set; }
        public double entradasTotais { get; set; }
        public double saidasTotais { get; set; }
        public double saidasParceladas {  get; set; }
        public double saldoGeral { get; set; }
    }
}
