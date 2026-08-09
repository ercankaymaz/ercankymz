using System.Numerics;
using SharpGLTF.Transforms;

namespace SharpGLTF.Scenes;

public readonly struct TransformChainBuilder
{
	private readonly NodeBuilder _ParentTransform;

	private readonly AffineTransform? _ChildTransform;

	public NodeBuilder Parent => _ParentTransform;

	public AffineTransform? Child => _ChildTransform;

	public static implicit operator TransformChainBuilder(NodeBuilder node)
	{
		return new TransformChainBuilder(node);
	}

	public static implicit operator TransformChainBuilder(AffineTransform transform)
	{
		return new TransformChainBuilder(transform);
	}

	public static implicit operator TransformChainBuilder(Matrix4x4 transform)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new TransformChainBuilder(transform);
	}

	public TransformChainBuilder(AffineTransform transform)
	{
		_ParentTransform = null;
		_ChildTransform = transform;
	}

	public TransformChainBuilder(NodeBuilder node)
	{
		_ParentTransform = node;
		_ChildTransform = null;
	}

	public TransformChainBuilder(NodeBuilder parent, AffineTransform child)
	{
		_ParentTransform = parent;
		_ChildTransform = child;
	}
}
