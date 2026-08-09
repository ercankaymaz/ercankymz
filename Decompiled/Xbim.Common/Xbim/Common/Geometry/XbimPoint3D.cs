using System;
using System.Runtime.InteropServices;

namespace Xbim.Common.Geometry;

[StructLayout(LayoutKind.Sequential, Pack = 8)]
public struct XbimPoint3D(double x, double y, double z)
{
	private const double Tolerance = 1E-09;

	public readonly double X = x;

	public readonly double Y = y;

	public readonly double Z = z;

	public static readonly XbimPoint3D Zero = new XbimPoint3D(0.0, 0.0, 0.0);

	public override string ToString()
	{
		return $"{X} {Y} {Z}";
	}

	public override bool Equals(object ob)
	{
		if (ob is XbimPoint3D xbimPoint3D)
		{
			if (Math.Abs(X - xbimPoint3D.X) < 1E-09 && Math.Abs(Y - xbimPoint3D.Y) < 1E-09)
			{
				return Math.Abs(Z - xbimPoint3D.Z) < 1E-09;
			}
			return false;
		}
		return false;
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

	public static XbimPoint3D operator +(XbimPoint3D p, XbimVector3D v)
	{
		return Add(p, v);
	}

	public static XbimPoint3D Add(XbimPoint3D p, XbimVector3D v)
	{
		return new XbimPoint3D(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
	}

	public static XbimPoint3D Add(XbimPoint3D p, XbimPoint3D v)
	{
		return new XbimPoint3D(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
	}

	public static XbimPoint3D operator *(XbimPoint3D p, XbimMatrix3D m)
	{
		return Multiply(p, m);
	}

	public static XbimPoint3D Multiply(XbimPoint3D p, XbimMatrix3D m)
	{
		double x = p.X;
		double y = p.Y;
		double z = p.Z;
		XbimPoint3D result = new XbimPoint3D(m.M11 * x + m.M21 * y + m.M31 * z + m.OffsetX, m.M12 * x + m.M22 * y + m.M32 * z + m.OffsetY, m.M13 * x + m.M23 * y + m.M33 * z + m.OffsetZ);
		if (m.IsAffine)
		{
			return result;
		}
		double num = x * m.M14 + y * m.M24 + z * m.M34 + m.M44;
		x = result.X / num;
		y = result.Y / num;
		z = result.Z / num;
		return new XbimPoint3D(x, y, z);
	}

	public static XbimVector3D operator -(XbimPoint3D a, XbimPoint3D b)
	{
		return Subtract(a, b);
	}

	public static XbimPoint3D operator -(XbimPoint3D a, XbimVector3D b)
	{
		return new XbimPoint3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
	}

	public static XbimVector3D Subtract(XbimPoint3D a, XbimPoint3D b)
	{
		return new XbimVector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
	}

	public static bool operator ==(XbimPoint3D left, XbimPoint3D right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(XbimPoint3D left, XbimPoint3D right)
	{
		return !(left == right);
	}
}
