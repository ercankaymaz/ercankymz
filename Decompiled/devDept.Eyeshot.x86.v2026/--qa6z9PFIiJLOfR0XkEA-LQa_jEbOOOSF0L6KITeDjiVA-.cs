using System;
using System.Reflection;
using System.Security;

internal static class _0023_003Dqa6z9PFIiJLOfR0XkEA_0024LQa_jEbOOOSF0L6KITeDjiVA_003D
{
	private static readonly bool _0023_003Dzq80RbjQ_003D;

	static _0023_003Dqa6z9PFIiJLOfR0XkEA_0024LQa_jEbOOOSF0L6KITeDjiVA_003D()
	{
		_0023_003Dzq80RbjQ_003D = _0023_003DzaeNusmucZZ0PphvUi5Qy61kVa2M_0024();
	}

	private static bool _0023_003DzaeNusmucZZ0PphvUi5Qy61kVa2M_0024()
	{
		try
		{
			if (Environment.Version.Major < 4)
			{
				return false;
			}
			Assembly assembly = typeof(_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D).Assembly;
			Assembly assembly2 = typeof(SecurityCriticalAttribute).Assembly;
			bool result = false;
			object[] customAttributes = assembly.GetCustomAttributes(inherit: false);
			foreach (object obj in customAttributes)
			{
				if (obj is AllowPartiallyTrustedCallersAttribute)
				{
					result = true;
					continue;
				}
				Type type = obj.GetType();
				if (type.Assembly == assembly2 && _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527948).Equals(type.FullName, StringComparison.Ordinal) && (byte)type.GetProperty(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528033)).GetValue(obj, null) != 2)
				{
					return false;
				}
			}
			return result;
		}
		catch
		{
			return false;
		}
	}

	public static bool _0023_003Dziv0obqa9KuHlQlXfp_0024xK88T7rEmB()
	{
		return _0023_003Dzq80RbjQ_003D;
	}
}
