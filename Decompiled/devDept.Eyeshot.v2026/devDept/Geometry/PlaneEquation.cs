using System;
using System.ComponentModel;
using devDept.Geometry.Converters;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
[TypeConverter(typeof(PlaneEquationConverter))]
public class PlaneEquation : Vector3D
{
	public double D;

	public PlaneEquation()
	{
	}

	public PlaneEquation(Point3D P, Vector3D N)
	{
		if (!Create(P, N))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659357));
		}
	}

	public PlaneEquation(double a, double b, double c, double d)
	{
		X = a;
		Y = b;
		Z = c;
		D = d;
		double length = base.Length;
		if (Math.Abs(1.0 - length) > 1E-12)
		{
			Normalize();
			D = d / length;
		}
	}

	protected PlaneEquation(PlaneEquation another)
		: base(another)
	{
		D = another.D;
	}

	public override void Negate()
	{
		base.Negate();
		D = 0.0 - D;
	}

	public bool Create(Point3D P, Vector3D N)
	{
		bool result = false;
		if (P.IsValid() && N.IsValid())
		{
			X = N.X;
			Y = N.Y;
			Z = N.Z;
			result = !(Math.Abs(1.0 - base.Length) > 1E-12) || Normalize();
			D = 0.0 - (X * P.X + Y * P.Y + Z * P.Z);
		}
		return result;
	}

	public override object Clone()
	{
		return new PlaneEquation(this);
	}

	public double ValueAt(Point3D P)
	{
		return X * P.X + Y * P.Y + Z * P.Z + D;
	}

	public double ValueAt(double x, double y, double z)
	{
		return X * x + Y * y + Z * z + D;
	}

	public override bool IsValid()
	{
		if (base.IsValid())
		{
			return !double.IsNaN(D);
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659185), X, Y, Z, D);
	}

	public override double[] ToArray()
	{
		return new double[4] { X, Y, Z, D };
	}

	public override Vector2DSurrogate ConvertToSurrogate()
	{
		return new PlaneEquationSurrogate(this);
	}

	public override Vector3D_V6Surrogate ConvertToSurrogate_V6()
	{
		return new PlaneEquation_V6Surrogate(this);
	}
}
