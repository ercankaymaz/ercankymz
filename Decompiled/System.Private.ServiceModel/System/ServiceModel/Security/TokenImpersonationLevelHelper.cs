using System.ComponentModel;
using System.Security.Principal;

namespace System.ServiceModel.Security;

internal static class TokenImpersonationLevelHelper
{
	private static TokenImpersonationLevel[] s_TokenImpersonationLevelOrder = new TokenImpersonationLevel[5]
	{
		TokenImpersonationLevel.None,
		TokenImpersonationLevel.Anonymous,
		TokenImpersonationLevel.Identification,
		TokenImpersonationLevel.Impersonation,
		TokenImpersonationLevel.Delegation
	};

	internal static bool IsDefined(TokenImpersonationLevel value)
	{
		if (value != TokenImpersonationLevel.None && value != TokenImpersonationLevel.Anonymous && value != TokenImpersonationLevel.Identification && value != TokenImpersonationLevel.Impersonation)
		{
			return value == TokenImpersonationLevel.Delegation;
		}
		return true;
	}

	internal static void Validate(TokenImpersonationLevel value)
	{
		if (!IsDefined(value))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidEnumArgumentException("value", (int)value, typeof(TokenImpersonationLevel)));
		}
	}

	internal static string ToString(TokenImpersonationLevel impersonationLevel)
	{
		return impersonationLevel switch
		{
			TokenImpersonationLevel.Identification => "identification", 
			TokenImpersonationLevel.None => "none", 
			TokenImpersonationLevel.Anonymous => "anonymous", 
			TokenImpersonationLevel.Impersonation => "impersonation", 
			TokenImpersonationLevel.Delegation => "delegation", 
			_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidEnumArgumentException("impersonationLevel", (int)impersonationLevel, typeof(TokenImpersonationLevel))), 
		};
	}

	internal static bool IsGreaterOrEqual(TokenImpersonationLevel x, TokenImpersonationLevel y)
	{
		Validate(x);
		Validate(y);
		if (x == y)
		{
			return true;
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < s_TokenImpersonationLevelOrder.Length; i++)
		{
			if (x == s_TokenImpersonationLevelOrder[i])
			{
				num = i;
			}
			if (y == s_TokenImpersonationLevelOrder[i])
			{
				num2 = i;
			}
		}
		return num > num2;
	}

	internal static int Compare(TokenImpersonationLevel x, TokenImpersonationLevel y)
	{
		int result = 0;
		if (x != y)
		{
			result = x switch
			{
				TokenImpersonationLevel.Identification => -1, 
				TokenImpersonationLevel.Impersonation => y switch
				{
					TokenImpersonationLevel.Identification => 1, 
					TokenImpersonationLevel.Delegation => -1, 
					_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidEnumArgumentException("y", (int)y, typeof(TokenImpersonationLevel))), 
				}, 
				TokenImpersonationLevel.Delegation => 1, 
				_ => throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidEnumArgumentException("x", (int)x, typeof(TokenImpersonationLevel))), 
			};
		}
		return result;
	}
}
