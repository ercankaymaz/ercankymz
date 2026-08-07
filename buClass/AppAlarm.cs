// Decompiled with JetBrains decompiler
// Type: buClass.AppAlarm
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

#nullable disable
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
    AppAlarm.Alarms.Add($"{Ax} : {Message} - {id.ToString()}");
  }

  public static void AddToAlarm(AppAlarm alarm)
  {
    AppAlarm.Alarms.Add($"{alarm.Axis} : {alarm.Text} - {alarm.ID.ToString()} | {alarm.Code.ToString()} | {alarm.Option.ToString()} | {alarm.Aux}");
  }

  public static void AddToAlarm(string Message) => AppAlarm.Alarms.Add(Message);

  public void ClearAlarm()
  {
    AppAlarm.Alarms.Clear();
    this.Occured = false;
  }

  public static void AppendLogFile(string Filename, List<AppAlarm> Alarms)
  {
    TextWriter textWriter = (TextWriter) null;
    try
    {
      if (Filename.Length < 1)
        return;
      DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(Filename));
      if (!directoryInfo.Exists)
        directoryInfo.Create();
      textWriter = (TextWriter) File.AppendText(Filename);
      for (int index = 0; index <= Alarms.Count - 1; ++index)
      {
        string str = $"{Alarms[index].Axis} ; {Alarms[index].Text} ; {Alarms[index].ID.ToString()} ; {Alarms[index].Code.ToString()} ; {Alarms[index].Option.ToString()} ; {Alarms[index].Aux};{DateTime.Now.ToString()}{Environment.NewLine}";
        textWriter.Write(str);
      }
      textWriter.Close();
    }
    catch (Exception ex)
    {
      string str = "Filename : " + Filename;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
    finally
    {
      textWriter?.Close();
    }
  }

  public static void AppendLogFile(string Filename, AppAlarm Alarm)
  {
    TextWriter textWriter = (TextWriter) null;
    try
    {
      if (Filename.Length < 1)
        return;
      DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(Filename));
      if (!directoryInfo.Exists)
        directoryInfo.Create();
      textWriter = (TextWriter) File.AppendText(Filename);
      string str = $"{Alarm.Axis} ; {Alarm.Text} ; {Alarm.ID.ToString()} ; {Alarm.Code.ToString()} ; {Alarm.Option.ToString()} ; {Alarm.Aux};{DateTime.Now.ToString()}{Environment.NewLine}";
      textWriter.Write(str);
      textWriter.Close();
    }
    catch (Exception ex)
    {
      string str = $"Filename : {Filename} - Alarm : {Alarm?.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
    finally
    {
      textWriter?.Close();
    }
  }

  public override string ToString() => $"Axis : {this.Axis} - {this.Text} =  {this.ID.ToString()}";
}
