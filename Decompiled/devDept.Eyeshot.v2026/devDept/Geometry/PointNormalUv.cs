using System;
using devDept.Serialization;

namespace devDept.Geometry;

[Serializable]
public class PointNormalUv : PointUv
{
	public double Nx;

	public double Ny;

	public double Nz;

	public float PlotValue;

	public byte ColorIndex;

	public int Index = -1;

	public Vector3D Normal => new Vector3D(Nx, Ny, Nz);

	public PointNormalUv(double x, double y, double z, double u, double v)
		: base(x, y, z, u, v)
	{
	}

	public PointNormalUv(double x, double y, double z, double nx, double ny, double nz)
		: base(x, y, z, 0.0, 0.0)
	{
		Nx = nx;
		Ny = ny;
		Nz = nz;
	}

	protected PointNormalUv(PointNormalUv another)
		: base(another)
	{
		Nx = another.Nx;
		Ny = another.Ny;
		Nz = another.Nz;
	}

	public override object Clone()
	{
		return new PointNormalUv(this);
	}

	public override void TransformBy(Transformation xform)
	{
		base.TransformBy(xform);
		Transformation matrixForNormals = Utility.GetMatrixForNormals(xform);
		Utility._0023_003Dze5abBKgivGEU(matrixForNormals, matrixForNormals.HasScaling, ref Nx, ref Ny, ref Nz);
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659302), base.ToString(), Nx, Ny, Nz);
	}

	public override Point2DSurrogate ConvertToSurrogate()
	{
		return new PointNormalUvSurrogate(this);
	}
}
