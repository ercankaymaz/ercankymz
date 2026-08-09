namespace System.Text;

internal static class EncodingExtensions
{
	public static string GetString(this Encoding encoding, ReadOnlySpan<byte> bytes)
	{
		if (bytes.IsEmpty)
		{
			return string.Empty;
		}
		return encoding.GetString(bytes.ToArray());
	}
}
