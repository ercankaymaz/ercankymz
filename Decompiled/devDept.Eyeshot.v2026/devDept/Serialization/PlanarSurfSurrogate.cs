using devDept.Geometry;

namespace devDept.Serialization;

public class PlanarSurfSurrogate : AnalyticSurfSurrogate
{
	public Plane Plane;

	public PlanarSurfSurrogate(PlanarSurf planarSurf)
		: base(planarSurf)
	{
	}

	protected override AnalyticSurf ConvertToObject()
	{
		PlanarSurf planarSurf = new PlanarSurf(Plane);
		CopyDataToObject(planarSurf);
		return planarSurf;
	}

	protected override void CopyDataFromObject(AnalyticSurf anSurf)
	{
		PlanarSurf planarSurf = anSurf as PlanarSurf;
		Plane = planarSurf.Plane;
		base.CopyDataFromObject((AnalyticSurf)planarSurf);
	}
}
