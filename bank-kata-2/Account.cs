namespace bank_kata_2
{
    public class Account
    {
        private TransactionRepo _transactionRepo;

        public Account(TransactionRepo transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }

        public void Deposit(int amount)
        {
            var deposit= new Transaction(amount);
            _transactionRepo.Add(deposit);
        }

        public void Withdraw(int i)
        {
            throw new System.NotImplementedException();
        }

        public void PrintStatement()
        {
            throw new System.NotImplementedException();
        }
    }
}