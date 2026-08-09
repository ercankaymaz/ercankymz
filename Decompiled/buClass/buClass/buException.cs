using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace buClass;

public class buException
{
	public static List<buException> LastExceptions = new List<buException>();

	public string Message = "";

	public Exception MSCode = new Exception();

	public DateTime Time = default(DateTime);

	public static int ExceptionCount = 0;

	public buException()
	{
	}

	public buException(string message, Exception MSCode, DateTime time)
	{
		Message = message;
		this.MSCode = MSCode;
		Time = time;
	}

	public static void throwException(Exception MSException, string callMethod)
	{
		throwException(MSException, callMethod, ShowMessageBox: false, "");
	}

	public static void throwException(Exception MSException, string callMethod, bool ShowMessageBox)
	{
		throwException(MSException, callMethod, ShowMessageBox, "");
	}

	public static void throwException(Exception MSException, string callMethod, bool ShowMessageBox, string auxMessage)
	{
		throwException(MSException, "", callMethod, ShowMessageBox, auxMessage);
	}

	public static void throwException(Exception MSException, string callClass, string callMethod, bool ShowMessageBox, string auxMessage)
	{
		try
		{
			bool flag = false;
			string text = "exp_" + DateTime.Now.Year.ToString("D4") + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2") + "_" + DateTime.Now.Hour.ToString("D2") + DateTime.Now.Minute.ToString("D2") + DateTime.Now.Second.ToString("D2");
			buException item = new buException(callMethod, MSException, DateTime.Now);
			ExceptionCount++;
			string text2 = MSException.Message.Replace("\r\n", " - ");
			string text3 = "";
			if (callClass.Trim().Length > 0)
			{
				text3 = callClass + " > ";
			}
			string text4 = "[ " + text3 + callMethod + " ] " + Environment.NewLine + Environment.NewLine + MSException.Message;
			buLogVer5.addToLogException(callClass, callMethod, MSException.Message, "Exception", text);
			if (auxMessage.Length > 0)
			{
				text4 = text4 + Environment.NewLine + Environment.NewLine + auxMessage;
			}
			LastExceptions.Add(item);
			if (LastExceptions.Count > 10 && LastExceptions[LastExceptions.Count - 1].Message.Trim().ToLower() == callMethod.Trim().ToLower() && LastExceptions[LastExceptions.Count - 2].Message.Trim().ToLower() == callMethod.Trim().ToLower())
			{
				flag = true;
			}
			if (LastExceptions.Count > 5)
			{
				LastExceptions.RemoveRange(0, LastExceptions.Count - 5);
			}
			try
			{
				string text5 = "";
				DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Exception);
				if (!directoryInfo.Exists)
				{
					AppPath.Exception = AppPath.Base + "\\Exceptions";
					directoryInfo = new DirectoryInfo(AppPath.Exception);
					if (!directoryInfo.Exists)
					{
						directoryInfo.Create();
					}
				}
				if (directoryInfo.FullName.Length > 0)
				{
					text5 = AppPath.Exception + "\\" + text + ".exp";
					using StreamWriter streamWriter = new StreamWriter(text5, append: true);
					streamWriter.WriteLine("-----------------------------------------------------------------------------");
					streamWriter.WriteLine("Date : " + DateTime.Now.ToString());
					streamWriter.WriteLine("Class : " + callClass);
					streamWriter.WriteLine("Method : " + callMethod);
					if (auxMessage.Length > 0)
					{
						streamWriter.WriteLine("Aux : " + auxMessage);
					}
					streamWriter.WriteLine();
					while (MSException != null)
					{
						streamWriter.WriteLine(MSException.GetType().FullName);
						streamWriter.WriteLine("Message : " + MSException.Message);
						streamWriter.WriteLine("StackTrace : " + MSException.StackTrace);
						MSException = MSException.InnerException;
					}
				}
			}
			catch (Exception)
			{
			}
			if (ShowMessageBox && !flag)
			{
				MessageBox.Show(text4, buLangTranslate.preDef.Exception, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		catch (Exception)
		{
		}
	}

	public static void throwException(CalculationErrorEventArg CalcError, bool ShowMessageBox)
	{
		bool flag = false;
		buLog.addLog(CalcError);
		buException item = new buException(CalcError.Method, CalcError.Exceptions, DateTime.Now);
		ExceptionCount++;
		string text = CalcError.Exceptions.Message.Replace("\r\n", " - ");
		string text2 = "[ " + CalcError.Method + " ] " + Environment.NewLine + Environment.NewLine + text;
		if (CalcError.Message.Length > 0)
		{
			text2 = text2 + Environment.NewLine + Environment.NewLine + CalcError.Message;
		}
		string value = DateTime.Now.ToLongDateString() + " ; " + DateTime.Now.ToLocalTime().ToString() + " ; Method : " + CalcError.Method + " ; ID : " + CalcError.ID + " ; Job : " + CalcError.Job + " ; SubJob : " + CalcError.SubJob + "  ;  Exception: " + text + "  ;  Message : " + CalcError.Message + Environment.NewLine;
		LastExceptions.Add(item);
		if (LastExceptions.Count > 3 && LastExceptions[LastExceptions.Count - 1].Message.Trim().ToLower() == CalcError.Method.Trim().ToLower() && LastExceptions[LastExceptions.Count - 2].Message.Trim().ToLower() == CalcError.Method.Trim().ToLower())
		{
			flag = true;
		}
		if (!flag)
		{
			try
			{
				TextWriter textWriter = File.AppendText(buSystem.fileNameException);
				textWriter.Write(value);
				textWriter.Close();
			}
			catch (Exception)
			{
			}
		}
		if (LastExceptions.Count > 5)
		{
			LastExceptions.RemoveRange(0, LastExceptions.Count - 5);
		}
		try
		{
			FileInfo fileInfo = new FileInfo(buSystem.fileNameException);
			if (fileInfo.Exists)
			{
				int num = 2048;
				int num2 = 20;
				if (fileInfo.Length > Convert.ToInt32(num * 1024))
				{
					List<string> list = new List<string>();
					string text3 = "";
					TextReader textReader = File.OpenText(buSystem.fileNameException);
					while ((text3 = textReader.ReadLine()) != null)
					{
						list.Add(text3);
					}
					textReader.Close();
					int num3 = Convert.ToInt32(list.Count * num2 / 100);
					list.Reverse();
					list.RemoveRange(num3, list.Count - num3);
					list.Reverse();
					TextWriter textWriter2 = File.CreateText(buSystem.fileNameException);
					for (int i = 0; i <= list.Count - 1; i++)
					{
						textWriter2.WriteLine(list[i].ToString());
					}
					textWriter2.Close();
				}
			}
		}
		catch (Exception)
		{
		}
		if (ShowMessageBox && !flag)
		{
			MessageBox.Show(text2);
		}
	}
}
