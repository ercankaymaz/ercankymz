using devDept.Geometry;

namespace devDept.Serialization;

public class ToroidalSurfSurrogate : PlanarSurfSurrogate
{
	public double MajorRadius;

	public double MinorRadius;

	public ToroidalSurfSurrogate(ToroidalSurf toroidalSurf)
		: base(toroidalSurf)
	{
	}

	protected override AnalyticSurf ConvertToObject()
	{
		ToroidalSurf toroidalSurf = new ToroidalSurf(Plane, MajorRadius, MinorRadius);
		CopyDataToObject(toroidalSurf);
		return toroidalSurf;
	}

	protected override void CopyDataFromObject(AnalyticSurf anSurf)
	{
		ToroidalSurf toroidalSurf = anSurf as ToroidalSurf;
		MajorRadius = toroidalSurf.MajorRadius;
		MinorRadius = toroidalSurf.MinorRadius;
		base.CopyDataFromObject((AnalyticSurf)toroidalSurf);
	}
}
