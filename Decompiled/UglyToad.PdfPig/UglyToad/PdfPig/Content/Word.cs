using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Content;

public class Word
{
	public string Text { get; }

	public TextOrientation TextOrientation { get; }

	public PdfRectangle BoundingBox { get; }

	public string? FontName { get; }

	public IReadOnlyList<Letter> Letters { get; }

	public Word(IReadOnlyList<Letter> letters)
	{
		if (letters == null)
		{
			throw new ArgumentNullException("letters");
		}
		if (letters.Count == 0)
		{
			throw new ArgumentException("Empty letters provided.", "letters");
		}
		Letters = letters;
		TextOrientation textOrientation = letters[0].TextOrientation;
		if (textOrientation != TextOrientation.Other)
		{
			foreach (Letter letter in letters)
			{
				if (letter.TextOrientation != textOrientation)
				{
					textOrientation = TextOrientation.Other;
					break;
				}
			}
		}
		(string, PdfRectangle) tuple = textOrientation switch
		{
			TextOrientation.Horizontal => GetBoundingBoxH(letters), 
			TextOrientation.Rotate180 => GetBoundingBox180(letters), 
			TextOrientation.Rotate90 => GetBoundingBox90(letters), 
			TextOrientation.Rotate270 => GetBoundingBox270(letters), 
			_ => GetBoundingBoxOther(letters), 
		};
		Text = tuple.Item1;
		BoundingBox = tuple.Item2;
		FontName = letters[0].FontName;
		TextOrientation = textOrientation;
	}

	private (string, PdfRectangle) GetBoundingBoxH(IReadOnlyList<Letter> letters)
	{
		StringBuilder stringBuilder = new StringBuilder();
		double num = double.MaxValue;
		double num2 = double.MinValue;
		double num3 = double.MaxValue;
		double num4 = double.MinValue;
		for (int i = 0; i < letters.Count; i++)
		{
			Letter letter = letters[i];
			stringBuilder.Append(letter.Value);
			if (letter.StartBaseLine.X < num)
			{
				num = letter.StartBaseLine.X;
			}
			if (letter.StartBaseLine.Y < num3)
			{
				num3 = letter.StartBaseLine.Y;
			}
			double num5 = letter.StartBaseLine.X + Math.Max(letter.Width, letter.GlyphRectangle.Width);
			if (num5 > num2)
			{
				num2 = num5;
			}
			if (letter.GlyphRectangle.TopLeft.Y > num4)
			{
				num4 = letter.GlyphRectangle.TopLeft.Y;
			}
		}
		return (stringBuilder.ToString(), new PdfRectangle(num, num3, num2, num4));
	}

	private (string, PdfRectangle) GetBoundingBox180(IReadOnlyList<Letter> letters)
	{
		StringBuilder stringBuilder = new StringBuilder();
		double num = double.MinValue;
		double num2 = double.MinValue;
		double num3 = double.MaxValue;
		double num4 = double.MaxValue;
		for (int i = 0; i < letters.Count; i++)
		{
			Letter letter = letters[i];
			stringBuilder.Append(letter.Value);
			if (letter.StartBaseLine.X > num)
			{
				num = letter.StartBaseLine.X;
			}
			if (letter.StartBaseLine.Y > num2)
			{
				num2 = letter.StartBaseLine.Y;
			}
			double num5 = letter.StartBaseLine.X - Math.Max(letter.Width, letter.GlyphRectangle.Width);
			if (num5 < num3)
			{
				num3 = num5;
			}
			if (letter.GlyphRectangle.TopRight.Y < num4)
			{
				num4 = letter.GlyphRectangle.TopRight.Y;
			}
		}
		return (stringBuilder.ToString(), new PdfRectangle(num, num2, num3, num4));
	}

	private (string, PdfRectangle) GetBoundingBox90(IReadOnlyList<Letter> letters)
	{
		StringBuilder stringBuilder = new StringBuilder();
		double num = double.MaxValue;
		double num2 = double.MaxValue;
		double num3 = double.MinValue;
		double num4 = double.MinValue;
		for (int i = 0; i < letters.Count; i++)
		{
			Letter letter = letters[i];
			stringBuilder.Append(letter.Value);
			if (letter.StartBaseLine.X < num)
			{
				num = letter.StartBaseLine.X;
			}
			if (letter.EndBaseLine.Y < num2)
			{
				num2 = letter.EndBaseLine.Y;
			}
			double num5 = letter.StartBaseLine.X + letter.GlyphRectangle.Height;
			if (num5 > num3)
			{
				num3 = num5;
			}
			if (letter.GlyphRectangle.BottomLeft.Y > num4)
			{
				num4 = letter.GlyphRectangle.BottomLeft.Y;
			}
		}
		return (stringBuilder.ToString(), new PdfRectangle(new PdfPoint(num3, num4), new PdfPoint(num3, num2), new PdfPoint(num, num4), new PdfPoint(num, num2)));
	}

	private (string, PdfRectangle) GetBoundingBox270(IReadOnlyList<Letter> letters)
	{
		StringBuilder stringBuilder = new StringBuilder();
		double num = double.MaxValue;
		double num2 = double.MinValue;
		double num3 = double.MaxValue;
		double num4 = double.MinValue;
		for (int i = 0; i < letters.Count; i++)
		{
			Letter letter = letters[i];
			stringBuilder.Append(letter.Value);
			if (letter.StartBaseLine.X > num2)
			{
				num2 = letter.StartBaseLine.X;
			}
			if (letter.StartBaseLine.Y < num3)
			{
				num3 = letter.StartBaseLine.Y;
			}
			double num5 = letter.StartBaseLine.X - letter.GlyphRectangle.Height;
			if (num5 < num)
			{
				num = num5;
			}
			if (letter.GlyphRectangle.BottomRight.Y > num4)
			{
				num4 = letter.GlyphRectangle.BottomRight.Y;
			}
		}
		return (stringBuilder.ToString(), new PdfRectangle(new PdfPoint(num, num3), new PdfPoint(num, num4), new PdfPoint(num2, num3), new PdfPoint(num2, num4)));
	}

	private (string, PdfRectangle) GetBoundingBoxOther(IReadOnlyList<Letter> letters)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < letters.Count; i++)
		{
			stringBuilder.Append(letters[i].Value);
		}
		if (letters.Count == 1)
		{
			return (stringBuilder.ToString(), letters[0].GlyphRectangle);
		}
		List<PdfPoint> list = letters.SelectMany((Letter r) => new PdfPoint[2] { r.StartBaseLine, r.EndBaseLine }).ToList();
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
		IEnumerable<PdfPoint> source = from p in letters.SelectMany((Letter r) => new PdfPoint[4]
			{
				r.StartBaseLine,
				r.EndBaseLine,
				r.GlyphRectangle.TopLeft,
				r.GlyphRectangle.TopRight
			}).Distinct()
			select inverseRotation.Transform(p);
		PdfRectangle original = new PdfRectangle(source.Min((PdfPoint p) => p.X), source.Min((PdfPoint p) => p.Y), source.Max((PdfPoint p) => p.X), source.Max((PdfPoint p) => p.Y));
		PdfRectangle item = new TransformationMatrix(num8, num9, 0.0, 0.0 - num9, num8, 0.0, 0.0, 0.0, 1.0).Transform(original);
		PdfRectangle pdfRectangle = new PdfRectangle(item.BottomLeft, item.TopLeft, item.BottomRight, item.TopRight);
		PdfRectangle pdfRectangle2 = new PdfRectangle(item.BottomRight, item.BottomLeft, item.TopRight, item.TopLeft);
		PdfRectangle pdfRectangle3 = new PdfRectangle(item.TopRight, item.BottomRight, item.TopLeft, item.BottomLeft);
		Letter letter = letters[0];
		Letter letter2 = letters[letters.Count - 1];
		double num11 = Math.Atan2(letter2.EndBaseLine.Y - letter.StartBaseLine.Y, letter2.EndBaseLine.X - letter.StartBaseLine.X) * 180.0 / Math.PI;
		double num12 = Math.Abs(BoundAngle180(item.Rotation - num11));
		double num13 = Math.Abs(BoundAngle180(pdfRectangle.Rotation - num11));
		if (num13 < num12)
		{
			num12 = num13;
			item = pdfRectangle;
		}
		double num14 = Math.Abs(BoundAngle180(pdfRectangle2.Rotation - num11));
		if (num14 < num12)
		{
			num12 = num14;
			item = pdfRectangle2;
		}
		if (Math.Abs(BoundAngle180(pdfRectangle3.Rotation - num11)) < num12)
		{
			item = pdfRectangle3;
		}
		return (stringBuilder.ToString(), item);
	}

	private static double BoundAngle180(double angle)
	{
		angle = (angle + 180.0) % 360.0;
		if (angle < 0.0)
		{
			angle += 360.0;
		}
		return angle - 180.0;
	}

	public override string ToString()
	{
		return Text;
	}
}
