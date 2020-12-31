using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trade.Domain.Commands;
using Trade.Domain.Commands.Interfaces;

namespace Trade.Tests.Commands
{
    [TestClass]
    public class RiskAnalysisCommandTests
    {
        private RiskAnalysisCommand _riskAnalysisCommnad = new RiskAnalysisCommand(-500);

        [TestMethod]
        [TestCategory("Domain.Commands")]
        public void Dado_valor_igual_ou_abaixo_de_0_Validate_deve_falhar()
        {
            _riskAnalysisCommnad.Validate();
            Assert.AreEqual(false, _riskAnalysisCommnad.Valid);
        }

        [TestMethod]
        [TestCategory("Domain.Commands")]
        public void Dado_valor_acima_de_0_Validate_deve_passar()
        {
            _riskAnalysisCommnad.Value = 500;
            _riskAnalysisCommnad.Validate();
            Assert.AreEqual(true, _riskAnalysisCommnad.Valid);
        }
    }
}