using sync = mpir.core;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace mpir.async.core
{
    public class mpf_t : IAsyncResult, IDisposable
    {
        private readonly Task<sync.mpf_t> t = null;

        public mpf_t() : this(() => new sync.mpf_t()) { }
        public mpf_t(double x) : this(() => new sync.mpf_t(x)) { }
        public mpf_t(long x) : this(() => new sync.mpf_t(x)) { }
        public mpf_t(ulong x) : this(() => new sync.mpf_t(x)) { }
        public mpf_t(string x) : this(() => new sync.mpf_t(x)) { }
        private mpf_t(Func<sync.mpf_t> f)
        {
            t = Task.Run(f);
        }
        private mpf_t(Func<Task<sync.mpf_t>> f)
        {
            t = Task.Run(f);
        }

        public static readonly mpf_t ONE = new mpf_t(1);
        public static readonly mpf_t TWO = new mpf_t(2);
        public static readonly mpf_t TEN = new mpf_t(10);

        public object AsyncState => t?.AsyncState;
        public TaskAwaiter<sync.mpf_t> GetAwaiter() => (t?.GetAwaiter()).GetValueOrDefault();
        public bool IsCompleted => (t?.IsCompleted).GetValueOrDefault(false);
        public WaitHandle AsyncWaitHandle => throw new NotImplementedException();
        public bool CompletedSynchronously => throw new NotImplementedException();
        public void Dispose()
        {
            t?.Dispose();
        }

        public new Task<string> ToString() => ToString(100);
        public Task<string> ToString(uint n_digits) => Task.Run(async () => (await this).ToString(n_digits));

        public static mpf_t operator +(mpf_t left, mpf_t right) => (mpf_t)(async () => (await left) + (await right));
        public static mpf_t operator +(mpf_t left, sync.mpf_t right) => (mpf_t)(async () => (await left) + right);
        public static mpf_t operator +(sync.mpf_t left, mpf_t right) => (mpf_t)(async () => left + (await right));
        public static mpf_t operator +(mpf_t left, long right) => (mpf_t)(async () => (await left) + right);
        public static mpf_t operator +(long left, mpf_t right) => (mpf_t)(async () => (await right) + left);
        public static mpf_t operator +(mpf_t left, ulong right) => (mpf_t)(async () => (await left) + right);
        public static mpf_t operator +(ulong left, mpf_t right) => (mpf_t)(async () => (await right) + left);

        public static mpf_t operator -(mpf_t x) => (mpf_t)(async () => -(await x));
        public static mpf_t operator -(mpf_t left, mpf_t right) => (mpf_t)(async () => (await left) - (await right));
        public static mpf_t operator -(mpf_t left, sync.mpf_t right) => (mpf_t)(async () => (await left) - right);
        public static mpf_t operator -(sync.mpf_t left, mpf_t right) => (mpf_t)(async () => left - (await right));
        public static mpf_t operator -(mpf_t left, long right) => (mpf_t)(async () => (await left) - right);
        public static mpf_t operator -(long left, mpf_t right) => (mpf_t)(async () => left - (await right));
        public static mpf_t operator -(mpf_t left, ulong right) => (mpf_t)(async () => (await left) * right);
        public static mpf_t operator -(ulong left, mpf_t right) => (mpf_t)(async () => left - (await right));

        public static mpf_t operator *(mpf_t left, mpf_t right) => (mpf_t)(async () => (await left) * (await right));
        public static mpf_t operator *(mpf_t left, sync.mpf_t right) => (mpf_t)(async () => (await left) * right);
        public static mpf_t operator *(sync.mpf_t left, mpf_t right) => (mpf_t)(async () => left * (await right));
        public static mpf_t operator *(mpf_t left, long right) => (mpf_t)(async () => (await left) * right);
        public static mpf_t operator *(long left, mpf_t right) => (mpf_t)(async () => (await right) * left);
        public static mpf_t operator *(mpf_t left, ulong right) => (mpf_t)(async () => (await left) * right);
        public static mpf_t operator *(ulong left, mpf_t right) => (mpf_t)(async () => (await right) * left);

        public static mpf_t operator /(mpf_t left, mpf_t right) => (mpf_t)(async () => (await left) / (await right));
        public static mpf_t operator /(mpf_t left, sync.mpf_t right) => (mpf_t)(async () => (await left) / right);
        public static mpf_t operator /(sync.mpf_t left, mpf_t right) => (mpf_t)(async () => left / (await right));
        public static mpf_t operator /(mpf_t left, ulong right) => (mpf_t)(async () => (await left) / right);
        public static mpf_t operator /(mpf_t left, long right) => (mpf_t)(async () => (await left) / right);

        public static mpf_t operator ^(mpf_t left, ulong right) => (mpf_t)(async () => (await left) ^ right);

        public static explicit operator Task<double>(mpf_t x) => Task.Run(async () => (double)(await x));
        public static explicit operator Task<long>(mpf_t x) => Task.Run(async () => (long)(await x));
        public static explicit operator Task<ulong>(mpf_t x) => Task.Run(async () => (ulong)(await x));
        public static explicit operator Task<string>(mpf_t x) => x.ToString();

        public static implicit operator mpf_t(float x) => new mpf_t(x);
        public static implicit operator mpf_t(double x) => new mpf_t(x);
        public static implicit operator mpf_t(short x) => new mpf_t(x);
        public static implicit operator mpf_t(ushort x) => new mpf_t((ulong)x);
        public static implicit operator mpf_t(int x) => new mpf_t(x);
        public static implicit operator mpf_t(uint x) => new mpf_t((ulong)x);
        public static implicit operator mpf_t(long x) => new mpf_t(x);
        public static implicit operator mpf_t(ulong x) => new mpf_t(x);
        public static implicit operator mpf_t(string x) => new mpf_t(x);

        public static explicit operator mpf_t(Func<sync.mpf_t> f) => new mpf_t(f);
        public static explicit operator mpf_t(Func<Task<sync.mpf_t>> f) => new mpf_t(f);
    }
}
