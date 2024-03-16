using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizacaoFinanceira.Objetos
{
    public class VerbaCategorias
    {
        public int chaveCategoria {  get; set; }
        public string descricaoCategoria { get; set; }
        public int chaveMes {  get; set; }
        public double verbaOriginalMesCategoria { get; set; }
        public double verbaAdicionalMesCategoria { get; set; }
        public double verbaMesCategoria { get; set; }
        public double saldoMes {  get; set; }
    }
}
