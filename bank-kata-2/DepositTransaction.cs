namespace bank_kata_2
{
    public class DepositTransaction : Transaction, ITransaction
    {
        public DepositTransaction(int amount, string todayToString):base(amount, todayToString)
        {
        }

        public override int ChangeToClosingBalance => Amount;
    }
}