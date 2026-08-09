using System;

namespace buClass;

public class ApplicationErrorEventArg
{
	public bool ShowMessageBox = false;

	public string Job = "";

	public string SubJob = "";

	public int ID = 0;

	public string Method = "";

	public string Message = "";

	public string Status = "";

	public Exception Exceptions = null;

	public ApplicationErrorEventArg()
	{
	}

	public ApplicationErrorEventArg(string method, string job, string subjob, int id)
	{
		Job = job;
		SubJob = subjob;
		ID = id;
		Method = method;
	}

	public ApplicationErrorEventArg(bool showmessage, string method, string message, string status, string job, string subjob, int id, Exception ee)
	{
		ShowMessageBox = showmessage;
		Job = job;
		SubJob = subjob;
		ID = id;
		Method = method;
		Message = message;
		Exceptions = ee;
		Status = status;
	}

	public override string ToString()
	{
		return Method + " = [ " + Job + " - " + SubJob + " ]  , ID : " + ID + " - Mes: " + Message;
	}
}
