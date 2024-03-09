using OrganizacaoFinanceira.Objetos;
using OrganizacaoFinanceira.Recursos;
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

namespace OrganizacaoFinanceira
{
    public partial class TelaPrincipal : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "WIjBhJwJ5rlUBzzPRFEkvY3Ib35hKZpbWHkTqO9n",
            BasePath = "https://organizacaofinanceira-9160c-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        string mensagemValorAtualConta = "";

        BindingSource bindingSourceContas = new BindingSource();
        BindingSource bindingSourceSaidas = new BindingSource();
        BindingSource bindingSourceEntradas = new BindingSource();
        BindingSource bindingSourceCategorias = new BindingSource();
        BindingSource bindingSourceMeses = new BindingSource();
        BindingSource bindingSourceLancRecorrentes = new BindingSource();
        BindingSource bindingSourceMesesFuturos = new BindingSource();

        SortableBindingList<ContaBanco> contas;
        SortableBindingList<Saida> saidas;
        SortableBindingList<Entrada> entradas;
        SortableBindingList<Categoria> categorias;
        SortableBindingList<Mes> meses;
        SortableBindingList<LancamentoRecorrente> lancamentosRecorrentes;
        List<MesFuturo> mesesFuturos;

        ContaBanco contaSelecionada;
        Saida saidaSelecionada;
        Entrada entradaSelecionada;
        Categoria categoriaSelecionada;
        Mes mesSelecionado;
        LancamentoRecorrente lancRecorrenteSelecionado;

        SortableBindingList<Saida> saidasDaConta;
        SortableBindingList<Entrada> entradasDaConta;
        SortableBindingList<Mes> mesesDaCategoria;

        FuncoesGrid funcoesGrid = new();

        public TelaPrincipal()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            rbtFiltroSaidaLancRecorrente.Checked = true;
            rbtLancamentoFuturo.Checked = true;
            panelLancRecorrente.BringToFront();
            panelLancamento.BringToFront();
        }

        private async void TelaPrincipal_Load(object sender, EventArgs e)
        {
            client = new FirebaseClient(config);
            if (client == null)
            {
                MessageBox.Show("Falha de conexão com o servidor!");
                return;
            }

            InicializarDatas();

            await BuscarTodosDados();

            InicializarContas();
            InicializarCategorias();
            InicializarLancamentosRecorrentes();
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

        private async Task BuscarTodosDados()
        {
            contas = await BuscarContas();
            saidas = await BuscarSaidas();
            entradas = await BuscarEntradas();
            meses = await BuscarMeses();
            categorias = await BuscarCategorias();
            lancamentosRecorrentes = await BuscarLancamentosRecorrentes();
        }

        private void TelaPrincipal_Resize(object sender, EventArgs e)
        {
            int x = (this.ClientSize.Width - panelLancamento.Size.Width) / 2;
            int y = (this.ClientSize.Height - panelLancamento.Size.Height) / 2;
            panelLancamento.Location = new Point(x, y);

            x = (this.ClientSize.Width - panelLancRecorrente.Size.Width) / 2;
            y = (this.ClientSize.Height - panelLancRecorrente.Size.Height) / 2;
            panelLancRecorrente.Location = new Point(x, y);
        }

        #region ATUALIZAR BANCO

        private async Task AtualizarSaidasBancoDados()
        {
            List<Task<SetResponse>> tasks = new List<Task<SetResponse>>();

            foreach (Saida saida in saidas)
            {
                // Inicie a tarefa e adicione à lista de tarefas
                Task<SetResponse> task = client.SetTaskAsync("Saidas/chave-" + saida.chave, saida);
                tasks.Add(task);
            }

            // Aguarde todas as tarefas serem concluídas
            await Task.WhenAll(tasks);

            MessageBox.Show("Atualização concluída");
            saidas = await BuscarSaidas();
        }

        #endregion

        #region CONTAS

        private void InicializarContas()
        {
            AtualizarValorTotalConta();
            funcoesGrid.ConfigurarGrid(dgvContas, bindingSourceContas, funcoesGrid.ColunasGridContas(), false);
            dgvContas.Columns[3].ToolTipText = mensagemValorAtualConta;

            bindingSourceContas.DataSource = contas;

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
            foreach (ContaBanco conta in contas)
            {
                saidasConta = saidas.Where(x => x.chaveConta == conta.chave && DataMenorIgual(x.mesReferencia.Date, DateTime.Now.Date)).Sum(x => x.valorParcela);
                entradasConta = entradas.Where(x => x.chaveConta == conta.chave).Sum(x => x.valor);

                creditoMesAtual = saidas.Where(x => x.chaveConta == conta.chave && x.tipoSaida == 0 && DatasIguais(x.mesReferencia.Date, DateTime.Now.Date)).Sum(x => x.valorParcela);
                saidasConta -= creditoMesAtual;

                conta.valorAtual = conta.valorInicial - saidasConta + entradasConta;
            }
            dgvContas.Refresh();
            InicializarMesesFuturos();
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

        private async Task<SortableBindingList<ContaBanco>> BuscarContas()
        {
            try
            {
                List<ContaBanco> contasAux;
                Dictionary<string, ContaBanco> chavesContas;

                FirebaseResponse firebaseResponse = await client.GetTaskAsync("Contas");
                if (firebaseResponse.Body == "null") return new SortableBindingList<ContaBanco>();

                chavesContas = firebaseResponse.ResultAs<Dictionary<string, ContaBanco>>();
                contasAux = chavesContas.Select(x => x.Value).ToList();

                return new SortableBindingList<ContaBanco>(contasAux);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar as contas.\n\n" + ex.Message);
                return new SortableBindingList<ContaBanco>(); ;
            }

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
                        if (saidas.Where(x => x.chaveConta == contaSelecionada.chave).Count() > 0 || entradas.Where(x => x.chaveConta == contaSelecionada.chave).Count() > 0)
                        {
                            MessageBox.Show("Para excluir a conta deve excluir todas as entradas e saídas vinculadas");
                            return;
                        }

                        // Realiza a operação de exclusão no banco de dados Firebase
                        FirebaseResponse response = await client.DeleteTaskAsync("Contas/" + "chave-" + contaSelecionada.chave);

                        // Verifica se a exclusão foi bem-sucedida
                        if (response.Exception == null)
                        {
                            MessageBox.Show("Conta excluída com sucesso.");

                            // Atualiza a lista de contas exibida na interface
                            contas = await BuscarContas();
                            bindingSourceContas.DataSource = contas;
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
                if (contas != null && contas.Count > 0)
                    conta.chave = contas.Max(x => x.chave) + 1;
                else
                    conta.chave = 1;
            }
            else
                conta.chave = Convert.ToInt32(tbxChaveConta.Text);

            if (contas.Any(x => x.chave == conta.chave))
            {
                ContaBanco contaOld = contas.FirstOrDefault(x => x.chave == conta.chave);
                conta.dataCriacao = contaOld.dataCriacao;
                conta.dataAlteracao = DateTime.Now;
            }
            else
            {
                conta.dataCriacao = DateTime.Now;
                conta.dataAlteracao = DateTime.Now;
            }

            SetResponse response = await client.SetTaskAsync("Contas/" + "chave-" + conta.chave, conta);

            ContaBanco result = response.ResultAs<ContaBanco>();

            MessageBox.Show("Conta gravada. " + result.chave);

            contas = await BuscarContas();
            bindingSourceContas.DataSource = contas;
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

                if (entradas == null) entradas = await BuscarEntradas();

                saidasDaConta = null;
                bindingSourceSaidas.DataSource = saidasDaConta;
                FiltrarEntradas();
            }
        }

        private void FiltrarSaidas()
        {
            if (contas == null || contas.Count == 0 || saidas == null) return;

            List<Saida> saidasAux;

            if (contaSelecionada != null)
            {
                saidasAux = saidas.Where(x => x.chaveConta == contaSelecionada.chave && x.mesReferencia.Year == dtpMesReferencia.Value.Year && x.mesReferencia.Month == dtpMesReferencia.Value.Month).ToList();

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

        private async Task<SortableBindingList<Saida>> BuscarSaidas()
        {
            try
            {
                List<Saida> saidasAux;
                Dictionary<string, Saida> chavesSaidas;

                FirebaseResponse firebaseResponse = await client.GetTaskAsync("Saidas");
                if (firebaseResponse.Body == "null") return new SortableBindingList<Saida>();

                chavesSaidas = firebaseResponse.ResultAs<Dictionary<string, Saida>>();
                saidasAux = chavesSaidas.Select(x => x.Value).ToList();

                return new SortableBindingList<Saida>(saidasAux);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar as saídas.\n\n" + ex.Message);
                return new SortableBindingList<Saida>();
            }

        }

        private async Task<SortableBindingList<Entrada>> BuscarEntradas()
        {
            try
            {
                List<Entrada> entradasAux;
                Dictionary<string, Entrada> chavesEntradas;

                FirebaseResponse firebaseResponse = await client.GetTaskAsync("Entradas");
                if (firebaseResponse.Body == "null") return new SortableBindingList<Entrada>();

                chavesEntradas = firebaseResponse.ResultAs<Dictionary<string, Entrada>>();
                entradasAux = chavesEntradas.Select(x => x.Value).ToList();

                return new SortableBindingList<Entrada>(entradasAux);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar as entradas.\n\n" + ex.Message);
                return new SortableBindingList<Entrada>();
            }

        }



        private void rbtSaidas_CheckedChanged(object sender, EventArgs e)
        {
            FiltrarLancamentos();
        }

        private void FiltrarEntradas()
        {
            if (contas == null || contas.Count == 0 || entradas == null) return;

            List<Entrada> entradaAux;

            if (contaSelecionada != null)
            {
                entradaAux = entradas.Where(x => x.chaveConta == contaSelecionada.chave && x.mesReferencia.Year == dtpMesReferencia.Value.Year && x.mesReferencia.Month == dtpMesReferencia.Value.Month).ToList();

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
                if (saidas != null && saidas.Count > 0)
                    saida.chave = saidas.Max(x => x.chave) + 1;
                else
                    saida.chave = 1;
            }
            else
            {
                saidaOld = saidas.FirstOrDefault(x => x.chave == Convert.ToInt32(tbxChaveLancamento.Text));
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

            SetResponse response = await client.SetTaskAsync("Saidas/" + "chave-" + saida.chave, saida);

            if (response.Exception == null)
            {
                if (saidaOld == null && saida.qtdParcelas > 1) await CriarParcelas(saida);

                MessageBox.Show("Saída gravada. " + saida.chave);

                saidas = await BuscarSaidas();
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

                SetResponse response = await client.SetTaskAsync("Saidas/" + chave, parcela);
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
            entrada.chaveCategoria = cbxCategoria.SelectedValue == null? 0 : (int)cbxCategoria.SelectedValue;
            entrada.mesReferencia = dtpMesReferenciaLancamento.Value;
            entrada.chaveConta = conta.chave;
            entrada.valor = Convert.ToDouble(tbxValor.Text);

            if (entradas != null && entradas.Count > 0 && entradas.Any(x => x.chave == entrada.chave))
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
                if (entradas != null && entradas.Count > 0)
                    entrada.chave = entradas.Max(x => x.chave) + 1;
                else entrada.chave = 1;
            }
            else
            {
                entrada.chave = Convert.ToInt32(tbxChaveLancamento.Text);
                entradaOld = entradas.FirstOrDefault(x => x.chave == entrada.chave);
            }


            SetResponse response = await client.SetTaskAsync("Entradas/" + "chave-" + entrada.chave, entrada);

            if (response.Exception == null)
            {
                if ((tbxChaveLancamento.Text.Trim() == "" && entrada.chaveCategoria > 0) || (entradaOld != null && entradaOld.chaveCategoria <= 0 && entrada.chaveCategoria > 0))
                {
                    await AdicionarVerbaMes(entrada);
                }

                MessageBox.Show("Entrada gravada. " + entrada.chave);

                entradas = await BuscarEntradas();
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
            if (meses != null && meses.Count > 0 && entrada != null)
            {
                mes = meses.FirstOrDefault(x => x.chaveCategoria == entrada.chaveCategoria && entrada.mesReferencia.Month == x.mes.Month && entrada.mesReferencia.Year == x.mes.Year);
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

            if (cbxCategoria.SelectedValue != null && (meses == null || meses.Count == 0 || meses.Where(x => x.mes.Month == dtpMesReferenciaLancamento.Value.Month && x.mes.Year == dtpMesReferenciaLancamento.Value.Year && x.chaveCategoria == (int)cbxCategoria.SelectedValue).Count() == 0))
            {
                Categoria categoria = categorias.FirstOrDefault(x => x.chave == (int)cbxCategoria.SelectedValue);
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

            if (contas != null && contas.Count > 0)
            {
                BindingList<ContaBanco> bindingList = new BindingList<ContaBanco>(contas);
                cbxContas.DataSource = bindingList;

                cbxContas.DisplayMember = "descricaoConta";
                cbxContas.ValueMember = "chave";
            }
        }

        private void PreencherComboBoxCategorias()
        {
            cbxCategoria.DataSource = null;
            cbxCategoria.Items.Clear();

            if (categorias != null && categorias.Count > 0)
            {
                BindingList<Categoria> bindingList = new BindingList<Categoria>(categorias);
                cbxCategoria.DataSource = bindingList;

                cbxCategoria.DisplayMember = "descricao";
                cbxCategoria.ValueMember = "chave";

                cbxCategoria.SelectedIndex = -1;
            }

            PreencherComboBoxCategoriasLancRecorrente();
        }

        private void PreencherComboBoxCategoriasLancRecorrente()
        {
            cbxCategoriaLancRecorrente.DataSource = null;
            cbxCategoriaLancRecorrente.Items.Clear();

            if (categorias != null && categorias.Count > 0)
            {
                BindingList<Categoria> bindingList = new BindingList<Categoria>(categorias);
                cbxCategoriaLancRecorrente.DataSource = bindingList;

                cbxCategoriaLancRecorrente.DisplayMember = "descricao";
                cbxCategoriaLancRecorrente.ValueMember = "chave";

                cbxCategoriaLancRecorrente.SelectedIndex = -1;
            }
        }

        private void SelecionarValorComboboxContas()
        {
            if (cbxContas.Items.Count > 0 && cbxContas.DataBindings != null && contas != null && contas.Count > 0)
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
                if (categorias != null) descricao = categorias.Where(x => x.chave == chave).Select(x => x.descricao).FirstOrDefault();
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

                            FirebaseResponse response = await client.DeleteTaskAsync("Saidas/" + "chave-" + saidaSelecionada.chave);

                            if (response.Exception != null)
                            {
                                MessageBox.Show($"Falha ao excluir a saída: {saidaSelecionada.descricao} - {saidaSelecionada.data}.");
                            }
                        }
                        else
                        {
                            Entrada entradaSelecionada = lancamento.DataBoundItem as Entrada;

                            FirebaseResponse response = await client.DeleteTaskAsync("Entradas/" + "chave-" + entradaSelecionada.chave);

                            if (response.Exception != null)
                            {
                                MessageBox.Show($"Falha ao excluir a entrada: {entradaSelecionada.descricao} - {entradaSelecionada.data}.");
                            }
                        }
                    }

                    MessageBox.Show("Lançamento(s) excluído(s) com sucesso.");
                    saidas = await BuscarSaidas();
                    entradas = await BuscarEntradas();

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
            bindingSourceCategorias.DataSource = categorias;

            funcoesGrid.ConfigurarGrid(dgvMeses, bindingSourceMeses, funcoesGrid.ColunasGridMeses(), false);
            FiltrarMeses();
            PreencherComboBoxCategorias();
        }

        private void AtualizarCategorias()
        {
            PreencherSaldoTotalCategoria();
            bindingSourceCategorias.DataSource = categorias;
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

                    if (saidas.Any(x => x.chaveCategoria == categoriaSelecionada.chave) || entradas.Any(x => x.chaveCategoria == categoriaSelecionada.chave) || lancamentosRecorrentes.Any(x => x.chaveCategoria == categoriaSelecionada.chave))
                    {
                        MessageBox.Show("Para excluir uma categoria não deve ter saídas, entradas ou lançamentos recorrentes vinculados. Verifique.");
                        return;
                    }

                    // Se o usuário confirmar a exclusão, exclua a conta
                    if (result == DialogResult.Yes)
                    {
                        // Realiza a operação de exclusão no banco de dados Firebase
                        FirebaseResponse response = await client.DeleteTaskAsync("Categorias/" + "chave-" + categoriaSelecionada.chave);

                        // Verifica se a exclusão foi bem-sucedida
                        if (response.Exception == null)
                        {
                            MessageBox.Show("Categoria excluída com sucesso.");

                            // Atualiza a lista de contas exibida na interface
                            categorias = await BuscarCategorias();
                            funcoesGrid.ConfigurarGrid(dgvCategorias, bindingSourceCategorias, funcoesGrid.ColunasGridCategorias(), false);
                            bindingSourceCategorias.DataSource = categorias;

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
            foreach (Categoria categoria in categorias)
            {
                verbaTotal = meses.Where(x => x.chaveCategoria == categoria.chave && DataMenorIgual(x.mes.Date, DateTime.Now.Date)).Sum(x => x.verbaMes);
                categoria.saldoTotal = verbaTotal - (saidas == null ? 0 : saidas.Where(x => x.chaveCategoria == categoria.chave).Sum(x => x.valorParcela));
            }
        }

        private void PreencherValoresTodosMeses()
        {
            foreach (Mes mes in meses)
            {
                PreencherValoresMes(mes);
            }
        }

        private void FiltrarMeses()
        {
            if (categorias == null || categorias.Count == 0 || meses == null || categoriaSelecionada == null) return;

            List<Mes> mesesAux;

            mesesAux = meses.Where(x => x.chaveCategoria == categoriaSelecionada.chave).ToList();
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

            if (saidas != null)
            {
                saidasCategoria = saidas.Where(x => x.chaveCategoria == mes.chaveCategoria).ToList();
                saidasMes = saidasCategoria.Where(x => x.mesReferencia.Month == mes.mes.Month && x.mesReferencia.Year == mes.mes.Year).ToList();
                mes.saldoMes = mes.verbaMes - saidasMes.Sum(x => x.valorParcela);
            }
        }

        private async Task<SortableBindingList<Mes>> BuscarMeses()
        {
            try
            {
                List<Mes> mesesAux;
                Dictionary<string, Mes> chavesMeses;

                FirebaseResponse firebaseResponse = await client.GetTaskAsync("Meses");
                if (firebaseResponse.Body == "null") return new SortableBindingList<Mes>();

                chavesMeses = firebaseResponse.ResultAs<Dictionary<string, Mes>>();
                mesesAux = chavesMeses.Select(x => x.Value).ToList();

                return new SortableBindingList<Mes>(mesesAux);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar os meses.\n\n" + ex.Message);
                return new SortableBindingList<Mes>();
            }

        }

        private async Task<SortableBindingList<Categoria>> BuscarCategorias()
        {
            try
            {
                List<Categoria> categoriasAux;
                Dictionary<string, Categoria> chavesCategorias;

                FirebaseResponse firebaseResponse = await client.GetTaskAsync("Categorias");
                if (firebaseResponse.Body == "null") return new SortableBindingList<Categoria>();

                chavesCategorias = firebaseResponse.ResultAs<Dictionary<string, Categoria>>();
                categoriasAux = chavesCategorias.Select(x => x.Value).ToList();

                return new SortableBindingList<Categoria>(categoriasAux);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar as categorias.\n\n" + ex.Message);
                return new SortableBindingList<Categoria>();
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
            if (categorias == null || categorias.Count == 0 || categoria == null)
            {
                MessageBox.Show("Deve criar primeiro as categorias.");
                return;
            }

            if (meses == null || meses.Count == 0)
            {
                mesNovo.chave = 1;

            }
            else
            {
                Mes mesOld = meses.FirstOrDefault(x => x.mes.Month == mes.Month && x.mes.Year == mes.Year && x.chaveCategoria == categoria.chave);
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
                    mesNovo.chave = meses.Max(x => x.chave) + 1;
            }

            mesNovo.mes = mes.Date;
            mesNovo.chaveCategoria = categoria.chave;

            SalvarMes(mesNovo, true);
        }

        private async Task SalvarMes(Mes mesNovo, bool mostrarMensagem)
        {
            SetResponse response = await client.SetTaskAsync("Meses/" + "chave-" + mesNovo.chave.ToString(), mesNovo);

            if (response.Exception == null)
            {
                if (mostrarMensagem) MessageBox.Show("Mes gravado.");
                LimparMes();

                meses = await BuscarMeses();
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
                if (categorias == null || categorias.Count == 0)
                    categoriaNova.chave = 1;
                else
                    categoriaNova.chave = categorias.Max(x => x.chave) + 1;
            }

            SetResponse response = await client.SetTaskAsync("Categorias/" + "chave-" + categoriaNova.chave.ToString(), categoriaNova);

            if (response.Exception == null)
            {
                MessageBox.Show("Categoria gravada.");

                categorias = await BuscarCategorias();
                funcoesGrid.ConfigurarGrid(dgvCategorias, bindingSourceCategorias, funcoesGrid.ColunasGridCategorias(), false);
                bindingSourceCategorias.DataSource = categorias;

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

        #region LANÇAMENTOS RECORRENTES

        private void InicializarLancamentosRecorrentes()
        {
            funcoesGrid.ConfigurarGrid(dgvLancamentosRecorrentes, bindingSourceLancRecorrentes, funcoesGrid.ColunasGridLancamentosRecorrentes(), false);
            bindingSourceLancRecorrentes.DataSource = lancamentosRecorrentes;
            FiltrarLancamentosRecorrentes();
        }

        private async Task<SortableBindingList<LancamentoRecorrente>> BuscarLancamentosRecorrentes()
        {
            try
            {
                List<LancamentoRecorrente> lancRecorrentesAux;
                Dictionary<string, LancamentoRecorrente> chavesLancRecorrentes;

                FirebaseResponse firebaseResponse = await client.GetTaskAsync("LancamentosRecorrentes");
                if (firebaseResponse.Body == "null") return new SortableBindingList<LancamentoRecorrente>();

                chavesLancRecorrentes = firebaseResponse.ResultAs<Dictionary<string, LancamentoRecorrente>>();
                lancRecorrentesAux = chavesLancRecorrentes.Select(x => x.Value).ToList();

                return new SortableBindingList<LancamentoRecorrente>(lancRecorrentesAux);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar os lançamentos recorrentes.\n\n" + ex.Message);
                return new SortableBindingList<LancamentoRecorrente>();
            }

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

            if (tbxIdLancRecorrente.Text.Length > 0)
            {
                lancRecorrenteNovo.chave = Convert.ToInt32(tbxIdLancRecorrente.Text);
            }
            else
            {
                if (lancamentosRecorrentes == null || lancamentosRecorrentes.Count == 0)
                    lancRecorrenteNovo.chave = 1;
                else
                    lancRecorrenteNovo.chave = lancamentosRecorrentes.Max(x => x.chave) + 1;
            }

            SetResponse response = await client.SetTaskAsync("LancamentosRecorrentes/" + "chave-" + lancRecorrenteNovo.chave.ToString(), lancRecorrenteNovo);

            if (response.Exception == null)
            {
                MessageBox.Show("Lançamento recorrente gravado.");

                lancamentosRecorrentes = await BuscarLancamentosRecorrentes();
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
            cbxCategoria.SelectedIndex = -1;
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
                if (lancamentosRecorrentes != null) descricao = categorias.Where(x => x.chave == chave).Select(x => x.descricao).FirstOrDefault();
                e.Value = descricao == null ? "" : descricao;

                // Define o formato de exibição da célula como texto
                e.FormattingApplied = true;
            }

            if (dgvLancamentosRecorrentes.Columns[e.ColumnIndex].DataPropertyName == "tipoLancamento" && e.Value != null)
            {
                e.Value = (byte)e.Value == 0 ? "Saída" : "Entrada";
                e.FormattingApplied = true;
            }
        }
        private void rbtFiltroSaidaLancRecorrente_CheckedChanged(object sender, EventArgs e)
        {
            FiltrarLancamentosRecorrentes();
        }

        private void FiltrarLancamentosRecorrentes()
        {
            if (lancamentosRecorrentes == null) return;
            SortableBindingList<LancamentoRecorrente> lancamentosFiltro = new(lancamentosRecorrentes.Where(x => x.tipoLancamento == (rbtFiltroSaidaLancRecorrente.Checked ? 0 : 1)).ToList());
            bindingSourceLancRecorrentes.DataSource = lancamentosFiltro;
            dgvLancamentosRecorrentes.Columns[2].Visible = rbtFiltroSaidaLancRecorrente.Checked;
            InicializarMesesFuturos();
        }

        #endregion

        #region MESES FUTUROS

        private void InicializarMesesFuturos()
        {
            mesesFuturos = new();
            double valorAtualContas = contas.Sum(x => x.valorAtual);

            //Feito isso, pois o valor atual não considera as compras no crédito do mês atual, pois ainda não foram pagas.
            if (saidas!=null && saidas.Count>0) {
                valorAtualContas -= saidas.Where(x => x.tipoSaida == 0 && x.mesReferencia.Month == DateTime.Now.Month && x.mesReferencia.Year == DateTime.Now.Year).Sum(x => x.valorParcela);
            }

            if (rbtLancamentoFuturo.Checked)            
            {
                double entradasTotaisRecorrente = lancamentosRecorrentes.Where(x => x.tipoLancamento == 1).Sum(x => x.valor);
                double saidasParceladas;
                double entradasMesAtual;
                for (int i = 0; i < 11; i++)
                {
                    mesesFuturos.Add(new MesFuturo());
                    mesesFuturos[i].mes = DateTime.Now.AddMonths(i+1);

                    saidasParceladas = 0;
                    entradasMesAtual = 0;

                    if (saidas != null && saidas.Count > 0)
                    {
                        saidasParceladas = saidas.Where(x => x.qtdParcelas > 1 && x.mesReferencia.Month == mesesFuturos[i].mes.Month && x.mesReferencia.Year == mesesFuturos[i].mes.Year).Sum(x => x.valorParcela);
                    }

                    if (entradas != null && entradas.Count > 0)
                    {
                        entradasMesAtual = entradas.Where(x => x.mesReferencia.Month == mesesFuturos[i].mes.Month && x.mesReferencia.Year == mesesFuturos[i].mes.Year).Sum(x => x.valor);
                    }

                    double saidatotal = 0;
                    double saidasCategoria;
                    double saidasMesCategoria;
                    foreach (Categoria categoria in categorias)
                    {
                        saidatotal += lancamentosRecorrentes.Where(x => x.tipoLancamento == 0 && x.obrigatorio && x.chaveCategoria == categoria.chave).Sum(x => x.valor);
                        saidasCategoria = lancamentosRecorrentes.Where(x => x.tipoLancamento == 0 && !x.obrigatorio && x.chaveCategoria == categoria.chave).Sum(x => x.valor);
                        saidasMesCategoria = saidas.Where(x => x.tipoSaida == 0 && x.chaveCategoria == categoria.chave && x.mesReferencia.Month == mesesFuturos[i].mes.Month && x.mesReferencia.Year == mesesFuturos[i].mes.Year).Sum(x => x.valorParcela);

                        if (saidasMesCategoria >= saidasCategoria)
                        {
                            saidatotal += saidasMesCategoria;
                        }
                        else
                        {
                            saidatotal += saidasCategoria - saidasMesCategoria;
                        }
                    }

                    mesesFuturos[i].saidasTotais = saidatotal;
                    mesesFuturos[i].entradasTotais = entradasTotaisRecorrente;
                    mesesFuturos[i].saidasParceladas = saidasParceladas;
                    mesesFuturos[i].saldoGeral = valorAtualContas + entradasTotaisRecorrente - saidatotal - entradasMesAtual;
                    valorAtualContas = mesesFuturos[i].saldoGeral;
                }
            }

            funcoesGrid.ConfigurarGrid(dgvMesesFuturos, bindingSourceMesesFuturos, funcoesGrid.ColunasGridMesesFuturos(), false);
            bindingSourceMesesFuturos.DataSource = mesesFuturos;

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
        }

        #endregion

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
                        FirebaseResponse response = await client.DeleteTaskAsync("LancamentosRecorrentes/" + "chave-" + lancRecorrenteSelecionado.chave);

                        if (response.Exception == null)
                        {
                            MessageBox.Show("Lançamento recorrente excluído com sucesso.");

                            lancamentosRecorrentes = await BuscarLancamentosRecorrentes();
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
    }
}
