using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trade.Domain.Commands;
using Trade.Domain.Handlers;
using Trade.Domain.Enums;
using Trade.Domain.Entities;

namespace Trade.Tests.Handlers
{
    [TestClass]
    public class TradeHandlerTests
    {
        private Customer _customer;
        private TradeCommand _tradeCommand;
        private TradeHandler _tradeHandler = new TradeHandler();
        private GenericCommandResult _commandResult = new GenericCommandResult();

        [TestMethod]
        [TestCategory("Domain.Handlers")]
        public void Dado_um_Sector_Public_e_Value_abaixo_de_1k_deve_retornar_LOWRISK()
        {
            _customer = new Customer("Bruce Wayne", 50000m, ESector.Public);
            _tradeCommand = new TradeCommand(_customer);
            _commandResult = (GenericCommandResult)_tradeHandler.Handle(_tradeCommand);

            Assert.AreEqual(ERisk.LOWRISK.ToString(), _commandResult.Data.ToString());
        }

        [TestMethod]
        [TestCategory("Domain.Handlers")]
        public void Dado_um_Sector_Public_e_Value_acima_de_1k_deve_retornar_MEDIUMRISK()
        {
            _customer = new Customer("Bruce Wayne", 1500000m, ESector.Public);
            _tradeCommand = new TradeCommand(_customer);
            _commandResult = (GenericCommandResult)_tradeHandler.Handle(_tradeCommand);

            Assert.AreEqual(ERisk.MEDIUMRISK.ToString(), _commandResult.Data.ToString());
        }

        [TestMethod]
        [TestCategory("Domain.Handlers")]
        public void Dado_um_Sector_Private_e_Value_acima_de_1k_deve_retornar_HIGHRISK()
        {
            _customer = new Customer("Marvel", 5500000m, ESector.Private);
            _tradeCommand = new TradeCommand(_customer);
            _commandResult = (GenericCommandResult)_tradeHandler.Handle(_tradeCommand);

            Assert.AreEqual(ERisk.HIGHRISK.ToString(), _commandResult.Data.ToString());
        }
    }
}