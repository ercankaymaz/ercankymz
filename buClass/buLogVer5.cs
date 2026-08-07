// Decompiled with JetBrains decompiler
// Type: buClass.buLogVer5
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace buClass;

public class buLogVer5
{
  public static int cntLog = 0;
  public static List<string> logList = new List<string>();
  public string Message = (string) null;
  public string Command = "";
  public string Method = "";
  public string Data = (string) null;
  public double ID = 0.0;
  public double Value = 0.0;
  public DateTime Time = new DateTime();

  public buLogVer5()
  {
  }

  public buLogVer5(buLogVer5 log)
  {
    this.Message = log.Message;
    this.Data = log.Data;
    this.ID = log.ID;
    this.Time = log.Time;
    this.Command = log.Command;
    this.Method = log.Method;
    this.Value = log.Value;
  }

  public buLogVer5(
    string command,
    string method,
    string message,
    string data,
    double id,
    double value)
  {
    this.Command = command;
    this.Message = message;
    this.Method = method;
    this.Data = data;
    this.ID = id;
    this.Value = value;
    this.Time = DateTime.Now;
  }

  public static void checkLogFileSize()
  {
    try
    {
      if (AppBool.CheckingLogSize)
        return;
      AppBool.CheckingLogSize = true;
      FileInfo fileInfo1 = new FileInfo(buSystem.fileNameLog);
      if (fileInfo1.Exists)
      {
        int num1 = 2048 /*0x0800*/;
        int num2 = 20;
        if (fileInfo1.Length > (long) Convert.ToInt32(num1 * 1024 /*0x0400*/))
        {
          List<string> stringList = new List<string>();
          TextReader textReader = (TextReader) File.OpenText(buSystem.fileNameLog);
          string str;
          while ((str = textReader.ReadLine()) != null)
            stringList.Add(str);
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
      FileInfo fileInfo2 = new FileInfo(buSystem.fileNameExceptionLog);
      if (fileInfo2.Exists)
      {
        int num3 = 2048 /*0x0800*/;
        int num4 = 20;
        if (fileInfo2.Length > (long) Convert.ToInt32(num3 * 1024 /*0x0400*/))
        {
          List<string> stringList = new List<string>();
          TextReader textReader = (TextReader) File.OpenText(buSystem.fileNameExceptionLog);
          string str;
          while ((str = textReader.ReadLine()) != null)
            stringList.Add(str);
          textReader.Close();
          int int32 = Convert.ToInt32(stringList.Count * num4 / 100);
          stringList.Reverse();
          stringList.RemoveRange(int32, stringList.Count - int32);
          stringList.Reverse();
          TextWriter text = (TextWriter) File.CreateText(buSystem.fileNameExceptionLog);
          for (int index = 0; index <= stringList.Count - 1; ++index)
            text.WriteLine(stringList[index].ToString());
          text.Close();
        }
      }
      AppBool.CheckingLogSize = false;
    }
    catch (Exception ex)
    {
      AppBool.CheckingLogSize = false;
    }
  }

  public static string LogToString(
    string strClass,
    string method,
    string command,
    string message = "",
    string data = "",
    double id = 0.0,
    double value = 0.0)
  {
    try
    {
      string[] strArray = new string[16 /*0x10*/];
      DateTime dateTime = DateTime.Now;
      dateTime = dateTime.ToLocalTime();
      strArray[0] = dateTime.ToString("MM-dd-yyyy HH:mm:ss");
      strArray[1] = " ; ";
      strArray[2] = strClass;
      strArray[3] = " ; ";
      strArray[4] = method;
      strArray[5] = " ; ";
      strArray[6] = command;
      strArray[7] = " ; ";
      strArray[8] = message;
      strArray[9] = " ; ";
      strArray[10] = data;
      strArray[11] = " ; ";
      strArray[12] = value.ToString();
      strArray[13] = " ; ";
      strArray[14] = id.ToString();
      strArray[15] = Environment.NewLine;
      return string.Concat(strArray);
    }
    catch (Exception ex)
    {
      return "";
    }
  }

  public static void addToLog(ref List<string> loglist)
  {
    try
    {
      if (AppBool.SavingLog | AppBool.CheckingLogSize)
        return;
      AppBool.SavingLog = true;
      buSystem.fileNameLog = Application.StartupPath + "\\buLog5.csv";
      TextWriter textWriter = (TextWriter) File.AppendText(buSystem.fileNameLog);
      for (int index = 0; index <= loglist.Count - 1; ++index)
      {
        textWriter.Write(loglist[index]);
        ++buLogVer5.cntLog;
      }
      textWriter.Close();
      loglist.Clear();
      AppBool.SavingLog = false;
    }
    catch (Exception ex)
    {
      AppBool.SavingLog = false;
    }
  }

  public static void addToList(
    string strClass,
    string method,
    string command,
    string message = "",
    string data = "",
    double id = 0.0,
    double value = 0.0)
  {
    try
    {
      buLogVer5.logList.Add(buLogVer5.LogToString(strClass, method, command, message, data, id, value));
    }
    catch (Exception ex)
    {
    }
  }

  public static void addToLog(
    string strClass,
    string method,
    string command,
    string message = "",
    string data = "",
    double id = 0.0,
    double value = 0.0,
    bool AddException = false)
  {
    try
    {
      if (AppBool.SavingLog | AppBool.CheckingLogSize)
        return;
      AppBool.SavingLog = true;
      string str = buLogVer5.LogToString(strClass, method, command, message, data, id, value);
      buSystem.fileNameLog = Application.StartupPath + "\\buLog5.csv";
      TextWriter textWriter = (TextWriter) File.AppendText(buSystem.fileNameLog);
      textWriter.Write(str);
      textWriter.Close();
      if (AddException)
        buLogVer5.addToLogException(strClass, method, command, data: data, id: id, value: value);
      ++buLogVer5.cntLog;
      AppBool.SavingLog = false;
    }
    catch (Exception ex)
    {
      AppBool.SavingLog = false;
    }
  }

  public static void addToLog(
    string method,
    string command,
    string message,
    string data,
    double id,
    double value,
    bool AddException = false)
  {
    try
    {
      if (AppBool.SavingLog | AppBool.CheckingLogSize)
        return;
      AppBool.SavingLog = true;
      string str = buLogVer5.LogToString("", method, command, message, data, id, value);
      buSystem.fileNameLog = Application.StartupPath + "\\buLog5.csv";
      TextWriter textWriter = (TextWriter) File.AppendText(buSystem.fileNameLog);
      textWriter.Write(str);
      textWriter.Close();
      if (AddException)
        buLogVer5.addToLogException("", method, command, data: data, id: id, value: value);
      ++buLogVer5.cntLog;
      AppBool.SavingLog = false;
    }
    catch (Exception ex)
    {
      AppBool.SavingLog = false;
    }
  }

  public static void addToLogException(
    string strClass,
    string method,
    string command,
    string message = "Exception",
    string data = "",
    double id = 0.0,
    double value = 0.0)
  {
    try
    {
      if (AppBool.SavingExceptionLog | AppBool.CheckingLogSize)
        return;
      AppBool.SavingExceptionLog = true;
      string[] strArray = new string[16 /*0x10*/];
      DateTime dateTime = DateTime.Now;
      dateTime = dateTime.ToLocalTime();
      strArray[0] = dateTime.ToString();
      strArray[1] = " ; ";
      strArray[2] = strClass;
      strArray[3] = " ; ";
      strArray[4] = method;
      strArray[5] = " ; ";
      strArray[6] = command;
      strArray[7] = " ; ";
      strArray[8] = message;
      strArray[9] = " ; ";
      strArray[10] = data;
      strArray[11] = " ; ";
      strArray[12] = value.ToString();
      strArray[13] = " ; ";
      strArray[14] = id.ToString();
      strArray[15] = Environment.NewLine;
      string str = string.Concat(strArray);
      buSystem.fileNameLog = Application.StartupPath + "\\buLogException5.csv";
      TextWriter textWriter = (TextWriter) File.AppendText(buSystem.fileNameLog);
      textWriter.Write(str);
      textWriter.Close();
      AppBool.SavingExceptionLog = false;
    }
    catch (Exception ex)
    {
      AppBool.SavingExceptionLog = false;
    }
  }

  public override string ToString()
  {
    return $"{this.Time.ToString("HH:mm:ss")} - Method : {this.Method} - Cmd : {this.Command} - Msg : {this.Message}";
  }
}
