using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class SketchArcSurrogate : SketchCircleSurrogate
{
	public SketchPoint StartPoint;

	public SketchPoint EndPoint;

	public SketchArcSurrogate(SketchArc sketchArc)
		: base(sketchArc)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		SketchArc sketchArc = new SketchArc(null);
		CopyDataToObject(sketchArc);
		return sketchArc;
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		SketchArc obj = (SketchArc)sketchItem;
		obj._0023_003Dze8HLGHdo_0024aUJ(StartPoint);
		obj._0023_003DzkiChZxXAOBwG(EndPoint);
		base.CopyDataToObject(sketchItem);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		SketchArc sketchArc = (SketchArc)sketchItem;
		StartPoint = sketchArc.StartPoint;
		EndPoint = sketchArc.EndPoint;
		base.CopyDataFromObject(sketchItem);
	}
}
