// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Robotic.ComauPose
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Robotic;

[Serializable]
public class ComauPose : RobotPose
{
  public static void Copy(MarbleDrawingSetting Source, ref MarbleDrawingSetting Target)
  {
    Target = (MarbleDrawingSetting) new RobotPose(Source);
  }

  public override string ToString() => "";

  static ComauPose() => marbleSurfaceCleanPars.Captions = new List<string>();
}
