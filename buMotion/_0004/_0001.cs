// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buMotion;
using System;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace \u0004;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
internal class \u0001 : Attribute
{
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
      TextWriter textWriter1 = (TextWriter) File.AppendText($"{Application.StartupPath}\\{buMotionColors.LogFileName}");
      textWriter1.Write(str);
      textWriter1.Close();
      if (AddException)
        \u0007.\u0001.addToLogException(strClass, method, "Exception", message, data, id, value);
      TextWriter textWriter2 = (TextWriter) File.AppendText($"{Application.StartupPath}\\{buMotionColors.SeasonFileName}");
      textWriter2.Write(str);
      textWriter2.Close();
    }
    catch (Exception ex)
    {
    }
  }
}
