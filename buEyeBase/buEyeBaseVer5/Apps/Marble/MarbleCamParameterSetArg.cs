// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleCamParameterSetArg
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleCamParameterSetArg
{
  public double RoughTopOffset;
  public double RoughBottomOffset;
  public double RoughInsideOffset;
  public double RoughOutsideOffset;
  public double RoughZForwardDownStep;
  public double RoughStepover;
  public bool RoughEnable;
  public bool RoughMoveUpSafeDistance;
  public bool RoughZigzagMode;
  public bool RoughPerpendicularA;
  public bool RoughReverseCAngle;
  public MarbleCamAreaMode RoughAreaMode;
  public double OffsetPlungeFeed;
  public double OffsetCutForwardFeed;

  public abstract void m001FD5();

  public MarbleCamParameterSetArg()
  {
    // ISSUE: unable to decompile the method.
  }
}
