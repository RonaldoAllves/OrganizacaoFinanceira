namespace OrganizacaoFinanceira
{
    partial class TelaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvContas = new DataGridView();
            label1 = new Label();
            txBanco = new TextBox();
            txUsuario = new TextBox();
            label2 = new Label();
            txDataFechamento = new TextBox();
            label3 = new Label();
            txValorInicial = new TextBox();
            label4 = new Label();
            btnSalvar = new Button();
            dgvLancamentos = new DataGridView();
            dtpMesReferencia = new DateTimePicker();
            tbxTotalLancamento = new TextBox();
            label5 = new Label();
            label6 = new Label();
            rbtSaidas = new RadioButton();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            label7 = new Label();
            tbxDescricao = new TextBox();
            tbxValor = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            cbxCategoria = new ComboBox();
            label11 = new Label();
            label12 = new Label();
            dtpDataLancamento = new DateTimePicker();
            dtpDataInicial = new DateTimePicker();
            label13 = new Label();
            tbxValorTotal = new TextBox();
            label14 = new Label();
            label15 = new Label();
            dtpMesReferenciaLancamento = new DateTimePicker();
            label16 = new Label();
            cbxContas = new ComboBox();
            panelParcelas = new Panel();
            tbxNumParcela = new TextBox();
            nudQtdParcelas = new NumericUpDown();
            btnSalvarLancamento = new Button();
            tbxChaveLancamento = new TextBox();
            label17 = new Label();
            tbxChaveConta = new TextBox();
            label18 = new Label();
            lblTipoSaida = new Label();
            cbxTipoSaida = new ComboBox();
            chxCredito = new CheckBox();
            chxDinheiro = new CheckBox();
            btnLimparLancamento = new Button();
            panelLancamento = new Panel();
            label21 = new Label();
            tbxValorExtrapolado = new TextBox();
            chkObrigatorio = new CheckBox();
            btnFecharMntLancamento = new Button();
            label19 = new Label();
            btnNovoLancamento = new Button();
            btnNovaConta = new Button();
            menu = new MenuStrip();
            lançamentosToolStripMenuItem = new ToolStripMenuItem();
            categoriasToolStripMenuItem = new ToolStripMenuItem();
            mesesFuturoToolStripMenuItem = new ToolStripMenuItem();
            geralToolStripMenuItem = new ToolStripMenuItem();
            label20 = new Label();
            tbxTotalSelecionados = new TextBox();
            lblTituloContas = new Label();
            lblTituloSaidas = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvContas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLancamentos).BeginInit();
            groupBox1.SuspendLayout();
            panelParcelas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQtdParcelas).BeginInit();
            panelLancamento.SuspendLayout();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // dgvContas
            // 
            dgvContas.BackgroundColor = SystemColors.ControlLightLight;
            dgvContas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContas.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvContas.Location = new Point(12, 101);
            dgvContas.MultiSelect = false;
            dgvContas.Name = "dgvContas";
            dgvContas.RowHeadersWidth = 51;
            dgvContas.Size = new Size(844, 149);
            dgvContas.TabIndex = 0;
            dgvContas.CellDoubleClick += dgvContas_CellDoubleClick;
            dgvContas.ColumnWidthChanged += dgvContas_ColumnWidthChanged;
            dgvContas.SelectionChanged += dgvContas_SelectionChanged;
            dgvContas.KeyDown += dgvContas_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 51);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 1;
            label1.Text = "Banco";
            // 
            // txBanco
            // 
            txBanco.Location = new Point(65, 69);
            txBanco.Name = "txBanco";
            txBanco.Size = new Size(100, 23);
            txBanco.TabIndex = 2;
            // 
            // txUsuario
            // 
            txUsuario.Location = new Point(171, 69);
            txUsuario.Name = "txUsuario";
            txUsuario.Size = new Size(100, 23);
            txUsuario.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(171, 51);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 3;
            label2.Text = "Usuário";
            // 
            // txDataFechamento
            // 
            txDataFechamento.Location = new Point(277, 69);
            txDataFechamento.Name = "txDataFechamento";
            txDataFechamento.Size = new Size(100, 23);
            txDataFechamento.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(277, 51);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 5;
            label3.Text = "Data fechamento";
            // 
            // txValorInicial
            // 
            txValorInicial.Location = new Point(383, 69);
            txValorInicial.Name = "txValorInicial";
            txValorInicial.Size = new Size(100, 23);
            txValorInicial.TabIndex = 8;
            txValorInicial.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(383, 51);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 7;
            label4.Text = "Valor inicial";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(506, 69);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 9;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // dgvLancamentos
            // 
            dgvLancamentos.BackgroundColor = SystemColors.ControlLightLight;
            dgvLancamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLancamentos.Location = new Point(12, 320);
            dgvLancamentos.Name = "dgvLancamentos";
            dgvLancamentos.RowHeadersWidth = 51;
            dgvLancamentos.RowTemplate.Height = 25;
            dgvLancamentos.Size = new Size(844, 459);
            dgvLancamentos.TabIndex = 10;
            dgvLancamentos.CellDoubleClick += dgvLancamentos_CellDoubleClick;
            dgvLancamentos.CellFormatting += dgvLancamentos_CellFormatting;
            dgvLancamentos.ColumnWidthChanged += dgvLancamentos_ColumnWidthChanged;
            dgvLancamentos.SelectionChanged += dgvLancamentos_SelectionChanged;
            dgvLancamentos.KeyDown += dgvLancamentos_KeyDown;
            // 
            // dtpMesReferencia
            // 
            dtpMesReferencia.Format = DateTimePickerFormat.Custom;
            dtpMesReferencia.Location = new Point(12, 284);
            dtpMesReferencia.Name = "dtpMesReferencia";
            dtpMesReferencia.Size = new Size(104, 23);
            dtpMesReferencia.TabIndex = 11;
            dtpMesReferencia.ValueChanged += dtpMesReferencia_ValueChanged;
            // 
            // tbxTotalLancamento
            // 
            tbxTotalLancamento.Location = new Point(736, 284);
            tbxTotalLancamento.Name = "tbxTotalLancamento";
            tbxTotalLancamento.Size = new Size(120, 23);
            tbxTotalLancamento.TabIndex = 12;
            tbxTotalLancamento.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(736, 266);
            label5.Name = "label5";
            label5.Size = new Size(98, 15);
            label5.TabIndex = 13;
            label5.Text = "Total lançamento";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 266);
            label6.Name = "label6";
            label6.Size = new Size(100, 15);
            label6.TabIndex = 14;
            label6.Text = "Mês de referência";
            // 
            // rbtSaidas
            // 
            rbtSaidas.AutoSize = true;
            rbtSaidas.Location = new Point(6, 18);
            rbtSaidas.Name = "rbtSaidas";
            rbtSaidas.Size = new Size(58, 19);
            rbtSaidas.TabIndex = 15;
            rbtSaidas.TabStop = true;
            rbtSaidas.Text = "Saídas";
            rbtSaidas.UseVisualStyleBackColor = true;
            rbtSaidas.CheckedChanged += rbtSaidas_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(rbtSaidas);
            groupBox1.Location = new Point(122, 265);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(158, 48);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tipo de lançamento";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(79, 18);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(70, 19);
            radioButton2.TabIndex = 16;
            radioButton2.TabStop = true;
            radioButton2.Text = "Entradas";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(83, 51);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 17;
            label7.Text = "Descrição";
            // 
            // tbxDescricao
            // 
            tbxDescricao.Location = new Point(83, 69);
            tbxDescricao.Name = "tbxDescricao";
            tbxDescricao.Size = new Size(195, 23);
            tbxDescricao.TabIndex = 18;
            // 
            // tbxValor
            // 
            tbxValor.Location = new Point(283, 69);
            tbxValor.Name = "tbxValor";
            tbxValor.Size = new Size(116, 23);
            tbxValor.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(283, 51);
            label8.Name = "label8";
            label8.Size = new Size(33, 15);
            label8.TabIndex = 19;
            label8.Text = "Valor";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(5, 4);
            label9.Name = "label9";
            label9.Size = new Size(45, 15);
            label9.TabIndex = 21;
            label9.Text = "Parcela";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(58, 3);
            label10.Name = "label10";
            label10.Size = new Size(76, 15);
            label10.TabIndex = 23;
            label10.Text = "Qtd. parcelas";
            // 
            // cbxCategoria
            // 
            cbxCategoria.FormattingEnabled = true;
            cbxCategoria.Location = new Point(30, 122);
            cbxCategoria.Name = "cbxCategoria";
            cbxCategoria.Size = new Size(121, 23);
            cbxCategoria.TabIndex = 25;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(30, 105);
            label11.Name = "label11";
            label11.Size = new Size(58, 15);
            label11.TabIndex = 26;
            label11.Text = "Categoria";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(405, 51);
            label12.Name = "label12";
            label12.Size = new Size(113, 15);
            label12.TabIndex = 27;
            label12.Text = "Data de lançamento";
            // 
            // dtpDataLancamento
            // 
            dtpDataLancamento.Format = DateTimePickerFormat.Short;
            dtpDataLancamento.Location = new Point(405, 69);
            dtpDataLancamento.Name = "dtpDataLancamento";
            dtpDataLancamento.Size = new Size(113, 23);
            dtpDataLancamento.TabIndex = 28;
            // 
            // dtpDataInicial
            // 
            dtpDataInicial.Format = DateTimePickerFormat.Short;
            dtpDataInicial.Location = new Point(140, 22);
            dtpDataInicial.Name = "dtpDataInicial";
            dtpDataInicial.Size = new Size(113, 23);
            dtpDataInicial.TabIndex = 30;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(140, 4);
            label13.Name = "label13";
            label13.Size = new Size(98, 15);
            label13.TabIndex = 29;
            label13.Text = "Dt. primeira parc.";
            // 
            // tbxValorTotal
            // 
            tbxValorTotal.Location = new Point(259, 21);
            tbxValorTotal.Name = "tbxValorTotal";
            tbxValorTotal.Size = new Size(116, 23);
            tbxValorTotal.TabIndex = 32;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(259, 3);
            label14.Name = "label14";
            label14.Size = new Size(60, 15);
            label14.TabIndex = 31;
            label14.Text = "Valor total";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(287, 104);
            label15.Name = "label15";
            label15.Size = new Size(100, 15);
            label15.TabIndex = 34;
            label15.Text = "Mês de referência";
            // 
            // dtpMesReferenciaLancamento
            // 
            dtpMesReferenciaLancamento.Format = DateTimePickerFormat.Custom;
            dtpMesReferenciaLancamento.Location = new Point(287, 122);
            dtpMesReferenciaLancamento.Name = "dtpMesReferenciaLancamento";
            dtpMesReferenciaLancamento.Size = new Size(104, 23);
            dtpMesReferenciaLancamento.TabIndex = 33;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(157, 105);
            label16.Name = "label16";
            label16.Size = new Size(39, 15);
            label16.TabIndex = 36;
            label16.Text = "Conta";
            // 
            // cbxContas
            // 
            cbxContas.FormattingEnabled = true;
            cbxContas.Location = new Point(157, 122);
            cbxContas.Name = "cbxContas";
            cbxContas.Size = new Size(121, 23);
            cbxContas.TabIndex = 35;
            // 
            // panelParcelas
            // 
            panelParcelas.Controls.Add(tbxNumParcela);
            panelParcelas.Controls.Add(nudQtdParcelas);
            panelParcelas.Controls.Add(label9);
            panelParcelas.Controls.Add(label10);
            panelParcelas.Controls.Add(label13);
            panelParcelas.Controls.Add(tbxValorTotal);
            panelParcelas.Controls.Add(dtpDataInicial);
            panelParcelas.Controls.Add(label14);
            panelParcelas.Location = new Point(25, 160);
            panelParcelas.Name = "panelParcelas";
            panelParcelas.Size = new Size(387, 53);
            panelParcelas.TabIndex = 37;
            // 
            // tbxNumParcela
            // 
            tbxNumParcela.Enabled = false;
            tbxNumParcela.Location = new Point(5, 22);
            tbxNumParcela.Name = "tbxNumParcela";
            tbxNumParcela.Size = new Size(47, 23);
            tbxNumParcela.TabIndex = 49;
            // 
            // nudQtdParcelas
            // 
            nudQtdParcelas.Location = new Point(58, 22);
            nudQtdParcelas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQtdParcelas.Name = "nudQtdParcelas";
            nudQtdParcelas.Size = new Size(76, 23);
            nudQtdParcelas.TabIndex = 40;
            nudQtdParcelas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnSalvarLancamento
            // 
            btnSalvarLancamento.Location = new Point(98, 261);
            btnSalvarLancamento.Name = "btnSalvarLancamento";
            btnSalvarLancamento.Size = new Size(75, 23);
            btnSalvarLancamento.TabIndex = 38;
            btnSalvarLancamento.Text = "Salvar";
            btnSalvarLancamento.UseVisualStyleBackColor = true;
            btnSalvarLancamento.Click += btnSalvarLancamento_Click;
            // 
            // tbxChaveLancamento
            // 
            tbxChaveLancamento.Enabled = false;
            tbxChaveLancamento.Location = new Point(30, 69);
            tbxChaveLancamento.Name = "tbxChaveLancamento";
            tbxChaveLancamento.Size = new Size(47, 23);
            tbxChaveLancamento.TabIndex = 40;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(30, 52);
            label17.Name = "label17";
            label17.Size = new Size(18, 15);
            label17.TabIndex = 39;
            label17.Text = "ID";
            // 
            // tbxChaveConta
            // 
            tbxChaveConta.Enabled = false;
            tbxChaveConta.Location = new Point(12, 69);
            tbxChaveConta.Name = "tbxChaveConta";
            tbxChaveConta.Size = new Size(47, 23);
            tbxChaveConta.TabIndex = 42;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(12, 52);
            label18.Name = "label18";
            label18.Size = new Size(18, 15);
            label18.TabIndex = 41;
            label18.Text = "ID";
            // 
            // lblTipoSaida
            // 
            lblTipoSaida.AutoSize = true;
            lblTipoSaida.Location = new Point(397, 105);
            lblTipoSaida.Name = "lblTipoSaida";
            lblTipoSaida.Size = new Size(76, 15);
            lblTipoSaida.TabIndex = 44;
            lblTipoSaida.Text = "Tipo de saída";
            // 
            // cbxTipoSaida
            // 
            cbxTipoSaida.FormattingEnabled = true;
            cbxTipoSaida.Items.AddRange(new object[] { "Crédito", "Dinheiro" });
            cbxTipoSaida.Location = new Point(397, 122);
            cbxTipoSaida.Name = "cbxTipoSaida";
            cbxTipoSaida.Size = new Size(121, 23);
            cbxTipoSaida.TabIndex = 43;
            // 
            // chxCredito
            // 
            chxCredito.AutoSize = true;
            chxCredito.Location = new Point(293, 284);
            chxCredito.Name = "chxCredito";
            chxCredito.Size = new Size(65, 19);
            chxCredito.TabIndex = 45;
            chxCredito.Text = "Crédito";
            chxCredito.UseVisualStyleBackColor = true;
            chxCredito.CheckedChanged += chxCredito_CheckedChanged;
            // 
            // chxDinheiro
            // 
            chxDinheiro.AutoSize = true;
            chxDinheiro.Location = new Point(364, 284);
            chxDinheiro.Name = "chxDinheiro";
            chxDinheiro.Size = new Size(71, 19);
            chxDinheiro.TabIndex = 46;
            chxDinheiro.Text = "Dinheiro";
            chxDinheiro.UseVisualStyleBackColor = true;
            chxDinheiro.CheckedChanged += chxDinheiro_CheckedChanged;
            // 
            // btnLimparLancamento
            // 
            btnLimparLancamento.Location = new Point(382, 261);
            btnLimparLancamento.Name = "btnLimparLancamento";
            btnLimparLancamento.Size = new Size(75, 23);
            btnLimparLancamento.TabIndex = 47;
            btnLimparLancamento.Text = "Limpar";
            btnLimparLancamento.UseVisualStyleBackColor = true;
            btnLimparLancamento.Click += btnLimparLancamento_Click;
            // 
            // panelLancamento
            // 
            panelLancamento.BackColor = Color.FromArgb(255, 224, 192);
            panelLancamento.BorderStyle = BorderStyle.FixedSingle;
            panelLancamento.Controls.Add(label21);
            panelLancamento.Controls.Add(tbxValorExtrapolado);
            panelLancamento.Controls.Add(chkObrigatorio);
            panelLancamento.Controls.Add(btnFecharMntLancamento);
            panelLancamento.Controls.Add(label19);
            panelLancamento.Controls.Add(btnLimparLancamento);
            panelLancamento.Controls.Add(tbxDescricao);
            panelLancamento.Controls.Add(label7);
            panelLancamento.Controls.Add(label8);
            panelLancamento.Controls.Add(lblTipoSaida);
            panelLancamento.Controls.Add(tbxValor);
            panelLancamento.Controls.Add(btnSalvarLancamento);
            panelLancamento.Controls.Add(cbxTipoSaida);
            panelLancamento.Controls.Add(label12);
            panelLancamento.Controls.Add(dtpDataLancamento);
            panelLancamento.Controls.Add(label17);
            panelLancamento.Controls.Add(tbxChaveLancamento);
            panelLancamento.Controls.Add(panelParcelas);
            panelLancamento.Controls.Add(cbxCategoria);
            panelLancamento.Controls.Add(label16);
            panelLancamento.Controls.Add(label11);
            panelLancamento.Controls.Add(cbxContas);
            panelLancamento.Controls.Add(dtpMesReferenciaLancamento);
            panelLancamento.Controls.Add(label15);
            panelLancamento.Location = new Point(933, 195);
            panelLancamento.Name = "panelLancamento";
            panelLancamento.Size = new Size(543, 303);
            panelLancamento.TabIndex = 48;
            panelLancamento.Visible = false;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(165, 218);
            label21.Name = "label21";
            label21.Size = new Size(99, 15);
            label21.TabIndex = 50;
            label21.Text = "Valor extrapolado";
            // 
            // tbxValorExtrapolado
            // 
            tbxValorExtrapolado.Location = new Point(165, 232);
            tbxValorExtrapolado.Name = "tbxValorExtrapolado";
            tbxValorExtrapolado.Size = new Size(113, 23);
            tbxValorExtrapolado.TabIndex = 51;
            // 
            // chkObrigatorio
            // 
            chkObrigatorio.AutoSize = true;
            chkObrigatorio.Location = new Point(30, 234);
            chkObrigatorio.Name = "chkObrigatorio";
            chkObrigatorio.Size = new Size(117, 19);
            chkObrigatorio.TabIndex = 49;
            chkObrigatorio.Text = "gasto obrigatório";
            chkObrigatorio.UseVisualStyleBackColor = true;
            chkObrigatorio.CheckedChanged += chkObrigatorio_CheckedChanged;
            // 
            // btnFecharMntLancamento
            // 
            btnFecharMntLancamento.Location = new Point(509, 3);
            btnFecharMntLancamento.Name = "btnFecharMntLancamento";
            btnFecharMntLancamento.Size = new Size(29, 23);
            btnFecharMntLancamento.TabIndex = 48;
            btnFecharMntLancamento.Text = "X";
            btnFecharMntLancamento.UseVisualStyleBackColor = true;
            btnFecharMntLancamento.Click += btnFecharMntLancamento_Click;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label19.Location = new Point(162, 13);
            label19.Name = "label19";
            label19.Size = new Size(211, 20);
            label19.TabIndex = 41;
            label19.Text = "Cadastrar/Alterar lançamentos";
            // 
            // btnNovoLancamento
            // 
            btnNovoLancamento.Location = new Point(454, 280);
            btnNovoLancamento.Margin = new Padding(3, 2, 3, 2);
            btnNovoLancamento.Name = "btnNovoLancamento";
            btnNovoLancamento.Size = new Size(82, 22);
            btnNovoLancamento.TabIndex = 49;
            btnNovoLancamento.Text = "Novo";
            btnNovoLancamento.UseVisualStyleBackColor = true;
            btnNovoLancamento.Click += btnNovoLancamento_Click;
            // 
            // btnNovaConta
            // 
            btnNovaConta.Location = new Point(587, 69);
            btnNovaConta.Name = "btnNovaConta";
            btnNovaConta.Size = new Size(75, 23);
            btnNovaConta.TabIndex = 64;
            btnNovaConta.Text = "Limpar";
            btnNovaConta.UseVisualStyleBackColor = true;
            btnNovaConta.Click += btnNovaConta_Click;
            // 
            // menu
            // 
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { lançamentosToolStripMenuItem, categoriasToolStripMenuItem, mesesFuturoToolStripMenuItem, geralToolStripMenuItem });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(1924, 24);
            menu.TabIndex = 85;
            menu.Text = "menuStrip1";
            // 
            // lançamentosToolStripMenuItem
            // 
            lançamentosToolStripMenuItem.Name = "lançamentosToolStripMenuItem";
            lançamentosToolStripMenuItem.Size = new Size(90, 20);
            lançamentosToolStripMenuItem.Text = "Lançamentos";
            // 
            // categoriasToolStripMenuItem
            // 
            categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            categoriasToolStripMenuItem.Size = new Size(75, 20);
            categoriasToolStripMenuItem.Text = "Categorias";
            categoriasToolStripMenuItem.Click += categoriasToolStripMenuItem_Click;
            // 
            // mesesFuturoToolStripMenuItem
            // 
            mesesFuturoToolStripMenuItem.Name = "mesesFuturoToolStripMenuItem";
            mesesFuturoToolStripMenuItem.Size = new Size(88, 20);
            mesesFuturoToolStripMenuItem.Text = "Meses futuro";
            mesesFuturoToolStripMenuItem.Click += mesesFuturoToolStripMenuItem_Click;
            // 
            // geralToolStripMenuItem
            // 
            geralToolStripMenuItem.Name = "geralToolStripMenuItem";
            geralToolStripMenuItem.Size = new Size(46, 20);
            geralToolStripMenuItem.Text = "Geral";
            geralToolStripMenuItem.Click += geralToolStripMenuItem_Click;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(610, 266);
            label20.Name = "label20";
            label20.Size = new Size(103, 15);
            label20.TabIndex = 87;
            label20.Text = "Total selecionados";
            // 
            // tbxTotalSelecionados
            // 
            tbxTotalSelecionados.Location = new Point(610, 284);
            tbxTotalSelecionados.Name = "tbxTotalSelecionados";
            tbxTotalSelecionados.Size = new Size(120, 23);
            tbxTotalSelecionados.TabIndex = 86;
            tbxTotalSelecionados.TextAlign = HorizontalAlignment.Right;
            // 
            // lblTituloContas
            // 
            lblTituloContas.AutoSize = true;
            lblTituloContas.Location = new Point(957, 535);
            lblTituloContas.Name = "lblTituloContas";
            lblTituloContas.Size = new Size(44, 15);
            lblTituloContas.TabIndex = 88;
            lblTituloContas.Text = "Contas";
            // 
            // lblTituloSaidas
            // 
            lblTituloSaidas.AutoSize = true;
            lblTituloSaidas.Location = new Point(959, 565);
            lblTituloSaidas.Name = "lblTituloSaidas";
            lblTituloSaidas.Size = new Size(89, 15);
            lblTituloSaidas.TabIndex = 89;
            lblTituloSaidas.Text = "Saídas da conta";
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 791);
            Controls.Add(lblTituloSaidas);
            Controls.Add(lblTituloContas);
            Controls.Add(label20);
            Controls.Add(tbxTotalSelecionados);
            Controls.Add(panelLancamento);
            Controls.Add(btnNovaConta);
            Controls.Add(btnNovoLancamento);
            Controls.Add(chxDinheiro);
            Controls.Add(chxCredito);
            Controls.Add(tbxChaveConta);
            Controls.Add(label18);
            Controls.Add(groupBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(tbxTotalLancamento);
            Controls.Add(dtpMesReferencia);
            Controls.Add(dgvLancamentos);
            Controls.Add(btnSalvar);
            Controls.Add(txValorInicial);
            Controls.Add(label4);
            Controls.Add(txDataFechamento);
            Controls.Add(label3);
            Controls.Add(txUsuario);
            Controls.Add(label2);
            Controls.Add(txBanco);
            Controls.Add(label1);
            Controls.Add(dgvContas);
            Controls.Add(menu);
            MainMenuStrip = menu;
            Name = "TelaPrincipal";
            Text = "TelaPrincipal";
            Load += TelaPrincipal_Load;
            Resize += TelaPrincipal_Resize;
            ((System.ComponentModel.ISupportInitialize)dgvContas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLancamentos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelParcelas.ResumeLayout(false);
            panelParcelas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQtdParcelas).EndInit();
            panelLancamento.ResumeLayout(false);
            panelLancamento.PerformLayout();
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvContas;
        private Label label1;
        private TextBox txBanco;
        private TextBox txUsuario;
        private Label label2;
        private TextBox txDataFechamento;
        private Label label3;
        private TextBox txValorInicial;
        private Label label4;
        private Button btnSalvar;
        private DataGridView dgvLancamentos;
        private DateTimePicker dtpMesReferencia;
        private TextBox tbxTotalLancamento;
        private Label label5;
        private Label label6;
        private RadioButton rbtSaidas;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private Label label7;
        private TextBox tbxDescricao;
        private TextBox tbxValor;
        private Label label8;
        private Label label9;
        private Label label10;
        private ComboBox cbxCategoria;
        private Label label11;
        private Label label12;
        private DateTimePicker dtpDataLancamento;
        private DateTimePicker dtpDataInicial;
        private Label label13;
        private TextBox tbxValorTotal;
        private Label label14;
        private Label label15;
        private DateTimePicker dtpMesReferenciaLancamento;
        private Label label16;
        private ComboBox cbxContas;
        private Panel panelParcelas;
        private Button btnSalvarLancamento;
        private NumericUpDown nudQtdParcelas;
        private TextBox tbxChaveLancamento;
        private Label label17;
        private TextBox tbxChaveConta;
        private Label label18;
        private Label lblTipoSaida;
        private ComboBox cbxTipoSaida;
        private CheckBox chxCredito;
        private CheckBox chxDinheiro;
        private Button btnLimparLancamento;
        private Panel panelLancamento;
        private Label label19;
        private Button btnFecharMntLancamento;
        private Button btnNovoLancamento;
        private TextBox tbxValorRecorrente;
        private Button btnNovaConta;
        private ComboBox cbxCategoriaRecorrente;
        private Button btnSalvarLancamentoRecorrente;
        private TextBox tbxNumParcela;
        private MenuStrip menu;
        private ToolStripMenuItem lançamentosToolStripMenuItem;
        private ToolStripMenuItem categoriasToolStripMenuItem;
        private ToolStripMenuItem mesesFuturoToolStripMenuItem;
        private ToolStripMenuItem geralToolStripMenuItem;
        private Label label20;
        private TextBox tbxTotalSelecionados;
        private Label label21;
        private TextBox tbxValorExtrapolado;
        private CheckBox chkObrigatorio;
        private Label lblTituloContas;
        private Label lblTituloSaidas;
    }
}