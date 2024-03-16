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
            btnNovaConta = new Button();
            menu = new MenuStrip();
            lançamentosToolStripMenuItem = new ToolStripMenuItem();
            categoriasToolStripMenuItem = new ToolStripMenuItem();
            mesesFuturoToolStripMenuItem = new ToolStripMenuItem();
            geralToolStripMenuItem = new ToolStripMenuItem();
            label20 = new Label();
            tbxTotalSelecionados = new TextBox();
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
            dgvContas.Location = new Point(14, 135);
            dgvContas.Margin = new Padding(3, 4, 3, 4);
            dgvContas.MultiSelect = false;
            dgvContas.Name = "dgvContas";
            dgvContas.RowHeadersWidth = 51;
            dgvContas.Size = new Size(743, 245);
            dgvContas.TabIndex = 0;
            dgvContas.CellDoubleClick += dgvContas_CellDoubleClick;
            dgvContas.SelectionChanged += dgvContas_SelectionChanged;
            dgvContas.KeyDown += dgvContas_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 68);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "Banco";
            // 
            // txBanco
            // 
            txBanco.Location = new Point(74, 92);
            txBanco.Margin = new Padding(3, 4, 3, 4);
            txBanco.Name = "txBanco";
            txBanco.Size = new Size(114, 27);
            txBanco.TabIndex = 2;
            // 
            // txUsuario
            // 
            txUsuario.Location = new Point(195, 92);
            txUsuario.Margin = new Padding(3, 4, 3, 4);
            txUsuario.Name = "txUsuario";
            txUsuario.Size = new Size(114, 27);
            txUsuario.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(195, 68);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 3;
            label2.Text = "Usuário";
            // 
            // txDataFechamento
            // 
            txDataFechamento.Location = new Point(317, 92);
            txDataFechamento.Margin = new Padding(3, 4, 3, 4);
            txDataFechamento.Name = "txDataFechamento";
            txDataFechamento.Size = new Size(114, 27);
            txDataFechamento.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(317, 68);
            label3.Name = "label3";
            label3.Size = new Size(124, 20);
            label3.TabIndex = 5;
            label3.Text = "Data fechamento";
            // 
            // txValorInicial
            // 
            txValorInicial.Location = new Point(438, 92);
            txValorInicial.Margin = new Padding(3, 4, 3, 4);
            txValorInicial.Name = "txValorInicial";
            txValorInicial.Size = new Size(114, 27);
            txValorInicial.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(438, 68);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 7;
            label4.Text = "Valor inicial";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(578, 92);
            btnSalvar.Margin = new Padding(3, 4, 3, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(86, 31);
            btnSalvar.TabIndex = 9;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // dgvLancamentos
            // 
            dgvLancamentos.BackgroundColor = SystemColors.ControlLightLight;
            dgvLancamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLancamentos.Location = new Point(781, 135);
            dgvLancamentos.Margin = new Padding(3, 4, 3, 4);
            dgvLancamentos.Name = "dgvLancamentos";
            dgvLancamentos.RowHeadersWidth = 51;
            dgvLancamentos.RowTemplate.Height = 25;
            dgvLancamentos.Size = new Size(965, 696);
            dgvLancamentos.TabIndex = 10;
            dgvLancamentos.CellDoubleClick += dgvLancamentos_CellDoubleClick;
            dgvLancamentos.CellFormatting += dgvLancamentos_CellFormatting;
            dgvLancamentos.SelectionChanged += dgvLancamentos_SelectionChanged;
            dgvLancamentos.KeyDown += dgvLancamentos_KeyDown;
            // 
            // dtpMesReferencia
            // 
            dtpMesReferencia.Format = DateTimePickerFormat.Custom;
            dtpMesReferencia.Location = new Point(1057, 88);
            dtpMesReferencia.Margin = new Padding(3, 4, 3, 4);
            dtpMesReferencia.Name = "dtpMesReferencia";
            dtpMesReferencia.Size = new Size(118, 27);
            dtpMesReferencia.TabIndex = 11;
            dtpMesReferencia.ValueChanged += dtpMesReferencia_ValueChanged;
            // 
            // tbxTotalLancamento
            // 
            tbxTotalLancamento.Location = new Point(1189, 88);
            tbxTotalLancamento.Margin = new Padding(3, 4, 3, 4);
            tbxTotalLancamento.Name = "tbxTotalLancamento";
            tbxTotalLancamento.Size = new Size(137, 27);
            tbxTotalLancamento.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1189, 64);
            label5.Name = "label5";
            label5.Size = new Size(124, 20);
            label5.TabIndex = 13;
            label5.Text = "Total lançamento";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1053, 64);
            label6.Name = "label6";
            label6.Size = new Size(127, 20);
            label6.TabIndex = 14;
            label6.Text = "Mês de referência";
            // 
            // rbtSaidas
            // 
            rbtSaidas.AutoSize = true;
            rbtSaidas.Location = new Point(7, 24);
            rbtSaidas.Margin = new Padding(3, 4, 3, 4);
            rbtSaidas.Name = "rbtSaidas";
            rbtSaidas.Size = new Size(73, 24);
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
            groupBox1.Location = new Point(870, 64);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(181, 64);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tipo de lançamento";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(90, 24);
            radioButton2.Margin = new Padding(3, 4, 3, 4);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(87, 24);
            radioButton2.TabIndex = 16;
            radioButton2.TabStop = true;
            radioButton2.Text = "Entradas";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(95, 68);
            label7.Name = "label7";
            label7.Size = new Size(74, 20);
            label7.TabIndex = 17;
            label7.Text = "Descrição";
            // 
            // tbxDescricao
            // 
            tbxDescricao.Location = new Point(95, 92);
            tbxDescricao.Margin = new Padding(3, 4, 3, 4);
            tbxDescricao.Name = "tbxDescricao";
            tbxDescricao.Size = new Size(218, 27);
            tbxDescricao.TabIndex = 18;
            // 
            // tbxValor
            // 
            tbxValor.Location = new Point(320, 92);
            tbxValor.Margin = new Padding(3, 4, 3, 4);
            tbxValor.Name = "tbxValor";
            tbxValor.Size = new Size(132, 27);
            tbxValor.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(320, 68);
            label8.Name = "label8";
            label8.Size = new Size(43, 20);
            label8.TabIndex = 19;
            label8.Text = "Valor";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 5);
            label9.Name = "label9";
            label9.Size = new Size(56, 20);
            label9.TabIndex = 21;
            label9.Text = "Parcela";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(66, 4);
            label10.Name = "label10";
            label10.Size = new Size(96, 20);
            label10.TabIndex = 23;
            label10.Text = "Qtd. parcelas";
            // 
            // cbxCategoria
            // 
            cbxCategoria.FormattingEnabled = true;
            cbxCategoria.Location = new Point(34, 163);
            cbxCategoria.Margin = new Padding(3, 4, 3, 4);
            cbxCategoria.Name = "cbxCategoria";
            cbxCategoria.Size = new Size(138, 28);
            cbxCategoria.TabIndex = 25;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(34, 140);
            label11.Name = "label11";
            label11.Size = new Size(74, 20);
            label11.TabIndex = 26;
            label11.Text = "Categoria";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(459, 68);
            label12.Name = "label12";
            label12.Size = new Size(144, 20);
            label12.TabIndex = 27;
            label12.Text = "Data de lançamento";
            // 
            // dtpDataLancamento
            // 
            dtpDataLancamento.Format = DateTimePickerFormat.Short;
            dtpDataLancamento.Location = new Point(459, 92);
            dtpDataLancamento.Margin = new Padding(3, 4, 3, 4);
            dtpDataLancamento.Name = "dtpDataLancamento";
            dtpDataLancamento.Size = new Size(129, 27);
            dtpDataLancamento.TabIndex = 28;
            // 
            // dtpDataInicial
            // 
            dtpDataInicial.Format = DateTimePickerFormat.Short;
            dtpDataInicial.Location = new Point(160, 29);
            dtpDataInicial.Margin = new Padding(3, 4, 3, 4);
            dtpDataInicial.Name = "dtpDataInicial";
            dtpDataInicial.Size = new Size(129, 27);
            dtpDataInicial.TabIndex = 30;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(160, 5);
            label13.Name = "label13";
            label13.Size = new Size(124, 20);
            label13.TabIndex = 29;
            label13.Text = "Dt. primeira parc.";
            // 
            // tbxValorTotal
            // 
            tbxValorTotal.Location = new Point(296, 28);
            tbxValorTotal.Margin = new Padding(3, 4, 3, 4);
            tbxValorTotal.Name = "tbxValorTotal";
            tbxValorTotal.Size = new Size(132, 27);
            tbxValorTotal.TabIndex = 32;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(296, 4);
            label14.Name = "label14";
            label14.Size = new Size(78, 20);
            label14.TabIndex = 31;
            label14.Text = "Valor total";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(325, 139);
            label15.Name = "label15";
            label15.Size = new Size(127, 20);
            label15.TabIndex = 34;
            label15.Text = "Mês de referência";
            // 
            // dtpMesReferenciaLancamento
            // 
            dtpMesReferenciaLancamento.Format = DateTimePickerFormat.Custom;
            dtpMesReferenciaLancamento.Location = new Point(325, 163);
            dtpMesReferenciaLancamento.Margin = new Padding(3, 4, 3, 4);
            dtpMesReferenciaLancamento.Name = "dtpMesReferenciaLancamento";
            dtpMesReferenciaLancamento.Size = new Size(118, 27);
            dtpMesReferenciaLancamento.TabIndex = 33;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(179, 140);
            label16.Name = "label16";
            label16.Size = new Size(48, 20);
            label16.TabIndex = 36;
            label16.Text = "Conta";
            // 
            // cbxContas
            // 
            cbxContas.FormattingEnabled = true;
            cbxContas.Location = new Point(179, 163);
            cbxContas.Margin = new Padding(3, 4, 3, 4);
            cbxContas.Name = "cbxContas";
            cbxContas.Size = new Size(138, 28);
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
            panelParcelas.Location = new Point(29, 213);
            panelParcelas.Margin = new Padding(3, 4, 3, 4);
            panelParcelas.Name = "panelParcelas";
            panelParcelas.Size = new Size(442, 71);
            panelParcelas.TabIndex = 37;
            // 
            // tbxNumParcela
            // 
            tbxNumParcela.Enabled = false;
            tbxNumParcela.Location = new Point(6, 29);
            tbxNumParcela.Margin = new Padding(3, 4, 3, 4);
            tbxNumParcela.Name = "tbxNumParcela";
            tbxNumParcela.Size = new Size(53, 27);
            tbxNumParcela.TabIndex = 49;
            // 
            // nudQtdParcelas
            // 
            nudQtdParcelas.Location = new Point(66, 29);
            nudQtdParcelas.Margin = new Padding(3, 4, 3, 4);
            nudQtdParcelas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQtdParcelas.Name = "nudQtdParcelas";
            nudQtdParcelas.Size = new Size(87, 27);
            nudQtdParcelas.TabIndex = 40;
            nudQtdParcelas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnSalvarLancamento
            // 
            btnSalvarLancamento.Location = new Point(112, 337);
            btnSalvarLancamento.Margin = new Padding(3, 4, 3, 4);
            btnSalvarLancamento.Name = "btnSalvarLancamento";
            btnSalvarLancamento.Size = new Size(86, 31);
            btnSalvarLancamento.TabIndex = 38;
            btnSalvarLancamento.Text = "Salvar";
            btnSalvarLancamento.UseVisualStyleBackColor = true;
            btnSalvarLancamento.Click += btnSalvarLancamento_Click;
            // 
            // tbxChaveLancamento
            // 
            tbxChaveLancamento.Enabled = false;
            tbxChaveLancamento.Location = new Point(34, 92);
            tbxChaveLancamento.Margin = new Padding(3, 4, 3, 4);
            tbxChaveLancamento.Name = "tbxChaveLancamento";
            tbxChaveLancamento.Size = new Size(53, 27);
            tbxChaveLancamento.TabIndex = 40;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(34, 69);
            label17.Name = "label17";
            label17.Size = new Size(24, 20);
            label17.TabIndex = 39;
            label17.Text = "ID";
            // 
            // tbxChaveConta
            // 
            tbxChaveConta.Enabled = false;
            tbxChaveConta.Location = new Point(14, 92);
            tbxChaveConta.Margin = new Padding(3, 4, 3, 4);
            tbxChaveConta.Name = "tbxChaveConta";
            tbxChaveConta.Size = new Size(53, 27);
            tbxChaveConta.TabIndex = 42;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(14, 69);
            label18.Name = "label18";
            label18.Size = new Size(24, 20);
            label18.TabIndex = 41;
            label18.Text = "ID";
            // 
            // lblTipoSaida
            // 
            lblTipoSaida.AutoSize = true;
            lblTipoSaida.Location = new Point(450, 140);
            lblTipoSaida.Name = "lblTipoSaida";
            lblTipoSaida.Size = new Size(99, 20);
            lblTipoSaida.TabIndex = 44;
            lblTipoSaida.Text = "Tipo de saída";
            // 
            // cbxTipoSaida
            // 
            cbxTipoSaida.FormattingEnabled = true;
            cbxTipoSaida.Items.AddRange(new object[] { "Crédito", "Dinheiro" });
            cbxTipoSaida.Location = new Point(450, 163);
            cbxTipoSaida.Margin = new Padding(3, 4, 3, 4);
            cbxTipoSaida.Name = "cbxTipoSaida";
            cbxTipoSaida.Size = new Size(138, 28);
            cbxTipoSaida.TabIndex = 43;
            // 
            // chxCredito
            // 
            chxCredito.AutoSize = true;
            chxCredito.Location = new Point(1370, 92);
            chxCredito.Margin = new Padding(3, 4, 3, 4);
            chxCredito.Name = "chxCredito";
            chxCredito.Size = new Size(80, 24);
            chxCredito.TabIndex = 45;
            chxCredito.Text = "Crédito";
            chxCredito.UseVisualStyleBackColor = true;
            chxCredito.CheckedChanged += chxCredito_CheckedChanged;
            // 
            // chxDinheiro
            // 
            chxDinheiro.AutoSize = true;
            chxDinheiro.Location = new Point(1451, 92);
            chxDinheiro.Margin = new Padding(3, 4, 3, 4);
            chxDinheiro.Name = "chxDinheiro";
            chxDinheiro.Size = new Size(88, 24);
            chxDinheiro.TabIndex = 46;
            chxDinheiro.Text = "Dinheiro";
            chxDinheiro.UseVisualStyleBackColor = true;
            chxDinheiro.CheckedChanged += chxDinheiro_CheckedChanged;
            // 
            // btnLimparLancamento
            // 
            btnLimparLancamento.Location = new Point(437, 337);
            btnLimparLancamento.Margin = new Padding(3, 4, 3, 4);
            btnLimparLancamento.Name = "btnLimparLancamento";
            btnLimparLancamento.Size = new Size(86, 31);
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
            panelLancamento.Location = new Point(330, 388);
            panelLancamento.Margin = new Padding(3, 4, 3, 4);
            panelLancamento.Name = "panelLancamento";
            panelLancamento.Size = new Size(620, 403);
            panelLancamento.TabIndex = 48;
            panelLancamento.Visible = false;
            // 
            // btnFecharMntLancamento
            // 
            btnFecharMntLancamento.Location = new Point(582, 4);
            btnFecharMntLancamento.Margin = new Padding(3, 4, 3, 4);
            btnFecharMntLancamento.Name = "btnFecharMntLancamento";
            btnFecharMntLancamento.Size = new Size(33, 31);
            btnFecharMntLancamento.TabIndex = 48;
            btnFecharMntLancamento.Text = "X";
            btnFecharMntLancamento.UseVisualStyleBackColor = true;
            btnFecharMntLancamento.Click += btnFecharMntLancamento_Click;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label19.Location = new Point(185, 17);
            label19.Name = "label19";
            label19.Size = new Size(269, 25);
            label19.TabIndex = 41;
            label19.Text = "Cadastrar/Alterar lançamentos";
            // 
            // btnNovoLancamento
            // 
            btnNovoLancamento.Location = new Point(1651, 91);
            btnNovoLancamento.Name = "btnNovoLancamento";
            btnNovoLancamento.Size = new Size(94, 29);
            btnNovoLancamento.TabIndex = 49;
            btnNovoLancamento.Text = "Novo";
            btnNovoLancamento.UseVisualStyleBackColor = true;
            btnNovoLancamento.Click += btnNovoLancamento_Click;
            // 
            // btnNovaConta
            // 
            btnNovaConta.Location = new Point(671, 92);
            btnNovaConta.Margin = new Padding(3, 4, 3, 4);
            btnNovaConta.Name = "btnNovaConta";
            btnNovaConta.Size = new Size(86, 31);
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
            menu.Padding = new Padding(7, 3, 0, 3);
            menu.Size = new Size(1766, 30);
            menu.TabIndex = 85;
            menu.Text = "menuStrip1";
            // 
            // lançamentosToolStripMenuItem
            // 
            lançamentosToolStripMenuItem.Name = "lançamentosToolStripMenuItem";
            lançamentosToolStripMenuItem.Size = new Size(110, 24);
            lançamentosToolStripMenuItem.Text = "Lançamentos";
            // 
            // categoriasToolStripMenuItem
            // 
            categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            categoriasToolStripMenuItem.Size = new Size(94, 24);
            categoriasToolStripMenuItem.Text = "Categorias";
            categoriasToolStripMenuItem.Click += categoriasToolStripMenuItem_Click;
            // 
            // mesesFuturoToolStripMenuItem
            // 
            mesesFuturoToolStripMenuItem.Name = "mesesFuturoToolStripMenuItem";
            mesesFuturoToolStripMenuItem.Size = new Size(108, 24);
            mesesFuturoToolStripMenuItem.Text = "Meses futuro";
            mesesFuturoToolStripMenuItem.Click += mesesFuturoToolStripMenuItem_Click;
            // 
            // geralToolStripMenuItem
            // 
            geralToolStripMenuItem.Name = "geralToolStripMenuItem";
            geralToolStripMenuItem.Size = new Size(58, 24);
            geralToolStripMenuItem.Text = "Geral";
            geralToolStripMenuItem.Click += geralToolStripMenuItem_Click;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(781, 841);
            label20.Name = "label20";
            label20.Size = new Size(132, 20);
            label20.TabIndex = 87;
            label20.Text = "Total selecionados";
            // 
            // tbxTotalSelecionados
            // 
            tbxTotalSelecionados.Location = new Point(781, 865);
            tbxTotalSelecionados.Margin = new Padding(3, 4, 3, 4);
            tbxTotalSelecionados.Name = "tbxTotalSelecionados";
            tbxTotalSelecionados.Size = new Size(137, 27);
            tbxTotalSelecionados.TabIndex = 86;
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1766, 1055);
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
            Margin = new Padding(3, 4, 3, 4);
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
    }
}