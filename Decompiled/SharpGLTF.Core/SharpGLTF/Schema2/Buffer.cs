using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("Buffer[{LogicalIndex}] {Name} Bytes:{_Content?.Length ?? 0}")]
public sealed class Buffer : LogicalChildOfRoot
{
	public new const string SCHEMANAME = "buffer";

	private const int _byteLengthMinimum = 1;

	private int _byteLength;

	private string _uri;

	private byte[] _Content;

	private const string EMBEDDEDOCTETSTREAM = "data:application/octet-stream";

	private const string EMBEDDEDGLTFBUFFER = "data:application/gltf-buffer";

	public byte[] Content => _Content;

	protected override string GetSchemaName()
	{
		return "buffer";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "byteLength";
		yield return "uri";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (!(name == "byteLength"))
		{
			if (name == "uri")
			{
				value = FieldInfo.From("uri", this, (Buffer instance) => instance._uri);
				return true;
			}
			return base.TryReflectField(name, out value);
		}
		value = FieldInfo.From("byteLength", this, (Buffer instance) => instance._byteLength);
		return true;
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "byteLength", _byteLength);
		JsonSerializable.SerializeProperty(writer, "uri", _uri);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (!(jsonPropertyName == "byteLength"))
		{
			if (jsonPropertyName == "uri")
			{
				JsonSerializable.DeserializePropertyValue<Buffer, string>(ref reader, this, out _uri);
			}
			else
			{
				base.DeserializeProperty(jsonPropertyName, ref reader);
			}
		}
		else
		{
			JsonSerializable.DeserializePropertyValue<Buffer, int>(ref reader, this, out _byteLength);
		}
	}

	internal Buffer()
	{
	}

	internal Buffer(byte[] content)
	{
		_Content = content;
	}

	internal void _ResolveUri(ReadContext context)
	{
		_Content = _LoadBinaryBufferUnchecked(_uri, context);
		_uri = null;
	}

	private static byte[] _LoadBinaryBufferUnchecked(string uri, ReadContext context)
	{
		byte[] array = uri.TryParseBase64Unchecked("data:application/gltf-buffer", "data:application/octet-stream");
		if (array != null)
		{
			return array;
		}
		ArraySegment<byte> arraySegment = context.ReadAllBytesToEnd(uri);
		if (!arraySegment.TryGetUnderlayingArray(out var array2))
		{
			return Enumerable.ToArray(arraySegment);
		}
		return array2;
	}

	internal void _WriteToSatellite(WriteContext writer, string satelliteUri)
	{
		writer.WriteAllBytesToEnd(satelliteUri, new ArraySegment<byte>(_Content.GetPaddedContent()));
		_uri = satelliteUri._EscapeStringInternal();
		_byteLength = _Content.Length;
	}

	internal void _WriteToInternal()
	{
		_uri = null;
		_byteLength = _Content.Length;
	}

	internal void _ClearAfterWrite()
	{
		_uri = null;
		_byteLength = 0;
	}

	internal void _IsolateMemory()
	{
		if (_Content != null)
		{
			byte[] array = new byte[_Content.Length];
			_Content.CopyTo(array, 0);
			_Content = array;
		}
	}

	internal void OnValidateBinaryChunk(ValidationContext validate, byte[] binaryChunk)
	{
		validate = validate.GetContext(this);
		if (_uri == null)
		{
			validate.NotNull("binaryChunk", binaryChunk).IsLessOrEqual("ByteLength", _byteLength, binaryChunk.Length);
			return;
		}
		validate.IsValidURI("_uri", _uri, "data:application/gltf-buffer", "data:application/octet-stream");
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		validate.IsGreaterOrEqual("ByteLength", _byteLength, 1);
		base.OnValidateReferences(validate);
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		validate.NotNull("Content", _Content).IsLessOrEqual("ByteLength", _byteLength, _Content.Length);
		base.OnValidateContent(validate);
	}
}
