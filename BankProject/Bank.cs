using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class Bank : IBank
    {
        private int accountCounter = 9999999;
        private List<Account> accounts;

        public decimal Balance => 0;

        public Bank()
        {
            accounts = new List<Account>();
        }

        int IBank.OpenAccount(string accountHolder)
        {
            var account = new Account(generateAccountNumber(), accountHolder);
            accounts.Add(account);
            return account.Number;
        }

        void IBank.Deposit(int accountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }

        decimal IBank.GetAccountBalance(int accountNumber)
        {
            var account = accounts.FirstOrDefault(x => x.Number == accountNumber);
            if (account != null)
            {
                return account.Balance;
            }

            throw new ArgumentException($"Bank doesn't contain account with number {accountNumber}");
        }

        IList<string> IBank.GetAccountDetails()
        {
            return accounts.Select(x => x.Number.ToString()).ToList();
        }

        void IBank.Withdraw(int accountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }

        public int generateAccountNumber()
        {
            if (accountCounter == (1e9) - 1)
                accountCounter = 9999999;
            return ++accountCounter;
        }

        void IBank.SetOverdraft(int accountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
