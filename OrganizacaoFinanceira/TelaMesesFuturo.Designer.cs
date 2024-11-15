namespace OrganizacaoFinanceira
{
    partial class TelaMesesFuturo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaMesesFuturo));
            dgvMesesFuturos = new DataGridView();
            groupBox2 = new GroupBox();
            radioButton1 = new RadioButton();
            rbtFiltroSaidaLancRecorrente = new RadioButton();
            dgvLancamentosRecorrentes = new DataGridView();
            btnNovoLancRecorrente = new Button();
            panelLancRecorrente = new Panel();
            chkMesFixo = new CheckBox();
            lblMesFixo = new Label();
            dtpMesFixo = new DateTimePicker();
            lblMesFinal = new Label();
            dtpMesFinal = new DateTimePicker();
            chkLancObrigatorio = new CheckBox();
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
            lblCategoria = new Label();
            tbxEntradaExtra = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tbxSaidaExtra = new TextBox();
            btnRecalcular = new Button();
            groupBox1 = new GroupBox();
            cbxCategoriaSimulacao = new ComboBox();
            label7 = new Label();
            btnSimular = new Button();
            tbxQtdParcelas = new TextBox();
            label5 = new Label();
            label4 = new Label();
            dtpDataInicialParcela = new DateTimePicker();
            tbxValorMensal = new TextBox();
            label3 = new Label();
            lblTituloLancamentosCriados = new Label();
            lblTituloSaldosFuturo = new Label();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            panelLancaRecorrentes = new Panel();
            btnGerarDetalhes = new Button();
            lblLancamentoDetalhado = new Label();
            dgvLancRecorrenteDetalhado = new DataGridView();
            panelEntradaSaidaExtra = new Panel();
            panelSimularParcelamento = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvMesesFuturos).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLancamentosRecorrentes).BeginInit();
            panelLancRecorrente.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panelLancaRecorrentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLancRecorrenteDetalhado).BeginInit();
            panelEntradaSaidaExtra.SuspendLayout();
            panelSimularParcelamento.SuspendLayout();
            SuspendLayout();
            // 
            // dgvMesesFuturos
            // 
            dgvMesesFuturos.BackgroundColor = SystemColors.ControlLightLight;
            dgvMesesFuturos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMesesFuturos.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvMesesFuturos.Location = new Point(27, 173);
            dgvMesesFuturos.MultiSelect = false;
            dgvMesesFuturos.Name = "dgvMesesFuturos";
            dgvMesesFuturos.RowHeadersWidth = 51;
            dgvMesesFuturos.Size = new Size(688, 328);
            dgvMesesFuturos.TabIndex = 88;
            dgvMesesFuturos.CellFormatting += dgvMesesFuturos_CellFormatting;
            dgvMesesFuturos.ColumnWidthChanged += dgvMesesFuturos_ColumnWidthChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton1);
            groupBox2.Controls.Add(rbtFiltroSaidaLancRecorrente);
            groupBox2.Location = new Point(6, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(259, 42);
            groupBox2.TabIndex = 87;
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
            rbtFiltroSaidaLancRecorrente.Checked = true;
            rbtFiltroSaidaLancRecorrente.Location = new Point(37, 19);
            rbtFiltroSaidaLancRecorrente.Name = "rbtFiltroSaidaLancRecorrente";
            rbtFiltroSaidaLancRecorrente.Size = new Size(58, 19);
            rbtFiltroSaidaLancRecorrente.TabIndex = 15;
            rbtFiltroSaidaLancRecorrente.TabStop = true;
            rbtFiltroSaidaLancRecorrente.Text = "Saídas";
            rbtFiltroSaidaLancRecorrente.UseVisualStyleBackColor = true;
            rbtFiltroSaidaLancRecorrente.CheckedChanged += rbtFiltroSaidaLancRecorrente_CheckedChanged;
            // 
            // dgvLancamentosRecorrentes
            // 
            dgvLancamentosRecorrentes.BackgroundColor = SystemColors.ControlLightLight;
            dgvLancamentosRecorrentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLancamentosRecorrentes.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvLancamentosRecorrentes.Location = new Point(12, 72);
            dgvLancamentosRecorrentes.MultiSelect = false;
            dgvLancamentosRecorrentes.Name = "dgvLancamentosRecorrentes";
            dgvLancamentosRecorrentes.RowHeadersWidth = 51;
            dgvLancamentosRecorrentes.Size = new Size(821, 328);
            dgvLancamentosRecorrentes.TabIndex = 86;
            dgvLancamentosRecorrentes.CellDoubleClick += dgvLancamentosRecorrentes_CellDoubleClick;
            dgvLancamentosRecorrentes.CellFormatting += dgvLancamentosRecorrentes_CellFormatting;
            dgvLancamentosRecorrentes.ColumnWidthChanged += dgvLancamentosRecorrentes_ColumnWidthChanged;
            dgvLancamentosRecorrentes.SelectionChanged += dgvLancamentosRecorrentes_SelectionChanged;
            dgvLancamentosRecorrentes.KeyDown += dgvLancamentosRecorrentes_KeyDown;
            // 
            // btnNovoLancRecorrente
            // 
            btnNovoLancRecorrente.Location = new Point(310, 21);
            btnNovoLancRecorrente.Name = "btnNovoLancRecorrente";
            btnNovoLancRecorrente.Size = new Size(75, 23);
            btnNovoLancRecorrente.TabIndex = 85;
            btnNovoLancRecorrente.Text = "Novo";
            btnNovoLancRecorrente.UseVisualStyleBackColor = true;
            btnNovoLancRecorrente.Click += btnNovoLancRecorrente_Click;
            // 
            // panelLancRecorrente
            // 
            panelLancRecorrente.BackColor = Color.FromArgb(255, 224, 192);
            panelLancRecorrente.BorderStyle = BorderStyle.FixedSingle;
            panelLancRecorrente.Controls.Add(chkMesFixo);
            panelLancRecorrente.Controls.Add(lblMesFixo);
            panelLancRecorrente.Controls.Add(dtpMesFixo);
            panelLancRecorrente.Controls.Add(lblMesFinal);
            panelLancRecorrente.Controls.Add(dtpMesFinal);
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
            panelLancRecorrente.Controls.Add(lblCategoria);
            panelLancRecorrente.Location = new Point(186, 100);
            panelLancRecorrente.Name = "panelLancRecorrente";
            panelLancRecorrente.Size = new Size(539, 284);
            panelLancRecorrente.TabIndex = 90;
            panelLancRecorrente.Visible = false;
            // 
            // chkMesFixo
            // 
            chkMesFixo.AutoSize = true;
            chkMesFixo.Location = new Point(409, 71);
            chkMesFixo.Name = "chkMesFixo";
            chkMesFixo.Size = new Size(71, 19);
            chkMesFixo.TabIndex = 88;
            chkMesFixo.Text = "Mês fixo";
            chkMesFixo.UseVisualStyleBackColor = true;
            // 
            // lblMesFixo
            // 
            lblMesFixo.AutoSize = true;
            lblMesFixo.Location = new Point(276, 158);
            lblMesFixo.Name = "lblMesFixo";
            lblMesFixo.Size = new Size(52, 15);
            lblMesFixo.TabIndex = 87;
            lblMesFixo.Text = "Mês fixo";
            // 
            // dtpMesFixo
            // 
            dtpMesFixo.Format = DateTimePickerFormat.Custom;
            dtpMesFixo.Location = new Point(280, 176);
            dtpMesFixo.Name = "dtpMesFixo";
            dtpMesFixo.Size = new Size(104, 23);
            dtpMesFixo.TabIndex = 86;
            // 
            // lblMesFinal
            // 
            lblMesFinal.AutoSize = true;
            lblMesFinal.Location = new Point(388, 158);
            lblMesFinal.Name = "lblMesFinal";
            lblMesFinal.Size = new Size(55, 15);
            lblMesFinal.TabIndex = 85;
            lblMesFinal.Text = "Mês final";
            // 
            // dtpMesFinal
            // 
            dtpMesFinal.Format = DateTimePickerFormat.Custom;
            dtpMesFinal.Location = new Point(392, 176);
            dtpMesFinal.Name = "dtpMesFinal";
            dtpMesFinal.Size = new Size(104, 23);
            dtpMesFinal.TabIndex = 84;
            // 
            // chkLancObrigatorio
            // 
            chkLancObrigatorio.AutoSize = true;
            chkLancObrigatorio.Location = new Point(278, 71);
            chkLancObrigatorio.Name = "chkLancObrigatorio";
            chkLancObrigatorio.Size = new Size(87, 19);
            chkLancObrigatorio.TabIndex = 83;
            chkLancObrigatorio.Text = "Obrigatório";
            chkLancObrigatorio.UseVisualStyleBackColor = true;
            // 
            // tbxIdLancRecorrente
            // 
            tbxIdLancRecorrente.Enabled = false;
            tbxIdLancRecorrente.Location = new Point(28, 133);
            tbxIdLancRecorrente.Name = "tbxIdLancRecorrente";
            tbxIdLancRecorrente.Size = new Size(47, 23);
            tbxIdLancRecorrente.TabIndex = 82;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rbtEntradaLancRecorrente);
            groupBox3.Controls.Add(rbtSaidaLancRecorrente);
            groupBox3.Location = new Point(28, 54);
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
            rbtEntradaLancRecorrente.CheckedChanged += rbtEntradaLancRecorrente_CheckedChanged;
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
            btnLimparLancRecorrente.Location = new Point(333, 234);
            btnLimparLancRecorrente.Name = "btnLimparLancRecorrente";
            btnLimparLancRecorrente.Size = new Size(75, 23);
            btnLimparLancRecorrente.TabIndex = 47;
            btnLimparLancRecorrente.Text = "Limpar";
            btnLimparLancRecorrente.UseVisualStyleBackColor = true;
            btnLimparLancRecorrente.Click += btnLimparLancRecorrente_Click;
            // 
            // tbxDescLancRecorrente
            // 
            tbxDescLancRecorrente.Location = new Point(81, 133);
            tbxDescLancRecorrente.Name = "tbxDescLancRecorrente";
            tbxDescLancRecorrente.Size = new Size(303, 23);
            tbxDescLancRecorrente.TabIndex = 18;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(81, 115);
            label27.Name = "label27";
            label27.Size = new Size(58, 15);
            label27.TabIndex = 17;
            label27.Text = "Descrição";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(392, 114);
            label28.Name = "label28";
            label28.Size = new Size(33, 15);
            label28.TabIndex = 19;
            label28.Text = "Valor";
            // 
            // tbxValorLancRecorrente
            // 
            tbxValorLancRecorrente.Location = new Point(392, 132);
            tbxValorLancRecorrente.Name = "tbxValorLancRecorrente";
            tbxValorLancRecorrente.Size = new Size(116, 23);
            tbxValorLancRecorrente.TabIndex = 20;
            tbxValorLancRecorrente.TextAlign = HorizontalAlignment.Right;
            // 
            // btnSalvarLancRecorrente
            // 
            btnSalvarLancRecorrente.Location = new Point(125, 234);
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
            label31.Location = new Point(28, 116);
            label31.Name = "label31";
            label31.Size = new Size(18, 15);
            label31.TabIndex = 39;
            label31.Text = "ID";
            // 
            // cbxCategoriaLancRecorrente
            // 
            cbxCategoriaLancRecorrente.FormattingEnabled = true;
            cbxCategoriaLancRecorrente.Location = new Point(28, 176);
            cbxCategoriaLancRecorrente.Name = "cbxCategoriaLancRecorrente";
            cbxCategoriaLancRecorrente.Size = new Size(244, 23);
            cbxCategoriaLancRecorrente.TabIndex = 25;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(28, 159);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(58, 15);
            lblCategoria.TabIndex = 26;
            lblCategoria.Text = "Categoria";
            // 
            // tbxEntradaExtra
            // 
            tbxEntradaExtra.Location = new Point(3, 23);
            tbxEntradaExtra.Name = "tbxEntradaExtra";
            tbxEntradaExtra.Size = new Size(100, 23);
            tbxEntradaExtra.TabIndex = 92;
            tbxEntradaExtra.Text = "0";
            tbxEntradaExtra.TextAlign = HorizontalAlignment.Right;
            tbxEntradaExtra.TextChanged += tbxEntradaExtra_TextChanged;
            tbxEntradaExtra.KeyDown += tbxEntradaExtra_KeyDown;
            tbxEntradaExtra.Validated += tbxEntradaExtra_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 93;
            label1.Text = "Entrada extra";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(109, 5);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 95;
            label2.Text = "Saída extra";
            // 
            // tbxSaidaExtra
            // 
            tbxSaidaExtra.Location = new Point(109, 23);
            tbxSaidaExtra.Name = "tbxSaidaExtra";
            tbxSaidaExtra.Size = new Size(100, 23);
            tbxSaidaExtra.TabIndex = 94;
            tbxSaidaExtra.Text = "0";
            tbxSaidaExtra.TextAlign = HorizontalAlignment.Right;
            tbxSaidaExtra.TextChanged += tbxSaidaExtra_TextChanged;
            tbxSaidaExtra.KeyDown += tbxSaidaExtra_KeyDown;
            tbxSaidaExtra.Validated += tbxSaidaExtra_Validated;
            // 
            // btnRecalcular
            // 
            btnRecalcular.Location = new Point(215, 23);
            btnRecalcular.Name = "btnRecalcular";
            btnRecalcular.Size = new Size(75, 23);
            btnRecalcular.TabIndex = 96;
            btnRecalcular.Text = "Recalcular";
            btnRecalcular.UseVisualStyleBackColor = true;
            btnRecalcular.Click += btnRecalcular_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbxCategoriaSimulacao);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(btnSimular);
            groupBox1.Controls.Add(tbxQtdParcelas);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dtpDataInicialParcela);
            groupBox1.Controls.Add(tbxValorMensal);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(595, 78);
            groupBox1.TabIndex = 97;
            groupBox1.TabStop = false;
            groupBox1.Text = "Simular parcelamento";
            // 
            // cbxCategoriaSimulacao
            // 
            cbxCategoriaSimulacao.FormattingEnabled = true;
            cbxCategoriaSimulacao.Location = new Point(341, 42);
            cbxCategoriaSimulacao.Name = "cbxCategoriaSimulacao";
            cbxCategoriaSimulacao.Size = new Size(121, 23);
            cbxCategoriaSimulacao.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(341, 25);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 88;
            label7.Text = "Categoria";
            // 
            // btnSimular
            // 
            btnSimular.Location = new Point(493, 41);
            btnSimular.Name = "btnSimular";
            btnSimular.Size = new Size(75, 23);
            btnSimular.TabIndex = 5;
            btnSimular.Text = "Simular";
            btnSimular.UseVisualStyleBackColor = true;
            btnSimular.Click += btnSimular_Click;
            // 
            // tbxQtdParcelas
            // 
            tbxQtdParcelas.Location = new Point(112, 43);
            tbxQtdParcelas.Name = "tbxQtdParcelas";
            tbxQtdParcelas.Size = new Size(100, 23);
            tbxQtdParcelas.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(112, 25);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 4;
            label5.Text = "Qtd parcelas";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(218, 25);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 3;
            label4.Text = "Data inicio";
            // 
            // dtpDataInicialParcela
            // 
            dtpDataInicialParcela.Format = DateTimePickerFormat.Short;
            dtpDataInicialParcela.Location = new Point(218, 43);
            dtpDataInicialParcela.Name = "dtpDataInicialParcela";
            dtpDataInicialParcela.Size = new Size(117, 23);
            dtpDataInicialParcela.TabIndex = 3;
            // 
            // tbxValorMensal
            // 
            tbxValorMensal.Location = new Point(6, 43);
            tbxValorMensal.Name = "tbxValorMensal";
            tbxValorMensal.Size = new Size(100, 23);
            tbxValorMensal.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 25);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 0;
            label3.Text = "Valor mensal";
            // 
            // lblTituloLancamentosCriados
            // 
            lblTituloLancamentosCriados.AutoSize = true;
            lblTituloLancamentosCriados.Location = new Point(12, 417);
            lblTituloLancamentosCriados.Name = "lblTituloLancamentosCriados";
            lblTituloLancamentosCriados.Size = new Size(119, 15);
            lblTituloLancamentosCriados.TabIndex = 98;
            lblTituloLancamentosCriados.Text = "Lançamentos criados";
            // 
            // lblTituloSaldosFuturo
            // 
            lblTituloSaldosFuturo.AutoSize = true;
            lblTituloSaldosFuturo.Location = new Point(907, 45);
            lblTituloSaldosFuturo.Name = "lblTituloSaldosFuturo";
            lblTituloSaldosFuturo.Size = new Size(108, 15);
            lblTituloSaldosFuturo.TabIndex = 99;
            lblTituloSaldosFuturo.Text = "Saldo final por mês";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelEntradaSaidaExtra);
            splitContainer1.Panel2.Controls.Add(lblTituloSaldosFuturo);
            splitContainer1.Panel2.Controls.Add(dgvMesesFuturos);
            splitContainer1.Panel2.Controls.Add(panelSimularParcelamento);
            splitContainer1.Size = new Size(2202, 791);
            splitContainer1.SplitterDistance = 1091;
            splitContainer1.TabIndex = 100;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(lblTituloLancamentosCriados);
            splitContainer2.Panel1.Controls.Add(panelLancaRecorrentes);
            splitContainer2.Panel1.Controls.Add(panelLancRecorrente);
            splitContainer2.Panel1.Controls.Add(dgvLancamentosRecorrentes);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(lblLancamentoDetalhado);
            splitContainer2.Panel2.Controls.Add(dgvLancRecorrenteDetalhado);
            splitContainer2.Size = new Size(1091, 791);
            splitContainer2.SplitterDistance = 459;
            splitContainer2.TabIndex = 101;
            splitContainer2.SplitterMoved += splitContainer2_SplitterMoved;
            // 
            // panelLancaRecorrentes
            // 
            panelLancaRecorrentes.Controls.Add(btnGerarDetalhes);
            panelLancaRecorrentes.Controls.Add(groupBox2);
            panelLancaRecorrentes.Controls.Add(btnNovoLancRecorrente);
            panelLancaRecorrentes.Location = new Point(12, 12);
            panelLancaRecorrentes.Name = "panelLancaRecorrentes";
            panelLancaRecorrentes.Size = new Size(600, 59);
            panelLancaRecorrentes.TabIndex = 99;
            // 
            // btnGerarDetalhes
            // 
            btnGerarDetalhes.Location = new Point(420, 21);
            btnGerarDetalhes.Name = "btnGerarDetalhes";
            btnGerarDetalhes.Size = new Size(177, 23);
            btnGerarDetalhes.TabIndex = 88;
            btnGerarDetalhes.Text = "Gerar entrada detalhado";
            btnGerarDetalhes.UseVisualStyleBackColor = true;
            btnGerarDetalhes.Click += btnGerarDetalhes_Click;
            // 
            // lblLancamentoDetalhado
            // 
            lblLancamentoDetalhado.AutoSize = true;
            lblLancamentoDetalhado.Location = new Point(883, 78);
            lblLancamentoDetalhado.Name = "lblLancamentoDetalhado";
            lblLancamentoDetalhado.Size = new Size(139, 15);
            lblLancamentoDetalhado.TabIndex = 99;
            lblLancamentoDetalhado.Text = "Lançamentos detalhados";
            // 
            // dgvLancRecorrenteDetalhado
            // 
            dgvLancRecorrenteDetalhado.BackgroundColor = SystemColors.ControlLightLight;
            dgvLancRecorrenteDetalhado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLancRecorrenteDetalhado.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvLancRecorrenteDetalhado.Location = new Point(12, 23);
            dgvLancRecorrenteDetalhado.MultiSelect = false;
            dgvLancRecorrenteDetalhado.Name = "dgvLancRecorrenteDetalhado";
            dgvLancRecorrenteDetalhado.RowHeadersWidth = 51;
            dgvLancRecorrenteDetalhado.Size = new Size(821, 267);
            dgvLancRecorrenteDetalhado.TabIndex = 87;
            dgvLancRecorrenteDetalhado.CellFormatting += dgvLancRecorrenteDetalhado_CellFormatting;
            // 
            // panelEntradaSaidaExtra
            // 
            panelEntradaSaidaExtra.Controls.Add(tbxEntradaExtra);
            panelEntradaSaidaExtra.Controls.Add(tbxSaidaExtra);
            panelEntradaSaidaExtra.Controls.Add(label1);
            panelEntradaSaidaExtra.Controls.Add(btnRecalcular);
            panelEntradaSaidaExtra.Controls.Add(label2);
            panelEntradaSaidaExtra.Location = new Point(27, 122);
            panelEntradaSaidaExtra.Name = "panelEntradaSaidaExtra";
            panelEntradaSaidaExtra.Size = new Size(298, 53);
            panelEntradaSaidaExtra.TabIndex = 100;
            // 
            // panelSimularParcelamento
            // 
            panelSimularParcelamento.Controls.Add(groupBox1);
            panelSimularParcelamento.Location = new Point(24, 18);
            panelSimularParcelamento.Name = "panelSimularParcelamento";
            panelSimularParcelamento.Size = new Size(611, 87);
            panelSimularParcelamento.TabIndex = 100;
            // 
            // TelaMesesFuturo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2202, 791);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TelaMesesFuturo";
            Text = "Previsão meses";
            FormClosed += TelaMesesFuturo_FormClosed;
            Load += TelaMesesFuturo_Load;
            Resize += TelaMesesFuturo_Resize;
            ((System.ComponentModel.ISupportInitialize)dgvMesesFuturos).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLancamentosRecorrentes).EndInit();
            panelLancRecorrente.ResumeLayout(false);
            panelLancRecorrente.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panelLancaRecorrentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLancRecorrenteDetalhado).EndInit();
            panelEntradaSaidaExtra.ResumeLayout(false);
            panelEntradaSaidaExtra.PerformLayout();
            panelSimularParcelamento.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvMesesFuturos;
        private GroupBox groupBox2;
        private RadioButton radioButton1;
        private RadioButton rbtFiltroSaidaLancRecorrente;
        private DataGridView dgvLancamentosRecorrentes;
        private Button btnNovoLancRecorrente;
        private Panel panelLancRecorrente;
        private CheckBox chkLancObrigatorio;
        private TextBox tbxIdLancRecorrente;
        private GroupBox groupBox3;
        private RadioButton rbtEntradaLancRecorrente;
        private RadioButton rbtSaidaLancRecorrente;
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
        private Label lblCategoria;
        private TextBox tbxEntradaExtra;
        private Label label1;
        private Label label2;
        private TextBox tbxSaidaExtra;
        private Button btnRecalcular;
        private Label lblMesFinal;
        private DateTimePicker dtpMesFinal;
        private GroupBox groupBox1;
        private TextBox tbxValorMensal;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpDataInicialParcela;
        private TextBox tbxQtdParcelas;
        private Label label5;
        private Button btnSimular;
        private ComboBox cbxCategoriaSimulacao;
        private Label label7;
        private Label lblTituloLancamentosCriados;
        private Label lblTituloSaldosFuturo;
        private Label lblMesFixo;
        private DateTimePicker dtpMesFixo;
        private CheckBox chkMesFixo;
        private SplitContainer splitContainer1;
        private Panel panelLancaRecorrentes;
        private Panel panelEntradaSaidaExtra;
        private Panel panelSimularParcelamento;
        private SplitContainer splitContainer2;
        private DataGridView dgvLancRecorrenteDetalhado;
        private Label lblLancamentoDetalhado;
        private Button btnGerarDetalhes;
    }
}