namespace Microsoft.Windows.Design.PropertyEditing;

internal static class EnumValidator
{
	public static bool IsValid(PropertyValueExceptionSource value)
	{
		if (value != PropertyValueExceptionSource.Get)
		{
			return value == PropertyValueExceptionSource.Set;
		}
		return true;
	}
}
