using ProtoBuf;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class CurveSurrogate : NurbsBaseSurrogate
{
	internal GCurve Primitive;

	public Point4D[] Pw;

	public CurveSurrogate(Curve curve)
		: base(curve)
	{
	}

	protected internal override int GetP()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return p;
		}
		return Primitive.P;
	}

	protected internal override double[] GetU()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return U;
		}
		return Primitive.U;
	}

	protected internal Point4D[] GetPw()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Pw;
		}
		return Primitive.Pw;
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return CreateLinearPathOrGhostEntity(Vertices, typeof(Curve));
		}
		Curve curve = new Curve(this);
		CopyDataToObject(curve);
		return curve;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Curve curve = (Curve)entity;
		Pw = curve.Pw;
		base.CopyDataFromObject(entity);
	}

	protected override bool CheckSurrogateData(string logMessage = null)
	{
		if (base.Content == contentType.Tessellation && (Vertices == null || Vertices.Length == 0))
		{
			WriteLog(logMessage ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302669950));
			return false;
		}
		return true;
	}

	protected override void AfterDeserialize(SerializationContext serializationContext)
	{
		base.AfterDeserialize(serializationContext);
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version) && Primitive?.EntityData != null)
		{
			EntityData = new ProtoObject(Primitive.EntityData);
		}
	}
}
