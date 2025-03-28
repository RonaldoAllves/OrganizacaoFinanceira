using FireSharp.Response;
using OrganizacaoFinanceira.Dados;
using OrganizacaoFinanceira.Objetos;
using OrganizacaoFinanceira.Recursos;
using OrganizacaoFinanceira.Telas;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace OrganizacaoFinanceira
{
    public partial class TelaPrincipal : Form
    {
        CRUD CRUD = new CRUD();
        FuncoesGrid funcoesGrid = new();
        LayoutSplitterContainer layoutSplitter = new();

        string mensagemValorAtualConta = "";
        bool podeFiltrar = true;

        BindingSource bindingSourceContas = new BindingSource();
        BindingSource bindingSourceSaidas = new BindingSource();
        BindingSource bindingSourceEntradas = new BindingSource();

        ContaBanco contaSelecionada;
        Saida saidaSelecionada;
        Entrada entradaSelecionada;

        SortableBindingList<Saida> saidasDaConta;
        SortableBindingList<Entrada> entradasDaConta;

        public TelaPrincipal()
        {
            InitializeComponent();

            ControlesVisiveis(false);
            this.WindowState = FormWindowState.Maximized;
            LayoutColor.EstiloLayout(this);
        }

        private async void TelaPrincipal_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            podeFiltrar = false;

            mensagemValorAtualConta = "Considera o valor inicial da conta adicionando todas as entradas e retirando todas as saídas já existenste até o mês atual desconsiderando as compras no crédito do mês atual.\n" +
                                      "O valor atual já considera que foi pago a fatura do último mês fechado, ou seja, caso a fatura ainda não tenha sido paga, pode haver diferença do valor atual mostrado com o valor atual na conta.";

            //await CRUD.BuscarTodosDados(false);
            InicializarDatas();
            InicializarContas();            

            ControlesVisiveis(true);

            funcoesGrid.AjustarTitulo(dgvContas, lblTituloContas, "Contas");
            funcoesGrid.AjustarTitulo(dgvLancamentos, lblTituloSaidas, "Saídas da conta");

            podeFiltrar = true;
            FiltrarSaidas();

            splitContainer1.SplitterWidth = 3;            
            splitContainer1.Paint += (s, pe) => layoutSplitter.DesenharLinhaDivisoria(splitContainer1, pe);
            splitContainer1.Panel1.Paint += (s, pe) => layoutSplitter.PintarPainelComBordasArredondadas(splitContainer1.Panel1, pe);
            splitContainer1.Panel2.Paint += (s, pe) => layoutSplitter.PintarPainelComBordasArredondadas(splitContainer1.Panel2, pe);
            splitContainer1.MouseEnter += (s, e) => layoutSplitter.ExibirLinhaDivisoria(splitContainer1);
            splitContainer1.MouseLeave += (s, e) => layoutSplitter.DiminuirLinhaDivisoria(splitContainer1);

            RedefinirTamanhoGrids();
            this.Enabled = true;
        }

        private void ControlesVisiveis(bool visible)
        {
            foreach (Control control in this.Controls)
            {
                if (control is not Panel)
                {
                    control.Visible = visible;
                }
            }
        }

        private void InicializarDatas()
        {
            dtpMesReferencia.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpMesReferencia.CustomFormat = "MM/yyyy";
            dtpMesReferencia.ShowUpDown = true;
        }

        private void TelaPrincipal_Resize(object sender, EventArgs e)
        {
            RedefinirTamanhoGrids();
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
            CRUD.AtualizarValorTotalConta();
            dgvContas.Refresh();
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

            if (rbtSaidas.Checked) FiltrarLancamentosSaida();
            else FiltrarLancamentosEntrada();
        }

        #endregion

        #region LANÇAMENTOS CONTA

        private void InicializarLancamentos()
        {
            rbtSaidas.Checked = true;

            if (rbtSaidas.Checked)
            {
                lblTituloSaidas.Text = "Saídas da conta selecionada";
                funcoesGrid.ConfigurarGrid(dgvLancamentos, bindingSourceSaidas, funcoesGrid.ColunasGridSaidas(), false);

                FiltrarSaidas();

                chxCredito.Checked = true;
                chxDinheiro.Checked = false;                
            }
            else
            {
                lblTituloSaidas.Text = "Entradas da conta selecionada";
                funcoesGrid.ConfigurarGrid(dgvLancamentos, bindingSourceEntradas, funcoesGrid.ColunasGridEntradas(), false);

                FiltrarEntradas();
            }
        }

        private async void FiltrarLancamentosSaida()
        {
            chxCredito.Visible = rbtSaidas.Checked;
            chxDinheiro.Visible = rbtSaidas.Checked;

            if (rbtSaidas.Checked)
            {
                lblTituloSaidas.Text = "Saídas da conta selecionada";
                funcoesGrid.ConfigurarGrid(dgvLancamentos, bindingSourceSaidas, funcoesGrid.ColunasGridSaidas(), false);

                entradasDaConta = null;
                bindingSourceEntradas.DataSource = entradasDaConta;
                FiltrarSaidas();
            }
        }

        private async void FiltrarLancamentosEntrada()
        {
            chxCredito.Visible = rbtSaidas.Checked;
            chxDinheiro.Visible = rbtSaidas.Checked;

            if (!rbtSaidas.Checked)
            {
                lblTituloSaidas.Text = "Entradas da conta selecionada";

                funcoesGrid.ConfigurarGrid(dgvLancamentos, bindingSourceEntradas, funcoesGrid.ColunasGridEntradas(), false);

                if (DadosGerais.entradas == null) DadosGerais.entradas = await CRUD.BuscarEntradas();

                saidasDaConta = null;
                bindingSourceSaidas.DataSource = saidasDaConta;
                FiltrarEntradas();
            }
        }

        private void FiltrarSaidas()
        {
            if (!podeFiltrar) return;
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
        }

        private void rbtSaidas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtSaidas.Checked) FiltrarLancamentosSaida();
            else FiltrarLancamentosEntrada();

            funcoesGrid.ReajustarTamanhoTitulo(dgvLancamentos, lblTituloSaidas);
        }

        private void FiltrarEntradas()
        {
            if (!podeFiltrar) return;
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
            tbxTotalLancamento.Text = entradasDaConta.Sum(x => x.valor).ToString("N2");
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

            if (dgvLancamentos.Columns[e.ColumnIndex].DataPropertyName == "gastoObrigatorio" && e.Value != null)
            {
                if ((bool)(e.Value))
                    e.Value = "Sim";
                else
                    e.Value = "Não";

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

            if (dgvLancamentos.Columns[e.ColumnIndex].DataPropertyName == "chaveCategoriaMesFuturo" && e.Value != null)
            {
                string descricao = "";
                int chave = (int)e.Value;
                if (DadosGerais.categorias != null) descricao = DadosGerais.lancamentosRecorrentes.Where(x => x.tipoLancamento == 0 && x.chave == chave).Select(x => x.descricao).FirstOrDefault();
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

            TotalSelecionados();
        }

        private void TotalSelecionados()
        {
            if (dgvLancamentos.SelectedRows.Count > 0)
            {
                int columnIndex = 1;
                double soma = 0;
                foreach (DataGridViewRow row in dgvLancamentos.SelectedRows)
                {
                    soma += Convert.ToDouble(row.Cells[columnIndex].Value);
                }

                tbxTotalSelecionados.Text = soma.ToString("N2");
            }
            else
            {
                tbxTotalSelecionados.Text = "";
            }
        }

        private void dgvLancamentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FormAddLancamento formAddLancamento = new FormAddLancamento();
                formAddLancamento.Owner = this;
                formAddLancamento.editar = true;
                formAddLancamento.contaSelecionada = contaSelecionada;

                if (rbtSaidas.Checked)
                {
                    formAddLancamento.tipoSaida = true;
                    formAddLancamento.saidaSelecionada = saidaSelecionada;
                }
                else
                {
                    formAddLancamento.tipoSaida = false;
                    formAddLancamento.entradaSelecionada = entradaSelecionada;
                }
                if (formAddLancamento.ShowDialog() == DialogResult.OK)
                {
                    AtualizarValorTotalConta();
                    if (rbtSaidas.Checked) FiltrarSaidas();
                    else FiltrarEntradas();                    
                }
            }
        }
        private void dtpMesReferencia_ValueChanged(object sender, EventArgs e)
        {
            // Obtém o valor atual do DateTimePicker
            DateTime currentDate = dtpMesReferencia.Value;

            // Ajusta a data para o primeiro dia do mês atual
            DateTime adjustedDate = new DateTime(currentDate.Year, currentDate.Month, 1);

            // Se o dia atual for diferente do dia ajustado, atualize a data
            if (currentDate != adjustedDate)
            {
                dtpMesReferencia.Value = adjustedDate;
            }

            if (rbtSaidas.Checked) FiltrarLancamentosSaida();
            else FiltrarLancamentosEntrada();
        }
        
        private void btnNovoLancamento_Click(object sender, EventArgs e)
        {
            novoLancamento();   
        }

        private void novoLancamento()
        {
            FormAddLancamento formAddLancamento = new FormAddLancamento();
            formAddLancamento.Owner = this;
            formAddLancamento.contaSelecionada = contaSelecionada;
            formAddLancamento.saidaSelecionada = null;
            formAddLancamento.entradaSelecionada = null;

            if (rbtSaidas.Checked)
            {
                formAddLancamento.tipoSaida = true;
            }
            else
            {
                formAddLancamento.tipoSaida = false;
            }
            if (formAddLancamento.ShowDialog() == DialogResult.OK)
            {
                AtualizarValorTotalConta();
                if (rbtSaidas.Checked) FiltrarSaidas();
                else FiltrarEntradas();
                novoLancamento();
            }
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

                    if (rbtSaidas.Checked) FiltrarLancamentosSaida();
                    else FiltrarLancamentosEntrada();
                    AtualizarValorTotalConta();
                }
            }
        }

        #endregion       

        private void dgvContas_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            funcoesGrid.ReajustarTamanhoTitulo(dgvContas, lblTituloContas);
        }

        private void dgvLancamentos_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            funcoesGrid.ReajustarTamanhoTitulo(dgvLancamentos, lblTituloSaidas);
        }        

        private void RedefinirTamanhoGrids()
        {
            int topGrid = 85;
            int distanciaGrid = 25;

            dgvContas.Top = topGrid;
            dgvContas.Width = dgvContas.Parent.Width - dgvContas.Left - distanciaGrid;
            dgvContas.Height = dgvContas.Parent.Height - dgvContas.Top - distanciaGrid;
            funcoesGrid.ReajustarTamanhoTitulo(dgvContas, lblTituloContas);
            lblTituloContas.Top = dgvContas.Top - lblTituloContas.Height;
            panelEditContas.Top = dgvContas.Top - lblTituloContas.Height - panelEditContas.Height;

            dgvLancamentos.Top = topGrid;
            dgvLancamentos.Width = dgvLancamentos.Parent.Width - dgvLancamentos.Left - distanciaGrid;
            dgvLancamentos.Height = dgvLancamentos.Parent.Height - dgvLancamentos.Top - distanciaGrid;
            funcoesGrid.ReajustarTamanhoTitulo(dgvLancamentos, lblTituloSaidas);
            lblTituloSaidas.Top = dgvLancamentos.Top - lblTituloSaidas.Height;
            panelFiltroLancamentos.Top = dgvLancamentos.Top - lblTituloSaidas.Height - panelFiltroLancamentos.Height;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            RedefinirTamanhoGrids();
        }       
    }
}
