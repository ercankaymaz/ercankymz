using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class TrimCurveSurrogate : CurveSurrogate
{
	public Entity Edge;

	public TrimCurveSurrogate(TrimCurve trimCurve)
		: base(trimCurve)
	{
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return CreateLinearPathOrGhostEntity(Vertices, typeof(TrimCurve));
		}
		TrimCurve trimCurve = new TrimCurve(this);
		CopyDataToObject(trimCurve);
		return trimCurve;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is TrimCurve trimCurve)
		{
			trimCurve.Edge = Edge as ICurve;
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		TrimCurve trimCurve = (TrimCurve)entity;
		Edge = trimCurve.Edge as Entity;
		base.CopyDataFromObject(entity);
	}

	protected override bool CheckSurrogateData(string logMessage = null)
	{
		if (base.Content == contentType.Tessellation && (Vertices == null || Vertices.Length == 0))
		{
			WriteLog(logMessage ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673213));
			return false;
		}
		return true;
	}
}
