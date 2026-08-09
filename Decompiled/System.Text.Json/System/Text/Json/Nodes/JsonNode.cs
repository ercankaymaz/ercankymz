using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json.Serialization.Converters;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace System.Text.Json.Nodes;

public abstract class JsonNode
{
	private protected static readonly JsonSerializerOptions s_defaultOptions = new JsonSerializerOptions();

	private JsonNode _parent;

	private JsonNodeOptions? _options;

	internal virtual JsonElement? UnderlyingElement => null;

	public JsonNodeOptions? Options
	{
		get
		{
			if (!_options.HasValue && Parent != null)
			{
				_options = Parent.Options;
			}
			return _options;
		}
	}

	public JsonNode? Parent
	{
		get
		{
			return _parent;
		}
		internal set
		{
			_parent = value;
		}
	}

	public JsonNode Root
	{
		get
		{
			JsonNode parent = Parent;
			if (parent == null)
			{
				return this;
			}
			while (parent.Parent != null)
			{
				parent = parent.Parent;
			}
			return parent;
		}
	}

	public JsonNode? this[int index]
	{
		get
		{
			return GetItem(index);
		}
		set
		{
			SetItem(index, value);
		}
	}

	public JsonNode? this[string propertyName]
	{
		get
		{
			return AsObject().GetItem(propertyName);
		}
		set
		{
			AsObject().SetItem(propertyName, value);
		}
	}

	internal JsonNode(JsonNodeOptions? options = null)
	{
		_options = options;
	}

	public JsonArray AsArray()
	{
		JsonArray jsonArray = this as JsonArray;
		if (jsonArray == null)
		{
			object obj = global::_003CPrivateImplementationDetails_003E._43124F66689BF28A6C659604DD40EA12126064F91162A1EA50186FD55BD9A045_B11;
			if (obj == null)
			{
				obj = new string[1] { "JsonArray" };
				global::_003CPrivateImplementationDetails_003E._43124F66689BF28A6C659604DD40EA12126064F91162A1EA50186FD55BD9A045_B11 = (string[])obj;
			}
			ThrowHelper.ThrowInvalidOperationException_NodeWrongType(new ReadOnlySpan<string>((string[])obj));
		}
		return jsonArray;
	}

	public JsonObject AsObject()
	{
		JsonObject jsonObject = this as JsonObject;
		if (jsonObject == null)
		{
			object obj = global::_003CPrivateImplementationDetails_003E._6EEC039761107FCBC99B7D0010A33ADCCCC6D149369D1448F5DD990C8E8D9C22_B11;
			if (obj == null)
			{
				obj = new string[1] { "JsonObject" };
				global::_003CPrivateImplementationDetails_003E._6EEC039761107FCBC99B7D0010A33ADCCCC6D149369D1448F5DD990C8E8D9C22_B11 = (string[])obj;
			}
			ThrowHelper.ThrowInvalidOperationException_NodeWrongType(new ReadOnlySpan<string>((string[])obj));
		}
		return jsonObject;
	}

	public JsonValue AsValue()
	{
		JsonValue jsonValue = this as JsonValue;
		if (jsonValue == null)
		{
			object obj = global::_003CPrivateImplementationDetails_003E._655BDAA2B8C76C1E302EC9AC19D18270115A7BC573F22C64E99060D8C27A32AB_B11;
			if (obj == null)
			{
				obj = new string[1] { "JsonValue" };
				global::_003CPrivateImplementationDetails_003E._655BDAA2B8C76C1E302EC9AC19D18270115A7BC573F22C64E99060D8C27A32AB_B11 = (string[])obj;
			}
			ThrowHelper.ThrowInvalidOperationException_NodeWrongType(new ReadOnlySpan<string>((string[])obj));
		}
		return jsonValue;
	}

	public string GetPath()
	{
		if (Parent == null)
		{
			return "$";
		}
		Span<char> initialBuffer = stackalloc char[128];
		System.Text.ValueStringBuilder path = new System.Text.ValueStringBuilder(initialBuffer);
		path.Append('$');
		GetPath(ref path, null);
		return path.ToString();
	}

	internal abstract void GetPath(ref System.Text.ValueStringBuilder path, JsonNode child);

	public virtual T GetValue<T>()
	{
		throw new InvalidOperationException(System.SR.Format(System.SR.NodeWrongType, "JsonValue"));
	}

	private protected virtual JsonNode GetItem(int index)
	{
		object obj = global::_003CPrivateImplementationDetails_003E._861A6C24FD9D8C98168C4A642368515FFB3C2373689C2E1794F6FB226CE7E4E2_B11;
		if (obj == null)
		{
			obj = new string[2] { "JsonArray", "JsonObject" };
			global::_003CPrivateImplementationDetails_003E._861A6C24FD9D8C98168C4A642368515FFB3C2373689C2E1794F6FB226CE7E4E2_B11 = (string[])obj;
		}
		ThrowHelper.ThrowInvalidOperationException_NodeWrongType(new ReadOnlySpan<string>((string[])obj));
		return null;
	}

	private protected virtual void SetItem(int index, JsonNode node)
	{
		object obj = global::_003CPrivateImplementationDetails_003E._861A6C24FD9D8C98168C4A642368515FFB3C2373689C2E1794F6FB226CE7E4E2_B11;
		if (obj == null)
		{
			obj = new string[2] { "JsonArray", "JsonObject" };
			global::_003CPrivateImplementationDetails_003E._861A6C24FD9D8C98168C4A642368515FFB3C2373689C2E1794F6FB226CE7E4E2_B11 = (string[])obj;
		}
		ThrowHelper.ThrowInvalidOperationException_NodeWrongType(new ReadOnlySpan<string>((string[])obj));
	}

	public JsonNode DeepClone()
	{
		return DeepCloneCore();
	}

	internal abstract JsonNode DeepCloneCore();

	public JsonValueKind GetValueKind()
	{
		return GetValueKindCore();
	}

	private protected abstract JsonValueKind GetValueKindCore();

	public string GetPropertyName()
	{
		JsonObject obj = _parent as JsonObject;
		if (obj == null)
		{
			ThrowHelper.ThrowInvalidOperationException_NodeParentWrongType("JsonObject");
		}
		return obj.GetPropertyName(this);
	}

	public int GetElementIndex()
	{
		JsonArray obj = _parent as JsonArray;
		if (obj == null)
		{
			ThrowHelper.ThrowInvalidOperationException_NodeParentWrongType("JsonArray");
		}
		return obj.GetElementIndex(this);
	}

	public static bool DeepEquals(JsonNode? node1, JsonNode? node2)
	{
		if (node1 == null)
		{
			return node2 == null;
		}
		if (node2 == null)
		{
			return false;
		}
		return node1.DeepEqualsCore(node2);
	}

	internal abstract bool DeepEqualsCore(JsonNode node);

	[RequiresUnreferencedCode("Creating JsonValue instances with non-primitive types is not compatible with trimming. It can result in non-primitive types being serialized, which may have their members trimmed.")]
	[RequiresDynamicCode("Creating JsonValue instances with non-primitive types requires generating code at runtime.")]
	public void ReplaceWith<T>(T value)
	{
		JsonNode parent = _parent;
		if (!(parent is JsonObject jsonObject))
		{
			if (parent is JsonArray jsonArray)
			{
				JsonNode node = ConvertFromValue(value);
				jsonArray.SetItem(GetElementIndex(), node);
			}
		}
		else
		{
			JsonNode node = ConvertFromValue(value);
			jsonObject.SetItem(GetPropertyName(), node);
		}
	}

	internal void AssignParent(JsonNode parent)
	{
		if (Parent != null)
		{
			ThrowHelper.ThrowInvalidOperationException_NodeAlreadyHasParent();
		}
		for (JsonNode jsonNode = parent; jsonNode != null; jsonNode = jsonNode.Parent)
		{
			if (jsonNode == this)
			{
				ThrowHelper.ThrowInvalidOperationException_NodeCycleDetected();
			}
		}
		Parent = parent;
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	internal static JsonNode ConvertFromValue<T>(T value, JsonNodeOptions? options = null)
	{
		if (value == null)
		{
			return null;
		}
		if (value is JsonNode result)
		{
			return result;
		}
		if (value is JsonElement element)
		{
			return JsonNodeConverter.Create(element, options);
		}
		JsonTypeInfo<T> jsonTypeInfo = (JsonTypeInfo<T>)JsonSerializerOptions.Default.GetTypeInfo(typeof(T));
		return JsonValue.CreateFromTypeInfo(value, jsonTypeInfo, options);
	}

	public static implicit operator JsonNode(bool value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode?(bool? value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode(byte value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode?(byte? value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode(char value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode?(char? value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode(DateTime value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode?(DateTime? value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode(DateTimeOffset value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode?(DateTimeOffset? value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode(decimal value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode?(decimal? value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode(double value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode?(double? value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode(Guid value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode?(Guid? value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode(short value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode?(short? value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode(int value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode?(int? value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode(long value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode?(long? value)
	{
		return JsonValue.Create(value);
	}

	[CLSCompliant(false)]
	public static implicit operator JsonNode(sbyte value)
	{
		return JsonValue.Create(value);
	}

	[CLSCompliant(false)]
	public static implicit operator JsonNode?(sbyte? value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode(float value)
	{
		return JsonValue.Create(value);
	}

	public static implicit operator JsonNode?(float? value)
	{
		return JsonValue.Create(value);
	}

	[return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull("value")]
	public static implicit operator JsonNode?(string? value)
	{
		return JsonValue.Create(value);
	}

	[CLSCompliant(false)]
	public static implicit operator JsonNode(ushort value)
	{
		return JsonValue.Create(value);
	}

	[CLSCompliant(false)]
	public static implicit operator JsonNode?(ushort? value)
	{
		return JsonValue.Create(value);
	}

	[CLSCompliant(false)]
	public static implicit operator JsonNode(uint value)
	{
		return JsonValue.Create(value);
	}

	[CLSCompliant(false)]
	public static implicit operator JsonNode?(uint? value)
	{
		return JsonValue.Create(value);
	}

	[CLSCompliant(false)]
	public static implicit operator JsonNode(ulong value)
	{
		return JsonValue.Create(value);
	}

	[CLSCompliant(false)]
	public static implicit operator JsonNode?(ulong? value)
	{
		return JsonValue.Create(value);
	}

	public static explicit operator bool(JsonNode value)
	{
		return value.GetValue<bool>();
	}

	public static explicit operator bool?(JsonNode? value)
	{
		return value?.GetValue<bool>();
	}

	public static explicit operator byte(JsonNode value)
	{
		return value.GetValue<byte>();
	}

	public static explicit operator byte?(JsonNode? value)
	{
		return value?.GetValue<byte>();
	}

	public static explicit operator char(JsonNode value)
	{
		return value.GetValue<char>();
	}

	public static explicit operator char?(JsonNode? value)
	{
		return value?.GetValue<char>();
	}

	public static explicit operator DateTime(JsonNode value)
	{
		return value.GetValue<DateTime>();
	}

	public static explicit operator DateTime?(JsonNode? value)
	{
		return value?.GetValue<DateTime>();
	}

	public static explicit operator DateTimeOffset(JsonNode value)
	{
		return value.GetValue<DateTimeOffset>();
	}

	public static explicit operator DateTimeOffset?(JsonNode? value)
	{
		return value?.GetValue<DateTimeOffset>();
	}

	public static explicit operator decimal(JsonNode value)
	{
		return value.GetValue<decimal>();
	}

	public static explicit operator decimal?(JsonNode? value)
	{
		return value?.GetValue<decimal>();
	}

	public static explicit operator double(JsonNode value)
	{
		return value.GetValue<double>();
	}

	public static explicit operator double?(JsonNode? value)
	{
		return value?.GetValue<double>();
	}

	public static explicit operator Guid(JsonNode value)
	{
		return value.GetValue<Guid>();
	}

	public static explicit operator Guid?(JsonNode? value)
	{
		return value?.GetValue<Guid>();
	}

	public static explicit operator short(JsonNode value)
	{
		return value.GetValue<short>();
	}

	public static explicit operator short?(JsonNode? value)
	{
		return value?.GetValue<short>();
	}

	public static explicit operator int(JsonNode value)
	{
		return value.GetValue<int>();
	}

	public static explicit operator int?(JsonNode? value)
	{
		return value?.GetValue<int>();
	}

	public static explicit operator long(JsonNode value)
	{
		return value.GetValue<long>();
	}

	public static explicit operator long?(JsonNode? value)
	{
		return value?.GetValue<long>();
	}

	[CLSCompliant(false)]
	public static explicit operator sbyte(JsonNode value)
	{
		return value.GetValue<sbyte>();
	}

	[CLSCompliant(false)]
	public static explicit operator sbyte?(JsonNode? value)
	{
		return value?.GetValue<sbyte>();
	}

	public static explicit operator float(JsonNode value)
	{
		return value.GetValue<float>();
	}

	public static explicit operator float?(JsonNode? value)
	{
		return value?.GetValue<float>();
	}

	public static explicit operator string?(JsonNode? value)
	{
		return value?.GetValue<string>();
	}

	[CLSCompliant(false)]
	public static explicit operator ushort(JsonNode value)
	{
		return value.GetValue<ushort>();
	}

	[CLSCompliant(false)]
	public static explicit operator ushort?(JsonNode? value)
	{
		return value?.GetValue<ushort>();
	}

	[CLSCompliant(false)]
	public static explicit operator uint(JsonNode value)
	{
		return value.GetValue<uint>();
	}

	[CLSCompliant(false)]
	public static explicit operator uint?(JsonNode? value)
	{
		return value?.GetValue<uint>();
	}

	[CLSCompliant(false)]
	public static explicit operator ulong(JsonNode value)
	{
		return value.GetValue<ulong>();
	}

	[CLSCompliant(false)]
	public static explicit operator ulong?(JsonNode? value)
	{
		return value?.GetValue<ulong>();
	}

	public static JsonNode? Parse(ref Utf8JsonReader reader, JsonNodeOptions? nodeOptions = null)
	{
		return JsonNodeConverter.Create(JsonElement.ParseValue(ref reader), nodeOptions);
	}

	public static JsonNode? Parse([StringSyntax("Json")] string json, JsonNodeOptions? nodeOptions = null, JsonDocumentOptions documentOptions = default(JsonDocumentOptions))
	{
		if (json == null)
		{
			ThrowHelper.ThrowArgumentNullException("json");
		}
		return JsonNodeConverter.Create(JsonElement.ParseValue(json, documentOptions), nodeOptions);
	}

	public static JsonNode? Parse(ReadOnlySpan<byte> utf8Json, JsonNodeOptions? nodeOptions = null, JsonDocumentOptions documentOptions = default(JsonDocumentOptions))
	{
		return JsonNodeConverter.Create(JsonElement.ParseValue(utf8Json, documentOptions), nodeOptions);
	}

	public static JsonNode? Parse(Stream utf8Json, JsonNodeOptions? nodeOptions = null, JsonDocumentOptions documentOptions = default(JsonDocumentOptions))
	{
		if (utf8Json == null)
		{
			ThrowHelper.ThrowArgumentNullException("utf8Json");
		}
		return JsonNodeConverter.Create(JsonElement.ParseValue(utf8Json, documentOptions), nodeOptions);
	}

	public static async Task<JsonNode?> ParseAsync(Stream utf8Json, JsonNodeOptions? nodeOptions = null, JsonDocumentOptions documentOptions = default(JsonDocumentOptions), CancellationToken cancellationToken = default(CancellationToken))
	{
		if (utf8Json == null)
		{
			ThrowHelper.ThrowArgumentNullException("utf8Json");
		}
		return JsonNodeConverter.Create((await JsonDocument.ParseAsyncCoreUnrented(utf8Json, documentOptions, cancellationToken).ConfigureAwait(continueOnCapturedContext: false)).RootElement, nodeOptions);
	}

	public string ToJsonString(JsonSerializerOptions? options = null)
	{
		JsonWriterOptions options2 = default(JsonWriterOptions);
		int defaultBufferSize = 16384;
		if (options != null)
		{
			options2 = options.GetWriterOptions();
			defaultBufferSize = options.DefaultBufferSize;
		}
		PooledByteBufferWriter bufferWriter;
		Utf8JsonWriter utf8JsonWriter = Utf8JsonWriterCache.RentWriterAndBuffer(options2, defaultBufferSize, out bufferWriter);
		try
		{
			WriteTo(utf8JsonWriter, options);
			utf8JsonWriter.Flush();
			return JsonHelpers.Utf8GetString(bufferWriter.WrittenMemory.Span);
		}
		finally
		{
			Utf8JsonWriterCache.ReturnWriterAndBuffer(utf8JsonWriter, bufferWriter);
		}
	}

	public override string ToString()
	{
		if (this is JsonValue)
		{
			if (this is JsonValuePrimitive<string> jsonValuePrimitive)
			{
				return jsonValuePrimitive.Value;
			}
			if (this is JsonValueOfElement { Value: { ValueKind: JsonValueKind.String } } jsonValueOfElement)
			{
				return jsonValueOfElement.Value.GetString();
			}
		}
		PooledByteBufferWriter bufferWriter;
		Utf8JsonWriter utf8JsonWriter = Utf8JsonWriterCache.RentWriterAndBuffer(new JsonWriterOptions
		{
			Indented = true
		}, 16384, out bufferWriter);
		try
		{
			WriteTo(utf8JsonWriter);
			utf8JsonWriter.Flush();
			return JsonHelpers.Utf8GetString(bufferWriter.WrittenMemory.Span);
		}
		finally
		{
			Utf8JsonWriterCache.ReturnWriterAndBuffer(utf8JsonWriter, bufferWriter);
		}
	}

	public abstract void WriteTo(Utf8JsonWriter writer, JsonSerializerOptions? options = null);
}
