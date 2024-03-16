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
            chxTodosMeses = new CheckBox();
            btnLimparMes = new Button();
            tbxIdMes = new TextBox();
            label25 = new Label();
            btnLimparCategoria = new Button();
            tbxIdCategoria = new TextBox();
            label24 = new Label();
            dgvMeses = new DataGridView();
            btnCriarMes = new Button();
            btnSalvarCategoria = new Button();
            tbxVerbaMesCategoria = new TextBox();
            label23 = new Label();
            tbxVerbaPadraoCat = new TextBox();
            label22 = new Label();
            tbxDescCategoria = new TextBox();
            label21 = new Label();
            dgvCategorias = new DataGridView();
            label20 = new Label();
            dtpMesCategoria = new DateTimePicker();
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
            ((System.ComponentModel.ISupportInitialize)dgvMeses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVerbasPorMes).BeginInit();
            SuspendLayout();
            // 
            // chxTodosMeses
            // 
            chxTodosMeses.AutoSize = true;
            chxTodosMeses.Location = new Point(1370, 105);
            chxTodosMeses.Name = "chxTodosMeses";
            chxTodosMeses.Size = new Size(116, 24);
            chxTodosMeses.TabIndex = 88;
            chxTodosMeses.Text = "Todos meses";
            chxTodosMeses.UseVisualStyleBackColor = true;
            chxTodosMeses.CheckedChanged += chxTodosMeses_CheckedChanged;
            // 
            // btnLimparMes
            // 
            btnLimparMes.Location = new Point(1057, 104);
            btnLimparMes.Margin = new Padding(3, 4, 3, 4);
            btnLimparMes.Name = "btnLimparMes";
            btnLimparMes.Size = new Size(86, 29);
            btnLimparMes.TabIndex = 87;
            btnLimparMes.Text = "Limpar";
            btnLimparMes.UseVisualStyleBackColor = true;
            btnLimparMes.Click += btnLimparMes_Click;
            // 
            // tbxIdMes
            // 
            tbxIdMes.Enabled = false;
            tbxIdMes.Location = new Point(781, 104);
            tbxIdMes.Margin = new Padding(3, 4, 3, 4);
            tbxIdMes.Name = "tbxIdMes";
            tbxIdMes.Size = new Size(53, 27);
            tbxIdMes.TabIndex = 86;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(781, 81);
            label25.Name = "label25";
            label25.Size = new Size(24, 20);
            label25.TabIndex = 85;
            label25.Text = "ID";
            // 
            // btnLimparCategoria
            // 
            btnLimparCategoria.Location = new Point(503, 104);
            btnLimparCategoria.Margin = new Padding(3, 4, 3, 4);
            btnLimparCategoria.Name = "btnLimparCategoria";
            btnLimparCategoria.Size = new Size(86, 31);
            btnLimparCategoria.TabIndex = 84;
            btnLimparCategoria.Text = "Limpar";
            btnLimparCategoria.UseVisualStyleBackColor = true;
            btnLimparCategoria.Click += btnLimparCategoria_Click;
            // 
            // tbxIdCategoria
            // 
            tbxIdCategoria.Enabled = false;
            tbxIdCategoria.Location = new Point(14, 104);
            tbxIdCategoria.Margin = new Padding(3, 4, 3, 4);
            tbxIdCategoria.Name = "tbxIdCategoria";
            tbxIdCategoria.Size = new Size(53, 27);
            tbxIdCategoria.TabIndex = 83;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(14, 81);
            label24.Name = "label24";
            label24.Size = new Size(24, 20);
            label24.TabIndex = 82;
            label24.Text = "ID";
            // 
            // dgvMeses
            // 
            dgvMeses.BackgroundColor = SystemColors.ControlLightLight;
            dgvMeses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMeses.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvMeses.Location = new Point(781, 140);
            dgvMeses.Margin = new Padding(3, 4, 3, 4);
            dgvMeses.MultiSelect = false;
            dgvMeses.Name = "dgvMeses";
            dgvMeses.RowHeadersWidth = 51;
            dgvMeses.Size = new Size(965, 450);
            dgvMeses.TabIndex = 81;
            dgvMeses.CellDoubleClick += dgvMeses_CellDoubleClick;
            dgvMeses.CellFormatting += dgvMeses_CellFormatting;
            dgvMeses.SelectionChanged += dgvMeses_SelectionChanged;
            // 
            // btnCriarMes
            // 
            btnCriarMes.Location = new Point(934, 104);
            btnCriarMes.Name = "btnCriarMes";
            btnCriarMes.Size = new Size(117, 29);
            btnCriarMes.TabIndex = 80;
            btnCriarMes.Text = "Salvar/Criar mês";
            btnCriarMes.UseVisualStyleBackColor = true;
            btnCriarMes.Click += btnCriarMes_Click;
            // 
            // btnSalvarCategoria
            // 
            btnSalvarCategoria.Location = new Point(410, 105);
            btnSalvarCategoria.Margin = new Padding(3, 4, 3, 4);
            btnSalvarCategoria.Name = "btnSalvarCategoria";
            btnSalvarCategoria.Size = new Size(86, 31);
            btnSalvarCategoria.TabIndex = 79;
            btnSalvarCategoria.Text = "Salvar";
            btnSalvarCategoria.UseVisualStyleBackColor = true;
            btnSalvarCategoria.Click += btnSalvarCategoria_Click;
            // 
            // tbxVerbaMesCategoria
            // 
            tbxVerbaMesCategoria.Location = new Point(841, 104);
            tbxVerbaMesCategoria.Name = "tbxVerbaMesCategoria";
            tbxVerbaMesCategoria.Size = new Size(86, 27);
            tbxVerbaMesCategoria.TabIndex = 78;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(838, 81);
            label23.Name = "label23";
            label23.Size = new Size(78, 20);
            label23.TabIndex = 77;
            label23.Text = "Verba mês";
            // 
            // tbxVerbaPadraoCat
            // 
            tbxVerbaPadraoCat.Location = new Point(254, 104);
            tbxVerbaPadraoCat.Name = "tbxVerbaPadraoCat";
            tbxVerbaPadraoCat.Size = new Size(149, 27);
            tbxVerbaPadraoCat.TabIndex = 76;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(250, 81);
            label22.Name = "label22";
            label22.Size = new Size(99, 20);
            label22.TabIndex = 75;
            label22.Text = "Verba padrão";
            // 
            // tbxDescCategoria
            // 
            tbxDescCategoria.Location = new Point(74, 104);
            tbxDescCategoria.Name = "tbxDescCategoria";
            tbxDescCategoria.Size = new Size(174, 27);
            tbxDescCategoria.TabIndex = 74;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(70, 81);
            label21.Name = "label21";
            label21.Size = new Size(74, 20);
            label21.TabIndex = 73;
            label21.Text = "Categoria";
            // 
            // dgvCategorias
            // 
            dgvCategorias.BackgroundColor = SystemColors.ControlLightLight;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvCategorias.Location = new Point(14, 140);
            dgvCategorias.Margin = new Padding(3, 4, 3, 4);
            dgvCategorias.MultiSelect = false;
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.RowHeadersWidth = 51;
            dgvCategorias.Size = new Size(743, 450);
            dgvCategorias.TabIndex = 72;
            dgvCategorias.CellDoubleClick += dgvCategorias_CellDoubleClick;
            dgvCategorias.SelectionChanged += dgvCategorias_SelectionChanged;
            dgvCategorias.KeyDown += dgvCategorias_KeyDown;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(1185, 79);
            label20.Name = "label20";
            label20.Size = new Size(127, 20);
            label20.TabIndex = 71;
            label20.Text = "Mês de referência";
            // 
            // dtpMesCategoria
            // 
            dtpMesCategoria.Format = DateTimePickerFormat.Custom;
            dtpMesCategoria.Location = new Point(1189, 103);
            dtpMesCategoria.Margin = new Padding(3, 4, 3, 4);
            dtpMesCategoria.Name = "dtpMesCategoria";
            dtpMesCategoria.Size = new Size(118, 27);
            dtpMesCategoria.TabIndex = 70;
            dtpMesCategoria.ValueChanged += dtpMesCategoria_ValueChanged;
            // 
            // menu
            // 
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { lançamentosToolStripMenuItem, categoriasToolStripMenuItem, mesesFuturoToolStripMenuItem, geralToolStripMenuItem });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Padding = new Padding(7, 3, 0, 3);
            menu.Size = new Size(1760, 30);
            menu.TabIndex = 89;
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
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 607);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 91;
            label1.Text = "Mês de referência";
            // 
            // dtpMesRefVerbaTotal
            // 
            dtpMesRefVerbaTotal.Format = DateTimePickerFormat.Custom;
            dtpMesRefVerbaTotal.Location = new Point(14, 631);
            dtpMesRefVerbaTotal.Margin = new Padding(3, 4, 3, 4);
            dtpMesRefVerbaTotal.Name = "dtpMesRefVerbaTotal";
            dtpMesRefVerbaTotal.Size = new Size(118, 27);
            dtpMesRefVerbaTotal.TabIndex = 90;
            dtpMesRefVerbaTotal.ValueChanged += dtpMesRefVerbaTotal_ValueChanged;
            // 
            // tbxVerbaTotalMes
            // 
            tbxVerbaTotalMes.Location = new Point(165, 631);
            tbxVerbaTotalMes.Name = "tbxVerbaTotalMes";
            tbxVerbaTotalMes.Size = new Size(149, 27);
            tbxVerbaTotalMes.TabIndex = 93;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(161, 608);
            label2.Name = "label2";
            label2.Size = new Size(134, 20);
            label2.TabIndex = 92;
            label2.Text = "Verba total no mês";
            // 
            // dgvVerbasPorMes
            // 
            dgvVerbasPorMes.BackgroundColor = SystemColors.ControlLightLight;
            dgvVerbasPorMes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVerbasPorMes.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvVerbasPorMes.Location = new Point(14, 666);
            dgvVerbasPorMes.Margin = new Padding(3, 4, 3, 4);
            dgvVerbasPorMes.MultiSelect = false;
            dgvVerbasPorMes.Name = "dgvVerbasPorMes";
            dgvVerbasPorMes.RowHeadersWidth = 51;
            dgvVerbasPorMes.Size = new Size(1732, 258);
            dgvVerbasPorMes.TabIndex = 94;
            // 
            // tbxSaldoTotalMes
            // 
            tbxSaldoTotalMes.Location = new Point(320, 631);
            tbxSaldoTotalMes.Name = "tbxSaldoTotalMes";
            tbxSaldoTotalMes.Size = new Size(149, 27);
            tbxSaldoTotalMes.TabIndex = 96;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(316, 608);
            label3.Name = "label3";
            label3.Size = new Size(134, 20);
            label3.TabIndex = 95;
            label3.Text = "Saldo total no mês";
            // 
            // TelaCategorias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1760, 1052);
            Controls.Add(tbxSaldoTotalMes);
            Controls.Add(label3);
            Controls.Add(dgvVerbasPorMes);
            Controls.Add(tbxVerbaTotalMes);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpMesRefVerbaTotal);
            Controls.Add(menu);
            Controls.Add(chxTodosMeses);
            Controls.Add(btnLimparMes);
            Controls.Add(tbxIdMes);
            Controls.Add(label25);
            Controls.Add(btnLimparCategoria);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "TelaCategorias";
            Text = "TelaCategorias";
            Load += TelaCategorias_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMeses).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVerbasPorMes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chxTodosMeses;
        private Button btnLimparMes;
        private TextBox tbxIdMes;
        private Label label25;
        private Button btnLimparCategoria;
        private TextBox tbxIdCategoria;
        private Label label24;
        private DataGridView dgvMeses;
        private Button btnCriarMes;
        private Button btnSalvarCategoria;
        private TextBox tbxVerbaMesCategoria;
        private Label label23;
        private TextBox tbxVerbaPadraoCat;
        private Label label22;
        private TextBox tbxDescCategoria;
        private Label label21;
        private DataGridView dgvCategorias;
        private Label label20;
        private DateTimePicker dtpMesCategoria;
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
    }
}