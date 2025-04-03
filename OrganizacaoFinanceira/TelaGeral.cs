using OrganizacaoFinanceira.Dados;
using OrganizacaoFinanceira.Objetos;
using OrganizacaoFinanceira.Recursos;
using OrganizacaoFinanceira.Telas;
using System.Globalization;

namespace OrganizacaoFinanceira
{
    public partial class TelaGeral : Form
    {
        bool jaPodePreencherValores = false;
        public TelaGeral()
        {
            InitializeComponent();
            LayoutColor.EstiloLayout(this);
        }

        private void TelaGeral_Load(object sender, EventArgs e)
        {
            jaPodePreencherValores = false;
            ConfigurarPeriodo();

            lblValorRendimentosRecentes.ForeColor = Color.FromArgb(181, 230, 29);
            lblValorEntradasRecentes.ForeColor = Color.FromArgb(181, 230, 29);
            lblValorSaidasRecentes.ForeColor = Color.FromArgb(181, 230, 29);
            lblValorDividaTotal.ForeColor = Color.FromArgb(181, 230, 29);
            lblValorSaldoTotal.ForeColor = Color.FromArgb(181, 230, 29);
            lblSaldoTotalComCreditoAtual.ForeColor = Color.FromArgb(181, 230, 29);

            lblValorRendimentosRecentes.Font = new Font("Arial", 16, FontStyle.Bold);
            lblValorEntradasRecentes.Font = new Font("Arial", 16, FontStyle.Bold);
            lblValorSaidasRecentes.Font = new Font("Arial", 16, FontStyle.Bold);
            lblValorDividaTotal.Font = new Font("Arial", 16, FontStyle.Bold);
            lblValorSaldoTotal.Font = new Font("Arial", 16, FontStyle.Bold);
            lblSaldoTotalComCreditoAtual.Font = new Font("Arial", 16, FontStyle.Bold);

            jaPodePreencherValores = true;
            PreencherValores();
            ExibirGastosPorCategoria(panelDadosCategorias);
        }

        private void ConfigurarPeriodo()
        {
            // Configurar o DateTimePicker para exibir apenas meses
            dtpDataInicial.Format = DateTimePickerFormat.Custom;
            dtpDataInicial.CustomFormat = "MM/yyyy"; // Exibir mês e ano
            //dtpDataInicial.ShowUpDown = true; // Mostra botões de incremento

            dtpDataFinal.Format = DateTimePickerFormat.Custom;
            dtpDataFinal.CustomFormat = "MM/yyyy"; // Exibir mês e ano
            //dtpDataFinal.ShowUpDown = true; // Mostra botões de incremento

            // Definir período inicial de 12 meses
            dtpDataInicial.Value = new DateTime(DateTime.Now.AddMonths(-12).Year, DateTime.Now.AddMonths(-12).Month, 1);
            dtpDataFinal.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private void PreencherValores()
        {
            if (!jaPodePreencherValores) return;

            double rendimentos = 0;
            double entradas = 0;
            double saidas = 0;
            double dividaTotal = 0;
            double creditoMes = 0;
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

                creditoMes = DadosGerais.saidas
                    .Where(x => x.tipoSaida == 0 && x.mesReferencia.Month == DateTime.Now.Date.Month && x.mesReferencia.Year == DateTime.Now.Date.Year)
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
            lblSaldoTotalComCreditoAtual.Text = (saldo-creditoMes).ToString("C2", new CultureInfo("pt-BR"));
        }

        private int CalcularQuantidadeDeMeses(DateTime dataInicial, DateTime dataFinal)
        {
            // Calcula a diferença em anos e meses
            int anos = dataFinal.Year - dataInicial.Year;
            int meses = dataFinal.Month - dataInicial.Month;

            // Soma a diferença total em meses
            return (anos * 12) + meses;
        }


        public void ExibirGastosPorCategoria(Panel painelDestino)
        {
            if (!jaPodePreencherValores) return;

            // Definir o início e o fim do período baseado nas datas selecionadas
            var inicioPeriodo = new DateTime(dtpDataInicial.Value.Year, dtpDataInicial.Value.Month, 1);
            var fimPeriodo = new DateTime(dtpDataFinal.Value.Year, dtpDataFinal.Value.Month, DateTime.DaysInMonth(dtpDataFinal.Value.Year, dtpDataFinal.Value.Month));
            int quantidadeMeses = ((fimPeriodo.Year - inicioPeriodo.Year) * 12) + fimPeriodo.Month - inicioPeriodo.Month + 1;

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
                          MediaMensal = gasto.TotalGasto / quantidadeMeses,
                          ChaveCategoria = categoria.chave,
                      })
                .ToList();

            // Limpar o painel de destino antes de adicionar novos labels
            painelDestino.Controls.Clear();

            // Configurar início do layout
            int posicaoY = 50; // Posição vertical inicial
            int incrementoVertical = 30; // Espaçamento entre linhas
            int margemInferior = 20; // Margem adicional para ajustar o tamanho do painel

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

                Label labelSaldoPeriodo = new Label();

                if (item.Categoria == "Sarah")
                {
                    labelSaldoPeriodo = CalcularSaldoSarah(item, inicioPeriodo, fimPeriodo, posicaoY);                    
                }

                // Adicionar os labels ao painel
                painelDestino.Controls.Add(labelCategoria);
                painelDestino.Controls.Add(labelTotalGasto);
                painelDestino.Controls.Add(labelMediaMensal);
                painelDestino.Controls.Add(labelSaldoPeriodo);

                // Incrementar a posição vertical para o próximo item
                posicaoY += incrementoVertical;
            }

            // Adicionar labels de totais
            Label labelTotal = new Label
            {
                Text = $"Totais",
                Location = new Point(10, posicaoY),
                AutoSize = true
            };

            Label labelTotalGeral = new Label
            {
                Text = $"{total:C}",
                Location = new Point(200, posicaoY),
                AutoSize = true
            };

            Label labelTotalMediaMensal = new Label
            {
                Text = $"{totalMedia:C}",
                Location = new Point(400, posicaoY),
                AutoSize = true
            };

            // Definir cores
            labelTotal.ForeColor = Color.FromArgb(181, 230, 29);
            labelTotalGeral.ForeColor = Color.FromArgb(181, 230, 29);
            labelTotalMediaMensal.ForeColor = Color.FromArgb(181, 230, 29);

            // Adicionar labels ao painel
            painelDestino.Controls.Add(labelTotal);
            painelDestino.Controls.Add(labelTotalGeral);
            painelDestino.Controls.Add(labelTotalMediaMensal);

            // Ajustar a altura do painel com base na última posição Y
            painelDestino.Height = posicaoY + incrementoVertical + margemInferior;
            painelDestino.Width += 100;

            Label lblTituloDadosCategoria = new Label();
            lblTituloDadosCategoria.Text = "Dados por categoria no período";
            lblTituloDadosCategoria.Width = 300;
            lblTituloDadosCategoria.Left = painelDestino.Width/2 - lblTituloDadosCategoria.Width/2;
            lblTituloDadosCategoria.Top = 10; 
            lblTituloDadosCategoria.Font = new Font("Arial", 12, FontStyle.Bold);
            painelDestino.Controls.Add(lblTituloDadosCategoria);
        }

        private Label CalcularSaldoSarah(dynamic item, DateTime inicioPeriodo, DateTime fimPeriodo, int posicaoY)
        {
            double verba = DadosGerais.lancamentosRecorrentes.Where(x => x.tipoLancamento == 0 && x.chaveCategoria == item.ChaveCategoria).Select(x => x.valor).DefaultIfEmpty(0).FirstOrDefault();

            //Obtem toda a verba no periodo, se o periodo for além do mês atual, não deve considerar a verba dos próximos meses, pois não é garantia de te-las.
            double verbaTotalPeriodo = DadosGerais.meses.Where(x => x.chaveCategoria == item.ChaveCategoria && x.mes >= inicioPeriodo && x.mes <= fimPeriodo && x.mes <= DateTime.Now)
                                                        .Select(x => x.verbaMes)
                                                        .DefaultIfEmpty(0)
                                                        .Sum();

            //Calcular a verba dos proximos meses até o fimPeriodo
            int proximosMeses = CalcularQuantidadeDeMeses(DateTime.Now, fimPeriodo); //exemplo
            double verbaFutura = verba * proximosMeses;
            verbaTotalPeriodo += verbaFutura;

            double gastoTotalPeriodo = DadosGerais.saidas.Where(x => x.chaveCategoria == item.ChaveCategoria && x.data >= inicioPeriodo && x.data <= fimPeriodo)
                                                         .Select(x => x.valorParcela)
                                                         .DefaultIfEmpty(0)
                                                         .Sum();

            double saldoPeriodo = verbaTotalPeriodo - gastoTotalPeriodo;

            Label labelSaldoPeriodo = new Label
            {
                Text = $"Saldo no período: {saldoPeriodo:C}",
                Location = new Point(600, posicaoY),
                AutoSize = true
            };

            return labelSaldoPeriodo;
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

        private void TelaGeral_Resize(object sender, EventArgs e)
        {
            panelPeriodo.Width = this.Width - panelPeriodo.Left * 2;
            panelPeriodo.Height = this.Height - panelPeriodo.Top - 10;
        }
    }
}
