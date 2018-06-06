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
            Console.WriteLine("HEY");
            var t = new Task(() =>
            {
                Console.WriteLine("Press any key to disarm; you have 5 seconds.");
                bool cancelled = token.WaitHandle.WaitOne(5000);
                Console.WriteLine(cancelled ? "Bomb disarmed. " : "Boom!");
            },token);
            t.Start();


            Console.ReadKey();
            cts.Cancel();


            Console.WriteLine("MAIN DONE");
            Console.ReadKey();
        }
    }
}
