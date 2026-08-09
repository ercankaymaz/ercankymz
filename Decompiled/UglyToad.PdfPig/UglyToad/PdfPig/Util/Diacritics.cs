using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace UglyToad.PdfPig.Util;

public static class Diacritics
{
	private static readonly HashSet<string> NonCombiningDiacritics = new HashSet<string>
	{
		"\u00b4", "^", "ˆ", "\u00a8", "©", "™", "®", "`", "\u02dc", "∼",
		"\u00b8"
	};

	internal static bool IsPotentialStandaloneDiacritic(string value)
	{
		return NonCombiningDiacritics.Contains(value);
	}

	public static bool IsInCombiningDiacriticRange(string value)
	{
		if (value.Length != 1)
		{
			return false;
		}
		int num = value[0];
		if (num >= 768 && num <= 879)
		{
			return true;
		}
		return false;
	}

	public static bool TryCombineDiacriticWithPreviousLetter(string diacritic, string previous, [NotNullWhen(true)] out string? result)
	{
		result = null;
		if (previous == null)
		{
			return false;
		}
		result = previous + diacritic;
		int num = MeasureDiacriticAwareLength(previous);
		int num2 = MeasureDiacriticAwareLength(result);
		return num == num2;
	}

	private static int MeasureDiacriticAwareLength(string input)
	{
		int num = 0;
		TextElementEnumerator textElementEnumerator = StringInfo.GetTextElementEnumerator(input);
		while (textElementEnumerator.MoveNext())
		{
			textElementEnumerator.GetTextElement();
			num++;
		}
		return num;
	}
}
