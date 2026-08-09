namespace Microsoft.Windows.Design;

internal static class EnumValidator
{
	public static bool IsValid(OrderTokenConflictResolution value)
	{
		if (value != OrderTokenConflictResolution.Win)
		{
			return value == OrderTokenConflictResolution.Lose;
		}
		return true;
	}

	public static bool IsValid(OrderTokenPrecedence value)
	{
		if (value != OrderTokenPrecedence.Before)
		{
			return value == OrderTokenPrecedence.After;
		}
		return true;
	}
}
