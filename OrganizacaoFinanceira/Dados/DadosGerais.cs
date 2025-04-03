using FireSharp.Config;
using FireSharp.Interfaces;
using OrganizacaoFinanceira.Objetos;
using OrganizacaoFinanceira.Recursos;

namespace OrganizacaoFinanceira.Dados
{
    public static class DadosGerais
    {
        //Produção
        
        //public static double valorInicial = 4187.72;
        public static double valorInicial = 7565.08;
        public static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "WIjBhJwJ5rlUBzzPRFEkvY3Ib35hKZpbWHkTqO9n",
            BasePath = "https://organizacaofinanceira-9160c-default-rtdb.firebaseio.com/"
        };
        

        //Teste
        /*
        public static double valorInicial = 1000;
        public static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "mLpflE6AJ7Y4GMtCEdppg3HZwL0JcTIKU7lt5kgm",
            BasePath = "https://organizacaofinanceiroteste-default-rtdb.firebaseio.com/"
        };
        */

        public static IFirebaseClient client;

        public static SortableBindingList<ContaBanco> contas;
        public static SortableBindingList<Saida> saidas;
        public static SortableBindingList<Entrada> entradas;
        public static SortableBindingList<Categoria> categorias;
        public static SortableBindingList<Mes> meses;
        public static SortableBindingList<LancamentoRecorrente> lancamentosRecorrentes;
        public static SortableBindingList<LancamentoRecorrenteDetalhado> lancamentosRecorrentesDetalhado;
        public static List<MesFuturo> mesesFuturos;

        public static List<LancamentoRecorrente> lancamentosRecorrentesOriginal;
        public static List<ObsMes> obsMes;

        public static bool calcularEntradaSaidaExtra = true;
        public static double entradaExtra = 0;
        public static double saidaExtra = 0;        
    }
}
