using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class NotaFiscal
    {
        public string RazaoSocial { get; set; }

        public string Cnpj { get; set; }

        public DateTime DataDeEmissao { get; set; }

        public double ValorBruto { get; set; }

        public double Impostos { get; set; }

        public IList<ItemDaNota> Itens { get; set; }

        public string Observacoes { get; set; }

        public NotaFiscal(string razaoSocial, string cnpj, DateTime dataDeEmissão, double valorBruto, 
            double impostos, IList<ItemDaNota> Itens, string observacoes)
        {
            this.RazaoSocial = razaoSocial;
            this.Cnpj = cnpj;
            this.DataDeEmissao = dataDeEmissão;
            this.ValorBruto = valorBruto;
            this.Impostos = impostos;
            this.Itens = Itens;
            this.Observacoes = observacoes;
        }
    }
}
