using System.Collections.Generic;

namespace SharpGLTF.Transforms;

public interface IGeometryInstancing
{
	int InstancesCount { get; }

	IReadOnlyList<RigidTransform> WorldTransforms { get; }
}
