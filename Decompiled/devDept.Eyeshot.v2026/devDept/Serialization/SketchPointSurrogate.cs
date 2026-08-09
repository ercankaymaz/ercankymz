using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class SketchPointSurrogate : SketchCurveSurrogate
{
	public Point2D PlanePosition;

	public SketchPointSurrogate(SketchPoint sketchPoint)
		: base(sketchPoint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		SketchPoint sketchPoint = new SketchPoint();
		CopyDataToObject(sketchPoint);
		return sketchPoint;
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		if (sketchItem is SketchPoint sketchPoint)
		{
			sketchPoint._0023_003DzF56xZpo_003D(PlanePosition.X, PlanePosition.Y);
		}
		base.CopyDataToObject(sketchItem);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		PlanePosition = ((SketchPoint)sketchItem).PlanePosition;
		base.CopyDataFromObject(sketchItem);
	}
}
