using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class PointFixedConstraintSurrogate : ConstraintSurrogate
{
	internal double X;

	internal double Y;

	public PointFixedConstraintSurrogate(PointFixedConstraint pointFixedConstraint)
		: base(pointFixedConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		PointFixedConstraint pointFixedConstraint = new PointFixedConstraint(null);
		CopyDataToObject(pointFixedConstraint);
		return pointFixedConstraint;
	}

	protected override void CopyDataToObject(SketchItem sketchItem)
	{
		if (sketchItem is PointFixedConstraint pointFixedConstraint)
		{
			pointFixedConstraint.x = new Exp(X);
			pointFixedConstraint.y = new Exp(Y);
		}
		base.CopyDataToObject(sketchItem);
	}

	protected override void CopyDataFromObject(SketchItem sketchItem)
	{
		PointFixedConstraint pointFixedConstraint = (PointFixedConstraint)sketchItem;
		X = pointFixedConstraint.x.value;
		Y = pointFixedConstraint.y.value;
		base.CopyDataFromObject(sketchItem);
	}
}
