// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationDataFreeDraw
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperationDataFreeDraw : buSerilization5
{
  public double PartArea;
  public double TotalOutSideLength;
  public double TotalInsideLength;
  public double TotalLength;
  public string Name;
  public int GroupCount;

  public int HowManyClamperInsideProfile(ProfileItem Item, double MachineLength)
  {
    try
    {
      int num1 = 0;
      if (((ProfileSettings) Item).XReferanceLocation == LeftRightType.Left)
      {
        for (int index1 = 0; index1 <= ((ProfileSettings) Item).CalculationData.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= ((ProfileSettings) ((ProfileSettings) Item).CalculationData[index1]).calcOperations.Count - 1; ++index2)
          {
            for (int index3 = 0; index3 <= ((ProfileRuntimeSettings) ((ProfileSettings) ((ProfileSettings) Item).CalculationData[index1]).calcOperations[index2]).Clampers.Count - 1; ++index3)
            {
              ProfileClamper clamper = ((ProfileRuntimeSettings) ((ProfileSettings) ((ProfileSettings) Item).CalculationData[index1]).calcOperations[index2]).Clampers[index3];
              if (((PanelCutMoveCommand) clamper).XPosition > 0.0 & ((PanelCutMoveCommand) clamper).XPosition <= ((ProfileSettings) Item).Length + 2.0)
                ++num1;
            }
          }
        }
      }
      else
      {
        double num2 = MachineLength - ((ProfileSettings) Item).Length;
        double num3 = MachineLength;
        for (int index4 = 0; index4 <= ((ProfileSettings) Item).CalculationData.Count - 1; ++index4)
        {
          for (int index5 = 0; index5 <= ((ProfileSettings) ((ProfileSettings) Item).CalculationData[index4]).calcOperations.Count - 1; ++index5)
          {
            for (int index6 = 0; index6 <= ((ProfileRuntimeSettings) ((ProfileSettings) ((ProfileSettings) Item).CalculationData[index4]).calcOperations[index5]).Clampers.Count - 1; ++index6)
            {
              ProfileClamper clamper = ((ProfileRuntimeSettings) ((ProfileSettings) ((ProfileSettings) Item).CalculationData[index4]).calcOperations[index5]).Clampers[index6];
              if (((PanelCutMoveCommand) clamper).XPosition > num2 & ((PanelCutMoveCommand) clamper).XPosition <= num3)
                ++num1;
            }
          }
        }
      }
      return num1;
    }
    catch (Exception ex)
    {
      return 0;
    }
  }

  public void RemoveUnNeccesaryClamperMove(
    List<ProfileClamper> LastClampers,
    GProfileOperation OP,
    ref List<ProfileClamper> CurrentClampers)
  {
    if (!(LastClampers.Count > 0 & CurrentClampers.Count > 0))
      return;
    int index = CurrentClampers.Count - 1;
    if (index < 0)
      return;
    double num = ((PanelCutMoveCommand) CurrentClampers[index]).XPosition - ((PanelCutMoveCommand) LastClampers[index]).XPosition;
    if (num < 0.0 && ((FlatViewSettings) ((ProfileRuntimeSettings) OP).SizePoint).MinPoint.X < ((PanelCutMoveCommand) LastClampers[index]).XPosition & ((MachineSimulation) ((ProfileRuntimeSettings) OP).SizePoint).MaxPoint.X < ((PanelCutMoveCommand) LastClampers[index]).XPosition && ((FlatViewSettings) ((ProfileRuntimeSettings) OP).SizePoint).MinPoint.X < ((PanelCutMoveCommand) CurrentClampers[index]).XPosition & ((MachineSimulation) ((ProfileRuntimeSettings) OP).SizePoint).MaxPoint.X < ((PanelCutMoveCommand) CurrentClampers[index]).XPosition)
      CurrentClampers[index] = (ProfileClamper) new MarbleItemSettings(LastClampers[index]);
    if (num <= 0.0 || !(((PanelCutMoveCommand) LastClampers[index]).XPosition < ((FlatViewSettings) ((ProfileRuntimeSettings) OP).SizePoint).MinPoint.X & ((PanelCutMoveCommand) LastClampers[index]).XPosition < ((MachineSimulation) ((ProfileRuntimeSettings) OP).SizePoint).MaxPoint.X) || !(((PanelCutMoveCommand) CurrentClampers[index]).XPosition < ((FlatViewSettings) ((ProfileRuntimeSettings) OP).SizePoint).MinPoint.X & ((PanelCutMoveCommand) CurrentClampers[index]).XPosition < ((MachineSimulation) ((ProfileRuntimeSettings) OP).SizePoint).MaxPoint.X))
      return;
    CurrentClampers[index] = (ProfileClamper) new MarbleItemSettings(LastClampers[index]);
  }

  public bool isClamperSuitable(
    double MinPosition,
    double MaxPosition,
    double OperationMinDistance,
    double ClamperWidth)
  {
    try
    {
      double num1 = MaxPosition - MinPosition;
      double num2 = OperationMinDistance;
      if (MinPosition > 0.0)
        num2 = OperationMinDistance * 2.0;
      return num1 >= ClamperWidth + num2;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public bool isClamperInsideOperationRange(
    double MinPointX,
    double MaxPointX,
    double LeftDistance,
    double RightDistance,
    double ClamperPosition,
    double ClamperWidth)
  {
    double num1 = MinPointX - LeftDistance;
    double num2 = MaxPointX + RightDistance;
    double num3 = ClamperPosition;
    double num4 = ClamperPosition;
    return num1 < num3 & num3 < num2 || num1 < num4 & num4 < num2 || num1 < ClamperPosition & ClamperPosition < num2;
  }

  public bool isClamperInsideOperationRange(
    GProfileOperation OP,
    double LeftDistance,
    double RightDistance,
    double ClamperPosition,
    double ClamperWidth)
  {
    double num1 = ((FlatViewSettings) ((ProfileRuntimeSettings) OP).SizePoint).MinPoint.X - LeftDistance;
    double num2 = ((MachineSimulation) ((ProfileRuntimeSettings) OP).SizePoint).MaxPoint.X + RightDistance;
    double num3 = ClamperPosition - ClamperWidth / 2.0;
    double num4 = ClamperPosition + ClamperWidth / 2.0;
    return num1 < num3 & num3 < num2 || num1 < num4 & num4 < num2 || num1 < ClamperPosition & ClamperPosition < num2;
  }

  public bool isClamperInsideOperationRange(
    GProfileOperationGroup OP,
    double LeftDistance,
    double RightDistance,
    double ClamperPosition,
    double ClamperWidth)
  {
    double num1 = ((FlatViewSettings) ((ProfileSettings) OP).Size).MinPoint.X - LeftDistance;
    double num2 = ((MachineSimulation) ((ProfileSettings) OP).Size).MaxPoint.X - RightDistance;
    double num3 = ClamperPosition - ClamperWidth / 2.0;
    double num4 = ClamperPosition + ClamperWidth / 2.0;
    return num3 > num1 & num3 < num2 || num4 > num1 & num4 < num2;
  }
}
