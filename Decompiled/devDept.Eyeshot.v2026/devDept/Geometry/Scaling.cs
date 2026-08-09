using System;
using System.Runtime.Serialization;

namespace devDept.Geometry;

[Serializable]
[Obsolete("Use Transformation.CreateScaling() instead.")]
public class Scaling : Transformation
{
	public Scaling(double factor)
	{
		Scaling(factor, factor, factor);
	}

	public Scaling(double sx, double sy, double sz = 1.0)
	{
		Scaling(sx, sy, sz);
	}

	public Scaling(Vector3D sv)
	{
		Scaling(sv);
	}

	public Scaling(Point3D fixedPoint, double factor)
	{
		Scaling(fixedPoint, factor);
	}

	public Scaling(Point3D fixedPoint, double sx, double sy, double sz = 1.0)
	{
		Scaling(fixedPoint, sx, sy, sz);
	}

	protected Scaling(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public new void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
	}
}
