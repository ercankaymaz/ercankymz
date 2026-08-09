using devDept.Geometry;

namespace devDept.Eyeshot.Entities;

public struct HitTriangle(Point3D intPoint, int triangleIndex, int faceIndex, int shellOrElementIndex)
{
	public readonly Point3D IntersectionPoint = intPoint;

	public readonly int TriangleIndex = triangleIndex;

	public readonly int FaceIndex = faceIndex;

	public readonly int ShellOrElementIndex = shellOrElementIndex;
}
