// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camSpeeds5
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
public class camSpeeds5 : buSerilization5
{
  public int Count;
  public double Step;
  public double MoveUp;
  public int NumberOfPasses4DepthStep;
  public double FinalDepthStep;
  public bool MoveUpEnable;
  public bool DepthStepEnable;
  public CamMoveUpType MoveUpType;
  public CamStepType StepType;
  public CamStepDepthMode DepthStepMode;
  public CamHeightsType HeightType;
  public static List<string> Captions;
  public static byte f0001F3;
  public double Feed;
  public bool FeedEnable;
  public double BackwardFeed;
  public bool BackwardEnable;
  public double Plunge;
  public bool PlungeEnable;
  public double Rapid;
  public bool RapidEnable;

  public abstract void m000103();

  public camSpeeds5()
  {
    ((camOffset5) this).Enable = true;
    ((camOffset5) this).Offset = 0.0;
    ((camStep5) this).AdditionalOffset = 0.0;
    ((camStep5) this).FinishOffset = 0.0;
    ((camStep5) this).OffsetCount = 1;
    ((camStep5) this).OverlapDistance = 0.0;
    ((camStep5) this).AddToolDiameterAsOffset = false;
    ((camStep5) this).InCutSafeLength = 0.0;
    ((camStep5) this).ClosedContour = CamClosedContourType.Center;
    ((camStep5) this).Corner = OffsetCornerType.Line;
    ((camStep5) this).OpenContour = CamOpenContourType.Center;
    ((camStep5) this).OpenContourOld = CamOpenContourType2.Right;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public camSpeeds5(
    bool enable,
    double offset,
    double addtionalOffset,
    int offsetCount,
    double overlapDistance,
    CamClosedContourType flow,
    OffsetCornerType corner,
    CamOpenContourType2 openContour)
  {
    ((camOffset5) this).Enable = true;
    ((camOffset5) this).Offset = 0.0;
    ((camStep5) this).AdditionalOffset = 0.0;
    ((camStep5) this).FinishOffset = 0.0;
    ((camStep5) this).OffsetCount = 1;
    ((camStep5) this).OverlapDistance = 0.0;
    ((camStep5) this).AddToolDiameterAsOffset = false;
    ((camStep5) this).InCutSafeLength = 0.0;
    ((camStep5) this).ClosedContour = CamClosedContourType.Center;
    ((camStep5) this).Corner = OffsetCornerType.Line;
    ((camStep5) this).OpenContour = CamOpenContourType.Center;
    ((camStep5) this).OpenContourOld = CamOpenContourType2.Right;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((camOffset5) this).Enable = enable;
    ((camOffset5) this).Offset = offset;
    ((camStep5) this).AdditionalOffset = addtionalOffset;
    ((camStep5) this).OffsetCount = offsetCount;
    ((camStep5) this).OverlapDistance = overlapDistance;
    ((camStep5) this).ClosedContour = flow;
    ((camStep5) this).Corner = corner;
    ((camStep5) this).OpenContourOld = openContour;
  }

  public camSpeeds5(camOffset5 offset)
  {
    ((camOffset5) this).Enable = true;
    ((camOffset5) this).Offset = 0.0;
    ((camStep5) this).AdditionalOffset = 0.0;
    ((camStep5) this).FinishOffset = 0.0;
    ((camStep5) this).OffsetCount = 1;
    ((camStep5) this).OverlapDistance = 0.0;
    ((camStep5) this).AddToolDiameterAsOffset = false;
    ((camStep5) this).InCutSafeLength = 0.0;
    ((camStep5) this).ClosedContour = CamClosedContourType.Center;
    ((camStep5) this).Corner = OffsetCornerType.Line;
    ((camStep5) this).OpenContour = CamOpenContourType.Center;
    ((camStep5) this).OpenContourOld = CamOpenContourType2.Right;
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

  public override string ToString()
  {
    return $"{((camOffset5) this).Enable.ToString()} , Offset: {((camOffset5) this).Offset.ToString()} , Flow: {((camStep5) this).ClosedContour.ToString()} , Open: {((camStep5) this).OpenContour.ToString()}";
  }
}
