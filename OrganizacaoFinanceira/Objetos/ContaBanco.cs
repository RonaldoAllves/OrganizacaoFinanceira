namespace OrganizacaoFinanceira.Objetos
{
    public class ContaBanco
    {
        public int chave { get; set; }
        public string nomeBanco { get; set; }
        public string usuarioConta { get; set; }
        public short diaFechamento { get; set; }
        public double valorInicial { get; set; }
        public DateTime dataCriacao { get; set; }
        public DateTime dataAlteracao { get; set; }

        public string descricaoConta
        {
            get { return nomeBanco + " - " + usuarioConta; }
        }

        public double valorAtual { get; set; }
    }
}
