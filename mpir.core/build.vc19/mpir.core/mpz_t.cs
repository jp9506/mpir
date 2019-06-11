using System;
using System.Collections.Generic;
using System.Text;

namespace mpir.core
{
    public class mpz_t
    {
        private IntPtr me = new IntPtr();

        public mpz_t() { internals.mpir.__gmpz_init(ref me); }
        public mpz_t(int x) { internals.mpir.__gmpz_init_set_si(ref me, x); }
        public mpz_t(uint x) { internals.mpir.__gmpz_init_set_ui(ref me, x); }
        public mpz_t(long x) { internals.mpir.__gmpz_init_set_sx(ref me, x); }
        public mpz_t(ulong x) { internals.mpir.__gmpz_init_set_ux(ref me, x); }
        public mpz_t(string x) { internals.mpir.__gmpz_init_set_str(ref me, x, 10); }

        ~mpz_t() { internals.mpir.__gmpz_clear(ref me); }

        public override string ToString()
        {
            var res = "";
            //internals.mpir.__gmpz_get_str(ref res, 10, ref me);
            return res;
        }

        public static mpz_t operator +(mpz_t left, mpz_t right)
        {
            var res = new mpz_t();
            internals.mpir.__gmpz_add(ref res.me, ref left.me, ref right.me);
            return res;
        }

        public static explicit operator int(mpz_t x)
        {
            int res;
            internals.mpir.__gmpz_get_si(out res, ref x.me);
            return res;
        }
    }
}
