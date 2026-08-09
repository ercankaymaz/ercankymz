namespace buCore.buClipperLib;

public struct IntPoint
{
	public long X;

	public long Y;

	public long Z;

	public IntPoint(long x, long y, long z = 0L)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public IntPoint(double x, double y, double z = 0.0)
	{
		X = (long)x;
		Y = (long)y;
		Z = (long)z;
	}

	public IntPoint(DoublePoint dp)
	{
		X = (long)dp.X;
		Y = (long)dp.Y;
		Z = 0L;
	}

	public IntPoint(IntPoint pt)
	{
		X = pt.X;
		Y = pt.Y;
		Z = pt.Z;
	}

	public static bool operator ==(IntPoint a, IntPoint b)
	{
		return a.X == b.X && a.Y == b.Y;
	}

	public static bool operator !=(IntPoint a, IntPoint b)
	{
		return a.X != b.X || a.Y != b.Y;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (!(obj is IntPoint intPoint))
			{
				return false;
			}
			return X == intPoint.X && Y == intPoint.Y;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
