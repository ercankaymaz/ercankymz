using System;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class PointTangentU : PointTangent
{
	public double U;

	public float plotValue;

	public PointTangentU(double x, double y, double z, double tx, double ty, double tz, double u)
		: base(x, y, z, tx, ty, tz)
	{
		U = u;
	}

	protected PointTangentU(PointTangentU another)
		: base(another)
	{
		U = another.U;
	}

	public override object Clone()
	{
		return new PointTangentU(this);
	}

	public override Point2DSurrogate ConvertToSurrogate()
	{
		return new PointTangentUSurrogate(this);
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659201), base.ToString(), U);
	}
}
