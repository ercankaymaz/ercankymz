using System.Diagnostics.CodeAnalysis;

namespace System.Text.Json.Nodes;

internal sealed class JsonValueOfElement : JsonValue<JsonElement>
{
	internal override JsonElement? UnderlyingElement => Value;

	public JsonValueOfElement(JsonElement value, JsonNodeOptions? options)
		: base(value, options)
	{
	}

	internal override JsonNode DeepCloneCore()
	{
		return new JsonValueOfElement(Value.Clone(), base.Options);
	}

	private protected override JsonValueKind GetValueKindCore()
	{
		return Value.ValueKind;
	}

	internal override bool DeepEqualsCore(JsonNode otherNode)
	{
		JsonElement? underlyingElement = otherNode.UnderlyingElement;
		if (underlyingElement.HasValue)
		{
			JsonElement valueOrDefault = underlyingElement.GetValueOrDefault();
			return JsonElement.DeepEquals(Value, valueOrDefault);
		}
		if (otherNode is JsonValue)
		{
			return otherNode.DeepEqualsCore(this);
		}
		return base.DeepEqualsCore(otherNode);
	}

	public override TypeToConvert GetValue<TypeToConvert>()
	{
		if (!TryGetValue<TypeToConvert>(out var value))
		{
			ThrowHelper.ThrowInvalidOperationException_NodeUnableToConvertElement(Value.ValueKind, typeof(TypeToConvert));
		}
		return value;
	}

	public override bool TryGetValue<TypeToConvert>([System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out TypeToConvert value)
	{
		JsonElement value2 = Value;
		if (value2 is TypeToConvert)
		{
			TypeToConvert val = (TypeToConvert)((((object)value2) is TypeToConvert) ? ((object)value2) : null);
			value = val;
			return true;
		}
		switch (Value.ValueKind)
		{
		case JsonValueKind.Number:
			if (typeof(TypeToConvert) == typeof(int) || typeof(TypeToConvert) == typeof(int?))
			{
				int value3;
				bool result = Value.TryGetInt32(out value3);
				value = (TypeToConvert)(object)value3;
				return result;
			}
			if (typeof(TypeToConvert) == typeof(long) || typeof(TypeToConvert) == typeof(long?))
			{
				long value4;
				bool result2 = Value.TryGetInt64(out value4);
				value = (TypeToConvert)(object)value4;
				return result2;
			}
			if (typeof(TypeToConvert) == typeof(double) || typeof(TypeToConvert) == typeof(double?))
			{
				double value5;
				bool result3 = Value.TryGetDouble(out value5);
				value = (TypeToConvert)(object)value5;
				return result3;
			}
			if (typeof(TypeToConvert) == typeof(short) || typeof(TypeToConvert) == typeof(short?))
			{
				short value6;
				bool result4 = Value.TryGetInt16(out value6);
				value = (TypeToConvert)(object)value6;
				return result4;
			}
			if (typeof(TypeToConvert) == typeof(decimal) || typeof(TypeToConvert) == typeof(decimal?))
			{
				decimal value7;
				bool result5 = Value.TryGetDecimal(out value7);
				value = (TypeToConvert)(object)value7;
				return result5;
			}
			if (typeof(TypeToConvert) == typeof(byte) || typeof(TypeToConvert) == typeof(byte?))
			{
				byte value8;
				bool result6 = Value.TryGetByte(out value8);
				value = (TypeToConvert)(object)value8;
				return result6;
			}
			if (typeof(TypeToConvert) == typeof(float) || typeof(TypeToConvert) == typeof(float?))
			{
				float value9;
				bool result7 = Value.TryGetSingle(out value9);
				value = (TypeToConvert)(object)value9;
				return result7;
			}
			if (typeof(TypeToConvert) == typeof(uint) || typeof(TypeToConvert) == typeof(uint?))
			{
				uint value10;
				bool result8 = Value.TryGetUInt32(out value10);
				value = (TypeToConvert)(object)value10;
				return result8;
			}
			if (typeof(TypeToConvert) == typeof(ushort) || typeof(TypeToConvert) == typeof(ushort?))
			{
				ushort value11;
				bool result9 = Value.TryGetUInt16(out value11);
				value = (TypeToConvert)(object)value11;
				return result9;
			}
			if (typeof(TypeToConvert) == typeof(ulong) || typeof(TypeToConvert) == typeof(ulong?))
			{
				ulong value12;
				bool result10 = Value.TryGetUInt64(out value12);
				value = (TypeToConvert)(object)value12;
				return result10;
			}
			if (typeof(TypeToConvert) == typeof(sbyte) || typeof(TypeToConvert) == typeof(sbyte?))
			{
				sbyte value13;
				bool result11 = Value.TryGetSByte(out value13);
				value = (TypeToConvert)(object)value13;
				return result11;
			}
			break;
		case JsonValueKind.String:
			if (typeof(TypeToConvert) == typeof(string))
			{
				string text = Value.GetString();
				value = (TypeToConvert)(object)text;
				return true;
			}
			if (typeof(TypeToConvert) == typeof(DateTime) || typeof(TypeToConvert) == typeof(DateTime?))
			{
				DateTime value14;
				bool result12 = Value.TryGetDateTime(out value14);
				value = (TypeToConvert)(object)value14;
				return result12;
			}
			if (typeof(TypeToConvert) == typeof(DateTimeOffset) || typeof(TypeToConvert) == typeof(DateTimeOffset?))
			{
				DateTimeOffset value15;
				bool result13 = Value.TryGetDateTimeOffset(out value15);
				value = (TypeToConvert)(object)value15;
				return result13;
			}
			if (typeof(TypeToConvert) == typeof(Guid) || typeof(TypeToConvert) == typeof(Guid?))
			{
				Guid value16;
				bool result14 = Value.TryGetGuid(out value16);
				value = (TypeToConvert)(object)value16;
				return result14;
			}
			if (typeof(TypeToConvert) == typeof(char) || typeof(TypeToConvert) == typeof(char?))
			{
				string text2 = Value.GetString();
				if (text2.Length == 1)
				{
					value = (TypeToConvert)(object)text2[0];
					return true;
				}
			}
			break;
		case JsonValueKind.True:
		case JsonValueKind.False:
			if (typeof(TypeToConvert) == typeof(bool) || typeof(TypeToConvert) == typeof(bool?))
			{
				value = (TypeToConvert)(object)Value.GetBoolean();
				return true;
			}
			break;
		}
		value = default(TypeToConvert);
		return false;
	}

	public override void WriteTo(Utf8JsonWriter writer, JsonSerializerOptions options = null)
	{
		if (writer == null)
		{
			ThrowHelper.ThrowArgumentNullException("writer");
		}
		Value.WriteTo(writer);
	}
}
