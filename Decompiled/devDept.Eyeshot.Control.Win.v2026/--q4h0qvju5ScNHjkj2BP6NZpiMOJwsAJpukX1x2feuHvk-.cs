using System;
using System.Reflection;
using System.Security;

internal static class _0023_003Dq4h0qvju5ScNHjkj2BP6NZpiMOJwsAJpukX1x2feuHvk_003D
{
	private static readonly bool _0023_003DzjYYAPCA_003D;

	static _0023_003Dq4h0qvju5ScNHjkj2BP6NZpiMOJwsAJpukX1x2feuHvk_003D()
	{
		_0023_003DzjYYAPCA_003D = _0023_003DzcHm_QjaXVOcV9eKFD_Rxk4Dzzo07();
	}

	private static bool _0023_003DzcHm_QjaXVOcV9eKFD_Rxk4Dzzo07()
	{
		try
		{
			if (Environment.Version.Major < 4)
			{
				return false;
			}
			Assembly assembly = typeof(_0023_003Dqdjy057pni6pqXXBRENfBqjtjX_1wcO_0024_TAnJhYzAcPo_003D).Assembly;
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
				if (type.Assembly == assembly2 && _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619437).Equals(type.FullName, StringComparison.Ordinal) && (byte)type.GetProperty(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619456)).GetValue(obj, null) != 2)
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

	public static bool _0023_003DzchuEBNUpnCZMInRxeDXYXp0yUfTT()
	{
		return _0023_003DzjYYAPCA_003D;
	}
}
