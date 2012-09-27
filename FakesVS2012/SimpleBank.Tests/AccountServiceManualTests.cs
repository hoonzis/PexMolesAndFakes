using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleBank.Domain;
using SimpleBank.Repository.Fakes;

namespace SimpleBank.Tests
{
    [TestClass]
    public class AccountServiceManualTests
    {
        private List<Account> _accounts = new List<Account>();

        [TestInitialize]
        public void setUp()
        {
            List<Operation> operations1 = new List<Operation>();
            operations1.Add(new Operation { Amount = 100, Direction = Domain.Direction.Credit });
            operations1.Add(new Operation { Amount = 200, Direction = Domain.Direction.Debit });


            
            _accounts.Add(new Account { Balance = 300, Operations = operations1, AutorizeOverdraft = true, Id = 1 });
            _accounts.Add(new Account { Balance = 0, Operations = null, AutorizeOverdraft = false, Id = 2 });
        }

        [TestMethod]
        public void TestMakeTransfer_debit()
        {
            AccountService service = new AccountService(null, null);
            service.MakeTransfer(_accounts[0], _accounts[1], 200);
        }

        [TestMethod]
        public void ComputeInterest()
        {

            //StubIAccountRepository accountRepository = new StubIAccountRepository();
            //StubIOperationRepository operationRepository = new StubIOperationRepository();

            AccountService service = new AccountService(null, null);

            decimal result = service.ComputeInterest(new Account { Balance = 350 }, 0.1, 20);

            Assert.AreEqual(result, 123);
        }

        [TestMethod]
        public void GetOperationsForAccount_AccountFound()
        {
            StubIAccountRepository accountRepository = new StubIAccountRepository();
            accountRepository.GetAccountInt32 = (x) =>
            {
                return _accounts.SingleOrDefault(a => a.Id == x);
            };

            StubIOperationRepository operationRepository = new StubIOperationRepository();
            AccountService service = new AccountService(accountRepository, operationRepository);

            List<Operation> result = service.GetOperationsForAccount(1);
            Assert.AreEqual(result.Count, 2);
        }
    }
}
