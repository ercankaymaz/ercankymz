using System;
using System.ComponentModel;
using devDept.Geometry.Converters;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
[TypeConverter(typeof(Vector2DConverter))]
public class Vector2D : ICloneable
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

	[Browsable(false)]
	public Point2D AsPoint => new Point2D(X, Y);

	[Browsable(false)]
	public bool IsUnit => Math.Abs(1.0 - Length) < 1E-09;

	[Browsable(false)]
	public bool IsZero => Length < 1E-09;

	[Browsable(false)]
	public double Length
	{
		get
		{
			return Math.Sqrt(X * X + Y * Y);
		}
		set
		{
			double num = Math.Sqrt(X * X + Y * Y);
			if (num > 1E-09)
			{
				X *= value / num;
				Y *= value / num;
			}
		}
	}

	[Browsable(false)]
	public double LengthSquared => X * X + Y * Y;

	public static Vector2D AxisX => new Vector2D(1.0, 0.0);

	public static Vector2D AxisY => new Vector2D(0.0, 1.0);

	[Browsable(false)]
	public double Angle => Math.Atan2(Y, X);

	public Vector2D()
	{
	}

	public Vector2D(double x, double y)
	{
		X = x;
		Y = y;
	}

	public Vector2D(Point2D P0, Point2D P1)
	{
		X = P1.X - P0.X;
		Y = P1.Y - P0.Y;
	}

	public Vector2D(double[] v)
	{
		X = v[0];
		Y = v[1];
	}

	protected Vector2D(Vector2D another)
	{
		X = another.X;
		Y = another.Y;
	}

	public virtual object Clone()
	{
		return new Vector2D(this);
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

	public static Vector2D operator *(double s, Vector2D v)
	{
		return new Vector2D(s * v.X, s * v.Y);
	}

	public static Vector2D operator *(Vector2D v, double s)
	{
		return new Vector2D(s * v.X, s * v.Y);
	}

	public static Vector2D Subtract(Point2D a, Point2D b)
	{
		return new Vector2D(a.X - b.X, a.Y - b.Y);
	}

	public static Vector2D Add(Point2D a, Point2D b)
	{
		return new Vector2D(a.X + b.X, a.Y + b.Y);
	}

	public bool Normalize()
	{
		double num = Math.Sqrt(X * X + Y * Y);
		if (num > 2.2250738585072014E-308)
		{
			X /= num;
			Y /= num;
			return true;
		}
		return false;
	}

	public static double AngleBetween(Vector2D u, Vector2D v)
	{
		double value = u * v;
		Utility.LimitRange(-1.0, ref value, 1.0);
		return Math.Acos(value);
	}

	public static double SignedAngleBetween(Vector2D u, Vector2D v)
	{
		return Math.Atan2(PerpDotProduct(u, v), Dot(u, v));
	}

	public static double PerpDotProduct(Vector2D u, Vector2D v)
	{
		return u.X * v.Y - u.Y * v.X;
	}

	public static Vector2D operator -(Vector2D u, Vector2D v)
	{
		return new Vector2D(u.X - v.X, u.Y - v.Y);
	}

	public static Vector2D operator +(Vector2D u, Vector2D v)
	{
		return new Vector2D(u.X + v.X, u.Y + v.Y);
	}

	public static double Dot(Vector2D u, Vector2D v)
	{
		return u.X * v.X + u.Y * v.Y;
	}

	public static double operator *(Vector2D u, Vector2D v)
	{
		return u.X * v.X + u.Y * v.Y;
	}

	public static bool operator ==(Vector2D left, Vector2D right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Vector2D left, Vector2D right)
	{
		return !object.Equals(left, right);
	}

	public static double Dot(Vector2D v, Point2D p)
	{
		return v.X * p.X + v.Y * p.Y;
	}

	public static double Dot(Point2D p, Vector2D v)
	{
		return p.X * v.X + p.Y * v.Y;
	}

	public void Zero()
	{
		X = (Y = 0.0);
	}

	public static bool AreCoincident(Vector2D u, Vector2D v)
	{
		return AreCoincident(u, v, Utility._0023_003DzheSR8QM7q9ya);
	}

	public static bool AreCoincident(Vector2D u, Vector2D v, double tol)
	{
		return Math.Abs(1.0 - u * v) < tol;
	}

	public static bool AreOpposite(Vector2D u, Vector2D v)
	{
		return AreOpposite(u, v, Utility._0023_003DzheSR8QM7q9ya);
	}

	public static bool AreOpposite(Vector2D u, Vector2D v, double tol)
	{
		return Math.Abs(u * v + 1.0) < tol;
	}

	public static bool AreParallel(Vector2D u, Vector2D v)
	{
		return AreParallel(u, v, Utility._0023_003DzheSR8QM7q9ya);
	}

	public static bool AreParallel(Vector2D u, Vector2D v, double tol)
	{
		return Math.Abs(Math.Abs(u * v) - 1.0) < tol;
	}

	public static bool AreOrthogonal(Vector2D u, Vector2D v)
	{
		return AreOrthogonal(u, v, Utility._0023_003DzheSR8QM7q9ya);
	}

	public static bool AreOrthogonal(Vector2D u, Vector2D v, double tol)
	{
		return Math.Abs(u * v) < tol;
	}

	public bool Equals(Vector2D other)
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
		if (!(obj is Vector2D))
		{
			return false;
		}
		return Equals((Vector2D)obj);
	}

	public override int GetHashCode()
	{
		return (X.GetHashCode() * 397) ^ Y.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663096), X, Y, Length);
	}

	public virtual string ToStringXml()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659163), Utility.WriteFloatNumber(X), Utility.WriteFloatNumber(Y));
	}

	public virtual void Negate()
	{
		X = 0.0 - X;
		Y = 0.0 - Y;
	}

	public virtual void TransformBy(Transformation xform)
	{
		double[] array = xform.ActOnLeft(X, Y, 0.0, 0.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		X = num * array[0];
		Y = num * array[1];
	}

	public virtual Vector2DSurrogate ConvertToSurrogate()
	{
		return new Vector2DSurrogate(this);
	}

	public virtual Vector2D_V6Surrogate ConvertToSurrogate_V6()
	{
		return new Vector2D_V6Surrogate(this);
	}
}
