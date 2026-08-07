// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCountertopTapPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopTapPars : buSerilization5
{
  public bool UseG38G39;
  public bool AutoWaterOpenClose;
  public bool AutoWaterWhenCRotating;
  public bool OutsideArcCuttingByMilling;
  public double OutsideArcCuttingMinDiameterBySaw;
  public bool LastStepAtSameTime;
  public bool isCircularFirst;
  public bool isInsideFirst;

  public void GetCamID(List<MarbleItemCam> CamList, ref int MarbleCamID)
  {
    List<int> intList = new List<int>();
    for (int index = 0; index <= CamList.Count - 1; ++index)
    {
      if (((MarbleMachineSettings) CamList[index]).CamID >= 0)
        buFile5.AddValueToList(((MarbleMachineSettings) CamList[index]).CamID, ref intList);
    }
    if (intList.Count > 0)
    {
      buFile5.SortList(SortDirectionType.Lower, ref intList);
      MarbleCamID = intList[intList.Count - 1] + 1;
      ++MarbleDisplaySettings.MarbleCamID;
    }
    else
    {
      MarbleCamID = MarbleDisplaySettings.MarbleCamID;
      ++MarbleDisplaySettings.MarbleCamID;
    }
  }

  public void GetEdgeID(MarbleJob Job, ref int EdgeID)
  {
    List<int> intList = new List<int>();
    for (int index1 = 0; index1 <= ((MarbleProgramSettings) Job).Items.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).Edges.Count - 1; ++index2)
      {
        if (((MarbleToolType) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).Edges[index2]).EdgeID >= 0)
          buFile5.AddValueToList(((MarbleToolType) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).Edges[index2]).EdgeID, ref intList);
      }
    }
    if (intList.Count > 0)
    {
      buFile5.SortList(SortDirectionType.Lower, ref intList);
      EdgeID = intList[intList.Count - 1] + 1;
      ++MarbleDisplaySettings.MarbleEdgeID;
    }
    else
    {
      EdgeID = MarbleDisplaySettings.MarbleEdgeID;
      ++MarbleDisplaySettings.MarbleEdgeID;
    }
  }

  public void GetStripID(MarbleJob Job, ref int StripID)
  {
    List<int> intList = new List<int>();
    for (int index1 = 0; index1 <= ((MarbleProgramSettings) Job).Items.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).Edges.Count - 1; ++index2)
      {
        if (((MarbleContourMenuType) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).Edges[index2]).Slat != null && ((MarbleMotionCommands) ((MarbleConcaveArcOffsetCalculationType) ((MarbleContourMenuType) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).Edges[index2]).Slat).DataSlat).StripID >= 0)
          buFile5.AddValueToList(((MarbleMotionCommands) ((MarbleConcaveArcOffsetCalculationType) ((MarbleContourMenuType) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).Edges[index2]).Slat).DataSlat).StripID, ref intList);
      }
    }
    if (intList.Count > 0)
    {
      buFile5.SortList(SortDirectionType.Lower, ref intList);
      StripID = intList[intList.Count - 1] + 1;
      ++MarbleDisplaySettings.MarbleStripID;
    }
    else
    {
      StripID = MarbleDisplaySettings.MarbleStripID;
      ++MarbleDisplaySettings.MarbleStripID;
    }
  }

  public void GetJobBoxSize(ref MarbleJob Job)
  {
    List<Point3D> Points = new List<Point3D>();
    for (int index = 0; index <= ((MarbleProgramSettings) Job).Items.Count - 1; ++index)
    {
      Points.Add(F_NotchEdit.ToPoint3D(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index]).SizeItem).MinPoint));
      Points.Add(F_NotchEdit.ToPoint3D(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index]).SizeItem).MaxPoint));
    }
    buCall.\u0001.BoxSizeCalculate(Points, ref ((SortOptions) ((MarbleProgramSettings) Job).Material).BoxMinPoint, ref ((SortCamData) ((MarbleProgramSettings) Job).Material).BoxMaxPoint);
    ((SortResult) ((MarbleProgramSettings) Job).Material).Size.Width = ((SortCamData) ((MarbleProgramSettings) Job).Material).BoxMaxPoint.X - ((SortOptions) ((MarbleProgramSettings) Job).Material).BoxMinPoint.X;
    ((SortResult) ((MarbleProgramSettings) Job).Material).Size.Height = ((SortCamData) ((MarbleProgramSettings) Job).Material).BoxMaxPoint.Y - ((SortOptions) ((MarbleProgramSettings) Job).Material).BoxMinPoint.Y;
    ((SortResult) ((MarbleProgramSettings) Job).Material).Size.Depth = ((SortCamData) ((MarbleProgramSettings) Job).Material).BoxMaxPoint.Z - ((SortOptions) ((MarbleProgramSettings) Job).Material).BoxMinPoint.Z;
  }
}
