﻿using FireSharp.Response;
using OrganizacaoFinanceira.Dados;
using OrganizacaoFinanceira.Objetos;
using OrganizacaoFinanceira.Recursos;
using OrganizacaoFinanceira.Telas;
using System.Data;

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

            FiltrarVerbasMesCategorias();
        }

        private void FiltrarVerbasMesCategorias()
        {
            if (DadosGerais.categorias == null || DadosGerais.categorias.Count == 0 || DadosGerais.meses == null || DadosGerais.meses.Count == 0) return;

            int indexOld = dgvVerbasPorMes.SelectedRows.Count > 0 ? dgvVerbasPorMes.SelectedRows[0].Index : 0;
            DateTime mes = dtpMesRefVerbaTotal.Value.Date;
            SortableBindingList<VerbaCategorias> verbasCategorias = new();

            Mes mesAux;
            double verbaOriginalMes = 0;
            double verbaAdicionalMes = 0;
            double verbaTotalMes = 0;
            double saldoTotalMes = 0;
            double saidasMes = 0;
            double saidasTotalMes = 0;
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
                novo.saldoTotal = categoria.saldoTotal;

                verbasCategorias.Add(novo);
                verbaOriginalMes += novo.verbaOriginalMesCategoria;
                verbaAdicionalMes += novo.verbaAdicionalMesCategoria;
                verbaTotalMes += novo.verbaMesCategoria;
                saidasTotalMes += novo.gastoMes;
                saldoTotalMes += novo.saldoMes;
            }

            tbxVerbaOriginal.Text = verbaOriginalMes.ToString("N2");
            tbxVerbaAdicionalMes.Text = verbaAdicionalMes.ToString("N2");
            tbxVerbaTotalMes.Text = verbaTotalMes.ToString("N2");
            tbxSaidaTotalMes.Text = saidasTotalMes.ToString("N2");
            tbxSaldoTotalMes.Text = saldoTotalMes.ToString("N2");
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
        }

        private void dgvVerbasPorMes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvVerbasPorMes.Columns[e.ColumnIndex].DataPropertyName == "saldoMes" ||
                 dgvVerbasPorMes.Columns[e.ColumnIndex].DataPropertyName == "saldoTotal") && e.Value != null && e.Value is double)
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
    }
}
