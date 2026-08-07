// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.RollerBendSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class RollerBendSettings : buSerilization5
{
  public bool XMove;
  public bool YMove;
  public bool ZMove;
  public bool ARotation;
  public bool BRotation;
  public bool CRotation;
  public bool ARotation2;
  public bool BRotation2;
  public bool CRotation2;
  public string Tag;
  public int No;
  public int HeadNumber;

  [CompilerGenerated]
  [SpecialName]
  public string get_Command() => ((Router3AXTempVars) this).\u0008;

  [CompilerGenerated]
  [SpecialName]
  public void set_Command(string value) => ((Router3AXTempVars) this).\u0008 = value;
}
