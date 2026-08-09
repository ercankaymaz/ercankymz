using System.Collections.Generic;
using devDept.Eyeshot;

namespace devDept.Serialization;

internal class ShapeFileSurrogate : Surrogate<ShapeFile>
{
	public string FileName;

	public Dictionary<char, ShapeSymbol> Shapes;

	public byte ShapeFileType;

	public ShapeFileSurrogate(ShapeFile sf)
		: base(sf)
	{
	}

	protected override ShapeFile ConvertToObject()
	{
		ShapeFile shapeFile = new ShapeFile(FileName);
		CopyDataToObject(shapeFile);
		return shapeFile;
	}

	protected override void CopyDataToObject(ShapeFile sf)
	{
		sf.Shapes = Shapes;
		sf.ShapeFileType = (ShapeFileType)ShapeFileType;
		foreach (KeyValuePair<char, ShapeSymbol> shape in sf.Shapes)
		{
			shape.Value.Owner = sf;
		}
	}

	protected override void CopyDataFromObject(ShapeFile sf)
	{
		FileName = sf.FileName;
		Shapes = sf.Shapes;
		ShapeFileType = (byte)sf.ShapeFileType;
	}

	public static implicit operator ShapeFile(ShapeFileSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator ShapeFileSurrogate(ShapeFile source)
	{
		return source?.ConvertToSurrogate();
	}
}
