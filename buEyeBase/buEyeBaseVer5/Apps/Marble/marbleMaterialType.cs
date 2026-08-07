// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleMaterialType
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleMaterialType : buSerilization5
{
  public double FinishMinZ;
  public double FinishCOffsetAngle;
  public double FinishLeadInAngle;

  public static void Decode(List<string> SL, ref MarbleItem refItem)
  {
    try
    {
      refItem = (MarbleItem) new marbleCountertopPocketData();
      buSerilization5.Decode(SL, "", (SerilizationMode5) 1, (object) refItem);
      List<List<string>> stringListList = new List<List<string>>();
      List<string> CalcList1 = new List<string>();
      buStatics.ListToSpecificList("<ItemEntGroup>", "</ItemEntGroup>", false, SL, ref CalcList1);
      if (CalcList1.Count > 0)
      {
        ((MarbleScreenCaptureSettings) refItem).EntGroup = new buEntitiesGroup();
        DimensionGroup.Decode(CalcList1, ref ((MarbleScreenCaptureSettings) refItem).EntGroup);
      }
      CalcList1.Clear();
      buStatics.ListToSpecificList("<ItemEntGroupBottom>", "</ItemEntGroupBottom>", false, SL, ref CalcList1);
      if (CalcList1.Count > 0)
      {
        ((MarbleScreenCaptureSettings) refItem).EntGroupBottom = new buEntitiesGroup();
        DimensionGroup.Decode(CalcList1, ref ((MarbleScreenCaptureSettings) refItem).EntGroupBottom);
      }
      CalcList1.Clear();
      buStatics.ListToSpecificList("<ItemSettings>", "</ItemSettings>", false, SL, ref CalcList1);
      if (CalcList1.Count > 0)
      {
        if (CalcList1.Count >= 1)
        {
          object materialParameter = (object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).MaterialParameter;
          buSerilization5.StringToClass(ref materialParameter, CalcList1[0]);
        }
        if (CalcList1.Count >= 2)
        {
          object surfaceParameter = (object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).ReadSurfaceParameter;
          buSerilization5.StringToClass(ref surfaceParameter, CalcList1[1]);
        }
        if (CalcList1.Count >= 3)
        {
          object analysisParameter = (object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).SawFeedAnalysisParameter;
          buSerilization5.StringToClass(ref analysisParameter, CalcList1[2]);
        }
        if (CalcList1.Count >= 4)
        {
          object settingAirDry = (object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingAirDry;
          buSerilization5.StringToClass(ref settingAirDry, CalcList1[3]);
        }
        if (CalcList1.Count >= 5)
        {
          object settingChamferCut = (object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingChamferCut;
          buSerilization5.StringToClass(ref settingChamferCut, CalcList1[4]);
        }
        if (CalcList1.Count >= 6)
        {
          object settingColoumnsCut = (object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingColoumnsCut;
          buSerilization5.StringToClass(ref settingColoumnsCut, CalcList1[5]);
        }
        if (CalcList1.Count >= 7)
        {
          object settingDrillCut = (object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingDrillCut;
          buSerilization5.StringToClass(ref settingDrillCut, CalcList1[6]);
        }
        if (CalcList1.Count >= 8)
        {
          object settingLatheCut = (object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingLatheCut;
          buSerilization5.StringToClass(ref settingLatheCut, CalcList1[7]);
        }
        if (CalcList1.Count >= 9)
        {
          object latheVerticalCut = (object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingLatheVerticalCut;
          buSerilization5.StringToClass(ref latheVerticalCut, CalcList1[8]);
        }
        if (CalcList1.Count >= 10)
        {
          object settingMarbleCam = (object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingMarbleCam;
          buSerilization5.StringToClass(ref settingMarbleCam, CalcList1[9]);
        }
        if (CalcList1.Count >= 11)
        {
          object settingMaterialClean = (object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingMaterialClean;
          buSerilization5.StringToClass(ref settingMaterialClean, CalcList1[10]);
        }
        if (CalcList1.Count >= 12)
        {
          object settingProfileCurveCut = (object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingProfileCurveCut;
          buSerilization5.StringToClass(ref settingProfileCurveCut, CalcList1[11]);
        }
        if (CalcList1.Count >= 13)
        {
          object settingProfileCut = (object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingProfileCut;
          buSerilization5.StringToClass(ref settingProfileCut, CalcList1[12]);
        }
        if (CalcList1.Count >= 14)
        {
          object settingSliceCut = (object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingSliceCut;
          buSerilization5.StringToClass(ref settingSliceCut, CalcList1[13]);
        }
        if (CalcList1.Count >= 15)
        {
          object settingSweepCut = (object) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).Settings).settingSweepCut;
          buSerilization5.StringToClass(ref settingSweepCut, CalcList1[14]);
        }
        CalcList1.Clear();
      }
      CalcList1.Clear();
      buStatics.ListToSpecificList("<ItemCollapses>", "</ItemCollapses>", false, SL, ref CalcList1);
      if (CalcList1.Count > 0)
      {
        List<List<string>> CalcList2 = new List<List<string>>();
        buStatics.ListToSpecificList("<marbleCollapseItem>", "</marbleCollapseItem>", true, CalcList1, ref CalcList2);
        if (CalcList2.Count > 0)
        {
          for (int index = 0; index <= CalcList2.Count - 1; ++index)
          {
            marbleCollapseItem marbleCollapseItem = (marbleCollapseItem) new \u0007.\u0001();
            buSerilization5.Decode(CalcList2[index], "", (SerilizationMode5) 1, (object) marbleCollapseItem);
            ((MarbleScreenCaptureSettings) refItem).Collapses.Add(marbleCollapseItem);
          }
        }
      }
      CalcList1.Clear();
      if (CalcList1.Count > 0)
      {
        List<List<string>> CalcList3 = new List<List<string>>();
        buStatics.ListToSpecificList("<ItemEdge>", "</ItemEdge>", false, CalcList1, ref CalcList3);
        if (CalcList3.Count > 0)
        {
          for (int index = 0; index <= CalcList3.Count - 1; ++index)
          {
            marbleEdgeItem marbleEdgeItem = (marbleEdgeItem) null;
            List<string> CalcList4 = new List<string>();
            buStatics.ListToSpecificList("<marbleEdgeItem>", "</marbleEdgeItem>", true, CalcList3[index], ref CalcList4);
            if (CalcList4.Count >= 0)
            {
              marbleEdgeItem = (marbleEdgeItem) new \u0007.\u0001();
              buSerilization5.Decode(CalcList3[index], "", (SerilizationMode5) 1, (object) marbleEdgeItem);
            }
            if (marbleEdgeItem != null)
            {
              CalcList4 = new List<string>();
              buStatics.ListToSpecificList("<ItemEdgeRefEntity>", "</ItemEdgeRefEntity>", false, CalcList3[index], ref CalcList4);
              if (CalcList4.Count > 0)
              {
                if (CalcList4[0].IndexOf("<buEntity>") >= 0)
                  CalcList4.RemoveAt(0);
                buText.Decode(CalcList4, ref ((MarbleSliceType) marbleEdgeItem).refEntity);
              }
              CalcList4 = new List<string>();
              buStatics.ListToSpecificList("<ItemEdgeDrawEntity>", "</ItemEdgeDrawEntity>", false, CalcList3[index], ref CalcList4);
              if (CalcList4.Count > 0)
              {
                if (CalcList4[0].IndexOf("<buEntity>") >= 0)
                  CalcList4.RemoveAt(0);
                buText.Decode(CalcList4, ref ((MarbleSliceType) marbleEdgeItem).drawEntity);
              }
              ((MarbleScreenCaptureSettings) refItem).Edges.Add(marbleEdgeItem);
            }
          }
        }
      }
      CalcList1.Clear();
      buStatics.ListToSpecificList("<ItemEntities>", "</ItemEntities>", false, SL, ref CalcList1);
      if (CalcList1.Count > 0)
      {
        List<string> CalcList5 = new List<string>();
        buStatics.ListToSpecificList("<DrawWireEntities>", "</DrawWireEntities>", true, CalcList1, ref CalcList5);
        if (CalcList5.Count >= 0)
        {
          ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).DrawWireEntities = new List<buEntity>();
          buText.Decode(CalcList5, ref ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).DrawWireEntities);
          CalcList5.Clear();
        }
        buStatics.ListToSpecificList("<BaseEntities>", "</BaseEntities>", true, CalcList1, ref CalcList5);
        if (CalcList5.Count >= 0)
        {
          ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).BaseEntities = new List<buEntity>();
          buText.Decode(CalcList5, ref ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).BaseEntities);
          CalcList5.Clear();
        }
        buStatics.ListToSpecificList("<CamEntities>", "</CamEntities>", true, CalcList1, ref CalcList5);
        if (CalcList5.Count >= 0)
        {
          ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).CamEntities = new List<List<buEntity>>();
          buText.Decode(CalcList5, ref ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).CamEntities);
          CalcList5.Clear();
        }
        buStatics.ListToSpecificList("<BorderEntities>", "</BorderEntities>", true, CalcList1, ref CalcList5);
        if (CalcList5.Count >= 0)
        {
          ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).BorderEntities = new List<buEntity>();
          buText.Decode(CalcList5, ref ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).BorderEntities);
          CalcList5.Clear();
        }
        buStatics.ListToSpecificList("<ConcaveEntities>", "</ConcaveEntities>", true, CalcList1, ref CalcList5);
        if (CalcList5.Count >= 0)
        {
          ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).ConcaveEntities = new List<List<buEntity>>();
          buText.Decode(CalcList5, ref ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).ConcaveEntities);
          CalcList5.Clear();
        }
        buStatics.ListToSpecificList("<ConvexEntities>", "</ConvexEntities>", true, CalcList1, ref CalcList5);
        if (CalcList5.Count >= 0)
        {
          ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).ConvexEntities = new List<List<buEntity>>();
          buText.Decode(CalcList5, ref ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).ConvexEntities);
          CalcList5.Clear();
        }
        buStatics.ListToSpecificList("<DrillEntities>", "</DrillEntities>", true, CalcList1, ref CalcList5);
        if (CalcList5.Count >= 0)
        {
          ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).DrillEntities = new List<buEntity>();
          buText.Decode(CalcList5, ref ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).DrillEntities);
          CalcList5.Clear();
        }
        buStatics.ListToSpecificList("<EdgeEntities>", "</EdgeEntities>", true, CalcList1, ref CalcList5);
        if (CalcList5.Count >= 0)
        {
          ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).EdgeEntities = new List<buEntity>();
          buText.Decode(CalcList5, ref ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).EdgeEntities);
          CalcList5.Clear();
        }
        buStatics.ListToSpecificList("<EngravingEntities>", "</EngravingEntities>", true, CalcList1, ref CalcList5);
        if (CalcList5.Count >= 0)
        {
          ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).EngravingEntities = new List<buEntity>();
          buText.Decode(CalcList5, ref ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).EngravingEntities);
          CalcList5.Clear();
        }
        buStatics.ListToSpecificList("<ExtensionEntities>", "</ExtensionEntities>", true, CalcList1, ref CalcList5);
        if (CalcList5.Count >= 0)
        {
          ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).ExtensionEntities = new List<buEntity>();
          buText.Decode(CalcList5, ref ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).ExtensionEntities);
          CalcList5.Clear();
        }
        buStatics.ListToSpecificList("<SourceEntities>", "</SourceEntities>", true, CalcList1, ref CalcList5);
        if (CalcList5.Count >= 0)
        {
          ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).SourceEntities = new List<buEntity>();
          buText.Decode(CalcList5, ref ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).SourceEntities);
          CalcList5.Clear();
        }
        buStatics.ListToSpecificList("<TextEntities>", "</TextEntities>", true, CalcList1, ref CalcList5);
        if (CalcList5.Count >= 0)
        {
          ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).TextEntities = new List<buEntity>();
          buText.Decode(CalcList5, ref ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).TextEntities);
          CalcList5.Clear();
        }
        buStatics.ListToSpecificList("<WireEntities>", "</WireEntities>", true, CalcList1, ref CalcList5);
        if (CalcList5.Count >= 0)
        {
          ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).WireEntities = new List<List<buEntity>>();
          buText.Decode(CalcList5, ref ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) refItem).ItemEntities).WireEntities);
          CalcList5.Clear();
        }
      }
      CalcList1.Clear();
      buStatics.ListToSpecificList("<ItemCamList>", "</ItemCamList>", false, SL, ref CalcList1);
      if (CalcList1.Count <= 0)
        return;
      ((MarbleScreenCaptureSettings) refItem).CamList = new List<MarbleItemCam>();
      marbleEntityData.Decode(CalcList1, ref ((MarbleScreenCaptureSettings) refItem).CamList);
      CalcList1.Clear();
    }
    catch (Exception ex)
    {
    }
  }

  public static void Decode(List<string> SL, ref List<MarbleItem> refItes)
  {
    try
    {
      refItes = new List<MarbleItem>();
      if (SL.Count <= 0)
        return;
      List<List<string>> CalcList = new List<List<string>>();
      buStatics.ListToSpecificList("<MarbleItem>", "</MarbleItem>", true, SL, ref CalcList);
      if (CalcList.Count <= 0)
        return;
      for (int index = 0; index <= CalcList.Count - 1; ++index)
      {
        MarbleItem refItem = (MarbleItem) new marbleCountertopPocketData();
        marbleMaterialType.Decode(CalcList[index], ref refItem);
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
    // ISSUE: unable to decompile the method.
  }
}
