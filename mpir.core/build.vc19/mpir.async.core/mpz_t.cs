using sync = mpir.core;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace mpir.async.core
{
    public class mpz_t : IAsyncResult, IDisposable
    {
        private readonly Task<sync.mpz_t> t = null;

        public mpz_t() : this(() => new sync.mpz_t()) { }
        public mpz_t(long x) : this(() => new sync.mpz_t(x)) { }
        public mpz_t(ulong x) : this(() => new sync.mpz_t(x)) { }
        public mpz_t(string x) : this(() => new sync.mpz_t(x)) { }
        private mpz_t(Func<sync.mpz_t> f)
        {
            t = Task.Run(f);
        }
        private mpz_t(Func<Task<sync.mpz_t>> f)
        {
            t = Task.Run(f);
        }

        public static readonly mpz_t ONE = new mpz_t(1);
        public static readonly mpz_t TWO = new mpz_t(2);
        public static readonly mpz_t TEN = new mpz_t(10);

        public object AsyncState => t?.AsyncState;
        public TaskAwaiter<sync.mpz_t> GetAwaiter() => (t?.GetAwaiter()).GetValueOrDefault();
        public bool IsCompleted => (t?.IsCompleted).GetValueOrDefault(false);
        public WaitHandle AsyncWaitHandle => throw new NotImplementedException();
        public bool CompletedSynchronously => throw new NotImplementedException();
        public void Dispose()
        {
            t?.Dispose();
        }

        public new Task<string> ToString() => Task.Run(async () => (await this).ToString());

        public static mpz_t operator +(mpz_t left, mpz_t right) => (mpz_t)(async () => (await left) + (await right));
        public static mpz_t operator +(mpz_t left, sync.mpz_t right) => (mpz_t)(async () => (await left) + right);
        public static mpz_t operator +(sync.mpz_t left, mpz_t right) => (mpz_t)(async () => left + (await right));
        public static mpz_t operator +(mpz_t left, long right) => (mpz_t)(async () => (await left) + right);
        public static mpz_t operator +(long left, mpz_t right) => (mpz_t)(async () => (await right) + left);
        public static mpz_t operator +(mpz_t left, ulong right) => (mpz_t)(async () => (await left) + right);
        public static mpz_t operator +(ulong left, mpz_t right) => (mpz_t)(async () => (await right) + left);

        public static mpz_t operator -(mpz_t x) => (mpz_t)(async () => -(await x));
        public static mpz_t operator -(mpz_t left, mpz_t right) => (mpz_t)(async () => (await left) - (await right));
        public static mpz_t operator -(mpz_t left, sync.mpz_t right) => (mpz_t)(async () => (await left) - right);
        public static mpz_t operator -(sync.mpz_t left, mpz_t right) => (mpz_t)(async () => left - (await right));
        public static mpz_t operator -(mpz_t left, long right) => (mpz_t)(async () => (await left) - right);
        public static mpz_t operator -(long left, mpz_t right) => (mpz_t)(async () => left - (await right));
        public static mpz_t operator -(mpz_t left, ulong right) => (mpz_t)(async () => (await left) * right);
        public static mpz_t operator -(ulong left, mpz_t right) => (mpz_t)(async () => left - (await right));

        public static mpz_t operator *(mpz_t left, mpz_t right) => (mpz_t)(async () => (await left) * (await right));
        public static mpz_t operator *(mpz_t left, sync.mpz_t right) => (mpz_t)(async () => (await left) * right);
        public static mpz_t operator *(sync.mpz_t left, mpz_t right) => (mpz_t)(async () => left * (await right));
        public static mpz_t operator *(mpz_t left, long right) => (mpz_t)(async () => (await left) * right);
        public static mpz_t operator *(long left, mpz_t right) => (mpz_t)(async () => (await right) * left);
        public static mpz_t operator *(mpz_t left, ulong right) => (mpz_t)(async () => (await left) * right);
        public static mpz_t operator *(ulong left, mpz_t right) => (mpz_t)(async () => (await right) * left);

        public static mpz_t operator /(mpz_t left, mpz_t right) => (mpz_t)(async () => (await left) / (await right));
        public static mpz_t operator /(mpz_t left, sync.mpz_t right) => (mpz_t)(async () => (await left) / right);
        public static mpz_t operator /(sync.mpz_t left, mpz_t right) => (mpz_t)(async () => left / (await right));
        public static mpz_t operator /(mpz_t left, ulong right) => (mpz_t)(async () => (await left) / right);
        public static mpz_t operator /(mpz_t left, long right) => (mpz_t)(async () => (await left) / right);

        public static mpz_t operator %(mpz_t left, mpz_t right) => (mpz_t)(async () => (await left) % (await right));
        public static mpz_t operator %(mpz_t left, sync.mpz_t right) => (mpz_t)(async () => (await left) % right);
        public static mpz_t operator %(sync.mpz_t left, mpz_t right) => (mpz_t)(async () => left % (await right));
        public static mpz_t operator %(mpz_t left, ulong right) => (mpz_t)(async () => (await left) % right);
        public static mpz_t operator %(ulong left, mpz_t right) => (mpz_t)(async () => left % (await right));

        public static mpz_t operator ^(mpz_t left, ulong right) => (mpz_t)(async () => (await left) ^ right);

        public static explicit operator Task<long>(mpz_t x) => Task.Run(async () => (long)(await x));
        public static explicit operator Task<ulong>(mpz_t x) => Task.Run(async () => (ulong)(await x));
        public static explicit operator Task<string>(mpz_t x) => x.ToString();

        public static implicit operator mpz_t(short x) => new mpz_t(x);
        public static implicit operator mpz_t(ushort x) => new mpz_t((ulong)x);
        public static implicit operator mpz_t(int x) => new mpz_t(x);
        public static implicit operator mpz_t(uint x) => new mpz_t((ulong)x);
        public static implicit operator mpz_t(long x) => new mpz_t(x);
        public static implicit operator mpz_t(ulong x) => new mpz_t(x);
        public static implicit operator mpz_t(string x) => new mpz_t(x);

        public static explicit operator mpz_t(Func<sync.mpz_t> f) => new mpz_t(f);
        public static explicit operator mpz_t(Func<Task<sync.mpz_t>> f) => new mpz_t(f);

        public static mpz_t PowM(mpz_t @base, mpz_t exp, mpz_t mod) => (mpz_t)(async () => sync.mpz_t.PowM(await @base, await exp, await mod));
        public static mpz_t GCD(mpz_t left, mpz_t right) => (mpz_t)(async () => sync.mpz_t.GCD(await left, await right));
        public static mpz_t LCM(mpz_t left, mpz_t right) => (mpz_t)(async () => sync.mpz_t.LCM(await left, await right));
    }
}
