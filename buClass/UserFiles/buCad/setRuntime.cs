// Decompiled with JetBrains decompiler
// Type: buClass.UserFiles.buCad.setRuntime
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass.UserFiles.buCad;

[Serializable]
public class setRuntime : buSerilization
{
  public string FormSkin = "Office 2007 Black";
  public int Language = 0;
  public int MetricUnit = 0;
  public int MachineID = 0;
  public string ReleaseVer = "0";
  public string CustomerName = "";

  public override string ToString()
  {
    return $"Lang:{this.Language.ToString()} - MAchineID: {this.MachineID.ToString()}";
  }
}
