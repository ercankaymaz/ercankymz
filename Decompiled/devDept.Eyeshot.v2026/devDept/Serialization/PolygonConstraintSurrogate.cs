using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class PolygonConstraintSurrogate : ConstraintSurrogate
{
	public PolygonConstraintSurrogate(PolygonConstraint polygonConstraint)
		: base(polygonConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		PolygonConstraint polygonConstraint = new PolygonConstraint(null);
		CopyDataToObject(polygonConstraint);
		return polygonConstraint;
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		_ = (PolygonConstraint)sketchItem;
		base.CopyDataFromObject(sketchItem);
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		_ = (PolygonConstraint)sketchItem;
		base.CopyDataToObject(sketchItem);
	}
}
