// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleMenuType
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleMenuType : buSerilization5
{
  public double FinishLeadOutAngle;
  public double FinishTopOffset;
  public double FinishBottomOffset;
  public double FinishInsideOffset;
  public double FinishOutsideOffset;
  public bool FinishEnable;
  public bool FinishZigzagMode;
  public bool FinishPerpendicularA;
  public bool FinishReverseCAngle;
  public bool FinishMoveUpSafe;
  public bool FinishExecuteVerticalWalls;
  public bool Finish5Axis;
  public double OffsetPlungeFeed;
  public double OffsetCutForwardFeed;
  public double OffsetCutBackwardFeed;
  public double OffsetSafeDis;
  public double OffsetAngleStep;
  public double OffsetMinZ;
  public double OffsetLeadInAngle;

  public abstract void m001FB1();

  public marbleMenuType()
  {
    // ISSUE: unable to decompile the method.
  }

  public marbleMenuType(MarbleItemCam data)
  {
    // ISSUE: unable to decompile the method.
  }
}
