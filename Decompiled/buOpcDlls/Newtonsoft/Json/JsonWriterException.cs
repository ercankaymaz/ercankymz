using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Newtonsoft.Json;

[Serializable]
[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
public class JsonWriterException : JsonException
{
	[Newtonsoft_002EJson_002ENullable(2)]
	[field: Newtonsoft_002EJson_002ENullable(2)]
	public string Path
	{
		[Newtonsoft_002EJson_002ENullableContext(2)]
		get;
	}

	public JsonWriterException()
	{
	}

	public JsonWriterException(string message)
		: base(message)
	{
	}

	public JsonWriterException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public JsonWriterException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public JsonWriterException(string message, string path, [Newtonsoft_002EJson_002ENullable(2)] Exception innerException)
		: base(message, innerException)
	{
		Path = path;
	}

	internal static JsonWriterException Create(JsonWriter writer, string message, [Newtonsoft_002EJson_002ENullable(2)] Exception ex)
	{
		return Create(writer.ContainerPath, message, ex);
	}

	internal static JsonWriterException Create(string path, string message, [Newtonsoft_002EJson_002ENullable(2)] Exception ex)
	{
		message = JsonPosition.FormatMessage(null, path, message);
		return new JsonWriterException(message, path, ex);
	}
}
