using System.ComponentModel;
using System.Net.Security;

namespace System.ServiceModel.Security;

internal static class ProtectionLevelHelper
{
	public static bool IsDefined(ProtectionLevel value)
	{
		if (value != ProtectionLevel.None && value != ProtectionLevel.Sign)
		{
			return value == ProtectionLevel.EncryptAndSign;
		}
		return true;
	}

	public static void Validate(ProtectionLevel value)
	{
		if (!IsDefined(value))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidEnumArgumentException("value", (int)value, typeof(ProtectionLevel)));
		}
	}

	public static bool IsStronger(ProtectionLevel v1, ProtectionLevel v2)
	{
		if (v1 != ProtectionLevel.EncryptAndSign || v2 == ProtectionLevel.EncryptAndSign)
		{
			if (v1 == ProtectionLevel.Sign)
			{
				return v2 == ProtectionLevel.None;
			}
			return false;
		}
		return true;
	}

	public static bool IsStrongerOrEqual(ProtectionLevel v1, ProtectionLevel v2)
	{
		return v1 switch
		{
			ProtectionLevel.Sign => v2 != ProtectionLevel.EncryptAndSign, 
			ProtectionLevel.EncryptAndSign => true, 
			_ => false, 
		};
	}

	public static ProtectionLevel Max(ProtectionLevel v1, ProtectionLevel v2)
	{
		if (!IsStronger(v1, v2))
		{
			return v2;
		}
		return v1;
	}

	public static int GetOrdinal(ProtectionLevel? p)
	{
		if (p.HasValue)
		{
			return p.Value switch
			{
				ProtectionLevel.None => 2, 
				ProtectionLevel.Sign => 3, 
				ProtectionLevel.EncryptAndSign => 4, 
				_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidEnumArgumentException("p", (int)p.Value, typeof(ProtectionLevel))), 
			};
		}
		return 1;
	}
}
