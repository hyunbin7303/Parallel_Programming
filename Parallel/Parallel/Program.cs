using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel
{
    internal static class Program
    { 
        public static void Write(char c)
        {
            int i = 1000;
            while (i --> 0)
            {
                Console.Write(c);
            }
        }

        public static void Write(object o)
        {
            int i = 1000;
            while(i --> 0)
            {
                Console.Write(o);
            }
        }


        public static int TextLength(object o)
        {
            Console.WriteLine($"\nTask with id {Task.CurrentId} processing object {o}... ");
            return o.ToString().Length;
        }

        public static void Main()
        {
            //Task task = new Task(Write, "Hi");
            //task.Start();
            //Task.Factory.StartNew(Write, 123);

            string text1 = "Testing", text2 = "haha";
            var task1 = new Task<int>(TextLength, text1);
            task1.Start();
            Task<int> task2 = Task.Factory.StartNew(TextLength, text2);
            Console.WriteLine($"Length of '{text1}' is {task1.Result}");
            Console.WriteLine($"Length of '{text2}' is {task2.Result}");
            Console.WriteLine("Main Program. ");
            Console.ReadKey();
        }
    }
}
// Tasks get executed on separate threads which means at some point you might want to cancel a particular task,
// and task parallize provides explicit mechanism for doing exactly that . 