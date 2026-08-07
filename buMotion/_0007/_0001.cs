// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using System;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace \u0007;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
internal class \u0001 : Attribute
{
  public static void addToLogException(
    string strClass,
    string method,
    string command = "",
    string message = "Exception",
    string data = "",
    double id = 0.0,
    double value = 0.0)
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
      TextWriter textWriter = (TextWriter) File.AppendText(Application.StartupPath + "\\buMarbleException5.csv");
      textWriter.Write(str);
      textWriter.Close();
    }
    catch (Exception ex)
    {
    }
  }
}
