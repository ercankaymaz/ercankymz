using System;
using System.Diagnostics;
using SharpGLTF.Schema2;

namespace SharpGLTF.Scenes;

[DebuggerDisplay("_FixedIntance Node[{_DebugName,nq}] = {Content}")]
internal readonly struct _FixedIntance : Schema2SceneBuilder.IOperator<Scene>
{
	private readonly FixedTransformer _srcChild;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _DebugName => _srcChild?.Name ?? "*";

	public _FixedIntance(FixedTransformer fixedXformer)
	{
		_srcChild = fixedXformer;
	}

	void Schema2SceneBuilder.IOperator<Scene>.ApplyTo(Scene dstScene, Schema2SceneBuilder context)
	{
		if (!(_srcChild.Content is Schema2SceneBuilder.IOperator<Node> obj))
		{
			throw new InvalidOperationException("Operator expected");
		}
		Node node = dstScene.CreateNode();
		node.Name = _srcChild.Name;
		node.Extras = _srcChild.Extras?.DeepClone();
		node.LocalTransform = _srcChild.ChildTransform;
		obj.ApplyTo(node, context);
	}
}
