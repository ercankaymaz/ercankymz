using System;
using System.ComponentModel;
using devDept.Geometry.Converters;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
[TypeConverter(typeof(Point4DConverter))]
public class Point4D : Point3D
{
	public double W;

	public override double MaximumCoordinate
	{
		get
		{
			double num = base.MaximumCoordinate;
			if (Math.Abs(W) > num)
			{
				num = Math.Abs(W);
			}
			return num;
		}
	}

	public Point3D Euclid
	{
		get
		{
			return new Point3D(X / W, Y / W, Z / W);
		}
		set
		{
			X = value.X * W;
			Y = value.Y * W;
			Z = value.Z * W;
		}
	}

	public Point4D()
	{
	}

	public Point4D(double x, double y)
		: base(x, y)
	{
		W = 1.0;
	}

	public Point4D(double x, double y, double z)
		: base(x, y, z)
	{
		W = 1.0;
	}

	public Point4D(double x, double y, double z, double w)
		: base(x, y, z)
	{
		W = w;
	}

	public Point4D(double[] coords)
		: base(coords)
	{
		W = coords[3];
	}

	public Point4D(Point3D pt)
		: base(pt.X, pt.Y, pt.Z)
	{
		W = 1.0;
	}

	protected Point4D(Point4D another)
	{
		X = another.X;
		Y = another.Y;
		Z = another.Z;
		W = another.W;
	}

	public override object Clone()
	{
		return new Point4D(this);
	}

	public override double[] ToArray()
	{
		return new double[4] { X, Y, Z, W };
	}

	public override bool IsValid()
	{
		if (!double.IsNaN(X) && !double.IsNaN(Y) && !double.IsNaN(Z))
		{
			return !double.IsNaN(W);
		}
		return false;
	}

	public static Point4D operator *(double value, Point4D p)
	{
		return new Point4D
		{
			X = value * p.X,
			Y = value * p.Y,
			Z = value * p.Z,
			W = value * p.W
		};
	}

	public static Point4D operator *(Point4D p, double value)
	{
		return value * p;
	}

	public static Point4D operator /(Point4D p, double s)
	{
		double num = 1.0 / s;
		return new Point4D
		{
			X = p.X * num,
			Y = p.Y * num,
			Z = p.Z * num,
			W = p.W * num
		};
	}

	public static Point4D operator +(Point4D a, Point4D b)
	{
		return new Point4D(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
	}

	public static Point4D operator -(Point4D a, Point4D b)
	{
		return new Point4D(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
	}

	public static double Distance(Point4D a, Point4D b)
	{
		return Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y) + (b.Z - a.Z) * (b.Z - a.Z) + (b.W - a.W) * (b.W - a.W));
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659145), X, Y, Z, W);
	}

	public bool Equals(Point4D other)
	{
		if (Equals((Point3D)other))
		{
			return Utility.Compare(other.W, W) == 0;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Point4D))
		{
			return false;
		}
		return Equals(obj as Point4D);
	}

	public override int GetHashCode()
	{
		return (base.GetHashCode() * 397) ^ W.GetHashCode();
	}

	public static bool operator ==(Point4D left, Point4D right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Point4D left, Point4D right)
	{
		return !object.Equals(left, right);
	}

	public override void TransformBy(Transformation xform)
	{
		double[] array = xform.ActOnLeft(X, Y, Z, W);
		X = array[0];
		Y = array[1];
		Z = array[2];
		W = array[3];
	}

	public override Point2DSurrogate ConvertToSurrogate()
	{
		return new Point4DSurrogate(this);
	}

	public override string ToStringXml()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659090), Utility.WriteFloatNumber(X), Utility.WriteFloatNumber(Y), Utility.WriteFloatNumber(Z), Utility.WriteFloatNumber(W));
	}
}
