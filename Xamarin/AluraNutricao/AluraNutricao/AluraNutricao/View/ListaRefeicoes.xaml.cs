using AluraNutricao.Data;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AluraNutricao
{
    public partial class ListaRefeicoes : ContentPage
    {
        public ObservableCollection<Refeicao> Refeicoes { get; set; }
        private RefeicaoDAO Dao { get; set; }

        public string Nome { get; set; }

        public ListaRefeicoes(RefeicaoDAO dao)
        {
            BindingContext = this;
            Dao = dao;
            Refeicoes = dao.Lista;
            InitializeComponent();
        }

        public async void AcaoItem(object sender, ItemTappedEventArgs e)
        {
            Refeicao refeicao = e.Item as Refeicao;
            var resposta = await DisplayAlert("Remover item", "Você tem certeza que deseja remover a refeição" + refeicao.Descricao, "Sim", "Não");

            if (resposta)
            {
                Dao.Remove(refeicao);
                await DisplayAlert("Remover item", "Refeição removida com sucesso!", "Ok");
            }
        }
    }
}
