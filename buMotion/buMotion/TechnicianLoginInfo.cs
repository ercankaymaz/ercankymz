// Decompiled with JetBrains decompiler
// Type: buMotion.TechnicianLoginInfo
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace buMotion;

[Serializable]
public class TechnicianLoginInfo : buSerilization
{
  public string Message;
  public string Command;
  public string Method;
  public string Data;
  public string BaseClass;
  public double ID;

  public TechnicianLoginInfo(
    string baseClass,
    string method,
    string command,
    string message,
    string data,
    double id,
    double value)
  {
    ((TechnicianType) this).Value = 0.0;
    ((TechnicianType) this).Time = new DateTime();
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.BaseClass = baseClass;
    this.Command = command;
    this.Message = message;
    this.Method = method;
    this.Data = data;
    this.ID = id;
    ((TechnicianType) this).Value = value;
    ((TechnicianType) this).Time = DateTime.Now;
  }

  public static void checkLogFileSize()
  {
    try
    {
      FileInfo fileInfo1 = new FileInfo($"{Application.StartupPath}\\{buMotionColors.LogFileName}");
      if (fileInfo1.Exists)
      {
        int num1 = 2048 /*0x0800*/;
        int num2 = 20;
        if (fileInfo1.Length > (long) Convert.ToInt32(num1 * 1024 /*0x0400*/))
        {
          List<string> stringList = new List<string>();
          TextReader textReader = (TextReader) File.OpenText(fileInfo1.FullName);
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
      FileInfo fileInfo2 = new FileInfo($"{Application.StartupPath}\\{buMotionColors.ExceptionFileName}");
      if (fileInfo2.Exists)
        fileInfo2.Delete();
      FileInfo fileInfo3 = new FileInfo($"{Application.StartupPath}\\{buMotionColors.SeasonFileName}");
      if (!fileInfo3.Exists)
        return;
      int num3 = 2048 /*0x0800*/;
      int num4 = 20;
      if (fileInfo3.Length <= (long) Convert.ToInt32(num3 * 1024 /*0x0400*/))
        return;
      List<string> stringList1 = new List<string>();
      TextReader textReader1 = (TextReader) File.OpenText(fileInfo3.FullName);
      string str1;
      while ((str1 = textReader1.ReadLine()) != null)
        stringList1.Add(str1);
      textReader1.Close();
      int int32_1 = Convert.ToInt32(stringList1.Count * num4 / 100);
      stringList1.Reverse();
      stringList1.RemoveRange(int32_1, stringList1.Count - int32_1);
      stringList1.Reverse();
      TextWriter text1 = (TextWriter) File.CreateText(buSystem.fileNameExceptionLog);
      for (int index = 0; index <= stringList1.Count - 1; ++index)
        text1.WriteLine(stringList1[index].ToString());
      text1.Close();
    }
    catch (Exception ex)
    {
    }
  }

  public static void addToLogList(
    string strClass,
    string method,
    string command,
    string message = "",
    string data = "",
    double id = 0.0,
    double value = 0.0,
    bool AddException = false)
  {
    if (TechnicianType.LogList == null)
      TechnicianType.LogList = new List<string>();
    string[] strArray = new string[15];
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
    string str = string.Concat(strArray);
    TechnicianType.LogList.Add(str);
  }
}
