using devDept.Eyeshot;

namespace devDept.Serialization;

internal class ShapeSymbolComponentWithParamsSurrogate : ShapeSymbolComponentSurrogate
{
	public int[] Params;

	public ShapeSymbolComponentWithParamsSurrogate(ShapeSymbolComponentWithParams sscwp)
		: base(sscwp)
	{
	}

	protected override ShapeSymbolComponent ConvertToObject()
	{
		return new ShapeSymbolComponentWithParams((ShapeCommand)Command, Params);
	}

	protected override void CopyDataFromObject(ShapeSymbolComponent ssc)
	{
		ShapeSymbolComponentWithParams shapeSymbolComponentWithParams = ssc as ShapeSymbolComponentWithParams;
		Params = shapeSymbolComponentWithParams.Params;
		base.CopyDataFromObject(ssc);
	}
}
