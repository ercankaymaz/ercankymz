// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCountertopInsidePars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopInsidePars : buSerilization5
{
  public double MaxAllowedAngleA;
  public bool DontCheckZValues;
  public bool VerticalBackToFront;
  public bool HorizontalLeftToRight;
  public bool UseSawCuttings;
  public bool UseCornerByMilling;
  public bool UseCornerByDrill;
  public bool UseMillingCuttings;
  public bool UseDrillCut;
  public bool ToolPathPointDistributionMode;
  public bool CutSameDirection;
  public double CutTolerance;

  public void GetIDs(MarbleJob Job, ref int ItemID, ref int MarbleCamID)
  {
    this.GetCamID(Job, ref MarbleCamID);
    this.GetItemID(Job, ref ItemID);
  }

  public void GetItemID(MarbleJob Job, ref int ItemID)
  {
    List<int> intList = new List<int>();
    for (int index = 0; index <= ((MarbleProgramSettings) Job).Items.Count - 1; ++index)
    {
      if (((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index]).ID >= 0)
        buFile5.AddValueToList(((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index]).ID, ref intList);
    }
    if (intList.Count > 0)
    {
      buFile5.SortList(SortDirectionType.Lower, ref intList);
      ItemID = intList[intList.Count - 1] + 1;
    }
    else
      ItemID = 1;
  }

  public void GetCamID(MarbleJob Job, ref int MarbleCamID)
  {
    List<int> intList = new List<int>();
    for (int index1 = 0; index1 <= ((MarbleProgramSettings) Job).Items.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).CamList.Count - 1; ++index2)
      {
        if (((MarbleMachineSettings) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).CamList[index2]).CamID >= 0)
          buFile5.AddValueToList(((MarbleMachineSettings) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).CamList[index2]).CamID, ref intList);
      }
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

  public void GetCamID(MarbleJob Job, List<MarbleItemCam> CamList, ref int MarbleCamID)
  {
    List<int> intList = new List<int>();
    for (int index1 = 0; index1 <= ((MarbleProgramSettings) Job).Items.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).CamList.Count - 1; ++index2)
      {
        if (((MarbleMachineSettings) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).CamList[index2]).CamID >= 0)
          buFile5.AddValueToList(((MarbleMachineSettings) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).CamList[index2]).CamID, ref intList);
      }
    }
    for (int index = 0; index <= CamList.Count - 1; ++index)
      buFile5.AddValueToList(((MarbleMachineSettings) CamList[index]).CamID, ref intList);
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
}
