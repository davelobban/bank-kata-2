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

        [Test]
        public void Deposit_100Deposited_TransactionShowsInRepo()
        {

            var transactionRepo= new TransactionRepo();
            var transactions = transactionRepo.GetAll();
            var subject = new Account(transactionRepo);
            subject.Deposit(100);
            Assert.AreEqual(1, transactions.Count);
            var actual = transactions[0].Amount;
            Assert.AreEqual(100, actual);
        }
    }
}