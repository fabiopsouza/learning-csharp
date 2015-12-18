using System;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    public class AvaliadorTest
    {
        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario jose;
        private Usuario maria;

        [SetUp] //Setup -> Executa esse método antes de todos os métodos de teste
        public void AvaliadorTestSetup()
        {
            leiloeiro = new Avaliador();

            joao = new Usuario("Joao");
            jose = new Usuario("José");
            maria = new Usuario("Maria");
        }

        [Test]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            Leilao leilao = new CriadorDeLeilao()
                .Para("Playstation 3")
                .Lance(maria, 250.0)
                .Lance(joao, 300.0)
                .Lance(jose, 400.0)
                .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(leiloeiro.MaiorLance, 400);
            Assert.AreEqual(leiloeiro.MenorLance, 250);
        }

        [Test]
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Leilao leilao = new CriadorDeLeilao()
                .Para("Playstation 3")
                .Lance(joao, 1000)
                .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(leiloeiro.MaiorLance, 1000, 0.0001);
            Assert.AreEqual(leiloeiro.MenorLance, 1000, 0.0001);
        }

        [Test]
        public void DeveEncontrarOsTresMaiores()
        {
            Leilao leilao = new CriadorDeLeilao()
                .Para("Playstation 3")
                .Lance(joao, 100)
                .Lance(maria, 200)
                .Lance(jose, 300)
                .Lance(maria, 400)
                .Constroi();

            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor, 0.0001);
            Assert.AreEqual(300, maiores[1].Valor, 0.0001);
            Assert.AreEqual(200, maiores[2].Valor, 0.0001);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void NaoDeveAvaliarLeiloesSemNenhumLanceDado()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation").Constroi();
            leiloeiro.Avalia(leilao);
        }
    }
}
