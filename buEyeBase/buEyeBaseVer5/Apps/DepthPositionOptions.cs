// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DepthPositionOptions
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

public class DepthPositionOptions : buSerilization5
{
  public ProfileOperationDataFreeDraw FreeDrawData;
  public ProfileOperationDataText TextData;
  public ProfileOperationDataPolygon PolygonData;
  public ShapeArray Array;
  public ShapeMirror Mirror;

  public void SortListByPriority(SortDirectionType Direction, ref List<GProfileOperation> RefList)
  {
    try
    {
      bool flag = false;
      if (RefList.Count <= 1)
        return;
      RefList.Sort(ProfileSettings.\u003C\u003E9__99_0 ?? (ProfileSettings.\u003C\u003E9__99_0 = new Comparison<GProfileOperation>(((buPanelCutCalc) ProfileSettings.\u003C\u003E9).\u0003)));
      if (Direction == SortDirectionType.Lower)
      {
        for (int index = 1; index <= RefList.Count - 1; ++index)
        {
          if (((ProfileVisualSettings) RefList[index - 1]).Priority > ((ProfileVisualSettings) RefList[index]).Priority)
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
        if (((ProfileVisualSettings) RefList[index - 1]).Priority < ((ProfileVisualSettings) RefList[index]).Priority)
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

  public void SortList(SortDirectionType Direction, ref List<ProfileOperationSortItem> RefList)
  {
    try
    {
      bool flag = false;
      if (RefList.Count <= 1)
        return;
      RefList.Sort(ProfileSettings.\u003C\u003E9__100_0 ?? (ProfileSettings.\u003C\u003E9__100_0 = new Comparison<ProfileOperationSortItem>(((buPanelCutCalc) ProfileSettings.\u003C\u003E9).\u0001)));
      if (Direction == SortDirectionType.Lower)
      {
        for (int index = 1; index <= RefList.Count - 1; ++index)
        {
          if (((FlatViewSettings) ((PanelCutMoveCommand) RefList[index - 1]).SizePoint).MinPoint.X > ((FlatViewSettings) ((PanelCutMoveCommand) RefList[index]).SizePoint).MinPoint.X)
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
        if (((FlatViewSettings) ((PanelCutMoveCommand) RefList[index - 1]).SizePoint).MinPoint.X < ((FlatViewSettings) ((PanelCutMoveCommand) RefList[index]).SizePoint).MinPoint.X)
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

  public void CheckDepthAndChangeSequenceIfIntersect(ref List<GProfileOperation> RefList)
  {
    for (int index = 0; index <= RefList.Count - 1; ++index)
    {
      if (index < RefList.Count - 1 && ((ProfileMirror) ((ProfileRuntimeSettings) RefList[index]).OperationData).selectedPlaneName == ((ProfileMirror) ((ProfileRuntimeSettings) RefList[index + 1]).OperationData).selectedPlaneName)
      {
        bool flag = false;
        if (buCall.\u0001.isBoxSizeInsideBoxSize(((FlatViewSettings) ((ProfileRuntimeSettings) RefList[index]).SizePoint).MinPoint, ((MachineSimulation) ((ProfileRuntimeSettings) RefList[index]).SizePoint).MaxPoint, ((FlatViewSettings) ((ProfileRuntimeSettings) RefList[index + 1]).SizePoint).MinPoint, ((MachineSimulation) ((ProfileRuntimeSettings) RefList[index + 1]).SizePoint).MaxPoint, ((ProfilePatternCopy) ((ProfileRuntimeSettings) RefList[index]).OperationData).selectedPlane))
          flag = true;
        else if (buCall.\u0001.isBoxSizeInsideBoxSize(((FlatViewSettings) ((ProfileRuntimeSettings) RefList[index + 1]).SizePoint).MinPoint, ((MachineSimulation) ((ProfileRuntimeSettings) RefList[index + 1]).SizePoint).MaxPoint, ((FlatViewSettings) ((ProfileRuntimeSettings) RefList[index]).SizePoint).MinPoint, ((MachineSimulation) ((ProfileRuntimeSettings) RefList[index]).SizePoint).MaxPoint, ((ProfilePatternCopy) ((ProfileRuntimeSettings) RefList[index]).OperationData).selectedPlane))
          flag = true;
        else if (buCall.\u0001.isBoxSizesIntersection(((FlatViewSettings) ((ProfileRuntimeSettings) RefList[index]).SizePoint).MinPoint, ((MachineSimulation) ((ProfileRuntimeSettings) RefList[index]).SizePoint).MaxPoint, ((FlatViewSettings) ((ProfileRuntimeSettings) RefList[index + 1]).SizePoint).MinPoint, ((MachineSimulation) ((ProfileRuntimeSettings) RefList[index + 1]).SizePoint).MaxPoint, ((ProfilePatternCopy) ((ProfileRuntimeSettings) RefList[index]).OperationData).selectedPlane))
          flag = true;
        if (flag)
        {
          DepthPositions depthPositions1 = ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) RefList[index]).OperationData).DepthValues.Count <= 0 ? ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) RefList[index]).OperationData).Depth : ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) RefList[index]).OperationData).DepthValues[0];
          DepthPositions depthPositions2 = ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) RefList[index + 1]).OperationData).DepthValues.Count <= 0 ? ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) RefList[index + 1]).OperationData).Depth : ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) RefList[index + 1]).OperationData).DepthValues[0];
          if (((ProfileMirror) ((ProfileRuntimeSettings) RefList[index]).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) RefList[index]).OperationData).selectedPlaneName == planeNames.Back && ((MarbleRuntimeSettings) depthPositions1).TopPosition < ((MarbleRuntimeSettings) depthPositions2).TopPosition)
          {
            GProfileOperation gprofileOperation = RefList[index + 1];
            RefList.RemoveAt(index + 1);
            RefList.Insert(index, gprofileOperation);
          }
          if (((ProfileMirror) ((ProfileRuntimeSettings) RefList[index]).OperationData).selectedPlaneName == planeNames.Bottom | ((ProfileMirror) ((ProfileRuntimeSettings) RefList[index]).OperationData).selectedPlaneName == planeNames.Front && ((MarbleRuntimeSettings) depthPositions1).TopPosition > ((MarbleRuntimeSettings) depthPositions2).TopPosition)
          {
            GProfileOperation gprofileOperation = RefList[index + 1];
            RefList.RemoveAt(index + 1);
            RefList.Insert(index, gprofileOperation);
          }
        }
      }
    }
  }

  public ProfileItem SelectActiveProfile(
    ProfileItem FirstItem,
    ProfileItem SecondItem,
    ref int activeProfileIndex)
  {
    string callMethod = nameof (SelectActiveProfile);
    try
    {
      ProfileItem profileItem = (ProfileItem) null;
      if (activeProfileIndex == 0)
        profileItem = FirstItem;
      else if (activeProfileIndex == 1)
        profileItem = SecondItem;
      return profileItem;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, ProfileSettings.sClass, callMethod, false, "");
      return (ProfileItem) null;
    }
  }
}
