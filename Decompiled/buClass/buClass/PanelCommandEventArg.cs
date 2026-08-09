namespace buClass;

public class PanelCommandEventArg
{
	public PanelCommandType Command = PanelCommandType.None;

	public double Value = 0.0;

	public override string ToString()
	{
		return "Cmd : " + Command.ToString() + " , Value: " + Value;
	}
}
