using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Content;

namespace UglyToad.PdfPig.Util;

public class DefaultWordExtractor : IWordExtractor
{
	public static IWordExtractor Instance { get; } = new DefaultWordExtractor();

	public IEnumerable<Word> GetWords(IReadOnlyList<Letter> letters)
	{
		IOrderedEnumerable<Letter> orderedEnumerable = from x in letters
			orderby x.Location.Y descending, x.Location.X
			select x;
		List<Letter> lettersSoFar = new List<Letter>(10);
		Dictionary<double, Dictionary<double, int>> gapCountsSoFarByFontSize = new Dictionary<double, Dictionary<double, int>>();
		double? y = null;
		double? num = null;
		Letter letter = null;
		foreach (Letter letter2 in orderedEnumerable)
		{
			if (!y.HasValue)
			{
				y = letter2.Location.Y;
			}
			if (!num.HasValue)
			{
				num = letter2.Location.X;
			}
			if (letter == null)
			{
				if (!string.IsNullOrWhiteSpace(letter2.Value))
				{
					lettersSoFar.Add(letter2);
					letter = letter2;
					y = letter2.Location.Y;
					num = letter2.Location.X;
				}
				continue;
			}
			if (letter2.Location.Y < y.Value - 0.5)
			{
				if (lettersSoFar.Count > 0)
				{
					yield return GenerateWord(lettersSoFar);
					lettersSoFar.Clear();
				}
				if (!string.IsNullOrWhiteSpace(letter2.Value))
				{
					lettersSoFar.Add(letter2);
				}
				y = letter2.Location.Y;
				num = letter2.Location.X;
				letter = letter2;
				continue;
			}
			double num2 = Math.Max(letter.GlyphRectangle.Height, letter2.GlyphRectangle.Height);
			double num3 = letter2.Location.X - (letter.Location.X + letter.Width);
			bool flag = letter2.Location.X < num.Value - 1.0;
			bool flag2 = num3 > num2 * 0.39;
			bool flag3 = string.IsNullOrWhiteSpace(letter2.Value);
			bool flag4 = !string.Equals(letter2.FontName, letter.FontName, StringComparison.OrdinalIgnoreCase) && num3 > letter2.Width * 0.1;
			bool flag5 = Math.Abs(letter2.FontSize - letter.FontSize) > 0.1;
			bool flag6 = letter2.TextOrientation != letter.TextOrientation;
			bool flag7 = false;
			if (!flag5 && letter2.FontSize > 0.0 && num3 >= 0.0)
			{
				double key = Math.Round(letter2.FontSize);
				if (!gapCountsSoFarByFontSize.TryGetValue(key, out Dictionary<double, int> value))
				{
					value = (gapCountsSoFarByFontSize[key] = new Dictionary<double, int>());
				}
				double key2 = Math.Round(num3, 2);
				if (!value.ContainsKey(key2))
				{
					value[key2] = 0;
				}
				value[key2]++;
				if (value.Count > 1 && num3 > num2 * 0.16)
				{
					KeyValuePair<double, int> keyValuePair = value.OrderByDescending((KeyValuePair<double, int> x) => x.Value).First();
					if (num3 > keyValuePair.Key * 5.0 && keyValuePair.Value > 1)
					{
						flag7 = true;
					}
				}
			}
			if ((flag || flag2 || flag3 || flag4 || flag5 || flag6 || flag7) && lettersSoFar.Count > 0)
			{
				yield return GenerateWord(lettersSoFar);
				lettersSoFar.Clear();
			}
			if (!string.IsNullOrWhiteSpace(letter2.Value))
			{
				lettersSoFar.Add(letter2);
			}
			letter = letter2;
			num = letter2.Location.X;
		}
		if (lettersSoFar.Count > 0)
		{
			yield return GenerateWord(lettersSoFar);
		}
	}

	private static Word GenerateWord(List<Letter> letters)
	{
		return new Word(letters.ToList());
	}

	private DefaultWordExtractor()
	{
	}
}
