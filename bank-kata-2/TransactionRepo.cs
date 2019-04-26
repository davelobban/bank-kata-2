using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace bank_kata_2
{
    public class TransactionRepo
    {
        List<ITransaction> _transactions= new List<ITransaction>();
        private IDateProvider _dateProvider;

        public TransactionRepo(IDateProvider dateProvider)
        {
            _dateProvider= dateProvider;
        }

        public List<ITransaction> GetAll()
        {
            return _transactions;
        }

        public void AddDeposit(int amount)
        {
            var deposit = new DepositTransaction(amount, _dateProvider.TodayToString());
            _transactions.Add(deposit);
        }

        public void AddWithdrawal(int amount)
        {
            var deposit = new WithdrawalTransaction(amount, _dateProvider.TodayToString());
            _transactions.Add(deposit);
        }

        public List<IStatementTransaction> GetStatementTransactions()
        {
            var result = new List<IStatementTransaction>();
            var closingBalance = 0;
            var transactions = GetAll();
            transactions.ForEach(t =>
            {
                closingBalance += t.ChangeToClosingBalance;
                result.Add(new StatementTransaction(t.Amount, t.Date, closingBalance, t.ChangeToClosingBalance));
            });
            return result;
        }
    }
}