using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SimpleBank.Repository;
using SimpleBank.Domain;

namespace SimpleBank
{
    public class AccountService
    {
        private IAccountRepository _accountRepository;
        private IOperationRepository _operationRepository;

        public AccountService(IAccountRepository accountRepository, IOperationRepository operationRepository)
        {
            _accountRepository = accountRepository;
            _operationRepository = operationRepository;
        }

        public void MakeTransfer(Account creditAccount, Account debitAccount, decimal amount)
        {
            if (creditAccount == null)
            {
                throw new AccountServiceException("creditAccount null");
            }

            if (debitAccount == null)
            {
                throw new AccountServiceException("debitAccount null");
            }

            if (debitAccount.Balance < amount && debitAccount.AutorizeOverdraft == false)
            {
                throw new AccountServiceException("not enough money");
            }

            Operation creditOperation = new Operation() { Amount = amount, Direction = Direction.Credit};
            Operation debitOperation = new Operation() { Amount = amount, Direction = Direction.Debit };

            creditAccount.Operations.Add(creditOperation);
            debitAccount.Operations.Add(debitOperation);

            creditAccount.Balance += amount;
            debitAccount.Balance -= amount;


            _operationRepository.CreateOperation(creditOperation);
            _operationRepository.CreateOperation(debitOperation);

            _accountRepository.UpdateAccount(creditAccount);
            _accountRepository.UpdateAccount(debitAccount);
        }

        public decimal ComputeInterest(Account account, double annualRate, int months)
        {
            if (account == null)
            {
                throw new AccountServiceException("Account is null");
            }

            double yearInterest = Math.Round((double)account.Balance * annualRate);
            double monthInterest = yearInterest / 12;

            return (decimal)(monthInterest * months);
            
        }

        public List<Operation> GetOperationsForAccount(int accountID)
        {
            Account account = _accountRepository.GetAccount(accountID);
            if (account == null)
            {
                return null;
            }

            if (account.Operations == null)
            {
                return null;
            }

            return account.Operations.ToList();
        }

    }
}
