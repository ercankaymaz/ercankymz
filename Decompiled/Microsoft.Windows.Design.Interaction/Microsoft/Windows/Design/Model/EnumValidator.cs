namespace Microsoft.Windows.Design.Model;

internal static class EnumValidator
{
	public static bool IsValid(CreateOptions value)
	{
		if (value != CreateOptions.None)
		{
			return value == CreateOptions.InitializeDefaults;
		}
		return true;
	}
}
