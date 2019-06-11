using mpir.core;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            mpz_t x = 3;
            for (int i = 0; i < 10; i++)
            {
                x *= x;
                Console.WriteLine(i + ": " + x.ToString());
            }
        }
    }
}
