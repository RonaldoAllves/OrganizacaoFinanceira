using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizacaoFinanceira.Objetos
{
    public class Mes
    {
        public int chave {  get; set; }
        public DateTime mes {  get; set; }
        public double verbaOriginal { get; set; }
        public double verbaAdicional { get; set; }
        public int chaveCategoria { get; set; }     
        
        public double verbaMes
        {
            get { return verbaOriginal + verbaAdicional; }
        }

        public double saldoMes { get; set; }       
    }
}
