// Decompiled with JetBrains decompiler
// Type: buClass.buLog
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace buClass;

public class buLog
{
  public static List<buLog> LastLogs = new List<buLog>();
  public string Message = (string) null;
  public string Command = "";
  public string CallMethod = "";
  public string Status = "";
  public string ParStr2 = (string) null;
  public double ParVal1 = 0.0;
  public double ID = 0.0;
  public DateTime Time = new DateTime();

  public buLog()
  {
  }

  public buLog(buLog log)
  {
    this.Message = log.Message;
    this.Status = log.Status;
    this.ParStr2 = log.ParStr2;
    this.ParVal1 = log.ParVal1;
    this.ID = log.ID;
    this.Time = log.Time;
    this.Command = log.Command;
    this.CallMethod = log.CallMethod;
  }

  public buLog(string Command, string CallMethod, DateTime time)
  {
    this.Command = Command;
    this.Message = (string) null;
    this.Status = (string) null;
    this.ParStr2 = (string) null;
    this.ParVal1 = 0.0;
    this.ID = 0.0;
    this.Time = time;
  }

  public buLog(string Command, string CallMethod, string Message)
  {
    this.Command = Command;
    this.Message = Message;
    this.Status = (string) null;
    this.ParStr2 = (string) null;
    this.ParVal1 = 0.0;
    this.ID = 0.0;
    this.Time = DateTime.Now;
  }

  public buLog(string Command, string CallMethod, string Message, string status, double id)
  {
    this.Command = Command;
    this.Message = Message;
    this.Status = status;
    this.ParStr2 = (string) null;
    this.ParVal1 = 0.0;
    this.ID = id;
    this.Time = DateTime.Now;
  }

  public buLog(
    string Command,
    string CallMethod,
    string Message,
    string ParStr1,
    string ParStr2,
    double ParVal1,
    double ParVal2)
  {
    this.Message = Message;
    this.Command = Command;
    this.CallMethod = CallMethod;
    this.Status = ParStr1;
    this.ParStr2 = ParStr2;
    this.ParVal1 = ParVal1;
    this.ID = ParVal2;
    this.Time = DateTime.Now;
  }

  public buLog(
    string Command,
    string CallMethod,
    string Message,
    string ParStr1,
    string ParStr2,
    double ParVal1,
    double ParVal2,
    DateTime time)
  {
    this.Message = Message;
    this.Command = Command;
    this.CallMethod = CallMethod;
    this.Status = ParStr1;
    this.ParStr2 = ParStr2;
    this.ParVal1 = ParVal1;
    this.ID = ParVal2;
    this.Time = time;
  }

  public static void addLog(string Command)
  {
    buLog.addLog(new buLog(Command, "No Method", "No Message"), "");
  }

  public static void addLog(string Command, string Message, string callMethod)
  {
    buLog.addLog(new buLog(Command, callMethod, Message), callMethod);
  }

  public static void addLog(
    string Command,
    string Message,
    string callMethod,
    string ParStr1,
    string ParStr2,
    double ParVal1,
    double ParVal2)
  {
    buLog.addLog(new buLog(Command, callMethod, Message, ParStr1, ParStr1, ParVal1, ParVal2), callMethod);
  }

  public static void addLog(CalculationErrorEventArg CalcError)
  {
    buLog.addLog(new buLog("", CalcError.Method, CalcError.Message, CalcError.Status, (double) CalcError.ID), CalcError.Method);
  }

  public static void addLog(string command, string message, string method, string status, int id)
  {
    buLog.addLog(new buLog(command, method, message, status, (double) id), method);
  }

  public static void addLog(buLog log, string callMethod)
  {
    try
    {
      bool flag = false;
      string[] strArray = new string[18];
      strArray[0] = DateTime.Now.ToLongDateString();
      strArray[1] = " ; ";
      DateTime dateTime = DateTime.Now;
      dateTime = dateTime.ToLocalTime();
      strArray[2] = dateTime.ToString();
      strArray[3] = " ; Method : ";
      strArray[4] = callMethod;
      strArray[5] = "  ;  Command : ";
      strArray[6] = buStatics.StringToSting(log.Command);
      strArray[7] = "  ;  Message : ";
      strArray[8] = buStatics.StringToSting(log.Message);
      strArray[9] = "  ;  Par Str1 : ";
      strArray[10] = buStatics.StringToSting(log.Status);
      strArray[11] = "  ;  ParStr2: ";
      strArray[12] = buStatics.StringToSting(log.ParStr2);
      strArray[13] = "  ;  ParVal1: ";
      strArray[14] = buStatics.StringToSting(log.ParVal1.ToString());
      strArray[15] = "  ;  ParVal2: ";
      strArray[16 /*0x10*/] = buStatics.StringToSting(log.ID.ToString());
      strArray[17] = Environment.NewLine;
      string str1 = string.Concat(strArray);
      buLog.LastLogs.Add(new buLog(log)
      {
        CallMethod = callMethod
      });
      if (buLog.LastLogs.Count > 3 && buLog.LastLogs[buLog.LastLogs.Count - 1].Message.Trim().ToLower() == callMethod.Trim().ToLower() && buLog.LastLogs[buLog.LastLogs.Count - 2].Message.Trim().ToLower() == callMethod.Trim().ToLower())
        flag = true;
      if (!flag)
      {
        TextWriter textWriter = (TextWriter) File.AppendText(buSystem.fileNameLog);
        textWriter.Write(str1);
        textWriter.Close();
      }
      if (buLog.LastLogs.Count > 100)
        buLog.LastLogs.RemoveRange(0, buLog.LastLogs.Count - 50);
      FileInfo fileInfo = new FileInfo(buSystem.fileNameLog);
      if (!fileInfo.Exists)
        return;
      int num1 = 2048 /*0x0800*/;
      int num2 = 20;
      if (fileInfo.Length > (long) Convert.ToInt32(num1 * 1024 /*0x0400*/))
      {
        List<string> stringList = new List<string>();
        TextReader textReader = (TextReader) File.OpenText(buSystem.fileNameLog);
        string str2;
        while ((str2 = textReader.ReadLine()) != null)
          stringList.Add(str2);
        textReader.Close();
        int int32 = Convert.ToInt32(stringList.Count * num2 / 100);
        stringList.Reverse();
        stringList.RemoveRange(int32, stringList.Count - int32);
        stringList.Reverse();
        TextWriter text = (TextWriter) File.CreateText(buSystem.fileNameLog);
        for (int index = 0; index <= stringList.Count - 1; ++index)
          text.WriteLine(stringList[index].ToString());
        text.Close();
      }
    }
    catch (Exception ex)
    {
    }
  }

  public static void addLog(Exception ex, string Note)
  {
    try
    {
      string str1 = $"Line No : {ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7)}{Environment.NewLine}";
      string str2 = $"Error Message: {ex.GetType().Name.ToString()}{Environment.NewLine}";
      string str3 = $"Error Type : {ex.GetType().ToString()}{Environment.NewLine}";
      string str4 = $"Error Location : {ex.Message.ToString()}{Environment.NewLine}";
      string str5 = "Error Note : " + Note;
      FileInfo fileInfo = new FileInfo($"{Application.StartupPath}\\Error{DateTime.Now.Year.ToString()}_{DateTime.Now.Month.ToString()}_{DateTime.Now.Day.ToString()}_{DateTime.Now.Hour.ToString()}_{DateTime.Now.Minute.ToString()}_{DateTime.Now.Second.ToString()}_{DateTime.Now.Millisecond.ToString()}.instalog");
      if (fileInfo.Exists)
        return;
      TextWriter text = (TextWriter) File.CreateText(fileInfo.FullName);
      text.Write(str1);
      text.Write(str2);
      text.Write(str3);
      text.Write(str4);
      text.Write(str5);
      text.Close();
    }
    catch (Exception ex1)
    {
    }
  }

  public override string ToString()
  {
    return $"{this.Time.ToShortTimeString()} - Call : {this.CallMethod} - Cmd : {this.Command}";
  }
}
