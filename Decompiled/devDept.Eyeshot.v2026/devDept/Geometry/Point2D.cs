using System;
using System.ComponentModel;
using devDept.Geometry.Converters;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
[TypeConverter(typeof(Point2DConverter))]
public class Point2D : ICloneable
{
	public double X;

	public double Y;

	[Browsable(false)]
	public virtual double MaximumCoordinate
	{
		get
		{
			double num = Math.Abs(X);
			if (Math.Abs(Y) > num)
			{
				num = Math.Abs(Y);
			}
			return num;
		}
	}

	public static Point2D Origin => new Point2D(0.0, 0.0);

	public static Point2D MinValue => new Point2D(double.MinValue, double.MinValue);

	public static Point2D MaxValue => new Point2D(double.MaxValue, double.MaxValue);

	[Browsable(false)]
	public Vector2D AsVector => new Vector2D(X, Y);

	public Point2D()
	{
	}

	public Point2D(double x, double y)
	{
		X = x;
		Y = y;
	}

	public Point2D(double[] p)
	{
		X = p[0];
		Y = p[1];
	}

	protected Point2D(Point2D another)
	{
		X = another.X;
		Y = another.Y;
	}

	public virtual object Clone()
	{
		return new Point2D(this);
	}

	public virtual double[] ToArray()
	{
		return new double[2] { X, Y };
	}

	public virtual bool IsValid()
	{
		if (!double.IsNaN(X))
		{
			return !double.IsNaN(Y);
		}
		return false;
	}

	public static Point2D operator +(Point2D a, Point2D b)
	{
		return new Point2D
		{
			X = a.X + b.X,
			Y = a.Y + b.Y
		};
	}

	public static Point2D operator +(Point2D a, Vector2D b)
	{
		return new Point2D(a.X + b.X, a.Y + b.Y);
	}

	public static Point2D operator +(Vector2D v, Point2D p)
	{
		return new Point2D(v.X + p.X, v.Y + p.Y);
	}

	public static Point2D operator -(Point2D a, Point2D b)
	{
		return new Point2D
		{
			X = a.X - b.X,
			Y = a.Y - b.Y
		};
	}

	public static Point2D operator -(Point2D a, Vector2D b)
	{
		return new Point2D
		{
			X = a.X - b.X,
			Y = a.Y - b.Y
		};
	}

	public static Point2D operator -(Vector2D v, Point2D p)
	{
		return new Point2D(v.X - p.X, v.Y - p.Y);
	}

	public static Point2D operator *(double s, Point2D p)
	{
		return new Point2D
		{
			X = s * p.X,
			Y = s * p.Y
		};
	}

	public static Point2D operator *(Point2D p, double s)
	{
		return new Point2D
		{
			X = s * p.X,
			Y = s * p.Y
		};
	}

	public static Point2D operator /(Point2D p, double s)
	{
		return new Point2D
		{
			X = p.X / s,
			Y = p.Y / s
		};
	}

	public Point2D ProjectTo(Segment2D seg)
	{
		Vector2D vector2D = new Vector2D(seg.P1.X - seg.P0.X, seg.P1.Y - seg.P0.Y);
		Vector2D vector2D2 = new Vector2D(X - seg.P0.X, Y - seg.P0.Y);
		double num = vector2D.X * vector2D.X + vector2D.Y * vector2D.Y;
		double num2 = ((num < 1E-09) ? 0.0 : (vector2D * vector2D2 / num));
		return new Point2D(seg.P0.X + num2 * vector2D.X, seg.P0.Y + num2 * vector2D.Y);
	}

	public Point2D ProjectTo(Point2D rectMin, Point2D rectMax)
	{
		double x = Utility.Clamp(in X, in rectMin.X, in rectMax.X);
		double y = Utility.Clamp(in Y, in rectMin.Y, in rectMax.Y);
		return new Point2D(x, y);
	}

	public double DistanceTo(Segment2D seg)
	{
		Point2D b = ProjectTo(seg);
		return DistanceTo(b);
	}

	public bool Equals(Point2D other)
	{
		if (Utility.Compare(other.X, X) != 0)
		{
			return false;
		}
		if (Utility.Compare(other.Y, Y) != 0)
		{
			return false;
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Point2D))
		{
			return false;
		}
		return Equals((Point2D)obj);
	}

	public override int GetHashCode()
	{
		return (X.GetHashCode() * 397) ^ Y.GetHashCode();
	}

	public static bool operator ==(Point2D left, Point2D right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Point2D left, Point2D right)
	{
		return !object.Equals(left, right);
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977515), X, Y);
	}

	public virtual string ToStringXml()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659163), Utility.WriteFloatNumber(X), Utility.WriteFloatNumber(Y));
	}

	public static Point2D MidPoint(Point2D a, Point2D b)
	{
		return new Point2D((a.X + b.X) / 2.0, (a.Y + b.Y) / 2.0);
	}

	public static double Distance(Point2D a, Point2D b)
	{
		double num = b.X - a.X;
		double num2 = b.Y - a.Y;
		return Math.Sqrt(num * num + num2 * num2);
	}

	public static double DistanceSquared(Point2D a, Point2D b)
	{
		double num = b.X - a.X;
		double num2 = b.Y - a.Y;
		return num * num + num2 * num2;
	}

	public double DistanceTo(Point2D b)
	{
		return Distance(this, b);
	}

	public static bool AreEqual(Point2D p1, Point2D p2, double domainSize)
	{
		return DistanceSquared(p1, p2) < 1E-18 * domainSize * domainSize;
	}

	public virtual void TransformBy(Transformation xform)
	{
		double[] array = xform.ActOnLeft(X, Y, 0.0, 1.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		X = num * array[0];
		Y = num * array[1];
	}

	public virtual Point2DSurrogate ConvertToSurrogate()
	{
		return new Point2DSurrogate(this);
	}
}
