using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace devDept.Geometry;

[Serializable]
[Obsolete("Use Transformation.CreateIdentity() instead.")]
public class Identity : Transformation
{
	[DebuggerStepThrough]
	public Identity()
		: base(1.0)
	{
	}

	protected Identity(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
