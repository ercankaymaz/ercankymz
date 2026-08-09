using devDept.Geometry;

namespace devDept.Serialization;

public class ConicalSurfSurrogate : CylindricalSurfSurrogate
{
	public double HalfAngle;

	public ConicalSurfSurrogate(ConicalSurf conicalSurf)
		: base(conicalSurf)
	{
	}

	protected override AnalyticSurf ConvertToObject()
	{
		ConicalSurf conicalSurf = new ConicalSurf(Plane, Radius, HalfAngle);
		CopyDataToObject(conicalSurf);
		return conicalSurf;
	}

	protected override void CopyDataFromObject(AnalyticSurf anSurf)
	{
		ConicalSurf conicalSurf = anSurf as ConicalSurf;
		HalfAngle = conicalSurf.HalfAngle;
		base.CopyDataFromObject((AnalyticSurf)conicalSurf);
	}
}
