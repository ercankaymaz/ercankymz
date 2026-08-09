using System;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

[Serializable]
public class Ole2Frame : Picture
{
	public Ole2Frame(Plane plane, double width, double height, byte[] image)
		: base(plane, width, height, image)
	{
		base.Lighted = false;
	}

	protected Ole2Frame(Ole2Frame another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
	}

	protected Ole2Frame(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	protected internal Ole2Frame(Ole2FrameSurrogate surrogate)
		: this(surrogate.Plane, surrogate.Width, surrogate.Height, surrogate.Image?.Data)
	{
	}

	public override object Clone()
	{
		return new Ole2Frame(this);
	}

	public override object CloneWithTessellation()
	{
		return new Ole2Frame(this, RegenMode != regenType.RegenAndCompile);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new Ole2FrameSurrogate(this);
	}
}
