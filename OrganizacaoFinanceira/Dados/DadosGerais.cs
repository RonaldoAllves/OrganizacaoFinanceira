using FireSharp.Config;
using FireSharp.Interfaces;
using OrganizacaoFinanceira.Objetos;
using OrganizacaoFinanceira.Recursos;

namespace OrganizacaoFinanceira.Dados
{
    public static class DadosGerais
    {
        public static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "WIjBhJwJ5rlUBzzPRFEkvY3Ib35hKZpbWHkTqO9n",
            BasePath = "https://organizacaofinanceira-9160c-default-rtdb.firebaseio.com/"
        };

        public static IFirebaseClient client;

        public static SortableBindingList<ContaBanco> contas;
        public static SortableBindingList<Saida> saidas;
        public static SortableBindingList<Entrada> entradas;
        public static SortableBindingList<Categoria> categorias;
        public static SortableBindingList<Mes> meses;
        public static SortableBindingList<LancamentoRecorrente> lancamentosRecorrentes;
        public static SortableBindingList<LancamentoRecorrenteDetalhado> lancamentosRecorrentesDetalhado;
        public static List<MesFuturo> mesesFuturos;

        public static double entradaExtra = 0;
        public static double saidaExtra = 0;        
    }
}
