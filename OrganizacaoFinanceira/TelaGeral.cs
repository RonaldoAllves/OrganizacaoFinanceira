using OrganizacaoFinanceira.Dados;
using OrganizacaoFinanceira.Objetos;
using OrganizacaoFinanceira.Recursos;
using OrganizacaoFinanceira.Telas;
using System.Globalization;

namespace OrganizacaoFinanceira
{
    public partial class TelaGeral : Form
    {
        public TelaGeral()
        {
            InitializeComponent();
            LayoutColor.EstiloLayout(this);

            // Configurar o DateTimePicker para exibir apenas meses
            dtpDataInicial.Format = DateTimePickerFormat.Custom;
            dtpDataInicial.CustomFormat = "MM/yyyy"; // Exibir mês e ano
            dtpDataInicial.ShowUpDown = true; // Mostra botões de incremento

            dtpDataFinal.Format = DateTimePickerFormat.Custom;
            dtpDataFinal.CustomFormat = "MM/yyyy"; // Exibir mês e ano
            dtpDataFinal.ShowUpDown = true; // Mostra botões de incremento

            // Definir período inicial de 12 meses
            dtpDataInicial.Value = new DateTime(DateTime.Now.AddMonths(-12).Year, DateTime.Now.AddMonths(-12).Month, 1);
            dtpDataFinal.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private void TelaGeral_Load(object sender, EventArgs e)
        {
            lblValorRendimentosRecentes.ForeColor = Color.FromArgb(181, 230, 29);
            lblValorEntradasRecentes.ForeColor = Color.FromArgb(181, 230, 29);
            lblValorSaidasRecentes.ForeColor = Color.FromArgb(181, 230, 29);
            lblValorDividaTotal.ForeColor = Color.FromArgb(181, 230, 29);
            lblValorSaldoTotal.ForeColor = Color.FromArgb(181, 230, 29);

            lblValorRendimentosRecentes.Font = new Font("Arial", 16, FontStyle.Bold);
            lblValorEntradasRecentes.Font = new Font("Arial", 16, FontStyle.Bold);
            lblValorSaidasRecentes.Font = new Font("Arial", 16, FontStyle.Bold);
            lblValorDividaTotal.Font = new Font("Arial", 16, FontStyle.Bold);
            lblValorSaldoTotal.Font = new Font("Arial", 16, FontStyle.Bold);
            PreencherValores();
            ExibirGastosPorCategoria(panelDadosCategorias);
        }

        private void PreencherValores()
        {
            double rendimentos = 0;
            double entradas = 0;
            double saidas = 0;
            double dividaTotal = 0;
            double saldo = 0;

            // Ajustar início e fim do período com base nos DateTimePicker
            var inicioPeriodo = new DateTime(dtpDataInicial.Value.Year, dtpDataInicial.Value.Month, 1);
            var fimPeriodo = new DateTime(dtpDataFinal.Value.Year, dtpDataFinal.Value.Month, DateTime.DaysInMonth(dtpDataFinal.Value.Year, dtpDataFinal.Value.Month));

            if (DadosGerais.entradas != null && DadosGerais.entradas.Count > 0)
            {
                rendimentos = DadosGerais.entradas
                    .Where(x => x.descricao.Contains("ndiment") && x.data >= inicioPeriodo && x.data <= fimPeriodo)
                    .Select(x => x.valor)
                    .DefaultIfEmpty(0)
                    .Sum();

                entradas = DadosGerais.entradas
                    .Where(x => x.data >= inicioPeriodo && x.data <= fimPeriodo)
                    .Select(x => x.valor)
                    .DefaultIfEmpty(0)
                    .Sum();
            }

            if (DadosGerais.saidas != null && DadosGerais.saidas.Count > 0)
            {
                saidas = DadosGerais.saidas
                    .Where(x => x.data >= inicioPeriodo && x.data <= fimPeriodo)
                    .Select(x => x.valorParcela)
                    .DefaultIfEmpty(0)
                    .Sum();

                dividaTotal = DadosGerais.saidas
                    .Where(x => x.tipoSaida == 0 && x.data >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1))
                    .Select(x => x.valorParcela)
                    .DefaultIfEmpty(0)
                    .Sum();
            }

            if (DadosGerais.contas != null && DadosGerais.contas.Count > 0)
            {
                saldo = DadosGerais.contas.Where(x => x.valorAtual >= 0).Select(x => x.valorAtual).Sum();
            }

            lblValorRendimentosRecentes.Text = rendimentos.ToString("C2", new CultureInfo("pt-BR"));
            lblValorEntradasRecentes.Text = entradas.ToString("C2", new CultureInfo("pt-BR"));
            lblValorSaidasRecentes.Text = saidas.ToString("C2", new CultureInfo("pt-BR"));
            lblValorDividaTotal.Text = dividaTotal.ToString("C2", new CultureInfo("pt-BR"));
            lblValorSaldoTotal.Text = saldo.ToString("C2", new CultureInfo("pt-BR"));
        }

        public void ExibirGastosPorCategoria(Panel painelDestino)
        {
            // Definir o início e o fim do período baseado nas datas selecionadas
            var inicioPeriodo = new DateTime(dtpDataInicial.Value.Year, dtpDataInicial.Value.Month, 1);
            var fimPeriodo = new DateTime(dtpDataFinal.Value.Year, dtpDataFinal.Value.Month, DateTime.DaysInMonth(dtpDataFinal.Value.Year, dtpDataFinal.Value.Month));

            // Consulta ajustada com o filtro de data
            var gastosPorCategoria = DadosGerais.saidas
                .Where(x => x.data >= inicioPeriodo && x.data <= fimPeriodo)
                        .GroupBy(x => x.chaveCategoria)
                .Select(grupo => new { chaveCategoria = grupo.Key, TotalGasto = grupo.Sum(x => x.valorParcela) })
                .Join(DadosGerais.categorias,
                      gasto => gasto.chaveCategoria,
                      categoria => categoria.chave,
                      (gasto, categoria) => new
                      {
                          Categoria = categoria.descricao,
                          TotalGasto = gasto.TotalGasto,
                          MediaMensal = gasto.TotalGasto / 12
                      })
                .ToList();

            // Limpar o painel de destino antes de adicionar novos labels
            painelDestino.Controls.Clear();

            // Configurar início do layout
            int posicaoY = 10; // Posição vertical inicial

            double total = 0;
            double totalMedia = 0;

            // Criar dinamicamente labels para exibir os dados
            foreach (var item in gastosPorCategoria)
            {
                totalMedia += item.MediaMensal;
                total += item.TotalGasto;

                Label labelCategoria = new Label
                {
                    Text = $"{item.Categoria}",
                    Location = new Point(10, posicaoY),
                    AutoSize = true
                };

                Label labelTotalGasto = new Label
                {
                    Text = $"Total Gasto: {item.TotalGasto:C}",
                    Location = new Point(200, posicaoY),
                    AutoSize = true
                };

                Label labelMediaMensal = new Label
                {
                    Text = $"Média Mensal: {item.MediaMensal:C}",
                    Location = new Point(400, posicaoY),
                    AutoSize = true
                };

                // Adicionar os labels ao painel
                painelDestino.Controls.Add(labelCategoria);
                painelDestino.Controls.Add(labelTotalGasto);
                painelDestino.Controls.Add(labelMediaMensal);

                // Incrementar a posição vertical para o próximo item
                posicaoY += 30;
            }

            Label labeltotal = new Label
            {
                Text = $"Totais",
                Location = new Point(10, posicaoY),
                AutoSize = true
            };

            Label labelTotalGeral = new Label
            {
                Text = $"Total geral: {total:C}",
                Location = new Point(200, posicaoY),
                AutoSize = true
            };

            Label labelTotalMediaMensal = new Label
            {
                Text = $"Total média: {totalMedia:C}",
                Location = new Point(400, posicaoY),
                AutoSize = true
            };

            // Adicionar os labels ao painel
            painelDestino.Controls.Add(labeltotal);
            painelDestino.Controls.Add(labelTotalGeral);
            painelDestino.Controls.Add(labelTotalMediaMensal);
        }

        private void dtpDataInicial_ValueChanged(object sender, EventArgs e)
        {
            PreencherValores();
            ExibirGastosPorCategoria(panelDadosCategorias);
        }

        private void dtpDataFinal_ValueChanged(object sender, EventArgs e)
        {
            PreencherValores();
            ExibirGastosPorCategoria(panelDadosCategorias);
        }
    }
}
