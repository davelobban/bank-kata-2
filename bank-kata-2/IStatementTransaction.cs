namespace bank_kata_2
{
    public interface IStatementTransaction: ITransaction
    {
        int ClosingBalance { get; }
    }
}