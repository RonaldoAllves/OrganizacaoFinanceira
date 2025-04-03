namespace OrganizacaoFinanceira.Objetos
{
    public class VerbaCategorias
    {
        public int chaveCategoria { get; set; }
        public string descricaoCategoria { get; set; }
        public int chaveMes { get; set; }
        public double verbaOriginalMesCategoria { get; set; }
        public double verbaAdicionalMesCategoria { get; set; }
        public double verbaMesCategoria { get; set; }
        public double gastoMes { get; set; }
        public double saldoMes { get; set; }
        public double saldoTotal { get; set; }
        public double saldoGeral { get; set; }
    }
}
