using CSMath;

namespace ACadSharp.Entities;

public interface IGeometricEntity
{
	void ApplyTransform(Transform transform);

	BoundingBox GetBoundingBox();
}
