using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Memory;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
public sealed class AccessorSparseIndices : ExtraProperties
{
	public new const string SCHEMANAME = "indices";

	private int _bufferView;

	private const int _byteOffsetDefault = 0;

	private const int _byteOffsetMinimum = 0;

	private int? _byteOffset = 0;

	private IndexEncodingType _componentType;

	protected override string GetSchemaName()
	{
		return "indices";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "bufferView";
		yield return "byteOffset";
		yield return "componentType";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "bufferView":
			value = FieldInfo.From("bufferView", this, (AccessorSparseIndices instance) => instance._bufferView);
			return true;
		case "byteOffset":
			value = FieldInfo.From("byteOffset", this, (AccessorSparseIndices instance) => instance._byteOffset.GetValueOrDefault());
			return true;
		case "componentType":
			value = FieldInfo.From("componentType", this, (AccessorSparseIndices instance) => instance._componentType);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "bufferView", _bufferView);
		JsonSerializable.SerializeProperty(writer, "byteOffset", _byteOffset, 0);
		JsonSerializable.SerializePropertyEnumValue<IndexEncodingType>(writer, "componentType", _componentType);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "bufferView":
			JsonSerializable.DeserializePropertyValue<AccessorSparseIndices, int>(ref reader, this, out _bufferView);
			break;
		case "byteOffset":
			JsonSerializable.DeserializePropertyValue<AccessorSparseIndices, int?>(ref reader, this, out _byteOffset);
			break;
		case "componentType":
			_componentType = JsonSerializable.DeserializePropertyValue<IndexEncodingType>(ref reader);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal AccessorSparseIndices()
	{
	}

	internal AccessorSparseIndices(BufferView bv, int byteOffset, IndexEncodingType encoding)
	{
		Guard.NotNull(bv, "bv");
		Guard.MustBeGreaterThanOrEqualTo(byteOffset, 0, "byteOffset");
		_bufferView = bv.LogicalIndex;
		_byteOffset = byteOffset.AsNullable(0);
		_componentType = encoding;
	}

	internal IntegerArray _GetIndicesArray(ModelRoot root, int sparseCount)
	{
		BufferView bufferView = root.LogicalBufferViews[_bufferView];
		return new IntegerArray(bufferView.Content, _byteOffset.GetValueOrDefault(), sparseCount, _componentType);
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		base.OnValidateReferences(validate);
		validate.NonNegative("ByteOffset", _byteOffset).IsNullOrIndex("BufferView", _bufferView, validate.Root.LogicalBufferViews);
	}

	internal void ValidateIndices(ValidationContext validate, int count)
	{
		validate = validate.GetContext(this);
		BufferView bv = validate.Root.LogicalBufferViews[_bufferView];
		BufferView.VerifyAccess(validate, bv, _byteOffset.GetValueOrDefault(), (dim: DimensionType.SCALAR, enc: _componentType.ToComponent()), count);
	}
}
