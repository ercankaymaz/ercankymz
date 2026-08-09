using devDept.Geometry;

namespace devDept.Serialization;

public class PointNormalSurrogate : Point3DSurrogate
{
	public double Nx;

	public double Ny;

	public double Nz;

	public PointNormalSurrogate(PointNormal pointN)
		: base(pointN)
	{
	}

	protected override Point2D ConvertToObject()
	{
		return new PointNormal(X, Y, Z, Nx, Ny, Nz);
	}

	protected override void CopyDataFromObject(Point2D p)
	{
		PointNormal pointNormal = p as PointNormal;
		Nx = pointNormal.Nx;
		Ny = pointNormal.Ny;
		Nz = pointNormal.Nz;
		base.CopyDataFromObject(p);
	}
}
