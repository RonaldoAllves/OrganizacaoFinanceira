namespace OrganizacaoFinanceira
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
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
            tbxChaveConta = new TextBox();
            label18 = new Label();
            chxCredito = new CheckBox();
            chxDinheiro = new CheckBox();
            btnNovoLancamento = new Button();
            btnNovaConta = new Button();
            label20 = new Label();
            tbxTotalSelecionados = new TextBox();
            lblTituloContas = new Label();
            lblTituloSaidas = new Label();
            splitContainer1 = new SplitContainer();
            panelEditContas = new Panel();
            panelFiltroLancamentos = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvContas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLancamentos).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelEditContas.SuspendLayout();
            panelFiltroLancamentos.SuspendLayout();
            SuspendLayout();
            // 
            // dgvContas
            // 
            dgvContas.BackgroundColor = SystemColors.ControlLightLight;
            dgvContas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContas.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvContas.Location = new Point(19, 76);
            dgvContas.MultiSelect = false;
            dgvContas.Name = "dgvContas";
            dgvContas.RowHeadersWidth = 51;
            dgvContas.Size = new Size(844, 149);
            dgvContas.TabIndex = 0;
            dgvContas.CellDoubleClick += dgvContas_CellDoubleClick;
            dgvContas.ColumnWidthChanged += dgvContas_ColumnWidthChanged;
            dgvContas.SelectionChanged += dgvContas_SelectionChanged;
            dgvContas.KeyDown += dgvContas_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 3);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 1;
            label1.Text = "Banco";
            // 
            // txBanco
            // 
            txBanco.Location = new Point(57, 21);
            txBanco.Name = "txBanco";
            txBanco.Size = new Size(100, 23);
            txBanco.TabIndex = 2;
            // 
            // txUsuario
            // 
            txUsuario.Location = new Point(163, 21);
            txUsuario.Name = "txUsuario";
            txUsuario.Size = new Size(100, 23);
            txUsuario.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(163, 3);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 3;
            label2.Text = "Usuário";
            // 
            // txDataFechamento
            // 
            txDataFechamento.Location = new Point(269, 21);
            txDataFechamento.Name = "txDataFechamento";
            txDataFechamento.Size = new Size(100, 23);
            txDataFechamento.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(269, 3);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 5;
            label3.Text = "Data fechamento";
            // 
            // txValorInicial
            // 
            txValorInicial.Location = new Point(375, 21);
            txValorInicial.Name = "txValorInicial";
            txValorInicial.Size = new Size(100, 23);
            txValorInicial.TabIndex = 8;
            txValorInicial.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(375, 3);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 7;
            label4.Text = "Valor inicial";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(498, 21);
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
            dgvLancamentos.Location = new Point(12, 66);
            dgvLancamentos.Name = "dgvLancamentos";
            dgvLancamentos.RowHeadersWidth = 51;
            dgvLancamentos.RowTemplate.Height = 25;
            dgvLancamentos.Size = new Size(844, 270);
            dgvLancamentos.TabIndex = 10;
            dgvLancamentos.CellDoubleClick += dgvLancamentos_CellDoubleClick;
            dgvLancamentos.CellFormatting += dgvLancamentos_CellFormatting;
            dgvLancamentos.ColumnWidthChanged += dgvLancamentos_ColumnWidthChanged;
            dgvLancamentos.SelectionChanged += dgvLancamentos_SelectionChanged;
            dgvLancamentos.KeyDown += dgvLancamentos_KeyDown;
            // 
            // dtpMesReferencia
            // 
            dtpMesReferencia.Format = DateTimePickerFormat.Custom;
            dtpMesReferencia.Location = new Point(8, 22);
            dtpMesReferencia.Name = "dtpMesReferencia";
            dtpMesReferencia.ShowUpDown = true;
            dtpMesReferencia.Size = new Size(104, 23);
            dtpMesReferencia.TabIndex = 11;
            dtpMesReferencia.ValueChanged += dtpMesReferencia_ValueChanged;
            // 
            // tbxTotalLancamento
            // 
            tbxTotalLancamento.Location = new Point(732, 22);
            tbxTotalLancamento.Name = "tbxTotalLancamento";
            tbxTotalLancamento.Size = new Size(120, 23);
            tbxTotalLancamento.TabIndex = 12;
            tbxTotalLancamento.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(732, 4);
            label5.Name = "label5";
            label5.Size = new Size(98, 15);
            label5.TabIndex = 13;
            label5.Text = "Total lançamento";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(4, 4);
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
            groupBox1.Location = new Point(118, 3);
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
            // tbxChaveConta
            // 
            tbxChaveConta.Enabled = false;
            tbxChaveConta.Location = new Point(4, 21);
            tbxChaveConta.Name = "tbxChaveConta";
            tbxChaveConta.Size = new Size(47, 23);
            tbxChaveConta.TabIndex = 42;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(4, 4);
            label18.Name = "label18";
            label18.Size = new Size(18, 15);
            label18.TabIndex = 41;
            label18.Text = "ID";
            // 
            // chxCredito
            // 
            chxCredito.AutoSize = true;
            chxCredito.Location = new Point(289, 22);
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
            chxDinheiro.Location = new Point(360, 22);
            chxDinheiro.Name = "chxDinheiro";
            chxDinheiro.Size = new Size(71, 19);
            chxDinheiro.TabIndex = 46;
            chxDinheiro.Text = "Dinheiro";
            chxDinheiro.UseVisualStyleBackColor = true;
            chxDinheiro.CheckedChanged += chxDinheiro_CheckedChanged;
            // 
            // btnNovoLancamento
            // 
            btnNovoLancamento.Location = new Point(450, 18);
            btnNovoLancamento.Margin = new Padding(3, 2, 3, 2);
            btnNovoLancamento.Name = "btnNovoLancamento";
            btnNovoLancamento.Size = new Size(82, 22);
            btnNovoLancamento.TabIndex = 49;
            btnNovoLancamento.Text = "Novo";
            btnNovoLancamento.UseVisualStyleBackColor = true;
            btnNovoLancamento.Click += btnNovoLancamento_Click;
            // 
            // btnNovaConta
            // 
            btnNovaConta.Location = new Point(579, 21);
            btnNovaConta.Name = "btnNovaConta";
            btnNovaConta.Size = new Size(75, 23);
            btnNovaConta.TabIndex = 64;
            btnNovaConta.Text = "Limpar";
            btnNovaConta.UseVisualStyleBackColor = true;
            btnNovaConta.Click += btnNovaConta_Click;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(606, 4);
            label20.Name = "label20";
            label20.Size = new Size(103, 15);
            label20.TabIndex = 87;
            label20.Text = "Total selecionados";
            // 
            // tbxTotalSelecionados
            // 
            tbxTotalSelecionados.Location = new Point(606, 22);
            tbxTotalSelecionados.Name = "tbxTotalSelecionados";
            tbxTotalSelecionados.Size = new Size(120, 23);
            tbxTotalSelecionados.TabIndex = 86;
            tbxTotalSelecionados.TextAlign = HorizontalAlignment.Right;
            // 
            // lblTituloContas
            // 
            lblTituloContas.AutoSize = true;
            lblTituloContas.Location = new Point(19, 239);
            lblTituloContas.Name = "lblTituloContas";
            lblTituloContas.Size = new Size(44, 15);
            lblTituloContas.TabIndex = 88;
            lblTituloContas.Text = "Contas";
            // 
            // lblTituloSaidas
            // 
            lblTituloSaidas.AutoSize = true;
            lblTituloSaidas.Location = new Point(35, 414);
            lblTituloSaidas.Name = "lblTituloSaidas";
            lblTituloSaidas.Size = new Size(89, 15);
            lblTituloSaidas.TabIndex = 89;
            lblTituloSaidas.Text = "Saídas da conta";
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panelEditContas);
            splitContainer1.Panel1.Controls.Add(lblTituloContas);
            splitContainer1.Panel1.Controls.Add(dgvContas);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelFiltroLancamentos);
            splitContainer1.Panel2.Controls.Add(dgvLancamentos);
            splitContainer1.Panel2.Controls.Add(lblTituloSaidas);
            splitContainer1.Size = new Size(2174, 791);
            splitContainer1.SplitterDistance = 282;
            splitContainer1.TabIndex = 90;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // panelEditContas
            // 
            panelEditContas.Controls.Add(txUsuario);
            panelEditContas.Controls.Add(label1);
            panelEditContas.Controls.Add(txBanco);
            panelEditContas.Controls.Add(btnNovaConta);
            panelEditContas.Controls.Add(label2);
            panelEditContas.Controls.Add(label3);
            panelEditContas.Controls.Add(txDataFechamento);
            panelEditContas.Controls.Add(label4);
            panelEditContas.Controls.Add(tbxChaveConta);
            panelEditContas.Controls.Add(txValorInicial);
            panelEditContas.Controls.Add(label18);
            panelEditContas.Controls.Add(btnSalvar);
            panelEditContas.Location = new Point(19, 3);
            panelEditContas.Name = "panelEditContas";
            panelEditContas.Size = new Size(661, 53);
            panelEditContas.TabIndex = 89;
            // 
            // panelFiltroLancamentos
            // 
            panelFiltroLancamentos.Controls.Add(label6);
            panelFiltroLancamentos.Controls.Add(label20);
            panelFiltroLancamentos.Controls.Add(dtpMesReferencia);
            panelFiltroLancamentos.Controls.Add(tbxTotalSelecionados);
            panelFiltroLancamentos.Controls.Add(tbxTotalLancamento);
            panelFiltroLancamentos.Controls.Add(btnNovoLancamento);
            panelFiltroLancamentos.Controls.Add(label5);
            panelFiltroLancamentos.Controls.Add(chxDinheiro);
            panelFiltroLancamentos.Controls.Add(groupBox1);
            panelFiltroLancamentos.Controls.Add(chxCredito);
            panelFiltroLancamentos.Location = new Point(12, 3);
            panelFiltroLancamentos.Name = "panelFiltroLancamentos";
            panelFiltroLancamentos.Size = new Size(859, 57);
            panelFiltroLancamentos.TabIndex = 90;
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2174, 791);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TelaPrincipal";
            Text = "Lançamentos";
            Load += TelaPrincipal_Load;
            Resize += TelaPrincipal_Resize;
            ((System.ComponentModel.ISupportInitialize)dgvContas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLancamentos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelEditContas.ResumeLayout(false);
            panelEditContas.PerformLayout();
            panelFiltroLancamentos.ResumeLayout(false);
            panelFiltroLancamentos.PerformLayout();
            ResumeLayout(false);
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
        private TextBox tbxChaveConta;
        private Label label18;
        private CheckBox chxCredito;
        private CheckBox chxDinheiro;
        private Button btnNovoLancamento;
        private TextBox tbxValorRecorrente;
        private Button btnNovaConta;
        private ComboBox cbxCategoriaRecorrente;
        private Button btnSalvarLancamentoRecorrente;
        private Label label20;
        private TextBox tbxTotalSelecionados;
        private Label lblTituloContas;
        private Label lblTituloSaidas;
        private SplitContainer splitContainer1;
        private Panel panelEditContas;
        private Panel panelFiltroLancamentos;
    }
}