using devDept.Eyeshot;

namespace devDept.Serialization;

internal class ShapeSymbolRegularLineSurrogate : ShapeSymbolComponentSurrogate
{
	public int Direction;

	public int Length;

	public ShapeSymbolRegularLineSurrogate(ShapeSymbolRegularLine ssrl)
		: base(ssrl)
	{
	}

	protected override ShapeSymbolComponent ConvertToObject()
	{
		return new ShapeSymbolRegularLine(Direction, Length);
	}

	protected override void CopyDataFromObject(ShapeSymbolComponent ssc)
	{
		ShapeSymbolRegularLine shapeSymbolRegularLine = ssc as ShapeSymbolRegularLine;
		Direction = shapeSymbolRegularLine.Direction;
		Length = shapeSymbolRegularLine.Length;
		base.CopyDataFromObject(ssc);
	}
}
