using System.Text.Json.Nodes;
using System.Text.Json.Schema;

namespace System.Text.Json.Serialization.Converters;

internal sealed class JsonArrayConverter : JsonConverter<JsonArray>
{
	public override void Write(Utf8JsonWriter writer, JsonArray value, JsonSerializerOptions options)
	{
		if (value == null)
		{
			writer.WriteNullValue();
		}
		else
		{
			value.WriteTo(writer, options);
		}
	}

	public override JsonArray Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return reader.TokenType switch
		{
			JsonTokenType.StartArray => ReadList(ref reader, options.GetNodeOptions()), 
			JsonTokenType.Null => null, 
			_ => throw ThrowHelper.GetInvalidOperationException_ExpectedArray(reader.TokenType), 
		};
	}

	public static JsonArray ReadList(ref Utf8JsonReader reader, JsonNodeOptions? options = null)
	{
		return new JsonArray(JsonElement.ParseValue(ref reader), options);
	}

	internal override JsonSchema GetSchema(JsonNumberHandling _)
	{
		return new JsonSchema
		{
			Type = JsonSchemaType.Array
		};
	}
}
