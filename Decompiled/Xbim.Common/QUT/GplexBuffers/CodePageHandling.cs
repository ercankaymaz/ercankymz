using System;
using System.Globalization;
using System.Text;

namespace QUT.GplexBuffers;

public static class CodePageHandling
{
	public static int GetCodePage(string option)
	{
		string text = option.ToUpperInvariant();
		if (text.StartsWith("CodePage:", StringComparison.OrdinalIgnoreCase))
		{
			text = text.Substring(9);
		}
		try
		{
			if (text.Equals("RAW"))
			{
				return -1;
			}
			if (text.Equals("GUESS"))
			{
				return -2;
			}
			if (text.Equals("DEFAULT"))
			{
				return 0;
			}
			if (char.IsDigit(text[0]))
			{
				return int.Parse(text, CultureInfo.InvariantCulture);
			}
			return Encoding.GetEncoding(text).CodePage;
		}
		catch (FormatException)
		{
			Console.Error.WriteLine("Invalid format \"{0}\", using machine default", option);
		}
		catch (ArgumentException)
		{
			Console.Error.WriteLine("Unknown code page \"{0}\", using machine default", option);
		}
		return 0;
	}
}
