using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel
{
    internal static class Program
    {
        public static void Main()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = new Task(() =>
            {
                Console.WriteLine("5 Seconds ");
                for(int i= 0; i<5; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }


                Console.WriteLine("I'm Done. ");

            }, token);
            t.Start();

            // Another task Start
            Task t2 = Task.Factory.StartNew(() => Thread.Sleep(3000), token);

            // Task.WaitAll(t,t2); //you can use this one too.waiting two tasks are done.
            // Task.WaitAny(t, t2);
            //t.Wait(token);
            
            Task.WaitAll(new[] { t, t2 }, 4000, token);
            Console.WriteLine($"Task t status is {t.Status}");
            Console.WriteLine($"Task t2 status is {t2.Status}");




            Console.WriteLine("MAIN PROGRAM DONE.");
            Console.ReadKey();
        }
    }
}
