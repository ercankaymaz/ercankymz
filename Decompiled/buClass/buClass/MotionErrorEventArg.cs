using System;

namespace buClass;

public class MotionErrorEventArg
{
	public bool ShowMessageBox = false;

	public string Command = "";

	public string SubCommand = "";

	public int ID = 0;

	public string Method = "";

	public string Message = "";

	public string Status = "";

	public Exception Exceptions = null;

	public MotionErrorEventArg()
	{
	}

	public MotionErrorEventArg(string method, string cmd, string subcmd, int id)
	{
		Command = cmd;
		SubCommand = subcmd;
		ID = id;
		Method = method;
	}

	public MotionErrorEventArg(bool showmessage, string method, string message, string status, string cmd, string subcmd, int id, Exception ee)
	{
		ShowMessageBox = showmessage;
		Command = cmd;
		SubCommand = subcmd;
		ID = id;
		Method = method;
		Message = message;
		Exceptions = ee;
		Status = status;
	}

	public override string ToString()
	{
		return Method + " = [ " + Command + " - " + SubCommand + " ]  , ID : " + ID + " - Mes: " + Message;
	}
}
