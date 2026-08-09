using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace buClass;

public class buLog
{
	public static List<buLog> LastLogs = new List<buLog>();

	public string Message = null;

	public string Command = "";

	public string CallMethod = "";

	public string Status = "";

	public string ParStr2 = null;

	public double ParVal1 = 0.0;

	public double ID = 0.0;

	public DateTime Time = default(DateTime);

	public buLog()
	{
	}

	public buLog(buLog log)
	{
		Message = log.Message;
		Status = log.Status;
		ParStr2 = log.ParStr2;
		ParVal1 = log.ParVal1;
		ID = log.ID;
		Time = log.Time;
		Command = log.Command;
		CallMethod = log.CallMethod;
	}

	public buLog(string Command, string CallMethod, DateTime time)
	{
		this.Command = Command;
		Message = null;
		Status = null;
		ParStr2 = null;
		ParVal1 = 0.0;
		ID = 0.0;
		Time = time;
	}

	public buLog(string Command, string CallMethod, string Message)
	{
		this.Command = Command;
		this.Message = Message;
		Status = null;
		ParStr2 = null;
		ParVal1 = 0.0;
		ID = 0.0;
		Time = DateTime.Now;
	}

	public buLog(string Command, string CallMethod, string Message, string status, double id)
	{
		this.Command = Command;
		this.Message = Message;
		Status = status;
		ParStr2 = null;
		ParVal1 = 0.0;
		ID = id;
		Time = DateTime.Now;
	}

	public buLog(string Command, string CallMethod, string Message, string ParStr1, string ParStr2, double ParVal1, double ParVal2)
	{
		this.Message = Message;
		this.Command = Command;
		this.CallMethod = CallMethod;
		Status = ParStr1;
		this.ParStr2 = ParStr2;
		this.ParVal1 = ParVal1;
		ID = ParVal2;
		Time = DateTime.Now;
	}

	public buLog(string Command, string CallMethod, string Message, string ParStr1, string ParStr2, double ParVal1, double ParVal2, DateTime time)
	{
		this.Message = Message;
		this.Command = Command;
		this.CallMethod = CallMethod;
		Status = ParStr1;
		this.ParStr2 = ParStr2;
		this.ParVal1 = ParVal1;
		ID = ParVal2;
		Time = time;
	}

	public static void addLog(string Command)
	{
		buLog log = new buLog(Command, "No Method", "No Message");
		addLog(log, "");
	}

	public static void addLog(string Command, string Message, string callMethod)
	{
		buLog log = new buLog(Command, callMethod, Message);
		addLog(log, callMethod);
	}

	public static void addLog(string Command, string Message, string callMethod, string ParStr1, string ParStr2, double ParVal1, double ParVal2)
	{
		buLog log = new buLog(Command, callMethod, Message, ParStr1, ParStr1, ParVal1, ParVal2);
		addLog(log, callMethod);
	}

	public static void addLog(CalculationErrorEventArg CalcError)
	{
		buLog log = new buLog("", CalcError.Method, CalcError.Message, CalcError.Status, CalcError.ID);
		addLog(log, CalcError.Method);
	}

	public static void addLog(string command, string message, string method, string status, int id)
	{
		buLog log = new buLog(command, method, message, status, id);
		addLog(log, method);
	}

	public static void addLog(buLog log, string callMethod)
	{
		try
		{
			bool flag = false;
			string value = DateTime.Now.ToLongDateString() + " ; " + DateTime.Now.ToLocalTime().ToString() + " ; Method : " + callMethod + "  ;  Command : " + buStatics.StringToSting(log.Command) + "  ;  Message : " + buStatics.StringToSting(log.Message) + "  ;  Par Str1 : " + buStatics.StringToSting(log.Status) + "  ;  ParStr2: " + buStatics.StringToSting(log.ParStr2) + "  ;  ParVal1: " + buStatics.StringToSting(log.ParVal1.ToString()) + "  ;  ParVal2: " + buStatics.StringToSting(log.ID.ToString()) + Environment.NewLine;
			buLog buLog2 = new buLog(log);
			buLog2.CallMethod = callMethod;
			LastLogs.Add(buLog2);
			if (LastLogs.Count > 3 && LastLogs[LastLogs.Count - 1].Message.Trim().ToLower() == callMethod.Trim().ToLower() && LastLogs[LastLogs.Count - 2].Message.Trim().ToLower() == callMethod.Trim().ToLower())
			{
				flag = true;
			}
			if (!flag)
			{
				TextWriter textWriter = File.AppendText(buSystem.fileNameLog);
				textWriter.Write(value);
				textWriter.Close();
			}
			if (LastLogs.Count > 100)
			{
				LastLogs.RemoveRange(0, LastLogs.Count - 50);
			}
			FileInfo fileInfo = new FileInfo(buSystem.fileNameLog);
			if (!fileInfo.Exists)
			{
				return;
			}
			int num = 2048;
			int num2 = 20;
			if (fileInfo.Length > Convert.ToInt32(num * 1024))
			{
				List<string> list = new List<string>();
				string text = "";
				TextReader textReader = File.OpenText(buSystem.fileNameLog);
				while ((text = textReader.ReadLine()) != null)
				{
					list.Add(text);
				}
				textReader.Close();
				int num3 = Convert.ToInt32(list.Count * num2 / 100);
				list.Reverse();
				list.RemoveRange(num3, list.Count - num3);
				list.Reverse();
				TextWriter textWriter2 = File.CreateText(buSystem.fileNameLog);
				for (int i = 0; i <= list.Count - 1; i++)
				{
					textWriter2.WriteLine(list[i].ToString());
				}
				textWriter2.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	public static void addLog(Exception ex, string Note)
	{
		try
		{
			string value = "Line No : " + ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7) + Environment.NewLine;
			string value2 = "Error Message: " + ex.GetType().Name.ToString() + Environment.NewLine;
			string value3 = "Error Type : " + ex.GetType().ToString() + Environment.NewLine;
			string value4 = "Error Location : " + ex.Message.ToString() + Environment.NewLine;
			string value5 = "Error Note : " + Note;
			string fileName = Application.StartupPath + "\\Error" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + DateTime.Now.Millisecond + ".instalog";
			FileInfo fileInfo = new FileInfo(fileName);
			if (!fileInfo.Exists)
			{
				TextWriter textWriter = File.CreateText(fileInfo.FullName);
				textWriter.Write(value);
				textWriter.Write(value2);
				textWriter.Write(value3);
				textWriter.Write(value4);
				textWriter.Write(value5);
				textWriter.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	public override string ToString()
	{
		return Time.ToShortTimeString() + " - Call : " + CallMethod + " - Cmd : " + Command;
	}
}
