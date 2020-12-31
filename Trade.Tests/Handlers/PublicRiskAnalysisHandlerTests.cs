using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trade.Domain.Commands;
using Trade.Domain.Handlers;
using Trade.Domain.Enums;

namespace Trade.Tests.Handlers
{
    [TestClass]
    public class PublicRiskAnalysisHandlerTests
    {
        private static RiskAnalysisCommand _command = new RiskAnalysisCommand(200000m);
        private PublicRiskAnalysisHandler _privateRiskAnalysis = new PublicRiskAnalysisHandler();
        private GenericCommandResult _commandResult = new GenericCommandResult();

        [TestMethod]
        [TestCategory("Domain.Handlers")]
        public void Dado_um_valor_abaixo_de_1k_deve_retornar_LOWRISK()
        {
            _commandResult = (GenericCommandResult)_privateRiskAnalysis.Handle(_command);
            Assert.AreEqual(_commandResult.Data.ToString(), ERisk.LOWRISK.ToString());
        }

        [TestMethod]
        [TestCategory("Domain.Handlers")]
        public void Dado_um_valor_acima_de_1k_deve_retornar_MEDIURISK()
        {
            _command.Value = 1500000m;
            _commandResult = (GenericCommandResult)_privateRiskAnalysis.Handle(_command);
            Assert.AreEqual(_commandResult.Data.ToString(), ERisk.MEDIUMRISK.ToString());
        }


    }
}