using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class SketchEllipticalArcSurrogate : SketchEllipseSurrogate
{
	public SketchPoint StartPoint;

	public SketchPoint EndPoint;

	public SketchEllipticalArcSurrogate(SketchEllipticalArc sketchArc)
		: base(sketchArc)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		SketchEllipticalArc sketchEllipticalArc = new SketchEllipticalArc(null);
		CopyDataToObject(sketchEllipticalArc);
		return sketchEllipticalArc;
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		SketchEllipticalArc obj = (SketchEllipticalArc)sketchItem;
		obj._0023_003Dze8HLGHdo_0024aUJ(StartPoint);
		obj._0023_003DzkiChZxXAOBwG(EndPoint);
		base.CopyDataToObject(sketchItem);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		SketchEllipticalArc sketchEllipticalArc = (SketchEllipticalArc)sketchItem;
		StartPoint = sketchEllipticalArc.StartPoint;
		EndPoint = sketchEllipticalArc.EndPoint;
		base.CopyDataFromObject(sketchItem);
	}
}
