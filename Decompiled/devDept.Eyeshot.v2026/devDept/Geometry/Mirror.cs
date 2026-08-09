using System;
using System.Runtime.Serialization;

namespace devDept.Geometry;

[Serializable]
[Obsolete("Use Transformation.CreateReflection() instead.")]
public class Mirror : Transformation
{
	public Mirror(Plane plane)
	{
		Reflection(plane);
	}

	protected Mirror(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public new void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
	}
}
