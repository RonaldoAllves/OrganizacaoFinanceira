using OrganizacaoFinanceira.Dados;
using OrganizacaoFinanceira.Telas;
using System.Windows.Forms;

namespace OrganizacaoFinanceira
{
    public partial class Menu : Form
    {
        CRUD CRUD = new CRUD();
        Form formularioAtual = null;

        public Menu()
        {
            InitializeComponent();
            CarregarDados();
        }

        private async Task CarregarDados()
        {
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            await CRUD.BuscarTodosDados(false);

            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }

        private void LoadFormInPanel(Form form)
        {            
            // Limpa o painel antes de adicionar o novo formulário
            panelPrincipal.Controls.Clear();

            // Configura o formulário para embutir dentro do painel
            form.TopLevel = false; // Define que não é um formulário de nível superior
            form.FormBorderStyle = FormBorderStyle.None; // Remove bordas do formulário
            form.Dock = DockStyle.Fill; // Faz o formulário preencher todo o painel

            // Adiciona o formulário ao painel e o exibe
            panelPrincipal.Controls.Add(form);
            form.Show();
        }

        private void lançamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.telaPrincipal = new();
            formularioAtual = Formularios.telaPrincipal;
            LoadFormInPanel(Formularios.telaPrincipal);
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.telaCategorias = new();
            formularioAtual = Formularios.telaCategorias;
            LoadFormInPanel(Formularios.telaCategorias);
        }

        private void mesesFuturoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.telaMesesFuturo = new();
            formularioAtual = Formularios.telaMesesFuturo;
            LoadFormInPanel(Formularios.telaMesesFuturo);
        }

        private async void btnAtualizarDados_Click(object sender, EventArgs e)
        {
            await CarregarDados();
            if (formularioAtual != null)
            {
                formularioAtual = new();
            }
        }
    }
}
