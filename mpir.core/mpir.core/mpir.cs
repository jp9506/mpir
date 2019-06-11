using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace mpir.core.internals
{
    using mpz_t = IntPtr;
    public static class mpir
    {
        #region mpz_t

        [DllImport("mpir.dll")] public static extern void __gmpz_add(ref mpz_t rop, ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_add_ui(ref mpz_t rop, ref mpz_t op1, ulong op2);
        [DllImport("mpir.dll")] public static extern int __gmpz_cmp(ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_clear(ref mpz_t integer);
        [DllImport("mpir.dll")] public static extern void __gmpz_gcd(ref mpz_t rop, ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern long __gmpz_get_si(ref mpz_t op);
        [DllImport("mpir.dll")] public static extern void __gmpz_get_str(StringBuilder rop, int @base, ref mpz_t op);
        [DllImport("mpir.dll")] public static extern ulong __gmpz_get_ui(ref mpz_t op);
        [DllImport("mpir.dll")] public static extern void __gmpz_init(ref mpz_t integer);
        [DllImport("mpir.dll")] public static extern void __gmpz_init_set_si(ref mpz_t rop, long op);
        [DllImport("mpir.dll")] public static extern void __gmpz_init_set_str(ref mpz_t rop, [MarshalAs(UnmanagedType.LPStr)] string str, int @base);
        [DllImport("mpir.dll")] public static extern void __gmpz_init_set_ui(ref mpz_t rop, ulong op);
        [DllImport("mpir.dll")] public static extern void __gmpz_mod(ref mpz_t rop, ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_mod_ui(ref mpz_t rop, ref mpz_t op1, ulong op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_mul(ref mpz_t rop, ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_mul_si(ref mpz_t rop, ref mpz_t op1, long op2);
        public static void __gmpz_si_mul_si(ref mpz_t rop, long op1, long op2)
        {
            __gmpz_init_set_si(ref rop, op1);
            __gmpz_mul_si(ref rop, ref rop, op2);
        }
        [DllImport("mpir.dll")] public static extern void __gmpz_mul_ui(ref mpz_t rop, ref mpz_t op1, ulong op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_neg(ref mpz_t rop, ref mpz_t op);
        [DllImport("mpir.dll")] public static extern void __gmpz_pow_ui(ref mpz_t rop, ref mpz_t op1, ulong op2);
        [DllImport("mpir.dll")] public static extern uint __gmpz_sizeinbase(ref mpz_t op, int @base);
        [DllImport("mpir.dll")] public static extern void __gmpz_sub(ref mpz_t rop, ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_sub_ui(ref mpz_t rop, ref mpz_t op1, ulong op2);
        public static void __gmpz_ui_mod(ref mpz_t rop, ulong op1, ref mpz_t op2)
        {
            __gmpz_init_set_ui(ref rop, op1);
            __gmpz_mod(ref rop, ref rop, ref op2);
        }
        public static void __gmpz_ui_mul_ui(ref mpz_t rop, ulong op1, ulong op2)
        {
            __gmpz_init_set_ui(ref rop, op1);
            __gmpz_mul_ui(ref rop, ref rop, op2);
        }
        [DllImport("mpir.dll")] public static extern void __gmpz_ui_pow_ui(ref mpz_t rop, ulong op1, ulong op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_ui_sub(ref mpz_t rop, ulong op1, ref mpz_t op2);

        #endregion
    }
}
