using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBank.Domain
{
    public class Operation
    {
        public decimal Amount { get; set; }
        public Direction Direction { get; set; }
    }
}
