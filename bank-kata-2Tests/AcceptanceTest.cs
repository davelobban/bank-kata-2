using bank_kata_2;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class AcceptanceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AcceptanceTest_PrintsStatement()
        {
            var mockConsole = new Mock<IConsole>();
            var mockDateProvider = TransactionRepoTests.GetMockDateProviderWithDatesForAcceptanceTestScenario(out var transactionDate1, out var transactionDate2, out var transactionDate3);
            var transactionRepo = new TransactionRepo(mockDateProvider.Object);
            var account = new Account(transactionRepo, mockConsole.Object);
            account.Deposit(1000);
            account.Deposit(2000);
            account.Withdraw(500);
            account.PrintStatement();
            mockConsole.Verify(m=>m.WriteLine("Date       || Amount || Balance"),Times.Once);
            mockConsole.Verify(m => m.WriteLine("14/01/2012 || -500 || 2500"), Times.Once);
            mockConsole.Verify(m => m.WriteLine("13/01/2012 || 2000 || 3000"), Times.Once);
            mockConsole.Verify(m => m.WriteLine("10/01/2012 || 1000 || 1000"), Times.Once);
        }
    }
}