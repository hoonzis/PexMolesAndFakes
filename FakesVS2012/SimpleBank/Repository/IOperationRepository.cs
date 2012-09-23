using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleBank.Domain;

namespace SimpleBank.Repository
{
    public interface IOperationRepository
    {
        void CreateOperation(Operation o);
    }
}
