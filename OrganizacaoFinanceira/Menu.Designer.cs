namespace OrganizacaoFinanceira
{
    partial class Menu
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
            menuStrip1 = new MenuStrip();
            lançamentosToolStripMenuItem = new ToolStripMenuItem();
            categoriasToolStripMenuItem = new ToolStripMenuItem();
            mesesFuturoToolStripMenuItem = new ToolStripMenuItem();
            geralToolStripMenuItem = new ToolStripMenuItem();
            atualizarDadosToolStripMenuItem = new ToolStripMenuItem();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panelPrincipal = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { lançamentosToolStripMenuItem, categoriasToolStripMenuItem, mesesFuturoToolStripMenuItem, geralToolStripMenuItem, atualizarDadosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 87;
            menuStrip1.Text = "menuStrip1";
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
            categoriasToolStripMenuItem.Click += categoriasToolStripMenuItem_Click;
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
            geralToolStripMenuItem.Click += geralToolStripMenuItem_Click;
            // 
            // atualizarDadosToolStripMenuItem
            // 
            atualizarDadosToolStripMenuItem.Name = "atualizarDadosToolStripMenuItem";
            atualizarDadosToolStripMenuItem.Size = new Size(100, 20);
            atualizarDadosToolStripMenuItem.Text = "Atualizar dados";
            atualizarDadosToolStripMenuItem.Click += btnAtualizarDados_Click;
            // 
            // panelPrincipal
            // 
            panelPrincipal.Dock = DockStyle.Fill;
            panelPrincipal.Location = new Point(0, 24);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Size = new Size(800, 426);
            panelPrincipal.TabIndex = 88;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelPrincipal);
            Controls.Add(menuStrip1);
            Name = "Menu";
            Text = "Menu";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem lançamentosToolStripMenuItem;
        private ToolStripMenuItem categoriasToolStripMenuItem;
        private ToolStripMenuItem mesesFuturoToolStripMenuItem;
        private ToolStripMenuItem geralToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panelPrincipal;
        private ToolStripMenuItem atualizarDadosToolStripMenuItem;
    }
}