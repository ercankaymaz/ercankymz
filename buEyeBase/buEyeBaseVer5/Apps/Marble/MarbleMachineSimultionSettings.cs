// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleMachineSimultionSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

public class MarbleMachineSimultionSettings : buSerilization5
{
  public static byte f00489A;
  public marbleCamPars settingMarbleCam;
  public marbleSawMillingPars settingSawMilling;
  public marbleSlicesPars settingSliceCut;
  public marbleProfileCutPars settingProfileCut;
  public marbleProfileCurveCutPars settingProfileCurveCut;
  public marbleAirDryPars settingAirDry;
  public marbleMatrialCleanPars settingMaterialClean;
  public marbleColoumsPars settingColoumnsCut;
  public marbleLathePars settingLatheCut;
  public marbleLatheVerticalPars settingLatheVerticalCut;
  public marbleChamferPars settingChamferCut;
  public marbleSweepPars settingSweepCut;
  public marbleDrillPars settingDrillCut;
  public marbleCavityPars settingCavity;
  public marbleTapPars settingTap;
  public marbleVacuumPars settingVacuum;
  public marbleMaterialPars MaterialParameter;
  public marbleCamSawFeedAnalysisPars SawFeedAnalysisParameter;
  public marbleReadSurfacePars ReadSurfaceParameter;
  public marbleEventPar settingEvent;
  public marbleSurfaceCleanPars settingSurfaceClean;
  public marbleCutRemainMaterial settingCutRemailMaterial;
  public List<MarbleOperationSequence> CuttingSequence;
  public static byte f0048B2;
  public List<Entity> SolidEntity;
  public List<Entity> SolidInsideEntity;
  public List<buEntity> TextEntities;
  public List<buEntity> DrawWireEntities;
  public List<buEntity> SourceEntities;
  public List<List<buEntity>> WireEntities;
  public List<buEntity> ExtensionEntities;
  public List<buEntity> EdgeEntities;
  public List<buEntity> EngravingEntities;
  public List<buEntity> BaseEntities;
  public List<buEntity> BorderEntities;
  public List<buEntity> DrillEntities;
  public List<buEntitiesGroup> SurfaceEntities;
  public List<buEntitiesGroup> GroupEntities;
  public List<List<buEntity>> ConcaveEntities;
  public List<List<buEntity>> ConvexEntities;
  public List<List<buEntity>> CamEntities;
  public List<List<buEntityList>> SawEntities;
  public List<List<buEntityList>> MillingEntities;
  public List<List<buEntityList>> WaterJetEntities;
  public List<List<buEntityList>> MillingHeadEntities;
  public static byte f0048C8;
  public Point3D ExtendPoint;
  public double ExtendLength;
  public int CamID;
  public int indexCam;
  public int indexWire;
  public int indexWireSub;
  public StartEndType Direction;
  public buEntity entityExtend;
  public static byte f0048D1;
  public string OperationName;
  public bool Enable;
  public bool IsExecuted;
  public bool isError;
  public new bool Visible;
  public int ID;

  public override string ToString()
  {
    return $"BigChangeGap: {((MarbleRuntimeSettings) this).BigChangeGap.ToString()} - SmallChangeGap: {((MarbleRuntimeSettings) this).SmallChangeGap.ToString()}";
  }
}
