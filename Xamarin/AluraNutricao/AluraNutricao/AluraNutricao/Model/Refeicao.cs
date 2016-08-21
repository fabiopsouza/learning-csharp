using SQLite.Net.Attributes;

namespace AluraNutricao
{
    public class Refeicao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Calorias { get; set; }

        public Refeicao()
        {

        }

        public Refeicao(string descricao, double calorias)
        {
            Descricao = descricao;
            Calorias = calorias;
        }
    }
}
