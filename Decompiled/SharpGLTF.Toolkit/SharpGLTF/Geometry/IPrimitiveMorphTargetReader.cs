using System.Collections.Generic;
using SharpGLTF.Geometry.VertexTypes;

namespace SharpGLTF.Geometry;

public interface IPrimitiveMorphTargetReader
{
	IReadOnlyCollection<int> GetTargetIndices();

	IVertexBuilder GetVertex(int vertexIndex);

	VertexBuilder<VertexGeometryDelta, VertexMaterialDelta, VertexEmpty> GetVertexDelta(int vertexIndex);
}
