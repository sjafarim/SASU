using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    interface IAccount
    {
        string HolderName { get; }
        int Number { get; }
        decimal Balance { get; }
        void Deposit(decimal amount);
        bool Withdraw(decimal amount);

        bool SetOverDraft(decimal amount);
    }
}
