using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.TrueType.Glyphs;

internal sealed class Glyph : IGlyphDescription, IMergeableGlyph, ITransformableGlyph
{
	public PdfRectangle Bounds { get; }

	public byte[] Instructions { get; }

	public ushort[] EndPointsOfContours { get; }

	public GlyphPoint[] Points { get; }

	public bool IsSimple { get; }

	public bool IsEmpty => Points.Length == 0;

	public Glyph(bool isSimple, byte[] instructions, ushort[] endPointsOfContours, GlyphPoint[] points, PdfRectangle bounds)
	{
		IsSimple = isSimple;
		Instructions = instructions;
		EndPointsOfContours = endPointsOfContours;
		Points = points;
		Bounds = bounds;
	}

	public static IGlyphDescription Empty(PdfRectangle bounds)
	{
		return new Glyph(isSimple: true, Array.Empty<byte>(), Array.Empty<ushort>(), Array.Empty<GlyphPoint>(), bounds);
	}

	public IGlyphDescription DeepClone()
	{
		byte[] array = new byte[Instructions.Length];
		Array.Copy(Instructions, array, Instructions.Length);
		ushort[] array2 = new ushort[EndPointsOfContours.Length];
		Array.Copy(EndPointsOfContours, array2, EndPointsOfContours.Length);
		GlyphPoint[] array3 = new GlyphPoint[Points.Length];
		Array.Copy(Points, array3, Points.Length);
		return new Glyph(isSimple: false, array, array2, array3, Bounds);
	}

	public IGlyphDescription Merge(IGlyphDescription glyph)
	{
		GlyphPoint[] points = MergePoints(glyph);
		ushort[] endPointsOfContours = MergeContourEndPoints(glyph);
		return new Glyph(isSimple: false, Instructions, endPointsOfContours, points, Bounds);
	}

	private GlyphPoint[] MergePoints(IGlyphDescription glyph)
	{
		GlyphPoint[] array = new GlyphPoint[Points.Length + glyph.Points.Length];
		for (int i = 0; i < Points.Length; i++)
		{
			array[i] = Points[i];
		}
		for (int j = 0; j < glyph.Points.Length; j++)
		{
			array[j + Points.Length] = glyph.Points[j];
		}
		return array;
	}

	private ushort[] MergeContourEndPoints(IGlyphDescription glyph)
	{
		int num = ((EndPointsOfContours.Length != 0) ? EndPointsOfContours[EndPointsOfContours.Length - 1] : 0) + 1;
		ushort[] array = new ushort[EndPointsOfContours.Length + glyph.EndPointsOfContours.Length];
		for (int i = 0; i < EndPointsOfContours.Length; i++)
		{
			array[i] = EndPointsOfContours[i];
		}
		for (int j = 0; j < glyph.EndPointsOfContours.Length; j++)
		{
			array[j + EndPointsOfContours.Length] = (ushort)(glyph.EndPointsOfContours[j] + num);
		}
		return array;
	}

	public IGlyphDescription Transform(CompositeTransformMatrix3By2 matrix)
	{
		GlyphPoint[] array = new GlyphPoint[Points.Length];
		for (int num = Points.Length - 1; num >= 0; num--)
		{
			GlyphPoint glyphPoint = Points[num];
			PdfPoint source = matrix.ScaleAndRotate(new PdfPoint(glyphPoint.X, glyphPoint.Y));
			source = matrix.Translate(source);
			array[num] = new GlyphPoint((short)source.X, (short)source.Y, glyphPoint.IsOnCurve, glyphPoint.IsEndOfContour);
		}
		return new Glyph(IsSimple, Instructions, EndPointsOfContours, array, Bounds);
	}

	public bool TryGetGlyphPath(out IReadOnlyList<PdfSubpath> subpaths)
	{
		subpaths = Array.Empty<PdfSubpath>();
		if (Points == null)
		{
			return false;
		}
		if (Points.Length != 0)
		{
			subpaths = CalculatePath(Points);
		}
		return true;
	}

	private static IReadOnlyList<PdfSubpath> CalculatePath(GlyphPoint[] points)
	{
		List<PdfSubpath> list = new List<PdfSubpath>();
		int num = 0;
		for (int i = 0; i < points.Length; i++)
		{
			if (!points[i].IsEndOfContour)
			{
				continue;
			}
			PdfSubpath pdfSubpath = new PdfSubpath();
			GlyphPoint glyphPoint = points[num];
			GlyphPoint glyphPoint2 = points[i];
			List<GlyphPoint> list2 = new List<GlyphPoint>();
			for (int j = num; j <= i; j++)
			{
				list2.Add(points[j]);
			}
			if (points[num].IsOnCurve)
			{
				list2.Add(glyphPoint);
			}
			else if (points[i].IsOnCurve)
			{
				list2.Insert(0, glyphPoint2);
			}
			else
			{
				GlyphPoint item = midValue(glyphPoint, glyphPoint2);
				list2.Insert(0, item);
				list2.Add(item);
			}
			pdfSubpath.MoveTo(list2[0].X, list2[0].Y);
			for (int k = 1; k < list2.Count; k++)
			{
				GlyphPoint point = list2[k];
				if (point.IsOnCurve)
				{
					pdfSubpath.LineTo(point.X, point.Y);
				}
				else if (list2[k + 1].IsOnCurve)
				{
					GlyphPoint glyphPoint3 = list2[k + 1];
					pdfSubpath.BezierCurveTo(point.X, point.Y, glyphPoint3.X, glyphPoint3.Y);
					k++;
				}
				else
				{
					GlyphPoint glyphPoint4 = midValue(point, list2[k + 1]);
					pdfSubpath.BezierCurveTo(point.X, point.Y, glyphPoint4.X, glyphPoint4.Y);
				}
			}
			pdfSubpath.CloseSubpath();
			list.Add(pdfSubpath);
			num = i + 1;
		}
		return list;
	}

	private static short midValue(short a, short b)
	{
		return (short)(a + (b - a) / 2);
	}

	private static GlyphPoint midValue(GlyphPoint point1, GlyphPoint point2)
	{
		return new GlyphPoint(midValue(point1.X, point2.X), midValue(point1.Y, point2.Y), isOnCurve: true, isEndOfContour: false);
	}

	public override string ToString()
	{
		string text = (IsSimple ? "S" : "C");
		return $"{text}: Width {Bounds.Width}, Height: {Bounds.Height}, Points: {Points.Length}";
	}
}
