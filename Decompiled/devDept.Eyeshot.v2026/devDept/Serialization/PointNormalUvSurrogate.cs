using devDept.Geometry;

namespace devDept.Serialization;

public class PointNormalUvSurrogate : PointUvSurrogate
{
	public double Nx;

	public double Ny;

	public double Nz;

	public float PlotValue;

	public byte ColorIndex;

	public int Index;

	public PointNormalUvSurrogate(PointNormalUv pointNormalUv)
		: base(pointNormalUv)
	{
	}

	protected override Point2D ConvertToObject()
	{
		PointNormalUv pointNormalUv = new PointNormalUv(X, Y, Z, U, V);
		CopyDataToObject(pointNormalUv);
		return pointNormalUv;
	}

	protected override void CopyDataToObject(Point2D p)
	{
		PointNormalUv obj = p as PointNormalUv;
		obj.Nx = Nx;
		obj.Ny = Ny;
		obj.Nz = Nz;
		obj.PlotValue = PlotValue;
		obj.ColorIndex = ColorIndex;
		obj.Index = Index;
		base.CopyDataToObject(p);
	}

	protected override void CopyDataFromObject(Point2D p)
	{
		PointNormalUv pointNormalUv = p as PointNormalUv;
		Nx = pointNormalUv.Nx;
		Ny = pointNormalUv.Ny;
		Nz = pointNormalUv.Nz;
		PlotValue = pointNormalUv.PlotValue;
		ColorIndex = pointNormalUv.ColorIndex;
		Index = pointNormalUv.Index;
		base.CopyDataFromObject(p);
	}
}
