using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trade.Domain.Entities;
using Trade.Domain.Enums;

namespace Trade.Tests.Entities
{
    [TestClass]
    public class CustomerTests
    {
        private Customer _customer = new Customer("Bruce Wayne", 1200000.00m, ESector.Public);

        [TestMethod]
        [TestCategory("Domain.Entities")]
        public void Dado_um_novo_Customer_deve_gerar_um_Id_com_8_carcteres()
        {
            //* O Id é gerado através da clase abstrata Entity.cs
            //* Toda vez que seu construtor é chamado é criado um GUid
            //* E os seus 8 primeiros dígitos formam o Id. 
            Assert.AreEqual(8, _customer.Id.Length);
        }

        [TestMethod]
        [TestCategory("Domain.Entities")]
        public void Dado_um_nome_deve_falhar_se_houver_menos_que_3_caracteres()
        {
            _customer.ChangeName("Ed");
            var nameFail = true;
            if (_customer.Name.Length < 3)
            nameFail = false;
            Assert.AreEqual(false, nameFail);

        }

        [TestMethod]
        [TestCategory("Domain.Entities")]
        public void Dado_um_nome_deve_falhar_se_houver_mais_que_20_caracteres()
        {
            _customer.ChangeName("Bruce Wyane Or Batman");
            var nameFail = true;
            if (_customer.Name.Length > 20)
            nameFail = false;
            Assert.AreEqual(false, nameFail);
        }

        [TestMethod]
        [TestCategory("Domain.Entities")]
        public void Dado_um_nome_deve_Passar_se_houver_entre_3_e_20_caracteres()
        {
            var namePass = false;
            if (_customer.Name.Length > 3 && _customer.Name.Length < 20)
            namePass = true;
            Assert.AreEqual(true, namePass);
        }

        [TestMethod]
        [TestCategory("Domain.Entities")]
        public void Dado_um_novo_Customer_seu_TradeAmount_deve_ser_maior_que_0()
        {
            var amount = false;
            if (_customer.TradeAmount > 0)
                amount = true;
            Assert.AreEqual(true, amount);
        }
    }
}