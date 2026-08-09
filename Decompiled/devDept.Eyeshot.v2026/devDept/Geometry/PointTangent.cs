using System;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class PointTangent : Point3D
{
	public double Tx;

	public double Ty;

	public double Tz;

	public Vector3D Tangent
	{
		get
		{
			return new Vector3D(Tx, Ty, Tz);
		}
		set
		{
			Tx = value.X;
			Ty = value.Y;
			Tz = value.Z;
		}
	}

	public PointTangent(double x, double y, double z = 0.0)
		: base(x, y, z)
	{
		Tx = (Ty = (Tz = 0.0));
	}

	public PointTangent(double x, double y, double z, double tx, double ty, double tz)
		: base(x, y, z)
	{
		Tx = tx;
		Ty = ty;
		Tz = tz;
	}

	public PointTangent(double x, double y, double tx, double ty)
		: base(x, y, 0.0)
	{
		Tx = tx;
		Ty = ty;
	}

	protected PointTangent(PointTangent another)
		: base(another)
	{
		Tx = another.Tx;
		Ty = another.Ty;
		Tz = another.Tz;
	}

	public override object Clone()
	{
		return new PointTangent(this);
	}

	public override void TransformBy(Transformation xform)
	{
		base.TransformBy(xform);
		double[] array = xform.ActOnLeft(Tx, Ty, Tz, 0.0);
		double num = ((array[3] != 0.0) ? (1.0 / array[3]) : 1.0);
		Tx = num * array[0];
		Ty = num * array[1];
		Tz = num * array[2];
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659235), base.ToString(), Tx, Ty, Tz);
	}

	protected bool Equals(PointTangent other)
	{
		if (Equals((Point3D)other) && Utility.Compare(other.Tx, Tx) == 0 && Utility.Compare(other.Ty, Ty) == 0)
		{
			return Utility.Compare(other.Tz, Tz) == 0;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((PointTangent)obj);
	}

	public override int GetHashCode()
	{
		return (((((base.GetHashCode() * 397) ^ Tx.GetHashCode()) * 397) ^ Ty.GetHashCode()) * 397) ^ Tz.GetHashCode();
	}

	public override Point2DSurrogate ConvertToSurrogate()
	{
		return new PointTangentSurrogate(this);
	}
}
