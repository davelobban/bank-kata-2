using System.ComponentModel.DataAnnotations;
using System.Xml.Xsl;
using bank_kata_2;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class TransactionRepoTests
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

            var subject = new Account(transactionRepo);
            subject.Deposit(amount);
            var transactions = transactionRepo.GetAll();
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

            var subject = new Account(transactionRepo);
            subject.Withdraw(amount);
            var transactions = transactionRepo.GetAll();
            Assert.AreEqual(1, transactions.Count);
            var actual = transactions[0].Amount;
            Assert.AreEqual(amount, actual);
            var actualDate = transactions[0].Date;
            Assert.AreEqual(transactionDate, actualDate);
        }

        [Test]
        public void GetStatementTransactions_ThreeTransactions_TransactionsShowInResult()
        {
            var transactionDate1 = "10/01/2012";
            var transactionDate2 = "13/01/2012";
            var transactionDate3 = "14/01/2012";
            var amount1 = 1000;
            var amount2 = 2000;
            var amount3 = 500;
            var closingBalance1 = 1000;
            var closingBalance2 = 3000;
            var closingBalance3 = 2500;


            var mockDateProvider = new Mock<IDateProvider>();
            mockDateProvider.SetupSequence(m => m.TodayToString())
                .Returns(transactionDate1)
                .Returns(transactionDate2)
                .Returns(transactionDate3);
            var transactionRepo = new TransactionRepo(mockDateProvider.Object);

            var subject = new Account(transactionRepo);
            subject.Deposit(amount1);
            subject.Deposit(amount2);
            subject.Withdraw(amount3);

            var transactions = transactionRepo.GetStatementTransactions();
            Assert.AreEqual(3, transactions.Count);

            Assert.AreEqual(amount1, transactions[0].Amount);
            Assert.AreEqual(transactionDate1, transactions[0].Date);
            Assert.AreEqual(closingBalance1, transactions[0].ClosingBalance);

            Assert.AreEqual(amount2, transactions[1].Amount);
            Assert.AreEqual(transactionDate2, transactions[1].Date);
            Assert.AreEqual(closingBalance2, transactions[1].ClosingBalance);

            Assert.AreEqual(amount3, transactions[2].Amount);
            Assert.AreEqual(transactionDate3, transactions[2].Date);
            Assert.AreEqual(closingBalance3, transactions[2].ClosingBalance);

        }

    }
    }