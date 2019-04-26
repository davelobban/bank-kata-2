namespace bank_kata_2
{
    public class WithdrawalTransaction : Transaction, ITransaction
    {
        public WithdrawalTransaction(int amount, string todayToString) : base(amount, todayToString)
        {
        }

        public override int ChangeToClosingBalance => -Amount;
    }
}