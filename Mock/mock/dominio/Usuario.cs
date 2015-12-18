using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mock.dominio
{
    public class Usuario
    {
        public int id { get; private set; }
        public string nome {get ; private set; }

        public Usuario(string nome)
        {
            this.id = 0;
            this.nome = nome;
        }

        public Usuario(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            Usuario usuario = (Usuario) obj;
            if (this.id == usuario.id && this.nome == usuario.nome)
            {
                return true;
            }

            return false;
        }

        // criar getters
    }
}
