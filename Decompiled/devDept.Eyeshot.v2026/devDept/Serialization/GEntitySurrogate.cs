using System;
using ProtoBuf;

namespace devDept.Serialization;

internal class GEntitySurrogate : SurrogateWithReferenceId<GEntity>
{
	public ProtoObject EntityData;

	public string Type;

	public GEntitySurrogate(GEntity gEntity)
		: base(gEntity)
	{
	}

	private GEntitySurrogate(int referenceId)
		: base(referenceId)
	{
	}

	protected override GEntity ConvertToObject()
	{
		WriteLog(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671664) + Type + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290));
		return null;
	}

	protected override void CopyDataToObject(GEntity gEntity)
	{
		if (EntityData != null)
		{
			gEntity.EntityData = EntityData.Object;
		}
	}

	protected override void CopyDataFromObject(GEntity gEntity)
	{
		Type = gEntity.GetType().FullName;
		if (gEntity.EntityData != null)
		{
			EntityData = new ProtoObject(gEntity.EntityData);
		}
	}

	public static implicit operator GEntity(GEntitySurrogate surrogate)
	{
		GEntity gEntity = Serializer.GetCachedObject(surrogate) as GEntity;
		if (gEntity != null)
		{
			return gEntity;
		}
		if (surrogate != null)
		{
			gEntity = surrogate.ConvertToObject();
			Serializer.AddToCache(surrogate, gEntity);
			if (gEntity == null)
			{
				if (string.IsNullOrEmpty(surrogate.Log))
				{
					surrogate.WriteLog(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998666) + surrogate.GetType().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290));
				}
				return null;
			}
		}
		return gEntity;
	}

	public static implicit operator GEntitySurrogate(GEntity source)
	{
		if (source == null)
		{
			return null;
		}
		GEntitySurrogate gEntitySurrogate2;
		if (Serializer.GetCachedObjectWithReferenceId(source) is GEntitySurrogate gEntitySurrogate)
		{
			gEntitySurrogate2 = new GEntitySurrogate(gEntitySurrogate.ReferenceId);
		}
		else
		{
			gEntitySurrogate2 = source.ConvertToSurrogate();
			Serializer.AddToCache(source, gEntitySurrogate2);
		}
		if (gEntitySurrogate2 == null)
		{
			Type type = source.GetType();
			throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671863), type, type));
		}
		return gEntitySurrogate2;
	}

	[CLSCompliant(false)]
	protected override void BeforeDeserialize(SerializationContext serializationContext)
	{
		base.BeforeDeserialize(serializationContext);
		if (!(serializationContext.Context is Serializer))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670603));
		}
	}

	[CLSCompliant(false)]
	protected override void BeforeSerialize(SerializationContext serializationContext)
	{
		base.BeforeSerialize(serializationContext);
		((serializationContext.Context as Serializer) ?? throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670603))).WriteLog(base.Log);
	}
}
