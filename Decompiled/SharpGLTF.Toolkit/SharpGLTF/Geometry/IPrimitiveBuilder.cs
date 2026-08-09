using System;
using SharpGLTF.Geometry.VertexTypes;

namespace SharpGLTF.Geometry;

public interface IPrimitiveBuilder
{
	Type VertexType { get; }

	Func<IVertexBuilder> VertexFactory { get; }

	void SetVertexDelta(int morphTargetIndex, int vertexIndex, VertexGeometryDelta geometryDelta, VertexMaterialDelta materialDelta);

	int AddPoint(IVertexBuilder a);

	(int A, int B) AddLine(IVertexBuilder a, IVertexBuilder b);

	(int A, int B, int C) AddTriangle(IVertexBuilder a, IVertexBuilder b, IVertexBuilder c);

	(int A, int B, int C, int D) AddQuadrangle(IVertexBuilder a, IVertexBuilder b, IVertexBuilder c, IVertexBuilder d);
}
