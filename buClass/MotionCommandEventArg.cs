// Decompiled with JetBrains decompiler
// Type: buClass.MotionCommandEventArg
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;

#nullable disable
namespace buClass;

public class MotionCommandEventArg
{
  public MotionCommands Command = MotionCommands.None;
  public string Message = "";
  public double Val = 0.0;
  public List<string> ErrorList = new List<string>();

  public MotionCommandEventArg()
  {
  }

  public MotionCommandEventArg(MotionCommands cmd, string message, double val)
  {
    this.Command = cmd;
    this.Message = message;
    this.Val = val;
  }

  public override string ToString() => $"Command =  {this.Command.ToString()} - {this.Message}";
}
