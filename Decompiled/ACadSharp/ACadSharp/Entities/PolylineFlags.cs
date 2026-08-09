using System;

namespace ACadSharp.Entities;

[Flags]
public enum PolylineFlags
{
	Default = 0,
	ClosedPolylineOrClosedPolygonMeshInM = 1,
	CurveFit = 2,
	SplineFit = 4,
	Polyline3D = 8,
	PolygonMesh = 0x10,
	ClosedPolygonMeshInN = 0x20,
	PolyfaceMesh = 0x40,
	ContinuousLinetypePattern = 0x80
}
