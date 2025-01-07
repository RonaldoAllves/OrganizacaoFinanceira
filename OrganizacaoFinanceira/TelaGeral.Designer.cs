namespace OrganizacaoFinanceira
{
    partial class TelaGeral
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
            lblDividaTotal = new Label();
            lblValorDividaTotal = new Label();
            lblValorSaldoTotal = new Label();
            lblSaldoTotal = new Label();
            lblValorEntradasRecentes = new Label();
            lblEntradasRecentes = new Label();
            lblValorSaidasRecentes = new Label();
            lblSaidasRecentes = new Label();
            lblValorRendimentosRecentes = new Label();
            lblRendimenosRecentes = new Label();
            dtpDataInicial = new DateTimePicker();
            dtpDataFinal = new DateTimePicker();
            lblDataInicial = new Label();
            lblDataFinal = new Label();
            panelDadosCategorias = new Panel();
            panelPeriodo = new Panel();
            panelPeriodo.SuspendLayout();
            SuspendLayout();
            // 
            // lblDividaTotal
            // 
            lblDividaTotal.AutoSize = true;
            lblDividaTotal.Location = new Point(12, 9);
            lblDividaTotal.Name = "lblDividaTotal";
            lblDividaTotal.Size = new Size(136, 15);
            lblDividaTotal.TabIndex = 0;
            lblDividaTotal.Text = "Dívida crédito atual total";
            // 
            // lblValorDividaTotal
            // 
            lblValorDividaTotal.AutoSize = true;
            lblValorDividaTotal.Location = new Point(12, 34);
            lblValorDividaTotal.Name = "lblValorDividaTotal";
            lblValorDividaTotal.Size = new Size(44, 15);
            lblValorDividaTotal.TabIndex = 1;
            lblValorDividaTotal.Text = "R$ 0,00";
            // 
            // lblValorSaldoTotal
            // 
            lblValorSaldoTotal.AutoSize = true;
            lblValorSaldoTotal.Location = new Point(221, 34);
            lblValorSaldoTotal.Name = "lblValorSaldoTotal";
            lblValorSaldoTotal.Size = new Size(44, 15);
            lblValorSaldoTotal.TabIndex = 3;
            lblValorSaldoTotal.Text = "R$ 0,00";
            // 
            // lblSaldoTotal
            // 
            lblSaldoTotal.AutoSize = true;
            lblSaldoTotal.Location = new Point(221, 9);
            lblSaldoTotal.Name = "lblSaldoTotal";
            lblSaldoTotal.Size = new Size(63, 15);
            lblSaldoTotal.TabIndex = 2;
            lblSaldoTotal.Text = "Saldo total";
            // 
            // lblValorEntradasRecentes
            // 
            lblValorEntradasRecentes.AutoSize = true;
            lblValorEntradasRecentes.Location = new Point(14, 90);
            lblValorEntradasRecentes.Name = "lblValorEntradasRecentes";
            lblValorEntradasRecentes.Size = new Size(44, 15);
            lblValorEntradasRecentes.TabIndex = 5;
            lblValorEntradasRecentes.Text = "R$ 0,00";
            // 
            // lblEntradasRecentes
            // 
            lblEntradasRecentes.AutoSize = true;
            lblEntradasRecentes.Location = new Point(14, 65);
            lblEntradasRecentes.Name = "lblEntradasRecentes";
            lblEntradasRecentes.Size = new Size(145, 15);
            lblEntradasRecentes.TabIndex = 4;
            lblEntradasRecentes.Text = "Entradas totais no período";
            // 
            // lblValorSaidasRecentes
            // 
            lblValorSaidasRecentes.AutoSize = true;
            lblValorSaidasRecentes.Location = new Point(256, 90);
            lblValorSaidasRecentes.Name = "lblValorSaidasRecentes";
            lblValorSaidasRecentes.Size = new Size(44, 15);
            lblValorSaidasRecentes.TabIndex = 7;
            lblValorSaidasRecentes.Text = "R$ 0,00";
            // 
            // lblSaidasRecentes
            // 
            lblSaidasRecentes.AutoSize = true;
            lblSaidasRecentes.Location = new Point(256, 65);
            lblSaidasRecentes.Name = "lblSaidasRecentes";
            lblSaidasRecentes.Size = new Size(133, 15);
            lblSaidasRecentes.TabIndex = 6;
            lblSaidasRecentes.Text = "Saídas totais no período";
            // 
            // lblValorRendimentosRecentes
            // 
            lblValorRendimentosRecentes.AutoSize = true;
            lblValorRendimentosRecentes.Location = new Point(479, 90);
            lblValorRendimentosRecentes.Name = "lblValorRendimentosRecentes";
            lblValorRendimentosRecentes.Size = new Size(44, 15);
            lblValorRendimentosRecentes.TabIndex = 9;
            lblValorRendimentosRecentes.Text = "R$ 0,00";
            // 
            // lblRendimenosRecentes
            // 
            lblRendimenosRecentes.AutoSize = true;
            lblRendimenosRecentes.Location = new Point(479, 65);
            lblRendimenosRecentes.Name = "lblRendimenosRecentes";
            lblRendimenosRecentes.Size = new Size(142, 15);
            lblRendimenosRecentes.TabIndex = 8;
            lblRendimenosRecentes.Text = "Rendimentos por período";
            // 
            // dtpDataInicial
            // 
            dtpDataInicial.Location = new Point(14, 26);
            dtpDataInicial.Name = "dtpDataInicial";
            dtpDataInicial.Size = new Size(200, 23);
            dtpDataInicial.TabIndex = 10;
            dtpDataInicial.ValueChanged += dtpDataInicial_ValueChanged;
            // 
            // dtpDataFinal
            // 
            dtpDataFinal.Location = new Point(256, 26);
            dtpDataFinal.Name = "dtpDataFinal";
            dtpDataFinal.Size = new Size(200, 23);
            dtpDataFinal.TabIndex = 11;
            dtpDataFinal.ValueChanged += dtpDataFinal_ValueChanged;
            // 
            // lblDataInicial
            // 
            lblDataInicial.AutoSize = true;
            lblDataInicial.Location = new Point(14, 8);
            lblDataInicial.Name = "lblDataInicial";
            lblDataInicial.Size = new Size(63, 15);
            lblDataInicial.TabIndex = 12;
            lblDataInicial.Text = "Mês inicial";
            // 
            // lblDataFinal
            // 
            lblDataFinal.AutoSize = true;
            lblDataFinal.Location = new Point(256, 8);
            lblDataFinal.Name = "lblDataFinal";
            lblDataFinal.Size = new Size(55, 15);
            lblDataFinal.TabIndex = 13;
            lblDataFinal.Text = "Mês final";
            // 
            // panelDadosCategorias
            // 
            panelDadosCategorias.BorderStyle = BorderStyle.FixedSingle;
            panelDadosCategorias.Location = new Point(14, 129);
            panelDadosCategorias.Name = "panelDadosCategorias";
            panelDadosCategorias.Size = new Size(706, 343);
            panelDadosCategorias.TabIndex = 14;
            // 
            // panelPeriodo
            // 
            panelPeriodo.BorderStyle = BorderStyle.FixedSingle;
            panelPeriodo.Controls.Add(panelDadosCategorias);
            panelPeriodo.Controls.Add(lblDataFinal);
            panelPeriodo.Controls.Add(dtpDataInicial);
            panelPeriodo.Controls.Add(lblDataInicial);
            panelPeriodo.Controls.Add(lblEntradasRecentes);
            panelPeriodo.Controls.Add(dtpDataFinal);
            panelPeriodo.Controls.Add(lblValorEntradasRecentes);
            panelPeriodo.Controls.Add(lblSaidasRecentes);
            panelPeriodo.Controls.Add(lblValorRendimentosRecentes);
            panelPeriodo.Controls.Add(lblValorSaidasRecentes);
            panelPeriodo.Controls.Add(lblRendimenosRecentes);
            panelPeriodo.Location = new Point(12, 76);
            panelPeriodo.Name = "panelPeriodo";
            panelPeriodo.Size = new Size(757, 506);
            panelPeriodo.TabIndex = 15;
            // 
            // TelaGeral
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1063, 740);
            Controls.Add(panelPeriodo);
            Controls.Add(lblValorSaldoTotal);
            Controls.Add(lblSaldoTotal);
            Controls.Add(lblValorDividaTotal);
            Controls.Add(lblDividaTotal);
            Name = "TelaGeral";
            Text = "TelaGeral";
            Load += TelaGeral_Load;
            Resize += TelaGeral_Resize;
            panelPeriodo.ResumeLayout(false);
            panelPeriodo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDividaTotal;
        private Label lblValorDividaTotal;
        private Label lblValorSaldoTotal;
        private Label lblSaldoTotal;
        private Label lblValorEntradasRecentes;
        private Label lblEntradasRecentes;
        private Label lblValorSaidasRecentes;
        private Label lblSaidasRecentes;
        private Label lblValorRendimentosRecentes;
        private Label lblRendimenosRecentes;
        private DateTimePicker dtpDataInicial;
        private DateTimePicker dtpDataFinal;
        private Label lblDataInicial;
        private Label lblDataFinal;
        private Panel panelDadosCategorias;
        private Panel panelPeriodo;
    }
}