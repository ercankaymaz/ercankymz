namespace UglyToad.PdfPig.Util;

internal static class StringExtensions
{
	public static string AsSpanOrSubstring(this string text, int start)
	{
		return text.Substring(start);
	}

	public static string AsSpanOrSubstring(this string text, int start, int length)
	{
		return text.Substring(start, length);
	}
}
