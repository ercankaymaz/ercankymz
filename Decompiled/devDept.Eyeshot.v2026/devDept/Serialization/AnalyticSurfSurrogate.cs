using devDept.Geometry;

namespace devDept.Serialization;

public abstract class AnalyticSurfSurrogate : Surrogate<AnalyticSurf>
{
	public AnalyticSurfSurrogate(AnalyticSurf analyticSurf)
		: base(analyticSurf)
	{
	}

	protected abstract override AnalyticSurf ConvertToObject();

	protected override void CopyDataToObject(AnalyticSurf analyticSurf)
	{
	}

	protected override void CopyDataFromObject(AnalyticSurf analyticSurf)
	{
	}

	public static implicit operator AnalyticSurf(AnalyticSurfSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator AnalyticSurfSurrogate(AnalyticSurf source)
	{
		return source?.ConvertToSurrogate();
	}
}
