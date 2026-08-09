using System;

namespace ACadSharp.Entities;

[Flags]
public enum VertexFlags
{
	Default = 0,
	CurveFittingExtraVertex = 1,
	CurveFitTangent = 2,
	NotUsed = 4,
	SplineVertexFromSplineFitting = 8,
	SplineFrameControlPoint = 0x10,
	PolylineVertex3D = 0x20,
	PolygonMesh3D = 0x40,
	PolyfaceMeshVertex = 0x80
}
