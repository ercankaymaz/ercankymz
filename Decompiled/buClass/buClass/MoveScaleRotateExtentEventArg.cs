namespace buClass;

public class MoveScaleRotateExtentEventArg
{
	public MoveScaleRotateStretchVar Data = new MoveScaleRotateStretchVar();

	public MoveScaleRotateStretchType Type = MoveScaleRotateStretchType.StretchXMinus;

	public override string ToString()
	{
		return "Type : " + Type;
	}
}
