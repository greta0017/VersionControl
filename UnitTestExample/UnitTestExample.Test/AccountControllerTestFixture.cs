using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {

        [Test]
        [TestCase("asdfgh", false)]
        [TestCase("asdfgh@gmail", false)]
        [TestCase("asdfghgmail.com", false)]
        [TestCase("asdfgh@gmail.com", true)]


        public void TestValidateEmail(string email, bool expectedResult)
        {
            var accountC = new AccountController(); //email validálás rész
            var actualR = accountC.ValidateEmail(email); 
            Assert.AreEqual(expectedResult,actualR);
        }

        [TestCase("asdfgh", false)]//fv felé rakni a teszteseteket, arra fog vonatkozni
        [TestCase("ASDFGHJ", false)]
        [TestCase("asdfghs", false)]
        [TestCase("asd", false)]
        [TestCase("asdfghASD20", true)]

        public void TestValidatePassword(string password, bool expectedResult)
        {
            var accountC = new AccountController();
            var actualR = accountC.ValidatePassword(password);
            Assert.AreEqual(expectedResult, actualR);
        }
    }
}
