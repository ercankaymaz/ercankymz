using System;
using System.Runtime.Serialization;

namespace devDept.Geometry;

[Serializable]
[Obsolete("Use Transformation.CreateAlignment() instead.")]
public class Align3D : Transformation
{
	public Align3D(Plane originalFrame, Plane destinationFrame)
	{
		Rotation(originalFrame, destinationFrame);
	}

	public Align3D(Point3D p1A, Point3D p1B, Point3D p2A, Point3D p2B, Point3D p3A, Point3D p3B)
	{
		Plane plane = new Plane(p1A, p2A, p3A);
		Plane plane2 = new Plane(p1B, p2B, p3B);
		Rotation(plane, plane2);
	}

	protected Align3D(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public new void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
	}
}
