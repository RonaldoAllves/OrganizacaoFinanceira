﻿namespace OrganizacaoFinanceira.Recursos
{
    internal class FuncoesGrid
    {
        public void ConfigurarGrid(DataGridView dgv, BindingSource bindingSource, List<(string, string, DataGridViewContentAlignment, int, bool)> colunas, bool autoSizeFill)
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
                nameColumn.ReadOnly = true;
                nameColumn.DataPropertyName = item1; // Nome da propriedade do objeto MyDataItem
                nameColumn.HeaderText = item2; // Título da coluna no grid
                nameColumn.DefaultCellStyle.Alignment = item3;
                nameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                nameColumn.Width = item4;
                if (autoSizeFill) nameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (item5) nameColumn.DefaultCellStyle.Format = "N2";

                dgv.Columns.Add(nameColumn);
            }
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.AllowUserToAddRows = false;

            // Habilitar a ordenação para cada coluna
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        public void AjustarTitulo(DataGridView dataGridView, Label labelTitulo, string titulo)
        {
            labelTitulo.AutoSize = false;
            labelTitulo.Text = titulo;
            labelTitulo.BackColor = Color.FromArgb(181, 230, 29);
            labelTitulo.ForeColor = LayoutColor.backGround;
            labelTitulo.TextAlign = ContentAlignment.MiddleCenter;
            labelTitulo.Font = new Font("Arial", 12, FontStyle.Bold | FontStyle.Italic);


            // Definir o tamanho do label igual ao do DataGridView e centralizar
            labelTitulo.Width = CalcularLarguraTotal(dataGridView);
            labelTitulo.Height = 20; // Ajuste conforme necessário
            labelTitulo.Left = dataGridView.Left;

            labelTitulo.Top = dataGridView.Top;
            dataGridView.Top = labelTitulo.Top + labelTitulo.Height;

        }

        public static int CalcularLarguraTotal(DataGridView dataGridView)
        {
            int larguraTotal = 0;

            // Somar a largura de cada coluna
            foreach (DataGridViewColumn coluna in dataGridView.Columns)
            {
                if (coluna.Visible)
                    larguraTotal += coluna.Width;
            }

            // Adicionar a largura da borda direita do DataGridView
            larguraTotal += dataGridView.RowHeadersWidth;

            return larguraTotal;
        }

        public void ReajustarTamanhoTitulo(DataGridView dgv, Label labelTitulo)
        {
            labelTitulo.Width = CalcularLarguraTotal(dgv);
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

        public List<(string, string, DataGridViewContentAlignment, int, bool)> ColunasGridSaidas(bool comConta = false)
        {
            List<(string, string, DataGridViewContentAlignment, int, bool)> colunas = new List<(string, string, DataGridViewContentAlignment, int, bool)>
            {
                ("descricao", "Descrição", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("valorParcela", "Valor", DataGridViewContentAlignment.MiddleCenter, 100, true),
                ("data", "Data", DataGridViewContentAlignment.MiddleCenter, 100, false),
                ("chaveCategoria", "Categoria", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("tipoSaida", "Tipo", DataGridViewContentAlignment.MiddleCenter, 100, false),
                ("gastoObrigatorio", "Obrigatório", DataGridViewContentAlignment.MiddleCenter, 75, false),
                ("valorExtrapolado", "Valor extr.", DataGridViewContentAlignment.MiddleCenter, 100, false),
                ("parcela", "Parcela", DataGridViewContentAlignment.MiddleCenter, 75, false),
                ("qtdParcelas", "Qtd. de parcelas", DataGridViewContentAlignment.MiddleCenter, 100, false),
                ("dataInicio", "Dt. primeira parcela", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("dataCadastro", "Dt. de cadastro", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("dataAlteracao", "Dt. de alteração", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("chaveCategoriaMesFuturo", "Categoria mês futuro", DataGridViewContentAlignment.MiddleCenter, 150, false)
            };

            // Se comConta for verdadeiro, adicione uma nova coluna após "tipoSaida"
            if (comConta)
            {
                colunas.Insert(5, ("chaveConta", "Conta", DataGridViewContentAlignment.MiddleCenter, 150, false));
            }

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
                ("prioridade", "Prioridade", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("gastoFlexivel", "Gasto flexível", DataGridViewContentAlignment.MiddleCenter, 150, false),
            };
            return colunas;
        }

        public List<(string, string, DataGridViewContentAlignment, int, bool)> ColunasGridVerbasCategorias()
        {
            List<(string, string, DataGridViewContentAlignment, int, bool)> colunas = new List<(string, string, DataGridViewContentAlignment, int, bool)>
            {
                ("descricaoCategoria", "Descrição", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("verbaOriginalMesCategoria", "Verba original", DataGridViewContentAlignment.MiddleCenter, 150, true),
                ("verbaAdicionalMesCategoria", "Verba adicional", DataGridViewContentAlignment.MiddleCenter, 150, true),
                ("verbaMesCategoria", "Verba do mês", DataGridViewContentAlignment.MiddleCenter, 150, true),
                ("gastoMes", "Gasto do mês", DataGridViewContentAlignment.MiddleCenter, 150, true),
                ("saldoMes", "Saldo do mês", DataGridViewContentAlignment.MiddleCenter, 150, true),
                ("saldoTotal", "Saldo total", DataGridViewContentAlignment.MiddleCenter, 150, true),
                ("saldoGeral", "Saldo geral", DataGridViewContentAlignment.MiddleCenter, 150, true),
            };
            return colunas;
        }

        public List<(string, string, DataGridViewContentAlignment, int, bool)> ColunasGridMeses()
        {
            List<(string, string, DataGridViewContentAlignment, int, bool)> colunas = new List<(string, string, DataGridViewContentAlignment, int, bool)>
            {
                ("mes", "Mês", DataGridViewContentAlignment.MiddleCenter, 80, false),
                ("verbaOriginal", "Verba inicial", DataGridViewContentAlignment.MiddleCenter, 100, true),
                ("verbaAdicional", "Verba adicional", DataGridViewContentAlignment.MiddleCenter, 100, true),
                ("verbaMes", "Verba mês", DataGridViewContentAlignment.MiddleCenter, 100, true),
                ("saldoMes", "Saldo mês", DataGridViewContentAlignment.MiddleCenter, 100, true),
            };
            return colunas;
        }

        public List<(string, string, DataGridViewContentAlignment, int, bool)> ColunasGridMesesFuturos()
        {
            List<(string, string, DataGridViewContentAlignment, int, bool)> colunas = new List<(string, string, DataGridViewContentAlignment, int, bool)>
            {
                ("mes", "Mês", DataGridViewContentAlignment.MiddleCenter, 100, false),
                ("saidasTotais", "Saídas", DataGridViewContentAlignment.MiddleCenter, 100, true),
                ("saidasParceladas", "Saídas parceladas", DataGridViewContentAlignment.MiddleCenter, 100, true),
                ("entradasTotais", "Entradas", DataGridViewContentAlignment.MiddleCenter, 100, true),
                ("saldoGeral", "Saldo", DataGridViewContentAlignment.MiddleCenter, 100, true),
            };
            return colunas;
        }

        public List<(string, string, DataGridViewContentAlignment, int, bool)> ColunasGridLancamentosRecorrentes()
        {
            List<(string, string, DataGridViewContentAlignment, int, bool)> colunas = new List<(string, string, DataGridViewContentAlignment, int, bool)>
            {
                ("descricao", "Descrição", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("valor", "Valor", DataGridViewContentAlignment.MiddleCenter, 100, true),
                ("saldo", "Saldo", DataGridViewContentAlignment.MiddleCenter, 100, true),
                ("chaveCategoria", "Categoria", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("tipoLancamento", "Tipo do lançamento", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("dataFinal", "Data final", DataGridViewContentAlignment.MiddleCenter, 100, false),
                ("usaMesFixo", "Usa data fixa", DataGridViewContentAlignment.MiddleCenter, 100, false),
                ("dataFixa", "Mês fixo", DataGridViewContentAlignment.MiddleCenter, 100, false),
                ("obrigatorio", "Obrigatório", DataGridViewContentAlignment.MiddleCenter, 100, false),
            };
            return colunas;
        }

        public List<(string, string, DataGridViewContentAlignment, int, bool)> ColunasGridLancamentosRecorrentesDetalhado()
        {
            List<(string, string, DataGridViewContentAlignment, int, bool)> colunas = new List<(string, string, DataGridViewContentAlignment, int, bool)>
            {
                ("descricao", "Descrição", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("valor", "Valor", DataGridViewContentAlignment.MiddleCenter, 100, true),
                ("tipoLancamento", "Tipo do lançamento", DataGridViewContentAlignment.MiddleCenter, 150, false),
                ("mes", "Mês", DataGridViewContentAlignment.MiddleCenter, 100, false),
            };
            return colunas;
        }
    }
}
