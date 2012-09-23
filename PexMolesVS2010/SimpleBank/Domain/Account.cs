using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBank.Domain
{
    public class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public bool AutorizeOverdraft { get; set; }
        public IList<Operation> Operations { get; set; }

        public Account()
        {
            Operations = new List<Operation>();
        }
    }
}
