namespace Xbim.Common.Geometry;

public enum XbimGeometryType : byte
{
	Undefined,
	BoundingBox,
	MultipleBoundingBox,
	TriangulatedMesh,
	Region,
	TransformOnly,
	TriangulatedMeshHash,
	Polyhedron,
	TriangulatedPolyhedron,
	PolyhedronBinary
}
