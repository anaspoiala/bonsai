using System;
using System.Collections.Generic;
using System.Text;
using Bonsai.Domain;
using Bonsai.Persistence;
using Bonsai.Service;
using FluentAssertions;
using Moq;
using NUnit.Framework;


namespace Test.Bonsai
{
    [TestFixture]
    class AccountServiceTest
    {



        [Test]
        public void CreateAccount_ShouldValidate()
        {
            // arrage
            var accountRepository = new Mock<IAccountRepository>();
            var accountService = new AccountService(accountRepository.Object);

            //act
            var action = new Action(() => accountService.CreateAccount(new UserAccount()));

            //assert
            action.Should().Throw<InvalidOperationException>();

        }


        [Test]
        public void CreateAccount_DoesNotAcceptDuplicateAccount()
        {
            // arrage
            var mock = new Mock<IAccountRepository>();
            mock.Setup(repo => repo.GetAccountByUsername("john")).Returns(new UserAccount { Username = "john" });
            var accountService = new AccountService(mock.Object);

            //act
            var action = new Action(() => accountService.CreateAccount(new UserAccount { Username = "john" }));

            //assert
            action.Should().Throw<InvalidOperationException>("because service should check if users exists");

        }

        [Test]
        public void CreateAccount_CallsPasswordCheckFromRepo()
        {
            // arrage
            var mock = new Mock<IAccountRepository>();
            var accountService = new AccountService(mock.Object);

            //act
            accountService.CheckPassword(1, "123456");

            //assert
            mock.Verify(repo => repo.CheckAccountPassword(1, "123456"));

        }
    }
}
