using devDept.Geometry;

namespace devDept.Eyeshot;

public interface IRotateSettings
{
	rotationType RotationMode { get; set; }

	rotationCenterType RotationCenter { get; set; }

	Point3D Center { get; set; }
}
