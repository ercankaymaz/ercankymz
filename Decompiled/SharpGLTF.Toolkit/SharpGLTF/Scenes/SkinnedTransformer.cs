using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text.Json.Nodes;
using SharpGLTF.Geometry;
using SharpGLTF.Materials;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF.Scenes;

[DebuggerDisplay("SkinnedTransformer Node[{_DebugName,nq}] = {Content}")]
public class SkinnedTransformer : ContentTransformer, Schema2SceneBuilder.IOperator<Scene>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _NodeName;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private JsonNode _NodeExtras;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AffineTransform? _MeshPoseWorldTransform;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly List<(NodeBuilder Joint, Matrix4x4? InverseBindMatrix)> _Joints = new List<(NodeBuilder, Matrix4x4?)>();

	public override string Name
	{
		get
		{
			return _NodeName;
		}
		set
		{
			_NodeName = value;
		}
	}

	public override JsonNode Extras
	{
		get
		{
			return _NodeExtras;
		}
		set
		{
			_NodeExtras = value;
		}
	}

	internal SkinnedTransformer(IMeshBuilder<MaterialBuilder> mesh, AffineTransform meshWorldTransform, NodeBuilder[] joints)
		: base(mesh)
	{
		SetJoints(meshWorldTransform, joints);
	}

	internal SkinnedTransformer(IMeshBuilder<MaterialBuilder> mesh, (NodeBuilder Joint, Matrix4x4 InverseBindMatrix)[] joints)
		: base(mesh)
	{
		SetJoints(joints);
	}

	protected SkinnedTransformer(SkinnedTransformer other, DeepCloneContext args)
		: base(other)
	{
		SharpGLTF.Guard.NotNull(other, "other");
		_NodeName = other._NodeName;
		_NodeExtras = other._NodeExtras?.DeepClone();
		_MeshPoseWorldTransform = other._MeshPoseWorldTransform;
		foreach (var joint in other._Joints)
		{
			NodeBuilder item = joint.Joint;
			Matrix4x4? item2 = joint.InverseBindMatrix;
			(NodeBuilder, Matrix4x4?) item3 = (args.GetNode(item), item2);
			_Joints.Add(item3);
		}
	}

	public override ContentTransformer DeepClone(DeepCloneContext args)
	{
		return new SkinnedTransformer(this, args);
	}

	private void SetJoints(AffineTransform meshWorldTransform, NodeBuilder[] joints)
	{
		SharpGLTF.Guard.NotNull(joints, "joints");
		SharpGLTF.Guard.IsTrue(NodeBuilder.IsValidArmature(joints), "joints");
		_MeshPoseWorldTransform = meshWorldTransform;
		_Joints.Clear();
		_Joints.AddRange(joints.Select((NodeBuilder item) => ((NodeBuilder item, Matrix4x4?))(item: item, null)));
	}

	private void SetJoints((NodeBuilder Joint, Matrix4x4 InverseBindMatrix)[] joints)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(joints, "joints");
		SharpGLTF.Guard.IsTrue(NodeBuilder.IsValidArmature(joints.Select(((NodeBuilder Joint, Matrix4x4 InverseBindMatrix) item) => item.Joint)), "joints");
		for (int num = 0; num < joints.Length; num++)
		{
			Matrix4x4Factory.GuardMatrix(string.Format("{0}[{1}]", "joints", num), joints[num].InverseBindMatrix, Matrix4x4Factory.MatrixCheck.WorldTransform, 0.01f);
		}
		_MeshPoseWorldTransform = null;
		_Joints.Clear();
		_Joints.AddRange(joints.Select(((NodeBuilder Joint, Matrix4x4 InverseBindMatrix) item) => ((NodeBuilder Joint, Matrix4x4?))(Joint: item.Joint, item.InverseBindMatrix)));
	}

	public (NodeBuilder Joint, Matrix4x4 InverseBindMatrix)[] GetJointBindings()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		(NodeBuilder, Matrix4x4)[] array = new(NodeBuilder, Matrix4x4)[_Joints.Count];
		Matrix4x4 meshWorldTransform = _MeshPoseWorldTransform?.Matrix ?? Matrix4x4.Identity;
		for (int i = 0; i < array.Length; i++)
		{
			NodeBuilder item = _Joints[i].Joint;
			Matrix4x4 item2 = (Matrix4x4)(((_003F?)_Joints[i].InverseBindMatrix) ?? SkinnedTransform.CalculateInverseBinding(meshWorldTransform, item.WorldMatrix));
			array[i] = (item, item2);
		}
		return array;
	}

	public override NodeBuilder GetArmatureRoot()
	{
		return _Joints.Select(((NodeBuilder Joint, Matrix4x4? InverseBindMatrix) item) => item.Joint.Root).Distinct().FirstOrDefault();
	}

	public IGeometryTransform GetWorldTransformer(string animationTrack, float time)
	{
		(NodeBuilder Joint, Matrix4x4 InverseBindMatrix)[] jb = GetJointBindings();
		return new SkinnedTransform(jb.Length, (int idx) => jb[idx].InverseBindMatrix, (int idx) => jb[idx].Joint.GetWorldMatrix(animationTrack, time), default(SparseWeight8), useAbsoluteMorphTargets: false);
	}

	public override Matrix4x4 GetPoseWorldMatrix()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		return _MeshPoseWorldTransform?.Matrix ?? Matrix4x4.Identity;
	}

	void Schema2SceneBuilder.IOperator<Scene>.ApplyTo(Scene dstScene, Schema2SceneBuilder context)
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		if (!(base.Content is Schema2SceneBuilder.IOperator<Node> obj))
		{
			return;
		}
		Node node = dstScene.CreateNode();
		node.Name = _NodeName;
		node.Extras = _NodeExtras;
		if (_MeshPoseWorldTransform.HasValue)
		{
			Node[] array = new Node[_Joints.Count];
			for (int i = 0; i < array.Length; i++)
			{
				var (key, val) = _Joints[i];
				array[i] = context.GetNode(key);
			}
			node.WithSkinBinding(_MeshPoseWorldTransform.Value.Matrix, array);
		}
		else
		{
			(Node, Matrix4x4)[] joints = _Joints.Select(((NodeBuilder Joint, Matrix4x4? InverseBindMatrix) j) => (context.GetNode(j.Joint), Value: j.InverseBindMatrix.Value)).ToArray();
			node.WithSkinBinding(joints);
		}
		obj.ApplyTo(node, context);
		Schema2SceneBuilder.SetMorphAnimation(node, base.Morphings);
	}
}
