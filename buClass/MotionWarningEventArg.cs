// Decompiled with JetBrains decompiler
// Type: buClass.MotionWarningEventArg
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

public class MotionWarningEventArg
{
  public bool ShowMessageBox = false;
  public string Command = "";
  public string SubCommand = "";
  public int ID = 0;
  public string Method = "";
  public string Message = "";
  public string Status = "";
  public Exception Exceptions = (Exception) null;

  public MotionWarningEventArg()
  {
  }

  public MotionWarningEventArg(string method, string cmd, string subcmd, int id)
  {
    this.Command = cmd;
    this.SubCommand = subcmd;
    this.ID = id;
    this.Method = method;
  }

  public MotionWarningEventArg(
    bool showmessage,
    string method,
    string message,
    string status,
    string cmd,
    string subcmd,
    int id,
    Exception ee)
  {
    this.ShowMessageBox = showmessage;
    this.Command = cmd;
    this.SubCommand = subcmd;
    this.ID = id;
    this.Method = method;
    this.Message = message;
    this.Exceptions = ee;
    this.Status = status;
  }

  public override string ToString()
  {
    return $"{this.Method} = [ {this.Command} - {this.SubCommand} ]  , ID : {this.ID.ToString()} - Mes: {this.Message}";
  }
}
