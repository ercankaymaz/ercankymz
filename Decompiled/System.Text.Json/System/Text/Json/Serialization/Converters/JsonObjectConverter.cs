using System.Text.Json.Nodes;
using System.Text.Json.Schema;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal sealed class JsonObjectConverter : JsonConverter<JsonObject>
{
	internal override void ConfigureJsonTypeInfo(JsonTypeInfo jsonTypeInfo, JsonSerializerOptions options)
	{
		jsonTypeInfo.CreateObjectForExtensionDataProperty = () => new JsonObject(options.GetNodeOptions());
	}

	internal override void ReadElementAndSetProperty(object obj, string propertyName, ref Utf8JsonReader reader, JsonSerializerOptions options, scoped ref ReadStack state)
	{
		JsonNodeConverter.Instance.TryRead(ref reader, typeof(JsonNode), options, ref state, out var value, out var _);
		JsonObject obj2 = (JsonObject)obj;
		JsonNode value2 = value;
		obj2[propertyName] = value2;
	}

	public override void Write(Utf8JsonWriter writer, JsonObject value, JsonSerializerOptions options)
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

	public override JsonObject Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return reader.TokenType switch
		{
			JsonTokenType.StartObject => ReadObject(ref reader, options.GetNodeOptions()), 
			JsonTokenType.Null => null, 
			_ => throw ThrowHelper.GetInvalidOperationException_ExpectedObject(reader.TokenType), 
		};
	}

	public static JsonObject ReadObject(ref Utf8JsonReader reader, JsonNodeOptions? options)
	{
		return new JsonObject(JsonElement.ParseValue(ref reader), options);
	}

	internal override JsonSchema GetSchema(JsonNumberHandling _)
	{
		return new JsonSchema
		{
			Type = JsonSchemaType.Object
		};
	}
}
