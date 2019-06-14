using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mpir.core
{
    public class mpz_t : IComparable<mpz_t>, IEquatable<mpz_t>, IComparable<long>, IEquatable<long>, IComparable<ulong>, IEquatable<ulong>
    {
        private IntPtr me = new IntPtr();

        public mpz_t() { internals.mpir.__gmpz_init(ref me); }
        public mpz_t(mpz_t x) { internals.mpir.__gmpz_init_set(ref me, ref x.me); }
        public mpz_t(long x) { internals.mpir.__gmpz_init_set_si(ref me, x); }
        public mpz_t(ulong x) { internals.mpir.__gmpz_init_set_ui(ref me, x); }
        public mpz_t(string x) { internals.mpir.__gmpz_init_set_str(ref me, x, 10); }

        ~mpz_t() { internals.mpir.__gmpz_clear(ref me); }

        public int CompareTo(mpz_t other) => internals.mpir.__gmpz_cmp(ref me, ref other.me);
        public int CompareTo(long other) => internals.mpir.__gmpz_cmp_si(ref me, other);
        public int CompareTo(ulong other) => internals.mpir.__gmpz_cmp_ui(ref me, other);
        public bool Equals(mpz_t other) => CompareTo(other) == 0;
        public bool Equals(long other) => CompareTo(other) == 0;
        public bool Equals(ulong other) => CompareTo(other) == 0;

        public override string ToString()
        {
            uint size = internals.mpir.__gmpz_sizeinbase(ref me, 10);
            var res = new StringBuilder((int)size + 2);
            internals.mpir.__gmpz_get_str(res, 10, ref me);
            return res.ToString();
        }

        public static readonly mpz_t ONE = new mpz_t(1);
        public static readonly mpz_t TWO = new mpz_t(2);
        public static readonly mpz_t TEN = new mpz_t(10);

        public static mpz_t operator +(mpz_t left, mpz_t right)
        {
            var res = new mpz_t();
            internals.mpir.__gmpz_add(ref res.me, ref left.me, ref right.me);
            return res;
        }
        public static mpz_t operator +(mpz_t left, ulong right)
        {
            var res = new mpz_t();
            internals.mpir.__gmpz_add_ui(ref res.me, ref left.me, right);
            return res;
        }
        public static mpz_t operator +(ulong left, mpz_t right) => right + left;
        public static mpz_t operator +(mpz_t left, long right) => right >= 0 ? left + (ulong)right : left - ((ulong)-right);
        public static mpz_t operator +(long left, mpz_t right) => right + left;
        
        public static mpz_t operator -(mpz_t x)
        {
            var res = new mpz_t();
            internals.mpir.__gmpz_neg(ref res.me, ref x.me);
            return res;
        }
        public static mpz_t operator -(mpz_t left, mpz_t right)
        {
            var res = new mpz_t();
            internals.mpir.__gmpz_sub(ref res.me, ref left.me, ref right.me);
            return res;
        }
        public static mpz_t operator -(mpz_t left, ulong right)
        {
            var res = new mpz_t();
            internals.mpir.__gmpz_sub_ui(ref res.me, ref left.me, right);
            return res;
        }
        public static mpz_t operator -(ulong left, mpz_t right)
        {
            var res = new mpz_t();
            internals.mpir.__gmpz_ui_sub(ref res.me, left, ref right.me);
            return res;
        }
        public static mpz_t operator -(mpz_t left, long right) => right >= 0 ? left - (ulong)right : left + ((ulong)-right);
        public static mpz_t operator -(long left, mpz_t right) => left >= 0 ? (ulong)left - right : -right - ((ulong)-left);

        public static mpz_t operator *(mpz_t left, mpz_t right)
        {
            var res = new mpz_t();
            internals.mpir.__gmpz_mul(ref res.me, ref left.me, ref right.me);
            return res;
        }
        public static mpz_t operator *(mpz_t left, long right)
        {
            var res = new mpz_t();
            internals.mpir.__gmpz_mul_si(ref res.me, ref left.me, right);
            return res;
        }
        public static mpz_t operator *(long left, mpz_t right) => right * left;
        public static mpz_t operator *(mpz_t left, ulong right)
        {
            var res = new mpz_t();
            internals.mpir.__gmpz_mul_ui(ref res.me, ref left.me, right);
            return res;
        }
        public static mpz_t operator *(ulong left, mpz_t right) => right * left;

        public static mpz_t operator /(mpz_t left, mpz_t right)
        {
            var res = new mpz_t();
            internals.mpir.__gmpz_fdiv_q(ref res.me, ref left.me, ref right.me);
            return res;
        }
        public static mpz_t operator /(mpz_t left, ulong right)
        {
            var res = new mpz_t();
            internals.mpir.__gmpz_fdiv_q_ui(ref res.me, ref left.me, right);
            return res;
        }
        public static mpz_t operator /(mpz_t left, long right)
        {
            var res = new mpz_t(right);
            internals.mpir.__gmpz_fdiv_q(ref res.me, ref left.me, ref res.me);
            return res;
        }

        public static mpz_t operator %(mpz_t left, mpz_t right)
        {
            var res = new mpz_t();
            internals.mpir.__gmpz_mod(ref res.me, ref left.me, ref right.me);
            return res;
        }
        public static mpz_t operator %(mpz_t left, ulong right)
        {
            var res = new mpz_t();
            internals.mpir.__gmpz_mod_ui(ref res.me, ref left.me, right);
            return res;
        }
        public static mpz_t operator %(ulong left, mpz_t right)
        {
            var res = new mpz_t();
            internals.mpir.__gmpz_ui_mod(ref res.me, left, ref right.me);
            return res;
        }

        public static mpz_t operator ^(mpz_t left, ulong right)
        {
            var res = new mpz_t();
            internals.mpir.__gmpz_pow_ui(ref res.me, ref left.me, right);
            return res;
        }

        public static explicit operator long(mpz_t x) => internals.mpir.__gmpz_get_si(ref x.me);
        public static explicit operator ulong(mpz_t x) => internals.mpir.__gmpz_get_ui(ref x.me);
        public static explicit operator string(mpz_t x) => x.ToString();

        public static implicit operator mpz_t(short x) => new mpz_t(x);
        public static implicit operator mpz_t(ushort x) => new mpz_t((ulong)x);
        public static implicit operator mpz_t(int x) => new mpz_t(x);
        public static implicit operator mpz_t(uint x) => new mpz_t((ulong)x);
        public static implicit operator mpz_t(long x) => new mpz_t(x);
        public static implicit operator mpz_t(ulong x) => new mpz_t(x);
        public static implicit operator mpz_t(string x) => new mpz_t(x);

    }
    public class mpz_t_async : IAsyncResult, IDisposable
    {
        private Task<mpz_t> t = null;

        public mpz_t_async() : this(() => new mpz_t()) { }
        public mpz_t_async(long x) : this(() => new mpz_t(x)) { }
        public mpz_t_async(ulong x) : this(() => new mpz_t(x)) { }
        public mpz_t_async(string x) : this(() => new mpz_t(x)) { }
        private mpz_t_async(Func<mpz_t> f)
        {
            t = Task.Run(f);
        }
        private mpz_t_async(Func<Task<mpz_t>> f)
        {
            t = Task.Run(f);
        }

        public static readonly mpz_t_async ONE = new mpz_t_async(1);
        public static readonly mpz_t_async TWO = new mpz_t_async(2);
        public static readonly mpz_t_async TEN = new mpz_t_async(10);

        public object AsyncState => t?.AsyncState;
        public TaskAwaiter<mpz_t> GetAwaiter() => (t?.GetAwaiter()).GetValueOrDefault();
        public bool IsCompleted => (t?.IsCompleted).GetValueOrDefault(false);
        public WaitHandle AsyncWaitHandle => throw new NotImplementedException();
        public bool CompletedSynchronously => throw new NotImplementedException();
        public void Dispose()
        {
            t?.Dispose();
        }

        public new Task<string> ToString() => Task.Run(async () => (await this).ToString());

        public static mpz_t_async operator +(mpz_t_async left, mpz_t_async right) => (mpz_t_async)(async () => (await left) + (await right));
        public static mpz_t_async operator +(mpz_t_async left, mpz_t right) => (mpz_t_async)(async () => (await left) + right);
        public static mpz_t_async operator +(mpz_t left, mpz_t_async right) => (mpz_t_async)(async () => left + (await right));
        public static mpz_t_async operator +(mpz_t_async left, long right) => (mpz_t_async)(async () => (await left) + right);
        public static mpz_t_async operator +(long left, mpz_t_async right) => (mpz_t_async)(async () => (await right) + left);
        public static mpz_t_async operator +(mpz_t_async left, ulong right) => (mpz_t_async)(async () => (await left) + right);
        public static mpz_t_async operator +(ulong left, mpz_t_async right) => (mpz_t_async)(async () => (await right) + left);

        public static mpz_t_async operator -(mpz_t_async x) => (mpz_t_async)(async () => -(await x));
        public static mpz_t_async operator -(mpz_t_async left, mpz_t_async right) => (mpz_t_async)(async () => (await left) - (await right));
        public static mpz_t_async operator -(mpz_t_async left, mpz_t right) => (mpz_t_async)(async () => (await left) - right);
        public static mpz_t_async operator -(mpz_t left, mpz_t_async right) => (mpz_t_async)(async () => left - (await right));
        public static mpz_t_async operator -(mpz_t_async left, long right) => (mpz_t_async)(async () => (await left) - right);
        public static mpz_t_async operator -(long left, mpz_t_async right) => (mpz_t_async)(async () => left - (await right));
        public static mpz_t_async operator -(mpz_t_async left, ulong right) => (mpz_t_async)(async () => (await left) * right);
        public static mpz_t_async operator -(ulong left, mpz_t_async right) => (mpz_t_async)(async () => left - (await right));

        public static mpz_t_async operator *(mpz_t_async left, mpz_t_async right) => (mpz_t_async)(async () => (await left) * (await right));
        public static mpz_t_async operator *(mpz_t_async left, mpz_t right) => (mpz_t_async)(async () => (await left) * right);
        public static mpz_t_async operator *(mpz_t left, mpz_t_async right) => (mpz_t_async)(async () => left * (await right));
        public static mpz_t_async operator *(mpz_t_async left, long right) => (mpz_t_async)(async () => (await left) * right);
        public static mpz_t_async operator *(long left, mpz_t_async right) => (mpz_t_async)(async () => (await right) * left);
        public static mpz_t_async operator *(mpz_t_async left, ulong right) => (mpz_t_async)(async () => (await left) * right);
        public static mpz_t_async operator *(ulong left, mpz_t_async right) => (mpz_t_async)(async () => (await right) * left);

        public static mpz_t_async operator /(mpz_t_async left, mpz_t_async right) => (mpz_t_async)(async () => (await left) / (await right));
        public static mpz_t_async operator /(mpz_t_async left, mpz_t right) => (mpz_t_async)(async () => (await left) / right);
        public static mpz_t_async operator /(mpz_t left, mpz_t_async right) => (mpz_t_async)(async () => left / (await right));
        public static mpz_t_async operator /(mpz_t_async left, ulong right) => (mpz_t_async)(async () => (await left) / right);
        public static mpz_t_async operator /(mpz_t_async left, long right) => (mpz_t_async)(async () => (await left) / right);

        public static mpz_t_async operator %(mpz_t_async left, mpz_t_async right) => (mpz_t_async)(async () => (await left) % (await right));
        public static mpz_t_async operator %(mpz_t_async left, mpz_t right) => (mpz_t_async)(async () => (await left) % right);
        public static mpz_t_async operator %(mpz_t left, mpz_t_async right) => (mpz_t_async)(async () => left % (await right));
        public static mpz_t_async operator %(mpz_t_async left, ulong right) => (mpz_t_async)(async () => (await left) % right);
        public static mpz_t_async operator %(ulong left, mpz_t_async right) => (mpz_t_async)(async () => left % (await right));

        public static mpz_t_async operator ^(mpz_t_async left, ulong right) => (mpz_t_async)(async () => (await left) ^ right);

        public static explicit operator Task<long>(mpz_t_async x) => Task.Run(async () => (long)(await x));
        public static explicit operator Task<ulong>(mpz_t_async x) => Task.Run(async () => (ulong)(await x));
        public static explicit operator Task<string>(mpz_t_async x) => x.ToString();

        public static implicit operator mpz_t_async(short x) => new mpz_t_async(x);
        public static implicit operator mpz_t_async(ushort x) => new mpz_t_async((ulong)x);
        public static implicit operator mpz_t_async(int x) => new mpz_t_async(x);
        public static implicit operator mpz_t_async(uint x) => new mpz_t_async((ulong)x);
        public static implicit operator mpz_t_async(long x) => new mpz_t_async(x);
        public static implicit operator mpz_t_async(ulong x) => new mpz_t_async(x);
        public static implicit operator mpz_t_async(string x) => new mpz_t_async(x);

        public static explicit operator mpz_t_async(Func<mpz_t> f) => new mpz_t_async(f);
        public static explicit operator mpz_t_async(Func<Task<mpz_t>> f) => new mpz_t_async(f);
    }
}
