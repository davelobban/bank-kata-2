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
            _transactionRepo.AddDeposit(amount);
        }

        public void Withdraw(int amount)
        {
            _transactionRepo.AddWithdrawal(amount);
        }

        public void PrintStatement()
        {
            throw new System.NotImplementedException();
        }
    }
}