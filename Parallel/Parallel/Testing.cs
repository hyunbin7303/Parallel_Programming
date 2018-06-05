using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel
{
    public class Testing
    {
        public static void Main()
        {
            Task<int> task = HandleFileAsync();
        }

        static async Task<int> HandleFileAsync()
        {

            //string file = @""
            string file = @"C:\asdf.txt";
            Console.WriteLine("HandleFile Enter");
            int count = 0;
            using (StreamReader reader = new StreamReader(file))
            {

            }

                throw new NotImplementedException();
        }
    }
}
