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
            //Run().Wait();
            mpf_t x = -1;
            Console.WriteLine(x.ToString());
            x *= x;
            Console.WriteLine(x.ToString());

        }
        static async Task Run()
        {
            var res = await Task.WhenAll(Enumerable.Range(0, 10).Select(async (i) =>
            {
                mpf_t_async x = -Math.PI;
                mpf_t_async xi = x ^ (ulong)i;
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
