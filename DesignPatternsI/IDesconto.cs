namespace DesignPatterns
{
    public interface IDesconto
    {
        IDesconto Proximo { get; set; }

        double Descontar(Orcamento orcamento);
    }
}