using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Nodes;
using System.Text.Json.Schema;

namespace System.Text.Json.Serialization.Converters;

internal abstract class JsonPrimitiveConverter<T> : JsonConverter<T>
{
	public sealed override void WriteAsPropertyName(Utf8JsonWriter writer, [System.Diagnostics.CodeAnalysis.DisallowNull] T value, JsonSerializerOptions options)
	{
		if (value == null)
		{
			ThrowHelper.ThrowArgumentNullException("value");
		}
		WriteAsPropertyNameCore(writer, value, options, isWritingExtensionDataProperty: false);
	}

	public sealed override T ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType != JsonTokenType.PropertyName)
		{
			ThrowHelper.ThrowInvalidOperationException_ExpectedPropertyName(reader.TokenType);
		}
		return ReadAsPropertyNameCore(ref reader, typeToConvert, options);
	}

	private protected static JsonSchema GetSchemaForNumericType(JsonSchemaType schemaType, JsonNumberHandling numberHandling, bool isIeeeFloatingPoint = false)
	{
		string pattern = null;
		if ((numberHandling & (JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)) != JsonNumberHandling.Strict)
		{
			pattern = ((schemaType == JsonSchemaType.Integer) ? "^-?(?:0|[1-9]\\d*)$" : (isIeeeFloatingPoint ? "^-?(?:0|[1-9]\\d*)(?:\\.\\d+)?(?:[eE][+-]?\\d+)?$" : "^-?(?:0|[1-9]\\d*)(?:\\.\\d+)?$"));
			schemaType |= JsonSchemaType.String;
		}
		if (isIeeeFloatingPoint && (numberHandling & JsonNumberHandling.AllowNamedFloatingPointLiterals) != JsonNumberHandling.Strict)
		{
			return new JsonSchema
			{
				AnyOf = new List<JsonSchema>(2)
				{
					new JsonSchema
					{
						Type = schemaType,
						Pattern = pattern
					},
					new JsonSchema
					{
						Enum = new JsonArray
						{
							(JsonNode?)"NaN",
							(JsonNode?)"Infinity",
							(JsonNode?)"-Infinity"
						}
					}
				}
			};
		}
		return new JsonSchema
		{
			Type = schemaType,
			Pattern = pattern
		};
	}
}
