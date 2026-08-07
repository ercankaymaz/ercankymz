// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camStep5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class camStep5 : buSerilization5
{
  public double AdditionalOffset;
  public double FinishOffset;
  public int OffsetCount;
  public double OverlapDistance;
  public bool AddToolDiameterAsOffset;
  public double InCutSafeLength;
  public CamClosedContourType ClosedContour;
  public OffsetCornerType Corner;
  public CamOpenContourType OpenContour;
  public CamOpenContourType2 OpenContourOld;
  public static List<string> Captions;
  public static byte f0001DD;
  public bool Enable;
  public double FirstValue;
  public double StartValue;
  public double EndValue;
  public double Distance;
  public double DepthStep;
  public double StartOffset;
  public double EndOffset;
  public int NumberOfSlice;

  public void InchToMm()
  {
    ((camParameters5) this).Distances.Safe = Math.Round(((camParameters5) this).Distances.Safe * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Distances.SafeSmall = Math.Round(((camParameters5) this).Distances.SafeSmall * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Distances.FirstApproach = Math.Round(((camParameters5) this).Distances.FirstApproach * buSystem.InchToMmRatio, 5);
    ((camHole5) ((camParameters5) this).Distances).StepUp = Math.Round(((camHole5) ((camParameters5) this).Distances).StepUp * buSystem.InchToMmRatio, 5);
    ((camHole5) ((camParameters5) this).Distances).LeftSafe = Math.Round(((camHole5) ((camParameters5) this).Distances).LeftSafe * buSystem.InchToMmRatio, 5);
    ((camHole5) ((camParameters5) this).Distances).LeftSafeSmall = Math.Round(((camHole5) ((camParameters5) this).Distances).LeftSafeSmall * buSystem.InchToMmRatio, 5);
    ((camHole5) ((camParameters5) this).Distances).LeftFirstApproach = Math.Round(((camHole5) ((camParameters5) this).Distances).LeftFirstApproach * buSystem.InchToMmRatio, 5);
    ((camHole5) ((camParameters5) this).Distances).LeftStepUp = Math.Round(((camHole5) ((camParameters5) this).Distances).LeftStepUp * buSystem.InchToMmRatio, 5);
    ((camHole5) ((camParameters5) this).Distances).RightSafe = Math.Round(((camHole5) ((camParameters5) this).Distances).RightSafe * buSystem.InchToMmRatio, 5);
    ((camMaterial5) ((camParameters5) this).Distances).RightSafeSmall = Math.Round(((camMaterial5) ((camParameters5) this).Distances).RightSafeSmall * buSystem.InchToMmRatio, 5);
    ((camMaterial5) ((camParameters5) this).Distances).RightFirstApproach = Math.Round(((camMaterial5) ((camParameters5) this).Distances).RightFirstApproach * buSystem.InchToMmRatio, 5);
    ((camMaterial5) ((camParameters5) this).Distances).RightStepUp = Math.Round(((camMaterial5) ((camParameters5) this).Distances).RightStepUp * buSystem.InchToMmRatio, 5);
    ((camMaterial5) ((camParameters5) this).Distances).Air = Math.Round(((camMaterial5) ((camParameters5) this).Distances).Air * buSystem.InchToMmRatio, 5);
    ((camMaterial5) ((camParameters5) this).Distances).Rapid = Math.Round(((camMaterial5) ((camParameters5) this).Distances).Rapid * buSystem.InchToMmRatio, 5);
    ((camDrill5) ((camParameters5) this).Distances).EntryAndExit = Math.Round(((camDrill5) ((camParameters5) this).Distances).EntryAndExit * buSystem.InchToMmRatio, 5);
    ((camDistances5) ((camParameters5) this).Speeds).AreaClearance = Math.Round(((camDistances5) ((camParameters5) this).Speeds).AreaClearance * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Speeds.Feed = Math.Round(((camParameters5) this).Speeds.Feed * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Speeds.BackwardFeed = Math.Round(((camParameters5) this).Speeds.BackwardFeed * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Speeds.Plunge = Math.Round(((camParameters5) this).Speeds.Plunge * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Speeds.Rapid = Math.Round(((camParameters5) this).Speeds.Rapid * buSystem.InchToMmRatio, 5);
    ((camSpeedsEnable) ((camParameters5) this).Speeds).Leave = Math.Round(((camSpeedsEnable) ((camParameters5) this).Speeds).Leave * buSystem.InchToMmRatio, 5);
    ((camSpeedsEnable) ((camParameters5) this).Speeds).Finish = Math.Round(((camSpeedsEnable) ((camParameters5) this).Speeds).Finish * buSystem.InchToMmRatio, 5);
    ((camSpeedsEnable) ((camParameters5) this).Speeds).SpindleSpeed = Math.Round(((camSpeedsEnable) ((camParameters5) this).Speeds).SpindleSpeed * buSystem.InchToMmRatio, 5);
    ((camOperation5) ((camOffset5) this).Drill).EndHeight = Math.Round(((camOperation5) ((camOffset5) this).Drill).EndHeight * buSystem.InchToMmRatio, 5);
    ((camOperation5) ((camOffset5) this).Drill).PeckDepth = Math.Round(((camOperation5) ((camOffset5) this).Drill).PeckDepth * buSystem.InchToMmRatio, 5);
    ((camOperation5) ((camOffset5) this).Drill).PeckMinRetractDistance = Math.Round(((camOperation5) ((camOffset5) this).Drill).PeckMinRetractDistance * buSystem.InchToMmRatio, 5);
    ((camOperation5) ((camOffset5) this).Drill).StartHeight = Math.Round(((camOperation5) ((camOffset5) this).Drill).StartHeight * buSystem.InchToMmRatio, 5);
    ((camStrategy5) ((camOffset5) this).Hatch).CutStep = Math.Round(((camStrategy5) ((camOffset5) this).Hatch).CutStep * buSystem.InchToMmRatio, 5);
    ((camStrategy5) ((camOffset5) this).Hatch).XDirectionLength = Math.Round(((camStrategy5) ((camOffset5) this).Hatch).XDirectionLength * buSystem.InchToMmRatio, 5);
    ((camStrategy5) ((camOffset5) this).Hatch).YDirectionWidth = Math.Round(((camStrategy5) ((camOffset5) this).Hatch).YDirectionWidth * buSystem.InchToMmRatio, 5);
    ((camDrill5) ((camRuntime5) this).Hole).DownStep = Math.Round(((camDrill5) ((camRuntime5) this).Hole).DownStep * buSystem.InchToMmRatio, 5);
    ((camDrill5) ((camRuntime5) this).Hole).EndHeight = Math.Round(((camDrill5) ((camRuntime5) this).Hole).EndHeight * buSystem.InchToMmRatio, 5);
    ((camDrill5) ((camRuntime5) this).Hole).StartHeight = Math.Round(((camDrill5) ((camRuntime5) this).Hole).StartHeight * buSystem.InchToMmRatio, 5);
    ((camDrill5) ((camRuntime5) this).Hole).UpStep = Math.Round(((camDrill5) ((camRuntime5) this).Hole).UpStep * buSystem.InchToMmRatio, 5);
    ((MWCalculationOptions) ((camRuntime5) this).LeadIn).ArcRadius = Math.Round(((MWCalculationOptions) ((camRuntime5) this).LeadIn).ArcRadius * buSystem.InchToMmRatio, 5);
    ((MWCalculationOptions) ((camRuntime5) this).LeadIn).ExtendLength = Math.Round(((MWCalculationOptions) ((camRuntime5) this).LeadIn).ExtendLength * buSystem.InchToMmRatio, 5);
    ((MWCalculationOptions) ((camRuntime5) this).LeadIn).Length = Math.Round(((MWCalculationOptions) ((camRuntime5) this).LeadIn).Length * buSystem.InchToMmRatio, 5);
    ((MWCalculationOptions) ((camOffset5) this).LeadOut).ArcRadius = Math.Round(((MWCalculationOptions) ((camOffset5) this).LeadOut).ArcRadius * buSystem.InchToMmRatio, 5);
    ((MWCalculationOptions) ((camOffset5) this).LeadOut).ExtendLength = Math.Round(((MWCalculationOptions) ((camOffset5) this).LeadOut).ExtendLength * buSystem.InchToMmRatio, 5);
    ((MWCalculationOptions) ((camOffset5) this).LeadOut).Length = Math.Round(((MWCalculationOptions) ((camOffset5) this).LeadOut).Length * buSystem.InchToMmRatio, 5);
    ((camPocket5) ((camRuntime5) this).Material).StartZ = Math.Round(((camPocket5) ((camRuntime5) this).Material).StartZ * buSystem.InchToMmRatio, 5);
    ((camPocket5) ((camRuntime5) this).Material).Thickness = Math.Round(((camPocket5) ((camRuntime5) this).Material).Thickness * buSystem.InchToMmRatio, 5);
    ((camStep5) ((camParameters5) this).Offsets).AdditionalOffset = Math.Round(((camStep5) ((camParameters5) this).Offsets).AdditionalOffset * buSystem.InchToMmRatio, 5);
    ((camStep5) ((camParameters5) this).Offsets).FinishOffset = Math.Round(((camStep5) ((camParameters5) this).Offsets).FinishOffset * buSystem.InchToMmRatio, 5);
    ((camStep5) ((camParameters5) this).Offsets).InCutSafeLength = Math.Round(((camStep5) ((camParameters5) this).Offsets).InCutSafeLength * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Offsets.Offset = Math.Round(((camParameters5) this).Offsets.Offset * buSystem.InchToMmRatio, 5);
    ((camStep5) ((camParameters5) this).Offsets).OverlapDistance = Math.Round(((camStep5) ((camParameters5) this).Offsets).OverlapDistance * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Operations.BaseThickness = Math.Round(((camParameters5) this).Operations.BaseThickness * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Operations.Depth = Math.Round(((camParameters5) this).Operations.Depth * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Operations.Height = Math.Round(((camParameters5) this).Operations.Height * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Operations.Overlap = Math.Round(((camParameters5) this).Operations.Overlap * buSystem.InchToMmRatio, 5);
    ((camOptions5) ((camParameters5) this).Operations).TargetZ = Math.Round(((camOptions5) ((camParameters5) this).Operations).TargetZ * buSystem.InchToMmRatio, 5);
    ((camOptions5) ((camParameters5) this).Operations).Thickness = Math.Round(((camOptions5) ((camParameters5) this).Operations).Thickness * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Operations.Width = Math.Round(((camParameters5) this).Operations.Width * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Options.PocketNextContourMaxDistance = Math.Round(((camParameters5) this).Options.PocketNextContourMaxDistance * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Options.StockHeight = Math.Round(((camParameters5) this).Options.StockHeight * buSystem.InchToMmRatio, 5);
    ((camRotary5) ((camParameters5) this).Options).WidthXDirection = Math.Round(((camRotary5) ((camParameters5) this).Options).WidthXDirection * buSystem.InchToMmRatio, 5);
    ((camRotary5) ((camParameters5) this).Options).WidthXYDirection = Math.Round(((camRotary5) ((camParameters5) this).Options).WidthXYDirection * buSystem.InchToMmRatio, 5);
    ((camRotary5) ((camParameters5) this).Options).WidthYDirection = Math.Round(((camRotary5) ((camParameters5) this).Options).WidthYDirection * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Steps.DepthStep = Math.Round(((camParameters5) this).Steps.DepthStep * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Steps.Distance = Math.Round(((camParameters5) this).Steps.Distance * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Steps.EndValue = Math.Round(((camParameters5) this).Steps.EndValue * buSystem.InchToMmRatio, 5);
    ((camSpeeds5) ((camParameters5) this).Steps).MoveUp = Math.Round(((camSpeeds5) ((camParameters5) this).Steps).MoveUp * buSystem.InchToMmRatio, 5);
    ((camParameters5) this).Steps.StartValue = Math.Round(((camParameters5) this).Steps.StartValue * buSystem.InchToMmRatio, 5);
    ((camSpeeds5) ((camParameters5) this).Steps).Step = Math.Round(((camSpeeds5) ((camParameters5) this).Steps).Step * buSystem.InchToMmRatio, 5);
  }

  public abstract void m0000FF();

  public camStep5()
  {
    ((camOffset5) this).CamID = 0;
    ((camOffset5) this).SimG1DevideLength = 1.0;
    ((camOffset5) this).SimG0DevideLength = 10.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public camStep5(camRuntime5 offset)
  {
    ((camOffset5) this).CamID = 0;
    ((camOffset5) this).SimG1DevideLength = 1.0;
    ((camOffset5) this).SimG0DevideLength = 10.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) offset, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString() => "ID: " + ((camOffset5) this).CamID.ToString();
}
