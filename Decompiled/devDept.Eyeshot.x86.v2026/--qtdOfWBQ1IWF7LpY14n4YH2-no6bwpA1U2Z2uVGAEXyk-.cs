using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

internal static class _0023_003DqtdOfWBQ1IWF7LpY14n4YH2_0024no6bwpA1U2Z2uVGAEXyk_003D
{
	private static readonly bool _0023_003Dzq80RbjQ_003D;

	private static readonly bool _0023_003DzZzVr6_0024U_003D;

	static _0023_003DqtdOfWBQ1IWF7LpY14n4YH2_0024no6bwpA1U2Z2uVGAEXyk_003D()
	{
		OperatingSystem oSVersion = Environment.OSVersion;
		_0023_003Dzq80RbjQ_003D = oSVersion.Platform == PlatformID.Win32NT && oSVersion.Version >= new Version(6, 0);
		if (_0023_003DzlFQ0kKALFgjWvW1rCvaAZpGSGWYPHlnpLn1QhSF79VHG())
		{
			try
			{
				_0023_003DzZzVr6_0024U_003D = _0023_003Dz0lvUDcwP01xWtMRW4VEUc7Y_003D(oSVersion);
			}
			catch
			{
				_0023_003DzZzVr6_0024U_003D = false;
			}
		}
	}

	public static bool _0023_003DzlFQ0kKALFgjWvW1rCvaAZpGSGWYPHlnpLn1QhSF79VHG()
	{
		return _0023_003Dzq80RbjQ_003D;
	}

	public static bool _0023_003DzllpZWyqRACIcqjem77z6EdHw45Y6_zHj55UKpb4_003D()
	{
		return _0023_003DzZzVr6_0024U_003D;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0023_003Dz0lvUDcwP01xWtMRW4VEUc7Y_003D(OperatingSystem _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D.Platform == PlatformID.Win32NT && _0023_003Dzq80RbjQ_003D.Version < new Version(6, 2, 9200) && Process.GetCurrentProcess().SessionId == 0)
		{
			return false;
		}
		return true;
	}
}
