// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCountertopCavityData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Components;
using buEyeBaseVer5.Apps.Robotic;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopCavityData : buSerilization5
{
  public bool Copy;
  public double Radius;
  public double StartAngle;
  public double SweepAngle;
  public double BaseHeight;
  public double RoughPlungeFeed;
  public double RoughCutForwardFeed;
  public double RoughCutBackwardFeed;
  public double RoughSafeDis;
  public double RoughRapid;
  public double RoughAngleStep;
  public double RoughSurfOffset;
  public double RoughVerticalDevideLen;

  public void convOperationParameterToEntityDataParameter(
    marbleCamPars OPPars,
    MarbleToolType ToolType,
    ref marbleEntityData EntityDataPar)
  {
    // ISSUE: unable to decompile the method.
  }

  static marbleCountertopCavityData()
  {
    MarbleRuntimeSettings.varOperation = (MarbleItemSettings) new buLogMarbleVer5();
    MarbleRuntimeSettings.varMarbleMachineSettings = (MarbleMachineSettings) new buRoboticCalc();
    MarbleRuntimeSettings.varMarbleSettings = (MarbleProgramSettings) new MarbleCommandHandler();
    MarbleRuntimeSettings.varMarbleRunSettings = (MarbleRuntimeSettings) new MarbleSawCalcParameters();
    MarbleEntitiesSettings.varMarbleDisplaySettings = (MarbleDisplaySettings) new buEyeBaseVer5.Apps.Robotic.DoorJob();
    MarbleEntitiesSettings.varMarbleColorSettings = (MarbleColorSettings) new RoboticRuntimeSettings();
    MarbleEntitiesSettings.varMarbleControlColorSettings = (MarbleControlColorSettings) new RobotToolPath();
    MarbleEntitiesSettings.varMarbleEntitiesSettings = (MarbleEntitiesSettings) new MarbleImageThicknessData();
    MarbleEntitiesSettings.varMarbleDrawSettings = (MarbleDrawingSetting) new RobotPose();
    MarbleEntitiesSettings.varImageSettings = (MarbleImageSettings) new EulerAngles();
    MarbleEntitiesSettings.varCountertopSettings = (MarbleCountertopSettings) new PlaneAngles();
    MarbleEntitiesSettings.varCountertopParameter = (marbleCounterTopParameter) new \u0007.\u0001();
    MarbleEntitiesSettings.CircularShapeResolutions = new List<GeometryTableItem>();
    MarbleEntitiesSettings.CircularSpeedReductions = new List<CircularSpeedReduction>();
    MarbleEntitiesSettings.runCountertopData = (marbleCounterTopPars) new \u0007.\u0001();
    MarbleProgramSettings.pntTeachGrids = new List<List<Pnt3D>>();
    MarbleProgramSettings.SelectedItem = (MarbleSelection) new \u0007.\u0001();
    MarbleProgramSettings.activeToolSaw = (ToolBase5) new ToolGeometry5();
    MarbleProgramSettings.activeToolMilling = (ToolBase5) new ToolGeometry5();
    MarbleProgramSettings.activeToolMillingHead = (ToolBase5) new ToolGeometry5();
    MarbleProgramSettings.activeToolWaterjet = (ToolBase5) new ToolGeometry5();
    MarbleProgramSettings.activeToolAirDry = (ToolBase5) new ToolGeometry5();
    MarbleProgramSettings.activeToolLaserPointer = (ToolBase5) new ToolGeometry5();
    MarbleProgramSettings.ToolInMagazine = (List<ToolBase5>) null;
    MarbleProgramSettings.ToolMillings = (List<ToolBase5>) null;
    MarbleProgramSettings.ToolMillingHeads = (List<ToolBase5>) null;
    MarbleProgramSettings.ToolSaws = (List<ToolBase5>) null;
    MarbleProgramSettings.activeCountertop = (marbleCounterTopBase) null;
    MarbleProgramSettings.activeCountertopItem = (marbleCounterTopItem) new \u0007.\u0001();
    MarbleProgramSettings.activeCountertopEdge = (marbleEdgeItem) new \u0007.\u0001();
    MarbleProgramSettings.activeCountertopCorner = (marbleCountertopCornerPars) new \u0007.\u0001();
    MarbleProgramSettings.newCountertopItem = (marbleCounterTopItem) new \u0007.\u0001();
    MarbleProgramSettings.CountertopRefEntGroup = (buEntitiesGroup) null;
    MarbleProgramSettings.UndoJobList = new List<MarbleJob>();
    MarbleProgramSettings.UndoList = new List<List<MarbleItem>>();
    MarbleProgramSettings.MaterialList = new List<marbleMaterialType>();
    MarbleProgramSettings.CountertopEdgeControl = (buEnableTwoValueList) null;
  }

  static marbleCountertopCavityData()
  {
    MarbleProgramSettings.\u003C\u003E9 = (buMarbleCalc.\u003C\u003Ec) new marbleSlatData();
  }
}
