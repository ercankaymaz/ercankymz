using System.Diagnostics;
using System.Numerics;
using System.Text.Json.Nodes;
using SharpGLTF.Transforms;

namespace SharpGLTF.Scenes;

[DebuggerDisplay("FixedTransformer Node[{_DebugName,nq}] = {Content}")]
public class FixedTransformer : ContentTransformer
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _NodeName;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private JsonNode _NodeExtras;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private NodeBuilder _ParentNode;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AffineTransform _ChildTransform;

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

	public NodeBuilder ParentNode => _ParentNode;

	public AffineTransform ChildTransform
	{
		get
		{
			return _ChildTransform;
		}
		set
		{
			_ChildTransform = value;
		}
	}

	internal FixedTransformer(object content, AffineTransform transform)
		: base(content)
	{
		_ChildTransform = transform;
	}

	internal FixedTransformer(object content, NodeBuilder parentNode, AffineTransform childTransform)
		: base(content)
	{
		_ParentNode = parentNode;
		_ChildTransform = childTransform;
	}

	protected FixedTransformer(FixedTransformer other, DeepCloneContext args)
		: base(other)
	{
		SharpGLTF.Guard.NotNull(other, "other");
		_ParentNode = args.GetNode(other._ParentNode);
		_NodeName = other._NodeName;
		_NodeExtras = other._NodeExtras?.DeepClone();
		_ChildTransform = other._ChildTransform;
	}

	public override ContentTransformer DeepClone(DeepCloneContext args)
	{
		return new FixedTransformer(this, args);
	}

	public override NodeBuilder GetArmatureRoot()
	{
		return _ParentNode?.Root;
	}

	public override Matrix4x4 GetPoseWorldMatrix()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (_ParentNode != null)
		{
			return _ChildTransform.Matrix * _ParentNode.WorldMatrix;
		}
		return _ChildTransform.Matrix;
	}
}
