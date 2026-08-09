namespace UglyToad.PdfPig.Geometry.ClipperLibrary;

internal struct ClipperIntPoint(long x, long y)
{
	public long X = x;

	public long Y = y;

	public ClipperIntPoint(double x, double y)
		: this((long)x, (long)y)
	{
	}

	public ClipperIntPoint(ClipperIntPoint pt)
		: this(pt.X, pt.Y)
	{
	}

	public static bool operator ==(ClipperIntPoint a, ClipperIntPoint b)
	{
		if (a.X == b.X)
		{
			return a.Y == b.Y;
		}
		return false;
	}

	public static bool operator !=(ClipperIntPoint a, ClipperIntPoint b)
	{
		if (a.X == b.X)
		{
			return a.Y != b.Y;
		}
		return true;
	}

	public override bool Equals(object? obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is ClipperIntPoint clipperIntPoint)
		{
			if (X == clipperIntPoint.X)
			{
				return Y == clipperIntPoint.Y;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
