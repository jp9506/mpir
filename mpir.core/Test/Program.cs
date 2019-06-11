using mpir.core;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            mpz_t one = new mpz_t(1);
            Console.WriteLine((int)one);
            //Console.WriteLine(one.ToString());
        }
    }
}
