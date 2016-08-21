using AluraNutricao.Data;
using AluraNutricao.ViewModel;
using Xamarin.Forms;

namespace AluraNutricao
{
    public partial class CadastroRefeicao : ContentPage
    {
        public RefeicaoDAO Dao { get; set; }

        public CadastroRefeicao(RefeicaoDAO dao)
        {
            CadastroRefeicaoViewModel vm = new CadastroRefeicaoViewModel(dao, this);
            BindingContext = vm;
            InitializeComponent();
        }
        
    }
}
