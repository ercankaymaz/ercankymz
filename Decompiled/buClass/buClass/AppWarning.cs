using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace buClass;

[Serializable]
public class AppWarning : buSerilization
{
	public string Text = "";

	public string Axis = "";

	public int ID = -1;

	public double Code = 0.0;

	public int Option = 0;

	public string Aux = "";

	public bool Occured = false;

	public static List<string> Warnings = new List<string>();

	public AppWarning()
	{
	}

	public AppWarning(string text)
	{
		Text = text;
	}

	public static void AddToWarning(AppWarning warning)
	{
		Warnings.Add(warning.Axis + " : " + warning.Text + " - " + warning.ID + " | " + warning.Code + " | " + warning.Option + " | " + warning.Aux);
	}

	public static void AddToWarning(string Message, int id, string Ax)
	{
		Warnings.Add(Ax + " : " + Message + " - " + id);
	}

	public static void AddToWarning(string Message)
	{
		Warnings.Add(Message);
	}

	public void ClearWarning()
	{
		Warnings.Clear();
		Occured = false;
	}

	public static void AppendLogFile(string Filename, List<AppWarning> Warnings)
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
				for (int i = 0; i <= Warnings.Count - 1; i++)
				{
					string value = Warnings[i].Axis + " ; " + Warnings[i].Text + " ; " + Warnings[i].ID + " ; " + Warnings[i].Code + " ; " + Warnings[i].Option + " ; " + Warnings[i].Aux + ";" + DateTime.Now.ToString() + Environment.NewLine;
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

	public static void AppendLogFile(string Filename, AppWarning Warning)
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
				string value = Warning.Axis + " ; " + Warning.Text + " ; " + Warning.ID + " ; " + Warning.Code + " ; " + Warning.Option + " ; " + Warning.Aux + ";" + DateTime.Now.ToString() + Environment.NewLine;
				textWriter.Write(value);
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
}
