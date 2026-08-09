using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using devDept.Eyeshot.Control.MultiTouch.Interop;

internal static class _0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v
{
	public delegate uint _0023_003DzVMxxQ8H7UieE(IntPtr _0023_003DzVg1BG_0024g_003D, int _0023_003Dz1xK0BLg_003D, IntPtr _0023_003DzpZzvkAs_003D, IntPtr _0023_003DzafzCBBQ_003D);

	public enum _0023_003DztnVUK3HdJg3cERCIBQ_003D_003D
	{

	}

	public enum _0023_003DzvHuFgA27z78J : uint
	{

	}

	public struct _0023_003DzykQb7wpRwyKYM5sR3VpQ2BhxS_5Y
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003Dz_ZC5Ts0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003DzfVIARlg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IntPtr _0023_003DzsjYp3p4_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public POINTS _0023_003DzrFkXJJxZyCxL;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public uint _0023_003DziNnB3C000_0024Tg;
	}

	[DllImport("User32", EntryPoint = "SetProcessDPIAware")]
	public static extern bool _0023_003DzCZwVI6M7l3Bj();

	[DllImport("User32", EntryPoint = "IsWindow")]
	public static extern bool _0023_003Dzl39Y8_0024o_003D(IntPtr _0023_003DzVg1BG_0024g_003D);

	[DllImport("User32", EntryPoint = "ScreenToClient")]
	public static extern bool _0023_003Dz3fa9dBqDESKU(IntPtr _0023_003DzVg1BG_0024g_003D, ref POINT _0023_003DzCldu5gNueqKB);

	[DllImport("User32", EntryPoint = "SetWindowLongPtr")]
	public static extern IntPtr _0023_003Dz006MPQkKdlcK(IntPtr _0023_003DzVg1BG_0024g_003D, int _0023_003Dzj_0024aMA6k_003D, _0023_003DzVMxxQ8H7UieE _0023_003DzEupkiIpWzVpN);

	[DllImport("User32", EntryPoint = "SetWindowLong")]
	public static extern IntPtr _0023_003Dz2ZhGvdE_003D(IntPtr _0023_003DzVg1BG_0024g_003D, int _0023_003Dzj_0024aMA6k_003D, _0023_003DzVMxxQ8H7UieE _0023_003DzEupkiIpWzVpN);

	[DllImport("User32", EntryPoint = "CallWindowProc")]
	public static extern uint _0023_003DzoC_gT1LhHqeh(IntPtr _0023_003Dzdrc3_0024i9Pgnj8, IntPtr _0023_003DzVg1BG_0024g_003D, int _0023_003Dz1xK0BLg_003D, IntPtr _0023_003DzpZzvkAs_003D, IntPtr _0023_003DzafzCBBQ_003D);

	[DllImport("User32", EntryPoint = "GetSystemMetrics")]
	public static extern int _0023_003Dz7zcHXTcW2z_00247vpDbkSCcSwU_003D(_0023_003DztnVUK3HdJg3cERCIBQ_003D_003D _0023_003DznRRpGN8_003D);

	[DllImport("User32", EntryPoint = "RegisterTouchWindow")]
	public static extern bool _0023_003DzQz7n5NebgFWF(IntPtr _0023_003DzVg1BG_0024g_003D, _0023_003DzvHuFgA27z78J _0023_003Dz4xY59ps_003D);

	[DllImport("User32", EntryPoint = "UnregisterTouchWindow")]
	public static extern bool _0023_003Dz42MuSQgUnZyd(IntPtr _0023_003DzVg1BG_0024g_003D);

	[DllImport("User32", EntryPoint = "IsTouchWindow")]
	public static extern bool _0023_003DzbzyQimOIi5_0024q(IntPtr _0023_003DzVg1BG_0024g_003D, out uint _0023_003Dz6_qLIrU_003D);

	[DllImport("User32", EntryPoint = "GetTouchInputInfo")]
	public static extern bool _0023_003DzLR17p7FVRk5L(IntPtr _0023_003Dzy_0024mkymn_QqCc, int _0023_003DzlY_MFjg_003D, [In][Out] TOUCHINPUT[] _0023_003DzHvU_0024vt4_003D, int _0023_003Dz_ZC5Ts0_003D);

	[DllImport("User32", EntryPoint = "CloseTouchInputHandle")]
	public static extern void _0023_003DzQucVDhM6LxTEPEgZKQ_003D_003D(IntPtr _0023_003DzNAnADu0_003D);

	[DllImport("User32", EntryPoint = "SetProp")]
	public static extern bool _0023_003DzU2ecfJM_003D(IntPtr _0023_003DzVg1BG_0024g_003D, string _0023_003DzCih1KpQ_003D, IntPtr _0023_003DzXD7mrxo_003D);

	public static ushort _0023_003DzizbxK0cPigbL(uint _0023_003DzKbehXyo_003D)
	{
		return (ushort)_0023_003DzKbehXyo_003D;
	}

	public static ushort _0023_003DzsmbrAmDVouwi(uint _0023_003DzKbehXyo_003D)
	{
		return (ushort)(_0023_003DzKbehXyo_003D >> 16);
	}

	public static uint _0023_003Dz_ILf_BktQo_Y(ulong _0023_003DzKbehXyo_003D)
	{
		return (uint)(_0023_003DzKbehXyo_003D & 0xFFFFFFFFu);
	}

	public static uint _0023_003DzitlDEou_vdz3(ulong _0023_003DzKbehXyo_003D)
	{
		return (uint)((_0023_003DzKbehXyo_003D >> 32) & 0xFFFFFFFFu);
	}

	public static short _0023_003DzizbxK0cPigbL(int _0023_003DzKbehXyo_003D)
	{
		return (short)_0023_003DzKbehXyo_003D;
	}

	public static short _0023_003DzsmbrAmDVouwi(int _0023_003DzKbehXyo_003D)
	{
		return (short)(_0023_003DzKbehXyo_003D >> 16);
	}

	public static int _0023_003Dz_ILf_BktQo_Y(long _0023_003DzKbehXyo_003D)
	{
		return (int)_0023_003DzKbehXyo_003D;
	}

	public static int _0023_003DzitlDEou_vdz3(long _0023_003DzKbehXyo_003D)
	{
		return (int)(_0023_003DzKbehXyo_003D >> 32);
	}

	[DllImport("User32", EntryPoint = "SetGestureConfig")]
	public static extern bool _0023_003Dz1dxd_00247YHT5vY(IntPtr _0023_003Dziaz9rYc_003D, uint _0023_003Dz32cxLQrSh3rE, uint _0023_003DzI97DtEsKW0DX, GESTURECONFIG[] _0023_003DzT16gDfI_hvmn, uint _0023_003Dz_ZC5Ts0_003D);

	[DllImport("User32", EntryPoint = "GetGestureInfo")]
	public static extern bool _0023_003DzB_0024b_0024Gt6nyAdQ(IntPtr _0023_003DztFjpdtK7YFa4, ref GESTUREINFO _0023_003Dz8YZToW83wH5j);

	public static ushort _0023_003DzX6CwYKguIcX_0024aZfCWu0DUd6FLSaoXj3PvoQlLFHx3UiZ(ushort _0023_003DzIa5IVBg_003D)
	{
		return (ushort)(((double)(int)_0023_003DzIa5IVBg_003D + 6.2831853) / 12.5663706 * 65535.0);
	}

	public static double _0023_003DzYEYlCZJxFeH2HJyJN3dT0Oynhr02ZTAeYYDk_0024xa_0024lvyH(ushort _0023_003DzIa5IVBg_003D)
	{
		return (double)(int)_0023_003DzIa5IVBg_003D / 65535.0 * 4.0 * 3.14159265 - 6.2831853;
	}

	[DllImport("User32", EntryPoint = "CloseGestureInfoHandle")]
	public static extern bool _0023_003Dz_0024F4IK44IRRf3(IntPtr _0023_003DztFjpdtK7YFa4);
}
