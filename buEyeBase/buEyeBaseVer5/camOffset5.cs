// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camOffset5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class camOffset5 : buSerilization5
{
  public LeadOut5 LeadOut;
  public camHatch5 Hatch;
  public camDrill5 Drill;
  public camNotch5 Notch;
  public camRuntime5 Runtime;
  public SortSettings Sorting;
  public static byte f0001CB;
  public int CamID;
  public double SimG1DevideLength;
  public double SimG0DevideLength;
  public static byte f0001CF;
  public bool Enable;
  public double Offset;

  public static void Decode(ArrayList AL, string Char, ref camParameters5 Par)
  {
    buSerilization5.Decode(AL, Char, (SerilizationMode5) 1, (object) Par.Distances);
    buSerilization5.Decode(AL, Char, (SerilizationMode5) 1, (object) Par.Operations);
    buSerilization5.Decode(AL, Char, (SerilizationMode5) 1, (object) ((camRuntime5) Par).LeadIn);
    buSerilization5.Decode(AL, Char, (SerilizationMode5) 1, (object) ((camOffset5) Par).LeadOut);
    buSerilization5.Decode(AL, Char, (SerilizationMode5) 1, (object) Par.Offsets);
    buSerilization5.Decode(AL, Char, (SerilizationMode5) 1, (object) Par.Steps);
    buSerilization5.Decode(AL, Char, (SerilizationMode5) 1, (object) Par.Speeds);
    buSerilization5.Decode(AL, Char, (SerilizationMode5) 1, (object) Par.Options);
    buSerilization5.Decode(AL, Char, (SerilizationMode5) 1, (object) Par.Strategy);
    buSerilization5.Decode(AL, Char, (SerilizationMode5) 1, (object) Par.Pockets);
    buSerilization5.Decode(AL, Char, (SerilizationMode5) 1, (object) ((camRuntime5) Par).Hole);
    buSerilization5.Decode(AL, Char, (SerilizationMode5) 1, (object) ((camOffset5) Par).Hatch);
    buSerilization5.Decode(AL, Char, (SerilizationMode5) 1, (object) ((camOffset5) Par).Drill);
    buSerilization5.Decode(AL, Char, (SerilizationMode5) 1, (object) ((camOffset5) Par).Sorting);
    buSerilization5.Decode(AL, Char, (SerilizationMode5) 1, (object) Par.Rotary);
  }

  public static void ToDef(
    camParameters5 Par,
    ref ArrayList AL,
    string Char,
    int Space,
    SerilizationMode5 DefMode)
  {
    AL.AddRange((ICollection) Par.Distances.ToDefAll(Char, Space, (SerilizationMode5) 1));
    AL.AddRange((ICollection) Par.Operations.ToDefAll(Char, Space, (SerilizationMode5) 1));
    AL.AddRange((ICollection) ((camRuntime5) Par).LeadIn.ToDefAll(Char, Space, (SerilizationMode5) 1));
    AL.AddRange((ICollection) ((camOffset5) Par).LeadOut.ToDefAll(Char, Space, (SerilizationMode5) 1));
    AL.AddRange((ICollection) Par.Offsets.ToDefAll(Char, Space, (SerilizationMode5) 1));
    AL.AddRange((ICollection) Par.Steps.ToDefAll(Char, Space, (SerilizationMode5) 1));
    AL.AddRange((ICollection) Par.Speeds.ToDefAll(Char, Space, (SerilizationMode5) 1));
    AL.AddRange((ICollection) Par.Options.ToDefAll(Char, Space, (SerilizationMode5) 1));
    AL.AddRange((ICollection) Par.Strategy.ToDefAll(Char, Space, (SerilizationMode5) 1));
    AL.AddRange((ICollection) Par.Pockets.ToDefAll(Char, Space, (SerilizationMode5) 1));
    AL.AddRange((ICollection) ((camRuntime5) Par).Hole.ToDefAll(Char, Space, (SerilizationMode5) 1));
    AL.AddRange((ICollection) ((camOffset5) Par).Hatch.ToDefAll(Char, Space, (SerilizationMode5) 1));
    AL.AddRange((ICollection) ((camOffset5) Par).Drill.ToDefAll(Char, Space, (SerilizationMode5) 1));
    AL.AddRange((ICollection) ((camOffset5) Par).Sorting.ToDefAll(Char, Space, (SerilizationMode5) 1));
    AL.AddRange((ICollection) Par.Rotary.ToDefAll(Char, Space, (SerilizationMode5) 1));
  }

  public static void DecodeSingleLine(List<string> SL, string Char, ref camParameters5 Par)
  {
    Par = new camParameters5();
    if (SL.Count >= 1)
    {
      object distances = (object) Par.Distances;
      buSerilization5.StringToClass(ref distances, SL[0]);
    }
    if (SL.Count >= 2)
    {
      object drill = (object) ((camOffset5) Par).Drill;
      buSerilization5.StringToClass(ref drill, SL[1]);
    }
    if (SL.Count >= 3)
    {
      object hatch = (object) ((camOffset5) Par).Hatch;
      buSerilization5.StringToClass(ref hatch, SL[2]);
    }
    if (SL.Count >= 4)
    {
      object hole = (object) ((camRuntime5) Par).Hole;
      buSerilization5.StringToClass(ref hole, SL[3]);
    }
    if (SL.Count >= 5)
    {
      object leadIn = (object) ((camRuntime5) Par).LeadIn;
      buSerilization5.StringToClass(ref leadIn, SL[4]);
    }
    if (SL.Count >= 6)
    {
      object leadOut = (object) ((camOffset5) Par).LeadOut;
      buSerilization5.StringToClass(ref leadOut, SL[5]);
    }
    if (SL.Count >= 7)
    {
      object material = (object) ((camRuntime5) Par).Material;
      buSerilization5.StringToClass(ref material, SL[6]);
    }
    if (SL.Count >= 8)
    {
      object notch = (object) ((camOffset5) Par).Notch;
      buSerilization5.StringToClass(ref notch, SL[7]);
    }
    if (SL.Count >= 9)
    {
      object offsets = (object) Par.Offsets;
      buSerilization5.StringToClass(ref offsets, SL[8]);
    }
    if (SL.Count >= 10)
    {
      object operations = (object) Par.Operations;
      buSerilization5.StringToClass(ref operations, SL[9]);
    }
    if (SL.Count >= 11)
    {
      object options = (object) Par.Options;
      buSerilization5.StringToClass(ref options, SL[10]);
    }
    if (SL.Count >= 12)
    {
      object pockets = (object) Par.Pockets;
      buSerilization5.StringToClass(ref pockets, SL[11]);
    }
    if (SL.Count >= 13)
    {
      object sorting = (object) ((camOffset5) Par).Sorting;
      buSerilization5.StringToClass(ref sorting, SL[12]);
    }
    if (SL.Count >= 14)
    {
      object speeds = (object) Par.Speeds;
      buSerilization5.StringToClass(ref speeds, SL[13]);
    }
    if (SL.Count >= 15)
    {
      object steps = (object) Par.Steps;
      buSerilization5.StringToClass(ref steps, SL[14]);
    }
    if (SL.Count >= 16 /*0x10*/)
    {
      object strategy = (object) Par.Strategy;
      buSerilization5.StringToClass(ref strategy, SL[15]);
    }
    if (SL.Count < 17)
      return;
    object rotary = (object) Par.Rotary;
    buSerilization5.StringToClass(ref rotary, SL[16 /*0x10*/]);
  }

  public static void ToDefSingleLine(camParameters5 Par, ref ArrayList AL, string Char, int Space)
  {
    AL.Add((object) (buImage5.SpaceChar(Space) + "<CamParametersAll>"));
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParDis = {buSerilization5.ClassToString((object) Par.Distances)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParDrill = {buSerilization5.ClassToString((object) ((camOffset5) Par).Drill)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParHatch = {buSerilization5.ClassToString((object) ((camOffset5) Par).Hatch)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParHole = {buSerilization5.ClassToString((object) ((camRuntime5) Par).Hole)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParLeadIn= {buSerilization5.ClassToString((object) ((camRuntime5) Par).LeadIn)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParLeadOut = {buSerilization5.ClassToString((object) ((camOffset5) Par).LeadOut)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParMaterial = {buSerilization5.ClassToString((object) ((camRuntime5) Par).Material)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParNotch = {buSerilization5.ClassToString((object) ((camOffset5) Par).Notch)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParOffset = {buSerilization5.ClassToString((object) Par.Offsets)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParOperation = {buSerilization5.ClassToString((object) Par.Operations)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParOption = {buSerilization5.ClassToString((object) Par.Options)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParPocket = {buSerilization5.ClassToString((object) Par.Pockets)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParSorting = {buSerilization5.ClassToString((object) ((camOffset5) Par).Sorting)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParSpeed = {buSerilization5.ClassToString((object) Par.Speeds)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParStep = {buSerilization5.ClassToString((object) Par.Steps)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParStrategy = {buSerilization5.ClassToString((object) Par.Strategy)}");
    AL.Add((object) $"{buImage5.SpaceChar(Space + 2)}CamParRotary = {buSerilization5.ClassToString((object) Par.Rotary)}");
    AL.Add((object) (buImage5.SpaceChar(Space) + "</CamParametersAll>"));
  }

  public void MmToInch()
  {
    ((camParameters5) this).Distances.Safe = Math.Round(((camParameters5) this).Distances.Safe * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Distances.SafeSmall = Math.Round(((camParameters5) this).Distances.SafeSmall * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Distances.FirstApproach = Math.Round(((camParameters5) this).Distances.FirstApproach * buSystem.MmToInchRatio, 5);
    ((camHole5) ((camParameters5) this).Distances).StepUp = Math.Round(((camHole5) ((camParameters5) this).Distances).StepUp * buSystem.MmToInchRatio, 5);
    ((camHole5) ((camParameters5) this).Distances).LeftSafe = Math.Round(((camHole5) ((camParameters5) this).Distances).LeftSafe * buSystem.MmToInchRatio, 5);
    ((camHole5) ((camParameters5) this).Distances).LeftSafeSmall = Math.Round(((camHole5) ((camParameters5) this).Distances).LeftSafeSmall * buSystem.MmToInchRatio, 5);
    ((camHole5) ((camParameters5) this).Distances).LeftFirstApproach = Math.Round(((camHole5) ((camParameters5) this).Distances).LeftFirstApproach * buSystem.MmToInchRatio, 5);
    ((camHole5) ((camParameters5) this).Distances).LeftStepUp = Math.Round(((camHole5) ((camParameters5) this).Distances).LeftStepUp * buSystem.MmToInchRatio, 5);
    ((camHole5) ((camParameters5) this).Distances).RightSafe = Math.Round(((camHole5) ((camParameters5) this).Distances).RightSafe * buSystem.MmToInchRatio, 5);
    ((camMaterial5) ((camParameters5) this).Distances).RightSafeSmall = Math.Round(((camMaterial5) ((camParameters5) this).Distances).RightSafeSmall * buSystem.MmToInchRatio, 5);
    ((camMaterial5) ((camParameters5) this).Distances).RightFirstApproach = Math.Round(((camMaterial5) ((camParameters5) this).Distances).RightFirstApproach * buSystem.MmToInchRatio, 5);
    ((camMaterial5) ((camParameters5) this).Distances).RightStepUp = Math.Round(((camMaterial5) ((camParameters5) this).Distances).RightStepUp * buSystem.MmToInchRatio, 5);
    ((camMaterial5) ((camParameters5) this).Distances).Air = Math.Round(((camMaterial5) ((camParameters5) this).Distances).Air * buSystem.MmToInchRatio, 5);
    ((camMaterial5) ((camParameters5) this).Distances).Rapid = Math.Round(((camMaterial5) ((camParameters5) this).Distances).Rapid * buSystem.MmToInchRatio, 5);
    ((camDrill5) ((camParameters5) this).Distances).EntryAndExit = Math.Round(((camDrill5) ((camParameters5) this).Distances).EntryAndExit * buSystem.MmToInchRatio, 5);
    ((camDistances5) ((camParameters5) this).Speeds).AreaClearance = Math.Round(((camDistances5) ((camParameters5) this).Speeds).AreaClearance * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Speeds.Feed = Math.Round(((camParameters5) this).Speeds.Feed * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Speeds.BackwardFeed = Math.Round(((camParameters5) this).Speeds.BackwardFeed * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Speeds.Plunge = Math.Round(((camParameters5) this).Speeds.Plunge * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Speeds.Rapid = Math.Round(((camParameters5) this).Speeds.Rapid * buSystem.MmToInchRatio, 5);
    ((camSpeedsEnable) ((camParameters5) this).Speeds).Leave = Math.Round(((camSpeedsEnable) ((camParameters5) this).Speeds).Leave * buSystem.MmToInchRatio, 5);
    ((camSpeedsEnable) ((camParameters5) this).Speeds).Finish = Math.Round(((camSpeedsEnable) ((camParameters5) this).Speeds).Finish * buSystem.MmToInchRatio, 5);
    ((camSpeedsEnable) ((camParameters5) this).Speeds).SpindleSpeed = Math.Round(((camSpeedsEnable) ((camParameters5) this).Speeds).SpindleSpeed * buSystem.MmToInchRatio, 5);
    ((camOperation5) this.Drill).EndHeight = Math.Round(((camOperation5) this.Drill).EndHeight * buSystem.MmToInchRatio, 5);
    ((camOperation5) this.Drill).PeckDepth = Math.Round(((camOperation5) this.Drill).PeckDepth * buSystem.MmToInchRatio, 5);
    ((camOperation5) this.Drill).PeckMinRetractDistance = Math.Round(((camOperation5) this.Drill).PeckMinRetractDistance * buSystem.MmToInchRatio, 5);
    ((camOperation5) this.Drill).StartHeight = Math.Round(((camOperation5) this.Drill).StartHeight * buSystem.MmToInchRatio, 5);
    ((camStrategy5) this.Hatch).CutStep = Math.Round(((camStrategy5) this.Hatch).CutStep * buSystem.MmToInchRatio, 5);
    ((camStrategy5) this.Hatch).XDirectionLength = Math.Round(((camStrategy5) this.Hatch).XDirectionLength * buSystem.MmToInchRatio, 5);
    ((camStrategy5) this.Hatch).YDirectionWidth = Math.Round(((camStrategy5) this.Hatch).YDirectionWidth * buSystem.MmToInchRatio, 5);
    ((camDrill5) ((camRuntime5) this).Hole).DownStep = Math.Round(((camDrill5) ((camRuntime5) this).Hole).DownStep * buSystem.MmToInchRatio, 5);
    ((camDrill5) ((camRuntime5) this).Hole).EndHeight = Math.Round(((camDrill5) ((camRuntime5) this).Hole).EndHeight * buSystem.MmToInchRatio, 5);
    ((camDrill5) ((camRuntime5) this).Hole).StartHeight = Math.Round(((camDrill5) ((camRuntime5) this).Hole).StartHeight * buSystem.MmToInchRatio, 5);
    ((camDrill5) ((camRuntime5) this).Hole).UpStep = Math.Round(((camDrill5) ((camRuntime5) this).Hole).UpStep * buSystem.MmToInchRatio, 5);
    ((MWCalculationOptions) ((camRuntime5) this).LeadIn).ArcRadius = Math.Round(((MWCalculationOptions) ((camRuntime5) this).LeadIn).ArcRadius * buSystem.MmToInchRatio, 5);
    ((MWCalculationOptions) ((camRuntime5) this).LeadIn).ExtendLength = Math.Round(((MWCalculationOptions) ((camRuntime5) this).LeadIn).ExtendLength * buSystem.MmToInchRatio, 5);
    ((MWCalculationOptions) ((camRuntime5) this).LeadIn).Length = Math.Round(((MWCalculationOptions) ((camRuntime5) this).LeadIn).Length * buSystem.MmToInchRatio, 5);
    ((MWCalculationOptions) this.LeadOut).ArcRadius = Math.Round(((MWCalculationOptions) this.LeadOut).ArcRadius * buSystem.MmToInchRatio, 5);
    ((MWCalculationOptions) this.LeadOut).ExtendLength = Math.Round(((MWCalculationOptions) this.LeadOut).ExtendLength * buSystem.MmToInchRatio, 5);
    ((MWCalculationOptions) this.LeadOut).Length = Math.Round(((MWCalculationOptions) this.LeadOut).Length * buSystem.MmToInchRatio, 5);
    ((camPocket5) ((camRuntime5) this).Material).StartZ = Math.Round(((camPocket5) ((camRuntime5) this).Material).StartZ * buSystem.MmToInchRatio, 5);
    ((camPocket5) ((camRuntime5) this).Material).Thickness = Math.Round(((camPocket5) ((camRuntime5) this).Material).Thickness * buSystem.MmToInchRatio, 5);
    ((camStep5) ((camParameters5) this).Offsets).AdditionalOffset = Math.Round(((camStep5) ((camParameters5) this).Offsets).AdditionalOffset * buSystem.MmToInchRatio, 5);
    ((camStep5) ((camParameters5) this).Offsets).FinishOffset = Math.Round(((camStep5) ((camParameters5) this).Offsets).FinishOffset * buSystem.MmToInchRatio, 5);
    ((camStep5) ((camParameters5) this).Offsets).InCutSafeLength = Math.Round(((camStep5) ((camParameters5) this).Offsets).InCutSafeLength * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Offsets.Offset = Math.Round(((camParameters5) this).Offsets.Offset * buSystem.MmToInchRatio, 5);
    ((camStep5) ((camParameters5) this).Offsets).OverlapDistance = Math.Round(((camStep5) ((camParameters5) this).Offsets).OverlapDistance * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Operations.BaseThickness = Math.Round(((camParameters5) this).Operations.BaseThickness * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Operations.Depth = Math.Round(((camParameters5) this).Operations.Depth * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Operations.Height = Math.Round(((camParameters5) this).Operations.Height * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Operations.Overlap = Math.Round(((camParameters5) this).Operations.Overlap * buSystem.MmToInchRatio, 5);
    ((camOptions5) ((camParameters5) this).Operations).TargetZ = Math.Round(((camOptions5) ((camParameters5) this).Operations).TargetZ * buSystem.MmToInchRatio, 5);
    ((camOptions5) ((camParameters5) this).Operations).Thickness = Math.Round(((camOptions5) ((camParameters5) this).Operations).Thickness * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Operations.Width = Math.Round(((camParameters5) this).Operations.Width * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Options.PocketNextContourMaxDistance = Math.Round(((camParameters5) this).Options.PocketNextContourMaxDistance * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Options.StockHeight = Math.Round(((camParameters5) this).Options.StockHeight * buSystem.MmToInchRatio, 5);
    ((camRotary5) ((camParameters5) this).Options).WidthXDirection = Math.Round(((camRotary5) ((camParameters5) this).Options).WidthXDirection * buSystem.MmToInchRatio, 5);
    ((camRotary5) ((camParameters5) this).Options).WidthXYDirection = Math.Round(((camRotary5) ((camParameters5) this).Options).WidthXYDirection * buSystem.MmToInchRatio, 5);
    ((camRotary5) ((camParameters5) this).Options).WidthYDirection = Math.Round(((camRotary5) ((camParameters5) this).Options).WidthYDirection * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Steps.DepthStep = Math.Round(((camParameters5) this).Steps.DepthStep * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Steps.Distance = Math.Round(((camParameters5) this).Steps.Distance * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Steps.EndValue = Math.Round(((camParameters5) this).Steps.EndValue * buSystem.MmToInchRatio, 5);
    ((camSpeeds5) ((camParameters5) this).Steps).MoveUp = Math.Round(((camSpeeds5) ((camParameters5) this).Steps).MoveUp * buSystem.MmToInchRatio, 5);
    ((camParameters5) this).Steps.StartValue = Math.Round(((camParameters5) this).Steps.StartValue * buSystem.MmToInchRatio, 5);
    ((camSpeeds5) ((camParameters5) this).Steps).Step = Math.Round(((camSpeeds5) ((camParameters5) this).Steps).Step * buSystem.MmToInchRatio, 5);
  }
}
