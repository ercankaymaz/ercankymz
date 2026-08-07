// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.GCodeResult5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class GCodeResult5 : buSerilization5
{
  public string SceneName;
  public string ActionName;

  public override string ToString()
  {
    return $"LeadInLength: {((ShapeRuntimeData) this).LeadInLength.ToString()} , LeadOutLength: {((ShapeRuntimeData) this).LeadOutLength.ToString()}";
  }
}
