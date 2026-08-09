using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class TabulatedSurfSurrogate : AnalyticSurfSurrogate
{
	internal GEntity directrix_2022;

	public Entity Directrix;

	public Vector3D Generatrix;

	public TabulatedSurfSurrogate(TabulatedSurf tabSurf)
		: base(tabSurf)
	{
	}

	protected internal Entity GetDirectrix()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Directrix;
		}
		return GEntity.CreateEntityFromPrimitive(directrix_2022);
	}

	protected override AnalyticSurf ConvertToObject()
	{
		TabulatedSurf tabulatedSurf = new TabulatedSurf(this);
		CopyDataToObject(tabulatedSurf);
		return tabulatedSurf;
	}

	protected override void CopyDataFromObject(AnalyticSurf anSurf)
	{
		TabulatedSurf tabulatedSurf = (TabulatedSurf)anSurf;
		Directrix = (Entity)tabulatedSurf.Directrix;
		Generatrix = tabulatedSurf.Generatrix;
		base.CopyDataFromObject((AnalyticSurf)tabulatedSurf);
	}
}
