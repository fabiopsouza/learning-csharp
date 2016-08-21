using AluraNutricao.Data;
using SQLite.Net;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace AluraNutricao
{
    public class HomeTabbedPage : TabbedPage
    {
        public HomeTabbedPage()
        {
            SQLiteConnection con = DependencyService.Get<ISqlite>().GetConnection();
            RefeicaoDAO dao = new RefeicaoDAO(con);
            
            CadastroRefeicao telaCadastro = new CadastroRefeicao(dao);
            ListaRefeicoes telaLista = new ListaRefeicoes(dao);

            Children.Add(telaCadastro);
            Children.Add(telaLista);
        }
    }
}
