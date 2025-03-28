using FireSharp.Response;
using OrganizacaoFinanceira.Dados;
using OrganizacaoFinanceira.Objetos;
using OrganizacaoFinanceira.Telas;
using System.Globalization;
using System.Text;
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
            //await AtualizarSaidasComCategoriaMesFuturo();

            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }

        private async Task AtualizarSaidasComCategoriaMesFuturo()
        {
            List<string> erros = new List<string>();
            // Mapeamento das chaves e valores para chaveCategoriaMesFuturo
            var mapeamentoChaves = new Dictionary<int, int>
            {
                { 2, 4 },
                { 3, 9 },
                { 5, 7 },
                { 7, 6 },
                { 8, 5 },
                { 9, 8 },
                { 13, 19 }
            };

            foreach (var saida in DadosGerais.saidas)
            {
                if (mapeamentoChaves.ContainsKey(saida.chaveCategoria))
                {
                    // Atualiza de acordo com o mapeamento
                    saida.chaveCategoriaMesFuturo = mapeamentoChaves[saida.chaveCategoria];
                }
                else if (saida.chaveCategoria == 1)
                {
                    // Para chaveCategoria 1, verificar a descrição
                    if (!string.IsNullOrEmpty(saida.descricao))
                    {
                        var descricaoNormalizada = RemoverAcentos(saida.descricao).ToLower();
                        if (descricaoNormalizada.Contains("emprestimo"))
                        {
                            saida.chaveCategoriaMesFuturo = 10;
                        }
                        else if (descricaoNormalizada.Contains("financiamento"))
                        {
                            saida.chaveCategoriaMesFuturo = 11;
                        }
                        else
                        {
                            saida.chaveCategoriaMesFuturo = 3;
                        }
                    }
                    else
                    {
                        saida.chaveCategoriaMesFuturo = 3; // Valor padrão caso a descrição seja nula ou vazia
                    }
                }
                else
                {
                    // Valor padrão para outras chaves
                    saida.chaveCategoriaMesFuturo = 9;
                }

                SetResponse response = await DadosGerais.client.SetTaskAsync("Saidas/" + "chave-" + saida.chave, saida);
                if (response.Exception != null)
                {
                    erros.Add($"{saida.descricao} - {saida.chave} - {saida.mesReferencia}");
                }
            }
            MessageBox.Show($"Ocorreu {erros.Count} erros");
        }

        // Método auxiliar para remover acentos de uma string
        private static string RemoverAcentos(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return texto;

            var normalizedString = texto.Normalize(NormalizationForm.FormD);
            var stringBuilder = new System.Text.StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
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

        private void geralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.telaGeral = new();
            formularioAtual = Formularios.telaGeral;
            SetMenuItemActive(geralToolStripMenuItem);
            LoadFormInPanel(Formularios.telaGeral);
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
