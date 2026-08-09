using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using SharpGLTF.Collections;
using SharpGLTF.Diagnostics;
using SharpGLTF.IO;
using SharpGLTF.Memory;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("{_DebuggerDisplay(),nq}")]
public sealed class MeshPrimitive : ExtraProperties, IChildOfList<Mesh>
{
	public new const string SCHEMANAME = "primitive";

	private Dictionary<string, int> _attributes;

	private int? _indices;

	private int? _material;

	private const PrimitiveType _modeDefault = PrimitiveType.TRIANGLES;

	private PrimitiveType? _mode = PrimitiveType.TRIANGLES;

	private const int _targetsMinItems = 1;

	private List<Dictionary<string, int>> _targets;

	public int LogicalIndex { get; private set; } = -1;

	public Mesh LogicalParent { get; private set; }

	public Material Material
	{
		get
		{
			if (!_material.HasValue)
			{
				return null;
			}
			return LogicalParent.LogicalParent.LogicalMaterials[_material.Value];
		}
		set
		{
			if (value != null)
			{
				Guard.MustShareLogicalParent(LogicalParent.LogicalParent, "LogicalParent", value, "value");
			}
			_material = value?.LogicalIndex;
		}
	}

	public PrimitiveType DrawPrimitiveType
	{
		get
		{
			return _mode.AsValue(PrimitiveType.TRIANGLES);
		}
		set
		{
			_mode = value.AsNullable(PrimitiveType.TRIANGLES);
		}
	}

	public int MorphTargetsCount => _targets.Count;

	public IReadOnlyDictionary<string, Accessor> VertexAccessors => new ReadOnlyLinqDictionary<string, int, Accessor>(_attributes, (int alidx) => LogicalParent.LogicalParent.LogicalAccessors[alidx]);

	public Accessor IndexAccessor
	{
		get
		{
			return GetIndexAccessor();
		}
		set
		{
			SetIndexAccessor(value);
		}
	}

	protected override string GetSchemaName()
	{
		return "primitive";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "attributes";
		yield return "indices";
		yield return "material";
		yield return "mode";
		yield return "targets";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "attributes":
			value = FieldInfo.From("attributes", this, (MeshPrimitive instance) => instance._attributes);
			return true;
		case "indices":
			value = FieldInfo.From("indices", this, (MeshPrimitive instance) => instance._indices);
			return true;
		case "material":
			value = FieldInfo.From("material", this, (MeshPrimitive instance) => instance._material);
			return true;
		case "mode":
			value = FieldInfo.From("mode", this, (MeshPrimitive instance) => instance._mode ?? PrimitiveType.TRIANGLES);
			return true;
		case "targets":
			value = FieldInfo.From("targets", this, (MeshPrimitive instance) => instance._targets);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "attributes", _attributes);
		JsonSerializable.SerializeProperty(writer, "indices", _indices);
		JsonSerializable.SerializeProperty(writer, "material", _material);
		JsonSerializable.SerializePropertyEnumValue(writer, "mode", _mode, PrimitiveType.TRIANGLES);
		JsonSerializable.SerializeProperty(writer, "targets", _targets, 1);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "attributes":
			JsonSerializable.DeserializePropertyDictionary(ref reader, this, _attributes);
			break;
		case "indices":
			JsonSerializable.DeserializePropertyValue<MeshPrimitive, int?>(ref reader, this, out _indices);
			break;
		case "material":
			JsonSerializable.DeserializePropertyValue<MeshPrimitive, int?>(ref reader, this, out _material);
			break;
		case "mode":
			_mode = JsonSerializable.DeserializePropertyValue<PrimitiveType>(ref reader);
			break;
		case "targets":
			JsonSerializable.DeserializePropertyList(ref reader, this, _targets);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	private string _DebuggerDisplay()
	{
		string txt = $"Primitive[{LogicalIndex}]";
		return this.ToReport(txt);
	}

	internal MeshPrimitive()
	{
		_attributes = new Dictionary<string, int>();
		_targets = new List<Dictionary<string, int>>();
	}

	void IChildOfList<Mesh>.SetLogicalParent(Mesh parent, int index)
	{
		LogicalParent = parent;
		LogicalIndex = index;
	}

	public IEnumerable<BufferView> GetBufferViews(bool includeIndices, bool includeVertices, bool includeMorphs)
	{
		List<Accessor> list = new List<Accessor>();
		string[] array = _attributes.Keys.ToArray();
		if (includeIndices && IndexAccessor != null)
		{
			list.Add(IndexAccessor);
		}
		if (includeVertices)
		{
			list.AddRange(array.Select((string k) => VertexAccessors[k]));
		}
		if (includeMorphs)
		{
			for (int num = 0; num < MorphTargetsCount; num++)
			{
				string[] array2 = array;
				foreach (string key in array2)
				{
					IReadOnlyDictionary<string, Accessor> morphTargetAccessors = GetMorphTargetAccessors(num);
					if (morphTargetAccessors.TryGetValue(key, out var value))
					{
						list.Add(value);
					}
				}
			}
		}
		IEnumerable<int> source = (from item in list
			select item._SourceBufferViewIndex into item
			where item >= 0
			select item).Distinct();
		return source.Select((int idx) => LogicalParent.LogicalParent.LogicalBufferViews[idx]);
	}

	public IReadOnlyList<KeyValuePair<string, Accessor>> GetVertexAccessorsByBuffer(BufferView vb)
	{
		Guard.NotNull(vb, "vb");
		Guard.MustShareLogicalParent(LogicalParent, vb, "vb");
		return (from item in VertexAccessors
			where item.Value.SourceBufferView == vb
			orderby item.Value.ByteOffset
			select item).ToArray();
	}

	public Accessor GetVertexAccessor(string attributeKey)
	{
		Guard.NotNullOrEmpty(attributeKey, "attributeKey");
		if (!_attributes.TryGetValue(attributeKey, out var value))
		{
			return null;
		}
		return LogicalParent.LogicalParent.LogicalAccessors[value];
	}

	public void SetVertexAccessor(string attributeKey, Accessor accessor)
	{
		Guard.NotNullOrEmpty(attributeKey, "attributeKey");
		if (accessor != null)
		{
			Guard.MustShareLogicalParent(LogicalParent.LogicalParent, "LogicalParent", accessor, "accessor");
			_attributes[attributeKey] = accessor.LogicalIndex;
		}
		else
		{
			_attributes.Remove(attributeKey);
		}
	}

	internal IReadOnlyList<T> GetVertices<T>(string attributeKey) where T : unmanaged
	{
		Accessor vertexAccessor = GetVertexAccessor(attributeKey);
		return vertexAccessor.AsArrayOf<T>();
	}

	public Accessor GetIndexAccessor()
	{
		if (!_indices.HasValue)
		{
			return null;
		}
		return LogicalParent.LogicalParent.LogicalAccessors[_indices.Value];
	}

	public void SetIndexAccessor(Accessor accessor)
	{
		if (accessor == null)
		{
			_indices = null;
			return;
		}
		Guard.MustShareLogicalParent(LogicalParent.LogicalParent, "LogicalParent", accessor, "accessor");
		_indices = accessor.LogicalIndex;
	}

	public IList<uint> GetIndices()
	{
		return IndexAccessor?.AsIndicesArray();
	}

	public IEnumerable<int> GetPointIndices()
	{
		if (DrawPrimitiveType.GetPrimitiveVertexSize() != 1)
		{
			return Enumerable.Empty<int>();
		}
		if (IndexAccessor == null)
		{
			return Enumerable.Range(0, VertexAccessors.Values.First().Count);
		}
		return from item in IndexAccessor.AsIndicesArray()
			select (int)item;
	}

	public IEnumerable<(int A, int B)> GetLineIndices()
	{
		if (DrawPrimitiveType.GetPrimitiveVertexSize() != 2)
		{
			return Enumerable.Empty<(int, int)>();
		}
		if (IndexAccessor == null)
		{
			return DrawPrimitiveType.GetLinesIndices(VertexAccessors.Values.First().Count);
		}
		return DrawPrimitiveType.GetLinesIndices(IndexAccessor.AsIndicesArray());
	}

	public IEnumerable<(int A, int B, int C)> GetTriangleIndices()
	{
		if (DrawPrimitiveType.GetPrimitiveVertexSize() != 3)
		{
			return Enumerable.Empty<(int, int, int)>();
		}
		if (IndexAccessor == null)
		{
			return DrawPrimitiveType.GetTrianglesIndices(VertexAccessors.Values.First().Count);
		}
		return DrawPrimitiveType.GetTrianglesIndices(IndexAccessor.AsIndicesArray());
	}

	public IReadOnlyDictionary<string, Accessor> GetMorphTargetAccessors(int targetIdx)
	{
		Guard.MustBeGreaterThanOrEqualTo(targetIdx, 0, "targetIdx");
		return new ReadOnlyLinqDictionary<string, int, Accessor>(_targets[targetIdx], (int alidx) => LogicalParent.LogicalParent.LogicalAccessors[alidx]);
	}

	public void SetMorphTargetAccessors(int targetIdx, IReadOnlyDictionary<string, Accessor> accessors)
	{
		Guard.MustBeGreaterThanOrEqualTo(targetIdx, 0, "targetIdx");
		Guard.NotNull(accessors, "accessors");
		Guard.MustBeGreaterThan(accessors.Count, 0, "accessors");
		foreach (KeyValuePair<string, Accessor> accessor in accessors)
		{
			Guard.MustShareLogicalParent(LogicalParent, accessor.Value, "accessors");
		}
		while (_targets.Count <= targetIdx)
		{
			_targets.Add(new Dictionary<string, int>());
		}
		Dictionary<string, int> dictionary = _targets[targetIdx];
		dictionary.Clear();
		foreach (KeyValuePair<string, Accessor> accessor2 in accessors)
		{
			dictionary[accessor2.Key] = accessor2.Value.LogicalIndex;
		}
	}

	internal static bool CheckAttributesQuantizationRequired(ModelRoot root)
	{
		return root.LogicalMeshes.SelectMany((Mesh item) => item.Primitives).Any((MeshPrimitive prim) => prim.CheckAttributesQuantizationRequired());
	}

	private bool CheckAttributesQuantizationRequired()
	{
		if (_checkAccessors(VertexAccessors))
		{
			return true;
		}
		for (int i = 0; i < MorphTargetsCount; i++)
		{
			IReadOnlyDictionary<string, Accessor> morphTargetAccessors = GetMorphTargetAccessors(i);
			if (_checkAccessors(morphTargetAccessors))
			{
				return true;
			}
		}
		return false;
		static bool _checkAccessors(IReadOnlyDictionary<string, Accessor> accessors)
		{
			foreach (KeyValuePair<string, Accessor> accessor in accessors)
			{
				if (accessor.Value.Encoding != EncodingType.FLOAT)
				{
					if (accessor.Key == "POSITION")
					{
						return true;
					}
					if (accessor.Key == "NORMAL")
					{
						return true;
					}
					if (accessor.Key == "TANGENT")
					{
						return true;
					}
					if (accessor.Value.Encoding != EncodingType.UNSIGNED_BYTE && accessor.Value.Encoding != EncodingType.UNSIGNED_SHORT && accessor.Key.StartsWith("TEXCOORD_", StringComparison.OrdinalIgnoreCase))
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		base.OnValidateReferences(validate);
		ModelRoot logicalParent = LogicalParent.LogicalParent;
		validate.IsNullOrIndex("Material", _material, logicalParent.LogicalMaterials).IsNullOrIndex("Indices", _indices, logicalParent.LogicalAccessors);
		foreach (int value in _attributes.Values)
		{
			validate.IsNullOrIndex("Attributes", value, logicalParent.LogicalAccessors);
		}
		foreach (int item in _targets.SelectMany((Dictionary<string, int> item) => item.Values))
		{
			validate.IsNullOrIndex("Targets", item, logicalParent.LogicalAccessors);
		}
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		base.OnValidateContent(validate);
		int num = -1;
		foreach (KeyValuePair<string, Accessor> vertexAccessor in VertexAccessors)
		{
			if (num < 0)
			{
				num = vertexAccessor.Value.Count;
			}
			else
			{
				validate.AreEqual(vertexAccessor.Key, vertexAccessor.Value.Count, num);
			}
		}
		if (IndexAccessor != null && IndexAccessor.Count > 0)
		{
			IndexAccessor.ValidateIndices(validate, (uint)num, DrawPrimitiveType);
			bool flag = false;
			switch (DrawPrimitiveType)
			{
			case PrimitiveType.POINTS:
				if (IndexAccessor.Count < 1)
				{
					flag = true;
				}
				break;
			case PrimitiveType.LINE_LOOP:
			case PrimitiveType.LINE_STRIP:
				if (IndexAccessor.Count < 2)
				{
					flag = true;
				}
				break;
			case PrimitiveType.TRIANGLE_STRIP:
			case PrimitiveType.TRIANGLE_FAN:
				if (IndexAccessor.Count < 3)
				{
					flag = true;
				}
				break;
			case PrimitiveType.LINES:
				if (!IndexAccessor.Count.IsMultipleOf(2))
				{
					flag = true;
				}
				break;
			case PrimitiveType.TRIANGLES:
				if (!IndexAccessor.Count.IsMultipleOf(3))
				{
					flag = true;
				}
				break;
			}
			validate.IsTrue("_indices", !flag, "Mismatch between indices count and PrimitiveType");
		}
		IEnumerable<IGrouping<BufferView, Accessor>> enumerable = from item in VertexAccessors.Values.Distinct()
			where item.SourceBufferView != null
			group item by item.SourceBufferView;
		foreach (IGrouping<BufferView, Accessor> item in enumerable)
		{
			if (!item.Skip(1).Any())
			{
				continue;
			}
			if (item.Key.ByteStride > 0)
			{
				foreach (Accessor item2 in item)
				{
					if (item2.Format.ByteSizePadded > item.Key.ByteStride)
					{
						validate._LinkThrow("Attributes", $"Attribute element size {item2.Format.ByteSizePadded} exceeds ByteStride {item.Key.ByteStride}");
					}
				}
				continue;
			}
			IEnumerable<MemoryAccessor> abc = from item in item
				select (!item._TryGetMemoryAccessor(out var mem)) ? null : mem into item
				where item != null
				select item;
			if (MemoryAccessor.HaveOverlappingBuffers(abc))
			{
				validate._LinkThrow("Attributes", "BufferView access is expected to be sequential, but some buffers overlap.");
			}
		}
		if (validate.TryFix)
		{
			MemoryAccessor[] vertexAccessors = (from item in VertexAccessors
				select (!item.Value._TryGetMemoryAccessor(item.Key, out var mem)) ? null : mem into item
				where item != null
				select item).ToArray();
			MemoryAccessor.SanitizeVertexAttributes(vertexAccessors);
		}
		List<int> list = (from item in LogicalParent.LogicalParent.LogicalNodes
			where item.Mesh == LogicalParent
			select item.Skin into item
			where item != null
			select item.JointsCount).ToList();
		int skinsMaxJointCount = ((list.Count != 0) ? list.Max() : int.MaxValue);
		Accessor.ValidateVertexAttributes(validate, VertexAccessors, skinsMaxJointCount);
	}
}
