using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class ArcSurrogate : CircleSurrogate
{
	public Interval Domain;

	public ArcSurrogate(Arc arc)
		: base(arc)
	{
	}

	protected internal Interval GetDomain()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Domain;
		}
		return ((GArc)Primitive).Domain;
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return CreateLinearPathOrGhostEntity(Vertices, typeof(Arc));
		}
		Arc arc = new Arc(this);
		CopyDataToObject(arc);
		return arc;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		if (entity is Arc arc)
		{
			Domain = arc.Domain;
		}
		base.CopyDataFromObject(entity);
	}

	protected override bool CheckSurrogateData(string logMessage = null)
	{
		if (base.Content == contentType.Tessellation && (Vertices == null || Vertices.Length == 0))
		{
			WriteLog(logMessage ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302669811));
			return false;
		}
		return true;
	}
}
