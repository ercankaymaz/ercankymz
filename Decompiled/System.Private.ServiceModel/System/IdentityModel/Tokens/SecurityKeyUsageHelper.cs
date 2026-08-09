using System.ComponentModel;
using System.Runtime;

namespace System.IdentityModel.Tokens;

internal static class SecurityKeyUsageHelper
{
	internal static bool IsDefined(SecurityKeyUsage value)
	{
		if (value != SecurityKeyUsage.Exchange)
		{
			return value == SecurityKeyUsage.Signature;
		}
		return true;
	}

	internal static void Validate(SecurityKeyUsage value)
	{
		if (!IsDefined(value))
		{
			throw Fx.Exception.AsError(new InvalidEnumArgumentException("value", (int)value, typeof(SecurityKeyUsage)));
		}
	}
}
