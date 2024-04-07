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
            dgvMesesFuturos = new DataGridView();
            groupBox2 = new GroupBox();
            radioButton1 = new RadioButton();
            rbtFiltroSaidaLancRecorrente = new RadioButton();
            dgvLancamentosRecorrentes = new DataGridView();
            btnNovoLancRecorrente = new Button();
            panelLancRecorrente = new Panel();
            label6 = new Label();
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
            label37 = new Label();
            menu = new MenuStrip();
            lançamentosToolStripMenuItem = new ToolStripMenuItem();
            categoriasToolStripMenuItem = new ToolStripMenuItem();
            mesesFuturoToolStripMenuItem = new ToolStripMenuItem();
            geralToolStripMenuItem = new ToolStripMenuItem();
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
            ((System.ComponentModel.ISupportInitialize)dgvMesesFuturos).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLancamentosRecorrentes).BeginInit();
            panelLancRecorrente.SuspendLayout();
            groupBox3.SuspendLayout();
            menu.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvMesesFuturos
            // 
            dgvMesesFuturos.BackgroundColor = SystemColors.ControlLightLight;
            dgvMesesFuturos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMesesFuturos.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvMesesFuturos.Location = new Point(839, 125);
            dgvMesesFuturos.MultiSelect = false;
            dgvMesesFuturos.Name = "dgvMesesFuturos";
            dgvMesesFuturos.RowHeadersWidth = 51;
            dgvMesesFuturos.Size = new Size(688, 328);
            dgvMesesFuturos.TabIndex = 88;
            dgvMesesFuturos.CellFormatting += dgvMesesFuturos_CellFormatting;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton1);
            groupBox2.Controls.Add(rbtFiltroSaidaLancRecorrente);
            groupBox2.Location = new Point(12, 78);
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
            dgvLancamentosRecorrentes.Location = new Point(12, 125);
            dgvLancamentosRecorrentes.MultiSelect = false;
            dgvLancamentosRecorrentes.Name = "dgvLancamentosRecorrentes";
            dgvLancamentosRecorrentes.RowHeadersWidth = 51;
            dgvLancamentosRecorrentes.Size = new Size(821, 328);
            dgvLancamentosRecorrentes.TabIndex = 86;
            dgvLancamentosRecorrentes.CellDoubleClick += dgvLancamentosRecorrentes_CellDoubleClick;
            dgvLancamentosRecorrentes.CellFormatting += dgvLancamentosRecorrentes_CellFormatting;
            dgvLancamentosRecorrentes.SelectionChanged += dgvLancamentosRecorrentes_SelectionChanged;
            dgvLancamentosRecorrentes.KeyDown += dgvLancamentosRecorrentes_KeyDown;
            // 
            // btnNovoLancRecorrente
            // 
            btnNovoLancRecorrente.Location = new Point(316, 93);
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
            panelLancRecorrente.Controls.Add(label6);
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
            panelLancRecorrente.Controls.Add(label37);
            panelLancRecorrente.Location = new Point(558, 169);
            panelLancRecorrente.Name = "panelLancRecorrente";
            panelLancRecorrente.Size = new Size(539, 215);
            panelLancRecorrente.TabIndex = 90;
            panelLancRecorrente.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 96);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 85;
            label6.Text = "Mês final";
            // 
            // dtpMesFinal
            // 
            dtpMesFinal.Format = DateTimePickerFormat.Custom;
            dtpMesFinal.Location = new Point(30, 114);
            dtpMesFinal.Name = "dtpMesFinal";
            dtpMesFinal.Size = new Size(104, 23);
            dtpMesFinal.TabIndex = 84;
            // 
            // chkLancObrigatorio
            // 
            chkLancObrigatorio.AutoSize = true;
            chkLancObrigatorio.Location = new Point(401, 113);
            chkLancObrigatorio.Name = "chkLancObrigatorio";
            chkLancObrigatorio.Size = new Size(87, 19);
            chkLancObrigatorio.TabIndex = 83;
            chkLancObrigatorio.Text = "Obrigatório";
            chkLancObrigatorio.UseVisualStyleBackColor = true;
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
            groupBox3.Location = new Point(151, 96);
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
            btnLimparLancRecorrente.Location = new Point(332, 164);
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
            tbxValorLancRecorrente.TextAlign = HorizontalAlignment.Right;
            // 
            // btnSalvarLancRecorrente
            // 
            btnSalvarLancRecorrente.Location = new Point(124, 164);
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
            cbxCategoriaLancRecorrente.Location = new Point(401, 68);
            cbxCategoriaLancRecorrente.Name = "cbxCategoriaLancRecorrente";
            cbxCategoriaLancRecorrente.Size = new Size(121, 23);
            cbxCategoriaLancRecorrente.TabIndex = 25;
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new Point(401, 51);
            label37.Name = "label37";
            label37.Size = new Size(58, 15);
            label37.TabIndex = 26;
            label37.Text = "Categoria";
            // 
            // menu
            // 
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { lançamentosToolStripMenuItem, categoriasToolStripMenuItem, mesesFuturoToolStripMenuItem, geralToolStripMenuItem });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(1545, 24);
            menu.TabIndex = 91;
            menu.Text = "menuStrip1";
            // 
            // lançamentosToolStripMenuItem
            // 
            lançamentosToolStripMenuItem.Name = "lançamentosToolStripMenuItem";
            lançamentosToolStripMenuItem.Size = new Size(90, 20);
            lançamentosToolStripMenuItem.Text = "Lançamentos";
            lançamentosToolStripMenuItem.Click += lançamentosToolStripMenuItem_Click;
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
            // 
            // geralToolStripMenuItem
            // 
            geralToolStripMenuItem.Name = "geralToolStripMenuItem";
            geralToolStripMenuItem.Size = new Size(46, 20);
            geralToolStripMenuItem.Text = "Geral";
            // 
            // tbxEntradaExtra
            // 
            tbxEntradaExtra.Location = new Point(839, 97);
            tbxEntradaExtra.Name = "tbxEntradaExtra";
            tbxEntradaExtra.Size = new Size(100, 23);
            tbxEntradaExtra.TabIndex = 92;
            tbxEntradaExtra.Text = "0";
            tbxEntradaExtra.TextAlign = HorizontalAlignment.Right;
            tbxEntradaExtra.TextChanged += tbxEntradaExtra_TextChanged;
            tbxEntradaExtra.Validated += tbxEntradaExtra_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(839, 79);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 93;
            label1.Text = "Entrada extra";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(945, 79);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 95;
            label2.Text = "Saída extra";
            // 
            // tbxSaidaExtra
            // 
            tbxSaidaExtra.Location = new Point(945, 97);
            tbxSaidaExtra.Name = "tbxSaidaExtra";
            tbxSaidaExtra.Size = new Size(100, 23);
            tbxSaidaExtra.TabIndex = 94;
            tbxSaidaExtra.Text = "0";
            tbxSaidaExtra.TextAlign = HorizontalAlignment.Right;
            tbxSaidaExtra.TextChanged += tbxSaidaExtra_TextChanged;
            tbxSaidaExtra.Validated += tbxSaidaExtra_Validated;
            // 
            // btnRecalcular
            // 
            btnRecalcular.Location = new Point(1069, 96);
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
            groupBox1.Location = new Point(12, 487);
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
            cbxCategoriaSimulacao.TabIndex = 87;
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
            btnSimular.TabIndex = 86;
            btnSimular.Text = "Simular";
            btnSimular.UseVisualStyleBackColor = true;
            btnSimular.Click += btnSimular_Click;
            // 
            // tbxQtdParcelas
            // 
            tbxQtdParcelas.Location = new Point(112, 43);
            tbxQtdParcelas.Name = "tbxQtdParcelas";
            tbxQtdParcelas.Size = new Size(100, 23);
            tbxQtdParcelas.TabIndex = 5;
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
            dtpDataInicialParcela.TabIndex = 2;
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
            // TelaMesesFuturo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1545, 791);
            Controls.Add(groupBox1);
            Controls.Add(btnRecalcular);
            Controls.Add(label2);
            Controls.Add(tbxSaidaExtra);
            Controls.Add(label1);
            Controls.Add(tbxEntradaExtra);
            Controls.Add(menu);
            Controls.Add(panelLancRecorrente);
            Controls.Add(dgvMesesFuturos);
            Controls.Add(groupBox2);
            Controls.Add(dgvLancamentosRecorrentes);
            Controls.Add(btnNovoLancRecorrente);
            Name = "TelaMesesFuturo";
            Text = "TelaMesesFuturo";
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
            menu.ResumeLayout(false);
            menu.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private Label label37;
        private MenuStrip menu;
        private ToolStripMenuItem lançamentosToolStripMenuItem;
        private ToolStripMenuItem categoriasToolStripMenuItem;
        private ToolStripMenuItem mesesFuturoToolStripMenuItem;
        private ToolStripMenuItem geralToolStripMenuItem;
        private TextBox tbxEntradaExtra;
        private Label label1;
        private Label label2;
        private TextBox tbxSaidaExtra;
        private Button btnRecalcular;
        private Label label6;
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
    }
}