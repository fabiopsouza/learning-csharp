using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Iss : Imposto
    {
        public Iss(Imposto outroImposto) : base(outroImposto) { }

        public Iss() : base() { }

        public override double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.6 + CalculoDoOutroImposto(orcamento);
        }
    }
}
