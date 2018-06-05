using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel
{
    internal static class Program1
    {
        public static void Main()
        {

            // Cancenllation token source.
            var cts = new CancellationTokenSource();
            var token = cts.Token;



            token.Register(() =>
            {
                Console.WriteLine("Cancellation has been requested.");
            });// Going to be executed as soon as somebody does CPS the counsel.



            var t = new Task(() =>
            {
                int i = 0;
                while(true)
                {
                    /*
                    if(token.IsCancellationRequested)
                    {
                        throw new OperationCanceledException();
                    }
                    else
                    {
                        Console.WriteLine($"{i++}\t");
                    }
                    */
                    // Instead of this, use this one
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}\t");

                }
            }, token);
            t.Start();

            Task.Factory.StartNew(() =>
            {
                token.WaitHandle.WaitOne();
                Console.WriteLine("Wait Handle released, therefore the cancelation was requested. ");
            });

            Console.WriteLine("Main Program done.   ");
            Console.ReadKey();
            cts.Cancel();


        }
    }
}
