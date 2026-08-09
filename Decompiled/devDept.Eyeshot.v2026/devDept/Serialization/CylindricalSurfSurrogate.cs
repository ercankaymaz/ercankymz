using devDept.Geometry;

namespace devDept.Serialization;

public class CylindricalSurfSurrogate : PlanarSurfSurrogate
{
	public double Radius;

	public CylindricalSurfSurrogate(CylindricalSurf cylindricalSurf)
		: base(cylindricalSurf)
	{
	}

	protected override AnalyticSurf ConvertToObject()
	{
		CylindricalSurf cylindricalSurf = new CylindricalSurf(Plane, Radius);
		CopyDataToObject(cylindricalSurf);
		return cylindricalSurf;
	}

	protected override void CopyDataFromObject(AnalyticSurf anSurf)
	{
		CylindricalSurf cylindricalSurf = anSurf as CylindricalSurf;
		Radius = cylindricalSurf.Radius;
		base.CopyDataFromObject((AnalyticSurf)cylindricalSurf);
	}
}
