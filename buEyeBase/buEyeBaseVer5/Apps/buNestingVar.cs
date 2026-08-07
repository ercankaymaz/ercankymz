// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingVar
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingVar : buSerilization5
{
  public bool StepRun;
  public bool EngravingKeepRatio;
  public bool SimStopAtMatReady;
  public int SimStep;
  public double ContourOffset;
  public double ContourDepth;
  public drillCommands DrillCommand;
  public drillCommandBase DrillBaseCommand;
  public drillErpFileType ErpFileType;
  public DrillItemType ItemType;

  public bool DuplicateHolesFromItem(
    drillCommands Command,
    DrillRuntimeSettings Settings,
    DrillItem refDrill,
    ref DrillItemBase refItem,
    DrillJob Job,
    ref double CalcValue)
  {
    bool flag = false;
    if (Command == drillCommands.HorizontalHoles | Command == drillCommands.HorizontalLineHoles)
    {
      int num1 = ((buNestingProgramSettings) Settings).HorizontalCount;
      double num2 = ((buNestingProgramSettings) Settings).HorizontalDistance;
      if (Command == drillCommands.HorizontalLineHoles && ((DrillRuntimeSettings) refItem).HorizontalDistance > 0.0)
      {
        double num3 = ((SortResult) ((DrillSettings) Job).Material).Size.Width - ((DrillRuntimeSettings) refItem).StartDistance - ((DrillRuntimeSettings) refItem).EndDistance;
        if (((buNestingResultSettings) Settings).lastDrillPlaneNames == planeBoxNames.Front | ((buNestingResultSettings) Settings).lastDrillPlaneNames == planeBoxNames.Back)
          num3 = ((SortResult) ((DrillSettings) Job).Material).Size.Height - ((DrillRuntimeSettings) refItem).StartDistance - ((DrillRuntimeSettings) refItem).EndDistance;
        if (num3 > 0.0)
        {
          int int32 = Convert.ToInt32(num3 / ((DrillRuntimeSettings) refItem).HorizontalDistance);
          num2 = num3 / (double) int32;
          num1 = int32 + 1;
          if (!buConversion5.EQ(num2, ((DrillRuntimeSettings) refItem).HorizontalDistance, 0.01))
          {
            CalcValue = num2;
            flag = true;
          }
        }
      }
      if (((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Top | ((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Bottom | ((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Left | ((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Right)
      {
        double num4 = 1.0;
        if (((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Top | ((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Bottom | ((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Right && ((DrillRuntimeSettings) refItem).Corner == CornerLocation.LeftTop | ((DrillRuntimeSettings) refItem).Corner == CornerLocation.LeftBottom)
          num4 = -1.0;
        if (((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Left && ((DrillRuntimeSettings) refItem).Corner == CornerLocation.LeftBottom | ((DrillRuntimeSettings) refItem).Corner == CornerLocation.LeftTop)
          num4 = -1.0;
        for (int index = 0; index <= num1 - 1; ++index)
        {
          DrillItem drillItem = (DrillItem) new buProfileCalc(refDrill);
          ((DrillRuntimeSettings) drillItem).Center.X = ((DrillRuntimeSettings) drillItem).Center.X + num4 * num2 * (double) index;
          ((DrillRuntimeSettings) refItem).Items.Add(drillItem);
        }
      }
      if (((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Front | ((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Back)
      {
        double num5 = 1.0;
        if (((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Front && ((DrillRuntimeSettings) refItem).Corner == CornerLocation.LeftTop | ((DrillRuntimeSettings) refItem).Corner == CornerLocation.LeftBottom)
          num5 = -1.0;
        if (((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Back && ((DrillRuntimeSettings) refItem).Corner == CornerLocation.LeftTop | ((DrillRuntimeSettings) refItem).Corner == CornerLocation.LeftBottom)
          num5 = -1.0;
        for (int index = 0; index <= num1 - 1; ++index)
        {
          DrillItem drillItem = (DrillItem) new buProfileCalc(refDrill);
          ((DrillRuntimeSettings) drillItem).Center.Y = ((DrillRuntimeSettings) drillItem).Center.Y + num5 * num2 * (double) index;
          ((DrillRuntimeSettings) refItem).Items.Add(drillItem);
        }
      }
      ((DrillRuntimeSettings) refItem).HorizontalCount = num1;
      ((DrillRuntimeSettings) refItem).HorizontalDistance = num2;
    }
    if (Command == drillCommands.VerticalHoles | Command == drillCommands.VerticalLineHoles)
    {
      int num6 = ((buNestingProgramSettings) Settings).VerticalCount;
      double num7 = ((buNestingProgramSettings) Settings).VerticalDistance;
      if (Command == drillCommands.VerticalLineHoles && ((DrillRuntimeSettings) refItem).VerticalDistance > 0.0)
      {
        double num8 = ((SortResult) ((DrillSettings) Job).Material).Size.Depth - ((DrillRuntimeSettings) refItem).StartDistance - ((DrillRuntimeSettings) refItem).EndDistance;
        if (((buNestingResultSettings) Settings).lastDrillPlaneNames == planeBoxNames.Top | ((buNestingResultSettings) Settings).lastDrillPlaneNames == planeBoxNames.Bottom)
          num8 = ((SortResult) ((DrillSettings) Job).Material).Size.Height - ((DrillRuntimeSettings) refItem).StartDistance - ((DrillRuntimeSettings) refItem).EndDistance;
        if (num8 > 0.0)
        {
          int int32 = Convert.ToInt32(num8 / ((DrillRuntimeSettings) refItem).VerticalDistance);
          num7 = num8 / (double) int32;
          num6 = int32 + 1;
          if (!buConversion5.EQ(num7, ((DrillRuntimeSettings) refItem).VerticalDistance, 0.01))
          {
            CalcValue = num7;
            flag = true;
          }
        }
      }
      if (((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Top | ((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Bottom)
      {
        double num9 = 1.0;
        if (((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Top | ((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Right && ((DrillRuntimeSettings) refItem).Corner == CornerLocation.LeftBottom | ((DrillRuntimeSettings) refItem).Corner == CornerLocation.RightBottom)
          num9 = -1.0;
        if (((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Bottom && ((DrillRuntimeSettings) refItem).Corner == CornerLocation.LeftTop | ((DrillRuntimeSettings) refItem).Corner == CornerLocation.RightTop)
          num9 = -1.0;
        if (((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Left && ((DrillRuntimeSettings) refItem).Corner == CornerLocation.RightBottom | ((DrillRuntimeSettings) refItem).Corner == CornerLocation.RightTop)
          num9 = -1.0;
        for (int index = 0; index <= num6 - 1; ++index)
        {
          DrillItem drillItem = (DrillItem) new buProfileCalc(refDrill);
          ((DrillRuntimeSettings) drillItem).Center.Y = ((DrillRuntimeSettings) drillItem).Center.Y + num9 * num7 * (double) index;
          ((DrillRuntimeSettings) refItem).Items.Add(drillItem);
        }
      }
      if (((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Right | ((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Left | ((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Front | ((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Back)
      {
        double num10 = 1.0;
        if (((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Right | ((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Left | ((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Front | ((DrillRuntimeSettings) refItem).planeName == planeBoxNames.Back && ((DrillRuntimeSettings) refItem).Corner == CornerLocation.LeftTop | ((DrillRuntimeSettings) refItem).Corner == CornerLocation.RightTop)
          num10 = -1.0;
        for (int index = 0; index <= num6 - 1; ++index)
        {
          DrillItem drillItem = (DrillItem) new buProfileCalc(refDrill);
          ((DrillRuntimeSettings) drillItem).Center.Z = ((DrillRuntimeSettings) drillItem).Center.Z + num10 * num7 * (double) index;
          ((DrillRuntimeSettings) refItem).Items.Add(drillItem);
        }
      }
    }
    return flag;
  }

  public void SimPointMoveCalculate(
    DrillMove PreMove,
    DrillMove CurrentMove,
    double devideLen,
    ref List<DrillMove> calcSimMoves)
  {
    double num1 = Math.Abs(((FindToolSettings) CurrentMove).XPosition - ((FindToolSettings) PreMove).XPosition);
    double num2 = Math.Abs(((DrillUpdateArg) CurrentMove).Y1Position - ((DrillUpdateArg) PreMove).Y1Position);
    double num3 = Math.Abs(((DrillUpdateArg) CurrentMove).Y2Position - ((DrillUpdateArg) PreMove).Y2Position);
    double num4 = Math.Abs(((DrillUpdateArg) CurrentMove).Y3Position - ((DrillUpdateArg) PreMove).Y3Position);
    double num5 = Math.Abs(((ClamperInsideCalc) CurrentMove).Z1Position - ((ClamperInsideCalc) PreMove).Z1Position);
    double num6 = Math.Abs(((ClamperInsideCalc) CurrentMove).Z2Position - ((ClamperInsideCalc) PreMove).Z2Position);
    double num7 = Math.Abs(((ClamperInsideCalc) CurrentMove).Z3Position - ((ClamperInsideCalc) PreMove).Z3Position);
    double num8 = double.MinValue;
    if (((DrillUpdateArg) CurrentMove).Y1Position == 100000.0)
      num2 = 0.0;
    if (((DrillUpdateArg) CurrentMove).Y2Position == 100000.0)
      num3 = 0.0;
    if (((DrillUpdateArg) CurrentMove).Y3Position == 100000.0)
      num4 = 0.0;
    if (((ClamperInsideCalc) CurrentMove).Z1Position == 100000.0)
      num5 = 0.0;
    if (((ClamperInsideCalc) CurrentMove).Z2Position == 100000.0)
      num6 = 0.0;
    if (((ClamperInsideCalc) CurrentMove).Z3Position == 100000.0)
      num7 = 0.0;
    if (devideLen <= 0.0)
    {
      calcSimMoves.Add((DrillMove) new buProfileCalc(CurrentMove));
    }
    else
    {
      if (num1 > num8)
        num8 = num1;
      if (num2 > num8)
        num8 = num2;
      if (num3 > num8)
        num8 = num3;
      if (num4 > num8)
        num8 = num4;
      if (num5 > num8)
        num8 = num5;
      if (num6 > num8)
        num8 = num6;
      if (num7 > num8)
        num8 = num7;
      if (num8 > devideLen)
      {
        int DevideCount = (int) buFile5.RoundToUpper(num8 / devideLen);
        if (DevideCount < 2)
          DevideCount = 2;
        List<double> Values1 = new List<double>();
        List<double> Values2 = new List<double>();
        List<double> Values3 = new List<double>();
        List<double> Values4 = new List<double>();
        List<double> Values5 = new List<double>();
        List<double> Values6 = new List<double>();
        List<double> Values7 = new List<double>();
        List<double> Values8 = new List<double>();
        List<double> Values9 = new List<double>();
        buFile5.DevideMinMaxValueByNumber(((FindToolSettings) PreMove).XPosition, ((FindToolSettings) CurrentMove).XPosition, DevideCount, ref Values1);
        buFile5.DevideMinMaxValueByNumber(((FindToolSettings) PreMove).X1Clamper, ((FindToolSettings) CurrentMove).X1Clamper, DevideCount, ref Values2);
        buFile5.DevideMinMaxValueByNumber(((FindToolSettings) PreMove).X2Clamper, ((FindToolSettings) CurrentMove).X2Clamper, DevideCount, ref Values3);
        buFile5.DevideMinMaxValueByNumber(((DrillUpdateArg) PreMove).Y1Position, ((DrillUpdateArg) CurrentMove).Y1Position, DevideCount, ref Values4);
        buFile5.DevideMinMaxValueByNumber(((DrillUpdateArg) PreMove).Y2Position, ((DrillUpdateArg) CurrentMove).Y2Position, DevideCount, ref Values5);
        buFile5.DevideMinMaxValueByNumber(((DrillUpdateArg) PreMove).Y3Position, ((DrillUpdateArg) CurrentMove).Y3Position, DevideCount, ref Values6);
        buFile5.DevideMinMaxValueByNumber(((ClamperInsideCalc) PreMove).Z1Position, ((ClamperInsideCalc) CurrentMove).Z1Position, DevideCount, ref Values7);
        buFile5.DevideMinMaxValueByNumber(((ClamperInsideCalc) PreMove).Z2Position, ((ClamperInsideCalc) CurrentMove).Z2Position, DevideCount, ref Values8);
        buFile5.DevideMinMaxValueByNumber(((ClamperInsideCalc) PreMove).Z3Position, ((ClamperInsideCalc) CurrentMove).Z3Position, DevideCount, ref Values9);
        for (int index = 0; index <= Values1.Count - 1; ++index)
        {
          DrillMove drillMove = (DrillMove) new buProfileCalc(CurrentMove);
          ((FindToolSettings) drillMove).XPosition = Values1[index];
          ((FindToolSettings) drillMove).X1Clamper = Values2[index];
          ((FindToolSettings) drillMove).X2Clamper = Values3[index];
          ((DrillUpdateArg) drillMove).Y1Position = Values4[index];
          ((DrillUpdateArg) drillMove).Y2Position = Values5[index];
          ((DrillUpdateArg) drillMove).Y3Position = Values6[index];
          ((ClamperInsideCalc) drillMove).Z1Position = Values7[index];
          ((ClamperInsideCalc) drillMove).Z2Position = Values8[index];
          ((ClamperInsideCalc) drillMove).Z3Position = Values9[index];
          calcSimMoves.Add(drillMove);
        }
      }
      else
        calcSimMoves.Add((DrillMove) new buProfileCalc(CurrentMove));
    }
  }
}
