using mpir.core;
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
        }
        static async Task Run()
        {
            var res = await Task.WhenAll(Enumerable.Range(0, 10).Select(async (i) =>
            {
                mpz_t_async x = 3;
                mpz_t_async xi = x ^ (ulong)i;
                string s = await xi.ToString();
                return i + ": " + s;
            }));
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
    }
}
