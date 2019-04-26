using System;
using System.Collections.Generic;
using System.Text;

namespace bank_kata_2
{
    public class Transaction : ITransaction
    {
        public Transaction(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; }
    }
}
