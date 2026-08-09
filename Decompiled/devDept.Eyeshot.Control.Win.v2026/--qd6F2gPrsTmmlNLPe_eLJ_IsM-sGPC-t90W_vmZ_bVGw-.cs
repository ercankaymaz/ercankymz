using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

internal static class _0023_003Dqd6F2gPrsTmmlNLPe_eLJ_IsM_0024sGPC_0024t90W_vmZ_bVGw_003D
{
	private static readonly bool _0023_003DzjYYAPCA_003D;

	private static readonly bool _0023_003DzVC9FBdo_003D;

	static _0023_003Dqd6F2gPrsTmmlNLPe_eLJ_IsM_0024sGPC_0024t90W_vmZ_bVGw_003D()
	{
		OperatingSystem oSVersion = Environment.OSVersion;
		_0023_003DzjYYAPCA_003D = oSVersion.Platform == PlatformID.Win32NT && oSVersion.Version >= new Version(6, 0);
		if (_0023_003DzaAWBgRtawwrr21bwlFWs7ukLA0F4DO0uhgg6WVUsxqLt())
		{
			try
			{
				_0023_003DzVC9FBdo_003D = _0023_003DzPXPyfpiTijajL3Bm931sZI8_003D(oSVersion);
			}
			catch
			{
				_0023_003DzVC9FBdo_003D = false;
			}
		}
	}

	public static bool _0023_003DzaAWBgRtawwrr21bwlFWs7ukLA0F4DO0uhgg6WVUsxqLt()
	{
		return _0023_003DzjYYAPCA_003D;
	}

	public static bool _0023_003Dzh1NSeks7GQEzVwpTP_00246hwS30dBGfDwRJdXAPZJs_003D()
	{
		return _0023_003DzVC9FBdo_003D;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0023_003DzPXPyfpiTijajL3Bm931sZI8_003D(OperatingSystem _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D.Platform == PlatformID.Win32NT && _0023_003DzjYYAPCA_003D.Version < new Version(6, 2, 9200) && Process.GetCurrentProcess().SessionId == 0)
		{
			return false;
		}
		return true;
	}
}
