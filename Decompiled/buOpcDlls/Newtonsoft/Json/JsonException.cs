using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Newtonsoft.Json;

[Serializable]
[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
public class JsonException : Exception
{
	public JsonException()
	{
	}

	public JsonException(string message)
		: base(message)
	{
	}

	public JsonException(string message, [Newtonsoft_002EJson_002ENullable(2)] Exception innerException)
		: base(message, innerException)
	{
	}

	public JsonException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	internal static JsonException Create(IJsonLineInfo lineInfo, string path, string message)
	{
		message = JsonPosition.FormatMessage(lineInfo, path, message);
		return new JsonException(message);
	}
}
