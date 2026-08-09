using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class SketchEllipseSurrogate : SketchCurveSurrogate
{
	public SketchPoint Center;

	public double RadiusX;

	public double RadiusY;

	internal double px;

	internal double py;

	internal double ux;

	internal double uy;

	internal double vx;

	internal double vy;

	public SketchEllipseSurrogate(SketchEllipse sketchEllipse)
		: base(sketchEllipse)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		SketchEllipse sketchEllipse = new SketchEllipse(null);
		CopyDataToObject(sketchEllipse);
		return sketchEllipse;
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		SketchEllipse sketchEllipse = (SketchEllipse)sketchItem;
		sketchEllipse.c = Center;
		sketchEllipse.RadiusX = RadiusX;
		sketchEllipse.RadiusY = RadiusY;
		sketchEllipse.basis._0023_003DzJ1SNHdOrtq1L(new double[4] { ux, uy, vx, vy });
		sketchEllipse.basis._0023_003DzOjiryAH4CnPe(px, py);
		base.CopyDataToObject(sketchItem);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		SketchEllipse sketchEllipse = (SketchEllipse)sketchItem;
		Center = sketchEllipse.c;
		RadiusX = sketchEllipse.RadiusX;
		RadiusY = sketchEllipse.RadiusY;
		px = sketchEllipse.basis.px._0023_003DzV29zQ3g_003D();
		py = sketchEllipse.basis.py._0023_003DzV29zQ3g_003D();
		ux = sketchEllipse.basis.ux._0023_003DzV29zQ3g_003D();
		uy = sketchEllipse.basis.uy._0023_003DzV29zQ3g_003D();
		vx = sketchEllipse.basis.vx._0023_003DzV29zQ3g_003D();
		vy = sketchEllipse.basis.vy._0023_003DzV29zQ3g_003D();
		base.CopyDataFromObject(sketchItem);
	}
}
