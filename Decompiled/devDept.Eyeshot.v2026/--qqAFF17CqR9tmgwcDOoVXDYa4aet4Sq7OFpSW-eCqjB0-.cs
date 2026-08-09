using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

internal static class _0023_003DqqAFF17CqR9tmgwcDOoVXDYa4aet4Sq7OFpSW_0024eCqjB0_003D
{
	private static readonly bool _0023_003DziDLVpbY_003D;

	private static readonly bool _0023_003Dz5rQzobg_003D;

	static _0023_003DqqAFF17CqR9tmgwcDOoVXDYa4aet4Sq7OFpSW_0024eCqjB0_003D()
	{
		OperatingSystem oSVersion = Environment.OSVersion;
		_0023_003DziDLVpbY_003D = oSVersion.Platform == PlatformID.Win32NT && oSVersion.Version >= new Version(6, 0);
		if (_0023_003DzxKWD_T5_0024au9I7Tq2xZKviqzExvMSp04gbitd1k0akJ_0024u())
		{
			try
			{
				_0023_003Dz5rQzobg_003D = _0023_003DzxQXz2_0024lRliEGdTg7xR1MBH8_003D(oSVersion);
			}
			catch
			{
				_0023_003Dz5rQzobg_003D = false;
			}
		}
	}

	public static bool _0023_003DzxKWD_T5_0024au9I7Tq2xZKviqzExvMSp04gbitd1k0akJ_0024u()
	{
		return _0023_003DziDLVpbY_003D;
	}

	public static bool _0023_003DzTAWnZbAiOehvY43usoqJrLYW7A4rGUTC4ZIVI9c_003D()
	{
		return _0023_003Dz5rQzobg_003D;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0023_003DzxQXz2_0024lRliEGdTg7xR1MBH8_003D(OperatingSystem _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D.Platform == PlatformID.Win32NT && _0023_003DziDLVpbY_003D.Version < new Version(6, 2, 9200) && Process.GetCurrentProcess().SessionId == 0)
		{
			return false;
		}
		return true;
	}
}
