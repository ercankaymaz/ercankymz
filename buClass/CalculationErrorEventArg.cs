// Decompiled with JetBrains decompiler
// Type: buClass.CalculationErrorEventArg
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

public class CalculationErrorEventArg
{
  public bool ShowMessageBox = false;
  public string Job = "";
  public string SubJob = "";
  public int ID = 0;
  public string Method = "";
  public string Message = "";
  public string Status = "";
  public Exception Exceptions = (Exception) null;

  public CalculationErrorEventArg()
  {
  }

  public CalculationErrorEventArg(string method, string job, string subjob, int id)
  {
    this.Job = job;
    this.SubJob = subjob;
    this.ID = id;
    this.Method = method;
  }

  public CalculationErrorEventArg(
    bool showmessage,
    string method,
    string message,
    string status,
    string job,
    string subjob,
    int id,
    Exception ee)
  {
    this.ShowMessageBox = showmessage;
    this.Job = job;
    this.SubJob = subjob;
    this.ID = id;
    this.Method = method;
    this.Message = message;
    this.Exceptions = ee;
    this.Status = status;
  }

  public override string ToString()
  {
    return $"{this.Method} = [ {this.Job} - {this.SubJob} ]  , ID : {this.ID.ToString()}";
  }
}
