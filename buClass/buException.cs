// Decompiled with JetBrains decompiler
// Type: buClass.buException
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace buClass;

public class buException
{
  public static List<buException> LastExceptions = new List<buException>();
  public string Message = "";
  public Exception MSCode = new Exception();
  public DateTime Time = new DateTime();
  public static int ExceptionCount = 0;

  public buException()
  {
  }

  public buException(string message, Exception MSCode, DateTime time)
  {
    this.Message = message;
    this.MSCode = MSCode;
    this.Time = time;
  }

  public static void throwException(Exception MSException, string callMethod)
  {
    buException.throwException(MSException, callMethod, false, "");
  }

  public static void throwException(Exception MSException, string callMethod, bool ShowMessageBox)
  {
    buException.throwException(MSException, callMethod, ShowMessageBox, "");
  }

  public static void throwException(
    Exception MSException,
    string callMethod,
    bool ShowMessageBox,
    string auxMessage)
  {
    buException.throwException(MSException, "", callMethod, ShowMessageBox, auxMessage);
  }

  public static void throwException(
    Exception MSException,
    string callClass,
    string callMethod,
    bool ShowMessageBox,
    string auxMessage)
  {
    try
    {
      bool flag = false;
      string data = $"exp_{DateTime.Now.Year.ToString("D4")}{DateTime.Now.Month.ToString("D2")}{DateTime.Now.Day.ToString("D2")}_{DateTime.Now.Hour.ToString("D2")}{DateTime.Now.Minute.ToString("D2")}{DateTime.Now.Second.ToString("D2")}";
      buException buException = new buException(callMethod, MSException, DateTime.Now);
      ++buException.ExceptionCount;
      MSException.Message.Replace("\r\n", " - ");
      string str = "";
      if (callClass.Trim().Length > 0)
        str = callClass + " > ";
      string text = $"[ {str}{callMethod} ] {Environment.NewLine}{Environment.NewLine}{MSException.Message}";
      buLogVer5.addToLogException(callClass, callMethod, MSException.Message, data: data);
      if (auxMessage.Length > 0)
        text = text + Environment.NewLine + Environment.NewLine + auxMessage;
      buException.LastExceptions.Add(buException);
      if (buException.LastExceptions.Count > 10 && buException.LastExceptions[buException.LastExceptions.Count - 1].Message.Trim().ToLower() == callMethod.Trim().ToLower() && buException.LastExceptions[buException.LastExceptions.Count - 2].Message.Trim().ToLower() == callMethod.Trim().ToLower())
        flag = true;
      if (buException.LastExceptions.Count > 5)
        buException.LastExceptions.RemoveRange(0, buException.LastExceptions.Count - 5);
      try
      {
        DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Exception);
        if (!directoryInfo.Exists)
        {
          AppPath.Exception = AppPath.Base + "\\Exceptions";
          directoryInfo = new DirectoryInfo(AppPath.Exception);
          if (!directoryInfo.Exists)
            directoryInfo.Create();
        }
        if (directoryInfo.FullName.Length > 0)
        {
          using (StreamWriter streamWriter = new StreamWriter($"{AppPath.Exception}\\{data}.exp", true))
          {
            streamWriter.WriteLine("-----------------------------------------------------------------------------");
            streamWriter.WriteLine("Date : " + DateTime.Now.ToString());
            streamWriter.WriteLine("Class : " + callClass);
            streamWriter.WriteLine("Method : " + callMethod);
            if (auxMessage.Length > 0)
              streamWriter.WriteLine("Aux : " + auxMessage);
            streamWriter.WriteLine();
            for (; MSException != null; MSException = MSException.InnerException)
            {
              streamWriter.WriteLine(MSException.GetType().FullName);
              streamWriter.WriteLine("Message : " + MSException.Message);
              streamWriter.WriteLine("StackTrace : " + MSException.StackTrace);
            }
          }
        }
      }
      catch (Exception ex)
      {
      }
      if (!(ShowMessageBox & !flag))
        return;
      int num = (int) MessageBox.Show(text, buLangTranslate.preDef.Exception, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
    catch (Exception ex)
    {
    }
  }

  public static void throwException(CalculationErrorEventArg CalcError, bool ShowMessageBox)
  {
    bool flag = false;
    buLog.addLog(CalcError);
    buException buException = new buException(CalcError.Method, CalcError.Exceptions, DateTime.Now);
    ++buException.ExceptionCount;
    string str1 = CalcError.Exceptions.Message.Replace("\r\n", " - ");
    string text1 = $"[ {CalcError.Method} ] {Environment.NewLine}{Environment.NewLine}{str1}";
    if (CalcError.Message.Length > 0)
      text1 = text1 + Environment.NewLine + Environment.NewLine + CalcError.Message;
    string[] strArray = new string[16 /*0x10*/];
    strArray[0] = DateTime.Now.ToLongDateString();
    strArray[1] = " ; ";
    DateTime dateTime = DateTime.Now;
    dateTime = dateTime.ToLocalTime();
    strArray[2] = dateTime.ToString();
    strArray[3] = " ; Method : ";
    strArray[4] = CalcError.Method;
    strArray[5] = " ; ID : ";
    strArray[6] = CalcError.ID.ToString();
    strArray[7] = " ; Job : ";
    strArray[8] = CalcError.Job;
    strArray[9] = " ; SubJob : ";
    strArray[10] = CalcError.SubJob;
    strArray[11] = "  ;  Exception: ";
    strArray[12] = str1;
    strArray[13] = "  ;  Message : ";
    strArray[14] = CalcError.Message;
    strArray[15] = Environment.NewLine;
    string str2 = string.Concat(strArray);
    buException.LastExceptions.Add(buException);
    if (buException.LastExceptions.Count > 3 && buException.LastExceptions[buException.LastExceptions.Count - 1].Message.Trim().ToLower() == CalcError.Method.Trim().ToLower() && buException.LastExceptions[buException.LastExceptions.Count - 2].Message.Trim().ToLower() == CalcError.Method.Trim().ToLower())
      flag = true;
    if (!flag)
    {
      try
      {
        TextWriter textWriter = (TextWriter) File.AppendText(buSystem.fileNameException);
        textWriter.Write(str2);
        textWriter.Close();
      }
      catch (Exception ex)
      {
      }
    }
    if (buException.LastExceptions.Count > 5)
      buException.LastExceptions.RemoveRange(0, buException.LastExceptions.Count - 5);
    try
    {
      FileInfo fileInfo = new FileInfo(buSystem.fileNameException);
      if (fileInfo.Exists)
      {
        int num1 = 2048 /*0x0800*/;
        int num2 = 20;
        if (fileInfo.Length > (long) Convert.ToInt32(num1 * 1024 /*0x0400*/))
        {
          List<string> stringList = new List<string>();
          TextReader textReader = (TextReader) File.OpenText(buSystem.fileNameException);
          string str3;
          while ((str3 = textReader.ReadLine()) != null)
            stringList.Add(str3);
          textReader.Close();
          int int32 = Convert.ToInt32(stringList.Count * num2 / 100);
          stringList.Reverse();
          stringList.RemoveRange(int32, stringList.Count - int32);
          stringList.Reverse();
          TextWriter text2 = (TextWriter) File.CreateText(buSystem.fileNameException);
          for (int index = 0; index <= stringList.Count - 1; ++index)
            text2.WriteLine(stringList[index].ToString());
          text2.Close();
        }
      }
    }
    catch (Exception ex)
    {
    }
    if (!(ShowMessageBox & !flag))
      return;
    int num = (int) MessageBox.Show(text1);
  }
}
