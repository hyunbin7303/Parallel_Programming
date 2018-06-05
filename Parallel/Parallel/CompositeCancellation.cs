using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel
{
    public class CompositeCancellation
    {
        public static void Main()
        {
            // Object responsible for creating cancellation token and sending cancellation request to 
            //all copies of that token.
            CancellationTokenSource planned = new CancellationTokenSource();
            var preventative = new CancellationTokenSource();
            var Emergency = new CancellationTokenSource();
            var paranoid = CancellationTokenSource.CreateLinkedTokenSource(
                planned.Token, preventative.Token, Emergency.Token);


            Task.Factory.StartNew(() =>
            {
                int i = 0;
                while(true)
                {
                    paranoid.Token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}\t");
                    Thread.Sleep(1000);
                }
            }, paranoid.Token);
            // Essentially what this implies is I can now request cancellation on either planned or preventative or Emergency token sources.
            // All of this possible because we have a token from a linked token source that will stop our execution so it doesn't matter
            // what I do.

            // It does not matter whether it is preventative or planned or emergency.    
            Console.ReadKey();
            Emergency.Cancel();


            Console.WriteLine("Main Program Done.   ");
            Console.ReadKey();
        }

    }
}
