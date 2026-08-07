// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buQuiltingCalc
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buCore;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buQuiltingCalc
{
  public void SimulationPointDevide(
    PipeBendSimulationMove P0,
    PipeBendSimulationMove P1,
    double Length,
    int Count,
    double LastExecuteX,
    ref List<PipeBendSimulationMove> devidedPoints)
  {
    devidedPoints.Clear();
    if (Count > 0)
    {
      double num1 = ((NoneContinousResult) P1).YPos - ((NoneContinousResult) P0).YPos;
      double num2 = ((NoneContinousResult) P1).ZPos - ((NoneContinousResult) P0).ZPos;
      double num3 = ((FoamUpdateArg) P1).CPos - ((FoamUpdateArg) P0).CPos;
      double length = ((OperationSizeCalcArgs) P1).Length;
      double num4 = ((NoneContinousResult) P1).YPreasurePos - ((NoneContinousResult) P0).YPreasurePos;
      double num5 = num1 / (double) Count;
      double num6 = num2 / (double) Count;
      double num7 = num3 / (double) Count;
      double num8 = num4 / (double) Count;
      double num9 = Math.Round(length / (double) Count, 5);
      if (!buCompare.EQ(num3, 0.0))
        num9 = Math.Abs(Math.Round(Math.PI * ((FoamUpdateArg) P1).Radius * 2.0 * Math.Abs(((FoamUpdateArg) P1).CPos) / 360.0 / (double) Count, 5));
      if (num1 != 0.0 | num2 != 0.0 | num3 != 0.0 | num4 != 0.0 | length != 0.0)
      {
        for (double num10 = 1.0; num10 <= (double) Count; ++num10)
        {
          PipeBendSimulationMove bendSimulationMove = (PipeBendSimulationMove) new buDrillCalc(P0);
          ((OperationSizeCalcArgs) bendSimulationMove).Length = ((OperationSizeCalcArgs) bendSimulationMove).Length + num10 * num9;
          ((FoamUpdateArg) bendSimulationMove).BendPos = ((FoamUpdateArg) P1).BendPos;
          ((FoamUpdateArg) bendSimulationMove).RotatePos = ((FoamUpdateArg) P1).RotatePos;
          ((buSewingCalc) bendSimulationMove).IndexMove = ((buSewingCalc) P1).IndexMove;
          ((buSewingCalc) bendSimulationMove).MovePipe = ((buSewingCalc) P1).MovePipe;
          ((NoneContinousResult) bendSimulationMove).YPos = ((NoneContinousResult) bendSimulationMove).YPos + num10 * num5;
          ((NoneContinousResult) bendSimulationMove).ZPos = ((NoneContinousResult) bendSimulationMove).ZPos + num10 * num6;
          ((FoamUpdateArg) bendSimulationMove).CPos = ((FoamUpdateArg) bendSimulationMove).CPos + num10 * num7;
          ((NoneContinousResult) bendSimulationMove).YPreasurePos = ((NoneContinousResult) bendSimulationMove).YPreasurePos + num10 * num8;
          ((NoneContinousResult) bendSimulationMove).ExecutedPipe = num10 * Math.Abs(num9) + LastExecuteX;
          ((OperationSizeCalcArgs) bendSimulationMove).ExecutedStep = num9;
          devidedPoints.Add(bendSimulationMove);
        }
      }
      else
      {
        PipeBendSimulationMove bendSimulationMove = (PipeBendSimulationMove) new buDrillCalc(P1);
        ((NoneContinousResult) bendSimulationMove).ExecutedPipe = LastExecuteX;
        devidedPoints.Add(bendSimulationMove);
      }
    }
    else
      buNumeric5.MessageBoxError("Not Ready SimulationPointDevide");
  }
}
