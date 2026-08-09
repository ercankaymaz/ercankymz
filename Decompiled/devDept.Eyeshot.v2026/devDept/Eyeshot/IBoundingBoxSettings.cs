using devDept.Geometry;

namespace devDept.Eyeshot;

public interface IBoundingBoxSettings
{
	Point3D Min { get; }

	Point3D Max { get; }
}
