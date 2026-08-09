using System;
using System.Collections.Generic;

namespace CSMath;

public struct BoundingBox
{
	public static readonly BoundingBox Null;

	public static readonly BoundingBox Infinite;

	public BoundingBoxExtent Extent { get; }

	public XYZ Min { get; set; }

	public XYZ Max { get; set; }

	public XYZ Center => Min + (Max - Min) * 0.5;

	public double Width => Max.X - Min.X;

	public double Height => Max.Y - Min.Y;

	private BoundingBox(BoundingBoxExtent extent)
	{
		Min = default(XYZ);
		Max = default(XYZ);
		Extent = extent;
		switch (extent)
		{
		case BoundingBoxExtent.Null:
			Max = new XYZ(double.NaN);
			Min = new XYZ(double.NaN);
			break;
		case BoundingBoxExtent.Infinite:
			Min = new XYZ(double.NegativeInfinity);
			Max = new XYZ(double.PositiveInfinity);
			break;
		case BoundingBoxExtent.Finite:
		case BoundingBoxExtent.Point:
			break;
		}
	}

	public BoundingBox(XYZ point)
	{
		Extent = BoundingBoxExtent.Point;
		Min = point;
		Max = point;
	}

	public BoundingBox(XYZ min, XYZ max)
	{
		if (min == max)
		{
			Extent = BoundingBoxExtent.Point;
		}
		else
		{
			Extent = BoundingBoxExtent.Finite;
		}
		Min = new XYZ(Math.Min(min.X, max.X), Math.Min(min.Y, max.Y), Math.Min(min.Z, max.Z));
		Max = new XYZ(Math.Max(min.X, max.X), Math.Max(min.Y, max.Y), Math.Max(min.Z, max.Z));
	}

	public BoundingBox(double minX, double minY, double minZ, double maxX, double maxY, double maxZ)
	{
		this = new BoundingBox(new XYZ(minX, minY, minZ), new XYZ(maxX, maxY, maxZ));
	}

	public BoundingBox Move(XYZ xyz)
	{
		return new BoundingBox(Min + xyz, Max + xyz);
	}

	public BoundingBox Merge(BoundingBox box)
	{
		if (Extent == BoundingBoxExtent.Infinite || box.Extent == BoundingBoxExtent.Infinite)
		{
			return Infinite;
		}
		if (Extent == BoundingBoxExtent.Null)
		{
			return box;
		}
		if (box.Extent == BoundingBoxExtent.Null)
		{
			return this;
		}
		XYZ min = new XYZ(Math.Min(Min.X, box.Min.X), Math.Min(Min.Y, box.Min.Y), Math.Min(Min.Z, box.Min.Z));
		XYZ max = new XYZ(Math.Max(Max.X, box.Max.X), Math.Max(Max.Y, box.Max.Y), Math.Max(Max.Z, box.Max.Z));
		return new BoundingBox(min, max);
	}

	public bool IsIn(BoundingBox box)
	{
		bool partialIn;
		return IsIn(box, out partialIn);
	}

	public bool IsIn(BoundingBox box, out bool partialIn)
	{
		bool flag = IsIn(box.Min);
		bool flag2 = IsIn(box.Max);
		partialIn = flag || flag2;
		return flag && flag2;
	}

	public bool IsIn(XYZ point)
	{
		if (Min.X > point.X || Min.Y > point.Y || Min.Z > point.Z)
		{
			return false;
		}
		if (Max.X < point.X || Max.Y < point.Y || Max.Z < point.Z)
		{
			return false;
		}
		return true;
	}

	public static BoundingBox Merge(IEnumerable<BoundingBox> boxes)
	{
		BoundingBox result = Null;
		foreach (BoundingBox box in boxes)
		{
			result = result.Merge(box);
		}
		return result;
	}

	public static BoundingBox FromPoints(IEnumerable<XYZ> points)
	{
		BoundingBox result = Null;
		foreach (XYZ point in points)
		{
			result = result.Merge(new BoundingBox(point));
		}
		return result;
	}

	static BoundingBox()
	{
		Null = new BoundingBox(BoundingBoxExtent.Null);
		Infinite = new BoundingBox(BoundingBoxExtent.Infinite);
	}
}
