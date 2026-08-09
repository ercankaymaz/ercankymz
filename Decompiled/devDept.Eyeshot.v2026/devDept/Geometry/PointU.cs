using System;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class PointU : Point3D
{
	public double U;

	public PointU(double x, double y, double z, double u)
		: base(x, y, z)
	{
		U = u;
	}

	protected PointU(PointU another)
		: base(another)
	{
		U = another.U;
	}

	public override object Clone()
	{
		return new PointU(this);
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659955), X, Y, Z, U);
	}

	public override Point2DSurrogate ConvertToSurrogate()
	{
		return new PointUSurrogate(this);
	}
}
