using System;
using System.ComponentModel;
using System.IO;
using devDept.Geometry.Converters;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
[TypeConverter(typeof(Vector3DConverter))]
public class Vector3D : Vector2D
{
	public double Z;

	public double this[int index] => index switch
	{
		0 => X, 
		1 => Y, 
		_ => Z, 
	};

	public new static Vector3D AxisX => new Vector3D(1.0, 0.0, 0.0);

	public static Vector3D AxisMinusX => new Vector3D(-1.0, 0.0, 0.0);

	public new static Vector3D AxisY => new Vector3D(0.0, 1.0, 0.0);

	public static Vector3D AxisMinusY => new Vector3D(0.0, -1.0, 0.0);

	public static Vector3D AxisZ => new Vector3D(0.0, 0.0, 1.0);

	public static Vector3D AxisMinusZ => new Vector3D(0.0, 0.0, -1.0);

	[Browsable(false)]
	public new bool IsZero => Length < 1E-09;

	[Browsable(false)]
	public new bool IsUnit => Math.Abs(1.0 - Length) < 1E-09;

	[Browsable(false)]
	public new double Length
	{
		get
		{
			return Math.Sqrt(X * X + Y * Y + Z * Z);
		}
		set
		{
			double num = Math.Sqrt(X * X + Y * Y + Z * Z);
			if (num > 1E-09)
			{
				X *= value / num;
				Y *= value / num;
				Z *= value / num;
			}
		}
	}

	[Browsable(false)]
	public new double LengthSquared => X * X + Y * Y + Z * Z;

	[Browsable(false)]
	public double AngleInXY => Math.Atan2(Y, X);

	[Browsable(false)]
	public double AngleFromXY
	{
		get
		{
			double x = Math.Sqrt(X * X + Y * Y);
			return Math.Atan2(Z, x);
		}
	}

	[Browsable(false)]
	public new Point3D AsPoint => new Point3D(X, Y, Z);

	public override double MaximumCoordinate
	{
		get
		{
			double num = base.MaximumCoordinate;
			if (Math.Abs(Z) > num)
			{
				num = Math.Abs(Z);
			}
			return num;
		}
	}

	public Vector3D()
	{
	}

	public Vector3D(double x, double y)
		: base(x, y)
	{
	}

	public Vector3D(double x, double y, double z)
		: base(x, y)
	{
		Z = z;
	}

	public Vector3D(double[] v)
		: base(v)
	{
		Z = v[2];
	}

	public Vector3D(Point3D P0, Point3D P1)
	{
		X = P1.X - P0.X;
		Y = P1.Y - P0.Y;
		Z = P1.Z - P0.Z;
	}

	public Vector3D(Point3D P0, Point3D P1, Point3D P2)
	{
		Zero();
		Vector3D vector3D = Subtract(P2, P1);
		Vector3D vector3D2 = Subtract(P0, P2);
		Vector3D vector3D3 = Subtract(P1, P0);
		Vector3D vector3D4 = Cross(vector3D2, vector3D3);
		if (!vector3D4.Normalize())
		{
			return;
		}
		Vector3D vector3D5 = Cross(vector3D3, vector3D);
		if (!vector3D5.Normalize())
		{
			return;
		}
		Vector3D vector3D6 = Cross(vector3D, vector3D2);
		if (!vector3D6.Normalize())
		{
			return;
		}
		double num = 1.0 / vector3D.Length;
		double num2 = 1.0 / vector3D2.Length;
		double num3 = 1.0 / vector3D3.Length;
		double num4 = num * Math.Abs(Dot(vector3D4, vector3D)) + num2 * Math.Abs(Dot(vector3D4, vector3D2)) + num3 * Math.Abs(Dot(vector3D4, vector3D3));
		double num5 = num * Math.Abs(Dot(vector3D5, vector3D)) + num2 * Math.Abs(Dot(vector3D5, vector3D2)) + num3 * Math.Abs(Dot(vector3D5, vector3D3));
		double num6 = num * Math.Abs(Dot(vector3D6, vector3D)) + num2 * Math.Abs(Dot(vector3D6, vector3D2)) + num3 * Math.Abs(Dot(vector3D6, vector3D3));
		if (num4 <= num5)
		{
			if (num4 <= num6)
			{
				X = vector3D4.X;
				Y = vector3D4.Y;
				Z = vector3D4.Z;
			}
			else
			{
				X = vector3D6.X;
				Y = vector3D6.Y;
				Z = vector3D6.Z;
			}
		}
		else if (num5 <= num6)
		{
			X = vector3D5.X;
			Y = vector3D5.Y;
			Z = vector3D5.Z;
		}
		else
		{
			X = vector3D6.X;
			Y = vector3D6.Y;
			Z = vector3D6.Z;
		}
	}

	protected Vector3D(Vector3D another)
		: base(another)
	{
		Z = another.Z;
	}

	public override double[] ToArray()
	{
		return new double[3] { X, Y, Z };
	}

	public override bool IsValid()
	{
		if (base.IsValid())
		{
			return !double.IsNaN(Z);
		}
		return false;
	}

	public override object Clone()
	{
		return new Vector3D(this);
	}

	public bool PerpendicularTo(Vector3D v)
	{
		int num;
		int num2;
		int num3;
		double num4;
		double num5;
		if (Math.Abs(v.Y) > Math.Abs(v.X))
		{
			if (Math.Abs(v.Z) > Math.Abs(v.Y))
			{
				num = 2;
				num2 = 1;
				num3 = 0;
				num4 = v.Z;
				num5 = 0.0 - v.Y;
			}
			else if (Math.Abs(v.Z) >= Math.Abs(v.X))
			{
				num = 1;
				num2 = 2;
				num3 = 0;
				num4 = v.Y;
				num5 = 0.0 - v.Z;
			}
			else
			{
				num = 1;
				num2 = 0;
				num3 = 2;
				num4 = v.Y;
				num5 = 0.0 - v.X;
			}
		}
		else if (Math.Abs(v.Z) > Math.Abs(v.X))
		{
			num = 2;
			num2 = 0;
			num3 = 1;
			num4 = v.Z;
			num5 = 0.0 - v.X;
		}
		else if (Math.Abs(v.Z) > Math.Abs(v.Y))
		{
			num = 0;
			num2 = 2;
			num3 = 1;
			num4 = v.X;
			num5 = 0.0 - v.Z;
		}
		else
		{
			num = 0;
			num2 = 1;
			num3 = 2;
			num4 = v.X;
			num5 = 0.0 - v.Y;
		}
		double[] array = new double[3];
		array[num] = num5;
		array[num2] = num4;
		array[num3] = 0.0;
		X = array[0];
		Y = array[1];
		Z = array[2];
		return num4 != 0.0;
	}

	public new void Zero()
	{
		X = (Y = (Z = 0.0));
	}

	public static Vector3D operator -(Vector3D v1, Vector3D v2)
	{
		return new Vector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
	}

	public static Vector3D operator +(Vector3D a, Vector3D b)
	{
		return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
	}

	public static Vector3D operator *(double s, Vector3D v)
	{
		return new Vector3D(s * v.X, s * v.Y, s * v.Z);
	}

	public static Vector3D operator *(Vector3D v, double s)
	{
		return new Vector3D(s * v.X, s * v.Y, s * v.Z);
	}

	public static Vector3D operator /(Vector3D v, double s)
	{
		return new Vector3D(v.X / s, v.Y / s, v.Z / s);
	}

	public static bool operator ==(Vector3D left, Vector3D right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Vector3D left, Vector3D right)
	{
		return !object.Equals(left, right);
	}

	public new bool Normalize()
	{
		double num = Math.Sqrt(X * X + Y * Y + Z * Z);
		if (num > 2.2250738585072014E-308)
		{
			X /= num;
			Y /= num;
			Z /= num;
			return true;
		}
		return false;
	}

	public static double Dot(Vector3D u, Vector3D v)
	{
		return u.X * v.X + u.Y * v.Y + u.Z * v.Z;
	}

	public static double operator *(Vector3D u, Vector3D v)
	{
		return u.X * v.X + u.Y * v.Y + u.Z * v.Z;
	}

	public static double Dot(Vector3D v, Point3D p)
	{
		return v.X * p.X + v.Y * p.Y + v.Z * p.Z;
	}

	public static double Dot(Point3D p, Vector3D v)
	{
		return p.X * v.X + p.Y * v.Y + p.Z * v.Z;
	}

	public static Vector3D Subtract(Point3D a, Point3D b)
	{
		return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
	}

	public static Vector3D Add(Point3D a, Point3D b)
	{
		return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
	}

	public static Vector3D Cross(Vector3D a, Vector3D b)
	{
		return new Vector3D(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
	}

	public static Vector3D Cross(Point3D a, Point3D b)
	{
		return new Vector3D(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
	}

	public void WriteAsFloat(BinaryWriter bw)
	{
		bw.Write((float)X);
		bw.Write((float)Y);
		bw.Write((float)Z);
	}

	public static double AngleBetween(Vector3D u, Vector3D v)
	{
		double value = u * v;
		Utility.LimitRange(-1.0, ref value, 1.0);
		return Math.Acos(value);
	}

	public bool Equals(Vector3D other)
	{
		if (Equals((Vector2D)other))
		{
			return Utility.Compare(other.Z, Z) == 0;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Vector3D))
		{
			return false;
		}
		return Equals((Vector3D)obj);
	}

	public override int GetHashCode()
	{
		return (base.GetHashCode() * 397) ^ Z.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663066), X, Y, Z, Length);
	}

	public override string ToStringXml()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302921336), Utility.WriteFloatNumber(X), Utility.WriteFloatNumber(Y), Utility.WriteFloatNumber(Z));
	}

	public override void Negate()
	{
		base.Negate();
		Z = 0.0 - Z;
	}

	public static bool AreCoincident(Vector3D u, Vector3D v)
	{
		return AreCoincident(u, v, Utility._0023_003DzheSR8QM7q9ya);
	}

	public static bool AreCoincident(Vector3D u, Vector3D v, double tol)
	{
		return Math.Abs(1.0 - u * v) < tol;
	}

	public static bool AreOpposite(Vector3D u, Vector3D v)
	{
		return AreOpposite(u, v, Utility._0023_003DzheSR8QM7q9ya);
	}

	public static bool AreOpposite(Vector3D u, Vector3D v, double tol)
	{
		return Math.Abs(u * v + 1.0) < tol;
	}

	public static bool AreParallel(Vector3D u, Vector3D v)
	{
		return AreParallel(u, v, Utility._0023_003DzheSR8QM7q9ya);
	}

	public static bool AreParallel(Vector3D u, Vector3D v, double tol)
	{
		return Math.Abs(Math.Abs(u * v) - 1.0) < tol;
	}

	public static bool AreOrthogonal(Vector3D u, Vector3D v)
	{
		return AreOrthogonal(u, v, Utility._0023_003DzheSR8QM7q9ya);
	}

	public static bool AreOrthogonal(Vector3D u, Vector3D v, double tol)
	{
		return Math.Abs(u * v) < tol;
	}

	public override void TransformBy(Transformation xform)
	{
		double[] array = xform.ActOnLeft(X, Y, Z, 0.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		X = num * array[0];
		Y = num * array[1];
		Z = num * array[2];
	}

	public override Vector2DSurrogate ConvertToSurrogate()
	{
		return new Vector3DSurrogate(this);
	}

	public new virtual Vector3D_V6Surrogate ConvertToSurrogate_V6()
	{
		return new Vector3D_V6Surrogate(this);
	}
}
