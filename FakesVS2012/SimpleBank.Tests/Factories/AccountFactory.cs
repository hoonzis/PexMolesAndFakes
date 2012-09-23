using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Pex.Framework;
using SimpleBank.Domain;

namespace SimpleBank.Tests.Factories
{
    class AccountFactory
    {
        public static Random r = new Random();
        public static int counter = 0;
        /// <summary>A factory for Microsoft.ExtendedReflection.Metadata.Impl.__ArrayHelper`1[SimpleBank.Domain.Operation] instances</summary>
        [PexFactoryMethod(typeof(Account))]
        public static object Create()
        {
            int operationCount = r.Next(10);

            Account account = new Account();
            Operation[] operations = new Operation[operationCount];
            foreach (Operation o in operations)
            {
                o.Amount = r.Next(1000);
                o.Direction = Direction.Credit;
            }
            account.Operations = new List<Operation>(operations);
            account.Balance = operations.Sum(x => (x.Amount * (int)x.Direction));
            account.Id = counter++;
            return account;
        }
    }
}
