using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Newtonsoft.Json;

[Serializable]
[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
public class JsonReaderException : JsonException
{
	public int LineNumber { get; }

	public int LinePosition { get; }

	[Newtonsoft_002EJson_002ENullable(2)]
	[field: Newtonsoft_002EJson_002ENullable(2)]
	public string Path
	{
		[Newtonsoft_002EJson_002ENullableContext(2)]
		get;
	}

	public JsonReaderException()
	{
	}

	public JsonReaderException(string message)
		: base(message)
	{
	}

	public JsonReaderException(string message, Exception innerException)
		: base(message, innerException)
	{
	}

	public JsonReaderException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public JsonReaderException(string message, string path, int lineNumber, int linePosition, [Newtonsoft_002EJson_002ENullable(2)] Exception innerException)
		: base(message, innerException)
	{
		Path = path;
		LineNumber = lineNumber;
		LinePosition = linePosition;
	}

	internal static JsonReaderException Create(JsonReader reader, string message)
	{
		return Create(reader, message, null);
	}

	internal static JsonReaderException Create(JsonReader reader, string message, [Newtonsoft_002EJson_002ENullable(2)] Exception ex)
	{
		return Create(reader as IJsonLineInfo, reader.Path, message, ex);
	}

	internal static JsonReaderException Create([Newtonsoft_002EJson_002ENullable(2)] IJsonLineInfo lineInfo, string path, string message, [Newtonsoft_002EJson_002ENullable(2)] Exception ex)
	{
		message = JsonPosition.FormatMessage(lineInfo, path, message);
		int lineNumber;
		int linePosition;
		if (lineInfo != null && lineInfo.HasLineInfo())
		{
			lineNumber = lineInfo.LineNumber;
			linePosition = lineInfo.LinePosition;
		}
		else
		{
			lineNumber = 0;
			linePosition = 0;
		}
		return new JsonReaderException(message, path, lineNumber, linePosition, ex);
	}
}
