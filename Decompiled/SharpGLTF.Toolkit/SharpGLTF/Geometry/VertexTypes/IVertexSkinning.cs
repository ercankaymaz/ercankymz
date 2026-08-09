using System.Numerics;
using SharpGLTF.Transforms;

namespace SharpGLTF.Geometry.VertexTypes;

public interface IVertexSkinning : IVertexReflection
{
	int MaxBindings { get; }

	Vector4 JointsLow { get; }

	Vector4 JointsHigh { get; }

	Vector4 WeightsLow { get; }

	Vector4 WeightsHigh { get; }

	(int Index, float Weight) GetBinding(int index);

	void SetBindings(in SparseWeight8 bindings);

	void SetBindings(params (int Index, float Weight)[] bindings);

	SparseWeight8 GetBindings();
}
