using FireSharp.Response;
using OrganizacaoFinanceira.Dados;
using OrganizacaoFinanceira.Objetos;
using OrganizacaoFinanceira.Recursos;
using OrganizacaoFinanceira.Telas;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace OrganizacaoFinanceira
{
    public partial class TelaMesesFuturo : Form
    {
        BindingSource bindingSourceLancRecorrentes = new BindingSource();
        BindingSource bindingSourceMesesFuturos = new BindingSource();
        BindingSource bindingSourceLancRecorrentesDetalhado = new BindingSource();

        LancamentoRecorrente lancRecorrenteSelecionado;

        CRUD CRUD = new CRUD();
        FuncoesGrid funcoesGrid = new();
        LayoutSplitterContainer layoutSplitter = new();

        List<Saida> saidasComSimulacao;
        List<Saida> parcelasSimulacao;

        int qtdMeses = 26;

        public TelaMesesFuturo()
        {
            InitializeComponent();
            panelLancRecorrente.BringToFront();
            LayoutColor.EstiloLayout(this);
        }

        private void TelaMesesFuturo_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            saidasComSimulacao = DadosGerais.saidas.ToList();
            parcelasSimulacao = null;

            CarregarEntradaSaidaExtra();
            CarregarSaldoCategoriasLancamentosSaida();
            InicializarLancamentosRecorrentes();
            PreencherComboBoxCategorias(ref cbxCategoriaLancRecorrente);
            PreencherComboBoxCategorias(ref cbxCategoriaSimulacao);

            funcoesGrid.AjustarTitulo(dgvLancamentosRecorrentes, lblTituloLancamentosCriados, "Lançamentos criados");
            funcoesGrid.AjustarTitulo(dgvMesesFuturos, lblTituloSaldosFuturo, "Previsão do saldo final por mês");
            funcoesGrid.AjustarTitulo(dgvLancRecorrenteDetalhado, lblLancamentoDetalhado, "Lançamentos detalhados");

            dtpMesFinal.Format = DateTimePickerFormat.Custom;
            dtpMesFinal.CustomFormat = "MM/yyyy";

            dtpMesFixo.Format = DateTimePickerFormat.Custom;
            dtpMesFixo.CustomFormat = "MM/yyyy";

            splitContainer1.SplitterWidth = 3;
            splitContainer1.Paint += (s, pe) => layoutSplitter.DesenharLinhaDivisoria(splitContainer1, pe);
            splitContainer1.Panel1.Paint += (s, pe) => layoutSplitter.PintarPainelComBordasArredondadas(splitContainer1.Panel1, pe);
            splitContainer1.Panel2.Paint += (s, pe) => layoutSplitter.PintarPainelComBordasArredondadas(splitContainer1.Panel2, pe);
            splitContainer1.MouseEnter += (s, e) => layoutSplitter.ExibirLinhaDivisoria(splitContainer1);
            splitContainer1.MouseLeave += (s, e) => layoutSplitter.DiminuirLinhaDivisoria(splitContainer1);

            splitContainer2.SplitterWidth = 3;
            splitContainer2.Paint += (s, pe) => layoutSplitter.DesenharLinhaDivisoria(splitContainer2, pe);
            splitContainer2.Panel1.Paint += (s, pe) => layoutSplitter.PintarPainelComBordasArredondadas(splitContainer2.Panel1, pe);
            splitContainer2.Panel2.Paint += (s, pe) => layoutSplitter.PintarPainelComBordasArredondadas(splitContainer2.Panel2, pe);
            splitContainer2.MouseEnter += (s, e) => layoutSplitter.ExibirLinhaDivisoria(splitContainer2);
            splitContainer2.MouseLeave += (s, e) => layoutSplitter.DiminuirLinhaDivisoria(splitContainer2);

            RedefinirTamanhoGrids();

            this.Enabled = true;
        }

        private void CarregarSaldoCategoriasLancamentosSaida()
        {
            if (DadosGerais.lancamentosRecorrentes == null || DadosGerais.saidas == null || DadosGerais.saidas.Count == 0) return;

            foreach(LancamentoRecorrente lanc in DadosGerais.lancamentosRecorrentes.Where(x=>x.tipoLancamento == 0).ToList())
            {
                lanc.saldo = lanc.valor - DadosGerais.saidas.Where(x => x.chaveCategoriaMesFuturo == lanc.chave && x.mesReferencia.Month == DateTime.Now.Month && x.mesReferencia.Year == DateTime.Now.Year).Select(x => x.valorParcela).Sum();
            }
        }

        private void CalcularMediaGastosUltimosMeses()
        {
            int chave = DadosGerais.lancamentosRecorrentes.Select(x => x.chave).Max() + 1;
            DadosGerais.lancamentosRecorrentes = new SortableBindingList<LancamentoRecorrente>();
            foreach (Categoria categoria in DadosGerais.categorias)
            {
                LancamentoRecorrente novo = new();
                novo.chaveCategoria = categoria.chave;
                novo.chave = chave;
                novo.tipoLancamento = 0;
                novo.obrigatorio = DadosGerais.lancamentosRecorrentesOriginal.Where(x => x.chaveCategoria == categoria.chave).FirstOrDefault()?.obrigatorio ?? false;
                novo.valor = CalcularMediaGastosUltimosMesesPorCategoria(categoria.chave, 12);

                DadosGerais.lancamentosRecorrentes.Add(novo);

                chave++;
            }

            foreach (LancamentoRecorrente lanc in DadosGerais.lancamentosRecorrentesOriginal)
            {
                if (lanc.tipoLancamento == 1)
                {
                    DadosGerais.lancamentosRecorrentes.Add(lanc);
                }
            }
        }

        private double CalcularMediaGastosUltimosMesesPorCategoria(int chaveCategoria, int meses)
        {
            if (meses == 0) return 0;

            var dataAtual = DateTime.Now;
            var dataInicio = dataAtual.AddMonths(-meses).AddDays(1 - dataAtual.Day); // Primeiro dia do mês, X meses atrás
            var dataFim = new DateTime(dataAtual.Year, dataAtual.Month, 1).AddDays(-1); // Último dia do mês anterior

            var gastos = DadosGerais.saidas
                .Where(x => x.chaveCategoria == chaveCategoria && x.data >= dataInicio && x.data <= dataFim)
                .Sum(x => x.valorParcela); // Soma dos gastos no período

            return gastos / meses;
        }

        private void CarregarEntradaSaidaExtra()
        {
            if (DadosGerais.calcularEntradaSaidaExtra)
            {
                DadosGerais.entradaExtra = CalcularPrevisaoEntradaExtra();
                DadosGerais.saidaExtra = CalcularPrevisaoSaidaExtra();
            }

            if (DadosGerais.entradaExtra == 0) DadosGerais.entradaExtra = 0;
            if (DadosGerais.saidaExtra == 0) DadosGerais.saidaExtra = 0;

            tbxEntradaExtra.Text = DadosGerais.entradaExtra.ToString("N2");
            tbxSaidaExtra.Text = DadosGerais.saidaExtra.ToString("N2");
        }

        private double CalcularPrevisaoEntradaExtra()
        {
            double entradasFixa = DadosGerais.lancamentosRecorrentes.Where(x => x.tipoLancamento == 1 && x.usaMesFixo && x.dataFixa.Value.Month == DateTime.Now.Month).Sum(x => x.valor);
            //double entradasRecorrentes = DadosGerais.lancamentosRecorrentes.Where(x => x.tipoLancamento == 1 && !x.usaMesFixo).Sum(x => x.valor) + entradasFixa;
            double entradasRecorrentesDetalhado = DadosGerais.lancamentosRecorrentesDetalhado.Where(x => x.tipoLancamento == 1 && x.mes == DateTime.Now.Month).Sum(x => x.valor) + entradasFixa;
            double entradasMes = DadosGerais.entradas.Where(x => x.chaveCategoria == 0 && x.mesReferencia.Month == DateTime.Now.Month && x.mesReferencia.Year == DateTime.Now.Year).Sum(x => x.valor);
            double entradaExtra = entradasRecorrentesDetalhado - entradasMes;
            return entradaExtra < 0 ? 0 : entradaExtra;
        }

        private double CalcularPrevisaoSaidaExtra()
        {
            double valorObrigatorioPrevistoCat = 0;
            double valorNaoObrigatorioPrevistoCat;
            double valorObrigatorioRegistradoCat;
            double valorNaoObrigatorioRegistradoCategoria;
            double valorExtrapoladoCategoria;
            double valorFaltaGastarCategoria;
            double valorFaltaGastar = 0;

            Mes mesCategoria;
            double saldoCategoria;

            DateTime data = DateTime.Now;

            foreach (Categoria categoria in DadosGerais.categorias)
            {
                valorObrigatorioPrevistoCat = DadosGerais.lancamentosRecorrentes.Where(x => x.tipoLancamento == 0 && x.obrigatorio && x.chaveCategoria == categoria.chave && (x.dataFinal == DateTime.MinValue || MesMenorIgual(data, x.dataFinal))).Sum(x => x.valor);
                valorObrigatorioRegistradoCat = saidasComSimulacao.Where(x => x.gastoObrigatorio && x.chaveCategoria == categoria.chave && x.mesReferencia.Month == data.Month && x.mesReferencia.Year == data.Year).Sum(x => x.valorParcela);
                valorExtrapoladoCategoria = saidasComSimulacao.Where(x => x.gastoObrigatorio && x.chaveCategoria == categoria.chave && x.mesReferencia.Month == data.Month && x.mesReferencia.Year == data.Year).Sum(x => x.valorExtrapolado);
                valorFaltaGastarCategoria = valorObrigatorioPrevistoCat - valorObrigatorioRegistradoCat + valorExtrapoladoCategoria; //Adiciona o valor extrapolado, pois ele foi considerado em valorObrigatorioRegistradoCat.

                valorNaoObrigatorioPrevistoCat = DadosGerais.lancamentosRecorrentes.Where(x => x.tipoLancamento == 0 && !x.obrigatorio && x.chaveCategoria == categoria.chave && (x.dataFinal == DateTime.MinValue || MesMenorIgual(data, x.dataFinal))).Sum(x => x.valor);
                valorNaoObrigatorioRegistradoCategoria = saidasComSimulacao.Where(x => !x.gastoObrigatorio && x.chaveCategoria == categoria.chave && x.mesReferencia.Month == data.Month && x.mesReferencia.Year == data.Year).Sum(x => x.valorParcela);
                valorFaltaGastarCategoria += Math.Max(valorNaoObrigatorioPrevistoCat - valorNaoObrigatorioRegistradoCategoria, 0);

                if (chkUsaVerba.Checked && categoria.descricao != "Poupança")
                {
                    mesCategoria = DadosGerais.meses.Where(x => x.chaveCategoria == categoria.chave && x.mes.Month == data.Month && x.mes.Year == data.Year).FirstOrDefault();
                    saldoCategoria = mesCategoria == null ? 0 : mesCategoria.saldoMes;
                    saldoCategoria = Math.Max(saldoCategoria, DadosGerais.categorias.Where(x => x.chave == categoria.chave).FirstOrDefault().saldoTotal);
                    saldoCategoria = Math.Max(saldoCategoria, 0);
                    valorFaltaGastarCategoria = Math.Max(saldoCategoria, valorFaltaGastarCategoria);
                }

                valorFaltaGastar += valorFaltaGastarCategoria;
            }
            valorFaltaGastar = valorFaltaGastar < 0 ? 0 : valorFaltaGastar;
            return valorFaltaGastar;
        }

        private double CalcularPrevisaoSaidasTotaisMes(DateTime data)
        {
            double saidatotal = 0;
            double saidasCategoria;
            double saidasMesCategoria;
            foreach (Categoria categoria in DadosGerais.categorias)
            {
                saidatotal += DadosGerais.lancamentosRecorrentes.Where(x => x.tipoLancamento == 0 && x.obrigatorio && x.chaveCategoria == categoria.chave && (x.dataFinal == DateTime.MinValue || MesMenorIgual(data, x.dataFinal))).Sum(x => x.valor);
                saidasCategoria = DadosGerais.lancamentosRecorrentes.Where(x => x.tipoLancamento == 0 && !x.obrigatorio && x.chaveCategoria == categoria.chave && (x.dataFinal == DateTime.MinValue || MesMenorIgual(data, x.dataFinal))).Sum(x => x.valor);
                saidasMesCategoria = saidasComSimulacao.Where(x => x.tipoSaida == 0 && x.chaveCategoria == categoria.chave && x.mesReferencia.Month == data.Month && x.mesReferencia.Year == data.Year).Sum(x => x.valorParcela);

                saidatotal += Math.Max(saidasCategoria, saidasMesCategoria);

            }
            return saidatotal;
        }

        private void TelaMesesFuturo_Resize(object sender, EventArgs e)
        {
            int x = (this.ClientSize.Width - panelLancRecorrente.Size.Width) / 2;
            int y = (this.ClientSize.Height - panelLancRecorrente.Size.Height) / 2;
            panelLancRecorrente.Location = new Point(x, y);

            RedefinirTamanhoGrids();
        }

        private void PreencherComboBoxCategorias(ref ComboBox combo)
        {
            combo.DataSource = null;
            combo.Items.Clear();

            if (DadosGerais.categorias != null && DadosGerais.categorias.Count > 0)
            {
                BindingList<Categoria> bindingList = new BindingList<Categoria>(DadosGerais.categorias);
                combo.DataSource = bindingList;

                combo.DisplayMember = "descricao";
                combo.ValueMember = "chave";

                combo.SelectedIndex = -1;
            }
        }

        #region LANÇAMENTOS RECORRENTES

        private void InicializarLancamentosRecorrentes()
        {
            funcoesGrid.ConfigurarGrid(dgvLancamentosRecorrentes, bindingSourceLancRecorrentes, funcoesGrid.ColunasGridLancamentosRecorrentes(), false);
            bindingSourceLancRecorrentes.DataSource = DadosGerais.lancamentosRecorrentes;
            FiltrarLancamentosRecorrentes();
        }

        private async void btnSalvarLancRecorrente_Click(object sender, EventArgs e)
        {
            LancamentoRecorrente lancRecorrenteNovo = new();
            lancRecorrenteNovo.descricao = tbxDescLancRecorrente.Text.Trim();
            lancRecorrenteNovo.valor = Convert.ToDouble(tbxValorLancRecorrente.Text);
            lancRecorrenteNovo.tipoLancamento = rbtSaidaLancRecorrente.Checked == true ? (byte)0 : (byte)1;
            if (rbtSaidaLancRecorrente.Checked) lancRecorrenteNovo.chaveCategoria = (int)cbxCategoriaLancRecorrente.SelectedValue;
            else lancRecorrenteNovo.chaveCategoria = 0;
            lancRecorrenteNovo.obrigatorio = chkLancObrigatorio.Checked;

            if (rbtSaidaLancRecorrente.Checked) lancRecorrenteNovo.dataFinal = new DateTime(dtpMesFinal.Value.Year, dtpMesFinal.Value.Month, 1);

            lancRecorrenteNovo.usaMesFixo = chkMesFixo.Checked;
            if (chkMesFixo.Checked) lancRecorrenteNovo.dataFixa = new DateTime(dtpMesFixo.Value.Year, dtpMesFixo.Value.Month, 1);

            if (tbxIdLancRecorrente.Text.Length > 0)
            {
                lancRecorrenteNovo.chave = Convert.ToInt32(tbxIdLancRecorrente.Text);
            }
            else
            {
                if (DadosGerais.lancamentosRecorrentes == null || DadosGerais.lancamentosRecorrentes.Count == 0)
                    lancRecorrenteNovo.chave = 1;
                else
                    lancRecorrenteNovo.chave = DadosGerais.lancamentosRecorrentes.Max(x => x.chave) + 1;
            }

            this.Enabled = false;
            SetResponse response = await DadosGerais.client.SetTaskAsync("LancamentosRecorrentes/" + "chave-" + lancRecorrenteNovo.chave.ToString(), lancRecorrenteNovo);
            this.Enabled = true;

            if (response.Exception == null)
            {
                MessageBox.Show("Lançamento recorrente gravado.");

                DadosGerais.lancamentosRecorrentes = await CRUD.BuscarLancamentosRecorrentes();
                FiltrarLancamentosRecorrentes();

                LimparLancamentoRecorrente();
                panelLancRecorrente.Visible = false;
            }
            else
            {
                MessageBox.Show("Erro ao gravar lançamento recorrente.\n" + response.Exception);
            }
        }

        private async Task SalvarLancamentosRecorrentesDetalhadosAsync(LancamentoRecorrenteDetalhado lancamentoDetalhado, bool mostrarMensagem)
        {
            if (lancamentoDetalhado == null)
                return;

            try
            {
                if (DadosGerais.lancamentosRecorrentesDetalhado == null || DadosGerais.lancamentosRecorrentesDetalhado.Count == 0)
                {
                    lancamentoDetalhado.chave = 1;
                }
                else
                {
                    lancamentoDetalhado.chave = DadosGerais.lancamentosRecorrentesDetalhado.Max(x => x.chave) + 1;
                }

                // Salvar o detalhe na base
                SetResponse response = await DadosGerais.client.SetTaskAsync("LancamentosRecorrentesDetalhados/" + "chave-" + lancamentoDetalhado.chave, lancamentoDetalhado);

                if (response.Exception != null)
                {
                    MessageBox.Show($"Erro ao gravar lançamento detalhado.\n{response.Exception}");
                    return; // Parar o processo em caso de erro
                }
                if (mostrarMensagem) MessageBox.Show("Lançamentos recorrentes detalhados gravados com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar lançamentos recorrentes detalhados: {ex.Message}");
            }
        }

        private async Task AtualizarLancamentosRecorrentesDetalhadosAsync(LancamentoRecorrenteDetalhado lancamentoDetalhado, bool mostrarMensagem)
        {
            if (lancamentoDetalhado == null)
                return;

            try
            {
                if (DadosGerais.lancamentosRecorrentesDetalhado == null || DadosGerais.lancamentosRecorrentesDetalhado.Count == 0)
                {
                    lancamentoDetalhado.chave = 1;
                }

                // Salvar o detalhe na base
                SetResponse response = await DadosGerais.client.SetTaskAsync("LancamentosRecorrentesDetalhados/" + "chave-" + lancamentoDetalhado.chave, lancamentoDetalhado);

                if (response.Exception != null)
                {
                    MessageBox.Show($"Erro ao atualizar lançamento detalhado.\n{response.Exception}");
                    return; // Parar o processo em caso de erro
                }
                if (mostrarMensagem) MessageBox.Show("Lançamentos recorrentes detalhados atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar lançamentos recorrentes detalhados: {ex.Message}");
            }
        }

        private async Task AtualizarLancamentosRecorrentesDetalhadosAsync(LancamentoRecorrenteDetalhado lancamentoDetalhado)
        {
            if (lancamentoDetalhado == null || lancamentoDetalhado.chave == 0)
                return;

            try
            {
                // Salvar o detalhe na base
                SetResponse response = await DadosGerais.client.SetTaskAsync("LancamentosRecorrentesDetalhados/" + "chave-" + lancamentoDetalhado.chave, lancamentoDetalhado);

                if (response.Exception != null)
                {
                    MessageBox.Show($"Erro ao atualizar lançamento detalhado.\n{response.Exception}");
                    return; // Parar o processo em caso de erro
                }
                MessageBox.Show("Lançamento recorrente detalhado atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar lançamento recorrente detalhado: {ex.Message}");
            }
        }


        private void btnNovoLancRecorrente_Click(object sender, EventArgs e)
        {
            LimparLancamentoRecorrente();
            panelLancRecorrente.Visible = true;
            int x = (this.ClientSize.Width - panelLancRecorrente.Size.Width) / 2;
            int y = (this.ClientSize.Height - panelLancRecorrente.Size.Height) / 2;
            panelLancRecorrente.Location = new Point(x, y);
        }
        private void btnLimparLancRecorrente_Click(object sender, EventArgs e)
        {
            LimparLancamentoRecorrente();
        }

        private void LimparLancamentoRecorrente()
        {
            tbxIdLancRecorrente.Text = "";
            tbxDescLancRecorrente.Text = "";
            tbxValorLancRecorrente.Text = "";
            cbxCategoriaLancRecorrente.SelectedIndex = -1;
            rbtSaidaLancRecorrente.Checked = true;
        }

        private void btnFecharLancRecorrente_Click(object sender, EventArgs e)
        {
            LimparLancamentoRecorrente();
            panelLancRecorrente.Visible = false;
        }

        private void dgvLancamentosRecorrentes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                panelLancRecorrente.Visible = true;
                int x = (this.ClientSize.Width - panelLancRecorrente.Size.Width) / 2;
                int y = (this.ClientSize.Height - panelLancRecorrente.Size.Height) / 2;
                panelLancRecorrente.Location = new Point(x, y);                

                tbxIdLancRecorrente.Text = lancRecorrenteSelecionado.chave.ToString();
                tbxDescLancRecorrente.Text = lancRecorrenteSelecionado.descricao.ToString();
                tbxValorLancRecorrente.Text = lancRecorrenteSelecionado.valor.ToString();
                rbtSaidaLancRecorrente.Checked = lancRecorrenteSelecionado.tipoLancamento == 0 ? true : false;
                rbtEntradaLancRecorrente.Checked = lancRecorrenteSelecionado.tipoLancamento == 0 ? false : true;
                cbxCategoriaLancRecorrente.SelectedValue = lancRecorrenteSelecionado.chaveCategoria;
                chkLancObrigatorio.Checked = lancRecorrenteSelecionado.obrigatorio;
                chkMesFixo.Checked = lancRecorrenteSelecionado.usaMesFixo;
                dtpMesFinal.Value = lancRecorrenteSelecionado.dataFinal;
            }
        }

        private void dgvLancamentosRecorrentes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLancamentosRecorrentes.SelectedCells.Count > 0)
            {
                int rowIndex = dgvLancamentosRecorrentes.SelectedCells[0].RowIndex;

                if (rowIndex >= 0 && rowIndex < dgvLancamentosRecorrentes.Rows.Count)
                {
                    lancRecorrenteSelecionado = dgvLancamentosRecorrentes.Rows[rowIndex].DataBoundItem as LancamentoRecorrente;
                }
            }
            else
                lancRecorrenteSelecionado = null;

            FiltrarLancamentosRecorrentesDetalhado();
        }

        private void FiltrarLancamentosRecorrentesDetalhado()
        {
            if (lancRecorrenteSelecionado == null || DadosGerais.lancamentosRecorrentesDetalhado == null || lancRecorrenteSelecionado.tipoLancamento == 0)
            {
                // Limpar o grid de detalhes
                bindingSourceLancRecorrentesDetalhado.DataSource = new SortableBindingList<LancamentoRecorrenteDetalhado>();
                funcoesGrid.ConfigurarGrid(dgvLancRecorrenteDetalhado, bindingSourceLancRecorrentesDetalhado, funcoesGrid.ColunasGridLancamentosRecorrentesDetalhado(), false);
                dgvLancRecorrenteDetalhado.Columns[1].ReadOnly = false;
                return;
            }

            var detalhesExistentes = DadosGerais.lancamentosRecorrentesDetalhado.Where(x => x.chaveLancRecorrente == lancRecorrenteSelecionado.chave).OrderBy(x => x.mes).ToList();

            // Preencher o grid com os detalhes
            SortableBindingList<LancamentoRecorrenteDetalhado> detalhesParaExibir = new(detalhesExistentes);
            funcoesGrid.ConfigurarGrid(dgvLancRecorrenteDetalhado, bindingSourceLancRecorrentesDetalhado, funcoesGrid.ColunasGridLancamentosRecorrentesDetalhado(), false);
            dgvLancRecorrenteDetalhado.Columns[1].ReadOnly = false;
            bindingSourceLancRecorrentesDetalhado.DataSource = detalhesParaExibir;
        }

        private async void GerarLancamentosRecorrentesDetalhado()
        {
            if (lancRecorrenteSelecionado == null || DadosGerais.lancamentosRecorrentesDetalhado == null || lancRecorrenteSelecionado.tipoLancamento == 0 || lancRecorrenteSelecionado.usaMesFixo)
            {
                // Limpar o grid de detalhes
                bindingSourceLancRecorrentesDetalhado.DataSource = new SortableBindingList<LancamentoRecorrenteDetalhado>();
                funcoesGrid.ConfigurarGrid(dgvLancRecorrenteDetalhado, bindingSourceLancRecorrentesDetalhado, funcoesGrid.ColunasGridLancamentosRecorrentesDetalhado(), false);
                dgvLancRecorrenteDetalhado.Columns[1].ReadOnly = false;
                return;
            }

            var detalhesExistentes = DadosGerais.lancamentosRecorrentesDetalhado.Where(x => x.chaveLancRecorrente == lancRecorrenteSelecionado.chave).ToList();

            // Verificar se já há detalhes
            if (!detalhesExistentes.Any())
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                // Caso não haja detalhes, criar novos registros
                for (byte i = 1; i < 13; i++)
                {
                    if (lancRecorrenteSelecionado.tipoLancamento == 0) return;
                    var novoDetalhe = new LancamentoRecorrenteDetalhado
                    {
                        chaveLancRecorrente = lancRecorrenteSelecionado.chave,
                        descricao = lancRecorrenteSelecionado.descricao,
                        valor = lancRecorrenteSelecionado.valor,
                        tipoLancamento = lancRecorrenteSelecionado.tipoLancamento,
                        mes = i
                    };
                    await SalvarLancamentosRecorrentesDetalhadosAsync(novoDetalhe, false);
                    DadosGerais.lancamentosRecorrentesDetalhado.Add(novoDetalhe);
                }

                // Atualizar os detalhes existentes com os novos
                detalhesExistentes = DadosGerais.lancamentosRecorrentesDetalhado.Where(x => x.chaveLancRecorrente == lancRecorrenteSelecionado.chave).ToList();
                this.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            else
            {
                DialogResult result = MessageBox.Show("Já existe o lançamento detalhado. Tem certeza que deseja substituí-lo?",
                                                          "Atualizar lançamento detalhado",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;

                    // Caso não haja detalhes, criar novos registros
                    for (byte i = 1; i < 13; i++)
                    {
                        if (lancRecorrenteSelecionado.tipoLancamento == 0) return;
                        var detalhe = detalhesExistentes.Where(x=>x.mes == i).FirstOrDefault();
                        detalhe.valor = lancRecorrenteSelecionado.valor;

                        await AtualizarLancamentosRecorrentesDetalhadosAsync(detalhe, false);
                    }

                    this.Enabled = true;
                    this.Cursor = Cursors.Default;
                }

            }

            // Preencher o grid com os detalhes
            SortableBindingList<LancamentoRecorrenteDetalhado> detalhesParaExibir = new(detalhesExistentes);
            funcoesGrid.ConfigurarGrid(dgvLancRecorrenteDetalhado, bindingSourceLancRecorrentesDetalhado, funcoesGrid.ColunasGridLancamentosRecorrentesDetalhado(), false);
            dgvLancRecorrenteDetalhado.Columns[1].ReadOnly = false;
            bindingSourceLancRecorrentesDetalhado.DataSource = detalhesParaExibir;

            CarregarEntradaSaidaExtra();
            CarregarSaldoCategoriasLancamentosSaida();
            InicializarLancamentosRecorrentes();
            InicializarMesesFuturos();
        }

        private void dgvLancamentosRecorrentes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLancamentosRecorrentes.Columns[e.ColumnIndex].DataPropertyName == "chaveCategoria" && e.Value != null)
            {
                string descricao = "";
                int chave = (int)e.Value;
                if (DadosGerais.lancamentosRecorrentes != null) descricao = DadosGerais.categorias.Where(x => x.chave == chave).Select(x => x.descricao).FirstOrDefault();
                e.Value = descricao == null ? "" : descricao;

                // Define o formato de exibição da célula como texto
                e.FormattingApplied = true;
            }

            if (dgvLancamentosRecorrentes.Columns[e.ColumnIndex].DataPropertyName == "tipoLancamento" && e.Value != null)
            {
                e.Value = (byte)e.Value == 0 ? "Saída" : "Entrada";
                e.FormattingApplied = true;
            }

            if (dgvLancamentosRecorrentes.Columns[e.ColumnIndex].DataPropertyName == "obrigatorio" && e.Value != null)
            {
                e.Value = (bool)e.Value ? "Sim" : "Não";
                e.FormattingApplied = true;
            }

            if (dgvLancamentosRecorrentes.Columns[e.ColumnIndex].DataPropertyName == "usaMesFixo")
            {
                if (e.Value == null)
                {
                    e.Value = "Não";
                    return;
                }
                e.Value = (bool)e.Value ? "Sim" : "Não";
                e.FormattingApplied = true;
            }

            if (dgvLancamentosRecorrentes.Columns[e.ColumnIndex].DataPropertyName == "dataFixa" && e.Value != null)
            {
                // Verificar se o valor não é nulo e é uma data
                if (e.Value is DateTime dataFixa)
                {
                    // Alterar o valor da célula para o nome do mês
                    e.Value = dataFixa.ToString("MMMM"); // "MMMM" retorna o nome completo do mês
                    e.FormattingApplied = true;
                }
            }

            if (dgvLancamentosRecorrentes.Columns[e.ColumnIndex].DataPropertyName == "dataFinal" && e.Value != null)
            {
                // Verificar se o valor é uma data e não é a data mínima
                if (e.Value is DateTime dataFinal)
                {
                    // Se for a data mínima, não exibe nada
                    if (dataFinal == DateTime.MinValue)
                    {
                        e.Value = string.Empty; // Não mostrar nada
                    }
                    else
                    {
                        // Alterar o valor da célula para o formato MM/yyyy
                        e.Value = dataFinal.ToString("MM/yyyy");
                    }
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgvLancRecorrenteDetalhado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLancRecorrenteDetalhado.Columns[e.ColumnIndex].DataPropertyName == "tipoLancamento" && e.Value != null)
            {
                e.Value = (byte)e.Value == 0 ? "Saída" : "Entrada";
                e.FormattingApplied = true;
            }

            if (dgvLancRecorrenteDetalhado.Columns[e.ColumnIndex].DataPropertyName == "mes" && e.Value != null)
            {
                // Verificar se o valor não é nulo e é um byte
                if (e.Value is byte mes && mes >= 1 && mes <= 12)
                {
                    // Obter o nome do mês correspondente
                    string[] nomesMeses =
                    {
                        "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho",
                        "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"
                    };

                    e.Value = nomesMeses[mes - 1]; // Ajustar índice para base 0
                    e.FormattingApplied = true;
                }
            }
        }

        private void rbtFiltroSaidaLancRecorrente_CheckedChanged(object sender, EventArgs e)
        {
            FiltrarLancamentosRecorrentes(false);
            funcoesGrid.ReajustarTamanhoTitulo(dgvLancamentosRecorrentes, lblTituloLancamentosCriados);
        }

        private void FiltrarLancamentosRecorrentes(bool recarregar = true)
        {
            if (DadosGerais.lancamentosRecorrentes == null) return;
            SortableBindingList<LancamentoRecorrente> lancamentosFiltro = new(DadosGerais.lancamentosRecorrentes.Where(x => x.tipoLancamento == (rbtFiltroSaidaLancRecorrente.Checked ? 0 : 1)).ToList());
            bindingSourceLancRecorrentes.DataSource = lancamentosFiltro;
            if (recarregar) InicializarMesesFuturos();

            dgvLancamentosRecorrentes.Columns[2].Visible = rbtFiltroSaidaLancRecorrente.Checked;
            dgvLancamentosRecorrentes.Columns[3].Visible = rbtFiltroSaidaLancRecorrente.Checked;
            dgvLancamentosRecorrentes.Columns[5].Visible = rbtFiltroSaidaLancRecorrente.Checked;
            dgvLancamentosRecorrentes.Columns[8].Visible = rbtFiltroSaidaLancRecorrente.Checked;

            dgvLancamentosRecorrentes.Columns[6].Visible = !rbtFiltroSaidaLancRecorrente.Checked;
            dgvLancamentosRecorrentes.Columns[7].Visible = !rbtFiltroSaidaLancRecorrente.Checked;
        }

        #endregion

        #region MESES FUTUROS

        private void InicializarMesesFuturos(List<Saida> parcelasSimuladas = null)
        {
            DadosGerais.mesesFuturos = new();

            double saidasMesAtual = saidasComSimulacao.Where(x => x.tipoSaida == 0 && x.mesReferencia.Month == DateTime.Now.Month && x.mesReferencia.Year == DateTime.Now.Year).Sum(x => x.valorParcela);
            double valorAtualContas = DadosGerais.contas.Sum(x => x.valorAtual);

            valorAtualContas += Convert.ToDouble(tbxEntradaExtra.Text) - Convert.ToDouble(tbxSaidaExtra.Text);
            valorAtualContas -= saidasMesAtual;

            MesFuturo primeiroMes = new MesFuturo();
            primeiroMes.mes = DateTime.Now;
            primeiroMes.saldoGeral = valorAtualContas;
            primeiroMes.entradasTotais = DadosGerais.entradas.Where(x => x.mesReferencia.Month == DateTime.Now.Month && x.mesReferencia.Year == DateTime.Now.Year).Sum(x => x.valor) + Convert.ToDouble(tbxEntradaExtra.Text);
            primeiroMes.saidasTotais = saidasMesAtual + Convert.ToDouble(tbxSaidaExtra.Text);
            primeiroMes.saidasParceladas = saidasComSimulacao.Where(x => x.qtdParcelas > 1 && x.mesReferencia.Month == DateTime.Now.Month && x.mesReferencia.Year == DateTime.Now.Year).Sum(x => x.valorParcela);

            double saidasParceladas;
            double entradasMes;
            for (int i = 0; i < qtdMeses - 1; i++)
            {
                DadosGerais.mesesFuturos.Add(new MesFuturo());
                DadosGerais.mesesFuturos[i].mes = DateTime.Now.AddMonths(i + 1).Date;

                saidasParceladas = 0;
                entradasMes = 0;

                if (saidasComSimulacao != null && saidasComSimulacao.Count > 0)
                {
                    saidasParceladas = saidasComSimulacao.Where(x => x.qtdParcelas > 1 && x.mesReferencia.Month == DadosGerais.mesesFuturos[i].mes.Month && x.mesReferencia.Year == DadosGerais.mesesFuturos[i].mes.Year).Sum(x => x.valorParcela);
                }

                if (DadosGerais.entradas != null && DadosGerais.entradas.Count > 0)
                {
                    entradasMes = DadosGerais.entradas.Where(x => x.mesReferencia.Month == DadosGerais.mesesFuturos[i].mes.Month && x.mesReferencia.Year == DadosGerais.mesesFuturos[i].mes.Year).Sum(x => x.valor);
                }

                double saidatotal = CalcularPrevisaoSaidasTotaisMes(DadosGerais.mesesFuturos[i].mes);
                double valorFixo = DadosGerais.lancamentosRecorrentes.Where(x => x.tipoLancamento == 1 && x.usaMesFixo && x.dataFixa.Value.Month == DadosGerais.mesesFuturos[i].mes.Month).Sum(x => x.valor);
                double entradasTotaisRecorrente = DadosGerais.lancamentosRecorrentesDetalhado.Where(x => x.tipoLancamento == 1 && x.mes == DadosGerais.mesesFuturos[i].mes.Month).Sum(x => x.valor);
                double entradasRecorrentes = entradasTotaisRecorrente + valorFixo;

                DadosGerais.mesesFuturos[i].saidasTotais = saidatotal;
                DadosGerais.mesesFuturos[i].entradasTotais = Math.Max(entradasRecorrentes, entradasMes);
                DadosGerais.mesesFuturos[i].saidasParceladas = saidasParceladas;
                DadosGerais.mesesFuturos[i].saldoGeral = valorAtualContas + DadosGerais.mesesFuturos[i].entradasTotais - saidatotal;
                valorAtualContas = DadosGerais.mesesFuturos[i].saldoGeral;
            }

            DadosGerais.mesesFuturos.Insert(0, primeiroMes);

            funcoesGrid.ConfigurarGrid(dgvMesesFuturos, bindingSourceMesesFuturos, funcoesGrid.ColunasGridMesesFuturos(), false);
            bindingSourceMesesFuturos.DataSource = DadosGerais.mesesFuturos;
        }

        private bool MesMenorIgual(DateTime mes1, DateTime mes2)
        {
            DateTime data1 = new DateTime(mes1.Year, mes1.Month, 1);
            DateTime data2 = new DateTime(mes2.Year, mes2.Month, 1);

            return data1 <= data2;
        }

        private void dgvMesesFuturos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMesesFuturos.Columns[e.ColumnIndex].DataPropertyName == "mes" &&
                e.Value != null && e.Value is DateTime)
            {
                DateTime dateValue = (DateTime)e.Value;
                e.Value = dateValue.ToString("MMM/yyyy");
                e.FormattingApplied = true;
            }

            if (dgvMesesFuturos.Columns[e.ColumnIndex].DataPropertyName == "saldoGeral" && e.Value != null && e.Value is double)
            {
                double saldo = (double)e.Value;
                if (saldo < 0)
                {
                    e.CellStyle.ForeColor = LayoutColor.corValorNegativo;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = dgvMesesFuturos.DefaultCellStyle.ForeColor;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
                }
            }
        }

        private async void dgvLancamentosRecorrentes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dgvLancamentosRecorrentes.SelectedRows.Count > 0)
                {
                    LancamentoRecorrente lancRecorrenteSelecionado = dgvLancamentosRecorrentes.SelectedRows[0].DataBoundItem as LancamentoRecorrente;

                    DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este lançamento recorrente?",
                                                          "Excluir lançamento recorrente",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        this.Enabled = false;
                        FirebaseResponse response = await DadosGerais.client.DeleteTaskAsync("LancamentosRecorrentes/" + "chave-" + lancRecorrenteSelecionado.chave);
                        this.Enabled = true;

                        if (response.Exception == null)
                        {
                            MessageBox.Show("Lançamento recorrente excluído com sucesso.");

                            DadosGerais.lancamentosRecorrentes = await CRUD.BuscarLancamentosRecorrentes();
                            FiltrarLancamentosRecorrentes();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao excluir a lançamento recorrente.");
                        }
                    }
                }
            }
        }

        #endregion


        private void lançamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.telaPrincipal.Show();
            this.Close();
        }

        private void tbxEntradaExtra_Validated(object sender, EventArgs e)
        {
            if (tbxEntradaExtra.Text.Length == 0) tbxEntradaExtra.Text = "0";
        }

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            InicializarMesesFuturos();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.telaCategorias = new();
            Formularios.telaCategorias.WindowState = this.WindowState;
            Formularios.telaCategorias.Show();
            this.Hide();
        }

        private void tbxEntradaExtra_TextChanged(object sender, EventArgs e)
        {
            if (tbxEntradaExtra.Text.Length == 0) return;
            DadosGerais.entradaExtra = (!string.IsNullOrWhiteSpace(tbxEntradaExtra.Text)) ? Convert.ToDouble(tbxEntradaExtra.Text) : 0;
            DadosGerais.calcularEntradaSaidaExtra = false;
        }

        private void tbxSaidaExtra_TextChanged(object sender, EventArgs e)
        {
            if (tbxSaidaExtra.Text.Length == 0) return;
            DadosGerais.saidaExtra = (!string.IsNullOrWhiteSpace(tbxSaidaExtra.Text)) ? Convert.ToDouble(tbxSaidaExtra.Text) : 0;
            DadosGerais.calcularEntradaSaidaExtra = false;
        }

        private void tbxSaidaExtra_Validated(object sender, EventArgs e)
        {
            if (tbxSaidaExtra.Text.Length == 0) tbxSaidaExtra.Text = "0";
        }

        private void TelaMesesFuturo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Formularios.telaPrincipal.Show();
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            saidasComSimulacao = DadosGerais.saidas.ToList();
            parcelasSimulacao = new();
            int qtdParcelas = 0; // Valor padrão

            // Verificar se o campo de texto não está vazio
            if (!string.IsNullOrWhiteSpace(tbxQtdParcelas.Text))
            {
                qtdParcelas = Convert.ToInt16(tbxQtdParcelas.Text);
            }

            int categoria = (int)cbxCategoriaSimulacao.SelectedValue;
            DateTime data = dtpDataInicialParcela.Value.Date;
            for (int i = 0; i < qtdParcelas; i++)
            {
                Saida parc = new Saida();
                parc.tipoSaida = 0;
                parc.valorParcela = !string.IsNullOrWhiteSpace(tbxValorMensal.Text) ? Convert.ToDouble(tbxValorMensal.Text) : 0;
                parc.parcela = i + 1;
                parc.dataInicio = dtpDataInicialParcela.Value.Date;
                parc.qtdParcelas = qtdParcelas;
                parc.mesReferencia = data;
                parc.chaveCategoria = categoria;
                data = data.AddMonths(1);

                parcelasSimulacao.Add(parc);
            }
            saidasComSimulacao.AddRange(parcelasSimulacao);
            CarregarEntradaSaidaExtra();
            InicializarMesesFuturos();
        }

        private void dgvLancamentosRecorrentes_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            funcoesGrid.ReajustarTamanhoTitulo(dgvLancamentosRecorrentes, lblTituloLancamentosCriados);
        }

        private void dgvMesesFuturos_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            funcoesGrid.ReajustarTamanhoTitulo(dgvMesesFuturos, lblTituloSaldosFuturo);
        }

        private void rbtEntradaLancRecorrente_CheckedChanged(object sender, EventArgs e)
        {
            lblMesFinal.Enabled = !rbtEntradaLancRecorrente.Checked;
            dtpMesFinal.Enabled = !rbtEntradaLancRecorrente.Checked;

            lblMesFixo.Enabled = rbtEntradaLancRecorrente.Checked;
            dtpMesFixo.Enabled = rbtEntradaLancRecorrente.Checked;

            lblCategoria.Enabled = !rbtEntradaLancRecorrente.Checked;
            cbxCategoriaLancRecorrente.Enabled = !rbtEntradaLancRecorrente.Checked;
            chkLancObrigatorio.Enabled = !rbtEntradaLancRecorrente.Checked;
        }

        private void tbxEntradaExtra_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificar se a tecla pressionada foi Enter (código 13)
            if (e.KeyCode == Keys.Enter)
            {
                // Chama o método de ação quando o Enter for pressionado
                InicializarMesesFuturos();
            }
        }

        private void tbxSaidaExtra_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificar se a tecla pressionada foi Enter (código 13)
            if (e.KeyCode == Keys.Enter)
            {
                // Chama o método de ação quando o Enter for pressionado
                InicializarMesesFuturos();
            }
        }

        private void RedefinirTamanhoGrids()
        {
            int topGrid = 85;
            int distanciaGrid = 25;

            dgvLancamentosRecorrentes.Top = topGrid;
            dgvLancamentosRecorrentes.Width = dgvLancamentosRecorrentes.Parent.Width - dgvLancamentosRecorrentes.Left - distanciaGrid;
            dgvLancamentosRecorrentes.Height = dgvLancamentosRecorrentes.Parent.Height - dgvLancamentosRecorrentes.Top - distanciaGrid;
            funcoesGrid.ReajustarTamanhoTitulo(dgvLancamentosRecorrentes, lblTituloLancamentosCriados);
            lblTituloLancamentosCriados.Top = dgvLancamentosRecorrentes.Top - lblTituloLancamentosCriados.Height;
            panelLancaRecorrentes.Top = dgvLancamentosRecorrentes.Top - lblTituloLancamentosCriados.Height - panelLancaRecorrentes.Height;

            dgvLancRecorrenteDetalhado.Top = topGrid;
            dgvLancRecorrenteDetalhado.Width = dgvLancRecorrenteDetalhado.Parent.Width - dgvLancRecorrenteDetalhado.Left - distanciaGrid;
            dgvLancRecorrenteDetalhado.Height = dgvLancRecorrenteDetalhado.Parent.Height - dgvLancRecorrenteDetalhado.Top - distanciaGrid;
            funcoesGrid.ReajustarTamanhoTitulo(dgvLancRecorrenteDetalhado, lblLancamentoDetalhado);
            lblLancamentoDetalhado.Top = dgvLancRecorrenteDetalhado.Top - lblLancamentoDetalhado.Height;

            dgvMesesFuturos.Top = topGrid + panelSimularParcelamento.Top + panelSimularParcelamento.Height;
            dgvMesesFuturos.Width = dgvMesesFuturos.Parent.Width - dgvMesesFuturos.Left - distanciaGrid;
            dgvMesesFuturos.Height = dgvMesesFuturos.Parent.Height - dgvMesesFuturos.Top - distanciaGrid;
            funcoesGrid.ReajustarTamanhoTitulo(dgvMesesFuturos, lblTituloSaldosFuturo);
            lblTituloSaldosFuturo.Top = dgvMesesFuturos.Top - lblTituloSaldosFuturo.Height;
            panelEntradaSaidaExtra.Top = dgvMesesFuturos.Top - lblTituloSaldosFuturo.Height - panelEntradaSaidaExtra.Height;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            RedefinirTamanhoGrids();
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            RedefinirTamanhoGrids();
        }

        private void btnGerarDetalhes_Click(object sender, EventArgs e)
        {
            GerarLancamentosRecorrentesDetalhado();
        }

        private void dgvLancRecorrenteDetalhado_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Verificar se a coluna é a que precisa de validação
            if (dgvLancRecorrenteDetalhado.Columns[e.ColumnIndex].DataPropertyName == "valor")
            {
                string valor = e.FormattedValue.ToString();

                // Tentar converter para double
                if (!double.TryParse(valor, out _))
                {
                    // Mostrar mensagem de erro e cancelar a edição
                    MessageBox.Show("Insira um valor numérico válido.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    e.Cancel = true; // Impede que o foco saia da célula até corrigir
                }
            }
        }

        private async void dgvLancRecorrenteDetalhado_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar se a célula alterada é da coluna que queremos monitorar
            if (dgvLancRecorrenteDetalhado.Columns[e.ColumnIndex].DataPropertyName == "valor")
            {
                // Obter o objeto que foi alterado (linha)
                var linha = dgvLancRecorrenteDetalhado.Rows[e.RowIndex];
                var objetoAlterado = linha.DataBoundItem as LancamentoRecorrenteDetalhado;

                if (objetoAlterado != null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.Enabled = false;
                    await AtualizarLancamentosRecorrentesDetalhadosAsync(objetoAlterado);
                    CarregarEntradaSaidaExtra();
                    InicializarMesesFuturos();
                    this.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void chkUsaVerba_CheckedChanged(object sender, EventArgs e)
        {
            CarregarEntradaSaidaExtra();
            InicializarMesesFuturos();
        }

        private void chkUsarMediaVerbas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUsarMediaVerbas.Checked)
            {
                CalcularMediaGastosUltimosMeses();
            }
            else
            {
                DadosGerais.lancamentosRecorrentes = new SortableBindingList<LancamentoRecorrente>(DadosGerais.lancamentosRecorrentesOriginal);
            }

            CarregarEntradaSaidaExtra();
            InicializarMesesFuturos();
        }
    }
}
