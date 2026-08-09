using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class SketchLineSurrogate : SketchCurveSurrogate
{
	public SketchPoint StartPoint;

	public SketchPoint EndPoint;

	public SketchLineSurrogate(SketchLine sketchLine)
		: base(sketchLine)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		SketchLine sketchLine = new SketchLine(null);
		CopyDataToObject(sketchLine);
		return sketchLine;
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		if (sketchItem is SketchLine sketchLine)
		{
			sketchLine.p0 = StartPoint;
			sketchLine.p1 = EndPoint;
		}
		base.CopyDataToObject(sketchItem);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		if (sketchItem is SketchLine sketchLine)
		{
			StartPoint = sketchLine.p0;
			EndPoint = sketchLine.p1;
		}
		base.CopyDataFromObject(sketchItem);
	}
}
