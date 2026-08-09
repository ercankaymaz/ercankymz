using System.Text.Json.Schema;

namespace System.Text.Json.Serialization.Converters;

internal sealed class VersionConverter : JsonPrimitiveConverter<Version>
{
	public override Version Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.Null)
		{
			return null;
		}
		if (reader.TokenType != JsonTokenType.String)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedString(reader.TokenType);
		}
		return ReadCore(ref reader);
	}

	private static Version ReadCore(ref Utf8JsonReader reader)
	{
		string text = reader.GetString();
		if (!string.IsNullOrEmpty(text) && (!char.IsDigit(text[0]) || !char.IsDigit(text[text.Length - 1])))
		{
			ThrowHelper.ThrowFormatException(DataType.Version);
		}
		if (Version.TryParse(text, out var result))
		{
			return result;
		}
		ThrowHelper.ThrowJsonException();
		return null;
	}

	public override void Write(Utf8JsonWriter writer, Version value, JsonSerializerOptions options)
	{
		if ((object)value == null)
		{
			writer.WriteNullValue();
		}
		else
		{
			writer.WriteStringValue(value.ToString());
		}
	}

	internal override Version ReadAsPropertyNameCore(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return ReadCore(ref reader);
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter writer, Version value, JsonSerializerOptions options, bool isWritingExtensionDataProperty)
	{
		if ((object)value == null)
		{
			ThrowHelper.ThrowArgumentNullException("value");
		}
		writer.WritePropertyName(value.ToString());
	}

	internal override JsonSchema GetSchema(JsonNumberHandling _)
	{
		return new JsonSchema
		{
			Type = JsonSchemaType.String,
			Comment = "Represents a version string.",
			Pattern = "^\\d+(\\.\\d+){1,3}$"
		};
	}
}
