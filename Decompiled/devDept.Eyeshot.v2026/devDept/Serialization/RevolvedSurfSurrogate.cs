using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class RevolvedSurfSurrogate : PlanarSurfSurrogate
{
	internal GEntity generatrix_2022;

	public Entity Generatrix;

	public RevolvedSurfSurrogate(RevolvedSurf revolvedSurf)
		: base(revolvedSurf)
	{
	}

	protected internal Entity GetGeneratrix()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Generatrix;
		}
		return GEntity.CreateEntityFromPrimitive(generatrix_2022);
	}

	protected override AnalyticSurf ConvertToObject()
	{
		RevolvedSurf revolvedSurf = new RevolvedSurf(this);
		CopyDataToObject(revolvedSurf);
		return revolvedSurf;
	}

	protected override void CopyDataFromObject(AnalyticSurf anSurf)
	{
		RevolvedSurf revolvedSurf = (RevolvedSurf)anSurf;
		Generatrix = (Entity)revolvedSurf.Generatrix;
		base.CopyDataFromObject((AnalyticSurf)revolvedSurf);
	}
}
