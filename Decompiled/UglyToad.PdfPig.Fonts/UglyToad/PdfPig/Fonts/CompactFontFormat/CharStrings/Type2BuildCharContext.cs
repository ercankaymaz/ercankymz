using System.Collections.Generic;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat.CharStrings;

internal class Type2BuildCharContext
{
	private readonly Dictionary<int, double> transientArray = new Dictionary<int, double>();

	public CharStringStack Stack { get; } = new CharStringStack();

	public List<PdfSubpath> Path { get; } = new List<PdfSubpath>();

	public PdfPoint CurrentLocation { get; set; } = new PdfPoint(0, 0);

	public double? Width { get; set; }

	public void AddRelativeHorizontalLine(double dx)
	{
		AddRelativeLine(dx, 0.0);
	}

	public void AddRelativeVerticalLine(double dy)
	{
		AddRelativeLine(0.0, dy);
	}

	public void AddRelativeMoveTo(double dx, double dy)
	{
		BeforeMoveTo();
		PdfPoint currentLocation = new PdfPoint(CurrentLocation.X + dx, CurrentLocation.Y + dy);
		Path[Path.Count - 1].MoveTo(currentLocation.X, currentLocation.Y);
		CurrentLocation = currentLocation;
	}

	public void AddHorizontalMoveTo(double dx)
	{
		BeforeMoveTo();
		Path[Path.Count - 1].MoveTo(CurrentLocation.X + dx, CurrentLocation.Y);
		CurrentLocation = CurrentLocation.MoveX(dx);
	}

	public void AddVerticallMoveTo(double dy)
	{
		BeforeMoveTo();
		Path[Path.Count - 1].MoveTo(CurrentLocation.X, CurrentLocation.Y + dy);
		CurrentLocation = CurrentLocation.MoveY(dy);
	}

	public void AddRelativeBezierCurve(double dx1, double dy1, double dx2, double dy2, double dx3, double dy3)
	{
		double num = CurrentLocation.X + dx1;
		double num2 = CurrentLocation.Y + dy1;
		double num3 = num + dx2;
		double num4 = num2 + dy2;
		double num5 = num3 + dx3;
		double num6 = num4 + dy3;
		Path[Path.Count - 1].BezierCurveTo(num, num2, num3, num4, num5, num6);
		CurrentLocation = new PdfPoint(num5, num6);
	}

	public void AddRelativeLine(double dx, double dy)
	{
		PdfPoint currentLocation = new PdfPoint(CurrentLocation.X + dx, CurrentLocation.Y + dy);
		Path[Path.Count - 1].LineTo(currentLocation.X, currentLocation.Y);
		CurrentLocation = currentLocation;
	}

	public void AddVerticalStemHints(IReadOnlyList<(double start, double end)> hints)
	{
	}

	public void AddHorizontalStemHints(IReadOnlyList<(double start, double end)> hints)
	{
	}

	public void AddToTransientArray(double value, int location)
	{
		transientArray[location] = value;
	}

	private void BeforeMoveTo()
	{
		if (Path.Count > 0)
		{
			Path[Path.Count - 1].CloseSubpath();
		}
		Path.Add(new PdfSubpath());
	}

	public double GetFromTransientArray(int location)
	{
		double result = transientArray[location];
		transientArray.Remove(location);
		return result;
	}

	public static int CountToBias(int count)
	{
		if (count < 1240)
		{
			return 107;
		}
		if (count < 33900)
		{
			return 1131;
		}
		return 32768;
	}
}
