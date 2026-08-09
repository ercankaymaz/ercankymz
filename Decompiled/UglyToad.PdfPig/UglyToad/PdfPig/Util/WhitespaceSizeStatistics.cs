using UglyToad.PdfPig.Content;

namespace UglyToad.PdfPig.Util;

public static class WhitespaceSizeStatistics
{
	public static double GetExpectedWhitespaceSize(Letter letter)
	{
		return letter.PointSize * 0.27;
	}

	public static bool IsProbablyWhitespace(double gap, Letter letter)
	{
		return gap > GetExpectedWhitespaceSize(letter) - letter.PointSize * 0.05;
	}
}
