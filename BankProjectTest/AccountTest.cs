using System;
using BankProject;
using NUnit.Framework;
using BankProject;


namespace BankProjectTest
{
    [TestFixture]
    class AccountTests
    {
        [Test]
        public void account_number_less_then_10000000_throws_exception(
            [Values(int.MinValue, -1, 0, 1, 9999999)] int number)
        {
            Assert.Catch<ArgumentException>(() => new Account(number, "holder"));
        }

        [Test]
        public void account_number_greater_than_99999999_throws_exception(
            [Values(100000000, 111111111, int.MaxValue)] int number)
        {
            Assert.Catch<ArgumentException>(() => new Account(number, "holder"));
        }

        [Test]
        public void null_or_empty_account_name_throws_exception(
            [Values(null, "")] string name)
        {
            Assert.Catch<ArgumentException>(() => new Account(11111111, name));
        }

        [Test]
        public void new_account_has_zero_balance()
        {
            var account = new Account(11111111, "name");

            Assert.That(0, Is.EqualTo(account.Balance));
            Assert.That("name", Is.EqualTo(account.HolderName));
        }
    }
}
