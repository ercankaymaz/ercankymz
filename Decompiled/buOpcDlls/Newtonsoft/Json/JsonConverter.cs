using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
public abstract class JsonConverter
{
	public virtual bool CanRead => true;

	public virtual bool CanWrite => true;

	public abstract void WriteJson(JsonWriter writer, [Newtonsoft_002EJson_002ENullable(2)] object value, JsonSerializer serializer);

	[return: Newtonsoft_002EJson_002ENullable(2)]
	public abstract object ReadJson(JsonReader reader, Type objectType, [Newtonsoft_002EJson_002ENullable(2)] object existingValue, JsonSerializer serializer);

	public abstract bool CanConvert(Type objectType);
}
[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
public abstract class JsonConverter<[Newtonsoft_002EJson_002ENullable(2)] T> : JsonConverter
{
	public sealed override void WriteJson(JsonWriter writer, [Newtonsoft_002EJson_002ENullable(2)] object value, JsonSerializer serializer)
	{
		if (!((value != null) ? (value is T) : ReflectionUtils.IsNullable(typeof(T))))
		{
			throw new JsonSerializationException("Converter cannot write specified value to JSON. {0} is required.".FormatWith(CultureInfo.InvariantCulture, typeof(T)));
		}
		WriteJson(writer, (T)value, serializer);
	}

	public abstract void WriteJson(JsonWriter writer, [Newtonsoft_002EJson_002ENullable(2)] T value, JsonSerializer serializer);

	[return: Newtonsoft_002EJson_002ENullable(2)]
	public sealed override object ReadJson(JsonReader reader, Type objectType, [Newtonsoft_002EJson_002ENullable(2)] object existingValue, JsonSerializer serializer)
	{
		bool flag = existingValue == null;
		if (!flag && !(existingValue is T))
		{
			throw new JsonSerializationException("Converter cannot read JSON with the specified existing value. {0} is required.".FormatWith(CultureInfo.InvariantCulture, typeof(T)));
		}
		return ReadJson(reader, objectType, flag ? default(T) : ((T)existingValue), !flag, serializer);
	}

	[return: Newtonsoft_002EJson_002ENullable(2)]
	public abstract T ReadJson(JsonReader reader, Type objectType, [Newtonsoft_002EJson_002ENullable(2)] T existingValue, bool hasExistingValue, JsonSerializer serializer);

	public sealed override bool CanConvert(Type objectType)
	{
		return typeof(T).IsAssignableFrom(objectType);
	}
}
