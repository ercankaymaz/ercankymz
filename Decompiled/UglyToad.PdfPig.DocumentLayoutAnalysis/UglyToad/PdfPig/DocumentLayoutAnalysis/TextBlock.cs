using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Geometry;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis;

public class TextBlock
{
	public readonly string Separator;

	public string Text { get; }

	public TextOrientation TextOrientation { get; }

	public PdfRectangle BoundingBox { get; }

	public IReadOnlyList<TextLine> TextLines { get; }

	public int ReadingOrder { get; private set; }

	public TextBlock(IReadOnlyList<TextLine> lines, string separator = "\n")
	{
		if (lines == null)
		{
			throw new ArgumentNullException("lines");
		}
		if (lines.Count == 0)
		{
			throw new ArgumentException("Empty lines provided.", "lines");
		}
		Separator = separator;
		ReadingOrder = -1;
		TextLines = lines;
		if (lines.Count == 1)
		{
			BoundingBox = lines[0].BoundingBox;
			Text = lines[0].Text;
			TextOrientation = lines[0].TextOrientation;
			return;
		}
		TextOrientation textOrientation = lines[0].TextOrientation;
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
			BoundingBox = GetBoundingBoxH(lines);
			break;
		case TextOrientation.Rotate180:
			BoundingBox = GetBoundingBox180(lines);
			break;
		case TextOrientation.Rotate90:
			BoundingBox = GetBoundingBox90(lines);
			break;
		case TextOrientation.Rotate270:
			BoundingBox = GetBoundingBox270(lines);
			break;
		default:
			BoundingBox = GetBoundingBoxOther(lines);
			break;
		}
		Text = string.Join(separator, lines.Select((TextLine x) => x.Text));
		TextOrientation = textOrientation;
	}

	private PdfRectangle GetBoundingBoxH(IReadOnlyList<TextLine> lines)
	{
		double num = double.MaxValue;
		double num2 = double.MinValue;
		double num3 = double.MaxValue;
		double num4 = double.MinValue;
		for (int i = 0; i < lines.Count; i++)
		{
			TextLine textLine = lines[i];
			if (textLine.BoundingBox.BottomLeft.X < num)
			{
				num = textLine.BoundingBox.BottomLeft.X;
			}
			if (textLine.BoundingBox.BottomLeft.Y < num3)
			{
				num3 = textLine.BoundingBox.BottomLeft.Y;
			}
			double num5 = textLine.BoundingBox.BottomLeft.X + textLine.BoundingBox.Width;
			if (num5 > num2)
			{
				num2 = num5;
			}
			if (textLine.BoundingBox.TopLeft.Y > num4)
			{
				num4 = textLine.BoundingBox.TopLeft.Y;
			}
		}
		return new PdfRectangle(num, num3, num2, num4);
	}

	private PdfRectangle GetBoundingBox180(IReadOnlyList<TextLine> lines)
	{
		double num = double.MinValue;
		double num2 = double.MinValue;
		double num3 = double.MaxValue;
		double num4 = double.MaxValue;
		for (int i = 0; i < lines.Count; i++)
		{
			TextLine textLine = lines[i];
			if (textLine.BoundingBox.BottomLeft.X > num)
			{
				num = textLine.BoundingBox.BottomLeft.X;
			}
			if (textLine.BoundingBox.BottomLeft.Y > num2)
			{
				num2 = textLine.BoundingBox.BottomLeft.Y;
			}
			double num5 = textLine.BoundingBox.BottomLeft.X - textLine.BoundingBox.Width;
			if (num5 < num3)
			{
				num3 = num5;
			}
			if (textLine.BoundingBox.TopRight.Y < num4)
			{
				num4 = textLine.BoundingBox.TopRight.Y;
			}
		}
		return new PdfRectangle(num, num2, num3, num4);
	}

	private PdfRectangle GetBoundingBox90(IReadOnlyList<TextLine> lines)
	{
		double num = double.MaxValue;
		double num2 = double.MaxValue;
		double num3 = double.MinValue;
		double num4 = double.MinValue;
		for (int i = 0; i < lines.Count; i++)
		{
			TextLine textLine = lines[i];
			if (textLine.BoundingBox.BottomLeft.X < num)
			{
				num = textLine.BoundingBox.BottomLeft.X;
			}
			if (textLine.BoundingBox.BottomRight.Y < num2)
			{
				num2 = textLine.BoundingBox.BottomRight.Y;
			}
			double num5 = textLine.BoundingBox.BottomLeft.X + textLine.BoundingBox.Height;
			if (num5 > num3)
			{
				num3 = num5;
			}
			if (textLine.BoundingBox.BottomLeft.Y > num4)
			{
				num4 = textLine.BoundingBox.BottomLeft.Y;
			}
		}
		return new PdfRectangle(new PdfPoint(num3, num4), new PdfPoint(num3, num2), new PdfPoint(num, num4), new PdfPoint(num, num2));
	}

	private PdfRectangle GetBoundingBox270(IReadOnlyList<TextLine> lines)
	{
		double num = double.MaxValue;
		double num2 = double.MinValue;
		double num3 = double.MaxValue;
		double num4 = double.MinValue;
		for (int i = 0; i < lines.Count; i++)
		{
			TextLine textLine = lines[i];
			if (textLine.BoundingBox.BottomLeft.X > num2)
			{
				num2 = textLine.BoundingBox.BottomLeft.X;
			}
			if (textLine.BoundingBox.BottomLeft.Y < num3)
			{
				num3 = textLine.BoundingBox.BottomLeft.Y;
			}
			double num5 = textLine.BoundingBox.BottomLeft.X - textLine.BoundingBox.Height;
			if (num5 < num)
			{
				num = num5;
			}
			if (textLine.BoundingBox.BottomRight.Y > num4)
			{
				num4 = textLine.BoundingBox.BottomRight.Y;
			}
		}
		return new PdfRectangle(new PdfPoint(num, num3), new PdfPoint(num, num4), new PdfPoint(num2, num3), new PdfPoint(num2, num4));
	}

	private PdfRectangle GetBoundingBoxOther(IReadOnlyList<TextLine> lines)
	{
		PdfRectangle result = GeometryExtensions.MinimumAreaRectangle(lines.SelectMany((TextLine l) => new PdfPoint[4]
		{
			l.BoundingBox.BottomLeft,
			l.BoundingBox.BottomRight,
			l.BoundingBox.TopLeft,
			l.BoundingBox.TopRight
		}));
		PdfRectangle pdfRectangle = new PdfRectangle(result.BottomLeft, result.TopLeft, result.BottomRight, result.TopRight);
		PdfRectangle pdfRectangle2 = new PdfRectangle(result.BottomRight, result.BottomLeft, result.TopRight, result.TopLeft);
		PdfRectangle pdfRectangle3 = new PdfRectangle(result.TopRight, result.BottomRight, result.TopLeft, result.BottomLeft);
		TextLine textLine = lines[lines.Count - 1];
		double num = Distances.BoundAngle180(Distances.Angle(textLine.BoundingBox.BottomLeft, textLine.BoundingBox.BottomRight));
		double num2 = Math.Abs(Distances.BoundAngle180(result.Rotation - num));
		double num3 = Math.Abs(Distances.BoundAngle180(pdfRectangle.Rotation - num));
		if (num3 < num2)
		{
			num2 = num3;
			result = pdfRectangle;
		}
		double num4 = Math.Abs(Distances.BoundAngle180(pdfRectangle2.Rotation - num));
		if (num4 < num2)
		{
			num2 = num4;
			result = pdfRectangle2;
		}
		if (Math.Abs(Distances.BoundAngle180(pdfRectangle3.Rotation - num)) < num2)
		{
			result = pdfRectangle3;
		}
		return result;
	}

	public void SetReadingOrder(int readingOrder)
	{
		if (readingOrder < -1)
		{
			throw new ArgumentException("The reading order should be more or equal to -1. A value of -1 means the block is not ordered.", "readingOrder");
		}
		ReadingOrder = readingOrder;
	}

	public override string ToString()
	{
		return Text;
	}
}
