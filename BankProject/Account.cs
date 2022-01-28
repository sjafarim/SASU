using System;

namespace BankProject
{
    public class Account : IAccount
    {
        public Account(int number, string holderName)
        {
            HolderName = !string.IsNullOrEmpty(holderName) ? holderName : throw new ArgumentException(nameof(holderName));
            Number = (number < 100000000) && (number > 9999999) ? number : throw new ArgumentException("");
            Balance = 0;
        }
        public string HolderName { get; }
        public int Number { get; }
        public decimal Balance { get; private set; }
        private decimal Overdraft { get; set; }
        public void Deposit(decimal amount)
        {
            if (amount >= 0 &&
                ((decimal.MaxValue - amount > 0) ||
                (decimal.MaxValue - Balance - amount >= 0)))
                Balance += amount;
            else throw new ArgumentException("Unsupported balance");
        }
        public bool Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException();
            }
            if (Balance + Overdraft < amount)
            {
                return false;
            }
            Balance -= amount;
            return true;
        }

        public bool SetOverDraft(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException();
            }
            Overdraft = amount;
            return true;
        }
    }

}