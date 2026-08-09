using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Memory;
using SharpGLTF.Reflection;
using SharpGLTF.Transforms;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("Skin[{LogicalIndex}] {Name}")]
public sealed class Skin : LogicalChildOfRoot
{
	public new const string SCHEMANAME = "skin";

	private int? _inverseBindMatrices;

	private const int _jointsMinItems = 1;

	private List<int> _joints;

	private int? _skeleton;

	public IEnumerable<Node> VisualParents => Node.FindNodesUsingSkin(this);

	public int JointsCount => _joints.Count;

	public IReadOnlyList<Node> Joints => _joints.SelectList((int idx) => base.LogicalParent.LogicalNodes[idx]);

	public IReadOnlyList<Matrix4x4> InverseBindMatrices
	{
		get
		{
			Accessor inverseBindMatricesAccessor = GetInverseBindMatricesAccessor();
			if (inverseBindMatricesAccessor == null)
			{
				return Array.Empty<Matrix4x4>();
			}
			return inverseBindMatricesAccessor.AsMatrix4x4Array();
		}
	}

	public Node Skeleton
	{
		get
		{
			if (!_skeleton.HasValue)
			{
				return null;
			}
			return base.LogicalParent.LogicalNodes[_skeleton.Value];
		}
		set
		{
			if (value != null)
			{
				Guard.MustShareLogicalParent(base.LogicalParent, "LogicalParent", value, "value");
			}
			_skeleton = value?.LogicalIndex;
		}
	}

	protected override string GetSchemaName()
	{
		return "skin";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "inverseBindMatrices";
		yield return "joints";
		yield return "skeleton";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "inverseBindMatrices":
			value = FieldInfo.From("inverseBindMatrices", this, (Skin instance) => instance._inverseBindMatrices);
			return true;
		case "joints":
			value = FieldInfo.From("joints", this, (Skin instance) => instance._joints);
			return true;
		case "skeleton":
			value = FieldInfo.From("skeleton", this, (Skin instance) => instance._skeleton);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "inverseBindMatrices", _inverseBindMatrices);
		JsonSerializable.SerializeProperty(writer, "joints", _joints, 1);
		JsonSerializable.SerializeProperty(writer, "skeleton", _skeleton);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "inverseBindMatrices":
			JsonSerializable.DeserializePropertyValue<Skin, int?>(ref reader, this, out _inverseBindMatrices);
			break;
		case "joints":
			JsonSerializable.DeserializePropertyList(ref reader, this, _joints);
			break;
		case "skeleton":
			JsonSerializable.DeserializePropertyValue<Skin, int?>(ref reader, this, out _skeleton);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal Skin()
	{
		_joints = new List<int>();
	}

	public Accessor UseInverseBindMatricesAccessor()
	{
		Accessor accessor = GetInverseBindMatricesAccessor();
		if (accessor == null)
		{
			accessor = base.LogicalParent.CreateAccessor("Bind Matrices");
			_inverseBindMatrices = accessor.LogicalIndex;
		}
		return accessor;
	}

	public Accessor GetInverseBindMatricesAccessor()
	{
		if (!_inverseBindMatrices.HasValue)
		{
			return null;
		}
		return base.LogicalParent.LogicalAccessors[_inverseBindMatrices.Value];
	}

	public (Node Joint, Matrix4x4 InverseBindMatrix) GetJoint(int idx)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		int index = _joints[idx];
		Node item = base.LogicalParent.LogicalNodes[index];
		Matrix4x4 item2 = ((IReadOnlyList<Matrix4x4>)(GetInverseBindMatricesAccessor()?.AsMatrix4x4Array()))?[idx] ?? Matrix4x4.Identity;
		return (Joint: item, InverseBindMatrix: item2);
	}

	public void BindJoints(params Node[] joints)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		Node node = _FindCommonAncestor(joints);
		BindJoints(node.WorldMatrix, joints);
	}

	public void BindJoints(Matrix4x4 meshBindTransform, params Node[] joints)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		Guard.NotNull(joints, "joints");
		(Node, Matrix4x4)[] array = new(Node, Matrix4x4)[joints.Length];
		for (int i = 0; i < array.Length; i++)
		{
			Guard.NotNull(joints[i], "joints");
			Matrix4x4 item = (Matrix4x4)SkinnedTransform.CalculateInverseBinding((Matrix4x4Double)meshBindTransform, joints[i].WorldMatrixPrecise);
			array[i] = (joints[i], item);
		}
		BindJoints((IReadOnlyList<(Node Joint, Matrix4x4 InverseBindMatrix)>)array);
	}

	public void BindJoints(IReadOnlyList<(Node Joint, Matrix4x4 InverseBindMatrix)> joints)
	{
		Guard.NotNull(joints, "joints");
		_FindCommonAncestor(joints.Select(((Node Joint, Matrix4x4 InverseBindMatrix) item) => item.Joint));
		IEnumerable<Matrix4x4> values = joints.Select(((Node Joint, Matrix4x4 InverseBindMatrix) item, int idx) => _SanitizedIBM(item.InverseBindMatrix, idx));
		byte[] array = new byte[joints.Count * 16 * 4];
		new Matrix4x4Array(array).Fill(values);
		BufferView buffer = base.LogicalParent.UseBufferView(array);
		UseInverseBindMatricesAccessor().SetData(buffer, 0, joints.Count, AttributeFormat.Float4x4);
		_joints.Clear();
		_joints.AddRange(joints.Select(((Node Joint, Matrix4x4 InverseBindMatrix) item) => item.Joint.LogicalIndex));
		static Matrix4x4 _SanitizedIBM(Matrix4x4 ibm, int idx)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			Matrix4x4Factory.GuardMatrix(string.Format("{0}[{1}]", "joints", idx), ibm, Matrix4x4Factory.MatrixCheck.WorldTransform, 0.01f);
			ibm.M14 = 0f;
			ibm.M24 = 0f;
			ibm.M34 = 0f;
			ibm.M44 = 1f;
			return ibm;
		}
	}

	internal bool IsMatch(Node skeleton, KeyValuePair<Node, Matrix4x4>[] joints)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if (skeleton != Skeleton)
		{
			return false;
		}
		if (joints.Length != _joints.Count)
		{
			return false;
		}
		for (int i = 0; i < _joints.Count; i++)
		{
			KeyValuePair<Node, Matrix4x4> keyValuePair = joints[i];
			var (node, val) = GetJoint(i);
			if (keyValuePair.Key != node)
			{
				return false;
			}
			if (keyValuePair.Value != val)
			{
				return false;
			}
		}
		return true;
	}

	internal static IEnumerable<Skin> FindSkinsUsingJoint(Node jointNode)
	{
		int idx = jointNode.LogicalIndex;
		return jointNode.LogicalParent.LogicalSkins.Where((Skin s) => s._joints.Contains(idx));
	}

	internal static IEnumerable<Skin> FindSkinsUsingSkeleton(Node skeletonNode)
	{
		int idx = skeletonNode.LogicalIndex;
		return skeletonNode.LogicalParent.LogicalSkins.Where((Skin s) => s._skeleton == idx);
	}

	private Node _FindCommonAncestor(IEnumerable<Node> nodes)
	{
		if (nodes == null)
		{
			return null;
		}
		nodes = nodes.EnsureList();
		foreach (Node node in nodes)
		{
			Guard.NotNull(node, "nodes");
			Guard.MustShareLogicalParent(this, node, "nodes");
		}
		Node rootJoint = nodes.First();
		while (true)
		{
			if (nodes.All((Node j) => rootJoint == j || rootJoint._ContainsVisualNode(j, recursive: true)))
			{
				return rootJoint;
			}
			if (rootJoint.VisualParent == null)
			{
				break;
			}
			rootJoint = rootJoint.VisualParent;
		}
		Guard.IsTrue(target: false, "nodes", "Common ancestor not found");
		return null;
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		validate.IsNullOrIndex("Skeleton", _skeleton, base.LogicalParent.LogicalNodes).IsNullOrIndex("InverseBindMatrices", _inverseBindMatrices, base.LogicalParent.LogicalAccessors).IsGreaterOrEqual("Joints", _joints.Count, 1);
		Accessor inverseBindMatricesAccessor = GetInverseBindMatricesAccessor();
		if (inverseBindMatricesAccessor != null)
		{
			validate.AreEqual("InverseBindMatrices", inverseBindMatricesAccessor.Count, _joints.Count);
		}
		Node node = null;
		for (int i = 0; i < _joints.Count; i++)
		{
			int num = _joints[i];
			validate.IsNullOrIndex("Joints", num, base.LogicalParent.LogicalNodes);
			Node node2 = base.LogicalParent.LogicalNodes[num];
			Node visualRoot = node2.VisualRoot;
			if (node == null)
			{
				node = visualRoot;
			}
			else
			{
				validate.GetContext(visualRoot).AreSameReference("Root", node, visualRoot);
			}
		}
		base.OnValidateReferences(validate);
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		Accessor inverseBindMatricesAccessor = GetInverseBindMatricesAccessor();
		if (inverseBindMatricesAccessor != null)
		{
			validate.AreEqual("InverseBindMatrices", _joints.Count, inverseBindMatricesAccessor.Count);
			inverseBindMatricesAccessor.ValidateMatrices4x3(validate, mustInvert: true, mustDecompose: false);
		}
		if (_skeleton.HasValue)
		{
			Node skeleton = Skeleton;
			for (int i = 0; i < JointsCount; i++)
			{
				Node item = GetJoint(i).Joint;
				if (skeleton != item)
				{
					skeleton._ContainsVisualNode(item, recursive: true);
				}
			}
		}
		base.OnValidateContent(validate);
	}
}
