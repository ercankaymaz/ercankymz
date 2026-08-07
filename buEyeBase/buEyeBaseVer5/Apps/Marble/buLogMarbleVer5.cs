// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.buLogMarbleVer5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class buLogMarbleVer5
{
  public double TwistEndAngle;
  public double TwisStepAngle;
  public CamAxisCountType CamTypeRough;
  public CamAxisCountType CamTypeFinish;
  public static List<string> Captions;
  public static byte f004D13;
  public double Length;
  public double StartPosition;
  public double BaseHeight;

  public static void Decode(List<string> SL, ref MarbleVacuumCut refItem)
  {
    try
    {
      refItem = (MarbleVacuumCut) new DeleteEntitiesType();
      buSerilization5.Decode(SL, "", (SerilizationMode5) 1, (object) refItem);
      List<List<string>> stringListList = new List<List<string>>();
      List<string> stringList = new List<string>();
    }
    catch (Exception ex)
    {
    }
  }

  public static void Decode(List<string> SL, ref List<MarbleVacuumCut> refItes)
  {
    try
    {
      refItes = new List<MarbleVacuumCut>();
      if (SL.Count <= 0)
        return;
      List<List<string>> CalcList = new List<List<string>>();
      buStatics.ListToSpecificList("<MarbleVacuumCut>", "</MarbleVacuumCut>", true, SL, ref CalcList);
      if (CalcList.Count <= 0)
        return;
      for (int index = 0; index <= CalcList.Count - 1; ++index)
      {
        MarbleVacuumCut refItem = (MarbleVacuumCut) new DeleteEntitiesType();
        buLogMarbleVer5.Decode(CalcList[index], ref refItem);
        refItes.Add(refItem);
        CalcList[index].Clear();
      }
      CalcList.Clear();
    }
    catch (Exception ex)
    {
    }
  }

  public override string ToString()
  {
    return $"Start: {((MarbleMachineOptionsSettings) this).StartPoint.ToString()} , End: {((MarbleMachineOptionsSettings) this).EndPoint.ToString()}";
  }

  public abstract void m001FC2();

  public buLogMarbleVer5()
  {
    ((MarbleMachineSimultionSettings) this).settingMarbleCam = (marbleCamPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingSawMilling = (marbleSawMillingPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingSliceCut = (marbleSlicesPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingProfileCut = (marbleProfileCutPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingProfileCurveCut = (marbleProfileCurveCutPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingAirDry = (marbleAirDryPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingMaterialClean = (marbleMatrialCleanPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingColoumnsCut = (marbleColoumsPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingLatheCut = (marbleLathePars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingLatheVerticalCut = (marbleLatheVerticalPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingChamferCut = (marbleChamferPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingSweepCut = (marbleSweepPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingDrillCut = (marbleDrillPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingCavity = (marbleCavityPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingTap = (marbleTapPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingVacuum = (marbleVacuumPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).MaterialParameter = (marbleMaterialPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).SawFeedAnalysisParameter = (marbleCamSawFeedAnalysisPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).ReadSurfaceParameter = (marbleReadSurfacePars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingEvent = (marbleEventPar) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingSurfaceClean = (marbleSurfaceCleanPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingCutRemailMaterial = (marbleCutRemainMaterial) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).CuttingSequence = new List<MarbleOperationSequence>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buLogMarbleVer5(MarbleItemSettings data)
  {
    ((MarbleMachineSimultionSettings) this).settingMarbleCam = (marbleCamPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingSawMilling = (marbleSawMillingPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingSliceCut = (marbleSlicesPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingProfileCut = (marbleProfileCutPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingProfileCurveCut = (marbleProfileCurveCutPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingAirDry = (marbleAirDryPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingMaterialClean = (marbleMatrialCleanPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingColoumnsCut = (marbleColoumsPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingLatheCut = (marbleLathePars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingLatheVerticalCut = (marbleLatheVerticalPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingChamferCut = (marbleChamferPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingSweepCut = (marbleSweepPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingDrillCut = (marbleDrillPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingCavity = (marbleCavityPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingTap = (marbleTapPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingVacuum = (marbleVacuumPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).MaterialParameter = (marbleMaterialPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).SawFeedAnalysisParameter = (marbleCamSawFeedAnalysisPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).ReadSurfaceParameter = (marbleReadSurfacePars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingEvent = (marbleEventPar) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingSurfaceClean = (marbleSurfaceCleanPars) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).settingCutRemailMaterial = (marbleCutRemainMaterial) new \u0007.\u0001();
    ((MarbleMachineSimultionSettings) this).CuttingSequence = new List<MarbleOperationSequence>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    ((MarbleMachineSimultionSettings) this).MaterialParameter = (marbleMaterialPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).MaterialParameter);
    ((MarbleMachineSimultionSettings) this).SawFeedAnalysisParameter = (marbleCamSawFeedAnalysisPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).SawFeedAnalysisParameter);
    ((MarbleMachineSimultionSettings) this).ReadSurfaceParameter = (marbleReadSurfacePars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).ReadSurfaceParameter);
    ((MarbleMachineSimultionSettings) this).settingProfileCut = (marbleProfileCutPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingProfileCut);
    ((MarbleMachineSimultionSettings) this).settingProfileCurveCut = (marbleProfileCurveCutPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingProfileCurveCut);
    ((MarbleMachineSimultionSettings) this).settingAirDry = (marbleAirDryPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingAirDry);
    ((MarbleMachineSimultionSettings) this).settingMaterialClean = (marbleMatrialCleanPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingMaterialClean);
    ((MarbleMachineSimultionSettings) this).settingColoumnsCut = (marbleColoumsPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingColoumnsCut);
    ((MarbleMachineSimultionSettings) this).settingLatheCut = (marbleLathePars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingLatheCut);
    ((MarbleMachineSimultionSettings) this).settingLatheVerticalCut = (marbleLatheVerticalPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingLatheVerticalCut);
    ((MarbleMachineSimultionSettings) this).settingSweepCut = (marbleSweepPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingSweepCut);
    ((MarbleMachineSimultionSettings) this).settingSliceCut = (marbleSlicesPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingSliceCut);
    ((MarbleMachineSimultionSettings) this).settingChamferCut = (marbleChamferPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingChamferCut);
    ((MarbleMachineSimultionSettings) this).settingDrillCut = (marbleDrillPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingDrillCut);
    ((MarbleMachineSimultionSettings) this).settingMarbleCam = (marbleCamPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingMarbleCam);
    ((MarbleMachineSimultionSettings) this).settingEvent = (marbleEventPar) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingEvent);
    ((MarbleMachineSimultionSettings) this).settingSawMilling = (marbleSawMillingPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingSawMilling);
    ((MarbleMachineSimultionSettings) this).settingSurfaceClean = (marbleSurfaceCleanPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingSurfaceClean);
    ((MarbleMachineSimultionSettings) this).settingCavity = (marbleCavityPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingCavity);
    ((MarbleMachineSimultionSettings) this).settingTap = (marbleTapPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingTap);
    ((MarbleMachineSimultionSettings) this).settingVacuum = (marbleVacuumPars) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingVacuum);
    ((MarbleMachineSimultionSettings) this).settingCutRemailMaterial = (marbleCutRemainMaterial) new \u0007.\u0001(((MarbleMachineSimultionSettings) data).settingCutRemailMaterial);
  }

  public static void Copy(MarbleItemSettings refCam, ref MarbleItemSettings copiedCam)
  {
    if (refCam == null)
      return;
    copiedCam = (MarbleItemSettings) new buLogMarbleVer5(refCam);
  }

  public override string ToString()
  {
    return "Target Z:" + ((marbleEdgeItem) ((MarbleMachineSimultionSettings) this).settingMarbleCam).TargetZ.ToString();
  }

  public abstract void m001FC7();

  public buLogMarbleVer5()
  {
    ((MarbleMachineSimultionSettings) this).SolidEntity = (List<Entity>) null;
    ((MarbleMachineSimultionSettings) this).SolidInsideEntity = (List<Entity>) null;
    ((MarbleMachineSimultionSettings) this).TextEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).DrawWireEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).SourceEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).WireEntities = (List<List<buEntity>>) null;
    ((MarbleMachineSimultionSettings) this).ExtensionEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).EdgeEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).EngravingEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).BaseEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).BorderEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).DrillEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).SurfaceEntities = (List<buEntitiesGroup>) null;
    ((MarbleMachineSimultionSettings) this).GroupEntities = (List<buEntitiesGroup>) null;
    ((MarbleMachineSimultionSettings) this).ConcaveEntities = (List<List<buEntity>>) null;
    ((MarbleMachineSimultionSettings) this).ConvexEntities = (List<List<buEntity>>) null;
    ((MarbleMachineSimultionSettings) this).CamEntities = (List<List<buEntity>>) null;
    ((MarbleMachineSimultionSettings) this).SawEntities = (List<List<buEntityList>>) null;
    ((MarbleMachineSimultionSettings) this).MillingEntities = (List<List<buEntityList>>) null;
    ((MarbleMachineSimultionSettings) this).WaterJetEntities = (List<List<buEntityList>>) null;
    ((MarbleMachineSimultionSettings) this).MillingHeadEntities = (List<List<buEntityList>>) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buLogMarbleVer5(MarbleItemEntities data)
  {
    ((MarbleMachineSimultionSettings) this).SolidEntity = (List<Entity>) null;
    ((MarbleMachineSimultionSettings) this).SolidInsideEntity = (List<Entity>) null;
    ((MarbleMachineSimultionSettings) this).TextEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).DrawWireEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).SourceEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).WireEntities = (List<List<buEntity>>) null;
    ((MarbleMachineSimultionSettings) this).ExtensionEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).EdgeEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).EngravingEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).BaseEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).BorderEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).DrillEntities = (List<buEntity>) null;
    ((MarbleMachineSimultionSettings) this).SurfaceEntities = (List<buEntitiesGroup>) null;
    ((MarbleMachineSimultionSettings) this).GroupEntities = (List<buEntitiesGroup>) null;
    ((MarbleMachineSimultionSettings) this).ConcaveEntities = (List<List<buEntity>>) null;
    ((MarbleMachineSimultionSettings) this).ConvexEntities = (List<List<buEntity>>) null;
    ((MarbleMachineSimultionSettings) this).CamEntities = (List<List<buEntity>>) null;
    ((MarbleMachineSimultionSettings) this).SawEntities = (List<List<buEntityList>>) null;
    ((MarbleMachineSimultionSettings) this).MillingEntities = (List<List<buEntityList>>) null;
    ((MarbleMachineSimultionSettings) this).WaterJetEntities = (List<List<buEntityList>>) null;
    ((MarbleMachineSimultionSettings) this).MillingHeadEntities = (List<List<buEntityList>>) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    if (((MarbleMachineSimultionSettings) data).SurfaceEntities != null)
    {
      ((MarbleMachineSimultionSettings) this).SurfaceEntities = new List<buEntitiesGroup>();
      buEntitiesGroup.Copy(((MarbleMachineSimultionSettings) data).SurfaceEntities, ref ((MarbleMachineSimultionSettings) this).SurfaceEntities);
    }
    if (((MarbleMachineSimultionSettings) data).GroupEntities != null)
    {
      ((MarbleMachineSimultionSettings) this).GroupEntities = new List<buEntitiesGroup>();
      buEntitiesGroup.Copy(((MarbleMachineSimultionSettings) data).GroupEntities, ref ((MarbleMachineSimultionSettings) this).GroupEntities);
    }
    if (((MarbleMachineSimultionSettings) data).ExtensionEntities != null)
    {
      ((MarbleMachineSimultionSettings) this).ExtensionEntities = new List<buEntity>();
      buRadialDim.Copy(((MarbleMachineSimultionSettings) data).ExtensionEntities, ref ((MarbleMachineSimultionSettings) this).ExtensionEntities);
    }
    if (((MarbleMachineSimultionSettings) data).BorderEntities != null)
    {
      ((MarbleMachineSimultionSettings) this).BorderEntities = new List<buEntity>();
      buRadialDim.Copy(((MarbleMachineSimultionSettings) data).BorderEntities, ref ((MarbleMachineSimultionSettings) this).BorderEntities);
    }
    if (((MarbleMachineSimultionSettings) data).WireEntities != null)
    {
      ((MarbleMachineSimultionSettings) this).WireEntities = new List<List<buEntity>>();
      buRadialDim.Copy(((MarbleMachineSimultionSettings) data).WireEntities, ref ((MarbleMachineSimultionSettings) this).WireEntities);
    }
    if (((MarbleMachineSimultionSettings) data).TextEntities != null)
    {
      ((MarbleMachineSimultionSettings) this).TextEntities = new List<buEntity>();
      buRadialDim.Copy(((MarbleMachineSimultionSettings) data).TextEntities, ref ((MarbleMachineSimultionSettings) this).TextEntities);
    }
    if (((MarbleMachineSimultionSettings) data).EdgeEntities != null)
    {
      ((MarbleMachineSimultionSettings) this).EdgeEntities = new List<buEntity>();
      buRadialDim.Copy(((MarbleMachineSimultionSettings) data).EdgeEntities, ref ((MarbleMachineSimultionSettings) this).EdgeEntities);
    }
    if (((MarbleMachineSimultionSettings) data).EngravingEntities != null)
    {
      ((MarbleMachineSimultionSettings) this).EngravingEntities = new List<buEntity>();
      buRadialDim.Copy(((MarbleMachineSimultionSettings) data).EngravingEntities, ref ((MarbleMachineSimultionSettings) this).EngravingEntities);
    }
    if (((MarbleMachineSimultionSettings) data).ConcaveEntities != null)
    {
      ((MarbleMachineSimultionSettings) this).ConcaveEntities = new List<List<buEntity>>();
      buRadialDim.Copy(((MarbleMachineSimultionSettings) data).ConcaveEntities, ref ((MarbleMachineSimultionSettings) this).ConcaveEntities);
    }
    if (((MarbleMachineSimultionSettings) data).ConvexEntities != null)
    {
      ((MarbleMachineSimultionSettings) this).ConvexEntities = new List<List<buEntity>>();
      buRadialDim.Copy(((MarbleMachineSimultionSettings) data).ConvexEntities, ref ((MarbleMachineSimultionSettings) this).ConvexEntities);
    }
    if (((MarbleMachineSimultionSettings) data).CamEntities != null)
    {
      ((MarbleMachineSimultionSettings) this).CamEntities = new List<List<buEntity>>();
      buRadialDim.Copy(((MarbleMachineSimultionSettings) data).CamEntities, ref ((MarbleMachineSimultionSettings) this).CamEntities);
    }
    if (((MarbleMachineSimultionSettings) data).DrillEntities != null)
    {
      ((MarbleMachineSimultionSettings) this).DrillEntities = new List<buEntity>();
      buRadialDim.Copy(((MarbleMachineSimultionSettings) data).DrillEntities, ref ((MarbleMachineSimultionSettings) this).DrillEntities);
    }
    if (((MarbleMachineSimultionSettings) data).SourceEntities != null)
    {
      ((MarbleMachineSimultionSettings) this).SourceEntities = new List<buEntity>();
      buRadialDim.Copy(((MarbleMachineSimultionSettings) data).SourceEntities, ref ((MarbleMachineSimultionSettings) this).SourceEntities);
    }
    if (((MarbleMachineSimultionSettings) data).DrawWireEntities != null)
    {
      ((MarbleMachineSimultionSettings) this).DrawWireEntities = new List<buEntity>();
      buRadialDim.Copy(((MarbleMachineSimultionSettings) data).DrawWireEntities, ref ((MarbleMachineSimultionSettings) this).DrawWireEntities);
    }
    if (((MarbleMachineSimultionSettings) data).BaseEntities != null)
    {
      ((MarbleMachineSimultionSettings) this).BaseEntities = new List<buEntity>();
      buRadialDim.Copy(((MarbleMachineSimultionSettings) data).BaseEntities, ref ((MarbleMachineSimultionSettings) this).BaseEntities);
    }
    if (((MarbleMachineSimultionSettings) data).SolidEntity != null)
    {
      ((MarbleMachineSimultionSettings) this).SolidEntity = new List<Entity>();
      ((MarbleMachineSimultionSettings) this).SolidEntity = buVector5.CopyEntities(((MarbleMachineSimultionSettings) data).SolidEntity);
    }
    if (((MarbleMachineSimultionSettings) data).SolidInsideEntity != null)
    {
      ((MarbleMachineSimultionSettings) this).SolidInsideEntity = new List<Entity>();
      ((MarbleMachineSimultionSettings) this).SolidInsideEntity = buVector5.CopyEntities(((MarbleMachineSimultionSettings) data).SolidInsideEntity);
    }
    if (((MarbleMachineSimultionSettings) data).SawEntities != null)
      buLineCam.Copy(((MarbleMachineSimultionSettings) data).SawEntities, ref ((MarbleMachineSimultionSettings) this).SawEntities);
    if (((MarbleMachineSimultionSettings) data).MillingEntities != null)
      buLineCam.Copy(((MarbleMachineSimultionSettings) data).MillingEntities, ref ((MarbleMachineSimultionSettings) this).MillingEntities);
    if (((MarbleMachineSimultionSettings) data).WaterJetEntities != null)
      buLineCam.Copy(((MarbleMachineSimultionSettings) data).WaterJetEntities, ref ((MarbleMachineSimultionSettings) this).WaterJetEntities);
    if (((MarbleMachineSimultionSettings) data).MillingHeadEntities == null)
      return;
    buLineCam.Copy(((MarbleMachineSimultionSettings) data).MillingHeadEntities, ref ((MarbleMachineSimultionSettings) this).MillingHeadEntities);
  }
}
