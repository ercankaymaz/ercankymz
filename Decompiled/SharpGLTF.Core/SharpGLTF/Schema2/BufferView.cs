using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using SharpGLTF.Diagnostics;
using SharpGLTF.IO;
using SharpGLTF.Memory;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerTypeProxy(typeof(_BufferViewDebugProxy))]
[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public sealed class BufferView : LogicalChildOfRoot
{
	public new const string SCHEMANAME = "bufferView";

	private int _buffer;

	private const int _byteLengthMinimum = 1;

	private int _byteLength;

	private const int _byteOffsetDefault = 0;

	private const int _byteOffsetMinimum = 0;

	private int? _byteOffset = 0;

	private const int _byteStrideMinimum = 4;

	private const int _byteStrideMaximum = 252;

	private int? _byteStride;

	private BufferMode? _target;

	public bool IsVertexBuffer => _target == BufferMode.ARRAY_BUFFER;

	public bool IsIndexBuffer => _target == BufferMode.ELEMENT_ARRAY_BUFFER;

	public bool IsDataBuffer => !_target.HasValue;

	public int ByteStride => _byteStride.AsValue(0);

	public ArraySegment<byte> Content
	{
		get
		{
			Buffer buffer = base.LogicalParent.LogicalBuffers[_buffer];
			int offset = _byteOffset.AsValue(0);
			int byteLength = _byteLength;
			return new ArraySegment<byte>(buffer.Content, offset, byteLength);
		}
	}

	internal int LogicalBufferIndex => _buffer;

	protected override string GetSchemaName()
	{
		return "bufferView";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "buffer";
		yield return "byteLength";
		yield return "byteOffset";
		yield return "byteStride";
		yield return "target";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "buffer":
			value = FieldInfo.From("buffer", this, (BufferView instance) => instance._buffer);
			return true;
		case "byteLength":
			value = FieldInfo.From("byteLength", this, (BufferView instance) => instance._byteLength);
			return true;
		case "byteOffset":
			value = FieldInfo.From("byteOffset", this, (BufferView instance) => instance._byteOffset.GetValueOrDefault());
			return true;
		case "byteStride":
			value = FieldInfo.From("byteStride", this, (BufferView instance) => instance._byteStride);
			return true;
		case "target":
			value = FieldInfo.From("target", this, (BufferView instance) => instance._target);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "buffer", _buffer);
		JsonSerializable.SerializeProperty(writer, "byteLength", _byteLength);
		JsonSerializable.SerializeProperty(writer, "byteOffset", _byteOffset, 0);
		JsonSerializable.SerializeProperty(writer, "byteStride", _byteStride);
		JsonSerializable.SerializePropertyEnumValue(writer, "target", _target);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "buffer":
			JsonSerializable.DeserializePropertyValue<BufferView, int>(ref reader, this, out _buffer);
			break;
		case "byteLength":
			JsonSerializable.DeserializePropertyValue<BufferView, int>(ref reader, this, out _byteLength);
			break;
		case "byteOffset":
			JsonSerializable.DeserializePropertyValue<BufferView, int?>(ref reader, this, out _byteOffset);
			break;
		case "byteStride":
			JsonSerializable.DeserializePropertyValue<BufferView, int?>(ref reader, this, out _byteStride);
			break;
		case "target":
			_target = JsonSerializable.DeserializePropertyValue<BufferMode>(ref reader);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal string _GetDebuggerDisplay()
	{
		return this.ToReport();
	}

	internal BufferView()
	{
	}

	internal BufferView(Buffer buffer, int byteOffset, int? byteLength, int byteStride, BufferMode? target)
	{
		Guard.NotNull(buffer, "buffer");
		Guard.NotNull(buffer.Content, "buffer");
		Guard.NotNull(buffer.LogicalParent, "buffer");
		byteLength = byteLength.AsValue(buffer.Content.Length - byteOffset);
		Guard.MustBeGreaterThanOrEqualTo(byteLength.AsValue(0), 1, "byteLength");
		Guard.MustBeGreaterThanOrEqualTo(byteOffset, 0, "byteOffset");
		if (target == BufferMode.ELEMENT_ARRAY_BUFFER || byteStride == 0)
		{
			Guard.IsTrue(byteStride == 0, "byteStride");
			_byteStride = null;
		}
		else if (byteStride > 0)
		{
			Guard.IsTrue(byteStride.IsMultipleOf(4), "byteStride");
			Guard.MustBeBetweenOrEqualTo(byteStride, 4, 252, "byteStride");
			_byteStride = byteStride.AsNullable(0, 4, 252);
		}
		_buffer = buffer.LogicalIndex;
		_byteLength = byteLength.AsValue(buffer.Content.Length);
		_byteOffset = byteOffset.AsNullable(0, 0, int.MaxValue);
		_target = target;
	}

	public IEnumerable<Image> FindImages()
	{
		int idx = base.LogicalIndex;
		return base.LogicalParent.LogicalImages.Where((Image image) => image._SourceBufferViewIndex == idx);
	}

	public IEnumerable<Accessor> FindAccessors()
	{
		int idx = base.LogicalIndex;
		return base.LogicalParent.LogicalAccessors.Where((Accessor accessor) => accessor._SourceBufferViewIndex == idx);
	}

	internal void _IsolateBufferMemory(_StaticBufferBuilder targetBuffer)
	{
		byte[] content = base.LogicalParent.LogicalBuffers[_buffer].Content;
		byte[] array = new byte[_byteLength];
		Array.Copy(content, _byteOffset.GetValueOrDefault(), array, 0, _byteLength);
		_buffer = targetBuffer.BufferIndex;
		_byteLength = array.Length;
		_byteOffset = targetBuffer.Append(array);
	}

	public bool IsInterleaved(IEnumerable<Accessor> accessors)
	{
		Guard.NotNullOrEmpty(accessors, "accessors");
		foreach (Accessor accessor in accessors)
		{
			Guard.NotNull(accessor, "accessor");
			Guard.IsTrue(accessor.SourceBufferView == this, "accessors");
			if (accessor.ByteOffset >= ByteStride)
			{
				return false;
			}
		}
		return true;
	}

	internal static bool AreEqual(BufferView bv, ArraySegment<byte> content, int byteStride, BufferMode? target)
	{
		ArraySegment<byte> content2 = bv.Content;
		if (content2.Array != content.Array)
		{
			return false;
		}
		if (content2.Offset != content.Offset)
		{
			return false;
		}
		if (content2.Count != content.Count)
		{
			return false;
		}
		if (bv.ByteStride != byteStride)
		{
			return false;
		}
		if (bv._target != target)
		{
			return false;
		}
		return true;
	}

	internal static int GetAccessorByteLength(in AttributeFormat fmt, int count, BufferView bv)
	{
		int byteSize = fmt.ByteSize;
		if (bv == null || bv.ByteStride == 0)
		{
			return byteSize * count;
		}
		return bv.ByteStride * (count - 1) + byteSize;
	}

	internal static void VerifyAccess(ValidationContext validate, BufferView bv, int accessorByteOffset, AttributeFormat format, int count)
	{
		if (format.Normalized)
		{
			validate.IsAnyOf("Encoding", format.Encoding, EncodingType.UNSIGNED_BYTE, EncodingType.UNSIGNED_SHORT, EncodingType.BYTE, EncodingType.SHORT);
		}
		if (bv.IsVertexBuffer && bv.ByteStride == 0)
		{
			validate.IsMultipleOf("ElementByteSize", format.ByteSize, 4);
		}
		if (bv.IsIndexBuffer)
		{
			validate.GetContext(bv).IsUndefined("ByteStride", bv._byteStride);
			validate.IsAnyOf("Format", format, (dim: DimensionType.SCALAR, enc: EncodingType.UNSIGNED_BYTE), (dim: DimensionType.SCALAR, enc: EncodingType.UNSIGNED_SHORT), (dim: DimensionType.SCALAR, enc: EncodingType.UNSIGNED_INT));
		}
		if (bv.ByteStride > 0)
		{
			validate.IsGreaterOrEqual("ElementByteSize", bv.ByteStride, format.ByteSize);
		}
		int accessorByteLength = GetAccessorByteLength(in format, count, bv);
		validate.IsNullOrInRange((name: "BufferView", index: bv.LogicalIndex), accessorByteOffset, accessorByteLength, bv.Content);
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		base.OnValidateReferences(validate);
		validate.IsNullOrIndex("Buffer", _buffer, base.LogicalParent.LogicalBuffers).NonNegative("ByteOffset", _byteOffset).IsGreaterOrEqual("ByteLength", _byteLength, 1);
		if (_byteStride.HasValue)
		{
			validate.IsAnyOf("Target", _target, null, BufferMode.ARRAY_BUFFER).IsInRange("ByteStride", _byteStride.Value, 4, 252).IsMultipleOf("ByteStride", _byteStride.Value, 4);
		}
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		base.OnValidateContent(validate);
		Buffer buffer = base.LogicalParent.LogicalBuffers[_buffer];
		byte[] content = buffer.Content;
		validate.IsNullOrInRange("ByteOffset", _byteOffset, _byteLength, buffer.Content).IsLessOrEqual("ByteStride", ByteStride, _byteLength);
	}

	internal void ValidateBufferUsageGPU(ValidationContext validate, BufferMode usingMode)
	{
		validate = validate.GetContext(this);
		if (_target.HasValue)
		{
			validate.EnumsAreEqual("_target", _target.Value, usingMode);
		}
	}

	internal void ValidateBufferUsagePlainData(ValidationContext validate, bool supportsStride = true)
	{
		if (_byteStride.HasValue && !supportsStride)
		{
			if (validate.TryFix)
			{
				_byteStride = null;
			}
			validate.IsUndefined("_byteStride", _byteStride);
		}
		validate = validate.GetContext(this);
		if (_target.HasValue)
		{
			if (validate.TryFix)
			{
				_target = null;
			}
			validate.IsUndefined("_target", _target);
		}
	}
}
