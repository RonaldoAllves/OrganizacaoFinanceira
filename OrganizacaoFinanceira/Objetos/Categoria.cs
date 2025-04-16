namespace OrganizacaoFinanceira.Objetos
{
    public class Categoria
    {
        public int chave { get; set; }
        public string descricao { get; set; }
        public double verbaPadrao { get; set; }
        public double saldoTotal { get; set; }
        public byte prioridade { get; set; } // A partir do valor 1, onde quanto menor o valor, menos flexivel deve ser
        public bool gastoFlexivel { get; set; } // False - indica que deve evitar até último caso a redução do valor que pode gastar.
    }
}
