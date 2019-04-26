using System;
using System.Collections.Generic;

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
            var deposit = new Transaction(amount, _dateProvider.TodayToString());
            _transactions.Add(deposit);
        }

        public void AddWithdrawal(int amount)
        {
            var deposit = new Transaction(amount, _dateProvider.TodayToString());
            _transactions.Add(deposit);
        }
    }
}