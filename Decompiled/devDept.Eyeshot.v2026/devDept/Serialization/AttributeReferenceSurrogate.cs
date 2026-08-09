using System;
using ProtoBuf;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class AttributeReferenceSurrogate : Surrogate<AttributeReference>
{
	internal AttributeReferenceData Data;

	protected contentType DeserializationContent;

	public AttributeReferenceSurrogate(AttributeReference ar)
		: base(ar)
	{
	}

	protected override AttributeReference ConvertToObject()
	{
		return new AttributeReference(Data);
	}

	protected override void CopyDataToObject(AttributeReference obj)
	{
	}

	protected override void CopyDataFromObject(AttributeReference ar)
	{
		Data = ar.Data;
	}

	public static implicit operator AttributeReference(AttributeReferenceSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator AttributeReferenceSurrogate(AttributeReference source)
	{
		if (source == null)
		{
			return null;
		}
		AttributeReferenceSurrogate attributeReferenceSurrogate = source.ConvertToSurrogate();
		if (attributeReferenceSurrogate == null)
		{
			Type type = source.GetType();
			throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302669783), type, type));
		}
		return attributeReferenceSurrogate;
	}

	[CLSCompliant(false)]
	protected override void BeforeDeserialize(SerializationContext serializationContext)
	{
		base.BeforeDeserialize(serializationContext);
		if (!(serializationContext.Context is FileSerializer fileSerializer))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302669432));
		}
		DeserializationContent = fileSerializer.Content;
	}
}
