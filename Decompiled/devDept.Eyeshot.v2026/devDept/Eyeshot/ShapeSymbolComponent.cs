using System;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
internal class ShapeSymbolComponent : ICloneable
{
	public ShapeCommand Command { get; internal set; }

	public ShapeSymbolComponent(ShapeCommand aCommand)
	{
		Command = aCommand;
	}

	public ShapeSymbolComponent(ShapeSymbolComponent another)
		: this(another.Command)
	{
	}

	public virtual object Clone()
	{
		return new ShapeSymbolComponent(this);
	}

	public virtual ShapeSymbolComponentSurrogate ConvertToSurrogate()
	{
		return new ShapeSymbolComponentSurrogate(this);
	}
}
