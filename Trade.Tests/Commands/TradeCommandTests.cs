using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trade.Domain.Entities;
using Trade.Domain.Commands;
using Trade.Domain.Enums;

namespace Trade.Tests.Commands
{
    [TestClass]
    public class TradeCommandTests
    {
        private static Customer _customer = new Customer("Bruce Wayne", 1500000.00m, ESector.Public);
        private TradeCommand _tradeCommand = new TradeCommand(_customer);

        [TestMethod]
        [TestCategory("Domain.Commands")]
        public void Dado_um_novo_parametro_customer_todas_as_validacoes_devem_passar()
        {
            _tradeCommand.Validate();
            Assert.AreEqual(true, _customer.Valid);
        }
    }
}