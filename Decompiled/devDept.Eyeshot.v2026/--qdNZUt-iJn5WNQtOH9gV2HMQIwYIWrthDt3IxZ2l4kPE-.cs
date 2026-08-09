using System;
using System.Reflection;
using System.Security;

internal static class _0023_003DqdNZUt_0024iJn5WNQtOH9gV2HMQIwYIWrthDt3IxZ2l4kPE_003D
{
	private static readonly bool _0023_003DziDLVpbY_003D;

	static _0023_003DqdNZUt_0024iJn5WNQtOH9gV2HMQIwYIWrthDt3IxZ2l4kPE_003D()
	{
		_0023_003DziDLVpbY_003D = _0023_003DzD8N6h1gQVe3zpUv4j3VEUbdz7SpX();
	}

	private static bool _0023_003DzD8N6h1gQVe3zpUv4j3VEUbdz7SpX()
	{
		try
		{
			if (Environment.Version.Major < 4)
			{
				return false;
			}
			Assembly assembly = typeof(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D).Assembly;
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
				if (type.Assembly == assembly2 && _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909949).Equals(type.FullName, StringComparison.Ordinal) && (byte)type.GetProperty(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909900)).GetValue(obj, null) != 2)
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

	public static bool _0023_003DzoJ937IfXlQFvgt67vThzEz0bhViU()
	{
		return _0023_003DziDLVpbY_003D;
	}
}
