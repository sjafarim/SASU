using System;
using NUnit.Framework;
using BankProject;
using System.Collections.Generic;
using System.Linq;

namespace BankProjectTest
{
    public class TestsBank
    {

        [Test]
        public void initial_balance_is_zero()
        {
            IBank bank = new Bank();
            Assert.AreEqual(0, bank.Balance);
        }

        [Test]
        public void bank_initialy_has_no_account()
        {
            IBank bank = new Bank();
            Assert.AreEqual(0, bank.GetAccountDetails().Count);
        }

        [Test]
        public void accountNumber_generates_not_zero()
        {
            Bank bank = new Bank();
            Assert.AreNotEqual(0, bank.generateAccountNumber());
        }

        [Test]
        public void accountNumber_canbe_maximum_8_digits()
        {
            Bank bank = new Bank();
            Assert.Less(bank.generateAccountNumber(), 1e9);
        }

        [Test]
        public void accountNumbers_should_be_unique()
        {
            Bank bank = new Bank();
            List<int> accountNumbers = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                accountNumbers.Add(bank.generateAccountNumber());
            }
            Assert.AreEqual(100, accountNumbers.Distinct().Count());
        }

        [Test]
        public void requesting_balance_for_existing_account_returns_account_balance()
        {
            IBank bank = new Bank();

            var accountNumber = bank.OpenAccount("Account Holder");
            var accountBalance = bank.GetAccountBalance(accountNumber); ;

            Assert.AreEqual(0, accountBalance);
        }

        [Test]
        public void requesting_balance_for_non_existing_account_throws_exception()
        {
            IBank bank = new Bank();

            Assert.Throws<ArgumentException>(() => { bank.GetAccountBalance(0); });
        }

        [Test]
        public void account_details_returns_details_of_all_opened_accounts()
        {
            IBank bank = new Bank();

            bank.OpenAccount("Account Holder");
            bank.OpenAccount("Account Holder");

            Assert.AreEqual(2, bank.GetAccountDetails().Count);
        }


    }
}