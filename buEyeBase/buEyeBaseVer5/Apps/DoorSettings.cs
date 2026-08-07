// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DoorSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buClipperLib;
using System;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DoorSettings : buSerilization5
{
  public bool DontUseForCalculation;
  public string ID;
  public string Command;
  public int EntityIndex;
  public int EntitySubIndex;
  public int ItemID;
  public int EdgeID;

  public override bool Equals(object obj)
  {
    return obj != null && obj is IntPoint intPoint && ((DoorRuntimeSettings) this).X == intPoint.X && ((DoorRuntimeSettings) this).Y == intPoint.Y;
  }

  public override int GetHashCode()
  {
    // ISSUE: unable to decompile the method.
  }
}
