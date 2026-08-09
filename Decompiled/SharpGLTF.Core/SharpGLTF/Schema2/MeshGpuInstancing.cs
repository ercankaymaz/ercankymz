using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.Collections;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Transforms;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("{Count}")]
public class MeshGpuInstancing : ExtraProperties
{
	public new const string SCHEMANAME = "EXT_mesh_gpu_instancing";

	private Dictionary<string, int> _attributes;

	private readonly Node _Owner;

	public Node LogicalParent => _Owner;

	public Node VisualParent => _Owner;

	public int Count => _GetCount();

	public IReadOnlyDictionary<string, Accessor> Accessors => _GetAccessors();

	public IEnumerable<AffineTransform> LocalTransforms => _GetLocalTransforms();

	protected override string GetSchemaName()
	{
		return "EXT_mesh_gpu_instancing";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "attributes";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (name == "attributes")
		{
			value = FieldInfo.From("attributes", this, (MeshGpuInstancing instance) => instance._attributes);
			return true;
		}
		return base.TryReflectField(name, out value);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "attributes", _attributes);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (jsonPropertyName == "attributes")
		{
			JsonSerializable.DeserializePropertyDictionary(ref reader, this, _attributes);
		}
		else
		{
			base.DeserializeProperty(jsonPropertyName, ref reader);
		}
	}

	internal MeshGpuInstancing(Node node)
	{
		_Owner = node;
		_attributes = new Dictionary<string, int>();
	}

	private int _GetCount()
	{
		if (_attributes.Count != 0)
		{
			return _attributes.Values.Select((int item) => _Owner.LogicalParent.LogicalAccessors[item].Count).Min();
		}
		return 0;
	}

	private IReadOnlyDictionary<string, Accessor> _GetAccessors()
	{
		return new ReadOnlyLinqDictionary<string, int, Accessor>(_attributes, (int alidx) => LogicalParent.LogicalParent.LogicalAccessors[alidx]);
	}

	private IEnumerable<AffineTransform> _GetLocalTransforms()
	{
		int c = _GetCount();
		int i = 0;
		while (i < c)
		{
			yield return GetLocalTransform(i);
			int num = i + 1;
			i = num;
		}
	}

	public void ClearAccessors()
	{
		_attributes.Clear();
	}

	public Accessor GetAccessor(string attributeKey)
	{
		Guard.NotNullOrEmpty(attributeKey, "attributeKey");
		if (!_attributes.TryGetValue(attributeKey, out var value))
		{
			return null;
		}
		return _Owner.LogicalParent.LogicalAccessors[value];
	}

	public void SetAccessor(string attributeKey, Accessor accessor)
	{
		Guard.NotNullOrEmpty(attributeKey, "attributeKey");
		if (accessor != null)
		{
			Guard.MustShareLogicalParent(_Owner.LogicalParent, "LogicalParent", accessor, "accessor");
			if (_attributes.Count > 0)
			{
				Guard.MustBeEqualTo(Count, accessor.Count, "accessor");
			}
			_attributes[attributeKey] = accessor.LogicalIndex;
		}
		else
		{
			_attributes.Remove(attributeKey);
		}
	}

	public AffineTransform GetLocalTransform(int index)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		Vector3? scale = GetAccessor("SCALE")?.AsVector3Array()?[index];
		Quaternion? rotation = GetAccessor("ROTATION")?.AsQuaternionArray()?[index];
		Vector3? translation = GetAccessor("TRANSLATION")?.AsVector3Array()?[index];
		return AffineTransform.CreateFromAny(null, scale, rotation, translation);
	}

	public Matrix4x4 GetLocalMatrix(int index)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		return GetLocalTransform(index).Matrix;
	}

	public Matrix4x4 GetWorldMatrix(int index)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		return GetLocalMatrix(index) * _Owner.WorldMatrix;
	}
}
