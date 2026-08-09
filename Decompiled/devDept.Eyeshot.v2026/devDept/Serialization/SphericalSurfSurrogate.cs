using devDept.Geometry;

namespace devDept.Serialization;

public class SphericalSurfSurrogate : CylindricalSurfSurrogate
{
	public SphericalSurfSurrogate(SphericalSurf sphericalSurf)
		: base(sphericalSurf)
	{
	}

	protected override AnalyticSurf ConvertToObject()
	{
		SphericalSurf sphericalSurf = new SphericalSurf(Plane, Radius);
		CopyDataToObject(sphericalSurf);
		return sphericalSurf;
	}
}
