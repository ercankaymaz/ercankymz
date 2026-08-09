using System.Diagnostics;
using System.Numerics;
using System.Text.Json.Nodes;
using SharpGLTF.Schema2;

namespace SharpGLTF.Scenes;

[DebuggerDisplay("RigidTransformer Node[{_DebugName,nq}] = {Content}")]
public class RigidTransformer : ContentTransformer, Schema2SceneBuilder.IOperator<Scene>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private NodeBuilder _Node;

	public override string Name
	{
		get
		{
			return _Node.Name;
		}
		set
		{
			_Node.Name = value;
		}
	}

	public override JsonNode Extras
	{
		get
		{
			return _Node.Extras;
		}
		set
		{
			_Node.Extras = value;
		}
	}

	public NodeBuilder Transform
	{
		get
		{
			return _Node;
		}
		set
		{
			_Node = value;
		}
	}

	internal RigidTransformer(object content, NodeBuilder node)
		: base(content)
	{
		_Node = node;
	}

	protected RigidTransformer(RigidTransformer other, DeepCloneContext args)
		: base(other)
	{
		SharpGLTF.Guard.NotNull(other, "other");
		_Node = args.GetNode(other._Node);
	}

	public override ContentTransformer DeepClone(DeepCloneContext args)
	{
		return new RigidTransformer(this, args);
	}

	public override NodeBuilder GetArmatureRoot()
	{
		return _Node.Root;
	}

	public override Matrix4x4 GetPoseWorldMatrix()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return Transform.WorldMatrix;
	}

	void Schema2SceneBuilder.IOperator<Scene>.ApplyTo(Scene dstScene, Schema2SceneBuilder context)
	{
		if (base.Content is Schema2SceneBuilder.IOperator<Node> obj)
		{
			Node node = context.GetNode(_Node);
			obj.ApplyTo(node, context);
			if (obj is MeshContent)
			{
				Schema2SceneBuilder.SetMorphAnimation(node, base.Morphings);
			}
		}
	}
}
