namespace DesignPatterns
{
    public abstract class Imposto
    {
        public Imposto OutroImposto { get; set; }

        //Construtor 1
        public Imposto(Imposto outroImposto)
        {
            this.OutroImposto = outroImposto;
        }

        //Construtor 2 - Nulo com o polimorfismo
        public Imposto()
        {
            this.OutroImposto = null;
        }

        public abstract double Calcular(Orcamento orcamento);

        protected double CalculoDoOutroImposto(Orcamento orcamento)
        {
            if (OutroImposto == null)
                return 0;

            return OutroImposto.Calcular(orcamento);
        }
    }
}