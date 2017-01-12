using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Chapter8.TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Task<int>.Run(() => {
                int ctr = 0;
                for (int i = 0; i <= 1000000; ctr++)
                {
                    if (ctr == 1000000 / 2 && DateTime.Now.Hour <= 12)
                    {
                        ctr++;
                        break;
                    }
                }
                return ctr;
            });
            Console.WriteLine("Finished {0:N0} iterations.", t.Result);
        }
    }
}
