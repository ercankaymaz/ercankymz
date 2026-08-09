using System;
using System.Collections.Generic;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
internal class ShapeSymbol : ICloneable
{
	public char Symbol { get; private set; }

	public int LengthInStream { get; private set; }

	public string Name { get; set; }

	public ShapeFile Owner { get; internal set; }

	public List<ShapeSymbolComponent> Items { get; set; }

	public ShapeSymbol(uint aSymbol, int aLengthInStream, ShapeFile aOwner)
	{
		Symbol = (char)aSymbol;
		LengthInStream = aLengthInStream;
		Owner = aOwner;
		Items = new List<ShapeSymbolComponent>();
	}

	protected ShapeSymbol(ShapeSymbol another)
		: this(another.Symbol, another.LengthInStream, null)
	{
		foreach (ShapeSymbolComponent item in another.Items)
		{
			if (item is ShapeSymbolRegularLine)
			{
				Items.Add((ShapeSymbolRegularLine)item.Clone());
			}
			else if (item is ShapeSymbolComponentWithParams)
			{
				Items.Add((ShapeSymbolComponentWithParams)item.Clone());
			}
			else
			{
				Items.Add((ShapeSymbolComponent)item.Clone());
			}
		}
	}

	public object Clone()
	{
		return new ShapeSymbol(this);
	}

	public virtual ShapeSymbolSurrogate ConvertToSurrogate()
	{
		return new ShapeSymbolSurrogate(this);
	}
}
