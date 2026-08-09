using System;

namespace buClass;

[Serializable]
public class DrawSource : buSerilization
{
	public ViewportDrawingType Type = ViewportDrawingType.Cad;

	public int Index = 0;

	public int ID = 0;

	public DrawSource()
	{
	}

	public DrawSource(ViewportDrawingType type)
	{
		Type = type;
	}

	public DrawSource(DrawSource source)
	{
		Type = source.Type;
		Index = source.Index;
		ID = source.ID;
	}

	public DrawSource(ViewportDrawingType type, int index)
	{
		Type = type;
		Index = index;
	}

	public DrawSource(ViewportDrawingType type, int index, int id)
	{
		Type = type;
		Index = index;
		ID = id;
	}

	public override string ToString()
	{
		return Type.ToString() + " , Index : " + Index + " , ID : " + ID;
	}
}
