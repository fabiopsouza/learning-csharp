using System;
using System.Collections.Generic;
using mock.dominio;
using mock.infra;
using NUnit.Framework;

namespace mock.servico
{
    public class GeradorDePagamento
    {
        private LeilaoDaoFalso leilaoDao;
        private Avaliador avaliador;
        private PagamentoDao pagamentoDao;
        private IRelogio relogio;

        public GeradorDePagamento(LeilaoDaoFalso leilaoDao, Avaliador avaliador, PagamentoDao pagamentoDao)
        {
            this.leilaoDao = leilaoDao;
            this.avaliador = avaliador;
            this.pagamentoDao = pagamentoDao;
        }

        public GeradorDePagamento(LeilaoDaoFalso leilaoDao, Avaliador avaliador, PagamentoDao pagamentoDao, IRelogio relogio)
        {
            this.leilaoDao = leilaoDao;
            this.avaliador = avaliador;
            this.pagamentoDao = pagamentoDao;
            this.relogio = relogio;
        }

        public void Gerar()
        {
            List<Leilao> encerrados = leilaoDao.encerrados();

            foreach (var l in encerrados)
            {
                avaliador.avalia(l);
                Pagamento pagamento = new Pagamento(avaliador.maiorValor, ProximoDiaUtil());
                this.pagamentoDao.Salvar(pagamento);
            }
        }

        private DateTime ProximoDiaUtil()
        {
            DateTime data = relogio.hoje();
            DayOfWeek diaDaSemana = data.DayOfWeek;

            if (diaDaSemana == DayOfWeek.Saturday)
                data = data.AddDays(2);
            else if (diaDaSemana == DayOfWeek.Monday)
                data = data.AddDays(1);

            return data;
        }
    }
}
