// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleLatheVerticalPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleLatheVerticalPars : buSerilization5
{
  public ColorDrawType colorCamG0;
  public ColorDrawType colorCamG1;
  public ColorDrawType colorCamPlunge;
  public ColorDrawType colorCamLeave;
  public ColorDrawType colorCamConnection;
  public ColorDrawType colorCamLeadInOut;

  public void MarbleEntityDataToCamParameter(marbleEntityData Data, ref camParameters5 CamPar)
  {
    CamPar.Steps.EndValue = ((MarbleMotionCommands) Data).TargetZ;
  }

  public void GetLastCamPointOfItem(MarbleItem Item, ref TpPnt9D LastP9)
  {
    if (Item != null)
    {
      if ((((MarbleScreenCaptureSettings) Item).CamList == null ? 0 : (((MarbleScreenCaptureSettings) Item).CamList.Count > 0 ? 1 : 0)) != 0)
      {
        MarbleItemCam cam = ((MarbleScreenCaptureSettings) Item).CamList[((MarbleScreenCaptureSettings) Item).CamList.Count - 1];
        if (((MarbleMachineOptionsSettings) cam).CamBase != null)
        {
          camTpPoint camPoint = ((MarbleMachineOptionsSettings) cam).CamBase.CamPoints[((MarbleMachineOptionsSettings) cam).CamBase.CamPoints.Count - 1];
          if (camPoint.Points.Count > 0)
            LastP9 = new TpPnt9D(camPoint.Points[camPoint.Points.Count - 1]);
          else
            LastP9 = (TpPnt9D) null;
        }
        else
          LastP9 = (TpPnt9D) null;
      }
      else
        LastP9 = (TpPnt9D) null;
    }
    else
      LastP9 = (TpPnt9D) null;
  }

  public void GetSawCutStepDistances(
    double OperationMaxZ,
    double StockMaxZ,
    double SawCutStep,
    ref List<double> ZPositions)
  {
    double NewStep = 0.0;
    int StepCount = 0;
    this.GetSawCutStepDistances(OperationMaxZ, StockMaxZ, SawCutStep, ref NewStep, ref StepCount, ref ZPositions);
  }

  public void GetSawCutStepDistances(
    double OperationMaxZ,
    double StockMaxZ,
    double SawCutStep,
    ref double NewStep,
    ref int StepCount,
    ref List<double> ZPositions)
  {
    double num = StockMaxZ - OperationMaxZ;
    ZPositions.Clear();
    if (num <= 0.0)
      return;
    StepCount = (int) buFile5.RoundToUpper(num / SawCutStep);
    if (StepCount <= 0)
      StepCount = 1;
    NewStep = Math.Round(num / (double) StepCount, 3) - 0.01;
    if (StepCount == 1)
    {
      ZPositions.Add(OperationMaxZ);
    }
    else
    {
      for (int index = 0; index <= StepCount - 1; ++index)
        ZPositions.Insert(0, OperationMaxZ + NewStep * (double) index);
    }
  }

  public void GetCamIndexFromCamID(List<MarbleItemCam> CamList, int CamID, ref int CamIndex)
  {
    CamIndex = -1;
    for (int index = 0; index <= CamList.Count - 1; ++index)
    {
      if (((MarbleMachineSettings) CamList[index]).CamID == CamID)
      {
        CamIndex = index;
        break;
      }
    }
  }
}
