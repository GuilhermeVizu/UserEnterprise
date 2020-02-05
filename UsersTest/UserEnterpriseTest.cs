using Microsoft.VisualStudio.TestTools.UnitTesting;
using CadastroUsuario.Models;
using System;

namespace UsersTest
{
    [TestClass]
    public class UserEnterpriseTest
    {
        [TestMethod]
        public void ValidUser()
        {
            UserEnterprise userEnterprise = new UserEnterprise
            {
                FirstName = "Guilherme",
                LastName = "Correia",
                UserName = "GuilhermeCorreia",
                Email = "guilherme.correia@hotmail.com",
                Gender = "M",
                BirthDate = new DateTime(1993, 10, 30)
            };
            
            bool expected = true;

            CadastroUsuario.Controllers.UserEnterprisesController controller = new CadastroUsuario.Controllers.UserEnterprisesController(null);
            // Act
            controller.UserValidate(userEnterprise);

            // Assert
            Assert.AreEqual(expected, controller.valid, "", "Account not debited correctly");
        }
    }
}
