using OrganizacaoFinanceira.Telas;

namespace OrganizacaoFinanceira
{
    public partial class TelaGeral : Form
    {
        public TelaGeral()
        {
            InitializeComponent();
        }

        private void lançamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.telaPrincipal.Show();
            this.Close();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
