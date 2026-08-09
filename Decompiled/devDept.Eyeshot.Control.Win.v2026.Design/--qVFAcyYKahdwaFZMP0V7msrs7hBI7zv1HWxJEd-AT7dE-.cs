using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Win32.SafeHandles;

internal static class _0023_003DqVFAcyYKahdwaFZMP0V7msrs7hBI7zv1HWxJEd_0024AT7dE_003D
{
	[SecurityCritical]
	public sealed class _0023_003Dz3iPku7s_003D : SafeHandleZeroOrMinusOneIsInvalid
	{
		public override bool IsInvalid => handle == IntPtr.Zero;

		public _0023_003Dz3iPku7s_003D()
			: base(ownsHandle: true)
		{
		}

		protected override bool ReleaseHandle()
		{
			return _0023_003Dz0gi46baIQlHF_0024n1bBvJZiauoI2yZ(handle) == 0;
		}
	}

	public struct _0023_003Dz9jrlnWk_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003Dz9jrlnWk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzBxpHhQ0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dztgqm2r4_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzzKDx05I_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dz3iPku7s_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dz2X8kE24_003D;
	}

	[SecurityCritical]
	public sealed class _0023_003DzzKDx05I_003D : SafeHandleZeroOrMinusOneIsInvalid
	{
		public override bool IsInvalid => handle == IntPtr.Zero;

		public _0023_003DzzKDx05I_003D()
			: base(ownsHandle: true)
		{
		}

		protected override bool ReleaseHandle()
		{
			return _0023_003Dz0gi46baIQlHF_0024n1bBvJZiauoI2yZ(handle) == 0;
		}
	}

	public static void _0023_003DzXC7ohQwzGytn5KBhqOX0dJrInunX(uint _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D != 0)
		{
			uint num = _0023_003Dz9jrlnWk_003D;
			throw new InvalidOperationException(num.ToString());
		}
	}

	[DllImport("ncrypt.dll", EntryPoint = "NCryptFreeObject")]
	public static extern uint _0023_003Dz0gi46baIQlHF_0024n1bBvJZiauoI2yZ(IntPtr _0023_003Dz9jrlnWk_003D);

	[DllImport("ncrypt.dll", EntryPoint = "NCryptEncrypt")]
	public static extern uint _0023_003DzWxvrCkaPIwPE8k_uTe0nElTh2n_BOXOAvXEXWtQ_003D(_0023_003DzzKDx05I_003D _0023_003Dz9jrlnWk_003D, [MarshalAs(UnmanagedType.LPArray)] byte[] _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D, IntPtr _0023_003DzzKDx05I_003D, [MarshalAs(UnmanagedType.LPArray)] byte[] _0023_003Dz3iPku7s_003D, int _0023_003Dz2X8kE24_003D, out int _0023_003DzJGsRSpg_003D, int _0023_003Dz9I8ZVlc_003D);

	[DllImport("ncrypt.dll", CharSet = CharSet.Unicode, EntryPoint = "NCryptImportKey")]
	public static extern uint _0023_003DzmNuSwloqwECzAp5B8JjbOv0_003D(_0023_003Dz3iPku7s_003D _0023_003Dz9jrlnWk_003D, IntPtr _0023_003DzBxpHhQ0_003D, string _0023_003Dztgqm2r4_003D, IntPtr _0023_003DzzKDx05I_003D, out _0023_003DzzKDx05I_003D _0023_003Dz3iPku7s_003D, [MarshalAs(UnmanagedType.LPArray)] byte[] _0023_003Dz2X8kE24_003D, int _0023_003DzJGsRSpg_003D, uint _0023_003Dz9I8ZVlc_003D);

	[DllImport("ncrypt.dll", CharSet = CharSet.Unicode, EntryPoint = "NCryptOpenStorageProvider")]
	public static extern uint _0023_003DzfO8nZJJwLJq8nfiurFNTOPzcmzRW7rwgNdV3MeI_003D(out _0023_003Dz3iPku7s_003D _0023_003Dz9jrlnWk_003D, string _0023_003DzBxpHhQ0_003D, uint _0023_003Dztgqm2r4_003D);
}
