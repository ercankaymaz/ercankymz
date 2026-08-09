using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class DiameterConstraintSurrogate : RadiusConstraintSurrogate
{
	public DiameterConstraintSurrogate(DiameterConstraint diameterConstraint)
		: base(diameterConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		DiameterConstraint diameterConstraint = new DiameterConstraint(null);
		CopyDataToObject(diameterConstraint);
		return diameterConstraint;
	}
}
