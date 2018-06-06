using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel
{
    internal static class Program
    {
        public static void Main()
        {
         //   ExceptionHandlingTry();

            // Differeent Way
            try
            {
                ExceptionHandlingTry2();
            }catch(AggregateException ae)
            {
                foreach(var e in ae.InnerExceptions)
                {
                    Console.WriteLine($"EXCEPTION {e.GetType()} from {e.Source}");
                }
            }


            Console.WriteLine("Main PROGRAM DONE.");
            Console.ReadKey();
        }

        private static void ExceptionHandlingTry()
        {
            // Throwing exception on purpose.
            var t = Task.Factory.StartNew(() =>
            {
                throw new InvalidOperationException("Invalid Operation Exeception Happen! ") { Source = "t" };
            });
            var t2 = Task.Factory.StartNew(() =>
            {
                throw new AccessViolationException("Access Vilation Exception Happen! ") { Source = "t2" };
            });
            try
            {
                Task.WaitAll(t, t2);
            }
            catch (AggregateException ae) // Have to catch all exception in here.
            {
                foreach (var e in ae.InnerExceptions)
                {
                    Console.WriteLine($"EXCEPTION {e.GetType()} from {e.Source}");
                }
            }
        }

        private static void ExceptionHandlingTry2()
        {
            // Throwing exception on purpose.
            var t = Task.Factory.StartNew(() =>
            {
                throw new InvalidOperationException("Invalid Operation Exeception Happen! ") { Source = "t" };
            });
            var t2 = Task.Factory.StartNew(() =>
            {
                throw new AccessViolationException("Access Vilation Exception Happen! ") { Source = "t2" };
            });
            try
            {
                Task.WaitAll(t, t2);
            }
            catch (AggregateException ae) // Have to catch all exception in here.
            {
                ae.Handle(e =>
                {
                    if (e is InvalidOperationException)
                    {
                        Console.WriteLine("INVALID OPERATION! ");
                        return true;
                    }
                    else { return false; }
                });

            }
        }
    }
}

