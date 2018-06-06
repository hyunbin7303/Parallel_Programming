using System;
using System.Threading.Tasks;

namespace Parallel
{
    class Task1
    {
        private static void ShowMessage()
        {
            Console.WriteLine("SHOW MESSAGE METHOD ");
        }
        private static void Have_OnePara(int num) { Console.WriteLine($"Show number : {num}. "); }
        private static void Have_TwoPara(int num1, int num2) { Console.WriteLine($"Show number : {num1}, {num2}. "); }
        private static void Have_ThirdPara(int num1, int num2, string str1) { Console.WriteLine($"Show number : {num1}, {num2}, {str1}. "); }
        private static int Sum(int n)
        {
            int sum = 0;
            for (; n > 0; n--)
            {
                checked
                {
                    sum += n;
                }
            }
            return sum;
        }


        public static void Main()
        {
            /* Task Testing
            Task t1 = new Task(new Action(ShowMessage));
            t1.Start();

            Task t2 = new Task(delegate { ShowMessage(); });
            t2.Start();

            Task t3 = new Task(() => ShowMessage());
            t3.Start();
            */
            Task<int> t4 = new Task<int>(n =>
                Sum((int)n), 1000
            );
            t4.Start();
            t4.Wait();
            Console.WriteLine($"RESULT IS {t4.Result}. ");




            /* Action Testing
            Action action = new Action(ShowMessage);
            action();
            
            Action<int> a1 = Have_OnePara;
            Action<int, int> a2 = Have_TwoPara;
            Action<int, int, string> a3 = Have_ThirdPara;

            a1(10);
            a2(30, 40);
            a3(40, 50, "KEVIN");
            */

            Console.ReadKey();
        }
    }
}

/*https://msdn.microsoft.com/ko-kr/library/018hxwa8(v=vs.110).aspx
 * Action : Encapsulates a method that has a single parameter and X return a value.
 * You can use the Action<T> delegate to pass a method as a parameter without explicitly declaring a custom delegate.
 */
