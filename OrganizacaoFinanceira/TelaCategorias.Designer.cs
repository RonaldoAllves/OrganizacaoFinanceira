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
            panel1 = new Panel();
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
            menu.Padding = new Padding(7, 3, 0, 3);
            menu.Size = new Size(1924, 30);
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
            label1.Location = new Point(655, 76);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 91;
            label1.Text = "Mês de referência";
            // 
            // dtpMesRefVerbaTotal
            // 
            dtpMesRefVerbaTotal.Format = DateTimePickerFormat.Custom;
            dtpMesRefVerbaTotal.Location = new Point(658, 100);
            dtpMesRefVerbaTotal.Margin = new Padding(3, 4, 3, 4);
            dtpMesRefVerbaTotal.Name = "dtpMesRefVerbaTotal";
            dtpMesRefVerbaTotal.Size = new Size(118, 27);
            dtpMesRefVerbaTotal.TabIndex = 90;
            dtpMesRefVerbaTotal.ValueChanged += dtpMesRefVerbaTotal_ValueChanged;
            // 
            // tbxVerbaTotalMes
            // 
            tbxVerbaTotalMes.Location = new Point(809, 100);
            tbxVerbaTotalMes.Name = "tbxVerbaTotalMes";
            tbxVerbaTotalMes.Size = new Size(149, 27);
            tbxVerbaTotalMes.TabIndex = 93;
            tbxVerbaTotalMes.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(806, 77);
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
            dgvVerbasPorMes.Location = new Point(658, 136);
            dgvVerbasPorMes.Margin = new Padding(3, 4, 3, 4);
            dgvVerbasPorMes.MultiSelect = false;
            dgvVerbasPorMes.Name = "dgvVerbasPorMes";
            dgvVerbasPorMes.RowHeadersWidth = 51;
            dgvVerbasPorMes.Size = new Size(1618, 893);
            dgvVerbasPorMes.TabIndex = 94;
            dgvVerbasPorMes.CellFormatting += dgvVerbasPorMes_CellFormatting;
            // 
            // tbxSaldoTotalMes
            // 
            tbxSaldoTotalMes.Location = new Point(965, 100);
            tbxSaldoTotalMes.Name = "tbxSaldoTotalMes";
            tbxSaldoTotalMes.Size = new Size(149, 27);
            tbxSaldoTotalMes.TabIndex = 96;
            tbxSaldoTotalMes.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(960, 77);
            label3.Name = "label3";
            label3.Size = new Size(134, 20);
            label3.TabIndex = 95;
            label3.Text = "Saldo total no mês";
            // 
            // dgvCategorias
            // 
            dgvCategorias.BackgroundColor = SystemColors.ControlLightLight;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvCategorias.Location = new Point(12, 136);
            dgvCategorias.Margin = new Padding(3, 4, 3, 4);
            dgvCategorias.MultiSelect = false;
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.RowHeadersWidth = 51;
            dgvCategorias.Size = new Size(608, 587);
            dgvCategorias.TabIndex = 99;
            dgvCategorias.CellDoubleClick += dgvCategorias_CellDoubleClick;
            dgvCategorias.CellFormatting += dgvCategorias_CellFormatting;
            dgvCategorias.SelectionChanged += dgvCategorias_SelectionChanged;
            dgvCategorias.KeyDown += dgvCategorias_KeyDown;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(68, 78);
            label21.Name = "label21";
            label21.Size = new Size(74, 20);
            label21.TabIndex = 100;
            label21.Text = "Categoria";
            // 
            // tbxDescCategoria
            // 
            tbxDescCategoria.Location = new Point(72, 100);
            tbxDescCategoria.Name = "tbxDescCategoria";
            tbxDescCategoria.Size = new Size(174, 27);
            tbxDescCategoria.TabIndex = 101;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(248, 78);
            label22.Name = "label22";
            label22.Size = new Size(99, 20);
            label22.TabIndex = 102;
            label22.Text = "Verba padrão";
            // 
            // tbxVerbaPadraoCat
            // 
            tbxVerbaPadraoCat.Location = new Point(252, 100);
            tbxVerbaPadraoCat.Name = "tbxVerbaPadraoCat";
            tbxVerbaPadraoCat.Size = new Size(149, 27);
            tbxVerbaPadraoCat.TabIndex = 103;
            tbxVerbaPadraoCat.TextAlign = HorizontalAlignment.Right;
            // 
            // btnSalvarCategoria
            // 
            btnSalvarCategoria.Location = new Point(407, 97);
            btnSalvarCategoria.Margin = new Padding(3, 4, 3, 4);
            btnSalvarCategoria.Name = "btnSalvarCategoria";
            btnSalvarCategoria.Size = new Size(86, 31);
            btnSalvarCategoria.TabIndex = 106;
            btnSalvarCategoria.Text = "Salvar";
            btnSalvarCategoria.UseVisualStyleBackColor = true;
            btnSalvarCategoria.Click += btnSalvarCategoria_Click;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(12, 78);
            label24.Name = "label24";
            label24.Size = new Size(24, 20);
            label24.TabIndex = 109;
            label24.Text = "ID";
            // 
            // tbxIdCategoria
            // 
            tbxIdCategoria.Enabled = false;
            tbxIdCategoria.Location = new Point(12, 100);
            tbxIdCategoria.Margin = new Padding(3, 4, 3, 4);
            tbxIdCategoria.Name = "tbxIdCategoria";
            tbxIdCategoria.Size = new Size(53, 27);
            tbxIdCategoria.TabIndex = 110;
            // 
            // btnLimparCategoria
            // 
            btnLimparCategoria.Location = new Point(499, 96);
            btnLimparCategoria.Margin = new Padding(3, 4, 3, 4);
            btnLimparCategoria.Name = "btnLimparCategoria";
            btnLimparCategoria.Size = new Size(86, 31);
            btnLimparCategoria.TabIndex = 111;
            btnLimparCategoria.Text = "Limpar";
            btnLimparCategoria.UseVisualStyleBackColor = true;
            btnLimparCategoria.Click += btnLimparCategoria_Click;
            // 
            // chxTodosMeses
            // 
            chxTodosMeses.AutoSize = true;
            chxTodosMeses.Location = new Point(514, 766);
            chxTodosMeses.Name = "chxTodosMeses";
            chxTodosMeses.Size = new Size(116, 24);
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
            dgvMeses.Location = new Point(12, 807);
            dgvMeses.Margin = new Padding(3, 4, 3, 4);
            dgvMeses.MultiSelect = false;
            dgvMeses.Name = "dgvMeses";
            dgvMeses.RowHeadersWidth = 51;
            dgvMeses.Size = new Size(608, 223);
            dgvMeses.TabIndex = 108;
            dgvMeses.CellDoubleClick += dgvMeses_CellDoubleClick;
            dgvMeses.CellFormatting += dgvMeses_CellFormatting;
            dgvMeses.SelectionChanged += dgvMeses_SelectionChanged;
            // 
            // btnLimparMes
            // 
            btnLimparMes.Location = new Point(421, 763);
            btnLimparMes.Margin = new Padding(3, 4, 3, 4);
            btnLimparMes.Name = "btnLimparMes";
            btnLimparMes.Size = new Size(86, 29);
            btnLimparMes.TabIndex = 114;
            btnLimparMes.Text = "Limpar";
            btnLimparMes.UseVisualStyleBackColor = true;
            btnLimparMes.Click += btnLimparMes_Click;
            // 
            // dtpMesCategoria
            // 
            dtpMesCategoria.Format = DateTimePickerFormat.Custom;
            dtpMesCategoria.Location = new Point(12, 763);
            dtpMesCategoria.Margin = new Padding(3, 4, 3, 4);
            dtpMesCategoria.Name = "dtpMesCategoria";
            dtpMesCategoria.Size = new Size(118, 27);
            dtpMesCategoria.TabIndex = 97;
            dtpMesCategoria.ValueChanged += dtpMesCategoria_ValueChanged;
            // 
            // tbxIdMes
            // 
            tbxIdMes.Enabled = false;
            tbxIdMes.Location = new Point(144, 763);
            tbxIdMes.Margin = new Padding(3, 4, 3, 4);
            tbxIdMes.Name = "tbxIdMes";
            tbxIdMes.Size = new Size(53, 27);
            tbxIdMes.TabIndex = 113;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(8, 739);
            label20.Name = "label20";
            label20.Size = new Size(127, 20);
            label20.TabIndex = 98;
            label20.Text = "Mês de referência";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(144, 740);
            label25.Name = "label25";
            label25.Size = new Size(24, 20);
            label25.TabIndex = 112;
            label25.Text = "ID";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(202, 740);
            label23.Name = "label23";
            label23.Size = new Size(78, 20);
            label23.TabIndex = 104;
            label23.Text = "Verba mês";
            // 
            // tbxVerbaMesCategoria
            // 
            tbxVerbaMesCategoria.Location = new Point(205, 763);
            tbxVerbaMesCategoria.Name = "tbxVerbaMesCategoria";
            tbxVerbaMesCategoria.Size = new Size(86, 27);
            tbxVerbaMesCategoria.TabIndex = 105;
            tbxVerbaMesCategoria.TextAlign = HorizontalAlignment.Right;
            // 
            // btnCriarMes
            // 
            btnCriarMes.Location = new Point(298, 763);
            btnCriarMes.Name = "btnCriarMes";
            btnCriarMes.Size = new Size(117, 29);
            btnCriarMes.TabIndex = 107;
            btnCriarMes.Text = "Salvar/Criar mês";
            btnCriarMes.UseVisualStyleBackColor = true;
            btnCriarMes.Click += btnCriarMes_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(638, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(3, 985);
            panel1.TabIndex = 116;
            // 
            // TelaCategorias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1052);
            Controls.Add(panel1);
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
            Margin = new Padding(3, 4, 3, 4);
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
        private Panel panel1;
    }
}