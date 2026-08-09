using System;
using System.Collections.Generic;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
internal class ShapeFile : ICloneable
{
	public string FileName { get; set; }

	public Dictionary<char, ShapeSymbol> Shapes { get; internal set; }

	public ShapeFileType ShapeFileType { get; set; }

	public ShapeFile(string aFileName)
	{
		FileName = aFileName;
		Shapes = new Dictionary<char, ShapeSymbol>();
	}

	protected ShapeFile(ShapeFile another)
		: this(another.FileName)
	{
		foreach (KeyValuePair<char, ShapeSymbol> shape in another.Shapes)
		{
			ShapeSymbol shapeSymbol = (ShapeSymbol)shape.Value.Clone();
			shapeSymbol.Owner = this;
			Shapes.Add(shape.Key, shapeSymbol);
		}
	}

	public void Add(ShapeSymbol aShape)
	{
		Shapes.Add(aShape.Symbol, aShape);
	}

	public object Clone()
	{
		return new ShapeFile(this);
	}

	public virtual ShapeFileSurrogate ConvertToSurrogate()
	{
		return new ShapeFileSurrogate(this);
	}
}
