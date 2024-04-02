﻿using FireSharp.Response;
using OrganizacaoFinanceira.Dados;
using OrganizacaoFinanceira.Objetos;
using OrganizacaoFinanceira.Recursos;
using OrganizacaoFinanceira.Telas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizacaoFinanceira
{
    public partial class TelaMesesFuturo : Form
    {
        BindingSource bindingSourceLancRecorrentes = new BindingSource();
        BindingSource bindingSourceMesesFuturos = new BindingSource();

        LancamentoRecorrente lancRecorrenteSelecionado;

        CRUD CRUD = new CRUD();
        FuncoesGrid funcoesGrid = new();

        public TelaMesesFuturo()
        {
            InitializeComponent();
            panelLancRecorrente.BringToFront();
            LayoutColor.EstiloLayout(this);
        }

        private void TelaMesesFuturo_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            CarregarEntradaSaldoExtra();
            tbxEntradaExtra.Text = DadosGerais.entradaExtra.ToString();
            tbxSaidaExtra.Text = DadosGerais.saidaExtra.ToString();
            InicializarLancamentosRecorrentes();
            InicializarMesesFuturos();
            PreencherComboBoxCategoriasLancRecorrente();

            this.Enabled = true;
        }

        private void CarregarEntradaSaldoExtra()
        {
            if (DadosGerais.entradaExtra != 0 && DadosGerais.saidaExtra != 0)
            {
                return;
            }
            double entradasRecorrentes = DadosGerais.lancamentosRecorrentes.Where(x=>x.tipoLancamento == 1).Sum(x => x.valor);
            double saidasRecorrentes = DadosGerais.lancamentosRecorrentes.Where(x=>x.tipoLancamento == 0).Sum(x => x.valor);

            double entradasMes = DadosGerais.entradas.Where(x => x.mesReferencia.Month == DateTime.Now.Month && x.mesReferencia.Year == DateTime.Now.Year).Sum(x => x.valor);
            double saidasMes = DadosGerais.saidas.Where(x => x.mesReferencia.Month == DateTime.Now.Month && x.mesReferencia.Year == DateTime.Now.Year).Sum(x => x.valorParcela);

            DadosGerais.entradaExtra = entradasRecorrentes - entradasMes;
            DadosGerais.saidaExtra = saidasRecorrentes - saidasMes;

            if (DadosGerais.entradaExtra == 0) DadosGerais.entradaExtra = 0;
            if (DadosGerais.saidaExtra == 0) DadosGerais.saidaExtra = 0;

        }

        private void TelaMesesFuturo_Resize(object sender, EventArgs e)
        {
            int x = (this.ClientSize.Width - panelLancRecorrente.Size.Width) / 2;
            int y = (this.ClientSize.Height - panelLancRecorrente.Size.Height) / 2;
            panelLancRecorrente.Location = new Point(x, y);

            dgvLancamentosRecorrentes.Height = this.Height - dgvLancamentosRecorrentes.Top - 50;
            dgvMesesFuturos.Height = dgvLancamentosRecorrentes.Height;
            dgvMesesFuturos.Width = this.Width - dgvMesesFuturos.Left - 50;
        }

        private void PreencherComboBoxCategoriasLancRecorrente()
        {
            cbxCategoriaLancRecorrente.DataSource = null;
            cbxCategoriaLancRecorrente.Items.Clear();

            if (DadosGerais.categorias != null && DadosGerais.categorias.Count > 0)
            {
                BindingList<Categoria> bindingList = new BindingList<Categoria>(DadosGerais.categorias);
                cbxCategoriaLancRecorrente.DataSource = bindingList;

                cbxCategoriaLancRecorrente.DisplayMember = "descricao";
                cbxCategoriaLancRecorrente.ValueMember = "chave";

                cbxCategoriaLancRecorrente.SelectedIndex = -1;
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

            lancRecorrenteNovo.dataFinal = dtpMesFinal.Value;

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
                cbxCategoriaLancRecorrente.SelectedValue = lancRecorrenteSelecionado.chaveCategoria;
                chkLancObrigatorio.Checked = lancRecorrenteSelecionado.obrigatorio;
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
        }

        private void rbtFiltroSaidaLancRecorrente_CheckedChanged(object sender, EventArgs e)
        {
            FiltrarLancamentosRecorrentes();
        }

        private void FiltrarLancamentosRecorrentes()
        {
            if (DadosGerais.lancamentosRecorrentes == null) return;
            SortableBindingList<LancamentoRecorrente> lancamentosFiltro = new(DadosGerais.lancamentosRecorrentes.Where(x => x.tipoLancamento == (rbtFiltroSaidaLancRecorrente.Checked ? 0 : 1)).ToList());
            bindingSourceLancRecorrentes.DataSource = lancamentosFiltro;
            dgvLancamentosRecorrentes.Columns[2].Visible = rbtFiltroSaidaLancRecorrente.Checked;
            InicializarMesesFuturos();
        }

        #endregion

        #region MESES FUTUROS

        private void InicializarMesesFuturos()
        {
            DadosGerais.mesesFuturos = new();
            double valorAtualContas = DadosGerais.contas.Sum(x => x.valorAtual);

            valorAtualContas += Convert.ToDouble(tbxEntradaExtra.Text) - Convert.ToDouble(tbxSaidaExtra.Text);

            //Feito isso, pois o valor atual não considera as compras no crédito do mês atual, pois ainda não foram pagas.
            if (DadosGerais.saidas != null && DadosGerais.saidas.Count > 0)
            {
                valorAtualContas -= DadosGerais.saidas.Where(x => x.tipoSaida == 0 && x.mesReferencia.Month == DateTime.Now.Month && x.mesReferencia.Year == DateTime.Now.Year).Sum(x => x.valorParcela);
            }

            double entradasTotaisRecorrente = DadosGerais.lancamentosRecorrentes.Where(x => x.tipoLancamento == 1).Sum(x => x.valor);
            double saidasParceladas;
            double entradasMesAtual;
            for (int i = 0; i < 24; i++)
            {
                DadosGerais.mesesFuturos.Add(new MesFuturo());
                DadosGerais.mesesFuturos[i].mes = DateTime.Now.AddMonths(i + 1).Date;

                saidasParceladas = 0;
                entradasMesAtual = 0;

                if (DadosGerais.saidas != null && DadosGerais.saidas.Count > 0)
                {
                    saidasParceladas = DadosGerais.saidas.Where(x => x.qtdParcelas > 1 && x.mesReferencia.Month == DadosGerais.mesesFuturos[i].mes.Month && x.mesReferencia.Year == DadosGerais.mesesFuturos[i].mes.Year).Sum(x => x.valorParcela);
                }

                if (DadosGerais.entradas != null && DadosGerais.entradas.Count > 0)
                {
                    entradasMesAtual = DadosGerais.entradas.Where(x => x.mesReferencia.Month == DadosGerais.mesesFuturos[i].mes.Month && x.mesReferencia.Year == DadosGerais.mesesFuturos[i].mes.Year).Sum(x => x.valor);
                }

                double saidatotal = 0;
                double saidasCategoria;
                double saidasMesCategoria;
                foreach (Categoria categoria in DadosGerais.categorias)
                {
                    saidatotal += DadosGerais.lancamentosRecorrentes.Where(x => x.tipoLancamento == 0 && x.obrigatorio && x.chaveCategoria == categoria.chave && (x.dataFinal == DateTime.MinValue || MesMenorIgual(DadosGerais.mesesFuturos[i].mes, x.dataFinal))).Sum(x => x.valor);
                    saidasCategoria = DadosGerais.lancamentosRecorrentes.Where(x => x.tipoLancamento == 0 && !x.obrigatorio && x.chaveCategoria == categoria.chave && (x.dataFinal == DateTime.MinValue || MesMenorIgual(DadosGerais.mesesFuturos[i].mes, x.dataFinal))).Sum(x => x.valor);
                    saidasMesCategoria = DadosGerais.saidas.Where(x => x.tipoSaida == 0 && x.chaveCategoria == categoria.chave && x.mesReferencia.Month == DadosGerais.mesesFuturos[i].mes.Month && x.mesReferencia.Year == DadosGerais.mesesFuturos[i].mes.Year).Sum(x => x.valorParcela);

                    if (saidasMesCategoria >= saidasCategoria)
                    {
                        saidatotal += saidasMesCategoria;
                    }
                    else
                    {
                        saidatotal += saidasCategoria - saidasMesCategoria;
                    }
                }

                DadosGerais.mesesFuturos[i].saidasTotais = saidatotal;
                DadosGerais.mesesFuturos[i].entradasTotais = entradasTotaisRecorrente;
                DadosGerais.mesesFuturos[i].saidasParceladas = saidasParceladas;
                DadosGerais.mesesFuturos[i].saldoGeral = valorAtualContas + entradasTotaisRecorrente - saidatotal - entradasMesAtual;
                valorAtualContas = DadosGerais.mesesFuturos[i].saldoGeral;
            }

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
            DadosGerais.entradaExtra = Convert.ToDouble(tbxEntradaExtra.Text);
        }

        private void tbxSaidaExtra_TextChanged(object sender, EventArgs e)
        {
            if (tbxSaidaExtra.Text.Length == 0) return;
            DadosGerais.saidaExtra = Convert.ToDouble(tbxSaidaExtra.Text);
        }

        private void tbxSaidaExtra_Validated(object sender, EventArgs e)
        {
            if (tbxSaidaExtra.Text.Length == 0) tbxSaidaExtra.Text = "0";
        }
    }
}
