using System;
using devDept.Eyeshot.Entities;

namespace devDept.Geometry;

[Serializable]
public class InterPoint : PointTangent
{
	public double u;

	public double v;

	public double tu;

	public double tv;

	public double s;

	public double t;

	public double ts;

	public double tt;

	internal Arc arc;

	internal double arcParam;

	public bool IsTangent;

	public InterPoint(double x, double y, double z, double u, double v, double s, double t)
		: base(x, y, z, 0.0, 0.0, 0.0)
	{
		this.u = u;
		this.v = v;
		this.s = s;
		this.t = t;
	}

	protected InterPoint(InterPoint another)
		: base(another)
	{
		u = another.u;
		v = another.v;
		s = another.s;
		t = another.t;
		tu = another.tu;
		tv = another.tv;
		ts = another.ts;
		tt = another.tt;
		if (another.arc != null)
		{
			arc = (Arc)another.arc.Clone();
		}
		arcParam = another.arcParam;
	}

	public override object Clone()
	{
		return new InterPoint(this);
	}

	protected bool Equals(InterPoint other)
	{
		if (Equals((PointTangent)other) && Utility.Compare(other.u, u) == 0 && Utility.Compare(other.v, v) == 0 && Utility.Compare(other.s, s) == 0)
		{
			return Utility.Compare(other.t, t) == 0;
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
		return Equals((InterPoint)obj);
	}

	public override int GetHashCode()
	{
		return (((((((base.GetHashCode() * 397) ^ u.GetHashCode()) * 397) ^ v.GetHashCode()) * 397) ^ s.GetHashCode()) * 397) ^ t.GetHashCode();
	}

	public override string ToString()
	{
		if (arc != null)
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302658482), X, Y, Z, u, v, s, t, Tx, Ty, Tz, arcParam, arc.Radius);
		}
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302658118), X, Y, Z, u, v, s, t, Tx, Ty, Tz);
	}
}
