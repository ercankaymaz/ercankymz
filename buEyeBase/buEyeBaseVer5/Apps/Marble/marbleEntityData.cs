// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleEntityData
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
public class marbleEntityData : buSerilization5
{
  public double OffsetEdgeOffset;
  public double OffsetZForwardDownStep;
  public double OffsetInnerCutAAngle;
  public bool OffsetEnable;
  public bool OffsetZigzagMode;
  public bool OffsetReverseCAngle;
  public bool OffsetCutInisde;
  public bool OffsetCutOutside;
  public bool OffsetCutEdges;

  public static void Decode(List<string> SL, ref MarbleItemCam refItemCam)
  {
    try
    {
      refItemCam = (MarbleItemCam) new marbleMenuType();
      buSerilization5.Decode(SL, "", (SerilizationMode5) 1, (object) refItemCam);
      List<List<string>> stringListList = new List<List<string>>();
      List<string> CalcList = new List<string>();
      buStatics.ListToSpecificList("<ToolSelected>", "</ToolSelected>", false, SL, ref CalcList);
      if (CalcList.Count > 0)
      {
        if (CalcList.Count >= 1)
        {
          ((MarbleMachineOptionsSettings) refItemCam).ToolSelected = (ToolBase5) new ToolGeometry5();
          object toolSelected = (object) ((MarbleMachineOptionsSettings) refItemCam).ToolSelected;
          buSerilization5.StringToClass(ref toolSelected, CalcList[0]);
        }
        if (CalcList.Count >= 2)
        {
          object data = (object) ((ToolGeometry5) ((MarbleMachineOptionsSettings) refItemCam).ToolSelected).Data;
          buSerilization5.StringToClass(ref data, CalcList[1]);
        }
        if (CalcList.Count >= 3)
        {
          object geometry = (object) ((ToolGeometry5) ((MarbleMachineOptionsSettings) refItemCam).ToolSelected).Geometry;
          buSerilization5.StringToClass(ref geometry, CalcList[2]);
        }
        if (CalcList.Count >= 4)
        {
          object camData = (object) ((ToolGeometry5) ((MarbleMachineOptionsSettings) refItemCam).ToolSelected).CamData;
          buSerilization5.StringToClass(ref camData, CalcList[3]);
        }
        CalcList.Clear();
      }
      buStatics.ListToSpecificList("<CamSettings>", "</CamSettings>", false, SL, ref CalcList);
      if (CalcList.Count > 0)
      {
        if (CalcList.Count >= 1)
        {
          object offsets = (object) ((MarbleMachineOptionsSettings) refItemCam).setCam.Offsets;
          buSerilization5.StringToClass(ref offsets, CalcList[0]);
        }
        if (CalcList.Count >= 2)
        {
          object distances = (object) ((MarbleMachineOptionsSettings) refItemCam).setCam.Distances;
          buSerilization5.StringToClass(ref distances, CalcList[1]);
        }
        if (CalcList.Count >= 3)
        {
          object drill = (object) ((camOffset5) ((MarbleMachineOptionsSettings) refItemCam).setCam).Drill;
          buSerilization5.StringToClass(ref drill, CalcList[2]);
        }
        if (CalcList.Count >= 4)
        {
          object operations = (object) ((MarbleMachineOptionsSettings) refItemCam).setCam.Operations;
          buSerilization5.StringToClass(ref operations, CalcList[3]);
        }
        if (CalcList.Count >= 5)
        {
          object options = (object) ((MarbleMachineOptionsSettings) refItemCam).setCam.Options;
          buSerilization5.StringToClass(ref options, CalcList[4]);
        }
        if (CalcList.Count >= 6)
        {
          object pockets = (object) ((MarbleMachineOptionsSettings) refItemCam).setCam.Pockets;
          buSerilization5.StringToClass(ref pockets, CalcList[5]);
        }
        if (CalcList.Count >= 7)
        {
          object speeds = (object) ((MarbleMachineOptionsSettings) refItemCam).setCam.Speeds;
          buSerilization5.StringToClass(ref speeds, CalcList[6]);
        }
        if (CalcList.Count >= 8)
        {
          object steps = (object) ((MarbleMachineOptionsSettings) refItemCam).setCam.Steps;
          buSerilization5.StringToClass(ref steps, CalcList[7]);
        }
        if (CalcList.Count >= 9)
        {
          object strategy = (object) ((MarbleMachineOptionsSettings) refItemCam).setCam.Strategy;
          buSerilization5.StringToClass(ref strategy, CalcList[8]);
        }
        CalcList.Clear();
      }
      buStatics.ListToSpecificList("<WireEntities>", "</WireEntities>", false, SL, ref CalcList);
      if (CalcList.Count > 0)
      {
        ((MarbleMachineOptionsSettings) refItemCam).WireEntities = new List<List<buEntity>>();
        buText.Decode(CalcList, ref ((MarbleMachineOptionsSettings) refItemCam).WireEntities);
        CalcList.Clear();
      }
      buStatics.ListToSpecificList("<WireAuxEntities>", "</WireAuxEntities>", false, SL, ref CalcList);
      if (CalcList.Count > 0)
      {
        ((MarbleMachineOptionsSettings) refItemCam).WireAuxEntities = new List<List<buEntity>>();
        buText.Decode(CalcList, ref ((MarbleMachineOptionsSettings) refItemCam).WireAuxEntities);
        CalcList.Clear();
      }
      buStatics.ListToSpecificList("<ConcaveEntities>", "</ConcaveEntities>", false, SL, ref CalcList);
      if (CalcList.Count > 0)
      {
        ((MarbleMachineOptionsSettings) refItemCam).ConcaveEntities = new List<List<buEntity>>();
        buText.Decode(CalcList, ref ((MarbleMachineOptionsSettings) refItemCam).ConcaveEntities);
        CalcList.Clear();
      }
      buStatics.ListToSpecificList("<ConvexEntities>", "</ConvexEntities>", false, SL, ref CalcList);
      if (CalcList.Count > 0)
      {
        ((MarbleMachineOptionsSettings) refItemCam).ConvexEntities = new List<List<buEntity>>();
        buText.Decode(CalcList, ref ((MarbleMachineOptionsSettings) refItemCam).ConvexEntities);
        CalcList.Clear();
      }
      buStatics.ListToSpecificList("<DrillEntities>", "</ConcaveEntDrillEntitiesities>", false, SL, ref CalcList);
      if (CalcList.Count <= 0)
        return;
      ((MarbleMachineOptionsSettings) refItemCam).DrillEntities = new List<buEntity>();
      buText.Decode(CalcList, ref ((MarbleMachineOptionsSettings) refItemCam).DrillEntities);
      CalcList.Clear();
    }
    catch (Exception ex)
    {
    }
  }

  public static void Decode(List<string> SL, ref List<MarbleItemCam> refItemCams)
  {
    try
    {
      refItemCams = new List<MarbleItemCam>();
      if (SL.Count <= 0)
        return;
      List<List<string>> CalcList = new List<List<string>>();
      buStatics.ListToSpecificList("<MarbleItemCam>", "</MarbleItemCam>", true, SL, ref CalcList);
      if (CalcList.Count <= 0)
        return;
      for (int index = 0; index <= CalcList.Count - 1; ++index)
      {
        MarbleItemCam refItemCam = (MarbleItemCam) new marbleMenuType();
        marbleEntityData.Decode(CalcList[index], ref refItemCam);
        refItemCams.Add(refItemCam);
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

  public abstract void m001FBA();
}
