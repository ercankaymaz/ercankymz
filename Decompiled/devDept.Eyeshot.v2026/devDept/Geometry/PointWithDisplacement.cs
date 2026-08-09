using System;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class PointWithDisplacement : Point3D
{
	public double[][] Unknowns { get; set; }

	protected PointWithDisplacement(PointWithDisplacement another)
		: base(another)
	{
		Unknowns = new double[1][] { new double[3] };
	}

	public PointWithDisplacement(double x, double y, double z)
		: base(x, y, z)
	{
		Unknowns = new double[1][] { new double[3] { x, y, z } };
	}

	public float DisplacementX(double ampFactor, int mode = 0)
	{
		return (float)(X + Unknowns[mode][0] * ampFactor);
	}

	public float DisplacementY(double ampFactor, int mode = 0)
	{
		return (float)(Y + Unknowns[mode][1] * ampFactor);
	}

	public float DisplacementZ(double ampFactor, int mode = 0)
	{
		return (float)(Z + Unknowns[mode][2] * ampFactor);
	}

	public override Point2DSurrogate ConvertToSurrogate()
	{
		return new PointWithDisplacementSurrogate(this);
	}
}
