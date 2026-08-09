using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Win32.SafeHandles;

internal static class _0023_003DqIezmeNnHofVEbOTAbpKGB0VQKLhxLixo6_0024RbkwFivws_003D
{
	[SecurityCritical]
	public sealed class _0023_003DzTFNDoh0_003D : SafeHandleZeroOrMinusOneIsInvalid
	{
		public override bool IsInvalid => handle == IntPtr.Zero;

		public _0023_003DzTFNDoh0_003D()
			: base(ownsHandle: true)
		{
		}

		protected override bool ReleaseHandle()
		{
			return _0023_003DzxvvV7YLkQbeaJyVUG0_0024_0024igGPsCzq(handle) == 0;
		}
	}

	[SecurityCritical]
	public sealed class _0023_003Dzf4Pqh9s_003D : SafeHandleZeroOrMinusOneIsInvalid
	{
		public override bool IsInvalid => handle == IntPtr.Zero;

		public _0023_003Dzf4Pqh9s_003D()
			: base(ownsHandle: true)
		{
		}

		protected override bool ReleaseHandle()
		{
			return _0023_003DzxvvV7YLkQbeaJyVUG0_0024_0024igGPsCzq(handle) == 0;
		}
	}

	public struct _0023_003DzjYYAPCA_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003DzjYYAPCA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzVC9FBdo_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzwBouG0w_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dzf4Pqh9s_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzTFNDoh0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzraVZG9g_003D;
	}

	public static void _0023_003DzOlk5vG0kahh9vm4_dlcIZlf1u7qs(uint _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D != 0)
		{
			uint num = _0023_003DzjYYAPCA_003D;
			throw new InvalidOperationException(num.ToString());
		}
	}

	[DllImport("ncrypt.dll", EntryPoint = "NCryptFreeObject")]
	public static extern uint _0023_003DzxvvV7YLkQbeaJyVUG0_0024_0024igGPsCzq(IntPtr _0023_003DzjYYAPCA_003D);

	[DllImport("ncrypt.dll", EntryPoint = "NCryptEncrypt")]
	public static extern uint _0023_003Dz4WN8fb_aRs_82h61k98gGGo37Cwpc9vkeKAWtjQ_003D(_0023_003Dzf4Pqh9s_003D _0023_003DzjYYAPCA_003D, [MarshalAs(UnmanagedType.LPArray)] byte[] _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D, IntPtr _0023_003Dzf4Pqh9s_003D, [MarshalAs(UnmanagedType.LPArray)] byte[] _0023_003DzTFNDoh0_003D, int _0023_003DzraVZG9g_003D, out int _0023_003DzRoqMfFc_003D, int _0023_003Dz1SmHC4c_003D);

	[DllImport("ncrypt.dll", CharSet = CharSet.Unicode, EntryPoint = "NCryptImportKey")]
	public static extern uint _0023_003Dz_536VGQro1BSsDqRpuyuBJM_003D(_0023_003DzTFNDoh0_003D _0023_003DzjYYAPCA_003D, IntPtr _0023_003DzVC9FBdo_003D, string _0023_003DzwBouG0w_003D, IntPtr _0023_003Dzf4Pqh9s_003D, out _0023_003Dzf4Pqh9s_003D _0023_003DzTFNDoh0_003D, [MarshalAs(UnmanagedType.LPArray)] byte[] _0023_003DzraVZG9g_003D, int _0023_003DzRoqMfFc_003D, uint _0023_003Dz1SmHC4c_003D);

	[DllImport("ncrypt.dll", CharSet = CharSet.Unicode, EntryPoint = "NCryptOpenStorageProvider")]
	public static extern uint _0023_003DzbZNyXTvDJw2kNBCUaOyUUGHT7vt95sLwfRi_0vc_003D(out _0023_003DzTFNDoh0_003D _0023_003DzjYYAPCA_003D, string _0023_003DzVC9FBdo_003D, uint _0023_003DzwBouG0w_003D);
}
