using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Entities.NurbsSurface;
using devDept.Geometry.ConstraintSolver;
using devDept.Geometry.Converters;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
[TypeConverter(typeof(Point3DConverter))]
public class Point3D : Point2D, IMateable
{
	public double Z;

	[Browsable(false)]
	public new Vector3D AsVector => new Vector3D(X, Y, Z);

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

	public new static Point3D Origin => new Point3D();

	public new static Point3D MinValue => new Point3D(double.MinValue, double.MinValue, double.MinValue);

	public new static Point3D MaxValue => new Point3D(double.MaxValue, double.MaxValue, double.MaxValue);

	public double this[int index] => index switch
	{
		0 => X, 
		1 => Y, 
		_ => Z, 
	};

	public Point3D()
	{
	}

	public Point3D(double x, double y, double z)
		: base(x, y)
	{
		Z = z;
	}

	public Point3D(double x, double y)
		: base(x, y)
	{
		Z = 0.0;
	}

	public Point3D(double[] coords)
		: base(coords)
	{
		Z = coords[2];
	}

	protected Point3D(Point3D another)
		: base(another)
	{
		Z = another.Z;
	}

	public override object Clone()
	{
		return new Point3D(this);
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

	public bool IsInside(Point3D boxMin, Point3D boxMax)
	{
		if (boxMin.X < X && X < boxMax.X && boxMin.Y < Y && Y < boxMax.Y && boxMin.Z < Z && Z < boxMax.Z)
		{
			return true;
		}
		return false;
	}

	public static Point3D MidPoint(Point3D a, Point3D b)
	{
		return new Point3D((a.X + b.X) / 2.0, (a.Y + b.Y) / 2.0, (a.Z + b.Z) / 2.0);
	}

	public double DistanceTo(Point3D b)
	{
		return Distance(this, b);
	}

	public static double Distance(Point3D a, Point3D b)
	{
		return Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y) + (b.Z - a.Z) * (b.Z - a.Z));
	}

	public Point3D ProjectTo(Segment3D seg)
	{
		Vector3D vector3D = Vector3D.Subtract(seg.P1, seg.P0);
		Vector3D vector3D2 = Vector3D.Subtract(this, seg.P0);
		double lengthSquared = vector3D.LengthSquared;
		double num = ((lengthSquared < 2.220446049250313E-16) ? 0.0 : (vector3D * vector3D2 / lengthSquared));
		return seg.P0 + num * vector3D;
	}

	public Point3D ProjectTo(Point3D boxMin, Point3D boxMax)
	{
		double x = Utility.Clamp(in X, in boxMin.X, in boxMax.X);
		double y = Utility.Clamp(in Y, in boxMin.Y, in boxMax.Y);
		double z = Utility.Clamp(in Z, in boxMin.Z, in boxMax.Z);
		return new Point3D(x, y, z);
	}

	public double DistanceTo(Segment3D seg)
	{
		Point3D b = ProjectTo(seg);
		return DistanceTo(b);
	}

	public static double DistanceSquared(Point3D a, Point3D b)
	{
		return (b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y) + (b.Z - a.Z) * (b.Z - a.Z);
	}

	public double DistanceTo(Plane plane)
	{
		return plane.DistanceTo(this);
	}

	public bool Equals(Point3D other)
	{
		if (Equals((Point2D)other))
		{
			return Utility.Compare(other.Z, Z) == 0;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is Point3D))
		{
			return false;
		}
		return Equals((Point3D)obj);
	}

	public override int GetHashCode()
	{
		return (base.GetHashCode() * 397) ^ Z.GetHashCode();
	}

	public static bool operator ==(Point3D left, Point3D right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Point3D left, Point3D right)
	{
		return !object.Equals(left, right);
	}

	public static Point3D operator -(Point3D a, Point3D b)
	{
		return new Point3D
		{
			X = a.X - b.X,
			Y = a.Y - b.Y,
			Z = a.Z - b.Z
		};
	}

	public static Point3D operator *(double s, Point3D p)
	{
		return new Point3D
		{
			X = s * p.X,
			Y = s * p.Y,
			Z = s * p.Z
		};
	}

	public static Point3D operator *(Point3D p, double s)
	{
		return new Point3D
		{
			X = s * p.X,
			Y = s * p.Y,
			Z = s * p.Z
		};
	}

	public static Point3D operator /(Point3D p, double s)
	{
		return new Point3D
		{
			X = p.X / s,
			Y = p.Y / s,
			Z = p.Z / s
		};
	}

	public static Point3D operator +(Point3D a, Vector3D b)
	{
		return new Point3D
		{
			X = a.X + b.X,
			Y = a.Y + b.Y,
			Z = a.Z + b.Z
		};
	}

	public static Point3D operator +(Vector3D v, Point3D p)
	{
		return new Point3D(v.X + p.X, v.Y + p.Y, v.Z + p.Z);
	}

	public static Point3D operator -(Point3D a, Vector3D b)
	{
		return new Point3D
		{
			X = a.X - b.X,
			Y = a.Y - b.Y,
			Z = a.Z - b.Z
		};
	}

	public static Point3D operator -(Vector3D v, Point3D p)
	{
		return new Point3D(v.X - p.X, v.Y - p.Y, v.Z - p.Z);
	}

	public static Point3D operator +(Point3D a, Point3D b)
	{
		return new Point3D
		{
			X = a.X + b.X,
			Y = a.Y + b.Y,
			Z = a.Z + b.Z
		};
	}

	public static bool AreEqual(Point3D p1, Point3D p2, double domainSize)
	{
		return DistanceSquared(p1, p2) < 1E-18 * domainSize * domainSize;
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996518), X, Y, Z);
	}

	public override string ToStringXml()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302921336), Utility.WriteFloatNumber(X), Utility.WriteFloatNumber(Y), Utility.WriteFloatNumber(Z));
	}

	public virtual void WriteAsFloat(BinaryWriter bw)
	{
		bw.Write((float)X);
		bw.Write((float)Y);
		bw.Write((float)Z);
	}

	public override void TransformBy(Transformation xform)
	{
		double[] array = xform.ActOnLeft(X, Y, Z, 1.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		X = num * array[0];
		Y = num * array[1];
		Z = num * array[2];
	}

	ConstraintData IMateable.GetConstraintData(Stack<BlockReference> parents)
	{
		return ConstraintData.GetFromPoint3D(this, parents);
	}

	public override Point2DSurrogate ConvertToSurrogate()
	{
		return new Point3DSurrogate(this);
	}
}
