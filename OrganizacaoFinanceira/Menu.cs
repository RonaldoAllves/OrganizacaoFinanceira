using OrganizacaoFinanceira.Dados;
using OrganizacaoFinanceira.Telas;
using System.Windows.Forms;

namespace OrganizacaoFinanceira
{
    public partial class Menu : Form
    {
        CRUD CRUD = new CRUD();
        Form formularioAtual = null;
        private ToolStripMenuItem currentMenuItem = null;

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
            Application.DoEvents();
        }

        private void lançamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.telaPrincipal = new();
            formularioAtual = Formularios.telaPrincipal;
            SetMenuItemActive(lançamentosToolStripMenuItem);
            LoadFormInPanel(Formularios.telaPrincipal);
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.telaCategorias = new();
            formularioAtual = Formularios.telaCategorias;
            SetMenuItemActive(categoriasToolStripMenuItem);
            LoadFormInPanel(Formularios.telaCategorias);
        }

        private void mesesFuturoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.telaMesesFuturo = new();
            formularioAtual = Formularios.telaMesesFuturo;
            SetMenuItemActive(mesesFuturoToolStripMenuItem);
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

        private void SetMenuItemActive(ToolStripMenuItem activeMenuItem)
        {
            // Se já há um item ativo, restaure suas cores normais
            if (currentMenuItem != null)
            {
                currentMenuItem.BackColor = SystemColors.Control;   // Cor padrão do fundo
                currentMenuItem.ForeColor = SystemColors.ControlText; // Cor padrão do texto
            }

            // Atualiza o item ativo
            currentMenuItem = activeMenuItem;

            // Altere a cor de fundo e texto do item ativo
            currentMenuItem.BackColor = Color.DarkBlue;  // Cor de fundo do item ativo
            currentMenuItem.ForeColor = Color.White;     // Cor do texto do item ativo
        }
    }
}
