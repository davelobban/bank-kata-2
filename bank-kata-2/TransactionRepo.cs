using System;
using System.Collections.Generic;

namespace bank_kata_2
{
    public class TransactionRepo
    {
        List<ITransaction> _transactions= new List<ITransaction>();
        public List<ITransaction> GetAll()
        {
            return _transactions;
        }

        public void Add(Transaction transaction)
        {
            _transactions.Add(transaction);
        }
    }
}