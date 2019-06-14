using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace mpir.core.internals
{
    using mpf_t = IntPtr;
    public static partial class mpir
    {
        #region init
        [DllImport("mpir.dll")] public static extern void __gmpf_init(ref mpf_t rop);
        [DllImport("mpir.dll")] public static extern void __gmpf_init_set(ref mpf_t rop, ref mpf_t op);
        //[DllImport("mpir.dll")] public static extern void __gmpf_init_set_d(ref mpf_t rop, double op);
        //[DllImport("mpir.dll")] public static extern void __gmpf_init_set_si(ref mpf_t rop, long op);
        [DllImport("mpir.dll")] public static extern void __gmpf_init_set_str(ref mpf_t rop, [MarshalAs(UnmanagedType.LPStr)] string str, int @base);
        //[DllImport("mpir.dll")] public static extern void __gmpf_init_set_ui(ref mpf_t rop, ulong op);
        #endregion

        #region clear
        [DllImport("mpir.dll")] public static extern void __gmpf_clear(ref mpf_t rop);
        #endregion

        #region compare
        [DllImport("mpir.dll")] public static extern int __gmpf_cmp(ref mpf_t op1, ref mpf_t op2);
        [DllImport("mpir.dll")] public static extern int __gmpf_cmp_d(ref mpf_t op1, double op2);
        [DllImport("mpir.dll")] public static extern int __gmpf_cmp_si(ref mpf_t op1, long op2);
        [DllImport("mpir.dll")] public static extern int __gmpf_cmp_ui(ref mpf_t op1, ulong op2);
        #endregion

        #region get
        [DllImport("mpir.dll")] public static extern double __gmpf_get_d(ref mpf_t op);
        [DllImport("mpir.dll")] public static extern long __gmpf_get_si(ref mpf_t op);
        [DllImport("mpir.dll")] public static extern void __gmpf_get_str(StringBuilder rop, out int exp, int @base, uint n_digits, ref mpf_t op);
        [DllImport("mpir.dll")] public static extern ulong __gmpf_get_ui(ref mpf_t op);
        #endregion

        #region add
        [DllImport("mpir.dll")] public static extern void __gmpf_add(ref mpf_t rop, ref mpf_t op1, ref mpf_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpf_add_ui(ref mpf_t rop, ref mpf_t op1, ulong op2);
        #endregion

        #region sub
        [DllImport("mpir.dll")] public static extern void __gmpf_sub(ref mpf_t rop, ref mpf_t op1, ref mpf_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpf_sub_ui(ref mpf_t rop, ref mpf_t op1, ulong op2);
        [DllImport("mpir.dll")] public static extern void __gmpf_ui_sub(ref mpf_t rop, ulong op1, ref mpf_t op2);
        #endregion

        #region mult
        [DllImport("mpir.dll")] public static extern void __gmpf_mul(ref mpf_t rop, ref mpf_t op1, ref mpf_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpf_mul_ui(ref mpf_t rop, ref mpf_t op1, ulong op2);
        public static void __gmpf_ui_mul_ui(ref mpf_t rop, ulong op1, ulong op2)
        {
            __gmpf_init_set_str(ref rop, op1.ToString(), 10); //__gmpf_init_set_ui(ref rop, op1);
            __gmpf_mul_ui(ref rop, ref rop, op2);
        }
        #endregion

        #region div
        [DllImport("mpir.dll")] public static extern void __gmpf_div(ref mpf_t rop, ref mpf_t op1, ref mpf_t op2);
        [DllImport("mpir.dll")] public static extern void __gmpf_div_ui(ref mpf_t rop, ref mpf_t op1, ulong op2);
        [DllImport("mpir.dll")] public static extern void __gmpf_ui_div(ref mpf_t rop, ulong op1, ref mpf_t op2);
        public static void __gmpf_ui_div_ui(ref mpf_t rop, ulong op1, ulong op2)
        {
            __gmpf_init_set_str(ref rop, op1.ToString(), 10); //__gmpf_init_set_ui(ref rop, op1);
            __gmpf_div_ui(ref rop, ref rop, op2);
        }
        #endregion

        #region sqrt
        [DllImport("mpir.dll")] public static extern void __gmpf_sqrt(ref mpf_t rop, ref mpf_t op);
        [DllImport("mpir.dll")] public static extern void __gmpf_sqrt_ui(ref mpf_t rop, ulong op);
        #endregion

        #region pow
        [DllImport("mpir.dll")] public static extern void __gmpf_pow_ui(ref mpf_t rop, ref mpf_t op1, ulong op2);
        #endregion

        #region round
        [DllImport("mpir.dll")] public static extern void __gmpf_ceil(ref mpf_t rop, ref mpf_t op);
        [DllImport("mpir.dll")] public static extern void __gmpf_floor(ref mpf_t rop, ref mpf_t op);
        [DllImport("mpir.dll")] public static extern void __gmpf_trunc(ref mpf_t rop, ref mpf_t op);
        #endregion

        [DllImport("mpir.dll")] public static extern void __gmpf_abs(ref mpf_t rop, ref mpf_t op);
        [DllImport("mpir.dll")] public static extern void __gmpf_neg(ref mpf_t rop, ref mpf_t op);

    }
}
