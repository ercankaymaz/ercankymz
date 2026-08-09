using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.Diagnostics;
using SharpGLTF.IO;
using SharpGLTF.Memory;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
[DebuggerTypeProxy(typeof(_AccessorDebugProxy))]
public sealed class Accessor : LogicalChildOfRoot
{
	public new const string SCHEMANAME = "accessor";

	private int? _bufferView;

	private const int _byteOffsetDefault = 0;

	private const int _byteOffsetMinimum = 0;

	private int? _byteOffset = 0;

	private EncodingType _componentType;

	private const int _countMinimum = 1;

	private int _count;

	private const int _maxMinItems = 1;

	private const int _maxMaxItems = 16;

	private List<double> _max;

	private const int _minMinItems = 1;

	private const int _minMaxItems = 16;

	private List<double> _min;

	private static readonly bool _normalizedDefault;

	private bool? _normalized = _normalizedDefault;

	private AccessorSparse _sparse;

	private string _type;

	private DimensionType? _CachedType;

	public int Count => _count;

	public DimensionType Dimensions => _GetDimensions();

	public EncodingType Encoding => _componentType;

	public bool Normalized => _normalized.AsValue(defval: false);

	internal int _SourceBufferViewIndex => _bufferView.AsValue(-1);

	public int ByteLength => BufferView.GetAccessorByteLength(Format, Count, SourceBufferView);

	public BufferView SourceBufferView
	{
		get
		{
			if (!_bufferView.HasValue)
			{
				return null;
			}
			return base.LogicalParent.LogicalBufferViews[_bufferView.Value];
		}
	}

	public int ByteOffset => _byteOffset.AsValue(0);

	public bool IsSparse => _sparse != null;

	public AttributeFormat Format => new AttributeFormat(Dimensions, _componentType, _normalized.AsValue(defval: false));

	public (IReadOnlyList<double> Min, IReadOnlyList<double> Max) Bounds
	{
		get
		{
			IReadOnlyList<double> readOnlyList = _min;
			if (readOnlyList == null)
			{
				readOnlyList = Array.Empty<double>();
			}
			IReadOnlyList<double> readOnlyList2 = _max;
			if (readOnlyList2 == null)
			{
				readOnlyList2 = Array.Empty<double>();
			}
			return (Min: readOnlyList, Max: readOnlyList2);
		}
	}

	protected override string GetSchemaName()
	{
		return "accessor";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "bufferView";
		yield return "byteOffset";
		yield return "componentType";
		yield return "count";
		yield return "max";
		yield return "min";
		yield return "normalized";
		yield return "sparse";
		yield return "type";
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
			value = FieldInfo.From("bufferView", this, (Accessor instance) => instance._bufferView);
			return true;
		case "byteOffset":
			value = FieldInfo.From("byteOffset", this, (Accessor instance) => instance._byteOffset.GetValueOrDefault());
			return true;
		case "componentType":
			value = FieldInfo.From("componentType", this, (Accessor instance) => instance._componentType);
			return true;
		case "count":
			value = FieldInfo.From("count", this, (Accessor instance) => instance._count);
			return true;
		case "max":
			value = FieldInfo.From("max", this, (Accessor instance) => instance._max);
			return true;
		case "min":
			value = FieldInfo.From("min", this, (Accessor instance) => instance._min);
			return true;
		case "normalized":
			value = FieldInfo.From("normalized", this, (Accessor instance) => instance._normalized == true);
			return true;
		case "sparse":
			value = FieldInfo.From("sparse", this, (Accessor instance) => instance._sparse);
			return true;
		case "type":
			value = FieldInfo.From("type", this, (Accessor instance) => instance._type);
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
		JsonSerializable.SerializePropertyEnumValue<EncodingType>(writer, "componentType", _componentType);
		JsonSerializable.SerializeProperty(writer, "count", _count);
		JsonSerializable.SerializeProperty(writer, "max", _max, 1);
		JsonSerializable.SerializeProperty(writer, "min", _min, 1);
		JsonSerializable.SerializeProperty(writer, "normalized", _normalized, _normalizedDefault);
		JsonSerializable.SerializePropertyObject(writer, "sparse", _sparse);
		JsonSerializable.SerializeProperty(writer, "type", _type);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "bufferView":
			JsonSerializable.DeserializePropertyValue<Accessor, int?>(ref reader, this, out _bufferView);
			break;
		case "byteOffset":
			JsonSerializable.DeserializePropertyValue<Accessor, int?>(ref reader, this, out _byteOffset);
			break;
		case "componentType":
			_componentType = JsonSerializable.DeserializePropertyValue<EncodingType>(ref reader);
			break;
		case "count":
			JsonSerializable.DeserializePropertyValue<Accessor, int>(ref reader, this, out _count);
			break;
		case "max":
			JsonSerializable.DeserializePropertyList(ref reader, this, _max);
			break;
		case "min":
			JsonSerializable.DeserializePropertyList(ref reader, this, _min);
			break;
		case "normalized":
			JsonSerializable.DeserializePropertyValue<Accessor, bool?>(ref reader, this, out _normalized);
			break;
		case "sparse":
			JsonSerializable.DeserializePropertyValue<Accessor, AccessorSparse>(ref reader, this, out _sparse);
			break;
		case "type":
			JsonSerializable.DeserializePropertyValue<Accessor, string>(ref reader, this, out _type);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	public IAccessorArray<Matrix3x2> AsMatrix2x2Array()
	{
		if (!_TryGetMemoryAccessor(out var mem))
		{
			return new ZeroAccessorArray<Matrix3x2>(_count);
		}
		return mem.AsMatrix2x2Array();
	}

	public IAccessorArray<Matrix4x4> AsMatrix3x3Array()
	{
		if (!_TryGetMemoryAccessor(out var mem))
		{
			return new ZeroAccessorArray<Matrix4x4>(_count);
		}
		return mem.AsMatrix3x3Array();
	}

	public IAccessorArray<Matrix4x4> AsMatrix4x3Array()
	{
		if (!_TryGetMemoryAccessor(out var mem))
		{
			return new ZeroAccessorArray<Matrix4x4>(_count);
		}
		return mem.AsMatrix4x3Array();
	}

	public IAccessorArray<Matrix4x4> AsMatrix4x4Array()
	{
		if (!_TryGetMemoryAccessor(out var mem))
		{
			return new ZeroAccessorArray<Matrix4x4>(_count);
		}
		return mem.AsArrayOf<Matrix4x4>();
	}

	[Obsolete("Use AsMatrix4x4Array instead", true)]
	internal IReadOnlyList<Matrix4x4> AsMatrix4x4ReadOnlyList()
	{
		if (!_TryGetMemoryAccessor(out var mem))
		{
			return new ZeroAccessorArray<Matrix4x4>(_count);
		}
		return mem.AsArrayOf<Matrix4x4>();
	}

	public IAccessorArray<Quaternion> AsQuaternionArray()
	{
		if (_TryGetMemoryAccessor(out var mem))
		{
			if (_sparse == null)
			{
				return mem.AsQuaternionArray();
			}
			throw new NotImplementedException();
		}
		if (_sparse == null)
		{
			return new ZeroAccessorArray<Quaternion>(_count);
		}
		throw new NotImplementedException();
	}

	public IAccessorArray<float[]> AsMultiArray(int dimensions)
	{
		if (_TryGetMemoryAccessor(out var mem))
		{
			if (_sparse == null)
			{
				return mem.AsMultiArray(dimensions);
			}
			throw new NotImplementedException();
		}
		throw new NotImplementedException();
	}

	public IAccessorArray<uint> AsIndicesArray()
	{
		Guard.IsFalse(IsSparse, "IsSparse");
		Guard.IsTrue(Dimensions == DimensionType.SCALAR, "Dimensions");
		if (!_TryGetMemoryAccessor(out var _))
		{
			return new ZeroAccessorArray<uint>(_count);
		}
		return new IntegerArray(SourceBufferView.Content, ByteOffset, _count, Encoding.ToIndex());
	}

	public IAccessorArray<float> AsScalarArray()
	{
		return AsArrayOf<float>();
	}

	public IAccessorArray<Vector2> AsVector2Array()
	{
		return this.AsArrayOf<Vector2>();
	}

	public IAccessorArray<Vector3> AsVector3Array()
	{
		return this.AsArrayOf<Vector3>();
	}

	public IAccessorArray<Vector4> AsVector4Array()
	{
		return this.AsArrayOf<Vector4>();
	}

	public IAccessorArray<T> AsArrayOf<T>() where T : unmanaged
	{
		if (_TryGetMemoryAccessor(out var mem))
		{
			if (_sparse == null)
			{
				return mem.AsArrayOf<T>();
			}
			KeyValuePair<IntegerArray, MemoryAccessor> keyValuePair = _sparse._CreateMemoryAccessors(this);
			return MemoryAccessor.CreateSparseArray<T>(mem, keyValuePair.Key, keyValuePair.Value);
		}
		if (_sparse == null)
		{
			return new ZeroAccessorArray<T>(_count);
		}
		KeyValuePair<IntegerArray, MemoryAccessor> keyValuePair2 = _sparse._CreateMemoryAccessors(this);
		return MemoryAccessor.CreateSparseArray<T>(_count, keyValuePair2.Key, keyValuePair2.Value);
	}

	public IAccessorArray<Vector4> AsColorArray(float defaultW = 1f)
	{
		if (_TryGetMemoryAccessor(out var mem))
		{
			if (_sparse == null)
			{
				return mem.AsColorArray(defaultW);
			}
			KeyValuePair<IntegerArray, MemoryAccessor> keyValuePair = _sparse._CreateMemoryAccessors(this);
			return MemoryAccessor.CreateColorSparseArray(mem, keyValuePair.Key, keyValuePair.Value, defaultW);
		}
		if (_sparse == null)
		{
			return new ZeroAccessorArray<Vector4>(_count);
		}
		KeyValuePair<IntegerArray, MemoryAccessor> keyValuePair2 = _sparse._CreateMemoryAccessors(this);
		return MemoryAccessor.CreateColorSparseArray(_count, keyValuePair2.Key, keyValuePair2.Value);
	}

	public ArraySegment<byte> TryGetVertexBytes(int vertexIdx)
	{
		if (_sparse != null)
		{
			throw new InvalidOperationException("Can't be used on Acessors with Sparse Data");
		}
		if (!TryGetBufferView(out var bv))
		{
			return default(ArraySegment<byte>);
		}
		int num = Encoding.ByteLength() * Dimensions.DimCount();
		int num2 = Math.Max(num, bv.ByteStride);
		int num3 = vertexIdx * num2;
		return _Extensions.Slice(bv.Content, ByteOffset + vertexIdx * num2, num);
	}

	internal string _GetDebuggerDisplay()
	{
		return this.ToReportLong();
	}

	internal Accessor()
	{
		_min = new List<double>();
		_max = new List<double>();
		_byteOffset = null;
		_normalized = null;
	}

	private DimensionType _GetDimensions()
	{
		if (_CachedType.HasValue)
		{
			return _CachedType.Value;
		}
		_CachedType = (Enum.TryParse<DimensionType>(_type, out var result) ? result : DimensionType.CUSTOM);
		return _CachedType.Value;
	}

	internal bool _TryGetMemoryAccessor(out MemoryAccessor mem)
	{
		if (!TryGetBufferView(out var bv))
		{
			mem = null;
			return false;
		}
		mem = new MemoryAccessor(info: new MemoryAccessInfo(null, ByteOffset, Count, bv.ByteStride, Format), data: bv.Content);
		return true;
	}

	internal bool _TryGetMemoryAccessor(string name, out MemoryAccessor mem)
	{
		if (!TryGetBufferView(out var bv))
		{
			mem = null;
			return false;
		}
		mem = new MemoryAccessor(info: new MemoryAccessInfo(name, ByteOffset, Count, bv.ByteStride, Format), data: bv.Content);
		return true;
	}

	public bool TryGetBufferView(out BufferView bv)
	{
		if (_bufferView.HasValue)
		{
			bv = base.LogicalParent.LogicalBufferViews[_bufferView.Value];
			return true;
		}
		bv = null;
		return false;
	}

	public void UpdateBounds()
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		_min.Clear();
		_max.Clear();
		if (Count == 0 || Encoding != EncodingType.FLOAT)
		{
			return;
		}
		switch (Dimensions.DimCount())
		{
		case 1:
		{
			_ResetBounds();
			IAccessorArray<float> accessorArray2 = AsScalarArray();
			for (int j = 0; j < accessorArray2.Count; j++)
			{
				_AppendToBounds(accessorArray2[j]);
			}
			break;
		}
		case 2:
		{
			_ResetBounds();
			IAccessorArray<Vector2> accessorArray3 = AsVector2Array();
			for (int k = 0; k < accessorArray3.Count; k++)
			{
				_AppendToBounds<Vector2>(accessorArray3[k]);
			}
			break;
		}
		case 3:
		{
			_ResetBounds();
			IAccessorArray<Vector3> accessorArray = AsVector3Array();
			for (int i = 0; i < accessorArray.Count; i++)
			{
				_AppendToBounds<Vector3>(accessorArray[i]);
			}
			break;
		}
		}
	}

	private void _ResetBounds()
	{
		int num = Dimensions.DimCount();
		for (int i = 0; i < num; i++)
		{
			_min.Add(double.MaxValue);
			_max.Add(double.MinValue);
		}
	}

	private void _AppendToBounds<T>(T value) where T : unmanaged
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		if (!(value is float num))
		{
			if (!(value is Vector2 val))
			{
				if (!(value is Vector3 val2))
				{
					if (!(value is Vector4 val3))
					{
						if (value is Quaternion val4)
						{
							_AppendToBounds(val4.X, val4.Y, val4.Z, val4.W);
						}
					}
					else
					{
						_AppendToBounds(val3.X, val3.Y, val3.Z, val3.W);
					}
				}
				else
				{
					_AppendToBounds(val2.X, val2.Y, val2.Z);
				}
			}
			else
			{
				_AppendToBounds(val.X, val.Y);
			}
		}
		else
		{
			_AppendToBounds(num);
		}
	}

	private void _AppendToBounds(params float[] values)
	{
		if (values.Length != _min.Count)
		{
			throw new ArgumentException("values");
		}
		for (int i = 0; i < values.Length; i++)
		{
			_min[i] = Math.Min(_min[i], values[i]);
			_max[i] = Math.Max(_max[i], values[i]);
		}
	}

	public void SetDataFrom(Accessor other)
	{
		Guard.NotNull(other, "other");
		Guard.MustShareLogicalParent(this, other, "other");
		if (other._bufferView.HasValue)
		{
			if (other.SourceBufferView.ByteStride == 0)
			{
				throw new ArgumentException("When a BufferView is shared by more than one Accessor, its ByteStride must be explicitly set.", "Accessor");
			}
			SetData(other.SourceBufferView, other.ByteOffset, other.Count, other.Format);
		}
		else
		{
			SetZeros(other.Count, other.Format);
		}
	}

	public void SetZeros(MemoryAccessInfo accessor)
	{
		SetZeros(accessor.ItemsCount, accessor.Format);
	}

	public void SetZeros(int itemCount, AttributeFormat format)
	{
		Guard.MustBeGreaterThanOrEqualTo(itemCount, 1, "itemCount");
		_bufferView = null;
		_byteOffset = null;
		_count = itemCount;
		_CachedType = format.Dimensions;
		_type = Enum.GetName(typeof(DimensionType), format.Dimensions);
		_componentType = format.Encoding;
		_normalized = format.Normalized.AsNullable(_normalizedDefault);
		UpdateBounds();
	}

	[Obsolete("Use SetData with AttributeFormat. This will be removed soon.")]
	public void SetData(BufferView buffer, int bufferByteOffset, int itemCount, DimensionType dimensions, EncodingType encoding, bool normalized)
	{
		SetData(buffer, bufferByteOffset, itemCount, (dim: dimensions, enc: encoding, nrm: normalized));
	}

	public void SetData(BufferView buffer, int bufferByteOffset, int itemCount, AttributeFormat format)
	{
		Guard.NotNull(buffer, "buffer");
		Guard.MustShareLogicalParent(this, buffer, "buffer");
		Guard.MustBeGreaterThanOrEqualTo(bufferByteOffset, 0, "bufferByteOffset");
		Guard.MustBeGreaterThanOrEqualTo(itemCount, 1, "itemCount");
		_bufferView = buffer.LogicalIndex;
		_byteOffset = bufferByteOffset.AsNullable(0, 0, int.MaxValue);
		_count = itemCount;
		_CachedType = format.Dimensions;
		_type = Enum.GetName(typeof(DimensionType), format.Dimensions);
		_componentType = format.Encoding;
		_normalized = format.Normalized.AsNullable(_normalizedDefault);
		UpdateBounds();
	}

	public void RemoveSparseData()
	{
		_sparse = null;
		UpdateBounds();
	}

	public void CreateSparseData<T>(IReadOnlyDictionary<int, T> data) where T : unmanaged
	{
		if (!Enum.IsDefined(typeof(EncodingType), _componentType))
		{
			throw new InvalidOperationException("The Accessor's Format must be set before setting sparse data");
		}
		MemoryAccessor memoryAccessor = new MemoryAccessor(info: new MemoryAccessInfo("Indices", 0, data.Count, 0, DimensionType.SCALAR, EncodingType.UNSIGNED_INT), data: new byte[data.Count * 4]);
		IntegerArray integerArray = memoryAccessor.AsIntegerArray();
		MemoryAccessInfo info = new MemoryAccessInfo(null, 0, data.Count, 0, Format);
		MemoryAccessor memoryAccessor2 = new MemoryAccessor(new byte[data.Count * info.ByteLength], info);
		IAccessorArray<T> accessorArray = memoryAccessor2.AsArrayOf<T>();
		int num = 0;
		foreach (KeyValuePair<int, T> item in data.OrderBy((KeyValuePair<int, T> keyValuePair) => keyValuePair.Key))
		{
			integerArray[num] = (uint)item.Key;
			accessorArray[num] = item.Value;
			num++;
		}
		SetSparseData(memoryAccessor, memoryAccessor2);
	}

	public void SetSparseData(MemoryAccessor sparseIndices, MemoryAccessor sparseValues)
	{
		Guard.MustBeGreaterThan(sparseIndices.Attribute.ItemsCount, 0, "sparseIndices");
		Guard.MustBeLessThanOrEqualTo(sparseIndices.Attribute.ItemsCount, _count, "sparseIndices");
		Guard.MustBeEqualTo(sparseIndices.Attribute.ItemsCount, sparseValues.Attribute.ItemsCount, "sparseValues");
		BufferView indices = base.LogicalParent.UseBufferView(sparseIndices.Data);
		BufferView values = base.LogicalParent.UseBufferView(sparseValues.Data);
		SetSparseData(sparseIndices.Attribute.ItemsCount, indices, 0, sparseIndices.Attribute.Encoding.ToIndex(), values, 0);
	}

	public void SetSparseData(int sparseCount, BufferView indices, int indicesByteOffset, IndexEncodingType indicesEncoding, BufferView values, int valuesByteOffset)
	{
		Guard.MustBeGreaterThan(sparseCount, 0, "sparseCount");
		Guard.MustBeLessThanOrEqualTo(sparseCount, _count, "sparseCount");
		Guard.NotNull(indices, "indices");
		Guard.MustShareLogicalParent(this, indices, "indices");
		Guard.IsFalse(indices.IsVertexBuffer, "indices");
		Guard.IsFalse(indices.IsIndexBuffer, "indices");
		Guard.MustBeGreaterThanOrEqualTo(indicesByteOffset, 0, "indicesByteOffset");
		Guard.NotNull(values, "values");
		Guard.MustShareLogicalParent(this, values, "values");
		Guard.IsFalse(values.IsVertexBuffer, "values");
		Guard.IsFalse(values.IsIndexBuffer, "values");
		Guard.MustBeGreaterThanOrEqualTo(valuesByteOffset, 0, "valuesByteOffset");
		AccessorSparse accessorSparse = new AccessorSparse(sparseCount, indices, indicesByteOffset, indicesEncoding, values, valuesByteOffset);
		KeyValuePair<IntegerArray, MemoryAccessor> keyValuePair = accessorSparse._CreateMemoryAccessors(this);
		Guard.MustBeEqualTo(keyValuePair.Key.Count, sparseCount, "indices");
		Guard.MustBeEqualTo(keyValuePair.Value.Attribute.ItemsCount, sparseCount, "indices");
		_sparse = accessorSparse;
		UpdateBounds();
	}

	public void SetIndexData(MemoryAccessor src)
	{
		Guard.NotNull(src, "src");
		BufferView buffer = base.LogicalParent.UseBufferView(src.Data, src.Attribute.ByteStride, BufferMode.ELEMENT_ARRAY_BUFFER);
		SetIndexData(buffer, src.Attribute.ByteOffset, src.Attribute.ItemsCount, src.Attribute.Encoding.ToIndex());
	}

	public void SetIndexData(BufferView buffer, int bufferByteOffset, int itemCount, IndexEncodingType encoding)
	{
		Guard.NotNull(buffer, "buffer");
		Guard.MustShareLogicalParent(this, buffer, "buffer");
		Guard.IsFalse(buffer.IsVertexBuffer, "buffer");
		SetData(buffer, bufferByteOffset, itemCount, encoding.ToComponent());
	}

	public void SetVertexData(MemoryAccessor src)
	{
		Guard.NotNull(src, "src");
		BufferView buffer = base.LogicalParent.UseBufferView(src.Data, src.Attribute.StepByteLength, BufferMode.ARRAY_BUFFER);
		SetVertexData(buffer, src.Attribute.ByteOffset, src.Attribute.ItemsCount, src.Attribute.Format);
	}

	[Obsolete("Use SetVertexData with AttributeFormat. This will be removed soon.")]
	public void SetVertexData(BufferView buffer, int bufferByteOffset, int itemCount, DimensionType dimensions = DimensionType.VEC3, EncodingType encoding = EncodingType.FLOAT, bool normalized = false)
	{
		SetVertexData(buffer, bufferByteOffset, itemCount, (dim: dimensions, enc: encoding, nrm: normalized));
	}

	public void SetVertexData(BufferView buffer, int bufferByteOffset, int itemCount, AttributeFormat format)
	{
		Guard.NotNull(buffer, "buffer");
		Guard.MustShareLogicalParent(this, buffer, "buffer");
		Guard.MustBePositiveAndMultipleOf(format.ByteSize, 4, "format");
		Guard.IsFalse(buffer.IsIndexBuffer, "buffer");
		SetData(buffer, bufferByteOffset, itemCount, format);
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		base.OnValidateReferences(validate);
		if (_byteOffset.HasValue)
		{
			validate.IsDefined("_bufferView", _bufferView).IsNullOrIndex("_bufferView", _bufferView, base.LogicalParent.LogicalBufferViews);
		}
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		base.OnValidateContent(validate);
		validate.IsGreaterOrEqual("_count", _count, 1);
		if (_byteOffset.HasValue)
		{
			validate.NonNegative("_byteOffset", _byteOffset);
		}
		if (Dimensions == DimensionType.CUSTOM)
		{
			return;
		}
		if (TryGetBufferView(out var bv))
		{
			BufferView.VerifyAccess(validate, bv, ByteOffset, Format, Count);
		}
		if (_TryGetMemoryAccessor(out var mem))
		{
			validate.That(delegate
			{
				MemoryAccessor.VerifyAccessorBounds(mem, _min, _max);
			});
		}
		if (_normalized == true)
		{
			bool flag = false;
			flag |= Encoding == EncodingType.BYTE;
			flag |= Encoding == EncodingType.UNSIGNED_BYTE;
			flag |= Encoding == EncodingType.SHORT;
			flag |= Encoding == EncodingType.UNSIGNED_SHORT;
			validate.That(flag, "Normalized", "Only Byte and Short can be normalized");
		}
	}

	internal void ValidateIndices(ValidationContext validate, uint vertexCount, PrimitiveType drawingType)
	{
		validate = validate.GetContext(this);
		validate.IsAnyOf("Format", Format, (dim: DimensionType.SCALAR, enc: EncodingType.UNSIGNED_BYTE), (dim: DimensionType.SCALAR, enc: EncodingType.UNSIGNED_SHORT), (dim: DimensionType.SCALAR, enc: EncodingType.UNSIGNED_INT));
		if (TryGetBufferView(out var bv))
		{
			bv.ValidateBufferUsageGPU(validate, BufferMode.ELEMENT_ARRAY_BUFFER);
			validate.AreEqual("ByteStride", bv.ByteStride, 0);
		}
		if (_TryGetMemoryAccessor(out var mem))
		{
			validate.That(delegate
			{
				MemoryAccessor.VerifyVertexIndices(mem, vertexCount);
			});
		}
	}

	internal static void ValidateVertexAttributes(ValidationContext validate, IReadOnlyDictionary<string, Accessor> attributes, int skinsMaxJointCount)
	{
		if (validate.TryFix)
		{
			foreach (KeyValuePair<string, Accessor> item in attributes.Where((KeyValuePair<string, Accessor> item) => item.Key != "POSITION"))
			{
				item.Value._min.Clear();
				item.Value._max.Clear();
			}
		}
		if (attributes.TryGetValue("POSITION", out var value))
		{
			value._ValidatePositions(validate);
		}
		if (attributes.TryGetValue("NORMAL", out var value2))
		{
			value2._ValidateNormals(validate);
		}
		if (attributes.TryGetValue("TANGENT", out var value3))
		{
			value3._ValidateTangents(validate);
		}
		if (attributes.TryGetValue("JOINTS_0", out var value4))
		{
			value4._ValidateJoints(validate, "JOINTS_0", skinsMaxJointCount);
		}
		if (attributes.TryGetValue("JOINTS_1", out var value5))
		{
			value5._ValidateJoints(validate, "JOINTS_1", skinsMaxJointCount);
		}
		attributes.TryGetValue("WEIGHTS_0", out var value6);
		attributes.TryGetValue("WEIGHTS_1", out var value7);
		_ValidateWeights(validate, value6, value7);
	}

	private void _ValidatePositions(ValidationContext validate)
	{
		validate = validate.GetContext(this);
		if (TryGetBufferView(out var bv))
		{
			bv.ValidateBufferUsageGPU(validate, BufferMode.ARRAY_BUFFER);
		}
		if (!base.LogicalParent.MeshQuantizationAllowed)
		{
			validate.IsAnyOf("Format", Format, DimensionType.VEC3);
		}
		else
		{
			validate.IsAnyOf("Dimensions", Dimensions, DimensionType.VEC3);
		}
		validate.ArePositions("POSITION", AsVector3Array());
	}

	private void _ValidateNormals(ValidationContext validate)
	{
		validate = validate.GetContext(this);
		if (TryGetBufferView(out var bv))
		{
			bv.ValidateBufferUsageGPU(validate, BufferMode.ARRAY_BUFFER);
		}
		if (!base.LogicalParent.MeshQuantizationAllowed)
		{
			validate.IsAnyOf("Format", Format, DimensionType.VEC3);
		}
		else
		{
			validate.IsAnyOf("Dimensions", Dimensions, DimensionType.VEC3);
		}
		if (validate.TryFix)
		{
			AsVector3Array().SanitizeNormals();
		}
		validate.AreNormals("NORMAL", AsVector3Array());
	}

	private void _ValidateTangents(ValidationContext validate)
	{
		validate = validate.GetContext(this);
		if (TryGetBufferView(out var bv))
		{
			bv.ValidateBufferUsageGPU(validate, BufferMode.ARRAY_BUFFER);
		}
		if (!base.LogicalParent.MeshQuantizationAllowed)
		{
			validate.IsAnyOf("Format", Format, DimensionType.VEC3, DimensionType.VEC4);
		}
		else
		{
			validate.IsAnyOf("Dimensions", Dimensions, DimensionType.VEC3, DimensionType.VEC4);
		}
		if (validate.TryFix)
		{
			if (Dimensions == DimensionType.VEC3)
			{
				AsVector3Array().SanitizeNormals();
			}
			if (Dimensions == DimensionType.VEC4)
			{
				AsVector4Array().SanitizeTangents();
			}
		}
		if (Dimensions == DimensionType.VEC3)
		{
			validate.AreNormals("TANGENT", AsVector3Array());
		}
		if (Dimensions == DimensionType.VEC4)
		{
			validate.AreTangents("TANGENT", AsVector4Array());
		}
	}

	private void _ValidateJoints(ValidationContext validate, string attributeName, int skinsMaxJointCount)
	{
		validate = validate.GetContext(this);
		if (TryGetBufferView(out var bv))
		{
			bv.ValidateBufferUsageGPU(validate, BufferMode.ARRAY_BUFFER);
		}
		validate.IsAnyOf("Format", Format, (dim: DimensionType.VEC4, enc: EncodingType.UNSIGNED_BYTE), (dim: DimensionType.VEC4, enc: EncodingType.UNSIGNED_SHORT), DimensionType.VEC4).AreJoints(attributeName, AsVector4Array(), skinsMaxJointCount);
	}

	private static void _ValidateWeights(ValidationContext validate, Accessor weights0, Accessor weights1)
	{
		weights0?._ValidateWeights(validate);
		weights1?._ValidateWeights(validate);
		MemoryAccessor mem;
		MemoryAccessor memory0 = ((weights0 != null && weights0._TryGetMemoryAccessor("WEIGHTS_0", out mem)) ? mem : null);
		MemoryAccessor mem2;
		MemoryAccessor memory1 = ((weights1 != null && weights1._TryGetMemoryAccessor("WEIGHTS_1", out mem2)) ? mem2 : null);
		validate.That(delegate
		{
			MemoryAccessor.VerifyWeightsSum(memory0, memory1);
		});
	}

	private void _ValidateWeights(ValidationContext validate)
	{
		validate = validate.GetContext(this);
		if (TryGetBufferView(out var bv))
		{
			bv.ValidateBufferUsageGPU(validate, BufferMode.ARRAY_BUFFER);
		}
		validate.IsAnyOf("Format", Format, (dim: DimensionType.VEC4, enc: EncodingType.UNSIGNED_BYTE, nrm: true), (dim: DimensionType.VEC4, enc: EncodingType.UNSIGNED_SHORT, nrm: true), DimensionType.VEC4);
	}

	internal void ValidateMatrices4x3(ValidationContext validate, bool mustInvert = true, bool mustDecompose = true)
	{
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		validate = validate.GetContext(this);
		if (TryGetBufferView(out var bv))
		{
			bv.ValidateBufferUsagePlainData(validate);
		}
		validate.IsAnyOf("Format", Format, (dim: DimensionType.MAT4, enc: EncodingType.BYTE, nrm: true), (dim: DimensionType.MAT4, enc: EncodingType.SHORT, nrm: true), DimensionType.MAT4);
		IReadOnlyList<Matrix4x4> readOnlyList = AsMatrix4x4Array();
		for (int i = 0; i < readOnlyList.Count; i++)
		{
			validate.IsNullOrMatrix4x3("Matrices", readOnlyList[i], mustInvert, mustDecompose);
		}
	}

	internal void ValidateAnimationInput(ValidationContext validate)
	{
		if (TryGetBufferView(out var bv))
		{
			bv.ValidateBufferUsagePlainData(validate, supportsStride: false);
		}
		validate.IsAnyOf("Dimensions", Dimensions, default(DimensionType));
	}

	internal void ValidateAnimationOutput(ValidationContext validate)
	{
		if (TryGetBufferView(out var bv))
		{
			bv.ValidateBufferUsagePlainData(validate, supportsStride: false);
		}
		validate.IsAnyOf("Dimensions", Dimensions, DimensionType.SCALAR, DimensionType.VEC2, DimensionType.VEC3, DimensionType.VEC4);
	}
}
