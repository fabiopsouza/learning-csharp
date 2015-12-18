using mock.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mock.infra
{
    public class LeilaoDaoFalso
    {
        private static List<Leilao> leiloes = new List<Leilao>();
        
        public void salva(Leilao leilao)
        {
            leiloes.Add(leilao);
        }

        public virtual List<Leilao> encerrados()
        {
            List<Leilao> filtrados = new List<Leilao>();
            foreach (var l in leiloes)
            {
                if (l.encerrado) filtrados.Add(l);
            }

            return filtrados;
        }

        public virtual List<Leilao> correntes()
        {
            List<Leilao> correntes = new List<Leilao>();
            foreach (var l in leiloes)
            {
                if (!l.encerrado) correntes.Add(l);
            }

            return correntes;
        }

        public virtual void atualiza(Leilao leilao) { }

    }
}
