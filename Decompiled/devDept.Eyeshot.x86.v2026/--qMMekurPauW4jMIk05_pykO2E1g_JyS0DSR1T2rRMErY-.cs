using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Win32.SafeHandles;

internal static class _0023_003DqMMekurPauW4jMIk05_pykO2E1g_JyS0DSR1T2rRMErY_003D
{
	[SecurityCritical]
	public sealed class _0023_003DzcbLoSrg_003D : SafeHandleZeroOrMinusOneIsInvalid
	{
		public override bool IsInvalid => handle == IntPtr.Zero;

		public _0023_003DzcbLoSrg_003D()
			: base(ownsHandle: true)
		{
		}

		protected override bool ReleaseHandle()
		{
			return _0023_003DzhkIA5JuP97BF_0024fpoW_0024doGVtBO_m9(handle) == 0;
		}
	}

	public struct _0023_003Dzq80RbjQ_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003Dzq80RbjQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzZzVr6_0024U_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dz7hRN5Rg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzcbLoSrg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzqMLoHoQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzuwE9t4w_003D;
	}

	[SecurityCritical]
	public sealed class _0023_003DzqMLoHoQ_003D : SafeHandleZeroOrMinusOneIsInvalid
	{
		public override bool IsInvalid => handle == IntPtr.Zero;

		public _0023_003DzqMLoHoQ_003D()
			: base(ownsHandle: true)
		{
		}

		protected override bool ReleaseHandle()
		{
			return _0023_003DzhkIA5JuP97BF_0024fpoW_0024doGVtBO_m9(handle) == 0;
		}
	}

	public static void _0023_003DzeV_WHRuboyDpZCjQeklJ2EFzwsjg(uint _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D != 0)
		{
			uint num = _0023_003Dzq80RbjQ_003D;
			throw new InvalidOperationException(num.ToString());
		}
	}

	[DllImport("ncrypt.dll", EntryPoint = "NCryptFreeObject")]
	public static extern uint _0023_003DzhkIA5JuP97BF_0024fpoW_0024doGVtBO_m9(IntPtr _0023_003Dzq80RbjQ_003D);

	[DllImport("ncrypt.dll", EntryPoint = "NCryptEncrypt")]
	public static extern uint _0023_003Dz4i89NLVkc6mXummndb_CFkwHJsdjUFKoZJZF4o8_003D(_0023_003DzcbLoSrg_003D _0023_003Dzq80RbjQ_003D, [MarshalAs(UnmanagedType.LPArray)] byte[] _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D, IntPtr _0023_003DzcbLoSrg_003D, [MarshalAs(UnmanagedType.LPArray)] byte[] _0023_003DzqMLoHoQ_003D, int _0023_003DzuwE9t4w_003D, out int _0023_003DzoyRBT1A_003D, int _0023_003DzLaPeX80_003D);

	[DllImport("ncrypt.dll", CharSet = CharSet.Unicode, EntryPoint = "NCryptImportKey")]
	public static extern uint _0023_003DzIncISKKy7d5n_H1xoKUJUpY_003D(_0023_003DzqMLoHoQ_003D _0023_003Dzq80RbjQ_003D, IntPtr _0023_003DzZzVr6_0024U_003D, string _0023_003Dz7hRN5Rg_003D, IntPtr _0023_003DzcbLoSrg_003D, out _0023_003DzcbLoSrg_003D _0023_003DzqMLoHoQ_003D, [MarshalAs(UnmanagedType.LPArray)] byte[] _0023_003DzuwE9t4w_003D, int _0023_003DzoyRBT1A_003D, uint _0023_003DzLaPeX80_003D);

	[DllImport("ncrypt.dll", CharSet = CharSet.Unicode, EntryPoint = "NCryptOpenStorageProvider")]
	public static extern uint _0023_003Dz_pdPMp6ltfWYkfnIOTInJVtPyC690OnhtaREirA_003D(out _0023_003DzqMLoHoQ_003D _0023_003Dzq80RbjQ_003D, string _0023_003DzZzVr6_0024U_003D, uint _0023_003Dz7hRN5Rg_003D);
}
