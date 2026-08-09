using System;
using System.Reflection;
using System.Security;

internal static class _0023_003DqHG1TmG_0024dSF7XquINMc2Zz3tMFIPBSY3zMYxpt2OaEhY_003D
{
	private static readonly bool _0023_003Dz9jrlnWk_003D;

	static _0023_003DqHG1TmG_0024dSF7XquINMc2Zz3tMFIPBSY3zMYxpt2OaEhY_003D()
	{
		_0023_003Dz9jrlnWk_003D = _0023_003Dz99Rx7QOVZciEdgtYHGCi3EMGLx9J();
	}

	private static bool _0023_003Dz99Rx7QOVZciEdgtYHGCi3EMGLx9J()
	{
		try
		{
			if (Environment.Version.Major < 4)
			{
				return false;
			}
			Assembly assembly = typeof(_0023_003DqRfaUN25F_BqlwRMpZvaCa2Ku85GyU9tRcAtC6jERbhw_003D).Assembly;
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
				if (type.Assembly == assembly2 && _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312470).Equals(type.FullName, StringComparison.Ordinal) && (byte)type.GetProperty(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312569)).GetValue(obj, null) != 2)
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

	public static bool _0023_003DzmMFpo19NL5XDHMtobKhI8ni5CeJl()
	{
		return _0023_003Dz9jrlnWk_003D;
	}
}
