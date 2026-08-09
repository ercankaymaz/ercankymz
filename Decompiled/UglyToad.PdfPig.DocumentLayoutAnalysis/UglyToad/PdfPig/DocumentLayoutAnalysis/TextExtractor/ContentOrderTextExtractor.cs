using System;
using System.Collections.Generic;
using System.Text;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

public static class ContentOrderTextExtractor
{
	public class Options
	{
		public bool SeparateParagraphsWithDoubleNewline { get; set; }

		public bool ReplaceWhitespaceWithSpace { get; set; }

		public bool NegativeGapAsWhitespace { get; set; }
	}

	private static readonly HashSet<string> ReplaceableWhitespace = new HashSet<string> { "\t", "\v", "\f" };

	public static string GetText(Page page, bool addDoubleNewline = false)
	{
		return GetText(page, new Options
		{
			SeparateParagraphsWithDoubleNewline = addDoubleNewline
		});
	}

	public static string GetText(Page page, Options options)
	{
		if (options == null)
		{
			options = new Options();
		}
		StringBuilder stringBuilder = new StringBuilder();
		Letter letter = null;
		bool flag = false;
		for (int i = 0; i < page.Letters.Count; i++)
		{
			Letter letter2 = page.Letters[i];
			if (string.IsNullOrEmpty(letter2.Value))
			{
				continue;
			}
			if (options.ReplaceWhitespaceWithSpace && ReplaceableWhitespace.Contains(letter2.Value))
			{
				letter2 = new Letter(" ", letter2.GlyphRectangle, letter2.GlyphRectangleLoose, letter2.StartBaseLine, letter2.EndBaseLine, letter2.Width, letter2.FontSize, letter2.GetFont(), letter2.RenderingMode, letter2.StrokeColor, letter2.FillColor, letter2.PointSize, letter2.TextSequence);
			}
			if (letter2.Value == " " && !flag)
			{
				if (letter == null || !IsNewline(letter, letter2, page, out var _))
				{
					stringBuilder.Append(" ");
					letter = letter2;
					flag = true;
				}
				continue;
			}
			flag = false;
			if (letter != null && letter2.Value != " ")
			{
				if (IsNewline(GetNonWhitespacePrevious(page, i), letter2, page, out var isDoubleNewline2))
				{
					if (letter.Value == " ")
					{
						stringBuilder.Remove(stringBuilder.Length - 1, 1);
					}
					stringBuilder.AppendLine();
					if (options.SeparateParagraphsWithDoubleNewline && isDoubleNewline2)
					{
						stringBuilder.AppendLine();
					}
					flag = true;
				}
				else if (letter.Value != " ")
				{
					double num = letter2.StartBaseLine.X - letter.EndBaseLine.X;
					if (options.NegativeGapAsWhitespace)
					{
						num = Math.Abs(num);
					}
					if (WhitespaceSizeStatistics.IsProbablyWhitespace(num, letter))
					{
						stringBuilder.Append(" ");
						flag = true;
					}
				}
			}
			stringBuilder.Append(letter2.Value);
			letter = letter2;
		}
		return stringBuilder.ToString();
	}

	private static Letter GetNonWhitespacePrevious(Page page, int index)
	{
		for (int num = index - 1; num >= 0; num--)
		{
			Letter letter = page.Letters[num];
			if (!string.IsNullOrWhiteSpace(letter.Value))
			{
				return letter;
			}
		}
		return null;
	}

	private static bool IsNewline(Letter previous, Letter letter, Page page, out bool isDoubleNewline)
	{
		isDoubleNewline = false;
		if (previous == null)
		{
			return false;
		}
		int num = (int)Math.Round(previous.PointSize);
		int num2 = (int)Math.Round(letter.PointSize);
		int num3 = ((num2 < num) ? num2 : num);
		double num4 = Math.Abs(previous.StartBaseLine.Y - letter.StartBaseLine.Y);
		if (num4 > (double)num3 * 1.7 && previous.StartBaseLine.Y > letter.StartBaseLine.Y)
		{
			isDoubleNewline = true;
		}
		return num4 > (double)num3 * 0.9;
	}
}
