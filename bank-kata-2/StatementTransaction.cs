using System;

namespace bank_kata_2
{
    internal class StatementTransaction : Transaction, IStatementTransaction
    {
        internal StatementTransaction(int amount, string transactionDate, int closingBalance,
            int changeToClosingBalance)
            : base(amount, transactionDate)
        {
            ClosingBalance = closingBalance;
            ChangeToClosingBalance = changeToClosingBalance;
        }

        public int ClosingBalance { get; }

        public override int ChangeToClosingBalance { get; }
    }
}