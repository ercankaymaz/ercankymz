using System;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class PointUv : PointU
{
	public double V;

	public PointUv(double x, double y, double z, double u, double v)
		: base(x, y, z, u)
	{
		V = v;
	}

	protected PointUv(PointUv another)
		: base(another)
	{
		V = another.V;
	}

	public override object Clone()
	{
		return new PointUv(this);
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659929), X, Y, Z, U, V);
	}

	public override Point2DSurrogate ConvertToSurrogate()
	{
		return new PointUvSurrogate(this);
	}
}
