﻿namespace OrganizacaoFinanceira
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
            btnFecharMntLancamento = new Button();
            label19 = new Label();
            btnNovoLancamento = new Button();
            label20 = new Label();
            dtpMesCategoria = new DateTimePicker();
            dgvCategorias = new DataGridView();
            label21 = new Label();
            tbxDescCategoria = new TextBox();
            tbxVerbaPadraoCat = new TextBox();
            label22 = new Label();
            tbxVerbaMesCategoria = new TextBox();
            label23 = new Label();
            btnSalvarCategoria = new Button();
            btnCriarMes = new Button();
            dgvMeses = new DataGridView();
            tbxIdCategoria = new TextBox();
            label24 = new Label();
            btnNovaConta = new Button();
            btnNovaCategoria = new Button();
            tbxIdMes = new TextBox();
            label25 = new Label();
            btnLimparMes = new Button();
            chxTodosMeses = new CheckBox();
            btnNovoLancRecorrente = new Button();
            dgvLancamentosRecorrentes = new DataGridView();
            groupBox2 = new GroupBox();
            radioButton1 = new RadioButton();
            rbtFiltroSaidaLancRecorrente = new RadioButton();
            panelLancRecorrente = new Panel();
            tbxIdLancRecorrente = new TextBox();
            groupBox3 = new GroupBox();
            rbtEntradaLancRecorrente = new RadioButton();
            rbtSaidaLancRecorrente = new RadioButton();
            btnFecharLancRecorrente = new Button();
            label26 = new Label();
            btnLimparLancRecorrente = new Button();
            tbxDescLancRecorrente = new TextBox();
            label27 = new Label();
            label28 = new Label();
            tbxValorLancRecorrente = new TextBox();
            btnSalvarLancRecorrente = new Button();
            label31 = new Label();
            cbxCategoriaLancRecorrente = new ComboBox();
            label37 = new Label();
            dgvMesesFuturos = new DataGridView();
            groupBox4 = new GroupBox();
            rbtMedia = new RadioButton();
            rbtLancamentoFuturo = new RadioButton();
            chkLancObrigatorio = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvContas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLancamentos).BeginInit();
            groupBox1.SuspendLayout();
            panelParcelas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQtdParcelas).BeginInit();
            panelLancamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMeses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLancamentosRecorrentes).BeginInit();
            groupBox2.SuspendLayout();
            panelLancRecorrente.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMesesFuturos).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // dgvContas
            // 
            dgvContas.BackgroundColor = SystemColors.ControlLightLight;
            dgvContas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContas.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvContas.Location = new Point(12, 67);
            dgvContas.MultiSelect = false;
            dgvContas.Name = "dgvContas";
            dgvContas.RowHeadersWidth = 51;
            dgvContas.Size = new Size(650, 184);
            dgvContas.TabIndex = 0;
            dgvContas.CellDoubleClick += dgvContas_CellDoubleClick;
            dgvContas.SelectionChanged += dgvContas_SelectionChanged;
            dgvContas.KeyDown += dgvContas_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 17);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 1;
            label1.Text = "Banco";
            // 
            // txBanco
            // 
            txBanco.Location = new Point(65, 35);
            txBanco.Name = "txBanco";
            txBanco.Size = new Size(100, 23);
            txBanco.TabIndex = 2;
            // 
            // txUsuario
            // 
            txUsuario.Location = new Point(171, 35);
            txUsuario.Name = "txUsuario";
            txUsuario.Size = new Size(100, 23);
            txUsuario.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(171, 17);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 3;
            label2.Text = "Usuário";
            // 
            // txDataFechamento
            // 
            txDataFechamento.Location = new Point(277, 35);
            txDataFechamento.Name = "txDataFechamento";
            txDataFechamento.Size = new Size(100, 23);
            txDataFechamento.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(277, 17);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 5;
            label3.Text = "Data fechamento";
            // 
            // txValorInicial
            // 
            txValorInicial.Location = new Point(383, 35);
            txValorInicial.Name = "txValorInicial";
            txValorInicial.Size = new Size(100, 23);
            txValorInicial.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(383, 17);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 7;
            label4.Text = "Valor inicial";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(506, 35);
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
            dgvLancamentos.Location = new Point(683, 67);
            dgvLancamentos.Name = "dgvLancamentos";
            dgvLancamentos.RowHeadersWidth = 51;
            dgvLancamentos.RowTemplate.Height = 25;
            dgvLancamentos.Size = new Size(844, 184);
            dgvLancamentos.TabIndex = 10;
            dgvLancamentos.CellDoubleClick += dgvLancamentos_CellDoubleClick;
            dgvLancamentos.CellFormatting += dgvLancamentos_CellFormatting;
            dgvLancamentos.SelectionChanged += dgvLancamentos_SelectionChanged;
            dgvLancamentos.KeyDown += dgvLancamentos_KeyDown;
            // 
            // dtpMesReferencia
            // 
            dtpMesReferencia.Format = DateTimePickerFormat.Custom;
            dtpMesReferencia.Location = new Point(925, 32);
            dtpMesReferencia.Name = "dtpMesReferencia";
            dtpMesReferencia.Size = new Size(104, 23);
            dtpMesReferencia.TabIndex = 11;
            dtpMesReferencia.ValueChanged += dtpMesReferencia_ValueChanged;
            // 
            // tbxTotalLancamento
            // 
            tbxTotalLancamento.Location = new Point(1040, 32);
            tbxTotalLancamento.Name = "tbxTotalLancamento";
            tbxTotalLancamento.Size = new Size(120, 23);
            tbxTotalLancamento.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1040, 14);
            label5.Name = "label5";
            label5.Size = new Size(98, 15);
            label5.TabIndex = 13;
            label5.Text = "Total lançamento";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(921, 14);
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
            groupBox1.Location = new Point(761, 14);
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
            tbxDescricao.Size = new Size(191, 23);
            tbxDescricao.TabIndex = 18;
            // 
            // tbxValor
            // 
            tbxValor.Location = new Point(280, 69);
            tbxValor.Name = "tbxValor";
            tbxValor.Size = new Size(116, 23);
            tbxValor.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(280, 51);
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
            label12.Location = new Point(402, 51);
            label12.Name = "label12";
            label12.Size = new Size(113, 15);
            label12.TabIndex = 27;
            label12.Text = "Data de lançamento";
            // 
            // dtpDataLancamento
            // 
            dtpDataLancamento.Format = DateTimePickerFormat.Short;
            dtpDataLancamento.Location = new Point(402, 69);
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
            label15.Location = new Point(284, 104);
            label15.Name = "label15";
            label15.Size = new Size(100, 15);
            label15.TabIndex = 34;
            label15.Text = "Mês de referência";
            // 
            // dtpMesReferenciaLancamento
            // 
            dtpMesReferenciaLancamento.Format = DateTimePickerFormat.Custom;
            dtpMesReferenciaLancamento.Location = new Point(284, 122);
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
            btnSalvarLancamento.Location = new Point(98, 253);
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
            tbxChaveConta.Location = new Point(12, 35);
            tbxChaveConta.Name = "tbxChaveConta";
            tbxChaveConta.Size = new Size(47, 23);
            tbxChaveConta.TabIndex = 42;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(12, 18);
            label18.Name = "label18";
            label18.Size = new Size(18, 15);
            label18.TabIndex = 41;
            label18.Text = "ID";
            // 
            // lblTipoSaida
            // 
            lblTipoSaida.AutoSize = true;
            lblTipoSaida.Location = new Point(394, 105);
            lblTipoSaida.Name = "lblTipoSaida";
            lblTipoSaida.Size = new Size(76, 15);
            lblTipoSaida.TabIndex = 44;
            lblTipoSaida.Text = "Tipo de saída";
            // 
            // cbxTipoSaida
            // 
            cbxTipoSaida.FormattingEnabled = true;
            cbxTipoSaida.Items.AddRange(new object[] { "Crédito", "Dinheiro" });
            cbxTipoSaida.Location = new Point(394, 122);
            cbxTipoSaida.Name = "cbxTipoSaida";
            cbxTipoSaida.Size = new Size(121, 23);
            cbxTipoSaida.TabIndex = 43;
            // 
            // chxCredito
            // 
            chxCredito.AutoSize = true;
            chxCredito.Location = new Point(1199, 35);
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
            chxDinheiro.Location = new Point(1270, 35);
            chxDinheiro.Name = "chxDinheiro";
            chxDinheiro.Size = new Size(71, 19);
            chxDinheiro.TabIndex = 46;
            chxDinheiro.Text = "Dinheiro";
            chxDinheiro.UseVisualStyleBackColor = true;
            chxDinheiro.CheckedChanged += chxDinheiro_CheckedChanged;
            // 
            // btnLimparLancamento
            // 
            btnLimparLancamento.Location = new Point(382, 253);
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
            panelLancamento.Location = new Point(798, 126);
            panelLancamento.Name = "panelLancamento";
            panelLancamento.Size = new Size(543, 303);
            panelLancamento.TabIndex = 48;
            panelLancamento.Visible = false;
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
            btnNovoLancamento.Location = new Point(1445, 34);
            btnNovoLancamento.Margin = new Padding(3, 2, 3, 2);
            btnNovoLancamento.Name = "btnNovoLancamento";
            btnNovoLancamento.Size = new Size(82, 22);
            btnNovoLancamento.TabIndex = 49;
            btnNovoLancamento.Text = "Novo";
            btnNovoLancamento.UseVisualStyleBackColor = true;
            btnNovoLancamento.Click += btnNovoLancamento_Click;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(1037, 271);
            label20.Name = "label20";
            label20.Size = new Size(100, 15);
            label20.TabIndex = 51;
            label20.Text = "Mês de referência";
            // 
            // dtpMesCategoria
            // 
            dtpMesCategoria.Format = DateTimePickerFormat.Custom;
            dtpMesCategoria.Location = new Point(1040, 289);
            dtpMesCategoria.Name = "dtpMesCategoria";
            dtpMesCategoria.Size = new Size(104, 23);
            dtpMesCategoria.TabIndex = 50;
            dtpMesCategoria.ValueChanged += dtpMesCategoria_ValueChanged;
            // 
            // dgvCategorias
            // 
            dgvCategorias.BackgroundColor = SystemColors.ControlLightLight;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvCategorias.Location = new Point(12, 317);
            dgvCategorias.MultiSelect = false;
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.RowHeadersWidth = 51;
            dgvCategorias.Size = new Size(650, 184);
            dgvCategorias.TabIndex = 52;
            dgvCategorias.CellDoubleClick += dgvCategorias_CellDoubleClick;
            dgvCategorias.SelectionChanged += dgvCategorias_SelectionChanged;
            dgvCategorias.KeyDown += dgvCategorias_KeyDown;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(61, 273);
            label21.Name = "label21";
            label21.Size = new Size(58, 15);
            label21.TabIndex = 53;
            label21.Text = "Categoria";
            // 
            // tbxDescCategoria
            // 
            tbxDescCategoria.Location = new Point(65, 290);
            tbxDescCategoria.Margin = new Padding(3, 2, 3, 2);
            tbxDescCategoria.Name = "tbxDescCategoria";
            tbxDescCategoria.Size = new Size(153, 23);
            tbxDescCategoria.TabIndex = 54;
            // 
            // tbxVerbaPadraoCat
            // 
            tbxVerbaPadraoCat.Location = new Point(222, 290);
            tbxVerbaPadraoCat.Margin = new Padding(3, 2, 3, 2);
            tbxVerbaPadraoCat.Name = "tbxVerbaPadraoCat";
            tbxVerbaPadraoCat.Size = new Size(131, 23);
            tbxVerbaPadraoCat.TabIndex = 56;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(219, 273);
            label22.Name = "label22";
            label22.Size = new Size(76, 15);
            label22.TabIndex = 55;
            label22.Text = "Verba padrão";
            // 
            // tbxVerbaMesCategoria
            // 
            tbxVerbaMesCategoria.Location = new Point(736, 290);
            tbxVerbaMesCategoria.Margin = new Padding(3, 2, 3, 2);
            tbxVerbaMesCategoria.Name = "tbxVerbaMesCategoria";
            tbxVerbaMesCategoria.Size = new Size(76, 23);
            tbxVerbaMesCategoria.TabIndex = 58;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(733, 273);
            label23.Name = "label23";
            label23.Size = new Size(61, 15);
            label23.TabIndex = 57;
            label23.Text = "Verba mês";
            // 
            // btnSalvarCategoria
            // 
            btnSalvarCategoria.Location = new Point(359, 291);
            btnSalvarCategoria.Name = "btnSalvarCategoria";
            btnSalvarCategoria.Size = new Size(75, 23);
            btnSalvarCategoria.TabIndex = 59;
            btnSalvarCategoria.Text = "Salvar";
            btnSalvarCategoria.UseVisualStyleBackColor = true;
            btnSalvarCategoria.Click += btnSalvarCategoria_Click;
            // 
            // btnCriarMes
            // 
            btnCriarMes.Location = new Point(817, 290);
            btnCriarMes.Margin = new Padding(3, 2, 3, 2);
            btnCriarMes.Name = "btnCriarMes";
            btnCriarMes.Size = new Size(102, 22);
            btnCriarMes.TabIndex = 60;
            btnCriarMes.Text = "Salvar/Criar mês";
            btnCriarMes.UseVisualStyleBackColor = true;
            btnCriarMes.Click += btnCriarMes_Click;
            // 
            // dgvMeses
            // 
            dgvMeses.BackgroundColor = SystemColors.ControlLightLight;
            dgvMeses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMeses.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvMeses.Location = new Point(683, 317);
            dgvMeses.MultiSelect = false;
            dgvMeses.Name = "dgvMeses";
            dgvMeses.RowHeadersWidth = 51;
            dgvMeses.Size = new Size(844, 184);
            dgvMeses.TabIndex = 61;
            dgvMeses.CellDoubleClick += dgvMeses_CellDoubleClick;
            dgvMeses.CellFormatting += dgvMeses_CellFormatting;
            dgvMeses.SelectionChanged += dgvMeses_SelectionChanged;
            // 
            // tbxIdCategoria
            // 
            tbxIdCategoria.Enabled = false;
            tbxIdCategoria.Location = new Point(12, 290);
            tbxIdCategoria.Name = "tbxIdCategoria";
            tbxIdCategoria.Size = new Size(47, 23);
            tbxIdCategoria.TabIndex = 63;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(12, 273);
            label24.Name = "label24";
            label24.Size = new Size(18, 15);
            label24.TabIndex = 62;
            label24.Text = "ID";
            // 
            // btnNovaConta
            // 
            btnNovaConta.Location = new Point(587, 35);
            btnNovaConta.Name = "btnNovaConta";
            btnNovaConta.Size = new Size(75, 23);
            btnNovaConta.TabIndex = 64;
            btnNovaConta.Text = "Limpar";
            btnNovaConta.UseVisualStyleBackColor = true;
            btnNovaConta.Click += btnNovaConta_Click;
            // 
            // btnNovaCategoria
            // 
            btnNovaCategoria.Location = new Point(440, 290);
            btnNovaCategoria.Name = "btnNovaCategoria";
            btnNovaCategoria.Size = new Size(75, 23);
            btnNovaCategoria.TabIndex = 65;
            btnNovaCategoria.Text = "Limpar";
            btnNovaCategoria.UseVisualStyleBackColor = true;
            btnNovaCategoria.Click += btnNovaCategoria_Click;
            // 
            // tbxIdMes
            // 
            tbxIdMes.Enabled = false;
            tbxIdMes.Location = new Point(683, 290);
            tbxIdMes.Name = "tbxIdMes";
            tbxIdMes.Size = new Size(47, 23);
            tbxIdMes.TabIndex = 67;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(683, 273);
            label25.Name = "label25";
            label25.Size = new Size(18, 15);
            label25.TabIndex = 66;
            label25.Text = "ID";
            // 
            // btnLimparMes
            // 
            btnLimparMes.Location = new Point(925, 290);
            btnLimparMes.Name = "btnLimparMes";
            btnLimparMes.Size = new Size(75, 22);
            btnLimparMes.TabIndex = 68;
            btnLimparMes.Text = "Limpar";
            btnLimparMes.UseVisualStyleBackColor = true;
            btnLimparMes.Click += btnLimparMes_Click;
            // 
            // chxTodosMeses
            // 
            chxTodosMeses.AutoSize = true;
            chxTodosMeses.Location = new Point(1199, 291);
            chxTodosMeses.Margin = new Padding(3, 2, 3, 2);
            chxTodosMeses.Name = "chxTodosMeses";
            chxTodosMeses.Size = new Size(93, 19);
            chxTodosMeses.TabIndex = 69;
            chxTodosMeses.Text = "Todos meses";
            chxTodosMeses.UseVisualStyleBackColor = true;
            chxTodosMeses.CheckedChanged += chxTodosMeses_CheckedChanged;
            // 
            // btnNovoLancRecorrente
            // 
            btnNovoLancRecorrente.Location = new Point(587, 533);
            btnNovoLancRecorrente.Name = "btnNovoLancRecorrente";
            btnNovoLancRecorrente.Size = new Size(75, 23);
            btnNovoLancRecorrente.TabIndex = 78;
            btnNovoLancRecorrente.Text = "Novo";
            btnNovoLancRecorrente.UseVisualStyleBackColor = true;
            btnNovoLancRecorrente.Click += btnNovoLancRecorrente_Click;
            // 
            // dgvLancamentosRecorrentes
            // 
            dgvLancamentosRecorrentes.BackgroundColor = SystemColors.ControlLightLight;
            dgvLancamentosRecorrentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLancamentosRecorrentes.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvLancamentosRecorrentes.Location = new Point(12, 562);
            dgvLancamentosRecorrentes.MultiSelect = false;
            dgvLancamentosRecorrentes.Name = "dgvLancamentosRecorrentes";
            dgvLancamentosRecorrentes.RowHeadersWidth = 51;
            dgvLancamentosRecorrentes.Size = new Size(650, 184);
            dgvLancamentosRecorrentes.TabIndex = 79;
            dgvLancamentosRecorrentes.CellDoubleClick += dgvLancamentosRecorrentes_CellDoubleClick;
            dgvLancamentosRecorrentes.CellFormatting += dgvLancamentosRecorrentes_CellFormatting;
            dgvLancamentosRecorrentes.SelectionChanged += dgvLancamentosRecorrentes_SelectionChanged;
            dgvLancamentosRecorrentes.KeyDown += dgvLancamentosRecorrentes_KeyDown;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton1);
            groupBox2.Controls.Add(rbtFiltroSaidaLancRecorrente);
            groupBox2.Location = new Point(12, 515);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(259, 42);
            groupBox2.TabIndex = 80;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tipo de lançamento recorrente";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(159, 17);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(70, 19);
            radioButton1.TabIndex = 16;
            radioButton1.Text = "Entradas";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbtFiltroSaidaLancRecorrente
            // 
            rbtFiltroSaidaLancRecorrente.AutoSize = true;
            rbtFiltroSaidaLancRecorrente.Location = new Point(37, 19);
            rbtFiltroSaidaLancRecorrente.Name = "rbtFiltroSaidaLancRecorrente";
            rbtFiltroSaidaLancRecorrente.Size = new Size(58, 19);
            rbtFiltroSaidaLancRecorrente.TabIndex = 15;
            rbtFiltroSaidaLancRecorrente.Text = "Saídas";
            rbtFiltroSaidaLancRecorrente.UseVisualStyleBackColor = true;
            rbtFiltroSaidaLancRecorrente.CheckedChanged += rbtFiltroSaidaLancRecorrente_CheckedChanged;
            // 
            // panelLancRecorrente
            // 
            panelLancRecorrente.BackColor = Color.FromArgb(255, 224, 192);
            panelLancRecorrente.BorderStyle = BorderStyle.FixedSingle;
            panelLancRecorrente.Controls.Add(chkLancObrigatorio);
            panelLancRecorrente.Controls.Add(tbxIdLancRecorrente);
            panelLancRecorrente.Controls.Add(groupBox3);
            panelLancRecorrente.Controls.Add(btnFecharLancRecorrente);
            panelLancRecorrente.Controls.Add(label26);
            panelLancRecorrente.Controls.Add(btnLimparLancRecorrente);
            panelLancRecorrente.Controls.Add(tbxDescLancRecorrente);
            panelLancRecorrente.Controls.Add(label27);
            panelLancRecorrente.Controls.Add(label28);
            panelLancRecorrente.Controls.Add(tbxValorLancRecorrente);
            panelLancRecorrente.Controls.Add(btnSalvarLancRecorrente);
            panelLancRecorrente.Controls.Add(label31);
            panelLancRecorrente.Controls.Add(cbxCategoriaLancRecorrente);
            panelLancRecorrente.Controls.Add(label37);
            panelLancRecorrente.Location = new Point(125, 122);
            panelLancRecorrente.Name = "panelLancRecorrente";
            panelLancRecorrente.Size = new Size(454, 233);
            panelLancRecorrente.TabIndex = 49;
            panelLancRecorrente.Visible = false;
            // 
            // tbxIdLancRecorrente
            // 
            tbxIdLancRecorrente.Enabled = false;
            tbxIdLancRecorrente.Location = new Point(30, 69);
            tbxIdLancRecorrente.Name = "tbxIdLancRecorrente";
            tbxIdLancRecorrente.Size = new Size(47, 23);
            tbxIdLancRecorrente.TabIndex = 82;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rbtEntradaLancRecorrente);
            groupBox3.Controls.Add(rbtSaidaLancRecorrente);
            groupBox3.Location = new Point(170, 106);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(226, 42);
            groupBox3.TabIndex = 81;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tipo de lançamento recorrente";
            // 
            // rbtEntradaLancRecorrente
            // 
            rbtEntradaLancRecorrente.AutoSize = true;
            rbtEntradaLancRecorrente.Location = new Point(132, 17);
            rbtEntradaLancRecorrente.Name = "rbtEntradaLancRecorrente";
            rbtEntradaLancRecorrente.Size = new Size(70, 19);
            rbtEntradaLancRecorrente.TabIndex = 16;
            rbtEntradaLancRecorrente.TabStop = true;
            rbtEntradaLancRecorrente.Text = "Entradas";
            rbtEntradaLancRecorrente.UseVisualStyleBackColor = true;
            // 
            // rbtSaidaLancRecorrente
            // 
            rbtSaidaLancRecorrente.AutoSize = true;
            rbtSaidaLancRecorrente.Location = new Point(29, 18);
            rbtSaidaLancRecorrente.Name = "rbtSaidaLancRecorrente";
            rbtSaidaLancRecorrente.Size = new Size(58, 19);
            rbtSaidaLancRecorrente.TabIndex = 15;
            rbtSaidaLancRecorrente.TabStop = true;
            rbtSaidaLancRecorrente.Text = "Saídas";
            rbtSaidaLancRecorrente.UseVisualStyleBackColor = true;
            // 
            // btnFecharLancRecorrente
            // 
            btnFecharLancRecorrente.Location = new Point(409, 3);
            btnFecharLancRecorrente.Name = "btnFecharLancRecorrente";
            btnFecharLancRecorrente.Size = new Size(29, 23);
            btnFecharLancRecorrente.TabIndex = 48;
            btnFecharLancRecorrente.Text = "X";
            btnFecharLancRecorrente.UseVisualStyleBackColor = true;
            btnFecharLancRecorrente.Click += btnFecharLancRecorrente_Click;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label26.Location = new Point(83, 10);
            label26.Name = "label26";
            label26.Size = new Size(289, 20);
            label26.TabIndex = 41;
            label26.Text = "Cadastrar/Alterar lançamentos recorrentes";
            // 
            // btnLimparLancRecorrente
            // 
            btnLimparLancRecorrente.Location = new Point(304, 179);
            btnLimparLancRecorrente.Name = "btnLimparLancRecorrente";
            btnLimparLancRecorrente.Size = new Size(75, 23);
            btnLimparLancRecorrente.TabIndex = 47;
            btnLimparLancRecorrente.Text = "Limpar";
            btnLimparLancRecorrente.UseVisualStyleBackColor = true;
            btnLimparLancRecorrente.Click += btnLimparLancRecorrente_Click;
            // 
            // tbxDescLancRecorrente
            // 
            tbxDescLancRecorrente.Location = new Point(83, 69);
            tbxDescLancRecorrente.Name = "tbxDescLancRecorrente";
            tbxDescLancRecorrente.Size = new Size(191, 23);
            tbxDescLancRecorrente.TabIndex = 18;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(83, 51);
            label27.Name = "label27";
            label27.Size = new Size(58, 15);
            label27.TabIndex = 17;
            label27.Text = "Descrição";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(280, 51);
            label28.Name = "label28";
            label28.Size = new Size(33, 15);
            label28.TabIndex = 19;
            label28.Text = "Valor";
            // 
            // tbxValorLancRecorrente
            // 
            tbxValorLancRecorrente.Location = new Point(280, 69);
            tbxValorLancRecorrente.Name = "tbxValorLancRecorrente";
            tbxValorLancRecorrente.Size = new Size(116, 23);
            tbxValorLancRecorrente.TabIndex = 20;
            // 
            // btnSalvarLancRecorrente
            // 
            btnSalvarLancRecorrente.Location = new Point(95, 179);
            btnSalvarLancRecorrente.Name = "btnSalvarLancRecorrente";
            btnSalvarLancRecorrente.Size = new Size(75, 23);
            btnSalvarLancRecorrente.TabIndex = 38;
            btnSalvarLancRecorrente.Text = "Salvar";
            btnSalvarLancRecorrente.UseVisualStyleBackColor = true;
            btnSalvarLancRecorrente.Click += btnSalvarLancRecorrente_Click;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(30, 52);
            label31.Name = "label31";
            label31.Size = new Size(18, 15);
            label31.TabIndex = 39;
            label31.Text = "ID";
            // 
            // cbxCategoriaLancRecorrente
            // 
            cbxCategoriaLancRecorrente.FormattingEnabled = true;
            cbxCategoriaLancRecorrente.Location = new Point(30, 122);
            cbxCategoriaLancRecorrente.Name = "cbxCategoriaLancRecorrente";
            cbxCategoriaLancRecorrente.Size = new Size(121, 23);
            cbxCategoriaLancRecorrente.TabIndex = 25;
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new Point(30, 105);
            label37.Name = "label37";
            label37.Size = new Size(58, 15);
            label37.TabIndex = 26;
            label37.Text = "Categoria";
            // 
            // dgvMesesFuturos
            // 
            dgvMesesFuturos.BackgroundColor = SystemColors.ControlLightLight;
            dgvMesesFuturos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMesesFuturos.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvMesesFuturos.Location = new Point(683, 562);
            dgvMesesFuturos.MultiSelect = false;
            dgvMesesFuturos.Name = "dgvMesesFuturos";
            dgvMesesFuturos.RowHeadersWidth = 51;
            dgvMesesFuturos.Size = new Size(844, 184);
            dgvMesesFuturos.TabIndex = 81;
            dgvMesesFuturos.CellFormatting += dgvMesesFuturos_CellFormatting;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(rbtMedia);
            groupBox4.Controls.Add(rbtLancamentoFuturo);
            groupBox4.Location = new Point(683, 509);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(236, 48);
            groupBox4.TabIndex = 84;
            groupBox4.TabStop = false;
            groupBox4.Text = "Tipo previsão";
            // 
            // rbtMedia
            // 
            rbtMedia.AutoSize = true;
            rbtMedia.Location = new Point(170, 18);
            rbtMedia.Name = "rbtMedia";
            rbtMedia.Size = new Size(58, 19);
            rbtMedia.TabIndex = 16;
            rbtMedia.TabStop = true;
            rbtMedia.Text = "Média";
            rbtMedia.UseVisualStyleBackColor = true;
            // 
            // rbtLancamentoFuturo
            // 
            rbtLancamentoFuturo.AutoSize = true;
            rbtLancamentoFuturo.Location = new Point(6, 18);
            rbtLancamentoFuturo.Name = "rbtLancamentoFuturo";
            rbtLancamentoFuturo.Size = new Size(158, 19);
            rbtLancamentoFuturo.TabIndex = 15;
            rbtLancamentoFuturo.TabStop = true;
            rbtLancamentoFuturo.Text = "Lançamentos recorrentes";
            rbtLancamentoFuturo.UseVisualStyleBackColor = true;
            // 
            // chkLancObrigatorio
            // 
            chkLancObrigatorio.AutoSize = true;
            chkLancObrigatorio.Location = new Point(30, 154);
            chkLancObrigatorio.Name = "chkLancObrigatorio";
            chkLancObrigatorio.Size = new Size(87, 19);
            chkLancObrigatorio.TabIndex = 83;
            chkLancObrigatorio.Text = "Obrigatório";
            chkLancObrigatorio.UseVisualStyleBackColor = true;
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1537, 791);
            Controls.Add(groupBox4);
            Controls.Add(panelLancRecorrente);
            Controls.Add(panelLancamento);
            Controls.Add(dgvMesesFuturos);
            Controls.Add(groupBox2);
            Controls.Add(dgvLancamentosRecorrentes);
            Controls.Add(btnNovoLancRecorrente);
            Controls.Add(chxTodosMeses);
            Controls.Add(btnLimparMes);
            Controls.Add(tbxIdMes);
            Controls.Add(label25);
            Controls.Add(btnNovaCategoria);
            Controls.Add(btnNovaConta);
            Controls.Add(tbxIdCategoria);
            Controls.Add(label24);
            Controls.Add(dgvMeses);
            Controls.Add(btnCriarMes);
            Controls.Add(btnSalvarCategoria);
            Controls.Add(tbxVerbaMesCategoria);
            Controls.Add(label23);
            Controls.Add(tbxVerbaPadraoCat);
            Controls.Add(label22);
            Controls.Add(tbxDescCategoria);
            Controls.Add(label21);
            Controls.Add(dgvCategorias);
            Controls.Add(label20);
            Controls.Add(dtpMesCategoria);
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
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMeses).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLancamentosRecorrentes).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panelLancRecorrente.ResumeLayout(false);
            panelLancRecorrente.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMesesFuturos).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
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
        private Label label20;
        private DateTimePicker dtpMesCategoria;
        private DataGridView dgvCategorias;
        private Label label21;
        private TextBox tbxDescCategoria;
        private TextBox tbxVerbaPadraoCat;
        private Label label22;
        private TextBox tbxVerbaMesCategoria;
        private Label label23;
        private Button btnSalvarCategoria;
        private Button btnCriarMes;
        private DataGridView dgvMeses;
        private TextBox tbxValorRecorrente;
        private Label label24;
        private TextBox tbxIdCategoria;
        private Button btnNovaConta;
        private Button btnNovaCategoria;
        private TextBox tbxIdMes;
        private Label label25;
        private Button btnLimparMes;
        private CheckBox chxTodosMeses;
        private ComboBox cbxCategoriaRecorrente;
        private Button btnSalvarLancamentoRecorrente;
        private Button btnNovoLancRecorrente;
        private DataGridView dgvLancamentosRecorrentes;
        private GroupBox groupBox2;
        private RadioButton radioButton1;
        private RadioButton rbtFiltroSaidaLancRecorrente;
        private Panel panelLancRecorrente;
        private Button btnFecharLancRecorrente;
        private Label label26;
        private Button btnLimparLancRecorrente;
        private TextBox tbxDescLancRecorrente;
        private Label label27;
        private Label label28;
        private TextBox tbxValorLancRecorrente;
        private Button btnSalvarLancRecorrente;
        private Label label31;
        private ComboBox cbxCategoriaLancRecorrente;
        private Label label37;
        private GroupBox groupBox3;
        private RadioButton rbtEntradaLancRecorrente;
        private RadioButton rbtSaidaLancRecorrente;
        private TextBox tbxIdLancRecorrente;
        private DataGridView dgvMesesFuturos;
        private GroupBox groupBox4;
        private RadioButton rbtMedia;
        private RadioButton rbtLancamentoFuturo;
        private TextBox tbxNumParcela;
        private CheckBox chkLancObrigatorio;
    }
}