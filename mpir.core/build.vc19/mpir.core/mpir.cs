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
        [DllImport("mpir.dll")] public static extern void __gmpz_add_ui(ref mpz_t rop, mpz_t op1, uint op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_clear(ref mpz_t integer);
        [DllImport("mpir.dll")] public static extern double __gmpz_get_d(ref mpz_t op);
        [DllImport("mpir.dll")] public static extern double __gmpz_get_d_2exp(ref int exp, ref mpz_t op);
        [DllImport("mpir.dll")] public static extern int __gmpz_get_si(out int result, ref mpz_t op);
        [DllImport("mpir.dll")] public static extern int __gmpz_get_str(ref string rop, int @base, ref mpz_t op);
        [DllImport("mpir.dll")] public static extern long __gmpz_get_sx(ref mpz_t op);
        [DllImport("mpir.dll")] public static extern uint __gmpz_get_ui(ref mpz_t op);
        [DllImport("mpir.dll")] public static extern ulong __gmpz_get_ux(ref mpz_t op);
        [DllImport("mpir.dll")] public static extern void __gmpz_init(ref mpz_t integer);
        [DllImport("mpir.dll")] public static extern void __gmpz_init_set_d(ref mpz_t rop, double op);
        [DllImport("mpir.dll")] public static extern void __gmpz_init_set_si(ref mpz_t rop, int op);
        [DllImport("mpir.dll")] public static extern void __gmpz_init_set_str(ref mpz_t rop, string str, int @base);
        [DllImport("mpir.dll")] public static extern void __gmpz_init_set_sx(ref mpz_t rop, long op);
        [DllImport("mpir.dll")] public static extern void __gmpz_init_set_ui(ref mpz_t rop, uint op);
        [DllImport("mpir.dll")] public static extern void __gmpz_init_set_ux(ref mpz_t rop, ulong op);
        [DllImport("mpir.dll")] public static extern void __gmpz_sub(ref mpz_t rop, ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_sub_ui(ref mpz_t rop, ref mpz_t op1, uint op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_ui_sub(ref mpz_t rop, uint op1, ref mpz_t op2);

        #endregion
    }
}
