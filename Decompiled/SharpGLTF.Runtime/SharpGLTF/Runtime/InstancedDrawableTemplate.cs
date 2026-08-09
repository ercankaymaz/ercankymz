using System;
using System.Collections.Generic;
using System.Diagnostics;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF.Runtime;

internal class InstancedDrawableTemplate : RigidDrawableTemplate
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly AffineTransform[] _Instances;

	public IReadOnlyList<AffineTransform> Instances => _Instances;

	internal InstancedDrawableTemplate(Node node, Func<Node, int> indexFunc)
		: base(node, indexFunc)
	{
		MeshGpuInstancing gpuInstancing = node.GetGpuInstancing();
		_Instances = new AffineTransform[gpuInstancing.Count];
		for (int i = 0; i < _Instances.Length; i++)
		{
			_Instances[i] = gpuInstancing.GetLocalTransform(i);
		}
	}

	public override IGeometryTransform CreateGeometryTransform()
	{
		return new InstancingTransform(_Instances);
	}

	public override void UpdateGeometryTransform(IGeometryTransform rigidTransform, ArmatureInstance armature)
	{
		base.UpdateGeometryTransform(rigidTransform, armature);
		(rigidTransform as InstancingTransform).UpdateInstances();
	}
}
