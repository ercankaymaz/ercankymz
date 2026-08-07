// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleImageThicknessData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleImageThicknessData : buSerilization5
{
  public double TapRightDiameter;
  public double TapDepth;
  public double TapLeftDepth;
  public double TapRightDepth;
  public double TapLeftXOffset;
  public double TapLeftYOffset;

  public override string ToString() => "";

  public abstract void m001FE0();

  public MarbleImageThicknessData()
  {
    ((marbleProfileCurveCutPars) this).ContourDeviationResolution = 0.05;
    ((marbleProfileCurveCutPars) this).LatheDeviationResolution = 0.05;
    ((marbleProfileCurveCutPars) this).ColumnsDeviationResolution = 0.05;
    ((marbleProfileCurveCutPars) this).EngravingDeviationResolution = 0.05;
    ((marbleProfileCurveCutPars) this).ProfileDeviationResolution = 0.05;
    ((marbleProfileCurveCutPars) this).SweepDeviationResolution = 0.05;
    ((marbleProfileCurveCutPars) this).SolidDeviationResolution = 0.05;
    ((marbleProfileCurveCutPars) this).DimensionColor = Color.Lime;
    ((marbleProfileCurveCutPars) this).DimensionThickness = 3.0;
    ((marbleProfileCurveCutPars) this).DimensionTextHeight = 30.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
