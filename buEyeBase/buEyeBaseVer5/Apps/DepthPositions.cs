// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DepthPositions
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class DepthPositions : buSerilization5
{
  public ProfileOperationDataRectangle RectangleData;
  public ProfileOperationDataRectangleRound RectangleRoundData;
  public ProfileOperationDataCut CutData;
  public ProfileOperationDataSlot SlotData;
  public ProfileOperationDataEllipse EllipseData;
  public ProfileOperationDataNotch NotchData;
  public ProfileOperationDataHole HoleData;
  public ProfileOperationDataBarel BarelData;

  public bool FindNotchTool(List<ToolGroup5> ToolGroup, ref ToolBase5 foundTool)
  {
    foundTool = (ToolBase5) null;
    bool notchTool;
    for (int index1 = 0; index1 <= ToolGroup.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ((ToolGeometry5) ToolGroup[index1]).Tools.Count - 1; ++index2)
      {
        if (((ToolData5) ((ToolGeometry5) ((ToolGeometry5) ToolGroup[index1]).Tools[index2]).Geometry).GeometryType == ToolType.Saw)
        {
          foundTool = (ToolBase5) new ToolGeometry5(((ToolGeometry5) ToolGroup[index1]).Tools[index2]);
          notchTool = true;
          goto label_9;
        }
      }
    }
    notchTool = false;
label_9:
    return notchTool;
  }

  public void CheckToolLength(
    ProfileOperation Operation,
    ToolBase5 Tool,
    double ToolHolderLength,
    ref bool isToolLenShort,
    ref bool isToolCutLenShort)
  {
    isToolLenShort = false;
    isToolCutLenShort = false;
    if (Tool == null)
      return;
    if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).OperationType == ProfileOperationTypes.Notch)
    {
      if (((NestingPanelJob) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).NotchData).NotchDepth <= ((ToolGeometry5) Tool).Geometry.Diameter / 2.0)
        return;
      isToolCutLenShort = true;
    }
    else if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues.Count > 0)
    {
      if (Math.Abs(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues[0]).TopPosition - ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues[((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues.Count - 1]).BottomPosition) > ((ToolGeometry5) Tool).Geometry.TotalLength - ToolHolderLength)
        isToolLenShort = true;
      for (int index = 0; index <= ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues.Count - 1; ++index)
      {
        if (Math.Abs(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues[index]).TopPosition - ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues[index]).BottomPosition) > ((ToolGeometry5) Tool).Geometry.CutLength)
          isToolCutLenShort = true;
      }
    }
    else
    {
      double num = Math.Abs(((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Depth).TopPosition - ((MarbleRuntimeSettings) ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Depth).BottomPosition);
      if (((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).CamParMilling.Steps.Enable)
        num = ((camSpeeds5) ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).CamParMilling.Steps).Step;
      if (num > ((ToolGeometry5) Tool).Geometry.TotalLength - ToolHolderLength)
        isToolLenShort = true;
      if (num <= ((ToolGeometry5) Tool).Geometry.CutLength)
        return;
      isToolCutLenShort = true;
    }
  }

  public void SortList(SortDirectionType Direction, ref List<MinMax> RefList)
  {
    try
    {
      bool flag = false;
      if (RefList.Count <= 1)
        return;
      RefList.Sort(ProfileSettings.\u003C\u003E9__95_0 ?? (ProfileSettings.\u003C\u003E9__95_0 = new Comparison<MinMax>(((OperationUpdateArg) ProfileSettings.\u003C\u003E9).\u0001)));
      if (Direction == SortDirectionType.Lower)
      {
        for (int index = 1; index <= RefList.Count - 1; ++index)
        {
          if (RefList[index - 1].Min > RefList[index].Min)
          {
            index = RefList.Count;
            flag = true;
          }
        }
        if (flag)
          RefList.Reverse();
      }
      if (Direction != SortDirectionType.Bigger)
        return;
      for (int index = 1; index <= RefList.Count - 1; ++index)
      {
        if (RefList[index - 1].Min < RefList[index].Min)
        {
          index = RefList.Count;
          flag = true;
        }
      }
      if (!flag)
        return;
      RefList.Reverse();
    }
    catch (Exception ex)
    {
      string str = "Direction: " + Direction.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void SortList(SortDirectionType Direction, ref List<ProfileOperation> RefList)
  {
    try
    {
      bool flag = false;
      if (RefList.Count <= 1)
        return;
      RefList.Sort(ProfileSettings.\u003C\u003E9__96_0 ?? (ProfileSettings.\u003C\u003E9__96_0 = new Comparison<ProfileOperation>(((buPanelCutCalc) ProfileSettings.\u003C\u003E9).\u0001)));
      if (Direction == SortDirectionType.Lower)
      {
        for (int index = 1; index <= RefList.Count - 1; ++index)
        {
          if (((ProfileRuntimeSettings) RefList[index - 1]).MinPoint.X > ((ProfileRuntimeSettings) RefList[index]).MinPoint.X)
          {
            index = RefList.Count;
            flag = true;
          }
        }
        if (flag)
          RefList.Reverse();
      }
      if (Direction != SortDirectionType.Bigger)
        return;
      for (int index = 1; index <= RefList.Count - 1; ++index)
      {
        if (((ProfileRuntimeSettings) RefList[index - 1]).MinPoint.X < ((ProfileRuntimeSettings) RefList[index]).MinPoint.X)
        {
          index = RefList.Count;
          flag = true;
        }
      }
      if (!flag)
        return;
      RefList.Reverse();
    }
    catch (Exception ex)
    {
      string str = "Direction: " + Direction.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void SortList(SortDirectionType Direction, ref List<GProfileOperation> RefList)
  {
    try
    {
      bool flag = false;
      if (RefList.Count <= 1)
        return;
      RefList.Sort(ProfileSettings.\u003C\u003E9__97_0 ?? (ProfileSettings.\u003C\u003E9__97_0 = new Comparison<GProfileOperation>(((buPanelCutCalc) ProfileSettings.\u003C\u003E9).\u0001)));
      if (Direction == SortDirectionType.Lower)
      {
        for (int index = 1; index <= RefList.Count - 1; ++index)
        {
          if (((FlatViewSettings) ((ProfileRuntimeSettings) RefList[index - 1]).SizePoint).MinPoint.X > ((FlatViewSettings) ((ProfileRuntimeSettings) RefList[index]).SizePoint).MinPoint.X)
          {
            index = RefList.Count;
            flag = true;
          }
        }
        if (flag)
          RefList.Reverse();
      }
      if (Direction != SortDirectionType.Bigger)
        return;
      for (int index = 1; index <= RefList.Count - 1; ++index)
      {
        if (((FlatViewSettings) ((ProfileRuntimeSettings) RefList[index - 1]).SizePoint).MinPoint.X < ((FlatViewSettings) ((ProfileRuntimeSettings) RefList[index]).SizePoint).MinPoint.X)
        {
          index = RefList.Count;
          flag = true;
        }
      }
      if (!flag)
        return;
      RefList.Reverse();
    }
    catch (Exception ex)
    {
      string str = "Direction: " + Direction.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void SortList(
    SortDirectionType Direction,
    ref List<GProfileOperation> RefList,
    profileSortSequenceAtSamePosition Sequence)
  {
    // ISSUE: unable to decompile the method.
  }
}
