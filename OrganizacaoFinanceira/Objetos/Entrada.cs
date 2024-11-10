namespace OrganizacaoFinanceira.Objetos
{
    public class Entrada
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
