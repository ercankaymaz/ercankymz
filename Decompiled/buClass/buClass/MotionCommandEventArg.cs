using System.Collections.Generic;

namespace buClass;

public class MotionCommandEventArg
{
	public MotionCommands Command = MotionCommands.None;

	public string Message = "";

	public double Val = 0.0;

	public List<string> ErrorList = new List<string>();

	public MotionCommandEventArg()
	{
	}

	public MotionCommandEventArg(MotionCommands cmd, string message, double val)
	{
		Command = cmd;
		Message = message;
		Val = val;
	}

	public override string ToString()
	{
		return "Command =  " + Command.ToString() + " - " + Message;
	}
}
