using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleBank.Domain;
using SimpleBank.Repository.Moles;

namespace SimpleBank.Tests
{
    [TestClass]
    public class AccountServiceManualTest
    {
        private List<Account> _accounts = new List<Account>();

        [TestInitialize]
        public void setUp()
        {
            List<Operation> operations1 = new List<Operation>();
            operations1.Add(new Operation { Amount = 100, Direction = Direction.Credit });
            operations1.Add(new Operation { Amount = 200, Direction = Direction.Debit });

            List<Operation> operations2 = new List<Operation>();
            operations2.Add(new Operation { Amount = 100, Direction = Direction.Credit });
            
            _accounts.Add(new Account { Balance = 300, Operations = operations1, AutorizeOverdraft = true, Id = 1 });
            _accounts.Add(new Account { Balance = 0, Operations = operations2, AutorizeOverdraft = false, Id = 2 });
        }

        [TestMethod]
        public void TestMakeTransfer_debit()
        {
            var operationsList = new List<Operation>();

            SIOperationRepository opRepository = new SIOperationRepository();
            opRepository.CreateOperationOperation = (x) =>
            {
                operationsList.Add(x);
            };

            SIAccountRepository acRepository = new SIAccountRepository();
            acRepository.UpdateAccountAccount = (x) =>
            {
                var acc1 = _accounts.SingleOrDefault(y => y.Id == x.Id);
                acc1.Operations = x.Operations;
            };

            AccountService service = new AccountService(acRepository, opRepository);
            service.MakeTransfer(_accounts[1], _accounts[0], 200);
            Assert.AreEqual(_accounts[1].Balance, 200);
            Assert.AreEqual(_accounts[0].Balance, 100);
            Assert.AreEqual(operationsList.Count, 2);
            Assert.AreEqual(_accounts[1].Operations.Count, 2);
            Assert.AreEqual(_accounts[0].Operations.Count, 3);
        }

        [TestMethod]
        public void ComputeInterest()
        {
            AccountService service = new AccountService(null, null);

            decimal result = service.ComputeInterest(new Account { Balance = 120 }, 0.1, 20);

            Assert.AreEqual(result, 20);
        }

        [TestMethod]
        public void GetOperationsForAccount_AccountFound()
        {
            SIAccountRepository accountRepository = new SIAccountRepository();
            accountRepository.GetAccountInt32 = (x) =>
            {
                return _accounts.SingleOrDefault(a => a.Id == x);
            };

            SIOperationRepository operationRepository = new SIOperationRepository();
            AccountService service = new AccountService(accountRepository, operationRepository);

            List<Operation> result = service.GetOperationsForAccount(1);
            Assert.AreEqual(result.Count, 2);
        }
    }
    
}
