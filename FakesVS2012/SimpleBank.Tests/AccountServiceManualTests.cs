using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleBank.Domain;
using SimpleBank.Repository.Fakes;

namespace SimpleBank.Tests
{
    public class AccountServiceManualTests
    {
        public void TestMakeTransfer(Account creditAccount, Account debitAccount, decimal amount)
        {

            StubIAccountRepository accountRepository = new StubIAccountRepository();
            StubIOperationRepository operationRepository = new StubIOperationRepository();
            AccountService service = new AccountService(accountRepository, operationRepository);
            service.MakeTransfer(creditAccount, debitAccount, amount);
           
        }

        public decimal ComputeInterest(Account account, double annualRate, int months)
        {

            StubIAccountRepository accountRepository = new StubIAccountRepository();
            StubIOperationRepository operationRepository = new StubIOperationRepository();

            AccountService service = new AccountService(accountRepository, operationRepository);

            decimal result = service.ComputeInterest(account, annualRate, months);

            return result;
        }

        public List<Operation> GetOperationsForAccount(int accountID)
        {
            
            List<Operation> operations1 = new List<Operation>();
            operations1.Add(new Operation { Amount = 100, Direction = Domain.Direction.Credit });
            operations1.Add(new Operation { Amount = 200, Direction = Domain.Direction.Debit });


            List<Account> accounts = new List<Account>();
            accounts.Add(new Account { Balance = 300, Operations = operations1, AutorizeOverdraft = true, Id = 1 });
            accounts.Add(new Account { Balance = 0, Operations = null, AutorizeOverdraft = false, Id = 2 });

            StubIAccountRepository accountRepository = new StubIAccountRepository();
            accountRepository.GetAccountInt32 = (x) =>
            {
                return accounts.SingleOrDefault(a => a.Id == x);
            };

            StubIOperationRepository operationRepository = new StubIOperationRepository();
            AccountService service = new AccountService(accountRepository, operationRepository);

            List<Operation> result = service.GetOperationsForAccount(accountID);
            return result;            
        }
    }
}
