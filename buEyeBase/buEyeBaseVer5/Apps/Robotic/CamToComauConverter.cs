// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Robotic.CamToComauConverter
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Robotic;

public class CamToComauConverter
{
  public bool isRough;

  public static void Copy(MarbleMachineSettings Source, ref MarbleMachineSettings Target)
  {
    Target = (MarbleMachineSettings) new buRoboticCalc(Source);
  }

  public override string ToString()
  {
    return "BaseWoodZOffset: " + ((marbleProfileCutPars) this).BaseWoodZOffset.ToString();
  }

  static CamToComauConverter() => marbleProfileCutPars.Captions = new List<string>();

  public CamToComauConverter()
  {
    // ISSUE: unable to decompile the method.
  }

  public abstract void m001FF6();

  public CamToComauConverter()
  {
    ((marbleTapPars) this).DrawHead = true;
    ((marbleTapPars) this).DrawMachine = false;
    ((marbleTapPars) this).DrawLathe = false;
    ((marbleTapPars) this).DrawSawTool = true;
    ((marbleTapPars) this).DrawMillingTool = true;
    ((marbleTapPars) this).DrawMilling5AxisTool = true;
    ((marbleTapPars) this).DrawMillingHeadTool = true;
    ((marbleTapPars) this).DrawAirDry = false;
    ((marbleColoumsPars) this).DrawLaserPointer = false;
    ((marbleColoumsPars) this).DrawWaterjet = false;
    ((marbleColoumsPars) this).DrawAllTool = true;
    ((marbleColoumsPars) this).DrawSawToolForMillingHeadOperation = false;
    ((marbleColoumsPars) this).MovePartFromKinematicDistances = true;
    ((marbleColoumsPars) this).SimACAxesZDistance = 0.0;
    ((marbleColoumsPars) this).SimDrawCommonOffsetX = 0.0;
    ((marbleColoumsPars) this).SimDrawCommonOffsetY = 0.0;
    ((marbleColoumsPars) this).SimDrawCommonOffsetZ = 0.0;
    ((marbleSawMillingPars) this).SimDrawMillingToolOffsetX = 0.0;
    ((marbleSawMillingPars) this).SimDrawMillingToolOffsetY = 0.0;
    ((marbleSawMillingPars) this).SimDrawMillingToolOffsetZ = 0.0;
    ((marbleSawMillingPars) this).SimDrawSpindleOffsetX = 0.0;
    ((marbleSawMillingPars) this).SimDrawSpindleOffsetY = 0.0;
    ((marbleSawMillingPars) this).SimDrawSpindleOffsetZ = 0.0;
    ((marbleSawMillingPars) this).SimSpindleG54OffsetZ = 0.0;
    ((marbleSawMillingPars) this).SimDrawAirDryOffsetX = 0.0;
    ((marbleSawMillingPars) this).SimDrawAirDryOffsetY = 0.0;
    ((marbleSawMillingPars) this).SimDrawAirDryOffsetZ = 0.0;
    ((marbleSawMillingPars) this).SimDrawLaserPointerOffsetX = 0.0;
    ((marbleSawMillingPars) this).SimDrawLaserPointerOffsetY = 0.0;
    ((marbleSawMillingPars) this).SimDrawLaserPointerOffsetZ = 0.0;
    ((marbleSawMillingPars) this).SimDrawWaterjetOffsetX = 0.0;
    ((marbleSawMillingPars) this).SimDrawWaterjetOffsetY = 0.0;
    ((marbleSawMillingPars) this).SimDrawWaterjetOffsetZ = 0.0;
    ((marbleSawMillingPars) this).ExternalMillingSpindleStroke = 0.0;
    ((marbleSawMillingPars) this).SimDrawMillingHeadToolXOffset = 0.0;
    ((marbleSawMillingPars) this).SimDrawMillingHeadToolYOffset = 0.0;
    ((marbleSawMillingPars) this).SimDrawMillingHeadToolZOffset = 0.0;
    ((marbleSawMillingPars) this).SimCalcMillingToolXOffset = 0.0;
    ((marbleSawMillingPars) this).SimCalcMillingToolYOffset = 0.0;
    ((marbleSawMillingPars) this).SimCalcMillingToolZOffset = 0.0;
    ((marbleSawMillingPars) this).SimCalcMillingHeadToolXOffset = 0.0;
    ((marbleSawMillingPars) this).SimCalcMillingHeadToolYOffset = 0.0;
    ((marbleSawMillingPars) this).SimCalcMillingHeadToolZOffset = 0.0;
    ((marbleSawMillingPars) this).SimCalcLaserPointerToolXOffset = 0.0;
    ((marbleSawMillingPars) this).SimCalcLaserPointerToolYOffset = 0.0;
    ((marbleSawMillingPars) this).SimCalcLaserPointerToolZOffset = 0.0;
    ((marbleSawMillingPars) this).SimCalcAirDryToolXOffset = 0.0;
    ((marbleSawMillingPars) this).SimCalcAirDryToolYOffset = 0.0;
    ((marbleSawMillingPars) this).SimCalcAirDryToolZOffset = 0.0;
    ((marbleSawMillingPars) this).SimCalcWaterjetToolXOffset = 0.0;
    ((marbleSawMillingPars) this).SimCalcWaterjetToolYOffset = 0.0;
    ((marbleSawMillingPars) this).SimCalcWaterjetToolZOffset = 0.0;
    ((marbleSawMillingPars) this).SimulatioOnlineMoveXOffset = 0.0;
    ((marbleSawMillingPars) this).SimulatioOnlineMoveYOffset = 0.0;
    ((marbleSawMillingPars) this).SimulatioOnlineMoveZOffset = 0.0;
    ((marbleSawMillingPars) this).SimulatioOfflineMoveXOffset = 0.0;
    ((marbleSawMillingPars) this).SimulatioOfflineMoveYOffset = 0.0;
    ((marbleSawMillingPars) this).SimulatioOfflineMoveZOffset = 0.0;
    ((marbleSawMillingPars) this).OnlineSimulation = true;
    ((marbleSawMillingPars) this).SimInterval = 20;
    ((marbleSawMillingPars) this).SimulationG0DevideLength = 50.0;
    ((marbleSawMillingPars) this).SimulationG1DevideLength = 20.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public CamToComauConverter()
  {
    ((marbleSawMillingPars) this).LatheXOffset = 3600.0;
    ((marbleSawMillingPars) this).LatheYOffset = 2500.0;
    ((marbleSawMillingPars) this).LatheZOffset = 0.0;
    ((marbleSawMillingPars) this).LatheGCodeXOffset = -3600.0;
    ((marbleSawMillingPars) this).LatheGCodeYOffset = -2500.0;
    ((marbleSawMillingPars) this).LatheGCodeZOffset = 0.0;
    ((marbleSawMillingPars) this).LatheLeftRightSideDistance = 3620.0;
    ((marbleSawMillingPars) this).LathePosition = LeftRightType.Left;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
