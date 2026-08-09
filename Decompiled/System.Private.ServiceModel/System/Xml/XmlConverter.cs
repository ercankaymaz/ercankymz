namespace System.Xml;

internal static class XmlConverter
{
	public static bool IsWhitespace(char ch)
	{
		if (ch <= ' ')
		{
			if (ch != ' ' && ch != '\t' && ch != '\r')
			{
				return ch == '\n';
			}
			return true;
		}
		return false;
	}

	public static bool IsWhitespace(string s)
	{
		for (int i = 0; i < s.Length; i++)
		{
			if (!IsWhitespace(s[i]))
			{
				return false;
			}
		}
		return true;
	}
}
