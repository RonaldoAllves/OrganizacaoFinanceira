﻿using FireSharp.Response;
using OrganizacaoFinanceira.Dados;
using OrganizacaoFinanceira.Objetos;
using OrganizacaoFinanceira.Recursos;
using OrganizacaoFinanceira.Telas;
using System.Data;
using System.Windows.Forms;

namespace OrganizacaoFinanceira
{
    public partial class TelaCategorias : Form
    {
        CRUD CRUD = new CRUD();
        FuncoesGrid funcoesGrid = new();
        LayoutSplitterContainer layoutSplitter = new LayoutSplitterContainer();

        BindingSource bindingSourceCategorias = new BindingSource();
        BindingSource bindingSourceMeses = new BindingSource();
        BindingSource bindingSourceVerbasCategorias = new BindingSource();
        BindingSource bindingSourceSaidas = new BindingSource();

        Categoria categoriaSelecionada;
        Mes mesSelecionado;

        SortableBindingList<Mes> mesesDaCategoria;

        public TelaCategorias()
        {
            InitializeComponent();

            LayoutColor.EstiloLayout(this);
        }

        private void TelaCategorias_Load(object sender, EventArgs e)
        {
            dtpMesCategoria.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpMesCategoria.CustomFormat = "MM/yyyy";
            dtpMesCategoria.ShowUpDown = true;

            dtpMesRefVerbaTotal.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpMesRefVerbaTotal.CustomFormat = "MM/yyyy";
            dtpMesRefVerbaTotal.ShowUpDown = true;

            this.Enabled = false;
            InicializarCategorias();
            InicializarVerbasCategorias();

            funcoesGrid.AjustarTitulo(dgvCategorias, lblTituloCategorias, "Categorias criadas");
            funcoesGrid.AjustarTitulo(dgvMeses, lblTituloMesesCriados, "Meses criados");
            funcoesGrid.AjustarTitulo(dgvVerbasPorMes, lblTituloVerbasPorMes, "Verbas por mês");
            funcoesGrid.AjustarTitulo(dgvSaidasCategoria, lblTituloSaidasCategoria, "Saídas da categoria");

            splitContainer1.SplitterWidth = 3;
            splitContainer1.Paint += (s, pe) => layoutSplitter.DesenharLinhaDivisoria(splitContainer1, pe);
            splitContainer1.Panel1.Paint += (s, pe) => layoutSplitter.PintarPainelComBordasArredondadas(splitContainer1.Panel1, pe);
            splitContainer1.Panel2.Paint += (s, pe) => layoutSplitter.PintarPainelComBordasArredondadas(splitContainer1.Panel2, pe);
            splitContainer1.MouseEnter += (s, e) => layoutSplitter.ExibirLinhaDivisoria(splitContainer1);
            splitContainer1.MouseLeave += (s, e) => layoutSplitter.DiminuirLinhaDivisoria(splitContainer1);

            splitContainer2.SplitterWidth = 3;
            splitContainer2.BackColor = SystemColors.Window;
            splitContainer2.Paint += (s, pe) => layoutSplitter.DesenharLinhaDivisoria(splitContainer2, pe);
            splitContainer2.Panel1.Paint += (s, pe) => layoutSplitter.PintarPainelComBordasArredondadas(splitContainer2.Panel1, pe);
            splitContainer2.Panel2.Paint += (s, pe) => layoutSplitter.PintarPainelComBordasArredondadas(splitContainer2.Panel2, pe);
            splitContainer2.MouseEnter += (s, e) => layoutSplitter.ExibirLinhaDivisoria(splitContainer2);
            splitContainer2.MouseLeave += (s, e) => layoutSplitter.DiminuirLinhaDivisoria(splitContainer2);

            splitContainer3.SplitterWidth = 3;
            splitContainer3.BackColor = SystemColors.Window;
            splitContainer3.Paint += (s, pe) => layoutSplitter.DesenharLinhaDivisoria(splitContainer3, pe);
            splitContainer3.Panel1.Paint += (s, pe) => layoutSplitter.PintarPainelComBordasArredondadas(splitContainer3.Panel1, pe);
            splitContainer3.Panel2.Paint += (s, pe) => layoutSplitter.PintarPainelComBordasArredondadas(splitContainer3.Panel2, pe);
            splitContainer3.MouseEnter += (s, e) => layoutSplitter.ExibirLinhaDivisoria(splitContainer3);
            splitContainer3.MouseLeave += (s, e) => layoutSplitter.DiminuirLinhaDivisoria(splitContainer3);

            RedefinirTamanhoGrids();
            layoutSplitter.AjustarTamanhoSplitContainer(splitContainer1, 25);
            layoutSplitter.AjustarTamanhoSplitContainer(splitContainer2, 60);
            layoutSplitter.AjustarTamanhoSplitContainer(splitContainer3, 60);
            this.Enabled = true;
        }

        #region CATEGORIAS

        private void InicializarCategorias()
        {
            CRUD.PreencherValoresTodosMeses();
            CRUD.PreencherSaldoTotalCategoria();

            funcoesGrid.ConfigurarGrid(dgvCategorias, bindingSourceCategorias, funcoesGrid.ColunasGridCategorias(), false);
            bindingSourceCategorias.DataSource = DadosGerais.categorias;
            dgvCategorias.Columns[3].ReadOnly = false;
            dgvCategorias.Columns[4].ReadOnly = false;

            funcoesGrid.ConfigurarGrid(dgvMeses, bindingSourceMeses, funcoesGrid.ColunasGridMeses(), false);
            FiltrarMeses();
        }

        private void AtualizarCategorias()
        {
            CRUD.PreencherValoresTodosMeses();
            CRUD.PreencherSaldoTotalCategoria();
            bindingSourceCategorias.DataSource = DadosGerais.categorias;
            dgvCategorias.Refresh();
            InicializarVerbasCategorias();
        }

        private async void dgvCategorias_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada é a tecla "Delete"
            if (e.KeyCode == Keys.Delete)
            {
                if (dgvCategorias.SelectedRows.Count > 0)
                {
                    Categoria categoriaSelecionada = dgvCategorias.SelectedRows[0].DataBoundItem as Categoria;

                    // Exibe uma mensagem de confirmação para o usuário
                    DialogResult result = MessageBox.Show("Tem certeza que deseja excluir esta categoria?",
                                                          "Excluir categoria",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                    if (DadosGerais.saidas.Any(x => x.chaveCategoria == categoriaSelecionada.chave) || DadosGerais.entradas.Any(x => x.chaveCategoria == categoriaSelecionada.chave) || DadosGerais.lancamentosRecorrentes.Any(x => x.chaveCategoria == categoriaSelecionada.chave) || DadosGerais.meses.Any(x => x.chaveCategoria == categoriaSelecionada.chave))
                    {
                        MessageBox.Show("Para excluir uma categoria não deve ter saídas, entradas, meses ou lançamentos recorrentes vinculados. Verifique.");
                        return;
                    }

                    // Se o usuário confirmar a exclusão, exclua a conta
                    if (result == DialogResult.Yes)
                    {
                        this.Enabled = false;
                        // Realiza a operação de exclusão no banco de dados Firebase
                        FirebaseResponse response = await DadosGerais.client.DeleteTaskAsync("Categorias/" + "chave-" + categoriaSelecionada.chave);
                        this.Enabled = true;

                        // Verifica se a exclusão foi bem-sucedida
                        if (response.Exception == null)
                        {
                            MessageBox.Show("Categoria excluída com sucesso.");

                            // Atualiza a lista de contas exibida na interface
                            DadosGerais.categorias = await CRUD.BuscarCategorias();
                            funcoesGrid.ConfigurarGrid(dgvCategorias, bindingSourceCategorias, funcoesGrid.ColunasGridCategorias(), false);
                            bindingSourceCategorias.DataSource = DadosGerais.categorias;

                            FiltrarMeses();
                            FiltrarVerbasMesCategorias();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao excluir a categoria.");
                        }
                    }
                }
            }
        }

        private void btnLimparCategoria_Click(object sender, EventArgs e)
        {
            LimparCategoria();
        }

        private void LimparCategoria()
        {
            tbxIdCategoria.Text = "";
            tbxDescCategoria.Text = "";
            tbxVerbaPadraoCat.Text = "";
            tbxIdCategoria.Enabled = false;
        }

        static bool DataMenorIgual(DateTime data1, DateTime data2)
        {
            var data1SemDia = new DateTime(data1.Year, data1.Month, 1);
            var data2SemDia = new DateTime(data2.Year, data2.Month, 1);

            return data1SemDia <= data2SemDia;
        }

        private void FiltrarMeses()
        {
            if (DadosGerais.categorias == null || DadosGerais.categorias.Count == 0 || DadosGerais.meses == null || categoriaSelecionada == null) return;

            List<Mes> mesesAux;

            mesesAux = DadosGerais.meses.Where(x => x.chaveCategoria == categoriaSelecionada.chave).ToList();
            if (!chxTodosMeses.Checked)
            {
                mesesAux = mesesAux.Where(x => x.mes.Month == dtpMesCategoria.Value.Month && x.mes.Year == dtpMesCategoria.Value.Year).ToList();
            }

            mesesAux = mesesAux.OrderByDescending(x => x.mes).ToList();
            mesesDaCategoria = new(mesesAux);

            if (mesesDaCategoria.Count == 0)
            {
                bindingSourceMeses.DataSource = mesesDaCategoria;
                return;
            }

            foreach (Mes mes in mesesDaCategoria)
            {
                CRUD.PreencherValoresMes(mes);
            }

            bindingSourceMeses.DataSource = mesesDaCategoria;
        }

        private async void btnCriarMes_Click(object sender, EventArgs e)
        {
            Mes mesNovo = new();

            if (tbxVerbaMesCategoria.Text.Trim() != "")
                mesNovo.verbaOriginal = Convert.ToDouble(tbxVerbaMesCategoria.Text);
            else
                mesNovo.verbaOriginal = categoriaSelecionada.verbaPadrao;

            await CRUD.CriarMes(mesNovo, categoriaSelecionada.chave, dtpMesCategoria.Value);
            DadosGerais.meses = await CRUD.BuscarMeses();
            LimparMes();
            AtualizarCategorias();
            FiltrarMeses();
            FiltrarVerbasMesCategorias();
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedCells.Count > 0)
            {
                int rowIndex = dgvCategorias.SelectedCells[0].RowIndex;

                if (rowIndex >= 0 && rowIndex < dgvCategorias.Rows.Count)
                {
                    categoriaSelecionada = dgvCategorias.Rows[rowIndex].DataBoundItem as Categoria;
                }
            }
            else
                categoriaSelecionada = null;

            FiltrarMeses();
        }

        private async void btnSalvarCategoria_Click(object sender, EventArgs e)
        {
            Categoria categoriaNova = new();
            categoriaNova.descricao = tbxDescCategoria.Text.Trim();
            categoriaNova.verbaPadrao = (!String.IsNullOrEmpty(tbxVerbaPadraoCat.Text.Trim())) ? Convert.ToDouble(tbxVerbaPadraoCat.Text) : 0;

            if (tbxIdCategoria.Text.Length > 0)
            {
                categoriaNova.chave = Convert.ToInt32(tbxIdCategoria.Text);
            }
            else
            {
                if (DadosGerais.categorias == null || DadosGerais.categorias.Count == 0)
                    categoriaNova.chave = 1;
                else
                    categoriaNova.chave = DadosGerais.categorias.Max(x => x.chave) + 1;
            }

            this.Enabled = false;
            SetResponse response = await DadosGerais.client.SetTaskAsync("Categorias/" + "chave-" + categoriaNova.chave.ToString(), categoriaNova);
            this.Enabled = true;

            if (response.Exception == null)
            {
                MessageBox.Show("Categoria gravada.");

                DadosGerais.categorias = await CRUD.BuscarCategorias();
                funcoesGrid.ConfigurarGrid(dgvCategorias, bindingSourceCategorias, funcoesGrid.ColunasGridCategorias(), false);
                bindingSourceCategorias.DataSource = DadosGerais.categorias;

                AtualizarCategorias();
                LimparCategoria();
                FiltrarMeses();
                FiltrarVerbasMesCategorias();
            }
            else
            {
                MessageBox.Show("Erro ao gravar categoria.\n" + response.Exception);
            }
        }

        private async void dgvCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tbxIdCategoria.Text = categoriaSelecionada.chave.ToString();
                tbxDescCategoria.Text = categoriaSelecionada.descricao.ToString();
                tbxVerbaPadraoCat.Text = categoriaSelecionada.verbaPadrao.ToString();
            }
        }

        #endregion

        #region MESES

        private void dgvMeses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (chxTodosMeses.Checked) return;
            tbxIdMes.Text = mesSelecionado.chave.ToString();
            tbxVerbaMesCategoria.Text = mesSelecionado.verbaOriginal.ToString();
        }

        private void LimparMes()
        {
            tbxIdMes.Text = "";
            tbxVerbaMesCategoria.Text = "";
        }

        private void btnLimparMes_Click(object sender, EventArgs e)
        {
            LimparMes();
        }

        private void dgvMeses_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMeses.SelectedCells.Count > 0)
            {
                int rowIndex = dgvMeses.SelectedCells[0].RowIndex;

                if (rowIndex >= 0 && rowIndex < dgvMeses.Rows.Count)
                {
                    mesSelecionado = dgvMeses.Rows[rowIndex].DataBoundItem as Mes;
                }
            }
            else
                mesSelecionado = null;
        }

        private void dtpMesCategoria_ValueChanged(object sender, EventArgs e)
        {
            // Obtém o valor atual do DateTimePicker
            DateTime currentDate = dtpMesCategoria.Value;

            // Ajusta a data para o primeiro dia do mês atual
            DateTime adjustedDate = new DateTime(currentDate.Year, currentDate.Month, 1);

            // Se o dia atual for diferente do dia ajustado, atualize a data
            if (currentDate != adjustedDate)
            {
                dtpMesCategoria.Value = adjustedDate;
            }

            FiltrarMeses();
        }

        private void chxTodosMeses_CheckedChanged(object sender, EventArgs e)
        {
            dtpMesCategoria.Enabled = !chxTodosMeses.Checked;
            tbxVerbaMesCategoria.Enabled = !chxTodosMeses.Checked;
            btnCriarMes.Enabled = !chxTodosMeses.Checked;
            btnLimparMes.Enabled = !chxTodosMeses.Checked;
            if (chxTodosMeses.Checked) LimparMes();
            FiltrarMeses();
        }

        private void dgvMeses_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMeses.Columns[e.ColumnIndex].DataPropertyName == "mes" && e.Value != null && e.Value is DateTime)
            {
                DateTime dateValue = (DateTime)e.Value;
                e.Value = dateValue.ToString("MMM/yyyy");
                e.FormattingApplied = true;
            }

            if (dgvMeses.Columns[e.ColumnIndex].DataPropertyName == "saldoMes" && e.Value != null && e.Value is double)
            {
                double saldo = (double)e.Value;
                if (saldo < 0)
                {
                    e.CellStyle.ForeColor = LayoutColor.corValorNegativo;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = dgvMeses.DefaultCellStyle.ForeColor;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
                }
            }
        }

        #endregion

        private void lançamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.telaPrincipal.Show();
            this.Close();
        }

        private void mesesFuturoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.telaMesesFuturo = new();
            Formularios.telaMesesFuturo.WindowState = this.WindowState;
            Formularios.telaMesesFuturo.Show();
            this.Hide();

        }

        #region VERBAS DAS CATEGORIAS

        private void InicializarVerbasCategorias()
        {
            funcoesGrid.ConfigurarGrid(dgvVerbasPorMes, bindingSourceVerbasCategorias, funcoesGrid.ColunasGridVerbasCategorias(), false);
            FiltrarVerbasMesCategorias();
        }
        private void dtpMesRefVerbaTotal_ValueChanged(object sender, EventArgs e)
        {
            // Obtém o valor atual do DateTimePicker
            DateTime currentDate = dtpMesRefVerbaTotal.Value;

            // Ajusta a data para o primeiro dia do mês atual
            DateTime adjustedDate = new DateTime(currentDate.Year, currentDate.Month, 1);

            // Se o dia atual for diferente do dia ajustado, atualize a data
            if (currentDate != adjustedDate)
            {
                dtpMesRefVerbaTotal.Value = adjustedDate;
            }

            CarregarObsMes();
            FiltrarVerbasMesCategorias();
        }

        private void CarregarObsMes()
        {
            string obs = "";
            if (DadosGerais.obsMes != null && DadosGerais.obsMes.Count > 0)
            {
                ObsMes obsMes = DadosGerais.obsMes.Where(x => x.mes.Year == dtpMesRefVerbaTotal.Value.Year && x.mes.Month == dtpMesRefVerbaTotal.Value.Month).FirstOrDefault();
                if (obsMes != null)
                {
                    obs = obsMes.observacacao;
                }
            }
            textObsMes.Text = obs;
        }

        private void FiltrarVerbasMesCategorias()
        {
            if (DadosGerais.categorias == null || DadosGerais.categorias.Count == 0 || DadosGerais.meses == null || DadosGerais.meses.Count == 0) return;

            int indexOld = dgvVerbasPorMes.SelectedRows.Count > 0 ? dgvVerbasPorMes.SelectedRows[0].Index : 0;
            DateTime mes = dtpMesRefVerbaTotal.Value.Date;
            SortableBindingList<VerbaCategorias> verbasCategorias = new();

            Mes mesAux;
            double saidasMes = 0;

            foreach (Categoria categoria in DadosGerais.categorias)
            {
                mesAux = DadosGerais.meses.Where(x => x.mes.Month == mes.Month && x.mes.Year == mes.Year && x.chaveCategoria == categoria.chave).FirstOrDefault();
                saidasMes = DadosGerais.saidas.Where(x => x.chaveCategoria == categoria.chave && x.mesReferencia.Month == mes.Month && x.mesReferencia.Year == mes.Year).Sum(x => x.valorParcela);

                VerbaCategorias novo = new();
                novo.chaveCategoria = categoria.chave;
                novo.descricaoCategoria = categoria.descricao;
                novo.verbaMesCategoria = 0;
                novo.saldoMes = 0;

                if (mesAux == null) mesAux = new();

                novo.chaveMes = mesAux.chave;
                novo.verbaOriginalMesCategoria = mesAux.verbaOriginal;
                novo.verbaAdicionalMesCategoria = mesAux.verbaAdicional;
                novo.verbaMesCategoria = mesAux.verbaMes;
                novo.gastoMes = saidasMes;
                novo.saldoMes = mesAux.saldoMes;
                novo.saldoGeral = categoria.saldoTotal;

                double saidaFutura = DadosGerais.saidas == null ? 0 : DadosGerais.saidas.Where(x => x.chaveCategoria == categoria.chave && !DataMenorIgual(x.mesReferencia.Date, DateTime.Now.Date)).Sum(x => x.valorParcela);
                novo.saldoTotal = novo.saldoGeral + saidaFutura;

                verbasCategorias.Add(novo);
            }

            tbxNaoDistribuidoMes.Text = (DadosGerais.entradas.Where(x => x.mesReferencia.Month == mes.Month && x.mesReferencia.Year == mes.Year).Sum(x => x.valor) - DadosGerais.meses.Where(x => x.mes.Month == mes.Month && x.mes.Year == mes.Year).Select(x => x.verbaMes).Sum()).ToString("N2");
            tbxParcelasFuturas.Text = DadosGerais.saidas.Where(x => x.mesReferencia.Year > mes.Year || (x.mesReferencia.Year == mes.Year && x.mesReferencia.Month > mes.Month)).Select(x => x.valorParcela).Sum().ToString("N2");

            // vou pegar como valor inicial o que foi distribuido a mais no primeiro mês
            //DateTime primeiroMes = DadosGerais.meses.Min(x => x.mes);
            //double valorInicial = -1 * (DadosGerais.entradas.Where(x => x.mesReferencia.Month == primeiroMes.Month && x.mesReferencia.Year == primeiroMes.Year).Sum(x => x.valor) - DadosGerais.meses.Where(x => x.mes.Month == primeiroMes.Month && x.mes.Year == primeiroMes.Year).Select(x => x.verbaMes).Sum());
            //valorInicial+= 1444.21; //coloquei esse valor fixo, pois no primeiro mês 01/2024 eu reduzi a verba dos eletronicos/moveis.
            tbxNaoDistribuido.Text = ((DadosGerais.entradas.Where(x => DataMenorIgual(x.mesReferencia.Date, DateTime.Now.Date)).Sum(x => x.valor) + DadosGerais.valorInicial) - DadosGerais.meses.Where(x => DataMenorIgual(x.mes.Date, DateTime.Now.Date)).Select(x => x.verbaMes).Sum()).ToString("N2");

            AdicionarLinhaTotal(verbasCategorias);
            bindingSourceVerbasCategorias.DataSource = verbasCategorias;

            if (dgvVerbasPorMes != null && dgvVerbasPorMes.Rows.Count > 0)
            {
                if (dgvVerbasPorMes.Rows.Count >= (indexOld + 1))
                {
                    dgvVerbasPorMes.Rows[indexOld].Selected = true;
                }
                else
                {
                    dgvVerbasPorMes.Rows[0].Selected = true;
                }
            }
        }

        public void AdicionarLinhaTotal(SortableBindingList<VerbaCategorias> listaOriginal)
        {
            // Calcula os totais (ignorando colunas não numéricas)
            var total = new VerbaCategorias
            {
                descricaoCategoria = "TOTAL",
                verbaOriginalMesCategoria = listaOriginal.Sum(v => v.verbaOriginalMesCategoria),
                verbaAdicionalMesCategoria = listaOriginal.Sum(v => v.verbaAdicionalMesCategoria),
                verbaMesCategoria = listaOriginal.Sum(v => v.verbaMesCategoria),
                gastoMes = listaOriginal.Sum(v => v.gastoMes),
                saldoMes = listaOriginal.Sum(v => v.saldoMes),
                saldoTotal = listaOriginal.Sum(v => v.saldoTotal),
                saldoGeral = listaOriginal.Sum(v => v.saldoGeral)
            };

            // Adiciona o total à lista
            listaOriginal.Add(total);

            /*
            // Atualiza o DataGridView
            var bindingSource = new BindingSource { DataSource = listaComTotal };
            dataGridView.DataSource = bindingSource;

            // Formata a linha de total (opcional)
            if (dataGridView.Rows.Count > 0)
            {
                DataGridViewRow totalRow = dataGridView.Rows[dataGridView.Rows.Count - 1];
                totalRow.DefaultCellStyle.BackColor = Color.LightGray;
                totalRow.DefaultCellStyle.Font = new Font(dataGridView.Font, FontStyle.Bold);
            }
            */
        }

        #endregion

        private void dgvCategorias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCategorias.Columns[e.ColumnIndex].DataPropertyName == "saldoTotal" && e.Value != null && e.Value is double)
            {
                double saldo = (double)e.Value;
                if (saldo < 0)
                {
                    e.CellStyle.ForeColor = LayoutColor.corValorNegativo;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = dgvCategorias.DefaultCellStyle.ForeColor;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
                }
            }

            if (dgvCategorias.Columns[e.ColumnIndex].DataPropertyName == "gastoFlexivel" && e.Value != null && e.Value is bool)
            {
                bool valor = (bool)e.Value;
                e.Value = valor ? "Sim" : "Não";
                e.FormattingApplied = true;
            }

        }

        private void dgvVerbasPorMes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvVerbasPorMes.Columns[e.ColumnIndex].DataPropertyName == "saldoMes" ||
                 dgvVerbasPorMes.Columns[e.ColumnIndex].DataPropertyName == "saldoTotal" ||
                 dgvVerbasPorMes.Columns[e.ColumnIndex].DataPropertyName == "saldoGeral") && e.Value != null && e.Value is double)
            {
                double saldo = (double)e.Value;
                if (saldo < 0)
                {
                    e.CellStyle.ForeColor = LayoutColor.corValorNegativo;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = dgvVerbasPorMes.DefaultCellStyle.ForeColor;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
                }
            }

            var row = dgvVerbasPorMes.Rows[e.RowIndex];
            var cell = row.Cells[0]; // Substitua pelo nome da sua coluna de texto
            if (cell?.Value?.ToString() == "TOTAL")
            {
                // Formatação para a linha de TOTAL
                e.CellStyle.BackColor = Color.Gray;
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }
        }

        private void dgvVerbasPorMes_SelectionChanged(object sender, EventArgs e)
        {
            VerbaCategorias verbaCategoriaSelecionada = null;
            if (dgvVerbasPorMes.SelectedCells.Count > 0)
            {
                int rowIndex = dgvVerbasPorMes.SelectedCells[0].RowIndex;

                if (rowIndex >= 0 && rowIndex < dgvVerbasPorMes.Rows.Count)
                {
                    verbaCategoriaSelecionada = dgvVerbasPorMes.Rows[rowIndex].DataBoundItem as VerbaCategorias;
                }
            }

            FiltrarSaidas(verbaCategoriaSelecionada, false);

        }

        private void FiltrarSaidas(VerbaCategorias verbaCategoriaSelecionada, bool ajustarTitulo)
        {
            if (DadosGerais.categorias == null || DadosGerais.categorias.Count == 0 || DadosGerais.saidas == null) return;

            List<Saida> saidasAux;
            SortableBindingList<Saida> saidasDaCategoria;

            if (verbaCategoriaSelecionada != null)
            {
                saidasAux = DadosGerais.saidas.Where(x => x.chaveCategoria == verbaCategoriaSelecionada.chaveCategoria && x.mesReferencia.Year == dtpMesRefVerbaTotal.Value.Year && x.mesReferencia.Month == dtpMesRefVerbaTotal.Value.Month).ToList();
                saidasDaCategoria = new(saidasAux);
            }
            else
            {
                saidasDaCategoria = new();
            }

            funcoesGrid.ConfigurarGrid(dgvSaidasCategoria, bindingSourceSaidas, funcoesGrid.ColunasGridSaidas(true), false);
            bindingSourceSaidas.DataSource = saidasDaCategoria;

            tbxTotalSaida.Text = saidasDaCategoria.Sum(x => x.valorParcela).ToString("N2");
        }

        private void dgvSaidasCategoria_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSaidasCategoria.Columns[e.ColumnIndex].DataPropertyName == "tipoSaida" && e.Value != null)
            {
                if ((byte)(e.Value) == 0)
                    e.Value = "Crédito";
                else
                    e.Value = "Dinheiro";

                e.FormattingApplied = true;
            }

            if (dgvSaidasCategoria.Columns[e.ColumnIndex].DataPropertyName == "gastoObrigatorio" && e.Value != null)
            {
                if ((bool)(e.Value))
                    e.Value = "Sim";
                else
                    e.Value = "Não";

                e.FormattingApplied = true;
            }

            if (dgvSaidasCategoria.Columns[e.ColumnIndex].DataPropertyName == "chaveCategoria" && e.Value != null)
            {
                string descricao = "";
                int chave = (int)e.Value;
                if (DadosGerais.categorias != null) descricao = DadosGerais.categorias.Where(x => x.chave == chave).Select(x => x.descricao).FirstOrDefault();
                e.Value = descricao == null ? "" : descricao;

                e.FormattingApplied = true;
            }

            if (dgvSaidasCategoria.Columns[e.ColumnIndex].DataPropertyName == "chaveConta" && e.Value != null)
            {
                string descricao = "";
                int chave = (int)e.Value;
                if (DadosGerais.contas != null) descricao = DadosGerais.contas.Where(x => x.chave == chave).Select(x => x.descricaoConta).FirstOrDefault();
                e.Value = descricao == null ? "" : descricao;

                e.FormattingApplied = true;
            }

            if ((dgvSaidasCategoria.Columns[e.ColumnIndex].DataPropertyName == "data" ||
                dgvSaidasCategoria.Columns[e.ColumnIndex].DataPropertyName == "dataInicio") &&
                e.Value != null && e.Value is DateTime)
            {
                DateTime dateValue = (DateTime)e.Value;
                e.Value = dateValue.ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }
        }

        private void TelaCategorias_FormClosed(object sender, FormClosedEventArgs e)
        {
            Formularios.telaPrincipal.Show();
        }

        private void dgvCategorias_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            funcoesGrid.ReajustarTamanhoTitulo(dgvCategorias, lblTituloCategorias);
        }

        private void dgvMeses_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            funcoesGrid.ReajustarTamanhoTitulo(dgvMeses, lblTituloMesesCriados);
        }

        private void dgvVerbasPorMes_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            funcoesGrid.ReajustarTamanhoTitulo(dgvVerbasPorMes, lblTituloVerbasPorMes);
        }

        private void dgvSaidasCategoria_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            funcoesGrid.ReajustarTamanhoTitulo(dgvSaidasCategoria, lblTituloSaidasCategoria);
        }

        private void RedefinirTamanhoGrids()
        {
            int topGrid = 75;
            int distanciaGrid = 25;

            dgvCategorias.Top = topGrid;
            dgvCategorias.Width = dgvCategorias.Parent.Width - dgvCategorias.Left - distanciaGrid;
            dgvCategorias.Height = dgvCategorias.Parent.Height - dgvCategorias.Top - distanciaGrid;
            funcoesGrid.ReajustarTamanhoTitulo(dgvCategorias, lblTituloCategorias);
            lblTituloCategorias.Top = dgvCategorias.Top - lblTituloCategorias.Height;
            panelCategorias.Top = dgvCategorias.Top - lblTituloCategorias.Height - panelCategorias.Height;

            dgvMeses.Top = topGrid;
            dgvMeses.Width = dgvMeses.Parent.Width - dgvMeses.Left - distanciaGrid;
            dgvMeses.Height = dgvMeses.Parent.Height - dgvMeses.Top - distanciaGrid;
            funcoesGrid.ReajustarTamanhoTitulo(dgvMeses, lblTituloMesesCriados);
            lblTituloMesesCriados.Top = dgvMeses.Top - lblTituloMesesCriados.Height;
            panelMesesCriados.Top = dgvMeses.Top - lblTituloMesesCriados.Height - panelMesesCriados.Height;

            dgvVerbasPorMes.Top = topGrid;
            dgvVerbasPorMes.Width = dgvVerbasPorMes.Parent.Width - dgvVerbasPorMes.Left - distanciaGrid;
            dgvVerbasPorMes.Height = dgvVerbasPorMes.Parent.Height - dgvVerbasPorMes.Top - distanciaGrid;
            funcoesGrid.ReajustarTamanhoTitulo(dgvVerbasPorMes, lblTituloVerbasPorMes);
            lblTituloVerbasPorMes.Top = dgvVerbasPorMes.Top - lblTituloVerbasPorMes.Height;
            panelVerbasPorMes.Top = dgvVerbasPorMes.Top - lblTituloVerbasPorMes.Height - panelVerbasPorMes.Height;

            dgvSaidasCategoria.Top = topGrid;
            dgvSaidasCategoria.Width = dgvSaidasCategoria.Parent.Width - dgvSaidasCategoria.Left - distanciaGrid;
            dgvSaidasCategoria.Height = dgvSaidasCategoria.Parent.Height - dgvSaidasCategoria.Top - distanciaGrid;
            funcoesGrid.ReajustarTamanhoTitulo(dgvSaidasCategoria, lblTituloSaidasCategoria);
            lblTituloSaidasCategoria.Top = dgvSaidasCategoria.Top - lblTituloSaidasCategoria.Height;
            panelSaidasCategoria.Top = dgvSaidasCategoria.Top - lblTituloSaidasCategoria.Height - panelSaidasCategoria.Height;

            textObsMes.Left = lblTituloVerbasPorMes.Left + lblTituloVerbasPorMes.Width + 15;
            btnSalvarObsMes.Left = textObsMes.Left;
        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {
            RedefinirTamanhoGrids();
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            RedefinirTamanhoGrids();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            RedefinirTamanhoGrids();
        }

        private async void btnSalvarObsMes_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Cursor cursor = Cursors.WaitCursor;
            ObsMes obsMes;
            if (DadosGerais.obsMes == null || DadosGerais.obsMes.Count == 0)
            {
                obsMes = new ObsMes();
                obsMes.chave = 1;
                obsMes.mes = dtpMesRefVerbaTotal.Value.Date;
                obsMes.observacacao = textObsMes.Text;
                salvarMes(obsMes);
                this.Enabled = true;
                cursor = Cursors.Default;
                return;
            }

            obsMes = DadosGerais.obsMes.Where(x => x.mes.Month == dtpMesRefVerbaTotal.Value.Month && x.mes.Year == dtpMesRefVerbaTotal.Value.Year).FirstOrDefault();

            if (obsMes == null)
            {
                obsMes = new ObsMes();
                obsMes.chave = DadosGerais.obsMes.Max(x => x.chave) + 1;
                obsMes.mes = dtpMesRefVerbaTotal.Value.Date;
                obsMes.observacacao = textObsMes.Text;
                salvarMes(obsMes);
                this.Enabled = true;
                cursor = Cursors.Default;
                return;
            }

            obsMes.observacacao = textObsMes.Text;
            salvarMes(obsMes);
            this.Enabled = true;
            cursor = Cursors.Default;
        }

        private async void salvarMes(ObsMes obsMes)
        {
            await CRUD.SalvarObsMes(obsMes);
            DadosGerais.obsMes = await CRUD.BuscarObsMeses();
        }

        private async void dgvCategorias_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar se a célula alterada é da coluna que queremos monitorar
            if (dgvCategorias.Columns[e.ColumnIndex].DataPropertyName == "prioridade" ||
                dgvCategorias.Columns[e.ColumnIndex].DataPropertyName == "gastoFlexivel")
            {
                // Obter o objeto que foi alterado (linha)
                var linha = dgvCategorias.Rows[e.RowIndex];
                var objetoAlterado = linha.DataBoundItem as Categoria;

                if (objetoAlterado != null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    await AtualizarPrioridadeCategoria(objetoAlterado);
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private async Task AtualizarPrioridadeCategoria(Categoria categoria)
        {
            this.Enabled = false;
            SetResponse response = await DadosGerais.client.SetTaskAsync("Categorias/" + "chave-" + categoria.chave.ToString(), categoria);

            if (response.Exception == null)
            {
                MessageBox.Show("Categoria gravada.");

                DadosGerais.categorias = await CRUD.BuscarCategorias();
                funcoesGrid.ConfigurarGrid(dgvCategorias, bindingSourceCategorias, funcoesGrid.ColunasGridCategorias(), false);
                bindingSourceCategorias.DataSource = DadosGerais.categorias;
                dgvCategorias.Columns[3].ReadOnly = false;
                dgvCategorias.Columns[4].ReadOnly = false;

                AtualizarCategorias();
            }
            else
            {
                MessageBox.Show("Erro ao gravar categoria.\n" + response.Exception);
            }
            this.Enabled = true;
        }

        private void dgvCategorias_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (dgvCategorias.Columns[e.ColumnIndex].DataPropertyName == "gastoFlexivel")
            {
                if (e.Value != null)
                {
                    string texto = e.Value.ToString().Trim().ToLower();

                    if (texto == "sim")
                    {
                        e.Value = true;
                        e.ParsingApplied = true;
                    }
                    else if (texto == "não" || texto == "nao")
                    {
                        e.Value = false;
                        e.ParsingApplied = true;
                    }
                    else
                    {
                        MessageBox.Show("Digite 'Sim' ou 'Não'.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.ParsingApplied = false;
                    }
                }
            }
        }
    }
}
