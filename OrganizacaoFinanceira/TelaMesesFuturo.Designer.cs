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
            groupBox4 = new GroupBox();
            rbtMedia = new RadioButton();
            rbtLancamentoFuturo = new RadioButton();
            dgvMesesFuturos = new DataGridView();
            groupBox2 = new GroupBox();
            radioButton1 = new RadioButton();
            rbtFiltroSaidaLancRecorrente = new RadioButton();
            dgvLancamentosRecorrentes = new DataGridView();
            btnNovoLancRecorrente = new Button();
            panelLancRecorrente = new Panel();
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
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMesesFuturos).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLancamentosRecorrentes).BeginInit();
            panelLancRecorrente.SuspendLayout();
            groupBox3.SuspendLayout();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(rbtMedia);
            groupBox4.Controls.Add(rbtLancamentoFuturo);
            groupBox4.Location = new Point(781, 96);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(270, 64);
            groupBox4.TabIndex = 89;
            groupBox4.TabStop = false;
            groupBox4.Text = "Tipo previsão";
            // 
            // rbtMedia
            // 
            rbtMedia.AutoSize = true;
            rbtMedia.Location = new Point(194, 24);
            rbtMedia.Margin = new Padding(3, 4, 3, 4);
            rbtMedia.Name = "rbtMedia";
            rbtMedia.Size = new Size(72, 24);
            rbtMedia.TabIndex = 16;
            rbtMedia.Text = "Média";
            rbtMedia.UseVisualStyleBackColor = true;
            // 
            // rbtLancamentoFuturo
            // 
            rbtLancamentoFuturo.AutoSize = true;
            rbtLancamentoFuturo.Checked = true;
            rbtLancamentoFuturo.Location = new Point(7, 24);
            rbtLancamentoFuturo.Margin = new Padding(3, 4, 3, 4);
            rbtLancamentoFuturo.Name = "rbtLancamentoFuturo";
            rbtLancamentoFuturo.Size = new Size(195, 24);
            rbtLancamentoFuturo.TabIndex = 15;
            rbtLancamentoFuturo.TabStop = true;
            rbtLancamentoFuturo.Text = "Lançamentos recorrentes";
            rbtLancamentoFuturo.UseVisualStyleBackColor = true;
            // 
            // dgvMesesFuturos
            // 
            dgvMesesFuturos.BackgroundColor = SystemColors.ControlLightLight;
            dgvMesesFuturos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMesesFuturos.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvMesesFuturos.Location = new Point(781, 167);
            dgvMesesFuturos.Margin = new Padding(3, 4, 3, 4);
            dgvMesesFuturos.MultiSelect = false;
            dgvMesesFuturos.Name = "dgvMesesFuturos";
            dgvMesesFuturos.RowHeadersWidth = 51;
            dgvMesesFuturos.Size = new Size(965, 437);
            dgvMesesFuturos.TabIndex = 88;
            dgvMesesFuturos.CellFormatting += dgvMesesFuturos_CellFormatting;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton1);
            groupBox2.Controls.Add(rbtFiltroSaidaLancRecorrente);
            groupBox2.Location = new Point(14, 104);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(296, 56);
            groupBox2.TabIndex = 87;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tipo de lançamento recorrente";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(182, 23);
            radioButton1.Margin = new Padding(3, 4, 3, 4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(87, 24);
            radioButton1.TabIndex = 16;
            radioButton1.Text = "Entradas";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbtFiltroSaidaLancRecorrente
            // 
            rbtFiltroSaidaLancRecorrente.AutoSize = true;
            rbtFiltroSaidaLancRecorrente.Checked = true;
            rbtFiltroSaidaLancRecorrente.Location = new Point(42, 25);
            rbtFiltroSaidaLancRecorrente.Margin = new Padding(3, 4, 3, 4);
            rbtFiltroSaidaLancRecorrente.Name = "rbtFiltroSaidaLancRecorrente";
            rbtFiltroSaidaLancRecorrente.Size = new Size(73, 24);
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
            dgvLancamentosRecorrentes.Location = new Point(14, 167);
            dgvLancamentosRecorrentes.Margin = new Padding(3, 4, 3, 4);
            dgvLancamentosRecorrentes.MultiSelect = false;
            dgvLancamentosRecorrentes.Name = "dgvLancamentosRecorrentes";
            dgvLancamentosRecorrentes.RowHeadersWidth = 51;
            dgvLancamentosRecorrentes.Size = new Size(743, 437);
            dgvLancamentosRecorrentes.TabIndex = 86;
            dgvLancamentosRecorrentes.CellDoubleClick += dgvLancamentosRecorrentes_CellDoubleClick;
            dgvLancamentosRecorrentes.CellFormatting += dgvLancamentosRecorrentes_CellFormatting;
            dgvLancamentosRecorrentes.SelectionChanged += dgvLancamentosRecorrentes_SelectionChanged;
            dgvLancamentosRecorrentes.KeyDown += dgvLancamentosRecorrentes_KeyDown;
            // 
            // btnNovoLancRecorrente
            // 
            btnNovoLancRecorrente.Location = new Point(671, 128);
            btnNovoLancRecorrente.Margin = new Padding(3, 4, 3, 4);
            btnNovoLancRecorrente.Name = "btnNovoLancRecorrente";
            btnNovoLancRecorrente.Size = new Size(86, 31);
            btnNovoLancRecorrente.TabIndex = 85;
            btnNovoLancRecorrente.Text = "Novo";
            btnNovoLancRecorrente.UseVisualStyleBackColor = true;
            btnNovoLancRecorrente.Click += btnNovoLancRecorrente_Click;
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
            panelLancRecorrente.Location = new Point(917, 501);
            panelLancRecorrente.Margin = new Padding(3, 4, 3, 4);
            panelLancRecorrente.Name = "panelLancRecorrente";
            panelLancRecorrente.Size = new Size(519, 310);
            panelLancRecorrente.TabIndex = 90;
            panelLancRecorrente.Visible = false;
            // 
            // chkLancObrigatorio
            // 
            chkLancObrigatorio.AutoSize = true;
            chkLancObrigatorio.Location = new Point(34, 205);
            chkLancObrigatorio.Margin = new Padding(3, 4, 3, 4);
            chkLancObrigatorio.Name = "chkLancObrigatorio";
            chkLancObrigatorio.Size = new Size(109, 24);
            chkLancObrigatorio.TabIndex = 83;
            chkLancObrigatorio.Text = "Obrigatório";
            chkLancObrigatorio.UseVisualStyleBackColor = true;
            // 
            // tbxIdLancRecorrente
            // 
            tbxIdLancRecorrente.Enabled = false;
            tbxIdLancRecorrente.Location = new Point(34, 92);
            tbxIdLancRecorrente.Margin = new Padding(3, 4, 3, 4);
            tbxIdLancRecorrente.Name = "tbxIdLancRecorrente";
            tbxIdLancRecorrente.Size = new Size(53, 27);
            tbxIdLancRecorrente.TabIndex = 82;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rbtEntradaLancRecorrente);
            groupBox3.Controls.Add(rbtSaidaLancRecorrente);
            groupBox3.Location = new Point(194, 141);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(258, 56);
            groupBox3.TabIndex = 81;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tipo de lançamento recorrente";
            // 
            // rbtEntradaLancRecorrente
            // 
            rbtEntradaLancRecorrente.AutoSize = true;
            rbtEntradaLancRecorrente.Location = new Point(151, 23);
            rbtEntradaLancRecorrente.Margin = new Padding(3, 4, 3, 4);
            rbtEntradaLancRecorrente.Name = "rbtEntradaLancRecorrente";
            rbtEntradaLancRecorrente.Size = new Size(87, 24);
            rbtEntradaLancRecorrente.TabIndex = 16;
            rbtEntradaLancRecorrente.TabStop = true;
            rbtEntradaLancRecorrente.Text = "Entradas";
            rbtEntradaLancRecorrente.UseVisualStyleBackColor = true;
            // 
            // rbtSaidaLancRecorrente
            // 
            rbtSaidaLancRecorrente.AutoSize = true;
            rbtSaidaLancRecorrente.Location = new Point(33, 24);
            rbtSaidaLancRecorrente.Margin = new Padding(3, 4, 3, 4);
            rbtSaidaLancRecorrente.Name = "rbtSaidaLancRecorrente";
            rbtSaidaLancRecorrente.Size = new Size(73, 24);
            rbtSaidaLancRecorrente.TabIndex = 15;
            rbtSaidaLancRecorrente.TabStop = true;
            rbtSaidaLancRecorrente.Text = "Saídas";
            rbtSaidaLancRecorrente.UseVisualStyleBackColor = true;
            // 
            // btnFecharLancRecorrente
            // 
            btnFecharLancRecorrente.Location = new Point(467, 4);
            btnFecharLancRecorrente.Margin = new Padding(3, 4, 3, 4);
            btnFecharLancRecorrente.Name = "btnFecharLancRecorrente";
            btnFecharLancRecorrente.Size = new Size(33, 31);
            btnFecharLancRecorrente.TabIndex = 48;
            btnFecharLancRecorrente.Text = "X";
            btnFecharLancRecorrente.UseVisualStyleBackColor = true;
            btnFecharLancRecorrente.Click += btnFecharLancRecorrente_Click;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label26.Location = new Point(95, 13);
            label26.Name = "label26";
            label26.Size = new Size(370, 25);
            label26.TabIndex = 41;
            label26.Text = "Cadastrar/Alterar lançamentos recorrentes";
            // 
            // btnLimparLancRecorrente
            // 
            btnLimparLancRecorrente.Location = new Point(347, 239);
            btnLimparLancRecorrente.Margin = new Padding(3, 4, 3, 4);
            btnLimparLancRecorrente.Name = "btnLimparLancRecorrente";
            btnLimparLancRecorrente.Size = new Size(86, 31);
            btnLimparLancRecorrente.TabIndex = 47;
            btnLimparLancRecorrente.Text = "Limpar";
            btnLimparLancRecorrente.UseVisualStyleBackColor = true;
            btnLimparLancRecorrente.Click += btnLimparLancRecorrente_Click;
            // 
            // tbxDescLancRecorrente
            // 
            tbxDescLancRecorrente.Location = new Point(95, 92);
            tbxDescLancRecorrente.Margin = new Padding(3, 4, 3, 4);
            tbxDescLancRecorrente.Name = "tbxDescLancRecorrente";
            tbxDescLancRecorrente.Size = new Size(218, 27);
            tbxDescLancRecorrente.TabIndex = 18;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(95, 68);
            label27.Name = "label27";
            label27.Size = new Size(74, 20);
            label27.TabIndex = 17;
            label27.Text = "Descrição";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(320, 68);
            label28.Name = "label28";
            label28.Size = new Size(43, 20);
            label28.TabIndex = 19;
            label28.Text = "Valor";
            // 
            // tbxValorLancRecorrente
            // 
            tbxValorLancRecorrente.Location = new Point(320, 92);
            tbxValorLancRecorrente.Margin = new Padding(3, 4, 3, 4);
            tbxValorLancRecorrente.Name = "tbxValorLancRecorrente";
            tbxValorLancRecorrente.Size = new Size(132, 27);
            tbxValorLancRecorrente.TabIndex = 20;
            // 
            // btnSalvarLancRecorrente
            // 
            btnSalvarLancRecorrente.Location = new Point(109, 239);
            btnSalvarLancRecorrente.Margin = new Padding(3, 4, 3, 4);
            btnSalvarLancRecorrente.Name = "btnSalvarLancRecorrente";
            btnSalvarLancRecorrente.Size = new Size(86, 31);
            btnSalvarLancRecorrente.TabIndex = 38;
            btnSalvarLancRecorrente.Text = "Salvar";
            btnSalvarLancRecorrente.UseVisualStyleBackColor = true;
            btnSalvarLancRecorrente.Click += btnSalvarLancRecorrente_Click;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(34, 69);
            label31.Name = "label31";
            label31.Size = new Size(24, 20);
            label31.TabIndex = 39;
            label31.Text = "ID";
            // 
            // cbxCategoriaLancRecorrente
            // 
            cbxCategoriaLancRecorrente.FormattingEnabled = true;
            cbxCategoriaLancRecorrente.Location = new Point(34, 163);
            cbxCategoriaLancRecorrente.Margin = new Padding(3, 4, 3, 4);
            cbxCategoriaLancRecorrente.Name = "cbxCategoriaLancRecorrente";
            cbxCategoriaLancRecorrente.Size = new Size(138, 28);
            cbxCategoriaLancRecorrente.TabIndex = 25;
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new Point(34, 140);
            label37.Name = "label37";
            label37.Size = new Size(74, 20);
            label37.TabIndex = 26;
            label37.Text = "Categoria";
            // 
            // menu
            // 
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { lançamentosToolStripMenuItem, categoriasToolStripMenuItem, mesesFuturoToolStripMenuItem, geralToolStripMenuItem });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Padding = new Padding(7, 3, 0, 3);
            menu.Size = new Size(1766, 30);
            menu.TabIndex = 91;
            menu.Text = "menuStrip1";
            // 
            // lançamentosToolStripMenuItem
            // 
            lançamentosToolStripMenuItem.Name = "lançamentosToolStripMenuItem";
            lançamentosToolStripMenuItem.Size = new Size(110, 24);
            lançamentosToolStripMenuItem.Text = "Lançamentos";
            lançamentosToolStripMenuItem.Click += lançamentosToolStripMenuItem_Click;
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
            // 
            // geralToolStripMenuItem
            // 
            geralToolStripMenuItem.Name = "geralToolStripMenuItem";
            geralToolStripMenuItem.Size = new Size(58, 24);
            geralToolStripMenuItem.Text = "Geral";
            // 
            // tbxEntradaExtra
            // 
            tbxEntradaExtra.Location = new Point(1087, 125);
            tbxEntradaExtra.Margin = new Padding(3, 4, 3, 4);
            tbxEntradaExtra.Name = "tbxEntradaExtra";
            tbxEntradaExtra.Size = new Size(114, 27);
            tbxEntradaExtra.TabIndex = 92;
            tbxEntradaExtra.Text = "0";
            tbxEntradaExtra.TextChanged += tbxEntradaExtra_TextChanged;
            tbxEntradaExtra.Validated += tbxEntradaExtra_Validated;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1087, 101);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 93;
            label1.Text = "Entrada extra";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1208, 101);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 95;
            label2.Text = "Saída extra";
            // 
            // tbxSaidaExtra
            // 
            tbxSaidaExtra.Location = new Point(1208, 125);
            tbxSaidaExtra.Margin = new Padding(3, 4, 3, 4);
            tbxSaidaExtra.Name = "tbxSaidaExtra";
            tbxSaidaExtra.Size = new Size(114, 27);
            tbxSaidaExtra.TabIndex = 94;
            tbxSaidaExtra.Text = "0";
            tbxSaidaExtra.TextChanged += tbxSaidaExtra_TextChanged;
            tbxSaidaExtra.Validated += tbxSaidaExtra_Validated;
            // 
            // btnRecalcular
            // 
            btnRecalcular.Location = new Point(1350, 124);
            btnRecalcular.Margin = new Padding(3, 4, 3, 4);
            btnRecalcular.Name = "btnRecalcular";
            btnRecalcular.Size = new Size(86, 31);
            btnRecalcular.TabIndex = 96;
            btnRecalcular.Text = "Recalcular";
            btnRecalcular.UseVisualStyleBackColor = true;
            btnRecalcular.Click += btnRecalcular_Click;
            // 
            // TelaMesesFuturo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1766, 1055);
            Controls.Add(btnRecalcular);
            Controls.Add(label2);
            Controls.Add(tbxSaidaExtra);
            Controls.Add(label1);
            Controls.Add(tbxEntradaExtra);
            Controls.Add(menu);
            Controls.Add(panelLancRecorrente);
            Controls.Add(groupBox4);
            Controls.Add(dgvMesesFuturos);
            Controls.Add(groupBox2);
            Controls.Add(dgvLancamentosRecorrentes);
            Controls.Add(btnNovoLancRecorrente);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TelaMesesFuturo";
            Text = "TelaMesesFuturo";
            Load += TelaMesesFuturo_Load;
            Resize += TelaMesesFuturo_Resize;
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox4;
        private RadioButton rbtMedia;
        private RadioButton rbtLancamentoFuturo;
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
    }
}