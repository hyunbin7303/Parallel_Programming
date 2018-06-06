using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel
{

    public class BankAccount
    {
        private int balance;
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public void Deposit(int amount)
        {
            Interlocked.Add(ref balance, amount);
        }
        public void WithDraw(int amount)
        {
            Interlocked.Add(ref balance, -amount);
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
