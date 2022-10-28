using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mpir.core
{
    public class mpf_t : IComparable<mpf_t>, IEquatable<mpf_t>, IComparable<double>, IEquatable<double>, IComparable<long>, IEquatable<long>, IComparable<ulong>, IEquatable<ulong>
    {
        private IntPtr me = new IntPtr();

        public mpf_t() { internals.mpir.__gmpf_init(ref me); }
        public mpf_t(double x) : this(x.ToString()) { } // { internals.mpir.__gmpf_init_set_d(ref me, x); }
        public mpf_t(long x) : this(x.ToString()) { } // { internals.mpir.__gmpf_init_set_si(ref me, x); }
        public mpf_t(ulong x) : this(x.ToString()) { } // { internals.mpir.__gmpf_init_set_ui(ref me, x); }
        public mpf_t(string x) { internals.mpir.__gmpf_init_set_str(ref me, x, 10); }

        ~mpf_t() { internals.mpir.__gmpf_clear(ref me); }

        public int CompareTo(mpf_t other) => internals.mpir.__gmpf_cmp(ref me, ref other.me);
        public int CompareTo(double other) => internals.mpir.__gmpf_cmp_d(ref me, other);
        public int CompareTo(long other) => internals.mpir.__gmpf_cmp_si(ref me, other);
        public int CompareTo(ulong other) => internals.mpir.__gmpf_cmp_ui(ref me, other);
        public bool Equals(mpf_t other) => CompareTo(other) == 0;
        public bool Equals(double other) => CompareTo(other) == 0;
        public bool Equals(long other) => CompareTo(other) == 0;
        public bool Equals(ulong other) => CompareTo(other) == 0;

        public override string ToString() => ToString(100);
        public string ToString(uint n_digits)
        {
            var res = new StringBuilder((int)n_digits + 2);
            int exp = 0;
            internals.mpir.__gmpf_get_str(res, out exp, 10, n_digits, ref me);
            var str = res.ToString();
            var sign = "";
            if (str.StartsWith('-'))
            {
                sign = "-";
                str = str.Substring(1);
            }
            if (exp == 0)
                return sign + "0." + str;
            else if(exp > 0)
                return sign + str.Substring(0, exp) + "." + str.Substring(exp);
            else
                return sign + "0." + ("".PadLeft(-exp, '0')) + str;
        }

        public static readonly mpf_t ONE = new mpf_t(1);
        public static readonly mpf_t TWO = new mpf_t(2);
        public static readonly mpf_t TEN = new mpf_t(10);

        public static mpf_t operator +(mpf_t left, mpf_t right)
        {
            var res = new mpf_t();
            internals.mpir.__gmpf_add(ref res.me, ref left.me, ref right.me);
            return res;
        }
        public static mpf_t operator +(mpf_t left, ulong right)
        {
            var res = new mpf_t();
            internals.mpir.__gmpf_add_ui(ref res.me, ref left.me, right);
            return res;
        }
        public static mpf_t operator +(ulong left, mpf_t right) => right + left;
        public static mpf_t operator +(mpf_t left, long right) => right >= 0 ? left + (ulong)right : left - ((ulong)-right);
        public static mpf_t operator +(long left, mpf_t right) => right + left;
        
        public static mpf_t operator -(mpf_t x)
        {
            var res = new mpf_t();
            internals.mpir.__gmpf_neg(ref res.me, ref x.me);
            return res;
        }
        public static mpf_t operator -(mpf_t left, mpf_t right)
        {
            var res = new mpf_t();
            internals.mpir.__gmpf_sub(ref res.me, ref left.me, ref right.me);
            return res;
        }
        public static mpf_t operator -(mpf_t left, ulong right)
        {
            var res = new mpf_t();
            internals.mpir.__gmpf_sub_ui(ref res.me, ref left.me, right);
            return res;
        }
        public static mpf_t operator -(ulong left, mpf_t right)
        {
            var res = new mpf_t();
            internals.mpir.__gmpf_ui_sub(ref res.me, left, ref right.me);
            return res;
        }
        public static mpf_t operator -(mpf_t left, long right) => right >= 0 ? left - (ulong)right : left + ((ulong)-right);
        public static mpf_t operator -(long left, mpf_t right) => left >= 0 ? (ulong)left - right : -right - ((ulong)-left);

        public static mpf_t operator *(mpf_t left, mpf_t right)
        {
            var res = new mpf_t();
            internals.mpir.__gmpf_mul(ref res.me, ref left.me, ref right.me);
            return res;
        }
        public static mpf_t operator *(mpf_t left, long right) => right >= 0 ? left * (ulong)right : -left * ((ulong)-right);
        public static mpf_t operator *(long left, mpf_t right) => right * left;
        public static mpf_t operator *(mpf_t left, ulong right)
        {
            var res = new mpf_t();
            internals.mpir.__gmpf_mul_ui(ref res.me, ref left.me, right);
            return res;
        }
        public static mpf_t operator *(ulong left, mpf_t right) => right * left;

        public static mpf_t operator /(mpf_t left, mpf_t right)
        {
            var res = new mpf_t();
            internals.mpir.__gmpf_div(ref res.me, ref left.me, ref right.me);
            return res;
        }
        public static mpf_t operator /(mpf_t left, ulong right)
        {
            var res = new mpf_t();
            internals.mpir.__gmpf_div_ui(ref res.me, ref left.me, right);
            return res;
        }
        public static mpf_t operator /(mpf_t left, long right)
        {
            var res = new mpf_t(right);
            internals.mpir.__gmpf_div(ref res.me, ref left.me, ref res.me);
            return res;
        }

        public static mpf_t operator ^(mpf_t left, ulong right)
        {
            var res = new mpf_t();
            internals.mpir.__gmpf_pow_ui(ref res.me, ref left.me, right);
            return res;
        }

        public static explicit operator double(mpf_t x) => internals.mpir.__gmpf_get_d(ref x.me);
        public static explicit operator long(mpf_t x) => internals.mpir.__gmpf_get_si(ref x.me);
        public static explicit operator ulong(mpf_t x) => internals.mpir.__gmpf_get_ui(ref x.me);
        public static explicit operator string(mpf_t x) => x.ToString();

        public static implicit operator mpf_t(float x) => new mpf_t(x);
        public static implicit operator mpf_t(double x) => new mpf_t(x);
        public static implicit operator mpf_t(short x) => new mpf_t(x);
        public static implicit operator mpf_t(ushort x) => new mpf_t((ulong)x);
        public static implicit operator mpf_t(int x) => new mpf_t(x);
        public static implicit operator mpf_t(uint x) => new mpf_t((ulong)x);
        public static implicit operator mpf_t(long x) => new mpf_t(x);
        public static implicit operator mpf_t(ulong x) => new mpf_t(x);
        public static implicit operator mpf_t(string x) => new mpf_t(x);

    }
}
