using FireSharp.Response;
using OrganizacaoFinanceira.Dados;
using OrganizacaoFinanceira.Objetos;
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
    public partial class FormAddLancamento : Form
    {
        CRUD CRUD = new CRUD();

        public bool tipoSaida;
        public bool editar;
        public ContaBanco contaSelecionada;
        public Saida saidaSelecionada;
        public Entrada entradaSelecionada;

        public FormAddLancamento()
        {
            InitializeComponent();            
        }

        private void FormAddLancamento_Load(object sender, EventArgs e)
        {
            this.Enabled = false;
            centralizar();
            LimparLancamento();
            InicializarDatas();
            PreencherComboBoxContas();
            PreencherComboBoxCategorias();
            HabilitarControles(tipoSaida);
            SelecionarValorComboboxContas();
            if (editar)
            {
                if (tipoSaida) EditarSaidas();
                else EditarEntradas();
            }
            this.Enabled = true;
        }

        private void centralizar()
        {
            if (this.Owner != null)
            {
                // Calcula a posição para centralizar o formulário filho em relação ao formulário pai
                int x = this.Owner.Location.X + (this.Owner.Width - this.Width) / 2;
                int y = this.Owner.Location.Y + (this.Owner.Height - this.Height) / 2;

                // Define o StartPosition para manual e posiciona o formulário
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(x, y);
            }
        }

        private void InicializarDatas()
        {
            dtpMesReferenciaLancamento.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpMesReferenciaLancamento.CustomFormat = "MM/yyyy";
            dtpMesReferenciaLancamento.ShowUpDown = true;

            tbxNumParcela.Text = "1";
            nudQtdParcelas.Value = 1;
        }

        private void HabilitarControles(bool lancamentoSaida)
        {
            panelParcelas.Visible = lancamentoSaida;
            cbxTipoSaida.Visible = lancamentoSaida;
            lblTipoSaida.Visible = lancamentoSaida;
            chkObrigatorio.Visible = lancamentoSaida;
            tbxValorExtrapolado.Visible = lancamentoSaida;
            label21.Visible = lancamentoSaida;
        }

        private async void btnSalvarLancamento_Click(object sender, EventArgs e)
        {
            bool sucesso;
            if (tipoSaida)
            {
                sucesso = await SalvarSaida();
            }
            else
            {
                sucesso = await SalvarEntrada();
            }
            if (sucesso) this.DialogResult = DialogResult.OK;
            else this.DialogResult = DialogResult.Cancel;
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
            saida.gastoObrigatorio = chkObrigatorio.Checked;
            saida.valorExtrapolado = (string.IsNullOrEmpty(tbxValorExtrapolado.Text) ? 0 : Convert.ToDouble(tbxValorExtrapolado.Text));

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
                LimparLancamento();

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
            this.Enabled = false;
            for (int i = 1; i < saida.qtdParcelas; i++)
            {
                chave = $"chave-{saida.chave + i}";
                parcela = saida.Copy();
                parcela.chave = saida.chave + i;
                parcela.parcela = i + 1;
                parcela.data = (new DateTime(saida.mesReferencia.Year, saida.mesReferencia.Month, 1)).AddMonths(i);
                parcela.mesReferencia = parcela.data;

                SetResponse response = await DadosGerais.client.SetTaskAsync("Saidas/" + chave, parcela);
            }
            this.Enabled = true;
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
                LimparLancamento();
                return true;
            }
            else
            {
                MessageBox.Show("Erro ao gravar a entrada.\n" + response.Exception);
            }
            return false;
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

            if (tipoSaida && nudQtdParcelas.Value > 1 && (String.IsNullOrEmpty(tbxValorTotal.Text.Trim()) || !double.TryParse(tbxValorTotal.Text, out double valorTotal) || valorTotal <= 0))
            {
                sb.AppendLine("Quando a compra é parcelada deve ser informado o valor total.");
            }

            if (cbxCategoria.SelectedIndex < 0 && tipoSaida)
            {
                sb.AppendLine("Deve preencher a categoria. Verifique.");
            }

            if (!String.IsNullOrEmpty(tbxValorExtrapolado.Text.Trim()) && (!double.TryParse(tbxValorExtrapolado.Text, out double valorExtrapolado)))
            {
                sb.AppendLine("Preencha o valor extrapolado corretamente. Deve ser númerico.");
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
                CRUD.CriarMes(mesNovo, categoria.chave, dtpMesReferenciaLancamento.Value);
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
            cbxCategoria.Enabled = true;
            cbxCategoria.SelectedIndex = -1;
            dtpMesReferenciaLancamento.Text = DateTime.Now.ToShortDateString();
            tbxNumParcela.Text = "1";
            nudQtdParcelas.Value = 1;
            dtpDataInicial.Text = DateTime.Now.ToShortDateString();
            tbxValorTotal.Text = "";
            cbxTipoSaida.SelectedIndex = 0;
            chkObrigatorio.Checked = false;
            tbxValorExtrapolado.Text = "";
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

        private void EditarSaidas()
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

            chkObrigatorio.Checked = saidaSelecionada.gastoObrigatorio;
            tbxValorExtrapolado.Text = saidaSelecionada.valorExtrapolado.ToString();
            tbxValorExtrapolado.Enabled = chkObrigatorio.Checked;
        }

        private void EditarEntradas()
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

        private void btnLimparLancamento_Click(object sender, EventArgs e)
        {
            LimparLancamento();
        }

        private void chkObrigatorio_CheckedChanged(object sender, EventArgs e)
        {
            tbxValorExtrapolado.Enabled = chkObrigatorio.Checked;
        }

        private void dtpMesReferenciaLancamento_ValueChanged(object sender, EventArgs e)
        {
            // Obtém o valor atual do DateTimePicker
            DateTime currentDate = dtpMesReferenciaLancamento.Value;

            // Ajusta a data para o primeiro dia do mês atual
            DateTime adjustedDate = new DateTime(currentDate.Year, currentDate.Month, 1);

            // Se o dia atual for diferente do dia ajustado, atualize a data
            if (currentDate != adjustedDate)
            {
                dtpMesReferenciaLancamento.Value = adjustedDate;
            }
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
                    await CRUD.SalvarMes(mes, false);
                }
                else
                {
                    Mes mesNovo = new();
                    mesNovo.verbaAdicional = entrada.valor;
                    await CRUD.CriarMes(mesNovo, entrada.chaveCategoria, entrada.mesReferencia);
                }
            }
        }        
    }
}
