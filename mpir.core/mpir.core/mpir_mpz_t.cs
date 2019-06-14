using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace mpir.core.internals
{
    using mpz_t = IntPtr;
    public static partial class mpir
    {
        #region init
        [DllImport("mpir.dll")] public static extern void __gmpz_init(ref mpz_t rop);
        [DllImport("mpir.dll")] public static extern void __gmpz_init_set(ref mpz_t rop, ref mpz_t op);
        [DllImport("mpir.dll")] public static extern void __gmpz_init_set_si(ref mpz_t rop, long op);
        [DllImport("mpir.dll")] public static extern void __gmpz_init_set_str(ref mpz_t rop, [MarshalAs(UnmanagedType.LPStr)] string str, int @base);
        [DllImport("mpir.dll")] public static extern void __gmpz_init_set_ui(ref mpz_t rop, ulong op);
        #endregion

        #region clear
        [DllImport("mpir.dll")] public static extern void __gmpz_clear(ref mpz_t rop);
        #endregion

        #region compare
        [DllImport("mpir.dll")] public static extern int __gmpz_cmp(ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern int __gmpz_cmp_si(ref mpz_t op1, long op2);
        [DllImport("mpir.dll")] public static extern int __gmpz_cmp_ui(ref mpz_t op1, ulong op2);
        #endregion

        #region get
        [DllImport("mpir.dll")] public static extern long __gmpz_get_si(ref mpz_t op);
        [DllImport("mpir.dll")] public static extern void __gmpz_get_str(StringBuilder rop, int @base, ref mpz_t op);
        [DllImport("mpir.dll")] public static extern ulong __gmpz_get_ui(ref mpz_t op);
        #endregion

        #region add
        [DllImport("mpir.dll")] public static extern void __gmpz_add(ref mpz_t rop, ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_add_ui(ref mpz_t rop, ref mpz_t op1, ulong op2);
        #endregion

        #region sub
        [DllImport("mpir.dll")] public static extern void __gmpz_sub(ref mpz_t rop, ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_sub_ui(ref mpz_t rop, ref mpz_t op1, ulong op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_ui_sub(ref mpz_t rop, ulong op1, ref mpz_t op2);
        #endregion

        #region mult
        [DllImport("mpir.dll")] public static extern void __gmpz_mul(ref mpz_t rop, ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_mul_si(ref mpz_t rop, ref mpz_t op1, long op2);
        public static void __gmpz_si_mul_si(ref mpz_t rop, long op1, long op2)
        {
            __gmpz_init_set_si(ref rop, op1);
            __gmpz_mul_si(ref rop, ref rop, op2);
        }
        [DllImport("mpir.dll")] public static extern void __gmpz_mul_ui(ref mpz_t rop, ref mpz_t op1, ulong op2);
        public static void __gmpz_ui_mul_ui(ref mpz_t rop, ulong op1, ulong op2)
        {
            __gmpz_init_set_ui(ref rop, op1);
            __gmpz_mul_ui(ref rop, ref rop, op2);
        }
        #endregion

        #region div
        [DllImport("mpir.dll")] public static extern void __gmpz_fdiv_q(ref mpz_t rop, ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_fdiv_q_ui(ref mpz_t rop, ref mpz_t op1, ulong op2);
        #endregion

        #region mod
        [DllImport("mpir.dll")] public static extern void __gmpz_mod(ref mpz_t rop, ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_mod_ui(ref mpz_t rop, ref mpz_t op1, ulong op2);
        public static void __gmpz_ui_mod(ref mpz_t rop, ulong op1, ref mpz_t op2)
        {
            __gmpz_init_set_ui(ref rop, op1);
            __gmpz_mod(ref rop, ref rop, ref op2);
        }
        #endregion

        #region pow
        [DllImport("mpir.dll")] public static extern void __gmpz_pow_ui(ref mpz_t rop, ref mpz_t op1, ulong op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_ui_pow_ui(ref mpz_t rop, ulong op1, ulong op2);
        #endregion

        #region addmul
        [DllImport("mpir.dll")] public static extern void __mpz_addmul(ref mpz_t rop, ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern void __mpz_addmul_ui(ref mpz_t rop, ref mpz_t op1, ulong op2);
        #endregion

        #region submul
        [DllImport("mpir.dll")] public static extern void __mpz_submul(ref mpz_t rop, ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern void __mpz_submul_ui(ref mpz_t rop, ref mpz_t op1, ulong op2);
        #endregion

        #region gcd
        [DllImport("mpir.dll")] public static extern void __gmpz_gcd(ref mpz_t rop, ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_gcd_ui(ref mpz_t rop, ref mpz_t op1, ulong op2);
        #endregion

        #region lcm
        [DllImport("mpir.dll")] public static extern void __gmpz_lcm(ref mpz_t rop, ref mpz_t op1, ref mpz_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpz_lcm_ui(ref mpz_t rop, ref mpz_t op1, ulong op2);
        #endregion

        [DllImport("mpir.dll")] public static extern void __gmpz_abs(ref mpz_t rop, ref mpz_t op);
        [DllImport("mpir.dll")] public static extern void __gmpz_fac_ui(ref mpz_t rop, ulong op);
        [DllImport("mpir.dll")] public static extern void __gmpz_neg(ref mpz_t rop, ref mpz_t op);
        [DllImport("mpir.dll")] public static extern uint __gmpz_sizeinbase(ref mpz_t op, int @base);
    }
}
