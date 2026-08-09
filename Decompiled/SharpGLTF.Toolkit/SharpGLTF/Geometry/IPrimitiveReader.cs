using System;
using System.Collections.Generic;

namespace SharpGLTF.Geometry;

public interface IPrimitiveReader<TMaterial>
{
	Type VertexType { get; }

	TMaterial Material { get; }

	int VerticesPerPrimitive { get; }

	IReadOnlyList<IVertexBuilder> Vertices { get; }

	IReadOnlyList<IPrimitiveMorphTargetReader> MorphTargets { get; }

	IReadOnlyList<int> Points { get; }

	IReadOnlyList<(int A, int B)> Lines { get; }

	IReadOnlyList<(int A, int B, int C)> Triangles { get; }

	IReadOnlyList<(int A, int B, int C, int? D)> Surfaces { get; }

	IReadOnlyList<int> GetIndices();
}
