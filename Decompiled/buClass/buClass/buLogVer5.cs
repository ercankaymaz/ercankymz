using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace buClass;

public class buLogVer5
{
	public static int cntLog = 0;

	public static List<string> logList = new List<string>();

	public string Message = null;

	public string Command = "";

	public string Method = "";

	public string Data = null;

	public double ID = 0.0;

	public double Value = 0.0;

	public DateTime Time = default(DateTime);

	public buLogVer5()
	{
	}

	public buLogVer5(buLogVer5 log)
	{
		Message = log.Message;
		Data = log.Data;
		ID = log.ID;
		Time = log.Time;
		Command = log.Command;
		Method = log.Method;
		Value = log.Value;
	}

	public buLogVer5(string command, string method, string message, string data, double id, double value)
	{
		Command = command;
		Message = message;
		Method = method;
		Data = data;
		ID = id;
		Value = value;
		Time = DateTime.Now;
	}

	public static void checkLogFileSize()
	{
		try
		{
			if (AppBool.CheckingLogSize)
			{
				return;
			}
			AppBool.CheckingLogSize = true;
			FileInfo fileInfo = new FileInfo(buSystem.fileNameLog);
			if (fileInfo.Exists)
			{
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
					TextWriter textWriter = File.CreateText(buSystem.fileNameLog);
					for (int i = 0; i <= list.Count - 1; i++)
					{
						textWriter.WriteLine(list[i].ToString());
					}
					textWriter.Close();
				}
			}
			fileInfo = new FileInfo(buSystem.fileNameExceptionLog);
			if (fileInfo.Exists)
			{
				int num4 = 2048;
				int num5 = 20;
				if (fileInfo.Length > Convert.ToInt32(num4 * 1024))
				{
					List<string> list2 = new List<string>();
					string text2 = "";
					TextReader textReader2 = File.OpenText(buSystem.fileNameExceptionLog);
					while ((text2 = textReader2.ReadLine()) != null)
					{
						list2.Add(text2);
					}
					textReader2.Close();
					int num6 = Convert.ToInt32(list2.Count * num5 / 100);
					list2.Reverse();
					list2.RemoveRange(num6, list2.Count - num6);
					list2.Reverse();
					TextWriter textWriter2 = File.CreateText(buSystem.fileNameExceptionLog);
					for (int j = 0; j <= list2.Count - 1; j++)
					{
						textWriter2.WriteLine(list2[j].ToString());
					}
					textWriter2.Close();
				}
			}
			AppBool.CheckingLogSize = false;
		}
		catch (Exception)
		{
			AppBool.CheckingLogSize = false;
		}
	}

	public static string LogToString(string strClass, string method, string command, string message = "", string data = "", double id = 0.0, double value = 0.0)
	{
		try
		{
			return DateTime.Now.ToLocalTime().ToString("MM-dd-yyyy HH:mm:ss") + " ; " + strClass + " ; " + method + " ; " + command + " ; " + message + " ; " + data + " ; " + value + " ; " + id + Environment.NewLine;
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static void addToLog(ref List<string> loglist)
	{
		try
		{
			if (!(AppBool.SavingLog | AppBool.CheckingLogSize))
			{
				AppBool.SavingLog = true;
				buSystem.fileNameLog = Application.StartupPath + "\\buLog5.csv";
				TextWriter textWriter = File.AppendText(buSystem.fileNameLog);
				for (int i = 0; i <= loglist.Count - 1; i++)
				{
					textWriter.Write(loglist[i]);
					cntLog++;
				}
				textWriter.Close();
				loglist.Clear();
				AppBool.SavingLog = false;
			}
		}
		catch (Exception)
		{
			AppBool.SavingLog = false;
		}
	}

	public static void addToList(string strClass, string method, string command, string message = "", string data = "", double id = 0.0, double value = 0.0)
	{
		try
		{
			logList.Add(LogToString(strClass, method, command, message, data, id, value));
		}
		catch (Exception)
		{
		}
	}

	public static void addToLog(string strClass, string method, string command, string message = "", string data = "", double id = 0.0, double value = 0.0, bool AddException = false)
	{
		try
		{
			if (!(AppBool.SavingLog | AppBool.CheckingLogSize))
			{
				AppBool.SavingLog = true;
				string value2 = LogToString(strClass, method, command, message, data, id, value);
				buSystem.fileNameLog = Application.StartupPath + "\\buLog5.csv";
				TextWriter textWriter = File.AppendText(buSystem.fileNameLog);
				textWriter.Write(value2);
				textWriter.Close();
				if (AddException)
				{
					addToLogException(strClass, method, command, "Exception", data, id, value);
				}
				cntLog++;
				AppBool.SavingLog = false;
			}
		}
		catch (Exception)
		{
			AppBool.SavingLog = false;
		}
	}

	public static void addToLog(string method, string command, string message, string data, double id, double value, bool AddException = false)
	{
		try
		{
			if (!(AppBool.SavingLog | AppBool.CheckingLogSize))
			{
				AppBool.SavingLog = true;
				string value2 = LogToString("", method, command, message, data, id, value);
				buSystem.fileNameLog = Application.StartupPath + "\\buLog5.csv";
				TextWriter textWriter = File.AppendText(buSystem.fileNameLog);
				textWriter.Write(value2);
				textWriter.Close();
				if (AddException)
				{
					addToLogException("", method, command, "Exception", data, id, value);
				}
				cntLog++;
				AppBool.SavingLog = false;
			}
		}
		catch (Exception)
		{
			AppBool.SavingLog = false;
		}
	}

	public static void addToLogException(string strClass, string method, string command, string message = "Exception", string data = "", double id = 0.0, double value = 0.0)
	{
		try
		{
			if (!(AppBool.SavingExceptionLog | AppBool.CheckingLogSize))
			{
				AppBool.SavingExceptionLog = true;
				string value2 = DateTime.Now.ToLocalTime().ToString() + " ; " + strClass + " ; " + method + " ; " + command + " ; " + message + " ; " + data + " ; " + value + " ; " + id + Environment.NewLine;
				buSystem.fileNameLog = Application.StartupPath + "\\buLogException5.csv";
				TextWriter textWriter = File.AppendText(buSystem.fileNameLog);
				textWriter.Write(value2);
				textWriter.Close();
				AppBool.SavingExceptionLog = false;
			}
		}
		catch (Exception)
		{
			AppBool.SavingExceptionLog = false;
		}
	}

	public override string ToString()
	{
		return Time.ToString("HH:mm:ss") + " - Method : " + Method + " - Cmd : " + Command + " - Msg : " + Message;
	}
}
