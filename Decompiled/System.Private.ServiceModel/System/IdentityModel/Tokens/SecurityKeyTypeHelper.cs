using System.ComponentModel;
using System.Runtime;

namespace System.IdentityModel.Tokens;

internal static class SecurityKeyTypeHelper
{
	internal static bool IsDefined(SecurityKeyType value)
	{
		if (value != SecurityKeyType.SymmetricKey && value != SecurityKeyType.AsymmetricKey)
		{
			return value == SecurityKeyType.BearerKey;
		}
		return true;
	}

	internal static void Validate(SecurityKeyType value)
	{
		if (!IsDefined(value))
		{
			throw Fx.Exception.AsError(new InvalidEnumArgumentException("value", (int)value, typeof(SecurityKeyType)));
		}
	}
}
