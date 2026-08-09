using System;

namespace Poly2Tri.Utility;

public struct Rect2D
{
	private readonly double double_0;

	private readonly double double_1;

	private readonly double double_2;

	private readonly double double_3;

	public double MinX => double_0;

	public double MaxX => double_1;

	public double MinY => double_2;

	public double MaxY => double_3;

	public double Left => double_0;

	public double Right => double_1;

	public double Top => double_3;

	public double Bottom => double_2;

	public double Width => Right - Left;

	public double Height => Top - Bottom;

	public bool IsEmpty => !(Math.Abs(Width) >= 1.401298464324817E-45) || Math.Abs(Height) < 1.401298464324817E-45;

	private Rect2D(double double_4, double double_5, double double_6, double double_7)
	{
		double_0 = double_4;
		double_1 = double_5;
		double_2 = double_6;
		double_3 = double_7;
	}

	public override int GetHashCode()
	{
		return 54734431 * double_0.GetHashCode() + 1122547711 * double_2.GetHashCode() + 1097393683 * double_1.GetHashCode() + 1198754321 * double_3.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		return obj is Rect2D && method_0((Rect2D)obj);
	}

	private bool method_0(Rect2D rect2D_0, double double_4 = 1E-12)
	{
		return MathUtil.AreValuesEqual(MinX, rect2D_0.MinX, double_4) && MathUtil.AreValuesEqual(MaxX, rect2D_0.MaxX, double_4) && MathUtil.AreValuesEqual(MinY, rect2D_0.MinY, double_4) && MathUtil.AreValuesEqual(MaxY, rect2D_0.MaxY, double_4);
	}

	public bool Intersects(Rect2D r)
	{
		return !(Right <= r.Left) && Left < r.Right && Bottom < r.Top && Top > r.Bottom;
	}

	public Rect2D AddPoint(Point2D p)
	{
		return new Rect2D(Math.Min(MinX, p.X), Math.Max(MaxX, p.X), Math.Min(MinY, p.Y), Math.Max(MaxY, p.Y));
	}
}
