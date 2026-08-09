using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Content;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis;

public static class DuplicateOverlappingTextProcessor
{
	public static IReadOnlyList<Letter> Get(IEnumerable<Letter> letters)
	{
		if (letters == null || !letters.Any())
		{
			return letters?.ToList();
		}
		Queue<Letter> queue = new Queue<Letter>(letters);
		List<Letter> list = new List<Letter> { queue.Dequeue() };
		while (queue.Count > 0)
		{
			Letter letter = queue.Dequeue();
			bool flag = true;
			int num = -1;
			IEnumerable<Letter> source = list.Where((Letter l) => l.Value.Equals(letter.Value) && l.FontName.Equals(letter.FontName));
			if (source.Any())
			{
				double num2 = letter.GlyphRectangle.Width / (double)((letter.Value.Length == 0) ? 1 : letter.Value.Length) / 3.0;
				double minX = letter.GlyphRectangle.BottomLeft.X - num2;
				double maxX = letter.GlyphRectangle.BottomLeft.X + num2;
				double minY = letter.GlyphRectangle.BottomLeft.Y - num2;
				double maxY = letter.GlyphRectangle.BottomLeft.Y + num2;
				Letter letter2 = source.FirstOrDefault((Letter l) => minX <= l.GlyphRectangle.BottomLeft.X && maxX >= l.GlyphRectangle.BottomLeft.X && minY <= l.GlyphRectangle.BottomLeft.Y && maxY >= l.GlyphRectangle.BottomLeft.Y);
				if (letter2 != null)
				{
					flag = false;
					num = list.IndexOf(letter2);
				}
			}
			if (flag)
			{
				list.Add(letter);
			}
			else if (num != -1)
			{
				list[num] = letter.AsBold();
			}
		}
		return list;
	}
}
