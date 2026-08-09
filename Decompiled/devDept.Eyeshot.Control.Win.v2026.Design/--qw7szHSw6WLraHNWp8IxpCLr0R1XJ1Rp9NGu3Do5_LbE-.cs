using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

internal static class _0023_003Dqw7szHSw6WLraHNWp8IxpCLr0R1XJ1Rp9NGu3Do5_LbE_003D
{
	private static readonly bool _0023_003Dz9jrlnWk_003D;

	private static readonly bool _0023_003DzBxpHhQ0_003D;

	static _0023_003Dqw7szHSw6WLraHNWp8IxpCLr0R1XJ1Rp9NGu3Do5_LbE_003D()
	{
		OperatingSystem oSVersion = Environment.OSVersion;
		_0023_003Dz9jrlnWk_003D = oSVersion.Platform == PlatformID.Win32NT && oSVersion.Version >= new Version(6, 0);
		if (_0023_003Dzpxn36ZI0JdSG6YZsfv0FW4J7aTuhitjYuFm_0024t54hoWgV())
		{
			try
			{
				_0023_003DzBxpHhQ0_003D = _0023_003DzV0cP3tgdEL1zswasfETmQ5w_003D(oSVersion);
			}
			catch
			{
				_0023_003DzBxpHhQ0_003D = false;
			}
		}
	}

	public static bool _0023_003Dzpxn36ZI0JdSG6YZsfv0FW4J7aTuhitjYuFm_0024t54hoWgV()
	{
		return _0023_003Dz9jrlnWk_003D;
	}

	public static bool _0023_003Dz1uLJ_0024rUgsRl_X7lV_10_0024Q5BWc6keP5iL8DTAp_00240_003D()
	{
		return _0023_003DzBxpHhQ0_003D;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0023_003DzV0cP3tgdEL1zswasfETmQ5w_003D(OperatingSystem _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D.Platform == PlatformID.Win32NT && _0023_003Dz9jrlnWk_003D.Version < new Version(6, 2, 9200) && Process.GetCurrentProcess().SessionId == 0)
		{
			return false;
		}
		return true;
	}
}
