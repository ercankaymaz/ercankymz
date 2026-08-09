using System.Collections.Generic;
using System.Numerics;
using SharpGLTF.Geometry.VertexTypes;

namespace SharpGLTF.Geometry;

public interface IMorphTargetBuilder
{
	IReadOnlyCollection<Vector3> Positions { get; }

	IReadOnlyCollection<IVertexGeometry> Vertices { get; }

	IReadOnlyList<IVertexGeometry> GetVertices(Vector3 position);

	void SetVertex(IVertexGeometry meshVertex, IVertexGeometry morphVertex);

	void SetVertex(IVertexGeometry meshVertex, IVertexGeometry morphVertex, IVertexMaterial morphMaterial);

	void SetVertexDelta(IVertexGeometry meshVertex, VertexGeometryDelta geometryDelta);

	void SetVertexDelta(IVertexGeometry meshVertex, VertexGeometryDelta geometryDelta, VertexMaterialDelta materialDelta);

	void SetVertexDelta(Vector3 meshPosition, VertexGeometryDelta geometryDelta);

	void SetVertexDelta(Vector3 meshPosition, VertexGeometryDelta geometryDelta, VertexMaterialDelta materialDelta);
}
