using devDept.Eyeshot;

namespace devDept.Serialization;

internal class ShapeSymbolComponentSurrogate : Surrogate<ShapeSymbolComponent>
{
	public byte Command;

	public ShapeSymbolComponentSurrogate(ShapeSymbolComponent ssc)
		: base(ssc)
	{
	}

	protected override ShapeSymbolComponent ConvertToObject()
	{
		return new ShapeSymbolComponent((ShapeCommand)Command);
	}

	protected override void CopyDataToObject(ShapeSymbolComponent obj)
	{
	}

	protected override void CopyDataFromObject(ShapeSymbolComponent ssc)
	{
		Command = (byte)ssc.Command;
	}

	public static implicit operator ShapeSymbolComponent(ShapeSymbolComponentSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator ShapeSymbolComponentSurrogate(ShapeSymbolComponent source)
	{
		return source?.ConvertToSurrogate();
	}
}
