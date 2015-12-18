using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    public class LeilaoTest
    {
        [Test]
        public void DeveReceberUmLance()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            Assert.AreEqual(0, leilao.Lances.Count);

            var usuario = new Usuario("Steve Jobs");

            leilao.Propoe(new Lance(usuario, 2000));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.0001);

        }

        [Test]
        public void DeveReceberVariosLances()
        {
            Leilao leilao = new Leilao("Macbook Pro 15");
            leilao.Propoe(new Lance(new Usuario("Steve Jobs"), 2000));
            leilao.Propoe(new Lance(new Usuario("Steve Wozniak"), 3000));

            Assert.AreEqual(2, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.0001);
            Assert.AreEqual(3000, leilao.Lances[1].Valor, 0.0001);
        }

        [Test]
        public void NaoDeveAceitarDoisLancesSeguidosDoMesmoUsuario()
        {
            Leilao leilao = new Leilao("Mackbook Pro 15");
            var steveJobs = new Usuario("Steve Jobs");

            leilao.Propoe(new Lance(steveJobs, 2000));
            leilao.Propoe(new Lance(steveJobs, 3000));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.0001);
        }

        [Test]
        public void NaoDeveAceitarMaisDoQueCincoLancesDoMesmoUsuario()
        {
            Leilao leilao = new Leilao("Mackbook Pro 15");
            var steveJobs = new Usuario("Steve Jobs");
            var billGates = new Usuario("Bill Gates");

            leilao.Propoe(new Lance(steveJobs, 2000));
            leilao.Propoe(new Lance(billGates, 3000));

            leilao.Propoe(new Lance(steveJobs, 4000));
            leilao.Propoe(new Lance(billGates, 5000));

            leilao.Propoe(new Lance(steveJobs, 6000));
            leilao.Propoe(new Lance(billGates, 7000));

            leilao.Propoe(new Lance(steveJobs, 8000));
            leilao.Propoe(new Lance(billGates, 9000));

            leilao.Propoe(new Lance(steveJobs, 10000));
            leilao.Propoe(new Lance(billGates, 11000));

            //Deve ser ignorado
            leilao.Propoe(new Lance(steveJobs, 12000));

            Assert.AreEqual(10, leilao.Lances.Count);
            var ultimo = leilao.Lances.Count - 1;
            Lance ultimoLance = leilao.Lances[ultimo];
            Assert.AreEqual(ultimoLance.Valor, 11000);
        }
    }
}
