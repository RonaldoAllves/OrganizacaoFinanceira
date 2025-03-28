namespace OrganizacaoFinanceira.Objetos
{
    public class LancamentoRecorrente
    {
        public int chave { get; set; }
        public int chaveCategoria { get; set; }
        public string descricao { get; set; }
        public double valor { get; set; }
        public double saldo { get; set; } // Carrega o saldo do mês atual
        public byte tipoLancamento { get; set; } // 0 - saída ou 1 - entrada
        public DateTime dataFinal { get; set; }
        public bool obrigatorio { get; set; }
        public bool usaMesFixo { get; set; }
        public Nullable<DateTime> dataFixa {  get; set; }
    }
}
