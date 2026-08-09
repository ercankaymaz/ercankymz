using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Converters;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
public abstract class CustomCreationConverter<[Newtonsoft_002EJson_002ENullable(2)] T> : JsonConverter
{
	public override bool CanWrite => false;

	public override void WriteJson(JsonWriter writer, [Newtonsoft_002EJson_002ENullable(2)] object value, JsonSerializer serializer)
	{
		throw new NotSupportedException("CustomCreationConverter should only be used while deserializing.");
	}

	[return: Newtonsoft_002EJson_002ENullable(2)]
	public override object ReadJson(JsonReader reader, Type objectType, [Newtonsoft_002EJson_002ENullable(2)] object existingValue, JsonSerializer serializer)
	{
		if (reader.TokenType == JsonToken.Null)
		{
			return null;
		}
		T val = Create(objectType);
		if (val == null)
		{
			throw new JsonSerializationException("No object created.");
		}
		serializer.Populate(reader, val);
		return val;
	}

	public abstract T Create(Type objectType);

	public override bool CanConvert(Type objectType)
	{
		return typeof(T).IsAssignableFrom(objectType);
	}
}
