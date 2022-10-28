using mpir.async.core;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Run().Wait();
            //mpf_t x = -1;
            //Console.WriteLine(x.ToString());
            //x *= x;
            //Console.WriteLine(x.ToString());

        }
        static async Task Run()
        {
            //ulong exp = 1;
            ulong n = 1;
            mpz_t a = 4;
            mpz_t b = 11;
            while (n < 32)
            {
                a = ((a - 1) ^ 2) + 1;
                //exp *= 2;
                b = ((b - 1) ^ 2) + 1;
                var g = mpz_t.GCD(a, b);
                var s_g = await g.ToString();
                Console.WriteLine((n + ":").PadRight(6, ' ') + s_g);
                n++;
            }
        }
    }
}
