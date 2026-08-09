using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Nodes;
using SharpGLTF.Collections;
using SharpGLTF.Validation;

namespace SharpGLTF.IO;

public abstract class JsonSerializable
{
	internal string _SchemaName => GetSchemaName();

	internal void ValidateReferences(ValidationContext validate)
	{
		validate = validate.GetContext(this);
		OnValidateReferences(validate);
	}

	internal void ValidateContent(ValidationContext validate)
	{
		validate = validate.GetContext(this);
		OnValidateContent(validate);
	}

	protected virtual void OnValidateReferences(ValidationContext validate)
	{
	}

	protected virtual void OnValidateContent(ValidationContext validate)
	{
	}

	protected virtual string GetSchemaName()
	{
		return "JsonSerializable";
	}

	internal void Serialize(Utf8JsonWriter writer)
	{
		Guard.NotNull(writer, "writer");
		writer.WriteStartObject();
		SerializeProperties(writer);
		writer.WriteEndObject();
	}

	protected abstract void SerializeProperties(Utf8JsonWriter writer);

	protected static void SerializeProperty(Utf8JsonWriter writer, string name, object value)
	{
		if (value != null)
		{
			Guard.NotNull(writer, "writer");
			_SerializeProperty(writer, name, value);
		}
	}

	protected static void SerializeProperty(Utf8JsonWriter writer, string name, bool? value, bool? defval = null)
	{
		if (value.HasValue && (!defval.HasValue || !defval.Value.Equals(value.Value)))
		{
			Guard.NotNull(writer, "writer");
			writer.WriteBoolean(name, value.Value);
		}
	}

	protected static void SerializeProperty(Utf8JsonWriter writer, string name, int? value, int? defval = null)
	{
		if (value.HasValue && (!defval.HasValue || !defval.Value.Equals(value.Value)))
		{
			Guard.NotNull(writer, "writer");
			writer.WriteNumber(name, value.Value);
		}
	}

	protected static void SerializeProperty(Utf8JsonWriter writer, string name, float? value, float? defval = null)
	{
		if (value.HasValue && (!defval.HasValue || !defval.Value.Equals(value.Value)))
		{
			Guard.NotNull(writer, "writer");
			writer.WriteNumber(name, value.Value);
		}
	}

	protected static void SerializeProperty(Utf8JsonWriter writer, string name, double? value, double? defval = null)
	{
		if (value.HasValue && (!defval.HasValue || !defval.Value.Equals(value.Value)))
		{
			Guard.NotNull(writer, "writer");
			writer.WriteNumber(name, value.Value);
		}
	}

	protected static void SerializeProperty(Utf8JsonWriter writer, string name, Vector2? value, Vector2? defval = null)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (!value.HasValue)
		{
			return;
		}
		if (defval.HasValue)
		{
			Vector2 value2 = defval.Value;
			if (((Vector2)(ref value2)).Equals(value.Value))
			{
				return;
			}
		}
		Guard.NotNull(writer, "writer");
		writer.WritePropertyName(name);
		writer.WriteVector2(value.Value);
	}

	protected static void SerializeProperty(Utf8JsonWriter writer, string name, Vector3? value, Vector3? defval = null)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (!value.HasValue)
		{
			return;
		}
		if (defval.HasValue)
		{
			Vector3 value2 = defval.Value;
			if (((Vector3)(ref value2)).Equals(value.Value))
			{
				return;
			}
		}
		Guard.NotNull(writer, "writer");
		writer.WritePropertyName(name);
		writer.WriteVector3(value.Value);
	}

	protected static void SerializeProperty(Utf8JsonWriter writer, string name, Vector4? value, Vector4? defval = null)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (!value.HasValue)
		{
			return;
		}
		if (defval.HasValue)
		{
			Vector4 value2 = defval.Value;
			if (((Vector4)(ref value2)).Equals(value.Value))
			{
				return;
			}
		}
		Guard.NotNull(writer, "writer");
		writer.WritePropertyName(name);
		writer.WriteVector4(value.Value);
	}

	protected static void SerializeProperty(Utf8JsonWriter writer, string name, Quaternion? value, Quaternion? defval = null)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (!value.HasValue)
		{
			return;
		}
		if (defval.HasValue)
		{
			Quaternion value2 = defval.Value;
			if (((Quaternion)(ref value2)).Equals(value.Value))
			{
				return;
			}
		}
		Guard.NotNull(writer, "writer");
		writer.WritePropertyName(name);
		writer.WriteQuaternion(value.Value);
	}

	protected static void SerializeProperty(Utf8JsonWriter writer, string name, Matrix4x4? value, Matrix4x4? defval = null)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (!value.HasValue)
		{
			return;
		}
		if (defval.HasValue)
		{
			Matrix4x4 value2 = defval.Value;
			if (((Matrix4x4)(ref value2)).Equals(value.Value))
			{
				return;
			}
		}
		Guard.NotNull(writer, "writer");
		writer.WritePropertyName(name);
		writer.WriteMatrix4x4(value.Value);
	}

	protected static void SerializePropertyEnumValue<T>(Utf8JsonWriter writer, string name, T? value, T? defval = null) where T : struct
	{
		Guard.IsTrue(typeof(T).IsEnum, "T");
		if (value.HasValue && (!defval.HasValue || !defval.Value.Equals(value)))
		{
			Guard.NotNull(writer, "writer");
			writer.WriteNumber(name, (int)(object)value);
		}
	}

	protected static void SerializePropertyEnumSymbol<T>(Utf8JsonWriter writer, string name, T? value, T? defval = null) where T : struct
	{
		Guard.IsTrue(typeof(T).IsEnum, "T");
		if (value.HasValue && (!defval.HasValue || !defval.Value.Equals(value)))
		{
			Guard.NotNull(writer, "writer");
			writer.WriteString(name, Enum.GetName(typeof(T), value));
		}
	}

	protected static void SerializePropertyObject<T>(Utf8JsonWriter writer, string name, T value) where T : JsonSerializable
	{
		if (value != null)
		{
			Guard.NotNull(writer, "writer");
			_SerializeProperty(writer, name, value);
		}
	}

	protected static void SerializeProperty<T>(Utf8JsonWriter writer, string name, IReadOnlyList<T> collection, int? minItems = 1)
	{
		if (collection == null || (minItems.HasValue && collection.Count < minItems.Value))
		{
			return;
		}
		Guard.NotNull(writer, "writer");
		writer.WritePropertyName(name);
		writer.WriteStartArray();
		foreach (T item in collection)
		{
			_SerializeValue(writer, item);
		}
		writer.WriteEndArray();
	}

	protected static void SerializeProperty<T>(Utf8JsonWriter writer, string name, IReadOnlyDictionary<string, T> collection)
	{
		if (collection == null || collection.Count < 1)
		{
			return;
		}
		Guard.NotNull(writer, "writer");
		writer.WritePropertyName(name);
		writer.WriteStartObject();
		foreach (KeyValuePair<string, T> item in collection)
		{
			_SerializeProperty(writer, item.Key, item.Value);
		}
		writer.WriteEndObject();
	}

	private static void _SerializeProperty(Utf8JsonWriter writer, string name, object value)
	{
		Guard.NotNull(writer, "writer");
		Guard.NotNull(value, "value");
		if (!_IsNullOrEmpty(value) && !writer.TryWriteProperty(name, value))
		{
			writer.WritePropertyName(name);
			_SerializeValue(writer, value);
		}
	}

	private static bool _IsNullOrEmpty(object value)
	{
		if (value == null)
		{
			return true;
		}
		if (value is ICollection { Count: 0 })
		{
			return true;
		}
		return false;
	}

	private static void _SerializeValue(Utf8JsonWriter writer, object value)
	{
		Guard.NotNull(writer, "writer");
		Guard.NotNull(value, "value");
		if (writer.TryWriteValue(value))
		{
			return;
		}
		if (value is JsonNode jsonNode)
		{
			jsonNode.WriteTo(writer);
			return;
		}
		if (value is JsonSerializable jsonSerializable)
		{
			jsonSerializable.Serialize(writer);
			return;
		}
		if (value is IDictionary dictionary)
		{
			if (dictionary.Count == 0)
			{
				return;
			}
			writer.WriteStartObject();
			foreach (object key in dictionary.Keys)
			{
				object obj = dictionary[key];
				if (obj != null && (obj is string || obj is JsonSerializable || (!(obj is IList { Count: 0 }) && !(obj is IDictionary { Count: 0 }))))
				{
					_SerializeProperty(writer, key.ToString(), obj);
				}
			}
			writer.WriteEndObject();
			return;
		}
		if (value is IList list2)
		{
			if (list2.Count == 0)
			{
				return;
			}
			writer.WriteStartArray();
			foreach (object item in list2)
			{
				_SerializeValue(writer, item);
			}
			writer.WriteEndArray();
			return;
		}
		throw new NotImplementedException("Serialization of " + value.GetType().Name + " types is not supported.");
	}

	internal void Deserialize(ref Utf8JsonReader reader)
	{
		if (reader.TokenType == JsonTokenType.PropertyName)
		{
			reader.Read();
		}
		if (reader.TokenType == JsonTokenType.StartObject)
		{
			while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
			{
				if (reader.TokenType == JsonTokenType.PropertyName)
				{
					string jsonPropertyName = reader.GetString();
					DeserializeProperty(jsonPropertyName, ref reader);
					continue;
				}
				throw new NotImplementedException();
			}
			return;
		}
		throw new JsonException($"Unexpected token {reader.TokenType}");
	}

	protected static object DeserializeUnknownObject(ref Utf8JsonReader reader)
	{
		if (reader.TokenType == JsonTokenType.PropertyName)
		{
			reader.Read();
		}
		if (reader.TokenType == JsonTokenType.StartArray)
		{
			List<object> list = new List<object>();
			while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
			{
				list.Add(DeserializeUnknownObject(ref reader));
			}
			return list;
		}
		if (reader.TokenType == JsonTokenType.StartObject)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
			{
				if (reader.TokenType == JsonTokenType.PropertyName)
				{
					string key = reader.GetString();
					dictionary[key] = DeserializeUnknownObject(ref reader);
					continue;
				}
				throw new JsonException();
			}
			return dictionary;
		}
		return reader.GetAnyValue();
	}

	protected abstract void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader);

	protected static T DeserializePropertyValue<T>(ref Utf8JsonReader reader)
	{
		_TryCastValue<T>(ref reader, out var value);
		return (T)value;
	}

	protected static void DeserializePropertyValue<TParent, T>(ref Utf8JsonReader reader, TParent owner, out T property) where TParent : class
	{
		_TryCastValue<T>(ref reader, out var value);
		property = (T)value;
		if (property is IChildOf<TParent> childOf)
		{
			childOf.SetLogicalParent(owner);
		}
	}

	protected static void DeserializePropertyList<TParent, T>(ref Utf8JsonReader reader, TParent owner, IList<T> list) where TParent : class
	{
		DeserializePropertyList(ref reader, list);
	}

	protected static void DeserializePropertyList<T>(ref Utf8JsonReader reader, IList<T> list)
	{
		Guard.NotNull(list, "list");
		if (reader.TokenType == JsonTokenType.PropertyName)
		{
			reader.Read();
		}
		if (reader.TokenType != JsonTokenType.StartArray)
		{
			throw new JsonException();
		}
		if (reader.TokenType == JsonTokenType.StartObject)
		{
			throw new JsonException();
		}
		while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
		{
			if (_TryCastValue<T>(ref reader, out var value))
			{
				list.Add((T)value);
			}
		}
		if (list.Count == 0)
		{
			throw new JsonException("Empty array found.");
		}
	}

	protected static void DeserializePropertyDictionary<TParent, T>(ref Utf8JsonReader reader, TParent owner, IDictionary<string, T> dict) where TParent : class
	{
		DeserializePropertyDictionary(ref reader, dict);
	}

	protected static void DeserializePropertyDictionary<T>(ref Utf8JsonReader reader, IDictionary<string, T> dict)
	{
		Guard.NotNull(dict, "dict");
		if (reader.TokenType == JsonTokenType.PropertyName)
		{
			reader.Read();
		}
		if (reader.TokenType == JsonTokenType.StartArray)
		{
			throw new JsonException();
		}
		if (reader.TokenType != JsonTokenType.StartObject)
		{
			throw new JsonException();
		}
		while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
		{
			if (reader.TokenType == JsonTokenType.PropertyName)
			{
				string key = reader.GetString();
				if (_TryCastValue<T>(ref reader, out var value))
				{
					dict[key] = (T)value;
				}
			}
		}
		if (dict.Count == 0)
		{
			throw new JsonException("Empty dictionary found.");
		}
	}

	private static bool _TryCastValue<T>(ref Utf8JsonReader reader, out object value)
	{
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		value = null;
		if (reader.TokenType == JsonTokenType.EndArray)
		{
			return false;
		}
		if (reader.TokenType == JsonTokenType.EndObject)
		{
			return false;
		}
		if (reader.TokenType == JsonTokenType.PropertyName)
		{
			reader.Read();
		}
		Type type = typeof(T);
		Type underlyingType = Nullable.GetUnderlyingType(type);
		if (underlyingType != null)
		{
			type = underlyingType;
		}
		if (type == typeof(string))
		{
			value = reader.AsString();
			return true;
		}
		if (type == typeof(bool))
		{
			value = reader.AsBoolean();
			return true;
		}
		if (type == typeof(short))
		{
			value = reader.GetInt16();
			return true;
		}
		if (type == typeof(int))
		{
			value = reader.GetInt32();
			return true;
		}
		if (type == typeof(long))
		{
			value = reader.GetInt64();
			return true;
		}
		if (type == typeof(ushort))
		{
			value = reader.GetUInt16();
			return true;
		}
		if (type == typeof(uint))
		{
			value = reader.GetUInt32();
			return true;
		}
		if (type == typeof(ulong))
		{
			value = reader.GetUInt64();
			return true;
		}
		if (type == typeof(float))
		{
			value = reader.GetSingle();
			return true;
		}
		if (type == typeof(double))
		{
			value = reader.GetDouble();
			return true;
		}
		if (type == typeof(decimal))
		{
			value = reader.GetDecimal();
			return true;
		}
		if (type.IsEnum)
		{
			value = reader.AsEnum(type);
			return true;
		}
		if (type == typeof(Vector2))
		{
			List<float> list = new List<float>(2);
			DeserializePropertyList(ref reader, list);
			value = (object)new Vector2(list[0], list[1]);
			return true;
		}
		if (type == typeof(Vector3))
		{
			List<float> list2 = new List<float>(3);
			DeserializePropertyList(ref reader, list2);
			value = (object)new Vector3(list2[0], list2[1], list2[2]);
			return true;
		}
		if (type == typeof(Vector4))
		{
			List<float> list3 = new List<float>(4);
			DeserializePropertyList(ref reader, list3);
			value = (object)new Vector4(list3[0], list3[1], list3[2], list3[3]);
			return true;
		}
		if (type == typeof(Quaternion))
		{
			List<float> list4 = new List<float>(4);
			DeserializePropertyList(ref reader, list4);
			value = (object)new Quaternion(list4[0], list4[1], list4[2], list4[3]);
			return true;
		}
		if (type == typeof(Matrix4x4))
		{
			List<float> list5 = new List<float>(16);
			DeserializePropertyList(ref reader, list5);
			value = (object)new Matrix4x4(list5[0], list5[1], list5[2], list5[3], list5[4], list5[5], list5[6], list5[7], list5[8], list5[9], list5[10], list5[11], list5[12], list5[13], list5[14], list5[15]);
			return true;
		}
		if (typeof(JsonNode).IsAssignableFrom(type))
		{
			value = JsonNode.Parse(ref reader);
			return true;
		}
		if (typeof(JsonSerializable).IsAssignableFrom(type))
		{
			JsonSerializable jsonSerializable = Activator.CreateInstance(type, nonPublic: true) as JsonSerializable;
			jsonSerializable.Deserialize(ref reader);
			value = jsonSerializable;
			return true;
		}
		if (type.IsGenericType)
		{
			if (type.GetGenericTypeDefinition() == typeof(Dictionary<, >))
			{
				Type type2 = type.GetGenericArguments()[1];
				if (type2 == typeof(int))
				{
					Dictionary<string, int> dictionary = new Dictionary<string, int>();
					DeserializePropertyDictionary(ref reader, dictionary);
					value = dictionary;
					return true;
				}
			}
			throw new NotImplementedException($"Can't deserialize {type}");
		}
		throw new NotImplementedException($"Can't deserialize {type}");
	}
}
