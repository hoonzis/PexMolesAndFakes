// <copyright file="AccountServiceTest.cs">Copyright ©  2011</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleBank;
using Microsoft.Pex.Framework.Generated;
using SimpleBank.Domain;
using SimpleBank.Repository;
using System.Collections.Generic;
using Microsoft.Pex.Framework.Moles;
using System.Linq;

namespace SimpleBank
{
    [PexClass(typeof(AccountService))]
    [TestClass]
    public partial class AccountServiceTest
    {

        [PexMethod, PexAllowedException(typeof(AccountServiceException))]
        public void MakeTransfer(Account creditAccount,Account debitAccount,decimal amount)
        {
            /*
            SIAccountRepository accountRepository = new SIAccountRepository();
            SIOperationRepository operationRepository = new SIOperationRepository();
            AccountService service = new AccountService(accountRepository, operationRepository);
            service.MakeTransfer(creditAccount, debitAccount, amount);
             * */
        }

        [PexMethod, PexAllowedException(typeof(AccountServiceException))]
        public decimal ComputeInterest(Account account,double annualRate,int months)
        {
            
            /*
            PexAssume.Implies(account != null, () => account.Balance = 1000);
            PexAssume.IsTrue(annualRate != 0);
            PexAssume.IsTrue(months != 0);

            SIAccountRepository accountRepository = new SIAccountRepository();
            SIOperationRepository operationRepository = new SIOperationRepository();

            AccountService service = new AccountService(accountRepository, operationRepository);

            decimal result = service.ComputeInterest(account, annualRate, months);

            return result;*/
            return 0;
        }

        [PexMethod]
        public List<Operation> GetOperationsForAccount(int accountID)
        {
            /*
            List<Operation> operations1 = new List<Operation>();
            operations1.Add(new Operation { Amount = 100, Direction = Domain.Direction.Credit });
            operations1.Add(new Operation { Amount = 200, Direction = Domain.Direction.Debit });


            List<Account> accounts = new List<Account>();
            accounts.Add(new Account { Balance = 300, Operations = operations1, AutorizeOverdraft = true, Id = 1 });
            accounts.Add(new Account { Balance = 0, Operations = null, AutorizeOverdraft = false, Id = 2 });

            SIAccountRepository accountRepository = new SIAccountRepository();
            accountRepository.GetAccountInt32 = (x) =>
            {
                return accounts.SingleOrDefault(a => a.Id == x);
            };

            SIOperationRepository operationRepository = new SIOperationRepository();
            AccountService service = new AccountService(accountRepository, operationRepository);

            List<Operation> result = service.GetOperationsForAccount(accountID);
            return result;
             * */
            return null;
        }
    }
}
