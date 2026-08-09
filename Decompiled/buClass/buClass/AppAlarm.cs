using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace buClass;

[Serializable]
public class AppAlarm : buSerilization
{
	public string Text = "";

	public string Axis = "";

	public int ID = -1;

	public double Code = 0.0;

	public int Option = 0;

	public string Aux = "";

	public bool Occured = false;

	public static List<string> Alarms = new List<string>();

	public static void AddToAlarm(string Message, int id, string Ax)
	{
		Alarms.Add(Ax + " : " + Message + " - " + id);
	}

	public static void AddToAlarm(AppAlarm alarm)
	{
		Alarms.Add(alarm.Axis + " : " + alarm.Text + " - " + alarm.ID + " | " + alarm.Code + " | " + alarm.Option + " | " + alarm.Aux);
	}

	public static void AddToAlarm(string Message)
	{
		Alarms.Add(Message);
	}

	public void ClearAlarm()
	{
		Alarms.Clear();
		Occured = false;
	}

	public static void AppendLogFile(string Filename, List<AppAlarm> Alarms)
	{
		TextWriter textWriter = null;
		try
		{
			if (Filename.Length >= 1)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(Filename));
				if (!directoryInfo.Exists)
				{
					directoryInfo.Create();
				}
				textWriter = File.AppendText(Filename);
				for (int i = 0; i <= Alarms.Count - 1; i++)
				{
					string value = Alarms[i].Axis + " ; " + Alarms[i].Text + " ; " + Alarms[i].ID + " ; " + Alarms[i].Code + " ; " + Alarms[i].Option + " ; " + Alarms[i].Aux + ";" + DateTime.Now.ToString() + Environment.NewLine;
					textWriter.Write(value);
				}
				textWriter.Close();
			}
		}
		catch (Exception mSException)
		{
			string text = "Filename : " + Filename;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
		finally
		{
			textWriter?.Close();
		}
	}

	public static void AppendLogFile(string Filename, AppAlarm Alarm)
	{
		TextWriter textWriter = null;
		try
		{
			if (Filename.Length >= 1)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(Filename));
				if (!directoryInfo.Exists)
				{
					directoryInfo.Create();
				}
				textWriter = File.AppendText(Filename);
				string value = Alarm.Axis + " ; " + Alarm.Text + " ; " + Alarm.ID + " ; " + Alarm.Code + " ; " + Alarm.Option + " ; " + Alarm.Aux + ";" + DateTime.Now.ToString() + Environment.NewLine;
				textWriter.Write(value);
				textWriter.Close();
			}
		}
		catch (Exception mSException)
		{
			string text = "Filename : " + Filename + " - Alarm : " + Alarm;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
		finally
		{
			textWriter?.Close();
		}
	}

	public override string ToString()
	{
		return "Axis : " + Axis + " - " + Text + " =  " + ID;
	}
}
