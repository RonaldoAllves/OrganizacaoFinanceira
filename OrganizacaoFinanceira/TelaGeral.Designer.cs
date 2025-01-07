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
            lblValorEntradasRecentes.Location = new Point(12, 170);
            lblValorEntradasRecentes.Name = "lblValorEntradasRecentes";
            lblValorEntradasRecentes.Size = new Size(44, 15);
            lblValorEntradasRecentes.TabIndex = 5;
            lblValorEntradasRecentes.Text = "R$ 0,00";
            // 
            // lblEntradasRecentes
            // 
            lblEntradasRecentes.AutoSize = true;
            lblEntradasRecentes.Location = new Point(12, 145);
            lblEntradasRecentes.Name = "lblEntradasRecentes";
            lblEntradasRecentes.Size = new Size(178, 15);
            lblEntradasRecentes.TabIndex = 4;
            lblEntradasRecentes.Text = "Entradas totais últimos 12 meses";
            // 
            // lblValorSaidasRecentes
            // 
            lblValorSaidasRecentes.AutoSize = true;
            lblValorSaidasRecentes.Location = new Point(254, 170);
            lblValorSaidasRecentes.Name = "lblValorSaidasRecentes";
            lblValorSaidasRecentes.Size = new Size(44, 15);
            lblValorSaidasRecentes.TabIndex = 7;
            lblValorSaidasRecentes.Text = "R$ 0,00";
            // 
            // lblSaidasRecentes
            // 
            lblSaidasRecentes.AutoSize = true;
            lblSaidasRecentes.Location = new Point(254, 145);
            lblSaidasRecentes.Name = "lblSaidasRecentes";
            lblSaidasRecentes.Size = new Size(166, 15);
            lblSaidasRecentes.TabIndex = 6;
            lblSaidasRecentes.Text = "Saídas totais últimos 12 meses";
            // 
            // lblValorRendimentosRecentes
            // 
            lblValorRendimentosRecentes.AutoSize = true;
            lblValorRendimentosRecentes.Location = new Point(477, 170);
            lblValorRendimentosRecentes.Name = "lblValorRendimentosRecentes";
            lblValorRendimentosRecentes.Size = new Size(44, 15);
            lblValorRendimentosRecentes.TabIndex = 9;
            lblValorRendimentosRecentes.Text = "R$ 0,00";
            // 
            // lblRendimenosRecentes
            // 
            lblRendimenosRecentes.AutoSize = true;
            lblRendimenosRecentes.Location = new Point(477, 145);
            lblRendimenosRecentes.Name = "lblRendimenosRecentes";
            lblRendimenosRecentes.Size = new Size(171, 15);
            lblRendimenosRecentes.TabIndex = 8;
            lblRendimenosRecentes.Text = "Rendimentos últimos 12 meses";
            // 
            // dtpDataInicial
            // 
            dtpDataInicial.Location = new Point(12, 106);
            dtpDataInicial.Name = "dtpDataInicial";
            dtpDataInicial.Size = new Size(200, 23);
            dtpDataInicial.TabIndex = 10;
            dtpDataInicial.ValueChanged += dtpDataInicial_ValueChanged;
            // 
            // dtpDataFinal
            // 
            dtpDataFinal.Location = new Point(254, 106);
            dtpDataFinal.Name = "dtpDataFinal";
            dtpDataFinal.Size = new Size(200, 23);
            dtpDataFinal.TabIndex = 11;
            dtpDataFinal.ValueChanged += dtpDataFinal_ValueChanged;
            // 
            // lblDataInicial
            // 
            lblDataInicial.AutoSize = true;
            lblDataInicial.Location = new Point(12, 88);
            lblDataInicial.Name = "lblDataInicial";
            lblDataInicial.Size = new Size(63, 15);
            lblDataInicial.TabIndex = 12;
            lblDataInicial.Text = "Mês inicial";
            // 
            // lblDataFinal
            // 
            lblDataFinal.AutoSize = true;
            lblDataFinal.Location = new Point(254, 88);
            lblDataFinal.Name = "lblDataFinal";
            lblDataFinal.Size = new Size(55, 15);
            lblDataFinal.TabIndex = 13;
            lblDataFinal.Text = "Mês final";
            // 
            // panelDadosCategorias
            // 
            panelDadosCategorias.Location = new Point(12, 211);
            panelDadosCategorias.Name = "panelDadosCategorias";
            panelDadosCategorias.Size = new Size(882, 517);
            panelDadosCategorias.TabIndex = 14;
            // 
            // TelaGeral
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1063, 740);
            Controls.Add(panelDadosCategorias);
            Controls.Add(lblDataFinal);
            Controls.Add(lblDataInicial);
            Controls.Add(dtpDataFinal);
            Controls.Add(dtpDataInicial);
            Controls.Add(lblValorRendimentosRecentes);
            Controls.Add(lblRendimenosRecentes);
            Controls.Add(lblValorSaidasRecentes);
            Controls.Add(lblSaidasRecentes);
            Controls.Add(lblValorEntradasRecentes);
            Controls.Add(lblEntradasRecentes);
            Controls.Add(lblValorSaldoTotal);
            Controls.Add(lblSaldoTotal);
            Controls.Add(lblValorDividaTotal);
            Controls.Add(lblDividaTotal);
            Name = "TelaGeral";
            Text = "TelaGeral";
            Load += TelaGeral_Load;
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
    }
}