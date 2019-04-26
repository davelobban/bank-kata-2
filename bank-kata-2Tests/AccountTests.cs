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

        [TestCase(100)]
        [TestCase(200)]
        public void Deposit_AmountDeposited_TransactionShowsInRepo(int amount)
        {

            var transactionRepo= new TransactionRepo();
            var transactions = transactionRepo.GetAll();
            var subject = new Account(transactionRepo);
            subject.Deposit(amount);
            Assert.AreEqual(1, transactions.Count);
            var actual = transactions[0].Amount;
            Assert.AreEqual(amount, actual);
        }


        [TestCase(100)]
        [TestCase(200)]
        public void Withdraw_AmountWithdrawn_TransactionShowsInRepo(int amount)
        {

            var transactionRepo = new TransactionRepo();
            var transactions = transactionRepo.GetAll();
            var subject = new Account(transactionRepo);
            subject.Withdraw(amount);
            Assert.AreEqual(1, transactions.Count);
            var actual = transactions[0].Amount;
            Assert.AreEqual(amount, actual);
        }
    }
}