using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mock.dominio
{
    public class Lance
    {
        public Usuario usuario {get ; private set; }
        public double valor {get; private set;}
        public int id {get; private set;}


        public Lance(Usuario usuario, double valor)
        {
            this.usuario = usuario;
            this.valor = valor;
        }

        
    }
}
