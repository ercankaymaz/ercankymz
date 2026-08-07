// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleSelectionItems
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleSelectionItems
{
  public double OffsetCutBackwardFeed;
  public double OffsetSafeDis;
  public double OffsetAngleStep;
  public double OffsetMinZ;
  public double OffsetLeadIn;
  public double OffsetLeadOut;
  public double OffsetInsideOffset;
  public double OffsetOutsideOffset;
  public double OffsetEdgeOffset;
  public double OffsetZForwardDownStep;

  public MarbleSelectionItems(MarbleItemCam Cam, MarbleItem Item, int camIndex)
  {
    // ISSUE: unable to decompile the method.
  }
}
