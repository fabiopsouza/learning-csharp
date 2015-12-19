using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Icms : Imposto
    {
        public Icms(Imposto outroImposto) : base(outroImposto) {  }

        public Icms() : base() { }

        public override double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1;
        }
    }
}
