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
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvMeses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVerbasPorMes).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // chxTodosMeses
            // 
            chxTodosMeses.AutoSize = true;
            chxTodosMeses.Location = new Point(522, 537);
            chxTodosMeses.Margin = new Padding(3, 2, 3, 2);
            chxTodosMeses.Name = "chxTodosMeses";
            chxTodosMeses.Size = new Size(93, 19);
            chxTodosMeses.TabIndex = 88;
            chxTodosMeses.Text = "Todos meses";
            chxTodosMeses.UseVisualStyleBackColor = true;
            chxTodosMeses.CheckedChanged += chxTodosMeses_CheckedChanged;
            // 
            // btnLimparMes
            // 
            btnLimparMes.Location = new Point(364, 537);
            btnLimparMes.Name = "btnLimparMes";
            btnLimparMes.Size = new Size(75, 22);
            btnLimparMes.TabIndex = 87;
            btnLimparMes.Text = "Limpar";
            btnLimparMes.UseVisualStyleBackColor = true;
            btnLimparMes.Click += btnLimparMes_Click;
            // 
            // tbxIdMes
            // 
            tbxIdMes.Enabled = false;
            tbxIdMes.Location = new Point(122, 537);
            tbxIdMes.Name = "tbxIdMes";
            tbxIdMes.Size = new Size(47, 23);
            tbxIdMes.TabIndex = 86;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(122, 520);
            label25.Name = "label25";
            label25.Size = new Size(18, 15);
            label25.TabIndex = 85;
            label25.Text = "ID";
            // 
            // btnLimparCategoria
            // 
            btnLimparCategoria.Location = new Point(434, 40);
            btnLimparCategoria.Name = "btnLimparCategoria";
            btnLimparCategoria.Size = new Size(75, 23);
            btnLimparCategoria.TabIndex = 84;
            btnLimparCategoria.Text = "Limpar";
            btnLimparCategoria.UseVisualStyleBackColor = true;
            btnLimparCategoria.Click += btnLimparCategoria_Click;
            // 
            // tbxIdCategoria
            // 
            tbxIdCategoria.Enabled = false;
            tbxIdCategoria.Location = new Point(6, 40);
            tbxIdCategoria.Name = "tbxIdCategoria";
            tbxIdCategoria.Size = new Size(47, 23);
            tbxIdCategoria.TabIndex = 83;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(6, 23);
            label24.Name = "label24";
            label24.Size = new Size(18, 15);
            label24.TabIndex = 82;
            label24.Text = "ID";
            // 
            // dgvMeses
            // 
            dgvMeses.BackgroundColor = SystemColors.ControlLightLight;
            dgvMeses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMeses.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvMeses.Location = new Point(6, 570);
            dgvMeses.MultiSelect = false;
            dgvMeses.Name = "dgvMeses";
            dgvMeses.RowHeadersWidth = 51;
            dgvMeses.Size = new Size(609, 167);
            dgvMeses.TabIndex = 81;
            dgvMeses.CellDoubleClick += dgvMeses_CellDoubleClick;
            dgvMeses.CellFormatting += dgvMeses_CellFormatting;
            dgvMeses.SelectionChanged += dgvMeses_SelectionChanged;
            // 
            // btnCriarMes
            // 
            btnCriarMes.Location = new Point(256, 537);
            btnCriarMes.Margin = new Padding(3, 2, 3, 2);
            btnCriarMes.Name = "btnCriarMes";
            btnCriarMes.Size = new Size(102, 22);
            btnCriarMes.TabIndex = 80;
            btnCriarMes.Text = "Salvar/Criar mês";
            btnCriarMes.UseVisualStyleBackColor = true;
            btnCriarMes.Click += btnCriarMes_Click;
            // 
            // btnSalvarCategoria
            // 
            btnSalvarCategoria.Location = new Point(353, 41);
            btnSalvarCategoria.Name = "btnSalvarCategoria";
            btnSalvarCategoria.Size = new Size(75, 23);
            btnSalvarCategoria.TabIndex = 79;
            btnSalvarCategoria.Text = "Salvar";
            btnSalvarCategoria.UseVisualStyleBackColor = true;
            btnSalvarCategoria.Click += btnSalvarCategoria_Click;
            // 
            // tbxVerbaMesCategoria
            // 
            tbxVerbaMesCategoria.Location = new Point(175, 537);
            tbxVerbaMesCategoria.Margin = new Padding(3, 2, 3, 2);
            tbxVerbaMesCategoria.Name = "tbxVerbaMesCategoria";
            tbxVerbaMesCategoria.Size = new Size(76, 23);
            tbxVerbaMesCategoria.TabIndex = 78;
            tbxVerbaMesCategoria.TextAlign = HorizontalAlignment.Right;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(172, 520);
            label23.Name = "label23";
            label23.Size = new Size(61, 15);
            label23.TabIndex = 77;
            label23.Text = "Verba mês";
            // 
            // tbxVerbaPadraoCat
            // 
            tbxVerbaPadraoCat.Location = new Point(216, 40);
            tbxVerbaPadraoCat.Margin = new Padding(3, 2, 3, 2);
            tbxVerbaPadraoCat.Name = "tbxVerbaPadraoCat";
            tbxVerbaPadraoCat.Size = new Size(131, 23);
            tbxVerbaPadraoCat.TabIndex = 76;
            tbxVerbaPadraoCat.TextAlign = HorizontalAlignment.Right;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(213, 23);
            label22.Name = "label22";
            label22.Size = new Size(76, 15);
            label22.TabIndex = 75;
            label22.Text = "Verba padrão";
            // 
            // tbxDescCategoria
            // 
            tbxDescCategoria.Location = new Point(59, 40);
            tbxDescCategoria.Margin = new Padding(3, 2, 3, 2);
            tbxDescCategoria.Name = "tbxDescCategoria";
            tbxDescCategoria.Size = new Size(153, 23);
            tbxDescCategoria.TabIndex = 74;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(55, 23);
            label21.Name = "label21";
            label21.Size = new Size(58, 15);
            label21.TabIndex = 73;
            label21.Text = "Categoria";
            // 
            // dgvCategorias
            // 
            dgvCategorias.BackgroundColor = SystemColors.ControlLightLight;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvCategorias.Location = new Point(6, 67);
            dgvCategorias.MultiSelect = false;
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.RowHeadersWidth = 51;
            dgvCategorias.Size = new Size(609, 440);
            dgvCategorias.TabIndex = 72;
            dgvCategorias.CellDoubleClick += dgvCategorias_CellDoubleClick;
            dgvCategorias.CellFormatting += dgvCategorias_CellFormatting;
            dgvCategorias.SelectionChanged += dgvCategorias_SelectionChanged;
            dgvCategorias.KeyDown += dgvCategorias_KeyDown;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(3, 519);
            label20.Name = "label20";
            label20.Size = new Size(100, 15);
            label20.TabIndex = 71;
            label20.Text = "Mês de referência";
            // 
            // dtpMesCategoria
            // 
            dtpMesCategoria.Format = DateTimePickerFormat.Custom;
            dtpMesCategoria.Location = new Point(6, 537);
            dtpMesCategoria.Name = "dtpMesCategoria";
            dtpMesCategoria.Size = new Size(104, 23);
            dtpMesCategoria.TabIndex = 70;
            dtpMesCategoria.ValueChanged += dtpMesCategoria_ValueChanged;
            // 
            // menu
            // 
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { lançamentosToolStripMenuItem, categoriasToolStripMenuItem, mesesFuturoToolStripMenuItem, geralToolStripMenuItem });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(2098, 24);
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
            label1.Location = new Point(655, 57);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 91;
            label1.Text = "Mês de referência";
            // 
            // dtpMesRefVerbaTotal
            // 
            dtpMesRefVerbaTotal.Format = DateTimePickerFormat.Custom;
            dtpMesRefVerbaTotal.Location = new Point(658, 75);
            dtpMesRefVerbaTotal.Name = "dtpMesRefVerbaTotal";
            dtpMesRefVerbaTotal.Size = new Size(104, 23);
            dtpMesRefVerbaTotal.TabIndex = 90;
            dtpMesRefVerbaTotal.ValueChanged += dtpMesRefVerbaTotal_ValueChanged;
            // 
            // tbxVerbaTotalMes
            // 
            tbxVerbaTotalMes.Location = new Point(790, 75);
            tbxVerbaTotalMes.Margin = new Padding(3, 2, 3, 2);
            tbxVerbaTotalMes.Name = "tbxVerbaTotalMes";
            tbxVerbaTotalMes.Size = new Size(131, 23);
            tbxVerbaTotalMes.TabIndex = 93;
            tbxVerbaTotalMes.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(787, 58);
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
            dgvVerbasPorMes.Location = new Point(658, 102);
            dgvVerbasPorMes.MultiSelect = false;
            dgvVerbasPorMes.Name = "dgvVerbasPorMes";
            dgvVerbasPorMes.RowHeadersWidth = 51;
            dgvVerbasPorMes.Size = new Size(1416, 670);
            dgvVerbasPorMes.TabIndex = 94;
            dgvVerbasPorMes.CellFormatting += dgvVerbasPorMes_CellFormatting;
            // 
            // tbxSaldoTotalMes
            // 
            tbxSaldoTotalMes.Location = new Point(926, 75);
            tbxSaldoTotalMes.Margin = new Padding(3, 2, 3, 2);
            tbxSaldoTotalMes.Name = "tbxSaldoTotalMes";
            tbxSaldoTotalMes.Size = new Size(131, 23);
            tbxSaldoTotalMes.TabIndex = 96;
            tbxSaldoTotalMes.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(922, 58);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 95;
            label3.Text = "Saldo total no mês";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvCategorias);
            groupBox1.Controls.Add(label21);
            groupBox1.Controls.Add(tbxDescCategoria);
            groupBox1.Controls.Add(label22);
            groupBox1.Controls.Add(tbxVerbaPadraoCat);
            groupBox1.Controls.Add(btnSalvarCategoria);
            groupBox1.Controls.Add(label24);
            groupBox1.Controls.Add(tbxIdCategoria);
            groupBox1.Controls.Add(btnLimparCategoria);
            groupBox1.Controls.Add(chxTodosMeses);
            groupBox1.Controls.Add(dgvMeses);
            groupBox1.Controls.Add(btnLimparMes);
            groupBox1.Controls.Add(dtpMesCategoria);
            groupBox1.Controls.Add(tbxIdMes);
            groupBox1.Controls.Add(label20);
            groupBox1.Controls.Add(label25);
            groupBox1.Controls.Add(label23);
            groupBox1.Controls.Add(tbxVerbaMesCategoria);
            groupBox1.Controls.Add(btnCriarMes);
            groupBox1.Location = new Point(12, 35);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(630, 750);
            groupBox1.TabIndex = 97;
            groupBox1.TabStop = false;
            groupBox1.Text = "Criar categoria/mês";
            // 
            // TelaCategorias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2098, 789);
            Controls.Add(groupBox1);
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
            ((System.ComponentModel.ISupportInitialize)dgvMeses).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVerbasPorMes).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private GroupBox groupBox1;
    }
}