using System;
using System.Diagnostics;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF.Runtime;

internal class RigidDrawableTemplate : DrawableTemplate
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _NodeIndex;

	internal RigidDrawableTemplate(Node node, Func<Node, int> indexFunc)
		: base(node)
	{
		_NodeIndex = indexFunc(node);
	}

	public override IGeometryTransform CreateGeometryTransform()
	{
		return new RigidTransform();
	}

	public override void UpdateGeometryTransform(IGeometryTransform rigidTransform, ArmatureInstance armature)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		NodeInstance nodeInstance = armature.LogicalNodes[_NodeIndex];
		RigidTransform rigidTransform2 = (RigidTransform)rigidTransform;
		rigidTransform2.Update(nodeInstance.ModelMatrix);
		rigidTransform2.Update(nodeInstance.MorphWeights, false);
	}
}
