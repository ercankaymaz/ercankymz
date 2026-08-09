using System;
using System.Runtime.Serialization;

namespace devDept.Geometry;

[Serializable]
[Obsolete("Use Transformation.CreateTranslation() instead.")]
public class Translation : Transformation
{
	public Translation(double x, double y, double z = 0.0)
	{
		Translation(x, y, z);
	}

	public Translation(Vector3D v)
	{
		Translation(v);
	}

	public Translation(Vector2D v)
	{
		Translation(v.X, v.Y);
	}

	protected Translation(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public new void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
	}
}
