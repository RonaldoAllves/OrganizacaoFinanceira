using FireSharp.Response;
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
    public partial class TelaCategorias : Form
    {
        CRUD CRUD = new CRUD();
        FuncoesGrid funcoesGrid = new();

        BindingSource bindingSourceCategorias = new BindingSource();
        BindingSource bindingSourceMeses = new BindingSource();
        BindingSource bindingSourceVerbasCategorias = new BindingSource();

        Categoria categoriaSelecionada;
        Mes mesSelecionado;

        SortableBindingList<Mes> mesesDaCategoria;

        public TelaCategorias()
        {
            InitializeComponent();
        }

        private void TelaCategorias_Load(object sender, EventArgs e)
        {
            dtpMesCategoria.CustomFormat = "MM/yyyy";
            dtpMesCategoria.ShowUpDown = true;

            dtpMesRefVerbaTotal.CustomFormat = "MM/yyyy";
            dtpMesRefVerbaTotal.ShowUpDown = true;

            this.Enabled = false;
            InicializarCategorias();
            InicializarVerbasCategorias();
            this.Enabled = true;
        }


        #region CATEGORIAS

        private void InicializarCategorias()
        {
            PreencherValoresTodosMeses();
            PreencherSaldoTotalCategoria();

            funcoesGrid.ConfigurarGrid(dgvCategorias, bindingSourceCategorias, funcoesGrid.ColunasGridCategorias(), false);
            bindingSourceCategorias.DataSource = DadosGerais.categorias;

            funcoesGrid.ConfigurarGrid(dgvMeses, bindingSourceMeses, funcoesGrid.ColunasGridMeses(), false);
            FiltrarMeses();
        }

        private void AtualizarCategorias()
        {
            PreencherSaldoTotalCategoria();
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

                    if (DadosGerais.saidas.Any(x => x.chaveCategoria == categoriaSelecionada.chave) || DadosGerais.entradas.Any(x => x.chaveCategoria == categoriaSelecionada.chave) || DadosGerais.lancamentosRecorrentes.Any(x => x.chaveCategoria == categoriaSelecionada.chave))
                    {
                        MessageBox.Show("Para excluir uma categoria não deve ter saídas, entradas ou lançamentos recorrentes vinculados. Verifique.");
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

        private void PreencherSaldoTotalCategoria()
        {
            double verbaTotal;
            foreach (Categoria categoria in DadosGerais.categorias)
            {
                verbaTotal = DadosGerais.meses.Where(x => x.chaveCategoria == categoria.chave && DataMenorIgual(x.mes.Date, DateTime.Now.Date)).Sum(x => x.verbaMes);
                categoria.saldoTotal = verbaTotal - (DadosGerais.saidas == null ? 0 : DadosGerais.saidas.Where(x => x.chaveCategoria == categoria.chave).Sum(x => x.valorParcela));
            }
        }

        static bool DataMenorIgual(DateTime data1, DateTime data2)
        {
            var data1SemDia = new DateTime(data1.Year, data1.Month, 1);
            var data2SemDia = new DateTime(data2.Year, data2.Month, 1);

            return data1SemDia <= data2SemDia;
        }

        private void PreencherValoresTodosMeses()
        {
            foreach (Mes mes in DadosGerais.meses)
            {
                PreencherValoresMes(mes);
            }
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
                PreencherValoresMes(mes);
            }

            bindingSourceMeses.DataSource = mesesDaCategoria;
        }

        private void PreencherValoresMes(Mes mes)
        {
            List<Saida> saidasCategoria = new();
            List<Saida> saidasMes = new();

            if (DadosGerais.saidas != null)
            {
                saidasCategoria = DadosGerais.saidas.Where(x => x.chaveCategoria == mes.chaveCategoria).ToList();
                saidasMes = saidasCategoria.Where(x => x.mesReferencia.Month == mes.mes.Month && x.mesReferencia.Year == mes.mes.Year).ToList();
                mes.saldoMes = mes.verbaMes - saidasMes.Sum(x => x.valorParcela);
            }
        }

        private async void btnCriarMes_Click(object sender, EventArgs e)
        {
            Mes mesNovo = new();

            if (tbxVerbaMesCategoria.Text.Trim() != "")
                mesNovo.verbaOriginal = Convert.ToDouble(tbxVerbaMesCategoria.Text);
            else
                mesNovo.verbaOriginal = categoriaSelecionada.verbaPadrao;

            CRUD.CriarMes(mesNovo, categoriaSelecionada.chave, dtpMesCategoria.Value);
            DadosGerais.meses = await CRUD.BuscarMeses();
            LimparMes();
            AtualizarCategorias();
            FiltrarMeses();
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
            categoriaNova.verbaPadrao = Convert.ToDouble(tbxVerbaPadraoCat.Text);

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
            FiltrarVerbasMesCategorias();
        }

        private void FiltrarVerbasMesCategorias()
        {
            if (DadosGerais.categorias == null || DadosGerais.categorias.Count == 0 || DadosGerais.meses == null || DadosGerais.meses.Count == 0) return;

            DateTime mes = dtpMesRefVerbaTotal.Value.Date;
            SortableBindingList<VerbaCategorias> verbasCategorias = new();

            Mes mesAux;
            double verbaTotalMes = 0;
            double saldoTotalMes = 0;
            foreach (Categoria categoria in DadosGerais.categorias)
            {
                mesAux = DadosGerais.meses.Where(x => x.mes.Month == mes.Month && x.mes.Year == mes.Year && x.chaveCategoria == categoria.chave).FirstOrDefault();
                
                
                VerbaCategorias novo = new();
                novo.chaveCategoria = categoria.chave;
                novo.descricaoCategoria = categoria.descricao;
                novo.verbaMesCategoria = 0;
                novo.saldoMes = 0;

                if (mesAux != null)
                {
                    novo.chaveMes = mesAux.chave;
                    novo.verbaOriginalMesCategoria = mesAux.verbaOriginal;
                    novo.verbaAdicionalMesCategoria = mesAux.verbaAdicional;
                    novo.verbaMesCategoria = mesAux.verbaMes;
                    novo.saldoMes = mesAux.saldoMes;
                }

                verbasCategorias.Add(novo);
                verbaTotalMes += novo.verbaMesCategoria;
                saldoTotalMes += novo.saldoMes;
            }

            tbxVerbaTotalMes.Text = verbaTotalMes.ToString("N2");
            tbxSaldoTotalMes.Text = saldoTotalMes.ToString("N2");
            bindingSourceVerbasCategorias.DataSource = verbasCategorias;
        }

        #endregion

    }
}
