// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.WoodSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class WoodSettings : buSerilization5
{
  public double NickFinishDepth;
  public double NickRoughVel;
  public double NickFinishVel;
  public double NickRoughSpindleSpeed;
  public double NickFinishSpindleSpeed;
  public int NickToolNo;
  public bool NickEnable;
  public bool NickReverseDir;
  public bool VShapeAngleEnable;

  static WoodSettings()
  {
    WoodItemType.LangCutterStatus = new List<string>();
    WoodItemType.LangCutterMessage = new List<string>();
    WoodItemType.LangCutterCaptions = new List<string>();
  }
}
