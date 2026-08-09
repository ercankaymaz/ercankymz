using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Win32.SafeHandles;

internal static class _0023_003Dqq5mflhyyhw0UGwZzM_0024dunCCCmDIPSF9poCH4nOMZuuo_003D
{
	[SecurityCritical]
	public sealed class _0023_003DzR58imxw_003D : SafeHandleZeroOrMinusOneIsInvalid
	{
		public override bool IsInvalid => handle == IntPtr.Zero;

		public _0023_003DzR58imxw_003D()
			: base(ownsHandle: true)
		{
		}

		protected override bool ReleaseHandle()
		{
			return _0023_003DzIQtLV9mPcxOES_b_3g8OVddE_0024efz(handle) == 0;
		}
	}

	public struct _0023_003DziDLVpbY_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003DziDLVpbY_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dz5rQzobg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzAvn2b38_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzR58imxw_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzmQTFaQA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzWYPqg2E_003D;
	}

	[SecurityCritical]
	public sealed class _0023_003DzmQTFaQA_003D : SafeHandleZeroOrMinusOneIsInvalid
	{
		public override bool IsInvalid => handle == IntPtr.Zero;

		public _0023_003DzmQTFaQA_003D()
			: base(ownsHandle: true)
		{
		}

		protected override bool ReleaseHandle()
		{
			return _0023_003DzIQtLV9mPcxOES_b_3g8OVddE_0024efz(handle) == 0;
		}
	}

	public static void _0023_003DzvkgdlHxqAhiCw59i36euyPQ0WoRB(uint _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D != 0)
		{
			uint num = _0023_003DziDLVpbY_003D;
			throw new InvalidOperationException(num.ToString());
		}
	}

	[DllImport("ncrypt.dll", EntryPoint = "NCryptFreeObject")]
	public static extern uint _0023_003DzIQtLV9mPcxOES_b_3g8OVddE_0024efz(IntPtr _0023_003DziDLVpbY_003D);

	[DllImport("ncrypt.dll", EntryPoint = "NCryptEncrypt")]
	public static extern uint _0023_003DzLx13jGrd2ekPcs8Lnnh_ofc9w58zUjPZPtTnY9I_003D(_0023_003DzR58imxw_003D _0023_003DziDLVpbY_003D, [MarshalAs(UnmanagedType.LPArray)] byte[] _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D, IntPtr _0023_003DzR58imxw_003D, [MarshalAs(UnmanagedType.LPArray)] byte[] _0023_003DzmQTFaQA_003D, int _0023_003DzWYPqg2E_003D, out int _0023_003DzEWLeis8_003D, int _0023_003DzbfrNXYE_003D);

	[DllImport("ncrypt.dll", CharSet = CharSet.Unicode, EntryPoint = "NCryptImportKey")]
	public static extern uint _0023_003DzNuDfEB4tJ9AmDk3MqM2Au9M_003D(_0023_003DzmQTFaQA_003D _0023_003DziDLVpbY_003D, IntPtr _0023_003Dz5rQzobg_003D, string _0023_003DzAvn2b38_003D, IntPtr _0023_003DzR58imxw_003D, out _0023_003DzR58imxw_003D _0023_003DzmQTFaQA_003D, [MarshalAs(UnmanagedType.LPArray)] byte[] _0023_003DzWYPqg2E_003D, int _0023_003DzEWLeis8_003D, uint _0023_003DzbfrNXYE_003D);

	[DllImport("ncrypt.dll", CharSet = CharSet.Unicode, EntryPoint = "NCryptOpenStorageProvider")]
	public static extern uint _0023_003Dzz1Hc1XTJ5F_0024OFtjJUGKkkPY1r0iOmNguNHGuRYs_003D(out _0023_003DzmQTFaQA_003D _0023_003DziDLVpbY_003D, string _0023_003Dz5rQzobg_003D, uint _0023_003DzAvn2b38_003D);
}
