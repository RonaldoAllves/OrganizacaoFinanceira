namespace OrganizacaoFinanceira
{
    partial class FormAddLancamento
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
            label21 = new Label();
            tbxValorExtrapolado = new TextBox();
            chkObrigatorio = new CheckBox();
            label19 = new Label();
            btnLimparLancamento = new Button();
            tbxDescricao = new TextBox();
            label7 = new Label();
            label8 = new Label();
            lblTipoSaida = new Label();
            tbxValor = new TextBox();
            btnSalvarLancamento = new Button();
            cbxTipoSaida = new ComboBox();
            label12 = new Label();
            dtpDataLancamento = new DateTimePicker();
            label17 = new Label();
            tbxChaveLancamento = new TextBox();
            panelParcelas = new Panel();
            tbxNumParcela = new TextBox();
            nudQtdParcelas = new NumericUpDown();
            label9 = new Label();
            label10 = new Label();
            label13 = new Label();
            tbxValorTotal = new TextBox();
            dtpDataInicial = new DateTimePicker();
            label14 = new Label();
            cbxCategoria = new ComboBox();
            label16 = new Label();
            label11 = new Label();
            cbxContas = new ComboBox();
            dtpMesReferenciaLancamento = new DateTimePicker();
            label15 = new Label();
            panelParcelas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQtdParcelas).BeginInit();
            SuspendLayout();
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(147, 220);
            label21.Name = "label21";
            label21.Size = new Size(99, 15);
            label21.TabIndex = 74;
            label21.Text = "Valor extrapolado";
            // 
            // tbxValorExtrapolado
            // 
            tbxValorExtrapolado.Location = new Point(147, 236);
            tbxValorExtrapolado.Name = "tbxValorExtrapolado";
            tbxValorExtrapolado.Size = new Size(113, 23);
            tbxValorExtrapolado.TabIndex = 75;
            // 
            // chkObrigatorio
            // 
            chkObrigatorio.AutoSize = true;
            chkObrigatorio.Location = new Point(12, 240);
            chkObrigatorio.Name = "chkObrigatorio";
            chkObrigatorio.Size = new Size(100, 19);
            chkObrigatorio.TabIndex = 73;
            chkObrigatorio.Text = "gasto previsto";
            chkObrigatorio.UseVisualStyleBackColor = true;
            chkObrigatorio.CheckedChanged += chkObrigatorio_CheckedChanged;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label19.Location = new Point(144, 15);
            label19.Name = "label19";
            label19.Size = new Size(211, 20);
            label19.TabIndex = 68;
            label19.Text = "Cadastrar/Alterar lançamentos";
            // 
            // btnLimparLancamento
            // 
            btnLimparLancamento.Location = new Point(280, 305);
            btnLimparLancamento.Name = "btnLimparLancamento";
            btnLimparLancamento.Size = new Size(75, 23);
            btnLimparLancamento.TabIndex = 71;
            btnLimparLancamento.Text = "Limpar";
            btnLimparLancamento.UseVisualStyleBackColor = true;
            btnLimparLancamento.Click += btnLimparLancamento_Click;
            // 
            // tbxDescricao
            // 
            tbxDescricao.Location = new Point(65, 71);
            tbxDescricao.Name = "tbxDescricao";
            tbxDescricao.Size = new Size(195, 23);
            tbxDescricao.TabIndex = 53;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(65, 53);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 52;
            label7.Text = "Descrição";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(265, 53);
            label8.Name = "label8";
            label8.Size = new Size(33, 15);
            label8.TabIndex = 54;
            label8.Text = "Valor";
            // 
            // lblTipoSaida
            // 
            lblTipoSaida.AutoSize = true;
            lblTipoSaida.Location = new Point(379, 107);
            lblTipoSaida.Name = "lblTipoSaida";
            lblTipoSaida.Size = new Size(76, 15);
            lblTipoSaida.TabIndex = 70;
            lblTipoSaida.Text = "Tipo de saída";
            // 
            // tbxValor
            // 
            tbxValor.Location = new Point(265, 71);
            tbxValor.Name = "tbxValor";
            tbxValor.Size = new Size(116, 23);
            tbxValor.TabIndex = 55;
            // 
            // btnSalvarLancamento
            // 
            btnSalvarLancamento.Location = new Point(103, 305);
            btnSalvarLancamento.Name = "btnSalvarLancamento";
            btnSalvarLancamento.Size = new Size(75, 23);
            btnSalvarLancamento.TabIndex = 65;
            btnSalvarLancamento.Text = "Salvar";
            btnSalvarLancamento.UseVisualStyleBackColor = true;
            btnSalvarLancamento.Click += btnSalvarLancamento_Click;
            // 
            // cbxTipoSaida
            // 
            cbxTipoSaida.FormattingEnabled = true;
            cbxTipoSaida.Items.AddRange(new object[] { "Crédito", "Dinheiro" });
            cbxTipoSaida.Location = new Point(379, 124);
            cbxTipoSaida.Name = "cbxTipoSaida";
            cbxTipoSaida.Size = new Size(121, 23);
            cbxTipoSaida.TabIndex = 69;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(387, 53);
            label12.Name = "label12";
            label12.Size = new Size(113, 15);
            label12.TabIndex = 58;
            label12.Text = "Data de lançamento";
            // 
            // dtpDataLancamento
            // 
            dtpDataLancamento.Format = DateTimePickerFormat.Short;
            dtpDataLancamento.Location = new Point(387, 71);
            dtpDataLancamento.Name = "dtpDataLancamento";
            dtpDataLancamento.Size = new Size(113, 23);
            dtpDataLancamento.TabIndex = 59;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(12, 54);
            label17.Name = "label17";
            label17.Size = new Size(18, 15);
            label17.TabIndex = 66;
            label17.Text = "ID";
            // 
            // tbxChaveLancamento
            // 
            tbxChaveLancamento.Enabled = false;
            tbxChaveLancamento.Location = new Point(12, 71);
            tbxChaveLancamento.Name = "tbxChaveLancamento";
            tbxChaveLancamento.Size = new Size(47, 23);
            tbxChaveLancamento.TabIndex = 67;
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
            panelParcelas.Location = new Point(7, 162);
            panelParcelas.Name = "panelParcelas";
            panelParcelas.Size = new Size(387, 53);
            panelParcelas.TabIndex = 64;
            // 
            // tbxNumParcela
            // 
            tbxNumParcela.Enabled = false;
            tbxNumParcela.Location = new Point(5, 22);
            tbxNumParcela.Name = "tbxNumParcela";
            tbxNumParcela.Size = new Size(47, 23);
            tbxNumParcela.TabIndex = 49;
            // 
            // nudQtdParcelas
            // 
            nudQtdParcelas.Location = new Point(58, 22);
            nudQtdParcelas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQtdParcelas.Name = "nudQtdParcelas";
            nudQtdParcelas.Size = new Size(76, 23);
            nudQtdParcelas.TabIndex = 40;
            nudQtdParcelas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(5, 4);
            label9.Name = "label9";
            label9.Size = new Size(45, 15);
            label9.TabIndex = 21;
            label9.Text = "Parcela";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(58, 3);
            label10.Name = "label10";
            label10.Size = new Size(76, 15);
            label10.TabIndex = 23;
            label10.Text = "Qtd. parcelas";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(140, 4);
            label13.Name = "label13";
            label13.Size = new Size(98, 15);
            label13.TabIndex = 29;
            label13.Text = "Dt. primeira parc.";
            // 
            // tbxValorTotal
            // 
            tbxValorTotal.Location = new Point(259, 21);
            tbxValorTotal.Name = "tbxValorTotal";
            tbxValorTotal.Size = new Size(116, 23);
            tbxValorTotal.TabIndex = 32;
            // 
            // dtpDataInicial
            // 
            dtpDataInicial.Format = DateTimePickerFormat.Short;
            dtpDataInicial.Location = new Point(140, 22);
            dtpDataInicial.Name = "dtpDataInicial";
            dtpDataInicial.Size = new Size(113, 23);
            dtpDataInicial.TabIndex = 30;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(259, 3);
            label14.Name = "label14";
            label14.Size = new Size(60, 15);
            label14.TabIndex = 31;
            label14.Text = "Valor total";
            // 
            // cbxCategoria
            // 
            cbxCategoria.FormattingEnabled = true;
            cbxCategoria.Location = new Point(12, 124);
            cbxCategoria.Name = "cbxCategoria";
            cbxCategoria.Size = new Size(121, 23);
            cbxCategoria.TabIndex = 56;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(139, 107);
            label16.Name = "label16";
            label16.Size = new Size(39, 15);
            label16.TabIndex = 63;
            label16.Text = "Conta";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 107);
            label11.Name = "label11";
            label11.Size = new Size(58, 15);
            label11.TabIndex = 57;
            label11.Text = "Categoria";
            // 
            // cbxContas
            // 
            cbxContas.FormattingEnabled = true;
            cbxContas.Location = new Point(139, 124);
            cbxContas.Name = "cbxContas";
            cbxContas.Size = new Size(121, 23);
            cbxContas.TabIndex = 62;
            // 
            // dtpMesReferenciaLancamento
            // 
            dtpMesReferenciaLancamento.Format = DateTimePickerFormat.Custom;
            dtpMesReferenciaLancamento.Location = new Point(269, 124);
            dtpMesReferenciaLancamento.Name = "dtpMesReferenciaLancamento";
            dtpMesReferenciaLancamento.Size = new Size(104, 23);
            dtpMesReferenciaLancamento.TabIndex = 60;
            dtpMesReferenciaLancamento.ValueChanged += dtpMesReferenciaLancamento_ValueChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(269, 106);
            label15.Name = "label15";
            label15.Size = new Size(100, 15);
            label15.TabIndex = 61;
            label15.Text = "Mês de referência";
            // 
            // FormAddLancamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 348);
            Controls.Add(label21);
            Controls.Add(tbxValorExtrapolado);
            Controls.Add(chkObrigatorio);
            Controls.Add(label19);
            Controls.Add(btnLimparLancamento);
            Controls.Add(tbxDescricao);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(lblTipoSaida);
            Controls.Add(tbxValor);
            Controls.Add(btnSalvarLancamento);
            Controls.Add(cbxTipoSaida);
            Controls.Add(label12);
            Controls.Add(dtpDataLancamento);
            Controls.Add(label17);
            Controls.Add(tbxChaveLancamento);
            Controls.Add(panelParcelas);
            Controls.Add(cbxCategoria);
            Controls.Add(label16);
            Controls.Add(label11);
            Controls.Add(cbxContas);
            Controls.Add(dtpMesReferenciaLancamento);
            Controls.Add(label15);
            Name = "FormAddLancamento";
            Text = "Adicionar Lançamento";
            Load += FormAddLancamento_Load;
            panelParcelas.ResumeLayout(false);
            panelParcelas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQtdParcelas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label21;
        private TextBox tbxValorExtrapolado;
        private CheckBox chkObrigatorio;
        private Label label19;
        private Button btnLimparLancamento;
        private TextBox tbxDescricao;
        private Label label7;
        private Label label8;
        private Label lblTipoSaida;
        private TextBox tbxValor;
        private Button btnSalvarLancamento;
        private ComboBox cbxTipoSaida;
        private Label label12;
        private DateTimePicker dtpDataLancamento;
        private Label label17;
        private TextBox tbxChaveLancamento;
        private Panel panelParcelas;
        private TextBox tbxNumParcela;
        private NumericUpDown nudQtdParcelas;
        private Label label9;
        private Label label10;
        private Label label13;
        private TextBox tbxValorTotal;
        private DateTimePicker dtpDataInicial;
        private Label label14;
        private ComboBox cbxCategoria;
        private Label label16;
        private Label label11;
        private ComboBox cbxContas;
        private DateTimePicker dtpMesReferenciaLancamento;
        private Label label15;
    }
}