using System.ComponentModel.DataAnnotations;
using System.Xml.Xsl;
using bank_kata_2;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class AccountTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(100, "01/01/2010")]
        [TestCase(200, "02/02/2010")]
        public void Deposit_AmountDeposited_TransactionShowsInRepo(int amount, string transactionDate)
        {
            var mockDateProvider = new Mock<IDateProvider>();
            mockDateProvider.Setup(m => m.TodayToString()).Returns(transactionDate);
           var transactionRepo= new TransactionRepo(mockDateProvider.Object);

            var transactions = transactionRepo.GetAll();
            var subject = new Account(transactionRepo);
            subject.Deposit(amount);
            Assert.AreEqual(1, transactions.Count);
            var actual = transactions[0].Amount;
            Assert.AreEqual(amount, actual);
            var actualDate = transactions[0].Date;
            Assert.AreEqual(transactionDate, actualDate);
        }


        [TestCase(100, "01/01/2010")]
        [TestCase(200, "02/02/2010")]
        public void Withdraw_AmountWithdrawn_TransactionShowsInRepo(int amount, string transactionDate)
        {

            var mockDateProvider = new Mock<IDateProvider>();
            mockDateProvider.Setup(m => m.TodayToString()).Returns(transactionDate);
            var transactionRepo = new TransactionRepo(mockDateProvider.Object);

            var transactions = transactionRepo.GetAll();
            var subject = new Account(transactionRepo);
            subject.Withdraw(amount);
            Assert.AreEqual(1, transactions.Count);
            var actual = transactions[0].Amount;
            Assert.AreEqual(amount, actual);
            var actualDate = transactions[0].Date;
            Assert.AreEqual(transactionDate, actualDate);
        }
    }
}