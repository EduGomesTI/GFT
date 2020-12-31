using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trade.Domain.Commands;
using Trade.Domain.Handlers;
using Trade.Domain.Enums;

namespace Trade.Tests.Handlers
{
    [TestClass]
    public class PrivateRiskAnalysisHandlerTests
    {
        private static RiskAnalysisCommand _command = new RiskAnalysisCommand(2000000m);
        private PrivateRiskAnalysisHandler _privateRiskAnalysis = new PrivateRiskAnalysisHandler();
        private GenericCommandResult _commandResult = new GenericCommandResult();
       
        [TestMethod]
        [TestCategory("Domain.Handlers")]
        public void Dado_um_valor_acima_de_1k_deve_retornar_HIGHRISK()
        {
            _commandResult = (GenericCommandResult)_privateRiskAnalysis.Handle(_command);
            Assert.AreEqual(_commandResult.Data.ToString(), ERisk.HIGHRISK.ToString());
        }

        [TestMethod]
        [TestCategory("Domain.Handlers")]
        public void Dado_um_valor_abaixo_de_1k_deve_retornar_mensagem_de_alerta()
        {
            _command.Value = 500000m;
            _commandResult = (GenericCommandResult)_privateRiskAnalysis.Handle(_command);
            Assert.AreEqual("Risk analysis out of range.", _commandResult.Data.ToString());
        }
    }
}