using System.Collections.Generic;
using System.Numerics;
using SharpGLTF.Transforms;

namespace SharpGLTF.Runtime;

public interface IMeshPrimitiveDecoder
{
	int VertexCount { get; }

	int MorphTargetsCount { get; }

	int ColorsCount { get; }

	int TexCoordsCount { get; }

	int JointsWeightsCount { get; }

	IEnumerable<(int A, int B)> LineIndices { get; }

	IEnumerable<(int A, int B, int C)> TriangleIndices { get; }

	Vector3 GetPosition(int vertexIndex);

	Vector3 GetNormal(int vertexIndex);

	Vector4 GetTangent(int vertexIndex);

	Vector2 GetTextureCoord(int vertexIndex, int textureSetIndex);

	Vector4 GetColor(int vertexIndex, int colorSetIndex);

	SparseWeight8 GetSkinWeights(int vertexIndex);

	IReadOnlyList<Vector3> GetPositionDeltas(int vertexIndex);

	IReadOnlyList<Vector3> GetNormalDeltas(int vertexIndex);

	IReadOnlyList<Vector3> GetTangentDeltas(int vertexIndex);

	IReadOnlyList<Vector2> GetTextureCoordDeltas(int vertexIndex, int textureSetIndex);

	IReadOnlyList<Vector4> GetColorDeltas(int vertexIndex, int colorSetIndex);
}
public interface IMeshPrimitiveDecoder<TMaterial> : IMeshPrimitiveDecoder where TMaterial : class
{
	TMaterial Material { get; }
}
