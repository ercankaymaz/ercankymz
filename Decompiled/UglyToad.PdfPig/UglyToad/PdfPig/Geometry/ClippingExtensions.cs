using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Geometry.ClipperLibrary;
using UglyToad.PdfPig.Graphics;
using UglyToad.PdfPig.Logging;

namespace UglyToad.PdfPig.Geometry;

internal static class ClippingExtensions
{
	public const double Factor = 10000.0;

	private const int LinesInCurve = 10;

	public static PdfPath? Clip(this PdfPath clipping, PdfPath subject, ILog? log = null)
	{
		if (clipping == null)
		{
			throw new ArgumentNullException("clipping", "Clip: the clipping path cannot be null.");
		}
		if (!clipping.IsClipping)
		{
			throw new ArgumentException("Clip: the clipping path does not have the IsClipping flag set to true.", "clipping");
		}
		if (subject == null)
		{
			throw new ArgumentNullException("subject", "Clip: the subject path cannot be null.");
		}
		if (subject.Count == 0)
		{
			return subject;
		}
		Clipper clipper = new Clipper();
		foreach (PdfSubpath item in clipping)
		{
			if (item.Commands.Count != 0)
			{
				if (!item.IsClosed())
				{
					item.CloseSubpath();
				}
				if (!clipper.AddPath(item.ToClipperPolygon().ToList(), ClipperPolyType.Clip, Closed: true))
				{
					log?.Error("ClippingExtensions.Clip(): failed to add clipping subpath.");
				}
			}
		}
		bool flag = subject.IsFilled || subject.IsClipping;
		foreach (PdfSubpath item2 in subject)
		{
			if (item2.Commands.Count != 0)
			{
				if (flag && !item2.IsClosed() && item2.Commands.Count((PdfSubpath.IPathCommand sp) => sp is PdfSubpath.Line) < 2 && item2.Commands.Count((PdfSubpath.IPathCommand sp) => sp is PdfSubpath.BezierCurve) == 0)
				{
					flag = false;
				}
				if (flag && !item2.IsClosed())
				{
					item2.CloseSubpath();
				}
				if (!clipper.AddPath(item2.ToClipperPolygon().ToList(), ClipperPolyType.Subject, flag))
				{
					log?.Error("ClippingExtensions.Clip(): failed to add subject subpath for clipping.");
				}
			}
		}
		ClipperPolyFillType clipFillType = ((clipping.FillingRule == FillingRule.NonZeroWinding) ? ClipperPolyFillType.NonZero : ClipperPolyFillType.EvenOdd);
		ClipperPolyFillType subjFillType = ((subject.FillingRule == FillingRule.NonZeroWinding) ? ClipperPolyFillType.NonZero : ClipperPolyFillType.EvenOdd);
		if (!flag)
		{
			PdfPath pdfPath = subject.CloneEmpty();
			ClipperPolyTree clipperPolyTree = new ClipperPolyTree();
			if (clipper.Execute(ClipperClipType.Intersection, clipperPolyTree, subjFillType, clipFillType))
			{
				foreach (ClipperPolyNode child in clipperPolyTree.Children)
				{
					if (child.Contour.Count > 0)
					{
						PdfSubpath pdfSubpath = new PdfSubpath();
						pdfSubpath.MoveTo((double)child.Contour[0].X / 10000.0, (double)child.Contour[0].Y / 10000.0);
						for (int num = 1; num < child.Contour.Count; num++)
						{
							pdfSubpath.LineTo((double)child.Contour[num].X / 10000.0, (double)child.Contour[num].Y / 10000.0);
						}
						pdfPath.Add(pdfSubpath);
					}
				}
				if (pdfPath.Count > 0)
				{
					return pdfPath;
				}
			}
			return null;
		}
		PdfPath pdfPath2 = subject.CloneEmpty();
		List<List<ClipperIntPoint>> list = new List<List<ClipperIntPoint>>();
		if (!clipper.Execute(ClipperClipType.Intersection, list, subjFillType, clipFillType))
		{
			return null;
		}
		foreach (List<ClipperIntPoint> item3 in list)
		{
			if (item3.Count > 0)
			{
				PdfSubpath pdfSubpath2 = new PdfSubpath();
				pdfSubpath2.MoveTo((double)item3[0].X / 10000.0, (double)item3[0].Y / 10000.0);
				for (int num2 = 1; num2 < item3.Count; num2++)
				{
					pdfSubpath2.LineTo((double)item3[num2].X / 10000.0, (double)item3[num2].Y / 10000.0);
				}
				pdfSubpath2.CloseSubpath();
				pdfPath2.Add(pdfSubpath2);
			}
		}
		if (pdfPath2.Count > 0)
		{
			return pdfPath2;
		}
		return null;
	}

	internal static IEnumerable<ClipperIntPoint> ToClipperPolygon(this PdfSubpath pdfPath)
	{
		if (pdfPath.Commands.Count == 0)
		{
			yield break;
		}
		if (pdfPath.Commands[0] is PdfSubpath.Move move)
		{
			ClipperIntPoint movePoint = move.Location.ToClipperIntPoint();
			yield return movePoint;
			if (pdfPath.Commands.Count == 1)
			{
				yield break;
			}
			for (int i = 1; i < pdfPath.Commands.Count; i++)
			{
				PdfSubpath.IPathCommand pathCommand = pdfPath.Commands[i];
				if (pathCommand is PdfSubpath.Move)
				{
					throw new ArgumentException("ToClipperPolygon(): only one move allowed per subpath.", "pdfPath");
				}
				if (pathCommand is PdfSubpath.Line line)
				{
					yield return line.From.ToClipperIntPoint();
					yield return line.To.ToClipperIntPoint();
				}
				else if (pathCommand is PdfSubpath.BezierCurve bezierCurve)
				{
					foreach (PdfSubpath.Line lineB in bezierCurve.ToLines(10))
					{
						yield return lineB.From.ToClipperIntPoint();
						yield return lineB.To.ToClipperIntPoint();
					}
				}
				else if (pathCommand is PdfSubpath.Close)
				{
					yield return movePoint;
				}
			}
			yield break;
		}
		throw new ArgumentException($"ToClipperPolygon(): First command is not a Move command. Type is '{pdfPath.Commands[0].GetType()}'.", "pdfPath");
	}

	internal static IEnumerable<ClipperIntPoint> ToClipperPolygon(this PdfRectangle rectangle)
	{
		yield return rectangle.BottomLeft.ToClipperIntPoint();
		yield return rectangle.TopLeft.ToClipperIntPoint();
		yield return rectangle.TopRight.ToClipperIntPoint();
		yield return rectangle.BottomRight.ToClipperIntPoint();
	}

	internal static ClipperIntPoint ToClipperIntPoint(this PdfPoint point)
	{
		return new ClipperIntPoint(point.X * 10000.0, point.Y * 10000.0);
	}

	internal static List<ClipperIntPoint> ToClipperIntPoint(this PdfLine line)
	{
		return new List<ClipperIntPoint>
		{
			line.Point1.ToClipperIntPoint(),
			line.Point2.ToClipperIntPoint()
		};
	}
}
