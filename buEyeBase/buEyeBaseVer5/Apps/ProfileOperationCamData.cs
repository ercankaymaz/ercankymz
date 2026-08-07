// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationCamData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationCamData : buSerilization5
{
  public bool ShowSheetSizeOnDisplay;
  public bool ShowSheetNameOnDisplay;
  public bool ShowSheetPersentageOnDisplay;
  public bool ShowSheetCountOnDisplay;
  public bool DrawPartAsSolid;
  public bool DrawPartOnlyOutterSolid;
  public bool PartAreaOnlyFromOutter;
  public bool DrawSheets;
  public bool DrawSheetOnlyPreview;
  public HorizontalVertical DrawNestingResultAligment;
  public double DrawNestingResultSpace;
  public bool DrawAddClearAll;
  public bool DrawAddToEnd;
  public double DrawAddToEndOffset;
  public double RemnantMinLength;
  public double RemnantSizeOffset;
  public bool RemnantCalculate;
  public static List<string> Captions;
  public bool PartInnerShow;
  public bool SheetUselessShow;
  public bool DrawAsSolid;
  public Color PartSolidColor;
  public Color SheetSolidColor;
  public Color PartEntityColor;

  public bool isPositionInsideMinMax(
    double X,
    List<MinMax> MinMaxList,
    ref double distanceToMin,
    ref double distanceToMax)
  {
    try
    {
      for (int index = 0; index <= MinMaxList.Count - 1; ++index)
      {
        if (MinMaxList[index].Min <= X & X <= MinMaxList[index].Max)
        {
          distanceToMin = X - MinMaxList[index].Min;
          distanceToMax = MinMaxList[index].Max - X;
          return true;
        }
      }
      return false;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public bool isPreOPCalmperSequenceCloseToCurrentClamper(
    GProfileOperation PreOP,
    GProfileOperation CurrentOP,
    int ClamperIndex,
    double ClamperCloseToDistance,
    double LeftDistance,
    double RightDistance,
    double ClamperWidth,
    ref ProfileClamper CurrentClamper)
  {
    bool currentClamper;
    if (ClamperIndex <= ((ProfileRuntimeSettings) PreOP).Clampers.Count - 1)
    {
      if (Math.Abs(((PanelCutMoveCommand) ((ProfileRuntimeSettings) PreOP).Clampers[ClamperIndex]).XPosition - ((PanelCutMoveCommand) CurrentClamper).XPosition) < ClamperCloseToDistance)
      {
        OperationInsideClampers Options = (OperationInsideClampers) new MarbleDisplaySettings(LeftDistance, RightDistance, ClamperWidth);
        if (!((ProfileOperationDataText) this).isOperationInsideClamper(CurrentOP, ((ProfileRuntimeSettings) PreOP).Clampers[ClamperIndex], Options))
          CurrentClamper = (ProfileClamper) new MarbleItemSettings(((ProfileRuntimeSettings) PreOP).Clampers[ClamperIndex]);
      }
      currentClamper = true;
    }
    else
      currentClamper = false;
    return currentClamper;
  }

  public bool FindSuitableArea(
    List<GProfileOperationGroup> Groups,
    int startIndex,
    ProfileClamperSettings Settings,
    ref List<double> FoundX)
  {
    FoundX = new List<double>();
    bool suitableArea;
    if (startIndex < 0)
    {
      suitableArea = false;
    }
    else
    {
      for (int index1 = startIndex; index1 <= Groups.Count - 2; ++index1)
      {
        bool flag = false;
        for (int index2 = 0; index2 <= ((ProfileSettings) Groups[index1 + 1]).OpList.Count - 1; ++index2)
        {
          if (((ProfileMirror) ((ProfileRuntimeSettings) ((ProfileSettings) Groups[index1 + 1]).OpList[index2]).OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) ((ProfileRuntimeSettings) ((ProfileSettings) Groups[index1 + 1]).OpList[index2]).OperationData).selectedPlaneName == planeNames.Back | ((ProfileMirror) ((ProfileRuntimeSettings) ((ProfileSettings) Groups[index1 + 1]).OpList[index2]).OperationData).selectedPlaneName == planeNames.Free)
            flag = true;
        }
        if (flag)
        {
          if (((FlatViewSettings) ((ProfileSettings) Groups[index1 + 1]).Size).MinPoint.X - ((MachineSimulation) ((ProfileSettings) Groups[index1]).Size).MaxPoint.X > ((buMarbleCalc) Settings).OperationFrontLeftMinDistance + ((buMarbleCalc) Settings).OperationFrontRightMinDistance)
          {
            double num = ((MachineSimulation) ((ProfileSettings) Groups[index1]).Size).MaxPoint.X + ((buMarbleCalc) Settings).OperationFrontRightMinDistance;
            FoundX.Add(num);
          }
        }
        else if (((FlatViewSettings) ((ProfileSettings) Groups[index1 + 1]).Size).MidPoint.X - ((MachineSimulation) ((ProfileSettings) Groups[index1]).Size).MaxPoint.X > ((buMarbleCalc) Settings).OperationFrontLeftMinDistance + ((buMarbleCalc) Settings).OperationFrontRightMinDistance)
        {
          double num = ((MachineSimulation) ((ProfileSettings) Groups[index1]).Size).MaxPoint.X + ((buMarbleCalc) Settings).OperationFrontRightMinDistance;
          FoundX.Add(num);
        }
      }
      suitableArea = FoundX.Count != 0;
    }
    return suitableArea;
  }

  public void AddForbiddenAreaToList(MinMax ForbiddernPoint, ref List<MinMax> ForbiddenAreas)
  {
    if (ForbiddenAreas.Count == 0)
    {
      ForbiddenAreas.Add(ForbiddernPoint);
    }
    else
    {
      for (int index = 0; index <= ForbiddenAreas.Count - 1; ++index)
      {
        bool flag1 = buFile5.IsValueInsideMinMaxValues(ForbiddernPoint.Min, ForbiddenAreas[index].Min, ForbiddenAreas[index].Max);
        bool flag2 = buFile5.IsValueInsideMinMaxValues(ForbiddernPoint.Max, ForbiddenAreas[index].Min, ForbiddenAreas[index].Max);
        if (!flag1 & !flag2)
          ForbiddenAreas.Add(ForbiddernPoint);
        else if (flag1 & !flag2)
          ForbiddenAreas[index].Max = ForbiddernPoint.Max;
        else if (!flag1 & flag2)
          ForbiddenAreas[index].Min = ForbiddernPoint.Min;
      }
    }
  }

  public void MoveFwdClampersFromIndex(
    int refIndex,
    double MinClamperDistance,
    ref List<ProfileClamper> Clampers)
  {
    if (!(refIndex >= 0 & refIndex <= Clampers.Count - 1))
      return;
    for (int index = refIndex + 1; index <= Clampers.Count - 1; ++index)
    {
      if (((PanelCutMoveCommand) Clampers[index]).XPosition - ((PanelCutMoveCommand) Clampers[index - 1]).XPosition < MinClamperDistance)
        ((PanelCutMoveCommand) Clampers[index]).XPosition = ((PanelCutMoveCommand) Clampers[index - 1]).XPosition + MinClamperDistance;
    }
  }

  public void MoveBwdClampersFromIndex(
    int refIndex,
    double MinClamperDistance,
    ref List<ProfileClamper> Clampers)
  {
    if (!(refIndex >= 0 & refIndex <= Clampers.Count - 1))
      return;
    for (int index = refIndex - 1; index >= 0; --index)
    {
      if (((PanelCutMoveCommand) Clampers[index + 1]).XPosition - ((PanelCutMoveCommand) Clampers[index]).XPosition < MinClamperDistance)
        ((PanelCutMoveCommand) Clampers[index]).XPosition = ((PanelCutMoveCommand) Clampers[index + 1]).XPosition - MinClamperDistance;
    }
  }
}
