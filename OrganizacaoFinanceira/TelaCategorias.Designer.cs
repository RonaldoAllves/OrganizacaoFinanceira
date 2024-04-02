namespace OrganizacaoFinanceira
{
    partial class TelaCategorias
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
            menu = new MenuStrip();
            lançamentosToolStripMenuItem = new ToolStripMenuItem();
            categoriasToolStripMenuItem = new ToolStripMenuItem();
            mesesFuturoToolStripMenuItem = new ToolStripMenuItem();
            geralToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            dtpMesRefVerbaTotal = new DateTimePicker();
            tbxVerbaTotalMes = new TextBox();
            label2 = new Label();
            dgvVerbasPorMes = new DataGridView();
            tbxSaldoTotalMes = new TextBox();
            label3 = new Label();
            dgvCategorias = new DataGridView();
            label21 = new Label();
            tbxDescCategoria = new TextBox();
            label22 = new Label();
            tbxVerbaPadraoCat = new TextBox();
            btnSalvarCategoria = new Button();
            label24 = new Label();
            tbxIdCategoria = new TextBox();
            btnLimparCategoria = new Button();
            chxTodosMeses = new CheckBox();
            dgvMeses = new DataGridView();
            btnLimparMes = new Button();
            dtpMesCategoria = new DateTimePicker();
            tbxIdMes = new TextBox();
            label20 = new Label();
            label25 = new Label();
            label23 = new Label();
            tbxVerbaMesCategoria = new TextBox();
            btnCriarMes = new Button();
            panelDivisor = new Panel();
            menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVerbasPorMes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMeses).BeginInit();
            SuspendLayout();
            // 
            // menu
            // 
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { lançamentosToolStripMenuItem, categoriasToolStripMenuItem, mesesFuturoToolStripMenuItem, geralToolStripMenuItem });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(1684, 24);
            menu.TabIndex = 89;
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
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(573, 57);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 91;
            label1.Text = "Mês de referência";
            // 
            // dtpMesRefVerbaTotal
            // 
            dtpMesRefVerbaTotal.Format = DateTimePickerFormat.Custom;
            dtpMesRefVerbaTotal.Location = new Point(576, 75);
            dtpMesRefVerbaTotal.Name = "dtpMesRefVerbaTotal";
            dtpMesRefVerbaTotal.Size = new Size(104, 23);
            dtpMesRefVerbaTotal.TabIndex = 90;
            dtpMesRefVerbaTotal.ValueChanged += dtpMesRefVerbaTotal_ValueChanged;
            // 
            // tbxVerbaTotalMes
            // 
            tbxVerbaTotalMes.Location = new Point(708, 75);
            tbxVerbaTotalMes.Margin = new Padding(3, 2, 3, 2);
            tbxVerbaTotalMes.Name = "tbxVerbaTotalMes";
            tbxVerbaTotalMes.Size = new Size(131, 23);
            tbxVerbaTotalMes.TabIndex = 93;
            tbxVerbaTotalMes.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(705, 58);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 92;
            label2.Text = "Verba total no mês";
            // 
            // dgvVerbasPorMes
            // 
            dgvVerbasPorMes.BackgroundColor = SystemColors.ControlLightLight;
            dgvVerbasPorMes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVerbasPorMes.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvVerbasPorMes.Location = new Point(576, 102);
            dgvVerbasPorMes.MultiSelect = false;
            dgvVerbasPorMes.Name = "dgvVerbasPorMes";
            dgvVerbasPorMes.RowHeadersWidth = 51;
            dgvVerbasPorMes.Size = new Size(1416, 670);
            dgvVerbasPorMes.TabIndex = 94;
            dgvVerbasPorMes.CellFormatting += dgvVerbasPorMes_CellFormatting;
            // 
            // tbxSaldoTotalMes
            // 
            tbxSaldoTotalMes.Location = new Point(844, 75);
            tbxSaldoTotalMes.Margin = new Padding(3, 2, 3, 2);
            tbxSaldoTotalMes.Name = "tbxSaldoTotalMes";
            tbxSaldoTotalMes.Size = new Size(131, 23);
            tbxSaldoTotalMes.TabIndex = 96;
            tbxSaldoTotalMes.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(840, 58);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 95;
            label3.Text = "Saldo total no mês";
            // 
            // dgvCategorias
            // 
            dgvCategorias.BackgroundColor = SystemColors.ControlLightLight;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvCategorias.Location = new Point(10, 102);
            dgvCategorias.MultiSelect = false;
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.RowHeadersWidth = 51;
            dgvCategorias.Size = new Size(532, 440);
            dgvCategorias.TabIndex = 99;
            dgvCategorias.CellDoubleClick += dgvCategorias_CellDoubleClick;
            dgvCategorias.CellFormatting += dgvCategorias_CellFormatting;
            dgvCategorias.SelectionChanged += dgvCategorias_SelectionChanged;
            dgvCategorias.KeyDown += dgvCategorias_KeyDown;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(60, 58);
            label21.Name = "label21";
            label21.Size = new Size(58, 15);
            label21.TabIndex = 100;
            label21.Text = "Categoria";
            // 
            // tbxDescCategoria
            // 
            tbxDescCategoria.Location = new Point(63, 75);
            tbxDescCategoria.Margin = new Padding(3, 2, 3, 2);
            tbxDescCategoria.Name = "tbxDescCategoria";
            tbxDescCategoria.Size = new Size(153, 23);
            tbxDescCategoria.TabIndex = 101;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(217, 58);
            label22.Name = "label22";
            label22.Size = new Size(76, 15);
            label22.TabIndex = 102;
            label22.Text = "Verba padrão";
            // 
            // tbxVerbaPadraoCat
            // 
            tbxVerbaPadraoCat.Location = new Point(220, 75);
            tbxVerbaPadraoCat.Margin = new Padding(3, 2, 3, 2);
            tbxVerbaPadraoCat.Name = "tbxVerbaPadraoCat";
            tbxVerbaPadraoCat.Size = new Size(131, 23);
            tbxVerbaPadraoCat.TabIndex = 103;
            tbxVerbaPadraoCat.TextAlign = HorizontalAlignment.Right;
            // 
            // btnSalvarCategoria
            // 
            btnSalvarCategoria.Location = new Point(356, 73);
            btnSalvarCategoria.Name = "btnSalvarCategoria";
            btnSalvarCategoria.Size = new Size(75, 23);
            btnSalvarCategoria.TabIndex = 106;
            btnSalvarCategoria.Text = "Salvar";
            btnSalvarCategoria.UseVisualStyleBackColor = true;
            btnSalvarCategoria.Click += btnSalvarCategoria_Click;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(10, 58);
            label24.Name = "label24";
            label24.Size = new Size(18, 15);
            label24.TabIndex = 109;
            label24.Text = "ID";
            // 
            // tbxIdCategoria
            // 
            tbxIdCategoria.Enabled = false;
            tbxIdCategoria.Location = new Point(10, 75);
            tbxIdCategoria.Name = "tbxIdCategoria";
            tbxIdCategoria.Size = new Size(47, 23);
            tbxIdCategoria.TabIndex = 110;
            // 
            // btnLimparCategoria
            // 
            btnLimparCategoria.Location = new Point(437, 72);
            btnLimparCategoria.Name = "btnLimparCategoria";
            btnLimparCategoria.Size = new Size(75, 23);
            btnLimparCategoria.TabIndex = 111;
            btnLimparCategoria.Text = "Limpar";
            btnLimparCategoria.UseVisualStyleBackColor = true;
            btnLimparCategoria.Click += btnLimparCategoria_Click;
            // 
            // chxTodosMeses
            // 
            chxTodosMeses.AutoSize = true;
            chxTodosMeses.Location = new Point(450, 574);
            chxTodosMeses.Margin = new Padding(3, 2, 3, 2);
            chxTodosMeses.Name = "chxTodosMeses";
            chxTodosMeses.Size = new Size(93, 19);
            chxTodosMeses.TabIndex = 115;
            chxTodosMeses.Text = "Todos meses";
            chxTodosMeses.UseVisualStyleBackColor = true;
            chxTodosMeses.Click += chxTodosMeses_CheckedChanged;
            // 
            // dgvMeses
            // 
            dgvMeses.BackgroundColor = SystemColors.ControlLightLight;
            dgvMeses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMeses.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvMeses.Location = new Point(10, 605);
            dgvMeses.MultiSelect = false;
            dgvMeses.Name = "dgvMeses";
            dgvMeses.RowHeadersWidth = 51;
            dgvMeses.Size = new Size(532, 167);
            dgvMeses.TabIndex = 108;
            dgvMeses.CellDoubleClick += dgvMeses_CellDoubleClick;
            dgvMeses.CellFormatting += dgvMeses_CellFormatting;
            dgvMeses.SelectionChanged += dgvMeses_SelectionChanged;
            // 
            // btnLimparMes
            // 
            btnLimparMes.Location = new Point(368, 572);
            btnLimparMes.Name = "btnLimparMes";
            btnLimparMes.Size = new Size(75, 22);
            btnLimparMes.TabIndex = 114;
            btnLimparMes.Text = "Limpar";
            btnLimparMes.UseVisualStyleBackColor = true;
            btnLimparMes.Click += btnLimparMes_Click;
            // 
            // dtpMesCategoria
            // 
            dtpMesCategoria.Format = DateTimePickerFormat.Custom;
            dtpMesCategoria.Location = new Point(10, 572);
            dtpMesCategoria.Name = "dtpMesCategoria";
            dtpMesCategoria.Size = new Size(104, 23);
            dtpMesCategoria.TabIndex = 97;
            dtpMesCategoria.ValueChanged += dtpMesCategoria_ValueChanged;
            // 
            // tbxIdMes
            // 
            tbxIdMes.Enabled = false;
            tbxIdMes.Location = new Point(126, 572);
            tbxIdMes.Name = "tbxIdMes";
            tbxIdMes.Size = new Size(47, 23);
            tbxIdMes.TabIndex = 113;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(7, 554);
            label20.Name = "label20";
            label20.Size = new Size(100, 15);
            label20.TabIndex = 98;
            label20.Text = "Mês de referência";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(126, 555);
            label25.Name = "label25";
            label25.Size = new Size(18, 15);
            label25.TabIndex = 112;
            label25.Text = "ID";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(177, 555);
            label23.Name = "label23";
            label23.Size = new Size(61, 15);
            label23.TabIndex = 104;
            label23.Text = "Verba mês";
            // 
            // tbxVerbaMesCategoria
            // 
            tbxVerbaMesCategoria.Location = new Point(179, 572);
            tbxVerbaMesCategoria.Margin = new Padding(3, 2, 3, 2);
            tbxVerbaMesCategoria.Name = "tbxVerbaMesCategoria";
            tbxVerbaMesCategoria.Size = new Size(76, 23);
            tbxVerbaMesCategoria.TabIndex = 105;
            tbxVerbaMesCategoria.TextAlign = HorizontalAlignment.Right;
            // 
            // btnCriarMes
            // 
            btnCriarMes.Location = new Point(261, 572);
            btnCriarMes.Margin = new Padding(3, 2, 3, 2);
            btnCriarMes.Name = "btnCriarMes";
            btnCriarMes.Size = new Size(102, 22);
            btnCriarMes.TabIndex = 107;
            btnCriarMes.Text = "Salvar/Criar mês";
            btnCriarMes.UseVisualStyleBackColor = true;
            btnCriarMes.Click += btnCriarMes_Click;
            // 
            // panelDivisor
            // 
            panelDivisor.BorderStyle = BorderStyle.FixedSingle;
            panelDivisor.Location = new Point(558, 42);
            panelDivisor.Margin = new Padding(3, 2, 3, 2);
            panelDivisor.Name = "panelDivisor";
            panelDivisor.Size = new Size(3, 739);
            panelDivisor.TabIndex = 116;
            // 
            // TelaCategorias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1684, 789);
            Controls.Add(panelDivisor);
            Controls.Add(dgvCategorias);
            Controls.Add(label21);
            Controls.Add(tbxDescCategoria);
            Controls.Add(label22);
            Controls.Add(tbxVerbaPadraoCat);
            Controls.Add(btnSalvarCategoria);
            Controls.Add(label24);
            Controls.Add(tbxIdCategoria);
            Controls.Add(btnLimparCategoria);
            Controls.Add(chxTodosMeses);
            Controls.Add(dgvMeses);
            Controls.Add(btnLimparMes);
            Controls.Add(dtpMesCategoria);
            Controls.Add(tbxIdMes);
            Controls.Add(label20);
            Controls.Add(label25);
            Controls.Add(label23);
            Controls.Add(tbxVerbaMesCategoria);
            Controls.Add(btnCriarMes);
            Controls.Add(tbxSaldoTotalMes);
            Controls.Add(label3);
            Controls.Add(dgvVerbasPorMes);
            Controls.Add(tbxVerbaTotalMes);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpMesRefVerbaTotal);
            Controls.Add(menu);
            Name = "TelaCategorias";
            Text = "TelaCategorias";
            Load += TelaCategorias_Load;
            Resize += TelaCategorias_Resize;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVerbasPorMes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMeses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menu;
        private ToolStripMenuItem lançamentosToolStripMenuItem;
        private ToolStripMenuItem categoriasToolStripMenuItem;
        private ToolStripMenuItem mesesFuturoToolStripMenuItem;
        private ToolStripMenuItem geralToolStripMenuItem;
        private Label label1;
        private DateTimePicker dtpMesRefVerbaTotal;
        private TextBox tbxVerbaTotalMes;
        private Label label2;
        private DataGridView dgvVerbasPorMes;
        private TextBox tbxSaldoTotalMes;
        private Label label3;
        private DataGridView dgvCategorias;
        private Label label21;
        private TextBox tbxDescCategoria;
        private Label label22;
        private TextBox tbxVerbaPadraoCat;
        private Button btnSalvarCategoria;
        private Label label24;
        private TextBox tbxIdCategoria;
        private Button btnLimparCategoria;
        private CheckBox chxTodosMeses;
        private DataGridView dgvMeses;
        private Button btnLimparMes;
        private DateTimePicker dtpMesCategoria;
        private TextBox tbxIdMes;
        private Label label20;
        private Label label25;
        private Label label23;
        private TextBox tbxVerbaMesCategoria;
        private Button btnCriarMes;
        private Panel panelDivisor;
    }
}