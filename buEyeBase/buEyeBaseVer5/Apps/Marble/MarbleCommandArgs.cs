// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleCommandArgs
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleCommandArgs
{
  public double TapRightXOffset;
  public double TapRightYOffset;
  public bool LeftEnable;
  public bool RightEnable;

  static MarbleCommandArgs() => marbleProfileCutPars.Captions = new List<string>();
}
