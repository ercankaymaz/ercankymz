// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Point3DList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class Point3DList
{
  public bool G1EntitiesEnable;
  public bool LeaveEntitiesEnable;

  public override string ToString()
  {
    return $"Min Rad: {((ToolBase5) this).MinRadius.ToString("f2")} - Max Rad: {((ToolBase5) this).MaxRadius.ToString("f2")} - Feed: {((ToolBase5) this).Feed.ToString("f2")}";
  }

  public abstract void m000169();
}
