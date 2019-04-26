namespace bank_kata_2
{
    public interface ITransaction
    {
        int Amount { get; }
        string Date { get; }
        int ChangeToClosingBalance { get; }
    }
}