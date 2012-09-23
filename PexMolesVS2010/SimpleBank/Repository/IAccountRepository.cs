using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleBank.Domain;

namespace SimpleBank.Repository
{
    public interface IAccountRepository
    {
        void CreateAccount(Account account);
        Account GetAccount(int id);
        void UpdateAccount(Account account);
    }
}
