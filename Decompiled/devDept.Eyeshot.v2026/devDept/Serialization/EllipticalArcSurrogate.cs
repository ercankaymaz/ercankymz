using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class EllipticalArcSurrogate : EllipseSurrogate
{
	public Interval Domain;

	public EllipticalArcSurrogate(EllipticalArc ellipticalArc)
		: base(ellipticalArc)
	{
	}

	protected internal Interval GetDomain()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Domain;
		}
		return ((GEllipticalArc)Primitive).Domain;
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return CreateLinearPathOrGhostEntity(Vertices, typeof(EllipticalArc));
		}
		EllipticalArc ellipticalArc = new EllipticalArc(this);
		CopyDataToObject(ellipticalArc);
		return ellipticalArc;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		if (entity is EllipticalArc ellipticalArc)
		{
			Domain = ellipticalArc.Domain;
		}
		base.CopyDataFromObject(entity);
	}

	protected override bool CheckSurrogateData(string logMessage = null)
	{
		if (base.Content == contentType.Tessellation && (Vertices == null || Vertices.Length == 0))
		{
			WriteLog(logMessage ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302669868));
			return false;
		}
		return true;
	}
}
