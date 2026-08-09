using System;
using ns54;

namespace Poly2Tri.Utility;

public class Point2D : IComparable<Point2D>
{
	private double x;

	private double y;

	public virtual double X
	{
		get
		{
			return x;
		}
		set
		{
			x = value;
		}
	}

	public virtual double Y
	{
		get
		{
			return y;
		}
		set
		{
			y = value;
		}
	}

	public float Xf => (float)X;

	public float Yf => (float)Y;

	public Point2D()
	{
		x = 0.0;
		y = 0.0;
	}

	public Point2D(double x, double y)
	{
		this.x = x;
		this.y = y;
	}

	public override string ToString()
	{
		return $"[{X},{Y}]";
	}

	public override int GetHashCode()
	{
		return 378163771 * x.GetHashCode() + 113137337 * y.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Point2D p))
		{
			return false;
		}
		return Equals(p);
	}

	public bool Equals(Point2D p, double epsilon = 0.0)
	{
		if (p != null && MathUtil.AreValuesEqual(X, p.X, epsilon) && MathUtil.AreValuesEqual(Y, p.Y, epsilon))
		{
			return true;
		}
		return false;
	}

	public int CompareTo(Point2D other)
	{
		if (!(Y < other.Y))
		{
			if (!(Y > other.Y))
			{
				if (!(X < other.X))
				{
					if (!(X > other.X))
					{
						return 0;
					}
					return 1;
				}
				return -1;
			}
			return 1;
		}
		return -1;
	}

	public virtual void Set(double x, double y)
	{
		X = x;
		Y = y;
	}

	public void Subtract(Point2D p)
	{
		X -= p.X;
		Y -= p.Y;
	}

	public double Magnitude()
	{
		return Math.Sqrt(MagnitudeSquared());
	}

	public double MagnitudeSquared()
	{
		return X * X + Y * Y;
	}

	public void Normalize()
	{
		Class156.smethod_58(this, Class156.smethod_217(this));
	}

	public double Dot(Point2D p)
	{
		return X * p.X + Y * p.Y;
	}

	public double Cross(Point2D p)
	{
		return X * p.Y - Y * p.X;
	}

	public static double Dot(Point2D lhs, Point2D rhs)
	{
		return lhs.X * rhs.X + lhs.Y * rhs.Y;
	}

	public static double Cross(Point2D lhs, Point2D rhs)
	{
		return lhs.X * rhs.Y - lhs.Y * rhs.X;
	}

	public static Point2D Perpendicular(Point2D lhs, double scalar)
	{
		return new Point2D(lhs.Y * scalar, lhs.X * (0.0 - scalar));
	}

	public static Point2D Perpendicular(double scalar, Point2D rhs)
	{
		return new Point2D((0.0 - scalar) * rhs.Y, scalar * rhs.X);
	}

	public static Point2D operator +(Point2D lhs, Point2D rhs)
	{
		return new Point2D(lhs.X + rhs.X, lhs.Y + rhs.Y);
	}

	public static Point2D operator +(Point2D lhs, double scalar)
	{
		return new Point2D(lhs.X + scalar, lhs.Y + scalar);
	}

	public static Point2D operator -(Point2D lhs, Point2D rhs)
	{
		return new Point2D(lhs.X - rhs.X, lhs.Y - rhs.Y);
	}

	public static Point2D operator -(Point2D lhs, double scalar)
	{
		return new Point2D(lhs.X - scalar, lhs.Y - scalar);
	}

	public static Point2D operator *(Point2D lhs, Point2D rhs)
	{
		return new Point2D(lhs.X * rhs.X, lhs.Y * rhs.Y);
	}

	public static Point2D operator *(Point2D lhs, double scalar)
	{
		return new Point2D(lhs.X * scalar, lhs.Y * scalar);
	}

	public static Point2D operator *(double scalar, Point2D rhs)
	{
		return rhs * scalar;
	}

	public static Point2D operator /(Point2D lhs, Point2D rhs)
	{
		return new Point2D(lhs.X / rhs.X, lhs.Y / rhs.Y);
	}

	public static Point2D operator /(Point2D lhs, double scalar)
	{
		return new Point2D(lhs.X / scalar, lhs.Y / scalar);
	}

	public static Point2D operator -(Point2D p)
	{
		return new Point2D(0.0 - p.X, 0.0 - p.Y);
	}

	public static bool operator <(Point2D lhs, Point2D rhs)
	{
		return lhs.CompareTo(rhs) == -1;
	}

	public static bool operator >(Point2D lhs, Point2D rhs)
	{
		return lhs.CompareTo(rhs) == 1;
	}

	public static bool operator <=(Point2D lhs, Point2D rhs)
	{
		return lhs.CompareTo(rhs) <= 0;
	}

	public static bool operator >=(Point2D lhs, Point2D rhs)
	{
		return lhs.CompareTo(rhs) >= 0;
	}
}
