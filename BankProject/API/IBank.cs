using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public interface IBank
    {
        decimal Balance { get; }
        IList<string> GetAccountDetails();

        int OpenAccount(string accountHolder);
        void Deposit(int accountNumber, decimal amount);
        void Withdraw(int accountNumber, decimal amount);
        void SetOverdraft(int accountNumber, decimal amount);
        decimal GetAccountBalance(int accountNumber);
    }
}
