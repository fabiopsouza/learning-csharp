using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Aprovado : IEstadoDeUmOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            orcamento.Valor -= (orcamento.Valor*0.02);
        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orcamento já está em estado de aprovação");
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento já está aprovado, não pode ser reprovado agora");
        }

        public void Finaliza(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Reprovado();
        }
    }
}
