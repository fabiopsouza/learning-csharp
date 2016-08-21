using AluraNutricao.Data;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AluraNutricao.ViewModel
{
    public class CadastroRefeicaoViewModel : INotifyPropertyChanged
    {
        private RefeicaoDAO Dao { get; set; }
        private ContentPage Page { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SalvaRefeicao { get; set; }

        private string descricao { get; set; }
        private double calorias { get; set; }

        public string Descricao
        {
            get
            {
                return descricao;
            }
            set
            {
                if(descricao != value)
                {
                    descricao = value;
                    OnPropertyChanged(nameof(Descricao));
                }
            }
        }

        public double Calorias
        {
            get
            {
                return calorias;
            }
            set
            {
                if(calorias != value)
                {
                    calorias = value;
                    OnPropertyChanged(nameof(Calorias));
                }
            }
        }
        
        public CadastroRefeicaoViewModel(RefeicaoDAO dao, ContentPage page)
        {
            Dao = dao;
            Page = page;
            SalvaRefeicao = new Command(() => {
                Refeicao refeicao = new Refeicao(descricao, calorias);
                Dao.Salvar(refeicao);

                string msg = "A refeição " + descricao + " de " + calorias + " foi salva com sucesso!";
                Page.DisplayAlert("Salvar refeição", msg, "Ok");
            });
        }
        
        private void OnPropertyChanged(string nome)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(nome));
        }
        
    }
}
