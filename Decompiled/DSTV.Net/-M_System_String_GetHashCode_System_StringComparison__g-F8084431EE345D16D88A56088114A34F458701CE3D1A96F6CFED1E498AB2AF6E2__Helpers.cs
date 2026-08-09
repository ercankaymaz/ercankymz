using System;

internal class _003CM_System_String_GetHashCode_System_StringComparison__g_003EF8084431EE345D16D88A56088114A34F458701CE3D1A96F6CFED1E498AB2AF6E2__Helpers
{
	public static StringComparer FromComparison(StringComparison comparisonType)
	{
		return comparisonType switch
		{
			StringComparison.CurrentCulture => StringComparer.CurrentCulture, 
			StringComparison.CurrentCultureIgnoreCase => StringComparer.CurrentCultureIgnoreCase, 
			StringComparison.InvariantCulture => StringComparer.InvariantCulture, 
			StringComparison.InvariantCultureIgnoreCase => StringComparer.InvariantCultureIgnoreCase, 
			StringComparison.Ordinal => StringComparer.Ordinal, 
			StringComparison.OrdinalIgnoreCase => StringComparer.OrdinalIgnoreCase, 
			_ => throw new ArgumentException("The string comparison type passed in is currently not supported.", "comparisonType"), 
		};
	}
}
