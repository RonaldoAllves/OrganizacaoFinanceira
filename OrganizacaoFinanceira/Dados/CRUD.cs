using FireSharp.Response;
using FireSharp;
using OrganizacaoFinanceira.Objetos;
using OrganizacaoFinanceira.Recursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizacaoFinanceira.Dados
{
    public class CRUD
    {
        public async Task BuscarTodosDados()
        {
            DadosGerais.client = new FirebaseClient(DadosGerais.config);
            if (DadosGerais.client == null)
            {
                MessageBox.Show("Falha de conexão com o servidor!");
                return;
            }

            DadosGerais.contas = await BuscarContas();
            DadosGerais.saidas = await BuscarSaidas();
            DadosGerais.entradas = await BuscarEntradas();
            DadosGerais.meses = await BuscarMeses();
            DadosGerais.categorias = await BuscarCategorias();
            DadosGerais.lancamentosRecorrentes = await BuscarLancamentosRecorrentes();
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
    }
}
