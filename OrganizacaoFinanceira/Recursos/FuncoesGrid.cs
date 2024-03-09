using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizacaoFinanceira.Recursos
{
    internal class FuncoesGrid
    {
        public void ConfigurarGrid(DataGridView dgv, BindingSource bindingSource, List<(string, string, DataGridViewContentAlignment, int, bool)> colunas, bool autoSizeFill = true)
        {
            // Configuração do DataGridView
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = bindingSource;
            dgv.Columns.Clear();
            dgv.Rows.Clear();
            // Configuração das colunas
            DataGridViewTextBoxColumn nameColumn;
            foreach (var (item1, item2, item3, item4, item5) in colunas)
            {
                nameColumn = new DataGridViewTextBoxColumn();
                nameColumn.DataPropertyName = item1; // Nome da propriedade do objeto MyDataItem
                nameColumn.HeaderText = item2; // Título da coluna no grid
                nameColumn.DefaultCellStyle.Alignment = item3;
                nameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                nameColumn.Width = item4;
                if (autoSizeFill) nameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (item5)nameColumn.DefaultCellStyle.Format = "N2";                

                dgv.Columns.Add(nameColumn);
            }
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.DefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;

            //dgv.Width = dgv.Parent.Width - gbxCadastrar.Width - 50;
            //dgv.Columns[0].Width = 100;

            // Habilitar a ordenação para cada coluna
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        public List<(string, string, DataGridViewContentAlignment, int, bool)> ColunasGridContas()
        {
            List<(string, string, DataGridViewContentAlignment, int, bool)> colunas = new List<(string, string, DataGridViewContentAlignment, int, bool)>
            {
                ("nomeBanco", "Banco", DataGridViewContentAlignment.MiddleCenter, 100, false),
                ("usuarioConta", "Usuário", DataGridViewContentAlignment.MiddleCenter, 100, false),
                ("valorInicial", "Valor inicial", DataGridViewContentAlignment.MiddleCenter, 120, true),
                ("valorAtual", "Valor atual", DataGridViewContentAlignment.MiddleCenter, 120, true),
                ("diaFechamento", "Dia fech.", DataGridViewContentAlignment.MiddleCenter, 100, false),
                ("dataCriacao", "Data criação", DataGridViewContentAlignment.MiddleCenter, 140, false),
                ("dataAlteracao", "Data alteração", DataGridViewContentAlignment.MiddleCenter, 140, false)
            };

            return colunas;
        }

        public List<(string, string, DataGridViewContentAlignment, int, bool)> ColunasGridSaidas()
        {
            List<(string, string, DataGridViewContentAlignment, int, bool)> colunas = new List<(string, string, DataGridViewContentAlignment, int, bool)>
            {
                ("descricao", "Descrição", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("valorParcela", "Valor", DataGridViewContentAlignment.MiddleCenter, 100, true),
                ("data", "Data", DataGridViewContentAlignment.MiddleCenter, 100, false),
                ("chaveCategoria", "Categoria", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("tipoSaida", "Tipo", DataGridViewContentAlignment.MiddleCenter, 100, false),
                ("parcela", "Parcela", DataGridViewContentAlignment.MiddleCenter, 75, false),
                ("qtdParcelas", "Qtd. de parcelas", DataGridViewContentAlignment.MiddleCenter, 100, false),
                ("dataInicio", "Dt. primeira parcela", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("dataCadastro", "Dt. de cadastro", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("dataAlteracao", "Dt. de alteração", DataGridViewContentAlignment.MiddleCenter, 150, false)
            };
            return colunas;
        }

        public List<(string, string, DataGridViewContentAlignment, int, bool)> ColunasGridEntradas()
        {
            List<(string, string, DataGridViewContentAlignment, int, bool)> colunas = new List<(string, string, DataGridViewContentAlignment, int, bool)>
            {
                ("descricao", "Descrição", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("valor", "Valor", DataGridViewContentAlignment.MiddleCenter, 100, true),
                ("data", "Data", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("chaveCategoria", "Categoria", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("dataCadastro", "Dt. de cadastro", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("dataAlteracao", "Dt. de alteração", DataGridViewContentAlignment.MiddleCenter, 150, false)
            };
            return colunas;
        }

        public List<(string, string, DataGridViewContentAlignment, int, bool)> ColunasGridCategorias()
        {
            List<(string, string, DataGridViewContentAlignment, int, bool)> colunas = new List<(string, string, DataGridViewContentAlignment, int, bool)>
            {
                ("descricao", "Descrição", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("verbaPadrao", "Verba padrão", DataGridViewContentAlignment.MiddleCenter, 150, true),
                ("saldoTotal", "Saldo geral", DataGridViewContentAlignment.MiddleCenter, 150, true),
            };
            return colunas;
        }

        public List<(string, string, DataGridViewContentAlignment, int, bool)> ColunasGridMeses()
        {
            List<(string, string, DataGridViewContentAlignment, int, bool)> colunas = new List<(string, string, DataGridViewContentAlignment, int, bool)>
            {
                ("mes", "Mês", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("verbaOriginal", "Verba inicial", DataGridViewContentAlignment.MiddleCenter, 150, true),
                ("verbaAdicional", "Verba adicional", DataGridViewContentAlignment.MiddleCenter, 150, true),
                ("verbaMes", "Verba mês", DataGridViewContentAlignment.MiddleCenter, 150, true),
                ("saldoMes", "Saldo mês", DataGridViewContentAlignment.MiddleCenter, 150, true),
            };
            return colunas;
        }
        
        public List<(string, string, DataGridViewContentAlignment, int, bool)> ColunasGridMesesFuturos()
        {
            List<(string, string, DataGridViewContentAlignment, int, bool)> colunas = new List<(string, string, DataGridViewContentAlignment, int, bool)>
            {
                ("mes", "Mês", DataGridViewContentAlignment.MiddleCenter, 100, false),
                ("saidasTotais", "Saídas", DataGridViewContentAlignment.MiddleCenter, 150, true),
                ("saidasParceladas", "Saídas parceladas", DataGridViewContentAlignment.MiddleCenter, 150, true),
                ("entradasTotais", "Entradas", DataGridViewContentAlignment.MiddleCenter, 150, true),
                ("saldoGeral", "Saldo", DataGridViewContentAlignment.MiddleCenter, 150, true),
            };
            return colunas;
        }

        public List<(string, string, DataGridViewContentAlignment, int, bool)> ColunasGridLancamentosRecorrentes()
        {
            List<(string, string, DataGridViewContentAlignment, int, bool)> colunas = new List<(string, string, DataGridViewContentAlignment, int, bool)>
            {
                ("descricao", "Descrição", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("valor", "Valor", DataGridViewContentAlignment.MiddleCenter, 150, true),
                ("chaveCategoria", "Categoria", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("tipoLancamento", "Tipo do lançamento", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("obrigatorio", "Obrigatório", DataGridViewContentAlignment.MiddleCenter, 100, false),
            };
            return colunas;
        }
    }
}
