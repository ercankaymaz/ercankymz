using System.Collections.Generic;
using System.Numerics;

namespace SharpGLTF.Transforms;

public interface IGeometryTransform
{
	bool Visible { get; }

	bool FlipFaces { get; }

	Vector3 TransformPosition(Vector3 localPosition, IReadOnlyList<Vector3> positionDeltas, in SparseWeight8 skinWeights);

	Vector3 TransformNormal(Vector3 localNormal, IReadOnlyList<Vector3> normalDeltas, in SparseWeight8 skinWeights);

	Vector4 TransformTangent(Vector4 tangent, IReadOnlyList<Vector3> tangentDeltas, in SparseWeight8 skinWeights);
}
