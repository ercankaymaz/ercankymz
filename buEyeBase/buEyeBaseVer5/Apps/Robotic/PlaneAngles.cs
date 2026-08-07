// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Robotic.PlaneAngles
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.Robotic;

[Serializable]
public class PlaneAngles : buSerilization5
{
  public const MarbleOperationSelectionCommand Cam = ; // Unable to render the field
  public const MarbleOperationSelectionCommand Panel = ; // Unable to render the field
  public const MarbleOperationSelectionCommand EdgeOutside = ; // Unable to render the field

  public override string ToString()
  {
    return $"PixelToMmX: {((marbleSurfaceCleanPars) this).PixelToMmX.ToString()} - PixelToMmY: {((marbleSurfaceCleanPars) this).PixelToMmY.ToString()}";
  }

  static PlaneAngles() => marbleSurfaceCleanPars.Captions = new List<string>();

  public PlaneAngles()
  {
    ((marbleSurfaceCleanPars) this).CountertopSlatOffset = 0.0;
    ((marbleMillingAnalyzePars) this).CountertopRotation = 0.0;
    ((marbleMillingAnalyzePars) this).CountertopRadius = 0.0;
    ((marbleMillingAnalyzePars) this).CountertopChamfer = 0.0;
    ((marbleGCodeCreateOptions) this).CountertopRectangleWidth = 1000.0;
    ((marbleGCodeCreateOptions) this).CountertopRectangleHeight = 600.0;
    ((marbleGCodeCreateOptions) this).CountertopLWidth = 1500.0;
    ((marbleCamSawFeedAnalysisPars) this).CountertopLHeight = 800.0;
    ((marbleCamSawFeedAnalysisPars) this).CountertopLTopLegWidth = 300.0;
    ((marbleCamSawFeedAnalysisPars) this).CountertopLBottomLegHeight = 300.0;
    ((marbleCamSawFeedAnalysisPars) this).CountertopTrapezTopWidth = 1800.0;
    ((marbleCamSawFeedAnalysisPars) this).CountertopTrapezBottomWidth = 2000.0;
    ((marbleMaterialPars) this).CountertopTrapezHeight = 2000.0;
    ((marbleMaterialPars) this).SocketDefaultWidth = 80.0;
    ((marbleMaterialPars) this).SocketDefaultHeight = 80.0;
    ((marbleMaterialPars) this).InsideAngleCutOnTopAsSize = true;
    ((marbleMaterialPars) this).DimensionFromCenter = false;
    ((marbleMaterialPars) this).ShowInsideDimensions = true;
    ((marbleReadSurfacePars) this).ShowInsideLocations = true;
    ((marbleReadSurfacePars) this).ShowInsideAngleText = true;
    ((marbleReadSurfacePars) this).ShowOutsideDimensions = true;
    ((marbleStepAnsFeedForCircular) this).ShowOutsideAngleText = true;
    ((marbleStepAnsFeedForCircular) this).ShowSlatAngleText = true;
    ((marbleStepAnsFeedForCircular) this).ShowAngleSolid = false;
    ((marbleStepAnsFeedForCircular) this).ShowChamferSolid = true;
    ((marbleStepAnsFeedForCircular) this).CollapseAs3DOnMain = false;
    ((marbleCounterTopBase) this).Collapseas3DWihDifferentColor = true;
    ((marbleCounterTopBase) this).CollopseSharpCorner = true;
    ((marbleCounterTopBase) this).colorAngleSolid = Color.LightBlue;
    ((marbleCounterTopBase) this).colorAnglePlane = Color.LimeGreen;
    ((marbleCounterTopBase) this).colorChamferTopPlane = Color.Magenta;
    ((marbleCounterTopBase) this).colorChamferBottomPlane = Color.Magenta;
    ((marbleCounterTopBase) this).colorChamferTopSolid = Color.MediumPurple;
    ((marbleCounterTopBase) this).colorChamferBottomSolid = Color.MediumPurple;
    ((marbleCounterTopItem) this).colorMainAngleText = Color.Black;
    ((marbleCounterTopItem) this).colorMainDimension = Color.Black;
    ((marbleCounterTopParameter) this).colorSinkAngle = Color.Green;
    ((marbleCounterTopParameter) this).colorSinkDimension = Color.Blue;
    ((marbleCounterTopParameter) this).colorSinkLoction = Color.Orange;
    ((marbleCounterTopParameter) this).colorBuiltInngle = Color.Green;
    ((marbleCounterTopParameter) this).colorBuiltInDimension = Color.BlueViolet;
    ((marbleCounterTopParameter) this).colorBuiltInLocation = Color.Orange;
    ((marbleCounterTopPars) this).colorSocketAngle = Color.Green;
    ((marbleCounterTopPars) this).colorSocketDimension = Color.DarkBlue;
    ((marbleCounterTopPars) this).colorSocketLoction = Color.Orange;
    ((marbleCounterTopPars) this).colorTapAngle = Color.Green;
    ((marbleCounterTopPars) this).colorTapDimension = Color.DarkSlateBlue;
    ((marbleCounterTopPars) this).colorTapLoction = Color.Orange;
    ((marbleCounterTopPars) this).colorCavitySolid = Color.Gray;
    ((marbleCounterTopPars) this).colorCavityAngle = Color.Green;
    ((marbleCounterTopPars) this).colorCavityDimension = Color.DarkSlateBlue;
    ((marbleCounterTopPars) this).colorCavityLoction = Color.Orange;
    ((marbleCounterTopPars) this).colorSlatAngle = Color.Green;
    ((marbleCounterTopPars) this).colorCollapse = Color.Cyan;
    ((marbleCounterTopPars) this).MainData = (marbleCountertopMainData) new \u0007.\u0001();
    ((marbleCounterTopPars) this).SinkFirstData = (marbleCountertopInsideData) new \u0007.\u0001();
    ((marbleCounterTopPars) this).SinkSecondData = (marbleCountertopInsideData) new \u0007.\u0001();
    ((marbleCounterTopPars) this).BuiltInFirstData = (marbleCountertopInsideData) new \u0007.\u0001();
    ((marbleCounterTopPars) this).BuiltInSecondData = (marbleCountertopInsideData) new \u0007.\u0001();
    ((marbleCounterTopPars) this).SocketFirstData = (marbleCountertopInsideData) new \u0007.\u0001();
    ((marbleCounterTopPars) this).SocketSecondData = (marbleCountertopInsideData) new \u0007.\u0001();
    ((marbleCollapseItem) this).TapFirstData = (marbleCountertopTapData) new \u0007.\u0001();
    ((marbleCollapseItem) this).TapSecondData = (marbleCountertopTapData) new \u0007.\u0001();
    ((marbleCollapseItem) this).TapThirdData = (marbleCountertopTapData) new \u0007.\u0001();
    ((marbleCollapseItem) this).TapFourthData = (marbleCountertopTapData) new \u0007.\u0001();
    ((marbleCollapseItem) this).CavityFirstData = (marbleCountertopCavityData) new \u0007.\u0001();
    ((marbleCollapseItem) this).CavitySecondData = (marbleCountertopCavityData) new \u0007.\u0001();
    ((marbleCollapseItem) this).SlatData = (marbleSlatData) new \u0007.\u0001();
    ((marbleCollapseItem) this).ChamferEdgeData = (marbleChamferBothSideData) new \u0007.\u0001();
    ((marbleCollapseItem) this).ChamferSlatData = (marbleChamferBothSideData) new \u0007.\u0001();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
