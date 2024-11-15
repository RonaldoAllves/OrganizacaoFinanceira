using FireSharp;
using FireSharp.Response;
using OrganizacaoFinanceira.Objetos;
using OrganizacaoFinanceira.Recursos;

namespace OrganizacaoFinanceira.Dados
{
    public class CRUD
    {
        #region BUSCAS
        public async Task BuscarTodosDados(bool somenteInicializar)
        {
            DadosGerais.client = new FirebaseClient(DadosGerais.config);
            if (DadosGerais.client == null)
            {
                MessageBox.Show("Falha de conexão com o servidor!");
                return;
            }

            if (somenteInicializar)
            {
                inicializarVazio();
                return;
            }

            DadosGerais.contas = await BuscarContas();
            DadosGerais.saidas = await BuscarSaidas();
            DadosGerais.entradas = await BuscarEntradas();
            DadosGerais.meses = await BuscarMeses();
            DadosGerais.categorias = await BuscarCategorias();
            DadosGerais.lancamentosRecorrentes = await BuscarLancamentosRecorrentes();
            DadosGerais.lancamentosRecorrentesDetalhado = await BuscarLancamentosRecorrentesDetalhado();
            AtualizarValorTotalConta();
        }

        public void AtualizarValorTotalConta()
        {
            double saidasConta;
            double entradasConta;
            double creditoMesAtual;
            foreach (ContaBanco conta in DadosGerais.contas)
            {
                saidasConta = DadosGerais.saidas.Where(x => x.chaveConta == conta.chave && DataMenorIgual(x.mesReferencia.Date, DateTime.Now.Date)).Sum(x => x.valorParcela);
                entradasConta = DadosGerais.entradas.Where(x => x.chaveConta == conta.chave && DataMenorIgual(x.mesReferencia, DateTime.Now.Date)).Sum(x => x.valor);

                creditoMesAtual = DadosGerais.saidas.Where(x => x.chaveConta == conta.chave && x.tipoSaida == 0 && DatasIguais(x.mesReferencia.Date, DateTime.Now.Date)).Sum(x => x.valorParcela);
                saidasConta -= creditoMesAtual;

                conta.valorAtual = conta.valorInicial - saidasConta + entradasConta;
            }
        }

        static bool DataMenorIgual(DateTime data1, DateTime data2)
        {
            var data1SemDia = new DateTime(data1.Year, data1.Month, 1);
            var data2SemDia = new DateTime(data2.Year, data2.Month, 1);

            return data1SemDia <= data2SemDia;
        }

        static bool DatasIguais(DateTime data1, DateTime data2)
        {
            var data1SemDia = new DateTime(data1.Year, data1.Month, 1);
            var data2SemDia = new DateTime(data2.Year, data2.Month, 1);

            return data1SemDia == data2SemDia;
        }

        private void inicializarVazio()
        {
            DadosGerais.contas = new();
            DadosGerais.saidas = new();
            DadosGerais.entradas = new();
            DadosGerais.meses = new();
            DadosGerais.categorias = new();
            DadosGerais.lancamentosRecorrentes = new();
        }

        public async Task<SortableBindingList<Saida>> BuscarSaidas()
        {
            try
            {
                List<Saida> saidasAux;
                Dictionary<string, Saida> chavesSaidas;

                FirebaseResponse firebaseResponse = await DadosGerais.client.GetTaskAsync("Saidas");
                if (firebaseResponse.Body == "null") return new SortableBindingList<Saida>();

                chavesSaidas = firebaseResponse.ResultAs<Dictionary<string, Saida>>();
                saidasAux = chavesSaidas.Select(x => x.Value).ToList();

                return new SortableBindingList<Saida>(saidasAux);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar as saídas.\n\n" + ex.Message);
                return new SortableBindingList<Saida>();
            }

        }

        public async Task<SortableBindingList<Entrada>> BuscarEntradas()
        {
            try
            {
                List<Entrada> entradasAux;
                Dictionary<string, Entrada> chavesEntradas;

                FirebaseResponse firebaseResponse = await DadosGerais.client.GetTaskAsync("Entradas");
                if (firebaseResponse.Body == "null") return new SortableBindingList<Entrada>();

                chavesEntradas = firebaseResponse.ResultAs<Dictionary<string, Entrada>>();
                entradasAux = chavesEntradas.Select(x => x.Value).ToList();

                return new SortableBindingList<Entrada>(entradasAux);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar as entradas.\n\n" + ex.Message);
                return new SortableBindingList<Entrada>();
            }

        }
        public async Task<SortableBindingList<ContaBanco>> BuscarContas()
        {
            try
            {
                List<ContaBanco> contasAux;
                Dictionary<string, ContaBanco> chavesContas;

                FirebaseResponse firebaseResponse = await DadosGerais.client.GetTaskAsync("Contas");
                if (firebaseResponse.Body == "null") return new SortableBindingList<ContaBanco>();

                chavesContas = firebaseResponse.ResultAs<Dictionary<string, ContaBanco>>();
                contasAux = chavesContas.Select(x => x.Value).ToList();

                return new SortableBindingList<ContaBanco>(contasAux);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar as contas.\n\n" + ex.Message);
                return new SortableBindingList<ContaBanco>(); ;
            }

        }

        public async Task<SortableBindingList<Mes>> BuscarMeses()
        {
            try
            {
                List<Mes> mesesAux;
                Dictionary<string, Mes> chavesMeses;

                FirebaseResponse firebaseResponse = await DadosGerais.client.GetTaskAsync("Meses");
                if (firebaseResponse.Body == "null") return new SortableBindingList<Mes>();

                chavesMeses = firebaseResponse.ResultAs<Dictionary<string, Mes>>();
                mesesAux = chavesMeses.Select(x => x.Value).ToList();

                return new SortableBindingList<Mes>(mesesAux);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar os meses.\n\n" + ex.Message);
                return new SortableBindingList<Mes>();
            }

        }

        public async Task<SortableBindingList<Categoria>> BuscarCategorias()
        {
            try
            {
                List<Categoria> categoriasAux;
                Dictionary<string, Categoria> chavesCategorias;

                FirebaseResponse firebaseResponse = await DadosGerais.client.GetTaskAsync("Categorias");
                if (firebaseResponse.Body == "null") return new SortableBindingList<Categoria>();

                chavesCategorias = firebaseResponse.ResultAs<Dictionary<string, Categoria>>();
                categoriasAux = chavesCategorias.Select(x => x.Value).ToList();

                return new SortableBindingList<Categoria>(categoriasAux);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar as categorias.\n\n" + ex.Message);
                return new SortableBindingList<Categoria>();
            }

        }

        public async Task<SortableBindingList<LancamentoRecorrente>> BuscarLancamentosRecorrentes()
        {
            try
            {
                List<LancamentoRecorrente> lancRecorrentesAux;
                Dictionary<string, LancamentoRecorrente> chavesLancRecorrentes;

                FirebaseResponse firebaseResponse = await DadosGerais.client.GetTaskAsync("LancamentosRecorrentes");
                if (firebaseResponse.Body == "null") return new SortableBindingList<LancamentoRecorrente>();

                chavesLancRecorrentes = firebaseResponse.ResultAs<Dictionary<string, LancamentoRecorrente>>();
                lancRecorrentesAux = chavesLancRecorrentes.Select(x => x.Value).ToList();

                return new SortableBindingList<LancamentoRecorrente>(lancRecorrentesAux);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar os lançamentos recorrentes.\n\n" + ex.Message);
                return new SortableBindingList<LancamentoRecorrente>();
            }
        }

        public async Task<SortableBindingList<LancamentoRecorrenteDetalhado>> BuscarLancamentosRecorrentesDetalhado()
        {
            try
            {
                List<LancamentoRecorrenteDetalhado> lancRecorrentesDetalhadoAux;
                Dictionary<string, LancamentoRecorrenteDetalhado> chavesLancRecorrentesDetalhados;

                FirebaseResponse firebaseResponse = await DadosGerais.client.GetTaskAsync("LancamentosRecorrentesDetalhados");
                if (firebaseResponse.Body == "null") return new SortableBindingList<LancamentoRecorrenteDetalhado>();

                chavesLancRecorrentesDetalhados = firebaseResponse.ResultAs<Dictionary<string, LancamentoRecorrenteDetalhado>>();
                lancRecorrentesDetalhadoAux = chavesLancRecorrentesDetalhados.Select(x => x.Value).ToList();

                return new SortableBindingList<LancamentoRecorrenteDetalhado>(lancRecorrentesDetalhadoAux);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar os lançamentos recorrentes detalhados.\n\n" + ex.Message);
                return new SortableBindingList<LancamentoRecorrenteDetalhado>();
            }
        }

        #endregion

        public async Task CriarMes(Mes mesNovo, int categoria, DateTime mes)
        {
            if (DadosGerais.categorias == null || DadosGerais.categorias.Count == 0 || categoria == 0)
            {
                MessageBox.Show("Deve criar primeiro as categorias.");
                return;
            }

            if (DadosGerais.meses == null || DadosGerais.meses.Count == 0)
            {
                mesNovo.chave = 1;

            }
            else
            {
                Mes mesOld = DadosGerais.meses.FirstOrDefault(x => x.mes.Month == mes.Month && x.mes.Year == mes.Year && x.chaveCategoria == categoria);
                if (mesOld != null)
                {
                    if (mesOld.verbaOriginal == mesNovo.verbaOriginal)
                    {
                        MessageBox.Show("Mês já existe.");
                        return;
                    }
                    mesNovo.chave = mesOld.chave;
                    mesNovo.verbaAdicional = mesOld.verbaAdicional;
                }
                else
                    mesNovo.chave = DadosGerais.meses.Max(x => x.chave) + 1;
            }

            mesNovo.mes = mes.Date;
            mesNovo.chaveCategoria = categoria;

            await SalvarMes(mesNovo, true);
        }

        public async Task SalvarMes(Mes mesNovo, bool mostrarMensagem)
        {
            SetResponse response = await DadosGerais.client.SetTaskAsync("Meses/" + "chave-" + mesNovo.chave.ToString(), mesNovo);

            if (response.Exception != null)
            {
                MessageBox.Show("Erro ao adicionar a verba no mês.\n" + response.Exception);
            }
        }
    }
}
