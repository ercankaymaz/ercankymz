// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Robotic.RoboticRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.Robotic;

[Serializable]
public class RoboticRuntimeSettings : buSerilization5
{
  public const MarbleOperationSequence SawStraight = ; // Unable to render the field
  public const MarbleOperationSequence SawCircular = ; // Unable to render the field
  public const MarbleOperationSequence SawAngleCutStraight = ; // Unable to render the field
  public const MarbleOperationSequence CornerCleanByMilling = ; // Unable to render the field
  public const MarbleOperationSequence CornerCleanByDrill = ; // Unable to render the field
  public const MarbleOperationSequence MillingCuttings = ; // Unable to render the field

  public RoboticRuntimeSettings()
  {
    ((marbleSawMillingPars) this).ZoomMouseWheelReverse = false;
    ((marbleSawMillingPars) this).CNCViewportBottomColor = Color.LightGray;
    ((marbleSawMillingPars) this).CNCViewportMiddleColor = Color.WhiteSmoke;
    ((marbleSawMillingPars) this).CNCViewportTopColor = Color.LightGray;
    ((marbleSawMillingPars) this).CNCViewportDisplayType = DisplayModeType.Rendered;
    ((marbleSawMillingPars) this).CNCViewportProjection = ProjectionModeType.Orthographic;
    ((marbleSawMillingPars) this).CNCViewportShowCubeBox = true;
    ((marbleSawMillingPars) this).CNCViewportShowUcsArrow = true;
    ((marbleSawMillingPars) this).CNCViewportShowOrigineSembol = true;
    ((marbleSawMillingPars) this).CNCViewportShowMouseCoordinates = true;
    ((marbleSawMillingPars) this).CadCamViewportBottomColor = Color.LightGray;
    ((marbleSawMillingPars) this).CadCamViewportMiddleColor = Color.WhiteSmoke;
    ((marbleSawMillingPars) this).CadCamViewportTopColor = Color.LightGray;
    ((marbleSawMillingPars) this).CadCamViewportDisplayType = DisplayModeType.Rendered;
    ((marbleSawMillingPars) this).CadCamViewportProjection = ProjectionModeType.Orthographic;
    ((marbleSawMillingPars) this).CadCamViewportShowCubeBox = true;
    ((marbleSawMillingPars) this).CadCamViewportShowUcsArrow = true;
    ((marbleSawMillingPars) this).CadCamViewportShowOrigineSembol = true;
    ((marbleSawMillingPars) this).CadCamViewportShowMouseCoordinates = true;
    ((marbleSawMillingPars) this).DialogViewportBottomColor = Color.DarkGray;
    ((marbleSawMillingPars) this).DialogViewportMiddleColor = Color.Silver;
    ((marbleSawMillingPars) this).DialogViewportTopColor = Color.Gray;
    ((marbleSlicesPars) this).DialogViewportDisplayType = DisplayModeType.Rendered;
    ((marbleSlicesPars) this).DialogViewportProjection = ProjectionModeType.Orthographic;
    ((marbleSlicesPars) this).DialogViewportShowCubeBox = true;
    ((marbleSlicesPars) this).DialogViewportShowUcsArrow = true;
    ((marbleSlicesPars) this).DialogViewportShowOrigineSembol = true;
    ((marbleSlicesPars) this).DialogViewportShowMouseCoordinates = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public RoboticRuntimeSettings()
  {
    ((marbleSlicesPars) this).SolidTranperancy = 120;
    ((marbleSlicesPars) this).colorItemBase = (ColorType) new CircularSpeedReduction(Color.Gray, (int) byte.MaxValue);
    ((marbleSlicesPars) this).colorItem = (ColorType) new CircularSpeedReduction(Color.WhiteSmoke, (int) byte.MaxValue);
    ((marbleSlicesPars) this).colorItemContour = (ColorType) new CircularSpeedReduction(Color.WhiteSmoke, (int) byte.MaxValue);
    ((marbleSlicesPars) this).colorItemEngrave = (ColorType) new CircularSpeedReduction(Color.WhiteSmoke, (int) byte.MaxValue);
    ((marbleSlicesPars) this).colorItemInside = (ColorType) new CircularSpeedReduction(Color.Cyan, (int) byte.MaxValue);
    ((marbleSlicesPars) this).colorItemProfile = (ColorType) new CircularSpeedReduction(Color.WhiteSmoke, (int) byte.MaxValue);
    ((marbleSweepPars) this).colorItemProfileCurve = (ColorType) new CircularSpeedReduction(Color.WhiteSmoke, (int) byte.MaxValue);
    ((marbleSweepPars) this).colorItemLatheHorizontal = (ColorType) new CircularSpeedReduction(Color.WhiteSmoke, (int) byte.MaxValue);
    ((marbleSweepPars) this).colorItemLatheVertical = (ColorType) new CircularSpeedReduction(Color.WhiteSmoke, (int) byte.MaxValue);
    ((marbleSweepPars) this).colorItemColumn = (ColorType) new CircularSpeedReduction(Color.WhiteSmoke, (int) byte.MaxValue);
    ((marbleSweepPars) this).colorItemSweep = (ColorType) new CircularSpeedReduction(Color.WhiteSmoke, (int) byte.MaxValue);
    ((marbleSweepPars) this).colorItemHole = (ColorType) new CircularSpeedReduction(Color.WhiteSmoke, (int) byte.MaxValue);
    ((marbleSweepPars) this).colorItemText = (ColorType) new CircularSpeedReduction(Color.WhiteSmoke, (int) byte.MaxValue);
    ((marbleSweepPars) this).colorItemSlicesHorizontal = (ColorType) new CircularSpeedReduction(Color.WhiteSmoke, (int) byte.MaxValue);
    ((marbleSweepPars) this).colorItemSlicesVertical = (ColorType) new CircularSpeedReduction(Color.WhiteSmoke, (int) byte.MaxValue);
    ((marbleSweepPars) this).colorItemSingleCut = (ColorType) new CircularSpeedReduction(Color.WhiteSmoke, (int) byte.MaxValue);
    ((marbleChamferPars) this).colorItemMaterialClean = (ColorType) new CircularSpeedReduction(Color.WhiteSmoke, (int) byte.MaxValue);
    ((marbleChamferPars) this).colorItemAirDry = (ColorType) new CircularSpeedReduction(Color.WhiteSmoke, 100);
    ((marbleChamferPars) this).colorAngleText = (ColorType) new CircularSpeedReduction(Color.Red, (int) byte.MaxValue);
    ((marbleChamferPars) this).colorSequenceText = (ColorType) new CircularSpeedReduction(Color.Black, (int) byte.MaxValue);
    ((marbleChamferPars) this).colorMaterial = (ColorType) new CircularSpeedReduction(Color.Pink, 100);
    ((marbleVacuumPars) this).colorMaterialDimension = (ColorType) new CircularSpeedReduction(Color.Black, (int) byte.MaxValue);
    ((marbleVacuumPars) this).colorPartDimension = (ColorType) new CircularSpeedReduction(Color.Black, (int) byte.MaxValue);
    ((marbleVacuumPars) this).colorDirArrow = (ColorType) new CircularSpeedReduction(Color.Red, (int) byte.MaxValue);
    ((marbleLathePars) this).colorItemEdge = (ColorType) new CircularSpeedReduction(Color.Black, (int) byte.MaxValue);
    ((marbleLathePars) this).colorItemCollopse = (ColorType) new CircularSpeedReduction(Color.DeepPink, 160 /*0xA0*/);
    ((marbleLathePars) this).colorItemVacuumCutMaterial = (ColorType) new CircularSpeedReduction(Color.GreenYellow, (int) byte.MaxValue);
    ((marbleLathePars) this).colorItemVacuumCutEdge = (ColorType) new CircularSpeedReduction(Color.Red, (int) byte.MaxValue);
    ((marbleLathePars) this).colorText = (ColorDrawType) new EdgeFoundArgs(Color.Black, (int) byte.MaxValue, 1.0);
    ((marbleLathePars) this).colorItemWire = (ColorDrawType) new EdgeFoundArgs(Color.Green, (int) byte.MaxValue, 1.0);
    ((marbleLathePars) this).colorItemExtension = (ColorDrawType) new EdgeFoundArgs(Color.Black, (int) byte.MaxValue, 1.0);
    ((marbleLathePars) this).colorDirArrowSequence = (ColorDrawType) new EdgeFoundArgs(Color.Black, (int) byte.MaxValue, 3.0);
    ((marbleLatheVerticalPars) this).colorCamG0 = (ColorDrawType) new EdgeFoundArgs(Color.Blue, (int) byte.MaxValue, 1.0);
    ((marbleLatheVerticalPars) this).colorCamG1 = (ColorDrawType) new EdgeFoundArgs(Color.Red, (int) byte.MaxValue, 1.0);
    ((marbleLatheVerticalPars) this).colorCamPlunge = (ColorDrawType) new EdgeFoundArgs(Color.Orange, (int) byte.MaxValue, 1.0);
    ((marbleLatheVerticalPars) this).colorCamLeave = (ColorDrawType) new EdgeFoundArgs(Color.DarkRed, (int) byte.MaxValue, 1.0);
    ((marbleLatheVerticalPars) this).colorCamConnection = (ColorDrawType) new EdgeFoundArgs(Color.Purple, (int) byte.MaxValue, 1.0);
    ((marbleLatheVerticalPars) this).colorCamLeadInOut = (ColorDrawType) new EdgeFoundArgs(Color.Orange, (int) byte.MaxValue, 1.0);
    ((marbleDrillPars) this).colorCamDraw = (ColorDrawType) new EdgeFoundArgs(Color.DarkOliveGreen, (int) byte.MaxValue, 2.0);
    ((marbleDrillPars) this).colorVacuum = (ColorDrawType) new EdgeFoundArgs(Color.Orange, (int) byte.MaxValue, 2.0);
    ((marbleDrillPars) this).colorCutSaw = (ColorDrawType) new EdgeFoundArgs(Color.Red, (int) byte.MaxValue, 1.0);
    ((marbleDrillPars) this).colorCutMilling = (ColorDrawType) new EdgeFoundArgs(Color.Blue, (int) byte.MaxValue, 1.0);
    ((marbleDrillPars) this).colorCutMillingHead = (ColorDrawType) new EdgeFoundArgs(Color.Green, (int) byte.MaxValue, 1.0);
    ((marbleDrillPars) this).colorCutWaterjet = (ColorDrawType) new EdgeFoundArgs(Color.Cyan, (int) byte.MaxValue, 1.0);
    ((marbleDrillPars) this).colorCutSaw45 = (ColorDrawType) new EdgeFoundArgs(Color.DarkRed, (int) byte.MaxValue, 1.0);
    ((marbleDrillPars) this).colorViewportGrid = (ColorType) new CircularSpeedReduction(Color.Black, (int) byte.MaxValue);
    ((marbleDrillPars) this).colorControlEnable = (ColorType) new CircularSpeedReduction(Color.Lime, (int) byte.MaxValue);
    ((marbleDrillPars) this).colorControlDisable = (ColorType) new CircularSpeedReduction(Color.Red, (int) byte.MaxValue);
    ((marbleDrillPars) this).colorControlselected = (ColorType) new CircularSpeedReduction(Color.Gold, (int) byte.MaxValue);
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
