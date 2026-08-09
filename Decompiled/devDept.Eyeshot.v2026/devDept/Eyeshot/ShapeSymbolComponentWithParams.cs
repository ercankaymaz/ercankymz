using System;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
internal class ShapeSymbolComponentWithParams : ShapeSymbolComponent, ICloneable
{
	public int[] Params { get; private set; }

	public ShapeSymbolComponentWithParams(ShapeCommand aCommand, int[] aParams)
		: base(aCommand)
	{
		Params = aParams;
	}

	protected ShapeSymbolComponentWithParams(ShapeSymbolComponentWithParams another)
		: this(another.Command, another.Params)
	{
	}

	public override object Clone()
	{
		return new ShapeSymbolComponentWithParams(this);
	}

	public override ShapeSymbolComponentSurrogate ConvertToSurrogate()
	{
		return new ShapeSymbolComponentWithParamsSurrogate(this);
	}
}
