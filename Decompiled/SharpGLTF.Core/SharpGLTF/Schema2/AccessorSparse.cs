using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Memory;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
public sealed class AccessorSparse : ExtraProperties
{
	public new const string SCHEMANAME = "sparse";

	private const int _countMinimum = 1;

	private int _count;

	private AccessorSparseIndices _indices;

	private AccessorSparseValues _values;

	public int Count => _count;

	protected override string GetSchemaName()
	{
		return "sparse";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "count";
		yield return "indices";
		yield return "values";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "count":
			value = FieldInfo.From("count", this, (AccessorSparse instance) => instance._count);
			return true;
		case "indices":
			value = FieldInfo.From("indices", this, (AccessorSparse instance) => instance._indices);
			return true;
		case "values":
			value = FieldInfo.From("values", this, (AccessorSparse instance) => instance._values);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "count", _count);
		JsonSerializable.SerializePropertyObject(writer, "indices", _indices);
		JsonSerializable.SerializePropertyObject(writer, "values", _values);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "count":
			JsonSerializable.DeserializePropertyValue<AccessorSparse, int>(ref reader, this, out _count);
			break;
		case "indices":
			JsonSerializable.DeserializePropertyValue<AccessorSparse, AccessorSparseIndices>(ref reader, this, out _indices);
			break;
		case "values":
			JsonSerializable.DeserializePropertyValue<AccessorSparse, AccessorSparseValues>(ref reader, this, out _values);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal AccessorSparse()
	{
	}

	internal AccessorSparse(int sparseCount, BufferView indices, int indicesOffset, IndexEncodingType indicesEncoding, BufferView values, int valuesOffset)
	{
		Guard.NotNull(indices, "indices");
		Guard.NotNull(values, "values");
		Guard.MustBeGreaterThanOrEqualTo(sparseCount, 1, "sparseCount");
		_count = sparseCount;
		_indices = new AccessorSparseIndices(indices, indicesOffset, indicesEncoding);
		_values = new AccessorSparseValues(values, valuesOffset);
	}

	internal KeyValuePair<IntegerArray, MemoryAccessor> _CreateMemoryAccessors(Accessor baseAccessor)
	{
		IntegerArray key = _indices._GetIndicesArray(baseAccessor.LogicalParent, _count);
		MemoryAccessor value = _values._GetMemoryAccessor(baseAccessor.LogicalParent, _count, baseAccessor);
		return new KeyValuePair<IntegerArray, MemoryAccessor>(key, value);
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		base.OnValidateReferences(validate);
		validate.IsInRange("Count", _count, 1, int.MaxValue).IsDefined("Indices", _indices).IsDefined("Values", _values);
		_indices?.ValidateReferences(validate);
		_values?.ValidateReferences(validate);
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		base.OnValidateContent(validate);
		_indices.ValidateIndices(validate, _count);
		_values.ValidateValues(validate, _count);
	}
}
