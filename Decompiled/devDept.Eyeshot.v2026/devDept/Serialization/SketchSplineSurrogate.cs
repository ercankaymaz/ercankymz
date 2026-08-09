using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class SketchSplineSurrogate : SketchCurveSurrogate
{
	public SketchPoint[] ControlPoints;

	public SketchSplineSurrogate(SketchSpline sketchSpline)
		: base(sketchSpline)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		SketchSpline sketchSpline = new SketchSpline(null);
		CopyDataToObject(sketchSpline);
		return sketchSpline;
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		((SketchSpline)sketchItem).ControlPoints = ControlPoints;
		base.CopyDataToObject(sketchItem);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		SketchSpline sketchSpline = (SketchSpline)sketchItem;
		ControlPoints = sketchSpline.ControlPoints;
		base.CopyDataFromObject(sketchItem);
	}
}
