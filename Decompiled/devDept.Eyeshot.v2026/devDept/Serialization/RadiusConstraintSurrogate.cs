using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class RadiusConstraintSurrogate : ValueConstraintSurrogate
{
	public RadiusConstraintSurrogate(RadiusConstraint radiusConstraint)
		: base(radiusConstraint)
	{
	}

	protected override SketchItem ConvertToObject()
	{
		RadiusConstraint radiusConstraint = new RadiusConstraint(null);
		CopyDataToObject(radiusConstraint);
		return radiusConstraint;
	}
}
