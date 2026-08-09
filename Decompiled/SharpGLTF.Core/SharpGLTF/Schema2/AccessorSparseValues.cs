using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Memory;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
public sealed class AccessorSparseValues : ExtraProperties
{
	public new const string SCHEMANAME = "values";

	private int _bufferView;

	private const int _byteOffsetDefault = 0;

	private const int _byteOffsetMinimum = 0;

	private int? _byteOffset = 0;

	protected override string GetSchemaName()
	{
		return "values";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "bufferView";
		yield return "byteOffset";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (!(name == "bufferView"))
		{
			if (name == "byteOffset")
			{
				value = FieldInfo.From("byteOffset", this, (AccessorSparseValues instance) => instance._byteOffset.GetValueOrDefault());
				return true;
			}
			return base.TryReflectField(name, out value);
		}
		value = FieldInfo.From("bufferView", this, (AccessorSparseValues instance) => instance._bufferView);
		return true;
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "bufferView", _bufferView);
		JsonSerializable.SerializeProperty(writer, "byteOffset", _byteOffset, 0);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (!(jsonPropertyName == "bufferView"))
		{
			if (jsonPropertyName == "byteOffset")
			{
				JsonSerializable.DeserializePropertyValue<AccessorSparseValues, int?>(ref reader, this, out _byteOffset);
			}
			else
			{
				base.DeserializeProperty(jsonPropertyName, ref reader);
			}
		}
		else
		{
			JsonSerializable.DeserializePropertyValue<AccessorSparseValues, int>(ref reader, this, out _bufferView);
		}
	}

	internal AccessorSparseValues()
	{
	}

	internal AccessorSparseValues(BufferView bv, int byteOffset)
	{
		Guard.NotNull(bv, "bv");
		Guard.MustBeGreaterThanOrEqualTo(byteOffset, 0, "byteOffset");
		_bufferView = bv.LogicalIndex;
		_byteOffset = byteOffset.AsNullable(0);
	}

	internal MemoryAccessor _GetMemoryAccessor(ModelRoot root, int sparseCount, Accessor baseAccessor)
	{
		BufferView bufferView = root.LogicalBufferViews[_bufferView];
		return new MemoryAccessor(info: new MemoryAccessInfo(null, _byteOffset.GetValueOrDefault(), sparseCount, bufferView.ByteStride, baseAccessor.Format), data: bufferView.Content);
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		base.OnValidateReferences(validate);
		validate.NonNegative("ByteOffset", _byteOffset).IsNullOrIndex("BufferView", _bufferView, validate.Root.LogicalBufferViews);
	}

	internal void ValidateValues(ValidationContext validate, int count)
	{
		BufferView bufferView = validate.Root.LogicalBufferViews[_bufferView];
	}
}
