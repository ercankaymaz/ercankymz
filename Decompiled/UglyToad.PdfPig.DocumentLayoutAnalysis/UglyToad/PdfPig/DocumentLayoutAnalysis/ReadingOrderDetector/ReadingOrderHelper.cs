using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Content;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.ReadingOrderDetector;

public static class ReadingOrderHelper
{
	public static List<Word> OrderByReadingOrder(this IEnumerable<Word> words)
	{
		if (words.Count() <= 1)
		{
			return words.ToList();
		}
		TextOrientation textOrientation = words.First().TextOrientation;
		if (textOrientation != TextOrientation.Other)
		{
			foreach (Word word in words)
			{
				if (word.TextOrientation != textOrientation)
				{
					textOrientation = TextOrientation.Other;
					break;
				}
			}
		}
		switch (textOrientation)
		{
		case TextOrientation.Horizontal:
			return words.OrderBy((Word w) => w.BoundingBox.BottomLeft.X).ToList();
		case TextOrientation.Rotate180:
			return words.OrderByDescending((Word w) => w.BoundingBox.BottomLeft.X).ToList();
		case TextOrientation.Rotate90:
			return words.OrderByDescending((Word w) => w.BoundingBox.BottomLeft.Y).ToList();
		case TextOrientation.Rotate270:
			return words.OrderBy((Word w) => w.BoundingBox.BottomLeft.Y).ToList();
		default:
		{
			double num = words.Average((Word w) => w.BoundingBox.Rotation);
			if (double.IsNaN(num))
			{
				throw new NotFiniteNumberException("OrderByReadingOrder: NaN bounding box rotation found when ordering words.", num);
			}
			if (0.0 < num && num <= 90.0)
			{
				return (from w in words
					orderby w.BoundingBox.BottomLeft.X, w.BoundingBox.BottomLeft.Y
					select w).ToList();
			}
			if (90.0 < num && num <= 180.0)
			{
				return (from w in words
					orderby w.BoundingBox.BottomLeft.X descending, w.BoundingBox.BottomLeft.Y
					select w).ToList();
			}
			if (-180.0 < num && num <= -90.0)
			{
				return (from w in words
					orderby w.BoundingBox.BottomLeft.X descending, w.BoundingBox.BottomLeft.Y descending
					select w).ToList();
			}
			if (-90.0 < num && num <= 0.0)
			{
				return (from w in words
					orderby w.BoundingBox.BottomLeft.X, w.BoundingBox.BottomLeft.Y descending
					select w).ToList();
			}
			throw new ArgumentException("OrderByReadingOrder: unknown bounding box rotation found when ordering words.", "avgAngle");
		}
		}
	}

	public static IReadOnlyList<TextLine> OrderByReadingOrder(this IEnumerable<TextLine> lines)
	{
		if (lines.Count() <= 1)
		{
			return lines.ToList();
		}
		TextOrientation textOrientation = lines.First().TextOrientation;
		if (textOrientation != TextOrientation.Other)
		{
			foreach (TextLine line in lines)
			{
				if (line.TextOrientation != textOrientation)
				{
					textOrientation = TextOrientation.Other;
					break;
				}
			}
		}
		switch (textOrientation)
		{
		case TextOrientation.Horizontal:
			return lines.OrderByDescending((TextLine w) => w.BoundingBox.BottomLeft.Y).ToList();
		case TextOrientation.Rotate180:
			return lines.OrderBy((TextLine w) => w.BoundingBox.BottomLeft.Y).ToList();
		case TextOrientation.Rotate90:
			return lines.OrderByDescending((TextLine w) => w.BoundingBox.BottomLeft.X).ToList();
		case TextOrientation.Rotate270:
			return lines.OrderBy((TextLine w) => w.BoundingBox.BottomLeft.X).ToList();
		default:
		{
			double num = lines.Average((TextLine w) => w.BoundingBox.Rotation);
			if (double.IsNaN(num))
			{
				throw new NotFiniteNumberException("OrderByReadingOrder: NaN bounding box rotation found when ordering lines.", num);
			}
			if (0.0 < num && num <= 90.0)
			{
				return (from w in lines
					orderby w.BoundingBox.BottomLeft.Y descending, w.BoundingBox.BottomLeft.X
					select w).ToList();
			}
			if (90.0 < num && num <= 180.0)
			{
				return (from w in lines
					orderby w.BoundingBox.BottomLeft.X, w.BoundingBox.BottomLeft.Y
					select w).ToList();
			}
			if (-180.0 < num && num <= -90.0)
			{
				return (from w in lines
					orderby w.BoundingBox.BottomLeft.Y, w.BoundingBox.BottomLeft.X descending
					select w).ToList();
			}
			if (-90.0 < num && num <= 0.0)
			{
				return (from w in lines
					orderby w.BoundingBox.BottomLeft.X descending, w.BoundingBox.BottomLeft.Y descending
					select w).ToList();
			}
			throw new ArgumentException("OrderByReadingOrder: unknown bounding box rotation found when ordering lines.", "avgAngle");
		}
		}
	}
}
