using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mock.dominio
{
    public class Pagamento
    {
        public double valor { get; private set; }
        public DateTime data { get; private set; }

        public Pagamento(double valor, DateTime data)
        {
            this.valor = valor;
            this.data = data;
        }
    }
}
