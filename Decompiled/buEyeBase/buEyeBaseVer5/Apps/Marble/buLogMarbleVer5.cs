using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class buLogMarbleVer5
{
	public string Message = null;

	public string Command = "";

	public string Method = "";

	public string Data = null;

	public string BaseClass = null;

	public double ID = 0.0;

	public double Value = 0.0;

	public DateTime Time = default(DateTime);

	public static List<string> LogList;

	public buLogMarbleVer5()
	{
	}

	public buLogMarbleVer5(buLogMarbleVer5 log)
	{
		Message = log.Message;
		Data = log.Data;
		ID = log.ID;
		Time = log.Time;
		Command = log.Command;
		Method = log.Method;
		Value = log.Value;
	}

	public buLogMarbleVer5(string baseClass, string method, string command, string message, string data, double id, double value)
	{
		BaseClass = baseClass;
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
			if (MarbleTempVars.CheckingLogSize)
			{
				return;
			}
			MarbleTempVars.CheckingLogSize = true;
			FileInfo fileInfo = new FileInfo(Application.StartupPath + "\\buMarbleLog5.csv");
			if (fileInfo.Exists)
			{
				int num = 20;
				if (fileInfo.Length > Convert.ToInt32(2097152))
				{
					List<string> list = new List<string>();
					string text = "";
					TextReader textReader = File.OpenText(fileInfo.FullName);
					while ((text = textReader.ReadLine()) != null)
					{
						list.Add(text);
					}
					textReader.Close();
					int num2 = Convert.ToInt32(list.Count * num / 100);
					list.Reverse();
					list.RemoveRange(num2, list.Count - num2);
					list.Reverse();
					TextWriter textWriter = File.CreateText(buSystem.fileNameLog);
					for (int i = 0; i <= list.Count - 1; i++)
					{
						textWriter.WriteLine(list[i].ToString());
					}
					textWriter.Close();
				}
			}
			fileInfo = new FileInfo(Application.StartupPath + "\\buMarbleInstantLog5.csv");
			if (fileInfo.Exists)
			{
				fileInfo.Delete();
			}
			fileInfo = new FileInfo(Application.StartupPath + "\\buMarbleException5.csv");
			if (fileInfo.Exists)
			{
				int num3 = 20;
				if (fileInfo.Length > Convert.ToInt32(2097152))
				{
					List<string> list2 = new List<string>();
					string text2 = "";
					TextReader textReader2 = File.OpenText(fileInfo.FullName);
					while ((text2 = textReader2.ReadLine()) != null)
					{
						list2.Add(text2);
					}
					textReader2.Close();
					int num4 = Convert.ToInt32(list2.Count * num3 / 100);
					list2.Reverse();
					list2.RemoveRange(num4, list2.Count - num4);
					list2.Reverse();
					TextWriter textWriter2 = File.CreateText(buSystem.fileNameExceptionLog);
					for (int j = 0; j <= list2.Count - 1; j++)
					{
						textWriter2.WriteLine(list2[j].ToString());
					}
					textWriter2.Close();
				}
			}
			fileInfo = new FileInfo(Application.StartupPath + "\\bucrtcl.lcsv");
			if (fileInfo.Exists)
			{
				int num5 = 20;
				if (fileInfo.Length > Convert.ToInt32(2097152))
				{
					List<string> list3 = new List<string>();
					string text3 = "";
					TextReader textReader3 = File.OpenText(fileInfo.FullName);
					while ((text3 = textReader3.ReadLine()) != null)
					{
						list3.Add(text3);
					}
					textReader3.Close();
					int num6 = Convert.ToInt32(list3.Count * num5 / 100);
					list3.Reverse();
					list3.RemoveRange(num6, list3.Count - num6);
					list3.Reverse();
					TextWriter textWriter3 = File.CreateText(buSystem.fileNameExceptionLog);
					for (int k = 0; k <= list3.Count - 1; k++)
					{
						textWriter3.WriteLine(list3[k].ToString());
					}
					textWriter3.Close();
				}
			}
			fileInfo = new FileInfo(Application.StartupPath + "\\bucoml.lcsv");
			if (fileInfo.Exists)
			{
				int num7 = 20;
				if (fileInfo.Length > Convert.ToInt32(2097152))
				{
					List<string> list4 = new List<string>();
					string text4 = "";
					TextReader textReader4 = File.OpenText(fileInfo.FullName);
					while ((text4 = textReader4.ReadLine()) != null)
					{
						list4.Add(text4);
					}
					textReader4.Close();
					int num8 = Convert.ToInt32(list4.Count * num7 / 100);
					list4.Reverse();
					list4.RemoveRange(num8, list4.Count - num8);
					list4.Reverse();
					TextWriter textWriter4 = File.CreateText(buSystem.fileNameExceptionLog);
					for (int l = 0; l <= list4.Count - 1; l++)
					{
						textWriter4.WriteLine(list4[l].ToString());
					}
					textWriter4.Close();
				}
			}
			MarbleTempVars.CheckingLogSize = false;
		}
		catch (Exception)
		{
			MarbleTempVars.CheckingLogSize = false;
		}
	}

	public static void addToLogList(string strClass, string method, string command, string message = "", string data = "", double id = 0.0, double value = 0.0, bool AddException = false)
	{
		if (LogList == null)
		{
			LogList = new List<string>();
		}
		string item = DateTime.Now.ToLocalTime().ToString() + " ; " + strClass + " ; " + method + " ; " + command + " ; " + message + " ; " + data + " ; " + value + " ; " + id;
		LogList.Add(item);
	}

	public static void saveLogList()
	{
		if (MarbleTempVars.SavingLog | MarbleTempVars.CheckingLogSize)
		{
			return;
		}
		MarbleTempVars.SavingLog = true;
		if (LogList != null)
		{
			string path = Application.StartupPath + "\\buMarbleLog5.csv";
			TextWriter textWriter = File.AppendText(path);
			for (int i = 0; i <= LogList.Count - 1; i++)
			{
				textWriter.Write(LogList[i]);
			}
			textWriter.Close();
			path = Application.StartupPath + "\\buMarbleInstantLog5.csv";
			TextWriter textWriter2 = File.AppendText(path);
			for (int j = 0; j <= LogList.Count - 1; j++)
			{
				textWriter2.Write(LogList[j]);
			}
			textWriter2.Close();
			LogList.Clear();
		}
		MarbleTempVars.SavingLog = false;
	}

	public static void addToLog(string strClass, string method, string command, string message = "", string data = "", double id = 0.0, double value = 0.0, bool AddException = false)
	{
		try
		{
			if (!(MarbleTempVars.SavingLog | MarbleTempVars.CheckingLogSize))
			{
				MarbleTempVars.SavingLog = true;
				string value2 = DateTime.Now.ToLocalTime().ToString() + " ; " + strClass + " ; " + method + " ; " + command + " ; " + message + " ; " + data + " ; " + value + " ; " + id + Environment.NewLine;
				string path = Application.StartupPath + "\\buMarbleLog5.csv";
				TextWriter textWriter = File.AppendText(path);
				textWriter.Write(value2);
				textWriter.Close();
				if (AddException)
				{
					addToLogException(strClass, method, "Exception", message, data, id, value);
				}
				path = Application.StartupPath + "\\buMarbleInstantLog5.csv";
				TextWriter textWriter2 = File.AppendText(path);
				textWriter2.Write(value2);
				textWriter2.Close();
				MarbleTempVars.SavingLog = false;
			}
		}
		catch (Exception)
		{
		}
	}

	public static void addToUserLog(string process, string command, string data1, string data2, string data3, string data4, int id)
	{
		try
		{
			if (!(MarbleTempVars.SavingUserLog | MarbleTempVars.CheckingLogSize))
			{
				MarbleTempVars.SavingUserLog = true;
				string value = DateTime.Now.ToLocalTime().ToString() + " ; " + process + " ; " + command + " ; " + data1 + " ; " + data2 + " ; " + data3 + " ; " + data4 + " ; " + id + Environment.NewLine;
				string path = Application.StartupPath + "\\bucoml.lcsv";
				TextWriter textWriter = File.AppendText(path);
				textWriter.Write(value);
				textWriter.Close();
				MarbleTempVars.SavingUserLog = false;
			}
		}
		catch (Exception)
		{
			MarbleTempVars.SavingUserLog = false;
		}
	}

	public static void addToCriticalLog(string process, string command, string data1, string data2, string data3, string data4, int id)
	{
		try
		{
			if (!(MarbleTempVars.SavingCriticalLog | MarbleTempVars.CheckingLogSize))
			{
				MarbleTempVars.SavingCriticalLog = true;
				string value = DateTime.Now.ToLocalTime().ToString() + " ; " + process + " ; " + command + " ; " + data1 + " ; " + data2 + " ; " + data3 + " ; " + data4 + " ; " + id + Environment.NewLine;
				string path = Application.StartupPath + "\\bucrtcl.lcsv";
				TextWriter textWriter = File.AppendText(path);
				textWriter.Write(value);
				textWriter.Close();
				MarbleTempVars.SavingCriticalLog = false;
			}
		}
		catch (Exception)
		{
		}
	}

	public static void addToLogException(string strClass, string method, string command = "", string message = "Exception", string data = "", double id = 0.0, double value = 0.0)
	{
		try
		{
			if (!(MarbleTempVars.SavingExceptionsLog | MarbleTempVars.CheckingLogSize))
			{
				MarbleTempVars.SavingExceptionsLog = true;
				string value2 = DateTime.Now.ToLocalTime().ToString() + " ; " + strClass + " ; " + method + " ; " + command + " ; " + message + " ; " + data + " ; " + value + " ; " + id + Environment.NewLine;
				string path = Application.StartupPath + "\\buMarbleException5.csv";
				TextWriter textWriter = File.AppendText(path);
				textWriter.Write(value2);
				textWriter.Close();
				MarbleTempVars.SavingExceptionsLog = false;
			}
		}
		catch (Exception)
		{
		}
	}

	public override string ToString()
	{
		return Time.ToShortTimeString() + " - BaseClass: " + BaseClass + " - Method: " + Method + " - Cmd: " + Command + " - Msg: " + Message;
	}
}
