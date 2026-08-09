using System.Collections.Generic;
using devDept.Eyeshot;

namespace devDept.Serialization;

internal class ShapeSymbolSurrogate : Surrogate<ShapeSymbol>
{
	public char Symbol;

	public int LengthInStream;

	public string Name;

	public List<ShapeSymbolComponent> Items;

	public ShapeSymbolSurrogate(ShapeSymbol ss)
		: base(ss)
	{
	}

	protected override ShapeSymbol ConvertToObject()
	{
		ShapeSymbol shapeSymbol = new ShapeSymbol(Symbol, LengthInStream, null);
		CopyDataToObject(shapeSymbol);
		return shapeSymbol;
	}

	protected override void CopyDataToObject(ShapeSymbol ss)
	{
		ss.Name = Name;
		ss.Items = Items;
	}

	protected override void CopyDataFromObject(ShapeSymbol ss)
	{
		Symbol = ss.Symbol;
		LengthInStream = ss.LengthInStream;
		Name = ss.Name;
		Items = ss.Items;
	}

	public static implicit operator ShapeSymbol(ShapeSymbolSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator ShapeSymbolSurrogate(ShapeSymbol source)
	{
		return source?.ConvertToSurrogate();
	}
}
