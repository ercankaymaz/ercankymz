using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis;

public class TextLine
{
	public readonly string Separator;

	public string Text { get; }

	public TextOrientation TextOrientation { get; }

	public PdfRectangle BoundingBox { get; }

	public IReadOnlyList<Word> Words { get; }

	public TextLine(IReadOnlyList<Word> words, string separator = " ")
	{
		if (words == null)
		{
			throw new ArgumentNullException("words");
		}
		if (words.Count == 0)
		{
			throw new ArgumentException("Empty words provided.", "words");
		}
		Separator = separator;
		Words = words;
		if (Words.Count == 1)
		{
			BoundingBox = Words[0].BoundingBox;
			Text = Words[0].Text;
			TextOrientation = words[0].TextOrientation;
			return;
		}
		TextOrientation textOrientation = words[0].TextOrientation;
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
			BoundingBox = GetBoundingBoxH(words);
			break;
		case TextOrientation.Rotate180:
			BoundingBox = GetBoundingBox180(words);
			break;
		case TextOrientation.Rotate90:
			BoundingBox = GetBoundingBox90(words);
			break;
		case TextOrientation.Rotate270:
			BoundingBox = GetBoundingBox270(words);
			break;
		default:
			BoundingBox = GetBoundingBoxOther(words);
			break;
		}
		Text = string.Join(Separator, from x in words
			where !string.IsNullOrWhiteSpace(x.Text)
			select x.Text);
		TextOrientation = textOrientation;
	}

	private PdfRectangle GetBoundingBoxH(IReadOnlyList<Word> words)
	{
		double num = double.MaxValue;
		double num2 = double.MinValue;
		double num3 = double.MaxValue;
		double num4 = double.MinValue;
		for (int i = 0; i < words.Count; i++)
		{
			Word word = words[i];
			if (word.BoundingBox.BottomLeft.X < num)
			{
				num = word.BoundingBox.BottomLeft.X;
			}
			if (word.BoundingBox.BottomLeft.Y < num3)
			{
				num3 = word.BoundingBox.BottomLeft.Y;
			}
			double num5 = word.BoundingBox.BottomLeft.X + word.BoundingBox.Width;
			if (num5 > num2)
			{
				num2 = num5;
			}
			if (word.BoundingBox.TopLeft.Y > num4)
			{
				num4 = word.BoundingBox.TopLeft.Y;
			}
		}
		return new PdfRectangle(num, num3, num2, num4);
	}

	private PdfRectangle GetBoundingBox180(IReadOnlyList<Word> words)
	{
		double num = double.MinValue;
		double num2 = double.MinValue;
		double num3 = double.MaxValue;
		double num4 = double.MaxValue;
		for (int i = 0; i < words.Count; i++)
		{
			Word word = words[i];
			if (word.BoundingBox.BottomLeft.X > num)
			{
				num = word.BoundingBox.BottomLeft.X;
			}
			if (word.BoundingBox.BottomLeft.Y > num2)
			{
				num2 = word.BoundingBox.BottomLeft.Y;
			}
			double num5 = word.BoundingBox.BottomLeft.X - word.BoundingBox.Width;
			if (num5 < num3)
			{
				num3 = num5;
			}
			if (word.BoundingBox.TopRight.Y < num4)
			{
				num4 = word.BoundingBox.TopRight.Y;
			}
		}
		return new PdfRectangle(num, num2, num3, num4);
	}

	private PdfRectangle GetBoundingBox90(IReadOnlyList<Word> words)
	{
		double num = double.MaxValue;
		double num2 = double.MaxValue;
		double num3 = double.MinValue;
		double num4 = double.MinValue;
		for (int i = 0; i < words.Count; i++)
		{
			Word word = words[i];
			if (word.BoundingBox.BottomLeft.X < num)
			{
				num = word.BoundingBox.BottomLeft.X;
			}
			if (word.BoundingBox.BottomRight.Y < num2)
			{
				num2 = word.BoundingBox.BottomRight.Y;
			}
			double num5 = word.BoundingBox.BottomLeft.X + word.BoundingBox.Height;
			if (num5 > num3)
			{
				num3 = num5;
			}
			if (word.BoundingBox.BottomLeft.Y > num4)
			{
				num4 = word.BoundingBox.BottomLeft.Y;
			}
		}
		return new PdfRectangle(new PdfPoint(num3, num4), new PdfPoint(num3, num2), new PdfPoint(num, num4), new PdfPoint(num, num2));
	}

	private PdfRectangle GetBoundingBox270(IReadOnlyList<Word> words)
	{
		double num = double.MaxValue;
		double num2 = double.MinValue;
		double num3 = double.MaxValue;
		double num4 = double.MinValue;
		for (int i = 0; i < words.Count; i++)
		{
			Word word = words[i];
			if (word.BoundingBox.BottomLeft.X > num2)
			{
				num2 = word.BoundingBox.BottomLeft.X;
			}
			if (word.BoundingBox.BottomLeft.Y < num3)
			{
				num3 = word.BoundingBox.BottomLeft.Y;
			}
			double num5 = word.BoundingBox.BottomLeft.X - word.BoundingBox.Height;
			if (num5 < num)
			{
				num = num5;
			}
			if (word.BoundingBox.BottomRight.Y > num4)
			{
				num4 = word.BoundingBox.BottomRight.Y;
			}
		}
		return new PdfRectangle(new PdfPoint(num, num3), new PdfPoint(num, num4), new PdfPoint(num2, num3), new PdfPoint(num2, num4));
	}

	private static PdfRectangle GetBoundingBoxOther(IReadOnlyList<Word> words)
	{
		List<PdfPoint> list = words.SelectMany((Word r) => new PdfPoint[2]
		{
			r.BoundingBox.BottomLeft,
			r.BoundingBox.BottomRight
		}).ToList();
		double num = list.Average((PdfPoint p) => p.X);
		double num2 = list.Average((PdfPoint p) => p.Y);
		double num3 = 0.0;
		double num4 = 0.0;
		for (int num5 = 0; num5 < list.Count; num5++)
		{
			PdfPoint pdfPoint = list[num5];
			double num6 = pdfPoint.X - num;
			double num7 = pdfPoint.Y - num2;
			num3 += num6 * num7;
			num4 += num6 * num6;
		}
		double num8 = 0.0;
		double num9 = 1.0;
		if (num4 > 0.001)
		{
			double num10 = Math.Atan(num3 / num4);
			num8 = Math.Cos(num10);
			num9 = Math.Sin(num10);
		}
		TransformationMatrix inverseRotation = new TransformationMatrix(num8, 0.0 - num9, 0.0, num9, num8, 0.0, 0.0, 0.0, 1.0);
		IEnumerable<PdfPoint> source = from p in words.SelectMany((Word r) => new PdfPoint[4]
			{
				r.BoundingBox.BottomLeft,
				r.BoundingBox.BottomRight,
				r.BoundingBox.TopLeft,
				r.BoundingBox.TopRight
			}).Distinct()
			select inverseRotation.Transform(p);
		PdfRectangle original = new PdfRectangle(source.Min((PdfPoint p) => p.X), source.Min((PdfPoint p) => p.Y), source.Max((PdfPoint p) => p.X), source.Max((PdfPoint p) => p.Y));
		PdfRectangle result = new TransformationMatrix(num8, num9, 0.0, 0.0 - num9, num8, 0.0, 0.0, 0.0, 1.0).Transform(original);
		PdfRectangle pdfRectangle = new PdfRectangle(result.BottomLeft, result.TopLeft, result.BottomRight, result.TopRight);
		PdfRectangle pdfRectangle2 = new PdfRectangle(result.BottomRight, result.BottomLeft, result.TopRight, result.TopLeft);
		PdfRectangle pdfRectangle3 = new PdfRectangle(result.TopRight, result.BottomRight, result.TopLeft, result.BottomLeft);
		Word word = words[0];
		double num11 = Distances.Angle(endPoint: words[words.Count - 1].BoundingBox.BottomRight, startPoint: word.BoundingBox.BottomLeft);
		double num12 = Math.Abs(Distances.BoundAngle180(result.Rotation - num11));
		double num13 = Math.Abs(Distances.BoundAngle180(pdfRectangle.Rotation - num11));
		if (num13 < num12)
		{
			num12 = num13;
			result = pdfRectangle;
		}
		double num14 = Math.Abs(Distances.BoundAngle180(pdfRectangle2.Rotation - num11));
		if (num14 < num12)
		{
			num12 = num14;
			result = pdfRectangle2;
		}
		if (Math.Abs(Distances.BoundAngle180(pdfRectangle3.Rotation - num11)) < num12)
		{
			result = pdfRectangle3;
		}
		return result;
	}

	public override string ToString()
	{
		return Text;
	}
}
