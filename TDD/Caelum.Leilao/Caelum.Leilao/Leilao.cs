using System.Collections.Generic;
namespace Caelum.Leilao
{

    public class Leilao
    {

        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {
            if(Lances.Count == 0 || PodeDarLance(lance.Usuario))
                Lances.Add(lance);
        }

        public Lance UltimoLanceDado()
        {
            return Lances[Lances.Count - 1];
        }

        private bool PodeDarLance(Usuario usuario)
        {
            return !UltimoLanceDado().Usuario.Equals(usuario) && qtdDeLancesDo(usuario) < 5;
        }

        private int qtdDeLancesDo(Usuario usuario)
        {
            int total = 0;
            foreach (var l in Lances)
            {
                if (l.Usuario.Equals(usuario)) total++;
            }
            return total;
        }
    }
}