using System;
using System.Collections.Generic;
using mock.dominio;
using mock.infra;
using mock.servico;
using Moq;
using NUnit.Framework;

namespace mock.testes
{
    [TestFixture]
    public class GeradorDePagamentoTest
    {
        [Test]
        public void DeveGerarPagamentoParaLeilaoEncerrado()
        {
            var leilaoDao = new Mock<LeilaoDaoFalso>();
            var avaliador = new Mock<Avaliador>();
            var pagamentoDao = new Mock<PagamentoDao>();

            Leilao leilao1 = new Leilao("Playstation");
            leilao1.naData(new DateTime(1995, 5, 5));

            leilao1.propoe(new Lance(new Usuario("Renan"), 500));
            leilao1.propoe(new Lance(new Usuario("Felipe"), 600));

            List<Leilao> listaDeLeiloes = new List<Leilao>();
            listaDeLeiloes.Add(leilao1);
            leilaoDao.Setup(l => l.encerrados()).Returns(listaDeLeiloes);

            avaliador.Setup(a => a.maiorValor).Returns(600); //Mock de uma propriedade

            //Pegar um objeto chamado dentro da classe que esta sendo testada, para avalia-lo
            Pagamento pagamentoCapturado = null;
            pagamentoDao.Setup(p => p.Salvar(It.IsAny<Pagamento>())).Callback<Pagamento>(r => pagamentoCapturado = r);

            GeradorDePagamento gerador = new GeradorDePagamento(leilaoDao.Object, avaliador.Object, pagamentoDao.Object);
            gerador.Gerar();

            Assert.AreEqual(600, pagamentoCapturado.valor);
        }

        [Test]
        public void DeveJogarParaOProximoDiaUtil()
        {
            var leilaoDao = new Mock<LeilaoDaoFalso>();
            var pagamentoDao = new Mock<PagamentoDao>();
            var relogio = new Mock<IRelogio>();

            Leilao leilao1 = new Leilao("Playstation");
            leilao1.naData(new DateTime(1995, 5, 5));

            leilao1.propoe(new Lance(new Usuario("Renan"), 500));
            leilao1.propoe(new Lance(new Usuario("Felipe"), 600));

            List<Leilao> listaDeLeiloes = new List<Leilao>();
            listaDeLeiloes.Add(leilao1);
            leilaoDao.Setup(l => l.encerrados()).Returns(listaDeLeiloes);

            relogio.Setup(r => r.hoje()).Returns(new DateTime(2012, 4, 7));

            Pagamento pagamentoCapturado = null;
            pagamentoDao.Setup(p => p.Salvar(It.IsAny<Pagamento>())).Callback<Pagamento>(r => pagamentoCapturado = r);

            GeradorDePagamento gerador = new GeradorDePagamento(leilaoDao.Object, new Avaliador(), pagamentoDao.Object, relogio.Object);
            gerador.Gerar();

            Assert.AreEqual(DayOfWeek.Monday, pagamentoCapturado.data.DayOfWeek);
        }
    }
}