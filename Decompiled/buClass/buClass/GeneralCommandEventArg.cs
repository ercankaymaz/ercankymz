namespace buClass;

public class GeneralCommandEventArg
{
	public string strCommand = "";

	public double valueCommandDouble = 0.0;

	public int valueCommandInt = 0;

	public object valueObject = null;

	public GeneralCommandEventArg()
	{
	}

	public GeneralCommandEventArg(string strCmd)
	{
		strCommand = strCmd;
	}

	public override string ToString()
	{
		return "Cmd : " + strCommand.ToString();
	}
}
