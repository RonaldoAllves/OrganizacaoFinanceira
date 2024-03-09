using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizacaoFinanceira.Objetos
{
    public class Saida
    {
        public int chave { get; set; }
        public int chaveConta { get; set; }
        public int chaveCategoria { get; set; }
        public string descricao { get; set; }
        public byte tipoSaida { get; set; } //0 - Crédito, 1 - Dinheiro
        public double valorTotal { get; set; }
        public double valorParcela { get; set; }
        public int parcela { get; set; }
        public int qtdParcelas { get; set; }
        public DateTime mesReferencia { get; set; }
        public DateTime data { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataAlteracao { get; set; }

        public Saida Copy()
        {
            Saida novaSaida = new Saida();

            novaSaida.chave = this.chave;
            novaSaida.chaveConta = this.chaveConta;
            novaSaida.chaveCategoria = this.chaveCategoria;
            novaSaida.descricao = this.descricao;
            novaSaida.tipoSaida = this.tipoSaida;
            novaSaida.valorTotal = this.valorTotal;
            novaSaida.valorParcela = this.valorParcela;
            novaSaida.parcela = this.parcela;
            novaSaida.qtdParcelas = this.qtdParcelas;
            novaSaida.mesReferencia = this.mesReferencia;
            novaSaida.data = this.data;
            novaSaida.dataInicio = this.dataInicio;
            novaSaida.dataCadastro = this.dataCadastro;
            novaSaida.dataAlteracao = this.dataAlteracao;

            return novaSaida;
        }
    }
}
