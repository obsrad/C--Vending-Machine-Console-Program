using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vendingmachine
{
    public class Wallet
    {
        public int balance = 0;

        public Wallet(int balance) 
        {
            this.balance = balance;
        }

        public bool ChangeBalance(int amount)
        {
            if ((balance + amount) < 0)
            {
                Console.WriteLine("Unable to change balance below 0.");
                return false;
            }
            else
            {
                //balance = balance + amount;
                balance += amount;
                return true;
            }
        }

        public bool Deposit(int amount) 
        {
            if (amount < 0)
            {
                Console.WriteLine("Cannot deposit negative numbers");
                return false;
            }
            else
            {
                return ChangeBalance(amount);
            }
        }

        public bool Withdraw(int amount)
        {
            if ((balance + amount) < 0)
            {
                Console.WriteLine("Cannot withdraw negative numbers");
                return false;
            }
            else
            {
                return ChangeBalance(-amount);
            }
        }

        public virtual void PrintWallet()
        {
            Console.WriteLine("Balance: " + balance);
        }
    }
}