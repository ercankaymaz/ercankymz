using System.Text.Json.Nodes;
using System.Text.Json.Schema;

namespace System.Text.Json.Serialization.Converters;

internal sealed class JsonValueConverter : JsonConverter<JsonValue>
{
	public override void Write(Utf8JsonWriter writer, JsonValue value, JsonSerializerOptions options)
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

	public override JsonValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.Null)
		{
			return null;
		}
		JsonElement element = JsonElement.ParseValue(ref reader);
		return JsonValue.CreateFromElement(in element, options.GetNodeOptions());
	}

	internal override JsonSchema GetSchema(JsonNumberHandling _)
	{
		return JsonSchema.CreateTrueSchema();
	}
}
