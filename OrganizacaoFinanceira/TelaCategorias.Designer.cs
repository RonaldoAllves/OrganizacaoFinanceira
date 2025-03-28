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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCategorias));
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
            dgvSaidasCategoria = new DataGridView();
            tbxTotalSaida = new TextBox();
            lblTotalSaidas = new Label();
            lblTituloCategorias = new Label();
            lblTituloMesesCriados = new Label();
            lblTituloVerbasPorMes = new Label();
            lblTituloSaidasCategoria = new Label();
            splitContainer1 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            panelCategorias = new Panel();
            panelMesesCriados = new Panel();
            splitContainer2 = new SplitContainer();
            btnSalvarObsMes = new Button();
            textObsMes = new RichTextBox();
            panelVerbasPorMes = new Panel();
            tbxNaoDistribuidoMes = new TextBox();
            label9 = new Label();
            tbxParcelasFuturas = new TextBox();
            label8 = new Label();
            tbxNaoDistribuido = new TextBox();
            label7 = new Label();
            tbxSaidaTotalMes = new TextBox();
            label6 = new Label();
            tbxVerbaAdicionalMes = new TextBox();
            label5 = new Label();
            tbxVerbaOriginal = new TextBox();
            label4 = new Label();
            panelSaidasCategoria = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvVerbasPorMes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMeses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSaidasCategoria).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            panelCategorias.SuspendLayout();
            panelMesesCriados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panelVerbasPorMes.SuspendLayout();
            panelSaidasCategoria.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 91;
            label1.Text = "Mês de referência";
            // 
            // dtpMesRefVerbaTotal
            // 
            dtpMesRefVerbaTotal.Format = DateTimePickerFormat.Custom;
            dtpMesRefVerbaTotal.Location = new Point(6, 21);
            dtpMesRefVerbaTotal.Name = "dtpMesRefVerbaTotal";
            dtpMesRefVerbaTotal.Size = new Size(104, 23);
            dtpMesRefVerbaTotal.TabIndex = 90;
            dtpMesRefVerbaTotal.ValueChanged += dtpMesRefVerbaTotal_ValueChanged;
            // 
            // tbxVerbaTotalMes
            // 
            tbxVerbaTotalMes.Location = new Point(415, 20);
            tbxVerbaTotalMes.Margin = new Padding(3, 2, 3, 2);
            tbxVerbaTotalMes.Name = "tbxVerbaTotalMes";
            tbxVerbaTotalMes.Size = new Size(102, 23);
            tbxVerbaTotalMes.TabIndex = 93;
            tbxVerbaTotalMes.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(412, 3);
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
            dgvVerbasPorMes.Location = new Point(28, 55);
            dgvVerbasPorMes.MultiSelect = false;
            dgvVerbasPorMes.Name = "dgvVerbasPorMes";
            dgvVerbasPorMes.RowHeadersWidth = 51;
            dgvVerbasPorMes.Size = new Size(406, 168);
            dgvVerbasPorMes.TabIndex = 94;
            dgvVerbasPorMes.CellFormatting += dgvVerbasPorMes_CellFormatting;
            dgvVerbasPorMes.ColumnWidthChanged += dgvVerbasPorMes_ColumnWidthChanged;
            dgvVerbasPorMes.SelectionChanged += dgvVerbasPorMes_SelectionChanged;
            // 
            // tbxSaldoTotalMes
            // 
            tbxSaldoTotalMes.Location = new Point(630, 19);
            tbxSaldoTotalMes.Margin = new Padding(3, 2, 3, 2);
            tbxSaldoTotalMes.Name = "tbxSaldoTotalMes";
            tbxSaldoTotalMes.Size = new Size(101, 23);
            tbxSaldoTotalMes.TabIndex = 96;
            tbxSaldoTotalMes.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(626, 2);
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
            dgvCategorias.Location = new Point(27, 80);
            dgvCategorias.MultiSelect = false;
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.RowHeadersWidth = 51;
            dgvCategorias.Size = new Size(532, 126);
            dgvCategorias.TabIndex = 99;
            dgvCategorias.CellDoubleClick += dgvCategorias_CellDoubleClick;
            dgvCategorias.CellFormatting += dgvCategorias_CellFormatting;
            dgvCategorias.ColumnWidthChanged += dgvCategorias_ColumnWidthChanged;
            dgvCategorias.SelectionChanged += dgvCategorias_SelectionChanged;
            dgvCategorias.KeyDown += dgvCategorias_KeyDown;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(53, 2);
            label21.Name = "label21";
            label21.Size = new Size(58, 15);
            label21.TabIndex = 100;
            label21.Text = "Categoria";
            // 
            // tbxDescCategoria
            // 
            tbxDescCategoria.Location = new Point(56, 19);
            tbxDescCategoria.Margin = new Padding(3, 2, 3, 2);
            tbxDescCategoria.Name = "tbxDescCategoria";
            tbxDescCategoria.Size = new Size(153, 23);
            tbxDescCategoria.TabIndex = 101;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(210, 2);
            label22.Name = "label22";
            label22.Size = new Size(76, 15);
            label22.TabIndex = 102;
            label22.Text = "Verba padrão";
            // 
            // tbxVerbaPadraoCat
            // 
            tbxVerbaPadraoCat.Location = new Point(213, 19);
            tbxVerbaPadraoCat.Margin = new Padding(3, 2, 3, 2);
            tbxVerbaPadraoCat.Name = "tbxVerbaPadraoCat";
            tbxVerbaPadraoCat.Size = new Size(131, 23);
            tbxVerbaPadraoCat.TabIndex = 103;
            tbxVerbaPadraoCat.TextAlign = HorizontalAlignment.Right;
            // 
            // btnSalvarCategoria
            // 
            btnSalvarCategoria.Location = new Point(349, 17);
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
            label24.Location = new Point(3, 2);
            label24.Name = "label24";
            label24.Size = new Size(18, 15);
            label24.TabIndex = 109;
            label24.Text = "ID";
            // 
            // tbxIdCategoria
            // 
            tbxIdCategoria.Enabled = false;
            tbxIdCategoria.Location = new Point(3, 19);
            tbxIdCategoria.Name = "tbxIdCategoria";
            tbxIdCategoria.Size = new Size(47, 23);
            tbxIdCategoria.TabIndex = 110;
            // 
            // btnLimparCategoria
            // 
            btnLimparCategoria.Location = new Point(430, 16);
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
            chxTodosMeses.Location = new Point(448, 23);
            chxTodosMeses.Margin = new Padding(3, 2, 3, 2);
            chxTodosMeses.Name = "chxTodosMeses";
            chxTodosMeses.Size = new Size(94, 19);
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
            dgvMeses.Location = new Point(27, 125);
            dgvMeses.MultiSelect = false;
            dgvMeses.Name = "dgvMeses";
            dgvMeses.RowHeadersWidth = 51;
            dgvMeses.Size = new Size(532, 167);
            dgvMeses.TabIndex = 108;
            dgvMeses.CellDoubleClick += dgvMeses_CellDoubleClick;
            dgvMeses.CellFormatting += dgvMeses_CellFormatting;
            dgvMeses.ColumnWidthChanged += dgvMeses_ColumnWidthChanged;
            dgvMeses.SelectionChanged += dgvMeses_SelectionChanged;
            // 
            // btnLimparMes
            // 
            btnLimparMes.Location = new Point(366, 21);
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
            dtpMesCategoria.Location = new Point(8, 21);
            dtpMesCategoria.Name = "dtpMesCategoria";
            dtpMesCategoria.Size = new Size(104, 23);
            dtpMesCategoria.TabIndex = 97;
            dtpMesCategoria.ValueChanged += dtpMesCategoria_ValueChanged;
            // 
            // tbxIdMes
            // 
            tbxIdMes.Enabled = false;
            tbxIdMes.Location = new Point(124, 21);
            tbxIdMes.Name = "tbxIdMes";
            tbxIdMes.Size = new Size(47, 23);
            tbxIdMes.TabIndex = 113;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(5, 3);
            label20.Name = "label20";
            label20.Size = new Size(100, 15);
            label20.TabIndex = 98;
            label20.Text = "Mês de referência";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(124, 4);
            label25.Name = "label25";
            label25.Size = new Size(18, 15);
            label25.TabIndex = 112;
            label25.Text = "ID";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(175, 4);
            label23.Name = "label23";
            label23.Size = new Size(61, 15);
            label23.TabIndex = 104;
            label23.Text = "Verba mês";
            // 
            // tbxVerbaMesCategoria
            // 
            tbxVerbaMesCategoria.Location = new Point(177, 21);
            tbxVerbaMesCategoria.Margin = new Padding(3, 2, 3, 2);
            tbxVerbaMesCategoria.Name = "tbxVerbaMesCategoria";
            tbxVerbaMesCategoria.Size = new Size(76, 23);
            tbxVerbaMesCategoria.TabIndex = 105;
            tbxVerbaMesCategoria.TextAlign = HorizontalAlignment.Right;
            // 
            // btnCriarMes
            // 
            btnCriarMes.Location = new Point(259, 21);
            btnCriarMes.Margin = new Padding(3, 2, 3, 2);
            btnCriarMes.Name = "btnCriarMes";
            btnCriarMes.Size = new Size(102, 22);
            btnCriarMes.TabIndex = 107;
            btnCriarMes.Text = "Salvar/Criar mês";
            btnCriarMes.UseVisualStyleBackColor = true;
            btnCriarMes.Click += btnCriarMes_Click;
            // 
            // dgvSaidasCategoria
            // 
            dgvSaidasCategoria.BackgroundColor = SystemColors.ControlLightLight;
            dgvSaidasCategoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSaidasCategoria.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvSaidasCategoria.Location = new Point(28, 64);
            dgvSaidasCategoria.MultiSelect = false;
            dgvSaidasCategoria.Name = "dgvSaidasCategoria";
            dgvSaidasCategoria.RowHeadersWidth = 51;
            dgvSaidasCategoria.Size = new Size(213, 148);
            dgvSaidasCategoria.TabIndex = 117;
            dgvSaidasCategoria.CellFormatting += dgvSaidasCategoria_CellFormatting;
            dgvSaidasCategoria.ColumnWidthChanged += dgvSaidasCategoria_ColumnWidthChanged;
            // 
            // tbxTotalSaida
            // 
            tbxTotalSaida.Location = new Point(6, 20);
            tbxTotalSaida.Margin = new Padding(3, 2, 3, 2);
            tbxTotalSaida.Name = "tbxTotalSaida";
            tbxTotalSaida.Size = new Size(131, 23);
            tbxTotalSaida.TabIndex = 119;
            tbxTotalSaida.TextAlign = HorizontalAlignment.Right;
            // 
            // lblTotalSaidas
            // 
            lblTotalSaidas.AutoSize = true;
            lblTotalSaidas.Location = new Point(3, 3);
            lblTotalSaidas.Name = "lblTotalSaidas";
            lblTotalSaidas.Size = new Size(68, 15);
            lblTotalSaidas.TabIndex = 118;
            lblTotalSaidas.Text = "Total saídas";
            // 
            // lblTituloCategorias
            // 
            lblTituloCategorias.AutoSize = true;
            lblTituloCategorias.Location = new Point(27, 320);
            lblTituloCategorias.Name = "lblTituloCategorias";
            lblTituloCategorias.Size = new Size(63, 15);
            lblTituloCategorias.TabIndex = 120;
            lblTituloCategorias.Text = "Categorias";
            // 
            // lblTituloMesesCriados
            // 
            lblTituloMesesCriados.AutoSize = true;
            lblTituloMesesCriados.Location = new Point(27, 314);
            lblTituloMesesCriados.Name = "lblTituloMesesCriados";
            lblTituloMesesCriados.Size = new Size(81, 15);
            lblTituloMesesCriados.TabIndex = 121;
            lblTituloMesesCriados.Text = "Meses criados";
            // 
            // lblTituloVerbasPorMes
            // 
            lblTituloVerbasPorMes.AutoSize = true;
            lblTituloVerbasPorMes.Location = new Point(28, 293);
            lblTituloVerbasPorMes.Name = "lblTituloVerbasPorMes";
            lblTituloVerbasPorMes.Size = new Size(87, 15);
            lblTituloVerbasPorMes.TabIndex = 122;
            lblTituloVerbasPorMes.Text = "Verbas por mês";
            // 
            // lblTituloSaidasCategoria
            // 
            lblTituloSaidasCategoria.AutoSize = true;
            lblTituloSaidasCategoria.Location = new Point(28, 262);
            lblTituloSaidasCategoria.Name = "lblTituloSaidasCategoria";
            lblTituloSaidasCategoria.Size = new Size(108, 15);
            lblTituloSaidasCategoria.TabIndex = 123;
            lblTituloSaidasCategoria.Text = "Saídas da categoria";
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.Control;
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(2463, 846);
            splitContainer1.SplitterDistance = 1278;
            splitContainer1.TabIndex = 124;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // splitContainer3
            // 
            splitContainer3.BorderStyle = BorderStyle.FixedSingle;
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(panelCategorias);
            splitContainer3.Panel1.Controls.Add(dgvCategorias);
            splitContainer3.Panel1.Controls.Add(lblTituloCategorias);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(panelMesesCriados);
            splitContainer3.Panel2.Controls.Add(dgvMeses);
            splitContainer3.Panel2.Controls.Add(lblTituloMesesCriados);
            splitContainer3.Size = new Size(1278, 846);
            splitContainer3.SplitterDistance = 376;
            splitContainer3.TabIndex = 0;
            splitContainer3.SplitterMoved += splitContainer3_SplitterMoved;
            // 
            // panelCategorias
            // 
            panelCategorias.Controls.Add(tbxIdCategoria);
            panelCategorias.Controls.Add(tbxDescCategoria);
            panelCategorias.Controls.Add(btnLimparCategoria);
            panelCategorias.Controls.Add(label22);
            panelCategorias.Controls.Add(label21);
            panelCategorias.Controls.Add(label24);
            panelCategorias.Controls.Add(tbxVerbaPadraoCat);
            panelCategorias.Controls.Add(btnSalvarCategoria);
            panelCategorias.Location = new Point(27, 23);
            panelCategorias.Name = "panelCategorias";
            panelCategorias.Size = new Size(512, 51);
            panelCategorias.TabIndex = 121;
            // 
            // panelMesesCriados
            // 
            panelMesesCriados.Controls.Add(dtpMesCategoria);
            panelMesesCriados.Controls.Add(btnLimparMes);
            panelMesesCriados.Controls.Add(btnCriarMes);
            panelMesesCriados.Controls.Add(tbxIdMes);
            panelMesesCriados.Controls.Add(tbxVerbaMesCategoria);
            panelMesesCriados.Controls.Add(label20);
            panelMesesCriados.Controls.Add(chxTodosMeses);
            panelMesesCriados.Controls.Add(label23);
            panelMesesCriados.Controls.Add(label25);
            panelMesesCriados.Location = new Point(27, 65);
            panelMesesCriados.Name = "panelMesesCriados";
            panelMesesCriados.Size = new Size(577, 54);
            panelMesesCriados.TabIndex = 122;
            // 
            // splitContainer2
            // 
            splitContainer2.BorderStyle = BorderStyle.FixedSingle;
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(btnSalvarObsMes);
            splitContainer2.Panel1.Controls.Add(textObsMes);
            splitContainer2.Panel1.Controls.Add(panelVerbasPorMes);
            splitContainer2.Panel1.Controls.Add(dgvVerbasPorMes);
            splitContainer2.Panel1.Controls.Add(lblTituloVerbasPorMes);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(panelSaidasCategoria);
            splitContainer2.Panel2.Controls.Add(dgvSaidasCategoria);
            splitContainer2.Panel2.Controls.Add(lblTituloSaidasCategoria);
            splitContainer2.Size = new Size(1181, 846);
            splitContainer2.SplitterDistance = 375;
            splitContainer2.TabIndex = 0;
            splitContainer2.SplitterMoved += splitContainer2_SplitterMoved;
            // 
            // btnSalvarObsMes
            // 
            btnSalvarObsMes.Location = new Point(442, 229);
            btnSalvarObsMes.Name = "btnSalvarObsMes";
            btnSalvarObsMes.Size = new Size(314, 23);
            btnSalvarObsMes.TabIndex = 125;
            btnSalvarObsMes.Text = "Salvar";
            btnSalvarObsMes.UseVisualStyleBackColor = true;
            btnSalvarObsMes.Click += btnSalvarObsMes_Click;
            // 
            // textObsMes
            // 
            textObsMes.Location = new Point(442, 55);
            textObsMes.Name = "textObsMes";
            textObsMes.Size = new Size(314, 168);
            textObsMes.TabIndex = 124;
            textObsMes.Text = "";
            // 
            // panelVerbasPorMes
            // 
            panelVerbasPorMes.Controls.Add(tbxNaoDistribuidoMes);
            panelVerbasPorMes.Controls.Add(label9);
            panelVerbasPorMes.Controls.Add(tbxParcelasFuturas);
            panelVerbasPorMes.Controls.Add(label8);
            panelVerbasPorMes.Controls.Add(tbxNaoDistribuido);
            panelVerbasPorMes.Controls.Add(label7);
            panelVerbasPorMes.Controls.Add(tbxSaidaTotalMes);
            panelVerbasPorMes.Controls.Add(label6);
            panelVerbasPorMes.Controls.Add(tbxVerbaAdicionalMes);
            panelVerbasPorMes.Controls.Add(label5);
            panelVerbasPorMes.Controls.Add(tbxVerbaOriginal);
            panelVerbasPorMes.Controls.Add(label4);
            panelVerbasPorMes.Controls.Add(dtpMesRefVerbaTotal);
            panelVerbasPorMes.Controls.Add(tbxSaldoTotalMes);
            panelVerbasPorMes.Controls.Add(label3);
            panelVerbasPorMes.Controls.Add(tbxVerbaTotalMes);
            panelVerbasPorMes.Controls.Add(label1);
            panelVerbasPorMes.Controls.Add(label2);
            panelVerbasPorMes.Location = new Point(25, 3);
            panelVerbasPorMes.Name = "panelVerbasPorMes";
            panelVerbasPorMes.Size = new Size(1143, 49);
            panelVerbasPorMes.TabIndex = 123;
            // 
            // tbxNaoDistribuidoMes
            // 
            tbxNaoDistribuidoMes.Location = new Point(737, 19);
            tbxNaoDistribuidoMes.Margin = new Padding(3, 2, 3, 2);
            tbxNaoDistribuidoMes.Name = "tbxNaoDistribuidoMes";
            tbxNaoDistribuidoMes.Size = new Size(101, 23);
            tbxNaoDistribuidoMes.TabIndex = 108;
            tbxNaoDistribuidoMes.TextAlign = HorizontalAlignment.Right;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(733, 2);
            label9.Name = "label9";
            label9.Size = new Size(131, 15);
            label9.TabIndex = 107;
            label9.Text = "Não distribuído no mês";
            // 
            // tbxParcelasFuturas
            // 
            tbxParcelasFuturas.Location = new Point(1020, 19);
            tbxParcelasFuturas.Margin = new Padding(3, 2, 3, 2);
            tbxParcelasFuturas.Name = "tbxParcelasFuturas";
            tbxParcelasFuturas.Size = new Size(101, 23);
            tbxParcelasFuturas.TabIndex = 106;
            tbxParcelasFuturas.TextAlign = HorizontalAlignment.Right;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1016, 2);
            label8.Name = "label8";
            label8.Size = new Size(90, 15);
            label8.TabIndex = 105;
            label8.Text = "Parcelas futuras";
            // 
            // tbxNaoDistribuido
            // 
            tbxNaoDistribuido.Location = new Point(900, 19);
            tbxNaoDistribuido.Margin = new Padding(3, 2, 3, 2);
            tbxNaoDistribuido.Name = "tbxNaoDistribuido";
            tbxNaoDistribuido.Size = new Size(101, 23);
            tbxNaoDistribuido.TabIndex = 104;
            tbxNaoDistribuido.TextAlign = HorizontalAlignment.Right;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(896, 2);
            label7.Name = "label7";
            label7.Size = new Size(118, 15);
            label7.TabIndex = 103;
            label7.Text = "Não distribuído geral";
            // 
            // tbxSaidaTotalMes
            // 
            tbxSaidaTotalMes.Location = new Point(523, 19);
            tbxSaidaTotalMes.Margin = new Padding(3, 2, 3, 2);
            tbxSaidaTotalMes.Name = "tbxSaidaTotalMes";
            tbxSaidaTotalMes.Size = new Size(101, 23);
            tbxSaidaTotalMes.TabIndex = 102;
            tbxSaidaTotalMes.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(520, 2);
            label6.Name = "label6";
            label6.Size = new Size(104, 15);
            label6.TabIndex = 101;
            label6.Text = "Saída total no mês";
            // 
            // tbxVerbaAdicionalMes
            // 
            tbxVerbaAdicionalMes.Location = new Point(278, 20);
            tbxVerbaAdicionalMes.Margin = new Padding(3, 2, 3, 2);
            tbxVerbaAdicionalMes.Name = "tbxVerbaAdicionalMes";
            tbxVerbaAdicionalMes.Size = new Size(131, 23);
            tbxVerbaAdicionalMes.TabIndex = 100;
            tbxVerbaAdicionalMes.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(278, 3);
            label5.Name = "label5";
            label5.Size = new Size(129, 15);
            label5.TabIndex = 99;
            label5.Text = "Verba adicional no mês";
            // 
            // tbxVerbaOriginal
            // 
            tbxVerbaOriginal.Location = new Point(137, 20);
            tbxVerbaOriginal.Margin = new Padding(3, 2, 3, 2);
            tbxVerbaOriginal.Name = "tbxVerbaOriginal";
            tbxVerbaOriginal.Size = new Size(131, 23);
            tbxVerbaOriginal.TabIndex = 98;
            tbxVerbaOriginal.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(137, 3);
            label4.Name = "label4";
            label4.Size = new Size(121, 15);
            label4.TabIndex = 97;
            label4.Text = "Verba original no mês";
            // 
            // panelSaidasCategoria
            // 
            panelSaidasCategoria.Controls.Add(tbxTotalSaida);
            panelSaidasCategoria.Controls.Add(lblTotalSaidas);
            panelSaidasCategoria.Location = new Point(28, 7);
            panelSaidasCategoria.Name = "panelSaidasCategoria";
            panelSaidasCategoria.Size = new Size(145, 51);
            panelSaidasCategoria.TabIndex = 124;
            // 
            // TelaCategorias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(2463, 846);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TelaCategorias";
            Text = "Categorias";
            FormClosed += TelaCategorias_FormClosed;
            Load += TelaCategorias_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVerbasPorMes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMeses).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSaidasCategoria).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            panelCategorias.ResumeLayout(false);
            panelCategorias.PerformLayout();
            panelMesesCriados.ResumeLayout(false);
            panelMesesCriados.PerformLayout();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panelVerbasPorMes.ResumeLayout(false);
            panelVerbasPorMes.PerformLayout();
            panelSaidasCategoria.ResumeLayout(false);
            panelSaidasCategoria.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
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
        private DataGridView dgvSaidasCategoria;
        private TextBox tbxTotalSaida;
        private Label lblTotalSaidas;
        private Label lblTituloCategorias;
        private Label lblTituloMesesCriados;
        private Label lblTituloVerbasPorMes;
        private Label lblTituloSaidasCategoria;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer2;
        private Panel panelMesesCriados;
        private Panel panelCategorias;
        private Panel panelVerbasPorMes;
        private Panel panelSaidasCategoria;
        private TextBox tbxVerbaOriginal;
        private Label label4;
        private TextBox tbxVerbaAdicionalMes;
        private Label label5;
        private TextBox tbxSaidaTotalMes;
        private Label label6;
        private TextBox tbxNaoDistribuido;
        private Label label7;
        private TextBox tbxParcelasFuturas;
        private Label label8;
        private TextBox tbxNaoDistribuidoMes;
        private Label label9;
        private Button btnSalvarObsMes;
        private RichTextBox textObsMes;
    }
}