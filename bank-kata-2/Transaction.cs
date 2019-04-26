using System;
using System.Collections.Generic;
using System.Text;

namespace bank_kata_2
{
    public abstract class Transaction : ITransaction
    {
        public Transaction(int amount, string transactionDate)
        {
            Amount = amount;
            Date = transactionDate;
        }

        public int Amount { get; }
        public string Date { get; }
        public abstract int ChangeToClosingBalance { get; }
    }
}
