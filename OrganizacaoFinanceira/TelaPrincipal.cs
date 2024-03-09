using OrganizacaoFinanceira.Objetos;
using OrganizacaoFinanceira.Recursos;
using OrganizacaoFinanceira.Dados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json.Bson;
using System.Net;
using System.Diagnostics.Eventing.Reader;
using FireSharp;
using System.Reflection;
using OrganizacaoFinanceira.Telas;

namespace OrganizacaoFinanceira
{
    public partial class TelaPrincipal : Form
    {
        CRUD CRUD = new CRUD();
        string mensagemValorAtualConta = "";

        BindingSource bindingSourceContas = new BindingSource();
        BindingSource bindingSourceSaidas = new BindingSource();
        BindingSource bindingSourceEntradas = new BindingSource();
        BindingSource bindingSourceCategorias = new BindingSource();
        BindingSource bindingSourceMeses = new BindingSource();

        ContaBanco contaSelecionada;
        Saida saidaSelecionada;
        Entrada entradaSelecionada;
        Categoria categoriaSelecionada;
        Mes mesSelecionado;

        SortableBindingList<Saida> saidasDaConta;
        SortableBindingList<Entrada> entradasDaConta;
        SortableBindingList<Mes> mesesDaCategoria;

        FuncoesGrid funcoesGrid = new();

        public TelaPrincipal()
        {


            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            panelLancamento.BringToFront();
        }

        private async void TelaPrincipal_Load(object sender, EventArgs e)
        {
            this.Enabled = false;

            await CRUD.BuscarTodosDados();
            InicializarDatas();
            InicializarContas();
            InicializarCategorias();


            this.Enabled = true;
        }

        private void InicializarDatas()
        {
            dtpMesReferencia.CustomFormat = "MM/yyyy";
            dtpMesReferencia.ShowUpDown = true;

            dtpMesReferenciaLancamento.CustomFormat = "MM/yyyy";
            dtpMesReferenciaLancamento.ShowUpDown = true;

            dtpMesCategoria.CustomFormat = "MM/yyyy";
            dtpMesCategoria.ShowUpDown = true;
        }

        private void TelaPrincipal_Resize(object sender, EventArgs e)
        {
            int x = (this.ClientSize.Width - panelLancamento.Size.Width) / 2;
            int y = (this.ClientSize.Height - panelLancamento.Size.Height) / 2;
            panelLancamento.Location = new Point(x, y);
        }

        #region ATUALIZAR BANCO

        private async Task AtualizarSaidasBancoDados()
        {
            List<Task<SetResponse>> tasks = new List<Task<SetResponse>>();

            this.Enabled = false;
            foreach (Saida saida in DadosGerais.saidas)
            {
                // Inicie a tarefa e adicione à lista de tarefas
                Task<SetResponse> task = DadosGerais.client.SetTaskAsync("Saidas/chave-" + saida.chave, saida);
                tasks.Add(task);
            }

            // Aguarde todas as tarefas serem concluídas
            await Task.WhenAll(tasks);
            this.Enabled = true;

            MessageBox.Show("Atualização concluída");
            DadosGerais.saidas = await CRUD.BuscarSaidas();
        }

        #endregion

        #region CONTAS

        private void InicializarContas()
        {
            AtualizarValorTotalConta();
            funcoesGrid.ConfigurarGrid(dgvContas, bindingSourceContas, funcoesGrid.ColunasGridContas(), false);
            dgvContas.Columns[3].ToolTipText = mensagemValorAtualConta;

            bindingSourceContas.DataSource = DadosGerais.contas;

            if (dgvContas.Rows.Count > 0)
            {
                dgvContas.Rows[0].Selected = true;
            }

            InicializarLancamentos();
        }

        private void AtualizarValorTotalConta()
        {
            mensagemValorAtualConta = "Considera o valor inicial da conta adicionando todas as entradas e retirando todas as saídas já existenste até o mês atual desconsiderando as compras no crédito do mês atual.\n" +
                                      "O valor atual já considera que foi pago a fatura do último mês fechado, ou seja, caso a fatura ainda não tenha sido paga, pode haver diferença do valor atual mostrado com o valor atual na conta.";
            double saidasConta;
            double entradasConta;
            double creditoMesAtual;
            foreach (ContaBanco conta in DadosGerais.contas)
            {
                saidasConta = DadosGerais.saidas.Where(x => x.chaveConta == conta.chave && DataMenorIgual(x.mesReferencia.Date, DateTime.Now.Date)).Sum(x => x.valorParcela);
                entradasConta = DadosGerais.entradas.Where(x => x.chaveConta == conta.chave).Sum(x => x.valor);

                creditoMesAtual = DadosGerais.saidas.Where(x => x.chaveConta == conta.chave && x.tipoSaida == 0 && DatasIguais(x.mesReferencia.Date, DateTime.Now.Date)).Sum(x => x.valorParcela);
                saidasConta -= creditoMesAtual;

                conta.valorAtual = conta.valorInicial - saidasConta + entradasConta;
            }
            dgvContas.Refresh();
        }

        static bool DataMenorIgual(DateTime data1, DateTime data2)
        {
            var data1SemDia = new DateTime(data1.Year, data1.Month, 1);
            var data2SemDia = new DateTime(data2.Year, data2.Month, 1);

            return data1SemDia <= data2SemDia;
        }

        static bool DatasIguais(DateTime data1, DateTime data2)
        {
            var data1SemDia = new DateTime(data1.Year, data1.Month, 1);
            var data2SemDia = new DateTime(data2.Year, data2.Month, 1);

            return data1SemDia == data2SemDia;
        }



        private void btnNovaConta_Click(object sender, EventArgs e)
        {
            LimparConta();
        }

        private async void dgvContas_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada é a tecla "Delete"
            if (e.KeyCode == Keys.Delete)
            {
                // Verifica se há uma linha selecionada na grade de dados
                if (dgvContas.SelectedRows.Count > 0)
                {
                    // Obtém a conta selecionada na linha
                    ContaBanco contaSelecionada = dgvContas.SelectedRows[0].DataBoundItem as ContaBanco;

                    // Exibe uma mensagem de confirmação para o usuário
                    DialogResult result = MessageBox.Show("Tem certeza que deseja excluir esta conta?",
                                                          "Excluir Conta",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                    // Se o usuário confirmar a exclusão, exclua a conta
                    if (result == DialogResult.Yes)
                    {
                        if (DadosGerais.saidas.Where(x => x.chaveConta == contaSelecionada.chave).Count() > 0 || DadosGerais.entradas.Where(x => x.chaveConta == contaSelecionada.chave).Count() > 0)
                        {
                            MessageBox.Show("Para excluir a conta deve excluir todas as entradas e saídas vinculadas");
                            return;
                        }

                        this.Enabled = false;
                        // Realiza a operação de exclusão no banco de dados Firebase
                        FirebaseResponse response = await DadosGerais.client.DeleteTaskAsync("Contas/" + "chave-" + contaSelecionada.chave);
                        this.Enabled = true;

                        // Verifica se a exclusão foi bem-sucedida
                        if (response.Exception == null)
                        {
                            MessageBox.Show("Conta excluída com sucesso.");

                            // Atualiza a lista de contas exibida na interface
                            DadosGerais.contas = await CRUD.BuscarContas();
                            bindingSourceContas.DataSource = DadosGerais.contas;
                            PreencherComboBoxContas();
                        }
                        else
                        {
                            MessageBox.Show("Falha ao excluir a conta.");
                        }

                    }
                }
            }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarConta()) return;

            ContaBanco conta = new();
            conta.nomeBanco = txBanco.Text.Trim();
            conta.usuarioConta = txUsuario.Text.Trim();
            conta.diaFechamento = Convert.ToInt16(txDataFechamento.Text);
            conta.valorInicial = Convert.ToDouble(txValorInicial.Text);

            if (tbxChaveConta.Text.Trim() == "")
            {
                if (DadosGerais.contas != null && DadosGerais.contas.Count > 0)
                    conta.chave = DadosGerais.contas.Max(x => x.chave) + 1;
                else
                    conta.chave = 1;
            }
            else
                conta.chave = Convert.ToInt32(tbxChaveConta.Text);

            if (DadosGerais.contas.Any(x => x.chave == conta.chave))
            {
                ContaBanco contaOld = DadosGerais.contas.FirstOrDefault(x => x.chave == conta.chave);
                conta.dataCriacao = contaOld.dataCriacao;
                conta.dataAlteracao = DateTime.Now;
            }
            else
            {
                conta.dataCriacao = DateTime.Now;
                conta.dataAlteracao = DateTime.Now;
            }

            this.Enabled = false;
            SetResponse response = await DadosGerais.client.SetTaskAsync("Contas/" + "chave-" + conta.chave, conta);
            this.Enabled = true;

            ContaBanco result = response.ResultAs<ContaBanco>();

            MessageBox.Show("Conta gravada. " + result.chave);

            DadosGerais.contas = await CRUD.BuscarContas();
            bindingSourceContas.DataSource = DadosGerais.contas;
            PreencherComboBoxContas();

            LimparConta();
            AtualizarValorTotalConta();
        }

        private void LimparConta()
        {
            tbxChaveConta.Text = "";
            txBanco.Text = "";
            txUsuario.Text = "";
            txDataFechamento.Text = "";
            txValorInicial.Text = "";
        }

        private bool ValidarConta()
        {
            // Verificar se os campos não estão vazios
            if (string.IsNullOrWhiteSpace(txBanco.Text) || string.IsNullOrWhiteSpace(txUsuario.Text) ||
                 string.IsNullOrWhiteSpace(txValorInicial.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return false;
            }

            if (txDataFechamento.Text.Trim().Length > 0)
            {
                // Verificar se o valor do dia de fechamento é um número válido
                if (!int.TryParse(txDataFechamento.Text, out int diaFechamento))
                {
                    MessageBox.Show("O dia de fechamento deve ser um número inteiro válido.");
                    return false;
                }

                // Verificar se o valor do dia de fechamento está dentro do intervalo válido (1 a 31)
                if (diaFechamento < 1 || diaFechamento > 31)
                {
                    MessageBox.Show("O dia de fechamento deve estar entre 1 e 31.");
                    return false;
                }
            }
            else txDataFechamento.Text = "0";

            // Verificar se o valor do valor inicial é um número válido
            if (!double.TryParse(txValorInicial.Text, out double valorInicial))
            {
                MessageBox.Show("O valor inicial deve ser um número válido.");
                return false;
            }

            // Verificar se o valor do valor inicial é maior que zero
            if (valorInicial < 0)
            {
                MessageBox.Show("O valor inicial deve ser maior que zero.");
                return false;
            }

            return true;
        }

        private void dgvContas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Preenche os campos da interface com os dados da conta selecionada
                tbxChaveConta.Text = contaSelecionada.chave.ToString();
                txBanco.Text = contaSelecionada.nomeBanco;
                txUsuario.Text = contaSelecionada.usuarioConta;
                txDataFechamento.Text = contaSelecionada.diaFechamento.ToString();
                txValorInicial.Text = contaSelecionada.valorInicial.ToString();
            }
        }

        private void dgvContas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvContas.SelectedCells.Count > 0)
            {
                int rowIndex = dgvContas.SelectedCells[0].RowIndex;

                if (rowIndex >= 0 && rowIndex < dgvContas.Rows.Count)
                {
                    contaSelecionada = dgvContas.Rows[rowIndex].DataBoundItem as ContaBanco;
                }
            }
            else
                contaSelecionada = null;

            FiltrarLancamentos();
            SelecionarValorComboboxContas();
        }

        #endregion

        #region LANÇAMENTOS CONTA

        private void InicializarLancamentos()
        {
            rbtSaidas.Checked = true;

            if (rbtSaidas.Checked)
            {
                funcoesGrid.ConfigurarGrid(dgvLancamentos, bindingSourceSaidas, funcoesGrid.ColunasGridSaidas(), false);
                FiltrarSaidas();
                LimparLancamento();

                chxCredito.Checked = true;
                chxDinheiro.Checked = false;
                tbxNumParcela.Text = "1";
                nudQtdParcelas.Value = 1;
            }
            else
            {
                funcoesGrid.ConfigurarGrid(dgvLancamentos, bindingSourceEntradas, funcoesGrid.ColunasGridEntradas(), false);
                FiltrarEntradas();
                LimparLancamento();
            }

            PreencherComboBoxContas();
        }

        private async void FiltrarLancamentos()
        {
            panelParcelas.Visible = rbtSaidas.Checked;
            chxCredito.Visible = rbtSaidas.Checked;
            chxDinheiro.Visible = rbtSaidas.Checked;
            cbxTipoSaida.Visible = rbtSaidas.Checked;
            lblTipoSaida.Visible = rbtSaidas.Checked;

            if (rbtSaidas.Checked)
            {
                funcoesGrid.ConfigurarGrid(dgvLancamentos, bindingSourceSaidas, funcoesGrid.ColunasGridSaidas(), false);
                entradasDaConta = null;
                bindingSourceEntradas.DataSource = entradasDaConta;
                FiltrarSaidas();
            }
            else
            {
                funcoesGrid.ConfigurarGrid(dgvLancamentos, bindingSourceEntradas, funcoesGrid.ColunasGridEntradas(), false);

                if (DadosGerais.entradas == null) DadosGerais.entradas = await CRUD.BuscarEntradas();

                saidasDaConta = null;
                bindingSourceSaidas.DataSource = saidasDaConta;
                FiltrarEntradas();
            }
        }

        private void FiltrarSaidas()
        {
            if (DadosGerais.contas == null || DadosGerais.contas.Count == 0 || DadosGerais.saidas == null) return;

            List<Saida> saidasAux;

            if (contaSelecionada != null)
            {
                saidasAux = DadosGerais.saidas.Where(x => x.chaveConta == contaSelecionada.chave && x.mesReferencia.Year == dtpMesReferencia.Value.Year && x.mesReferencia.Month == dtpMesReferencia.Value.Month).ToList();

                saidasAux = saidasAux.Where(x => (chxCredito.Checked && x.tipoSaida == 0) ||
                                                (chxDinheiro.Checked && x.tipoSaida == 1)).ToList();

                saidasDaConta = new(saidasAux);
            }
            else
            {
                saidasDaConta = new();
            }

            bindingSourceSaidas.DataSource = saidasDaConta;
            tbxTotalLancamento.Text = saidasDaConta.Sum(x => x.valorParcela).ToString("N2");
            LimparLancamento();
        }







        private void rbtSaidas_CheckedChanged(object sender, EventArgs e)
        {
            FiltrarLancamentos();
        }

        private void FiltrarEntradas()
        {
            if (DadosGerais.contas == null || DadosGerais.contas.Count == 0 || DadosGerais.entradas == null) return;

            List<Entrada> entradaAux;

            if (contaSelecionada != null)
            {
                entradaAux = DadosGerais.entradas.Where(x => x.chaveConta == contaSelecionada.chave && x.mesReferencia.Year == dtpMesReferencia.Value.Year && x.mesReferencia.Month == dtpMesReferencia.Value.Month).ToList();

                entradasDaConta = new(entradaAux);
            }
            else
            {
                entradasDaConta = new();
            }

            bindingSourceEntradas.DataSource = entradasDaConta;
            tbxTotalLancamento.Text = entradasDaConta.Sum(x => x.valor).ToString();
            LimparLancamento();
        }

        private async void btnSalvarLancamento_Click(object sender, EventArgs e)
        {
            if (rbtSaidas.Checked)
            {
                panelLancamento.Visible = !await SalvarSaida();
            }
            else
            {
                panelLancamento.Visible = !await SalvarEntrada();
            }
            if (!panelLancamento.Visible) AtualizarValorTotalConta();
        }

        private async Task<bool> SalvarSaida()
        {
            if (!ValidarLancamento()) return false;

            ContaBanco conta = cbxContas.SelectedItem as ContaBanco;

            Saida saidaOld = null;
            Saida saida = new Saida();
            saida.descricao = tbxDescricao.Text.Trim();
            saida.valorTotal = (tbxValorTotal.Text.Trim() == "") ? Convert.ToDouble(tbxValor.Text) : Convert.ToDouble(tbxValorTotal.Text);
            saida.data = dtpDataLancamento.Value.Date;
            saida.chaveCategoria = (int)cbxCategoria.SelectedValue;
            saida.mesReferencia = dtpMesReferenciaLancamento.Value.Date;
            saida.chaveConta = conta.chave;
            saida.valorParcela = Convert.ToDouble(tbxValor.Text);
            saida.parcela = Convert.ToInt32(tbxNumParcela.Text);
            saida.qtdParcelas = Convert.ToInt32(nudQtdParcelas.Value);
            saida.dataInicio = dtpDataInicial.Value.Date;

            switch (cbxTipoSaida.SelectedItem)
            {
                case "Crédito":
                    saida.tipoSaida = 0;
                    break;
                case "Dinheiro":
                    saida.tipoSaida = 1;
                    break;
                default:
                    saida.tipoSaida = 0;
                    break;
            }

            if (tbxChaveLancamento.Text.Trim() == "")
            {
                if (DadosGerais.saidas != null && DadosGerais.saidas.Count > 0)
                    saida.chave = DadosGerais.saidas.Max(x => x.chave) + 1;
                else
                    saida.chave = 1;
            }
            else
            {
                saidaOld = DadosGerais.saidas.FirstOrDefault(x => x.chave == Convert.ToInt32(tbxChaveLancamento.Text));
                saida.chave = saidaOld.chave;
                saida.dataCadastro = saidaOld.dataCadastro;
            }

            if (saidaOld != null)
            {
                saida.dataAlteracao = DateTime.Now;
            }
            else
            {
                saida.dataCadastro = DateTime.Now;
                saida.dataAlteracao = DateTime.Now;
            }

            this.Enabled = false;
            SetResponse response = await DadosGerais.client.SetTaskAsync("Saidas/" + "chave-" + saida.chave, saida);
            this.Enabled = true;

            if (response.Exception == null)
            {
                if (saidaOld == null && saida.qtdParcelas > 1) await CriarParcelas(saida);

                MessageBox.Show("Saída gravada. " + saida.chave);

                DadosGerais.saidas = await CRUD.BuscarSaidas();
                FiltrarSaidas();
                LimparLancamento();
                AtualizarCategorias();
                return true;
            }
            else
            {
                MessageBox.Show("Erro ao gravar a saída.\n" + response.Exception);
            }
            return false;
        }

        private async Task CriarParcelas(Saida saida)
        {
            Saida parcela;
            string chave;
            bool erro = false;
            Dictionary<string, Saida> dic;
            for (int i = 1; i < saida.qtdParcelas; i++)
            {
                chave = $"chave-{saida.chave + i}";
                parcela = saida.Copy();
                parcela.chave = saida.chave + i;
                parcela.parcela = i + 1;
                parcela.data = (new DateTime(saida.mesReferencia.Year, saida.mesReferencia.Month, 1)).AddMonths(i);
                parcela.mesReferencia = parcela.data;

                this.Enabled = false;
                SetResponse response = await DadosGerais.client.SetTaskAsync("Saidas/" + chave, parcela);
                this.Enabled = true;
            }
        }

        private async Task<bool> SalvarEntrada()
        {
            if (!ValidarLancamento()) return false;

            ContaBanco conta = cbxContas.SelectedItem as ContaBanco;

            Entrada entradaOld = null;
            Entrada entrada = new();
            entrada.descricao = tbxDescricao.Text.Trim();
            entrada.valor = Convert.ToDouble(tbxValor.Text);
            entrada.data = dtpDataLancamento.Value.Date;
            entrada.chaveCategoria = cbxCategoria.SelectedValue == null ? 0 : (int)cbxCategoria.SelectedValue;
            entrada.mesReferencia = dtpMesReferenciaLancamento.Value;
            entrada.chaveConta = conta.chave;
            entrada.valor = Convert.ToDouble(tbxValor.Text);

            if (DadosGerais.entradas != null && DadosGerais.entradas.Count > 0 && DadosGerais.entradas.Any(x => x.chave == entrada.chave))
            {
                entrada.dataAlteracao = DateTime.Now;
            }
            else
            {
                entrada.dataCadastro = DateTime.Now;
                entrada.dataAlteracao = DateTime.Now;
            }

            if (tbxChaveLancamento.Text.Trim() == "")
            {
                if (DadosGerais.entradas != null && DadosGerais.entradas.Count > 0)
                    entrada.chave = DadosGerais.entradas.Max(x => x.chave) + 1;
                else entrada.chave = 1;
            }
            else
            {
                entrada.chave = Convert.ToInt32(tbxChaveLancamento.Text);
                entradaOld = DadosGerais.entradas.FirstOrDefault(x => x.chave == entrada.chave);
            }

            this.Enabled = false;
            SetResponse response = await DadosGerais.client.SetTaskAsync("Entradas/" + "chave-" + entrada.chave, entrada);
            this.Enabled = true;

            if (response.Exception == null)
            {
                if ((tbxChaveLancamento.Text.Trim() == "" && entrada.chaveCategoria > 0) || (entradaOld != null && entradaOld.chaveCategoria <= 0 && entrada.chaveCategoria > 0))
                {
                    await AdicionarVerbaMes(entrada);
                }

                MessageBox.Show("Entrada gravada. " + entrada.chave);

                DadosGerais.entradas = await CRUD.BuscarEntradas();
                FiltrarEntradas();
                LimparLancamento();
                AtualizarCategorias();
                return true;
            }
            else
            {
                MessageBox.Show("Erro ao gravar a entrada.\n" + response.Exception);
            }
            return false;
        }

        private async Task AdicionarVerbaMes(Entrada entrada)
        {
            Mes mes;
            if (DadosGerais.meses != null && DadosGerais.meses.Count > 0 && entrada != null)
            {
                mes = DadosGerais.meses.FirstOrDefault(x => x.chaveCategoria == entrada.chaveCategoria && entrada.mesReferencia.Month == x.mes.Month && entrada.mesReferencia.Year == x.mes.Year);
                if (mes != null)
                {
                    mes.verbaAdicional += entrada.valor;
                    await SalvarMes(mes, false);
                }
            }

        }

        private bool ValidarLancamento()
        {
            StringBuilder sb = new StringBuilder();
            if (String.IsNullOrEmpty(tbxDescricao.Text.Trim()) || tbxDescricao.Text.Trim().Length > 150)
            {
                sb.AppendLine("Preencha a descrição corretamente. Deve ter no máximo 150 caracteres.");
            }

            if (String.IsNullOrEmpty(tbxValor.Text.Trim()) || (!double.TryParse(tbxValor.Text, out double valorInicial)))
            {
                sb.AppendLine("Preencha o valor corretamente. Deve ser númerico positivo.");
            }

            if (rbtSaidas.Checked && nudQtdParcelas.Value > 1 && (String.IsNullOrEmpty(tbxValorTotal.Text.Trim()) || !double.TryParse(tbxValorTotal.Text, out double valorTotal) || valorTotal <= 0))
            {
                sb.AppendLine("Quando há compra é parcelada deve ser informado o valor total.");
            }

            if (cbxCategoria.SelectedIndex < 0 && rbtSaidas.Checked)
            {
                sb.AppendLine("Deve preencher a categoria. Verifique.");
            }

            /*
            if (nudQtdParcelas.Value > 1 && Convert.ToInt32(tbxNumParcela.Text) == 1 && !(dtpMesReferenciaLancamento.Value.Date.Year == dtpDataInicial.Value.Year && dtpMesReferenciaLancamento.Value.Month == dtpDataInicial.Value.Month))
            {
                sb.AppendLine("Para registrar uma saída parcelada é necessário informar somente a primeira parcela, ou seja, o mês de referência deve ser igual ao mês da primeira parcela.");
            }*/

            if (cbxCategoria.SelectedValue != null && (DadosGerais.meses == null || DadosGerais.meses.Count == 0 || DadosGerais.meses.Where(x => x.mes.Month == dtpMesReferenciaLancamento.Value.Month && x.mes.Year == dtpMesReferenciaLancamento.Value.Year && x.chaveCategoria == (int)cbxCategoria.SelectedValue).Count() == 0))
            {
                Categoria categoria = DadosGerais.categorias.FirstOrDefault(x => x.chave == (int)cbxCategoria.SelectedValue);
                Mes mesNovo = new();

                mesNovo.verbaOriginal = categoria.verbaPadrao;
                CriarMes(mesNovo, categoria, dtpMesReferenciaLancamento.Value);
            }

            if (sb.Length > 0)
            {
                MessageBox.Show("Campos abaixos preenchidos incorretamente:\n\n" + sb.ToString());
                return false;
            }

            return true;
        }

        private void LimparLancamento()
        {
            tbxChaveLancamento.Text = "";
            tbxDescricao.Text = "";
            tbxValor.Text = "";
            dtpDataLancamento.Text = DateTime.Now.ToShortDateString();
            cbxCategoria.SelectedIndex = -1;
            dtpMesReferenciaLancamento.Text = DateTime.Now.ToShortDateString();
            tbxNumParcela.Text = "1";
            nudQtdParcelas.Value = 1;
            dtpDataInicial.Text = DateTime.Now.ToShortDateString();
            tbxValorTotal.Text = "";
            cbxTipoSaida.SelectedIndex = 0;
            SelecionarValorComboboxContas();

            nudQtdParcelas.Enabled = true;
            dtpDataInicial.Enabled = true;
        }

        private void PreencherComboBoxContas()
        {
            cbxContas.DataSource = null;
            cbxContas.Items.Clear();

            if (DadosGerais.contas != null && DadosGerais.contas.Count > 0)
            {
                BindingList<ContaBanco> bindingList = new BindingList<ContaBanco>(DadosGerais.contas);
                cbxContas.DataSource = bindingList;

                cbxContas.DisplayMember = "descricaoConta";
                cbxContas.ValueMember = "chave";
            }
        }

        private void PreencherComboBoxCategorias()
        {
            cbxCategoria.DataSource = null;
            cbxCategoria.Items.Clear();

            if (DadosGerais.categorias != null && DadosGerais.categorias.Count > 0)
            {
                BindingList<Categoria> bindingList = new BindingList<Categoria>(DadosGerais.categorias);
                cbxCategoria.DataSource = bindingList;

                cbxCategoria.DisplayMember = "descricao";
                cbxCategoria.ValueMember = "chave";

                cbxCategoria.SelectedIndex = -1;
            }
        }

        private void SelecionarValorComboboxContas()
        {
            if (cbxContas.Items.Count > 0 && cbxContas.DataBindings != null && DadosGerais.contas != null && DadosGerais.contas.Count > 0)
            {
                if (contaSelecionada != null) cbxContas.SelectedValue = contaSelecionada.chave;
            }
        }

        private void chxCredito_CheckedChanged(object sender, EventArgs e)
        {
            FiltrarSaidas();
        }

        private void chxDinheiro_CheckedChanged(object sender, EventArgs e)
        {
            FiltrarSaidas();
        }

        private void dgvLancamentos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLancamentos.Columns[e.ColumnIndex].DataPropertyName == "tipoSaida" && e.Value != null)
            {
                if ((byte)(e.Value) == 0)
                    e.Value = "Crédito";
                else
                    e.Value = "Dinheiro";

                // Define o formato de exibição da célula como texto
                e.FormattingApplied = true;
            }

            if (dgvLancamentos.Columns[e.ColumnIndex].DataPropertyName == "chaveCategoria" && e.Value != null)
            {
                string descricao = "";
                int chave = (int)e.Value;
                if (DadosGerais.categorias != null) descricao = DadosGerais.categorias.Where(x => x.chave == chave).Select(x => x.descricao).FirstOrDefault();
                e.Value = descricao == null ? "" : descricao;

                // Define o formato de exibição da célula como texto
                e.FormattingApplied = true;
            }

            if ((dgvLancamentos.Columns[e.ColumnIndex].DataPropertyName == "data" ||
                dgvLancamentos.Columns[e.ColumnIndex].DataPropertyName == "dataInicio") &&
                e.Value != null && e.Value is DateTime)
            {
                DateTime dateValue = (DateTime)e.Value;
                e.Value = dateValue.ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }
        }

        private void dgvLancamentos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLancamentos.SelectedCells.Count > 0)
            {
                int rowIndex = dgvLancamentos.SelectedCells[0].RowIndex;

                if (rowIndex >= 0 && rowIndex < dgvLancamentos.Rows.Count)
                {
                    if (rbtSaidas.Checked) saidaSelecionada = dgvLancamentos.Rows[rowIndex].DataBoundItem as Saida;
                    else entradaSelecionada = dgvLancamentos.Rows[rowIndex].DataBoundItem as Entrada;
                }
            }
            else
            {
                saidaSelecionada = null;
                entradaSelecionada = null;
            }
        }

        private void dgvLancamentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                panelLancamento.Visible = true;
                int x = (this.ClientSize.Width - panelLancamento.Size.Width) / 2;
                int y = (this.ClientSize.Height - panelLancamento.Size.Height) / 2;
                panelLancamento.Location = new Point(x, y);

                if (rbtSaidas.Checked)
                {
                    tbxChaveLancamento.Text = saidaSelecionada.chave.ToString();
                    tbxDescricao.Text = saidaSelecionada.descricao.ToString();
                    tbxValor.Text = saidaSelecionada.valorParcela.ToString();
                    dtpDataLancamento.Text = saidaSelecionada.data.ToShortDateString();
                    dtpMesReferenciaLancamento.Text = saidaSelecionada.mesReferencia.ToShortDateString();
                    tbxNumParcela.Text = saidaSelecionada.parcela.ToString();
                    nudQtdParcelas.Value = saidaSelecionada.qtdParcelas;
                    dtpDataInicial.Text = saidaSelecionada.dataInicio.ToShortDateString();
                    tbxValorTotal.Text = saidaSelecionada.valorTotal.ToString();
                    cbxTipoSaida.SelectedIndex = saidaSelecionada.tipoSaida == 0 ? 0 : 1;
                    cbxCategoria.SelectedValue = saidaSelecionada.chaveCategoria;
                    cbxCategoria.Enabled = true;

                    nudQtdParcelas.Enabled = false;
                    dtpDataInicial.Enabled = false;
                }
                else
                {
                    tbxChaveLancamento.Text = entradaSelecionada.chave.ToString();
                    tbxDescricao.Text = entradaSelecionada.descricao.ToString();
                    tbxValor.Text = entradaSelecionada.valor.ToString();
                    dtpDataLancamento.Text = entradaSelecionada.data.ToShortDateString();
                    dtpMesReferenciaLancamento.Text = entradaSelecionada.mesReferencia.ToShortDateString();

                    if (entradaSelecionada.chaveCategoria > 0)
                    {
                        cbxCategoria.Enabled = false;
                        cbxCategoria.SelectedValue = entradaSelecionada.chaveCategoria;
                    }
                    else cbxCategoria.SelectedIndex = -1;
                }
            }
        }
        private void dtpMesReferencia_ValueChanged(object sender, EventArgs e)
        {
            FiltrarLancamentos();
        }

        private void btnLimparLancamento_Click(object sender, EventArgs e)
        {
            LimparLancamento();
        }

        private void btnFecharMntLancamento_Click(object sender, EventArgs e)
        {
            LimparLancamento();
            panelLancamento.Visible = false;
        }
        private void btnNovoLancamento_Click(object sender, EventArgs e)
        {
            LimparLancamento();
            panelLancamento.Visible = true;
            int x = (this.ClientSize.Width - panelLancamento.Size.Width) / 2;
            int y = (this.ClientSize.Height - panelLancamento.Size.Height) / 2;
            panelLancamento.Location = new Point(x, y);
        }

        private async void dgvLancamentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dgvLancamentos.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Tem certeza que deseja excluir o(s) lancamento(s) selecionado(s)?",
                                                                  "Excluir lançamento",
                                                                  MessageBoxButtons.YesNo,
                                                                  MessageBoxIcon.Question);
                    if (result == DialogResult.No) return;

                    List<DataGridViewRow> lancamentosParaDeletar = new();

                    foreach (DataGridViewRow lancamento in dgvLancamentos.SelectedRows)
                    {
                        lancamentosParaDeletar.Add(lancamento);
                    }

                    foreach (DataGridViewRow lancamento in lancamentosParaDeletar)
                    {
                        if (rbtSaidas.Checked)
                        {
                            Saida saidaSelecionada = lancamento.DataBoundItem as Saida;

                            this.Enabled = false;
                            FirebaseResponse response = await DadosGerais.client.DeleteTaskAsync("Saidas/" + "chave-" + saidaSelecionada.chave);
                            this.Enabled = true;

                            if (response.Exception != null)
                            {
                                MessageBox.Show($"Falha ao excluir a saída: {saidaSelecionada.descricao} - {saidaSelecionada.data}.");
                            }
                        }
                        else
                        {
                            Entrada entradaSelecionada = lancamento.DataBoundItem as Entrada;

                            this.Enabled = false;
                            FirebaseResponse response = await DadosGerais.client.DeleteTaskAsync("Entradas/" + "chave-" + entradaSelecionada.chave);
                            this.Enabled = true;

                            if (response.Exception != null)
                            {
                                MessageBox.Show($"Falha ao excluir a entrada: {entradaSelecionada.descricao} - {entradaSelecionada.data}.");
                            }
                        }
                    }

                    MessageBox.Show("Lançamento(s) excluído(s) com sucesso.");
                    DadosGerais.saidas = await CRUD.BuscarSaidas();
                    DadosGerais.entradas = await CRUD.BuscarEntradas();

                    FiltrarLancamentos();
                    AtualizarValorTotalConta();
                }
            }
        }

        #endregion

        #region CATEGORIAS

        private void InicializarCategorias()
        {
            PreencherValoresTodosMeses();
            PreencherSaldoTotalCategoria();

            funcoesGrid.ConfigurarGrid(dgvCategorias, bindingSourceCategorias, funcoesGrid.ColunasGridCategorias(), false);
            bindingSourceCategorias.DataSource = DadosGerais.categorias;

            funcoesGrid.ConfigurarGrid(dgvMeses, bindingSourceMeses, funcoesGrid.ColunasGridMeses(), false);
            FiltrarMeses();
            PreencherComboBoxCategorias();
        }

        private void AtualizarCategorias()
        {
            PreencherSaldoTotalCategoria();
            bindingSourceCategorias.DataSource = DadosGerais.categorias;
            dgvCategorias.Refresh();
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

        private void btnNovaCategoria_Click(object sender, EventArgs e)
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

            CriarMes(mesNovo, categoriaSelecionada, dtpMesCategoria.Value);
        }

        private void CriarMes(Mes mesNovo, Categoria categoria, DateTime mes)
        {
            if (DadosGerais.categorias == null || DadosGerais.categorias.Count == 0 || categoria == null)
            {
                MessageBox.Show("Deve criar primeiro as categorias.");
                return;
            }

            if (DadosGerais.meses == null || DadosGerais.meses.Count == 0)
            {
                mesNovo.chave = 1;

            }
            else
            {
                Mes mesOld = DadosGerais.meses.FirstOrDefault(x => x.mes.Month == mes.Month && x.mes.Year == mes.Year && x.chaveCategoria == categoria.chave);
                if (mesOld != null)
                {
                    if (mesOld.verbaOriginal == mesNovo.verbaOriginal)
                    {
                        MessageBox.Show("Mês já existe.");
                        return;
                    }
                    mesNovo.chave = mesOld.chave;
                    mesNovo.verbaAdicional = mesOld.verbaAdicional;
                }
                else
                    mesNovo.chave = DadosGerais.meses.Max(x => x.chave) + 1;
            }

            mesNovo.mes = mes.Date;
            mesNovo.chaveCategoria = categoria.chave;

            SalvarMes(mesNovo, true);
        }

        private async Task SalvarMes(Mes mesNovo, bool mostrarMensagem)
        {
            this.Enabled = false;
            SetResponse response = await DadosGerais.client.SetTaskAsync("Meses/" + "chave-" + mesNovo.chave.ToString(), mesNovo);
            this.Enabled = true;

            if (response.Exception == null)
            {
                if (mostrarMensagem) MessageBox.Show("Mes gravado.");
                LimparMes();

                DadosGerais.meses = await CRUD.BuscarMeses();
                AtualizarCategorias();
                FiltrarMeses();
            }
            else
            {
                MessageBox.Show("Erro ao gravar mês.\n" + response.Exception);
            }
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

                PreencherComboBoxCategorias();
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

        private void geralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.telaGeral = new();
            Formularios.telaGeral.Show();
            this.Hide();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void mesesFuturoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.telaMesesFuturo = new();
            Formularios.telaMesesFuturo.WindowState = this.WindowState;
            Formularios.telaMesesFuturo.Show();
            this.Hide();
        }
    }
}
