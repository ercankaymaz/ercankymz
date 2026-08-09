namespace buClass;

public class DebugCommandEventArg
{
	public string DebugCommand = "";

	public bool PasswordChar = false;

	public override string ToString()
	{
		return "Cmd : " + DebugCommand.ToString();
	}
}
