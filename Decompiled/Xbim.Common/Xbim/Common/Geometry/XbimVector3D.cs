using System;
using System.Runtime.InteropServices;

namespace Xbim.Common.Geometry;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct XbimVector3D : IVector3D
{
	public static readonly XbimVector3D Zero;

	private const double Tolerance = 1E-09;

	public readonly double X;

	public readonly double Y;

	public readonly double Z;

	public double Length => length();

	public double Modulus => X * X + Y * Y + Z * Z;

	double IVector3D.X => X;

	double IVector3D.Y => Y;

	double IVector3D.Z => Z;

	public double Angle(XbimVector3D other)
	{
		double num = DotProduct(other) / (Length * other.Length);
		if (num > -0.70710678118655 && num < 0.70710678118655)
		{
			return Math.Acos(num);
		}
		double d = CrossProduct(other).Length / (Length * other.Length);
		if (num < 0.0)
		{
			return Math.PI - Math.Asin(d);
		}
		return Math.Asin(d);
	}

	public bool IsOpposite(XbimVector3D other, double angularTolerance)
	{
		return Math.PI - Angle(other) <= angularTolerance;
	}

	public bool IsParallel(XbimVector3D other, double angularTolerance)
	{
		double num = Angle(other);
		if (!(num <= angularTolerance))
		{
			return Math.PI - num <= angularTolerance;
		}
		return true;
	}

	public bool IsNormal(XbimVector3D other, double angularTolerance)
	{
		double num = Math.PI / 2.0 - Angle(other);
		if (num < 0.0)
		{
			num = 0.0 - num;
		}
		return num <= angularTolerance;
	}

	private double length()
	{
		return Math.Sqrt(X * X + Y * Y + Z * Z);
	}

	public XbimVector3D(double vx, double vy, double vz)
	{
		X = vx;
		Y = vy;
		Z = vz;
	}

	public XbimVector3D(double v)
	{
		X = v;
		Y = v;
		Z = v;
	}

	public static XbimVector3D Min(XbimVector3D a, XbimVector3D b)
	{
		return new XbimVector3D((a.X < b.X) ? a.X : b.X, (a.Y < b.Y) ? a.Y : b.Y, (a.Z < b.Z) ? a.Z : b.Z);
	}

	public static XbimVector3D Max(XbimVector3D a, XbimVector3D b)
	{
		return new XbimVector3D((a.X > b.X) ? a.X : b.X, (a.Y > b.Y) ? a.Y : b.Y, (a.Z > b.Z) ? a.Z : b.Z);
	}

	public override int GetHashCode()
	{
		double x = X;
		int hashCode = x.GetHashCode();
		x = Y;
		int num = hashCode ^ x.GetHashCode();
		x = Z;
		return num ^ x.GetHashCode();
	}

	public override bool Equals(object ob)
	{
		if (ob is XbimVector3D xbimVector3D)
		{
			if (Math.Abs(X - xbimVector3D.X) < 1E-09 && Math.Abs(Y - xbimVector3D.Y) < 1E-09)
			{
				return Math.Abs(Z - xbimVector3D.Z) < 1E-09;
			}
			return false;
		}
		return false;
	}

	public override string ToString()
	{
		return $"[{X}, {Y}, {Z}]";
	}

	public static bool operator !=(XbimVector3D v1, XbimVector3D v2)
	{
		return !v1.Equals(v2);
	}

	public static bool operator ==(XbimVector3D v1, XbimVector3D v2)
	{
		return v1.Equals(v2);
	}

	public static XbimVector3D operator +(XbimVector3D vector1, XbimVector3D vector2)
	{
		return new XbimVector3D(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);
	}

	public static XbimVector3D Add(XbimVector3D vector1, XbimVector3D vector2)
	{
		return new XbimVector3D(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);
	}

	public static XbimVector3D operator -(XbimVector3D vector1, XbimVector3D vector2)
	{
		return new XbimVector3D(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);
	}

	public static XbimVector3D Subtract(XbimVector3D vector1, XbimVector3D vector2)
	{
		return new XbimVector3D(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);
	}

	public static XbimVector3D operator *(double l, XbimVector3D v1)
	{
		return Multiply(l, v1);
	}

	public static XbimVector3D operator *(XbimVector3D v1, double l)
	{
		return Multiply(l, v1);
	}

	public static XbimVector3D operator *(XbimVector3D v1, XbimMatrix3D m)
	{
		return Multiply(v1, m);
	}

	public static XbimVector3D Multiply(double val, XbimVector3D vec)
	{
		return new XbimVector3D(vec.X * val, vec.Y * val, vec.Z * val);
	}

	public static XbimVector3D Multiply(XbimVector3D vec, XbimMatrix3D m)
	{
		double x = vec.X;
		double y = vec.Y;
		double z = vec.Z;
		return new XbimVector3D(m.M11 * x + m.M21 * y + m.M31 * z, m.M12 * x + m.M22 * y + m.M32 * z, m.M13 * x + m.M23 * y + m.M33 * z);
	}

	public XbimVector3D Normalized()
	{
		double x = X;
		double y = Y;
		double z = Z;
		double num = Math.Sqrt(x * x + y * y + z * z);
		if (Math.Abs(num) < 1E-09)
		{
			return new XbimVector3D(0.0, 0.0, 0.0);
		}
		num = 1.0 / num;
		x *= num;
		y *= num;
		z *= num;
		if (Math.Abs(x - 1.0) < 1E-09)
		{
			return new XbimVector3D(Math.Sign(x), 0.0, 0.0);
		}
		if (Math.Abs(y - 1.0) < 1E-09)
		{
			return new XbimVector3D(0.0, Math.Sign(y), 0.0);
		}
		if (Math.Abs(z - 1.0) < 1E-09)
		{
			return new XbimVector3D(0.0, 0.0, Math.Sign(z));
		}
		return new XbimVector3D(x, y, z);
	}

	public XbimVector3D CrossProduct(XbimVector3D v2)
	{
		return CrossProduct(this, v2);
	}

	public static XbimVector3D CrossProduct(XbimVector3D v1, XbimVector3D v2)
	{
		double x = v1.X;
		double y = v1.Y;
		double z = v1.Z;
		double x2 = v2.X;
		double y2 = v2.Y;
		double z2 = v2.Z;
		return new XbimVector3D(y * z2 - z * y2, z * x2 - x * z2, x * y2 - y * x2);
	}

	public XbimVector3D Negated()
	{
		return new XbimVector3D(0.0 - X, 0.0 - Y, 0.0 - Z);
	}

	public static double DotProduct(XbimVector3D v1, XbimVector3D v2)
	{
		return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
	}

	public double DotProduct(XbimVector3D v2)
	{
		return DotProduct(this, v2);
	}

	public bool IsInvalid()
	{
		if (Math.Abs(X) < 1E-09 && Math.Abs(Y) < 1E-09)
		{
			return Math.Abs(Z) < 1E-09;
		}
		return false;
	}

	public bool IsEqual(XbimVector3D b, double precision = 1E-09)
	{
		return Math.Abs(DotProduct(b) - 1.0) <= precision;
	}

	static XbimVector3D()
	{
		Zero = new XbimVector3D(0.0, 0.0, 0.0);
	}
}
