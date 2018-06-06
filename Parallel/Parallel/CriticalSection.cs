using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel
{
    public class BankAccount
    {
        public object padlock = new object();
        public int Balance { get; private set; }
        public void Deposit(int amount)
        {
            // += this mean,,,,
            // Op1 : temp <- GetBalance() + amount 
            // Op2 : SetBalance(temp)
            // Solution : Make lock.
            lock (padlock)
            {
                Balance += amount;
            }
        }
        public void WithDraw(int amount)
        {
            lock (padlock)
            {
                Balance -= amount;
            }
        }

    }



    internal static class Program
    {
        static void Main()
        {
            var task = new List<Task>();

            var ba = new BankAccount();
            for (int i = 0; i < 10; i++)
            {
                task.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        ba.Deposit(100);
                    }
                }));
                task.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        ba.WithDraw(100);
                    }
                }));
            }
            Task.WaitAll(task.ToArray());
            Console.WriteLine($"Final balance is { ba.Balance}. ");
            // Result must be different every time.
            // Reason : Deposit and WithDraw are not atomic.

        }
    }
}