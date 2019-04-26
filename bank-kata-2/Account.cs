namespace bank_kata_2
{
    public class Account
    {
        private TransactionRepo _transactionRepo;
        private IConsole _console;

        public Account(TransactionRepo transactionRepo, IConsole console)
        {
            _transactionRepo = transactionRepo;
            _console = console;
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
            _console.WriteLine("Date       || Amount || Balance");
            var transactionStatementLines = _transactionRepo.GetStatementTransactions();
            transactionStatementLines.Reverse();
            foreach (var line in transactionStatementLines)
            {
                var formatted = $"{line.Date} || {line.ChangeToClosingBalance} || {line.ClosingBalance}";
                _console.WriteLine(formatted);
            }
        }
    }
}