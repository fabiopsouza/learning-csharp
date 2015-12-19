using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NotaFiscalBuilder nfb = new NotaFiscalBuilder();

                nfb.ParaEmpresa("Caelum Ensino e Inovação")
                   .ComCnpj("12342.2333/333-333")
                   .ComItem(new ItemDaNota("item 1", 100.0))
                   .ComItem(new ItemDaNota("item 2", 200.0))
                   .NaDataAtual()
                   .ComObservacoes("Uma observação qualquer");

                nfb.AdicionaAcao(new EnviadorDeEmail());
                nfb.AdicionaAcao(new NotaFiscalDao());
                nfb.AdicionaAcao(new EnviadorDeSms());

                NotaFiscal nf = nfb.Constroi();

                Console.WriteLine("Valor total = " + nf.ValorBruto);
                Console.WriteLine("Impostos = " + nf.Impostos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
