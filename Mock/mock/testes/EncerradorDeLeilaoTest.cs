using System;
using System.Collections.Generic;
using mock.dominio;
using mock.infra;
using mock.servico;
using NUnit.Framework;
using Moq;

namespace mock.testes
{
    [TestFixture]
    public class EncerradorDeLeilaoTest
    {
        [Test]
        public void DeveEncerrarLeiloesQueComecaramAUmaSemana()
        {
            DateTime diaDaSemanaPassada = new DateTime(199, 5, 5);

            Leilao leilao1 = new Leilao("TV de Plasma");
            leilao1.naData(diaDaSemanaPassada);

            Leilao leilao2 = new Leilao("Playstation");
            leilao2.naData(diaDaSemanaPassada);

            List<Leilao> listaDeLeiloes = new List<Leilao>();
            listaDeLeiloes.Add(leilao1);
            listaDeLeiloes.Add(leilao2);

            var dao = new Mock<LeilaoDaoFalso>();
            dao.Setup(d => d.correntes()).Returns(listaDeLeiloes);

            EncerradorDeLeilao encerrador = new EncerradorDeLeilao(dao.Object, new Carteiro());
            encerrador.encerra();

            Assert.AreEqual(2, encerrador.total);
            Assert.IsTrue(leilao1.encerrado);
            Assert.IsTrue(leilao2.encerrado);
        }

        [Test]
        public void DeveEncerrarOsLeiloesESalvarNoDao()
        {
            DateTime diaDaSemanaPassada = new DateTime(199, 5, 5);

            Leilao leilao1 = new Leilao("TV de Plasma");
            leilao1.naData(diaDaSemanaPassada);

            Leilao leilao2 = new Leilao("Playstation");
            leilao2.naData(diaDaSemanaPassada);

            List<Leilao> listaDeLeiloes = new List<Leilao>();
            listaDeLeiloes.Add(leilao1);
            listaDeLeiloes.Add(leilao2);

            var dao = new Mock<LeilaoDaoFalso>();
            dao.Setup(d => d.correntes()).Returns(listaDeLeiloes);

            EncerradorDeLeilao encerrador = new EncerradorDeLeilao(dao.Object, new Carteiro());
            encerrador.encerra();

            dao.Verify(d => d.atualiza(leilao1), Times.Once); //Verifica se o método atualiza foi chamado (Times.Once -> apenas uma vez)
            dao.Verify(d => d.atualiza(leilao2));
        }

        [Test]
        public void DeveContinuarMesmoQuandoLancaExcessao()
        {
            DateTime diaDaSemanaPassada = new DateTime(199, 5, 5);

            Leilao leilao1 = new Leilao("TV de Plasma");
            leilao1.naData(diaDaSemanaPassada);

            Leilao leilao2 = new Leilao("Playstation");
            leilao2.naData(diaDaSemanaPassada);

            List<Leilao> listaDeLeiloes = new List<Leilao>();
            listaDeLeiloes.Add(leilao1);
            listaDeLeiloes.Add(leilao2);

            var dao = new Mock<LeilaoDaoFalso>();
            dao.Setup(d => d.correntes()).Returns(listaDeLeiloes);
            dao.Setup(d => d.atualiza(leilao1)).Throws(new Exception()); //Simula o lançamento de uma exceção ao chamar atualiza com leilao1

            var carteiro = new Mock<Carteiro>();

            EncerradorDeLeilao encerrador = new EncerradorDeLeilao(dao.Object, carteiro.Object);
            encerrador.encerra();

            dao.Verify(d => d.atualiza(leilao2), Times.Once);
            carteiro.Verify(d => d.Envia(leilao2), Times.Once);
        }
    }
}