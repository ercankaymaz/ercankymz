using System;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
internal class ShapeSymbolRegularLine : ShapeSymbolComponent, ICloneable
{
	public int Direction { get; private set; }

	public int Length { get; private set; }

	public ShapeSymbolRegularLine(int aDirection, int aLength)
		: base(ShapeCommand.RegularLine)
	{
		Direction = aDirection;
		Length = aLength;
	}

	protected ShapeSymbolRegularLine(ShapeSymbolRegularLine another)
		: this(another.Direction, another.Length)
	{
		base.Command = another.Command;
	}

	public override object Clone()
	{
		return new ShapeSymbolRegularLine(this);
	}

	public override ShapeSymbolComponentSurrogate ConvertToSurrogate()
	{
		return new ShapeSymbolRegularLineSurrogate(this);
	}
}
