using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class SketchCircleSurrogate : SketchCurveSurrogate
{
	public double Radius;

	public SketchPoint Center;

	public SketchCircleSurrogate(SketchCircle sketchCircle)
		: base(sketchCircle)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		SketchCircle sketchCircle = new SketchCircle(null);
		CopyDataToObject(sketchCircle);
		return sketchCircle;
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		SketchCircle obj = (SketchCircle)sketchItem;
		obj.radius._0023_003DzO_0024HwSzQ_003D(Radius);
		obj.c = Center;
		base.CopyDataToObject(sketchItem);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		SketchCircle sketchCircle = sketchItem as SketchCircle;
		Radius = sketchCircle.Radius;
		Center = sketchCircle.c;
		base.CopyDataFromObject(sketchItem);
	}
}
