// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camSpeedsEnable
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
public class camSpeedsEnable : buSerilization5
{
  public double Leave;
  public bool LeaveEnable;
  public double Finish;
  public bool FinishEnable;
  public double FirstStep;
  public double SpindleSpeed;
  public bool SpindleEnable;

  static camSpeedsEnable() => camStep5.Captions = new List<string>();

  public camSpeedsEnable()
  {
    ((camStep5) this).Enable = false;
    ((camStep5) this).FirstValue = 0.0;
    ((camStep5) this).StartValue = 20.0;
    ((camStep5) this).EndValue = 0.0;
    ((camStep5) this).Distance = 10.0;
    ((camStep5) this).DepthStep = 1.0;
    ((camStep5) this).StartOffset = 0.0;
    ((camStep5) this).EndOffset = 0.0;
    ((camStep5) this).NumberOfSlice = 1;
    ((camSpeeds5) this).Count = 1;
    ((camSpeeds5) this).Step = 2.0;
    ((camSpeeds5) this).MoveUp = 1.0;
    ((camSpeeds5) this).NumberOfPasses4DepthStep = 0;
    ((camSpeeds5) this).FinalDepthStep = 0.0;
    ((camSpeeds5) this).MoveUpEnable = false;
    ((camSpeeds5) this).DepthStepEnable = false;
    ((camSpeeds5) this).MoveUpType = CamMoveUpType.Absolute;
    ((camSpeeds5) this).StepType = CamStepType.StartToDistanceByCount;
    ((camSpeeds5) this).DepthStepMode = CamStepDepthMode.ConstantDepthStep;
    ((camSpeeds5) this).HeightType = CamHeightsType.ShpHtAutomatic;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public camSpeedsEnable(
    bool enable,
    double startValue,
    double endValue,
    double distance,
    int count,
    double step,
    CamStepType type)
  {
    ((camStep5) this).Enable = false;
    ((camStep5) this).FirstValue = 0.0;
    ((camStep5) this).StartValue = 20.0;
    ((camStep5) this).EndValue = 0.0;
    ((camStep5) this).Distance = 10.0;
    ((camStep5) this).DepthStep = 1.0;
    ((camStep5) this).StartOffset = 0.0;
    ((camStep5) this).EndOffset = 0.0;
    ((camStep5) this).NumberOfSlice = 1;
    ((camSpeeds5) this).Count = 1;
    ((camSpeeds5) this).Step = 2.0;
    ((camSpeeds5) this).MoveUp = 1.0;
    ((camSpeeds5) this).NumberOfPasses4DepthStep = 0;
    ((camSpeeds5) this).FinalDepthStep = 0.0;
    ((camSpeeds5) this).MoveUpEnable = false;
    ((camSpeeds5) this).DepthStepEnable = false;
    ((camSpeeds5) this).MoveUpType = CamMoveUpType.Absolute;
    ((camSpeeds5) this).StepType = CamStepType.StartToDistanceByCount;
    ((camSpeeds5) this).DepthStepMode = CamStepDepthMode.ConstantDepthStep;
    ((camSpeeds5) this).HeightType = CamHeightsType.ShpHtAutomatic;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((camStep5) this).Enable = enable;
    ((camStep5) this).StartValue = startValue;
    ((camStep5) this).EndValue = endValue;
    ((camStep5) this).Distance = distance;
    ((camSpeeds5) this).Count = count;
    ((camSpeeds5) this).Step = step;
    ((camSpeeds5) this).StepType = type;
  }

  public camSpeedsEnable(camStep5 step)
  {
    ((camStep5) this).Enable = false;
    ((camStep5) this).FirstValue = 0.0;
    ((camStep5) this).StartValue = 20.0;
    ((camStep5) this).EndValue = 0.0;
    ((camStep5) this).Distance = 10.0;
    ((camStep5) this).DepthStep = 1.0;
    ((camStep5) this).StartOffset = 0.0;
    ((camStep5) this).EndOffset = 0.0;
    ((camStep5) this).NumberOfSlice = 1;
    ((camSpeeds5) this).Count = 1;
    ((camSpeeds5) this).Step = 2.0;
    ((camSpeeds5) this).MoveUp = 1.0;
    ((camSpeeds5) this).NumberOfPasses4DepthStep = 0;
    ((camSpeeds5) this).FinalDepthStep = 0.0;
    ((camSpeeds5) this).MoveUpEnable = false;
    ((camSpeeds5) this).DepthStepEnable = false;
    ((camSpeeds5) this).MoveUpType = CamMoveUpType.Absolute;
    ((camSpeeds5) this).StepType = CamStepType.StartToDistanceByCount;
    ((camSpeeds5) this).DepthStepMode = CamStepDepthMode.ConstantDepthStep;
    ((camSpeeds5) this).HeightType = CamHeightsType.ShpHtAutomatic;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) step, ref CopiedClass);
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
    return $"{((camStep5) this).Enable.ToString()} , Cnt: {((camSpeeds5) this).Count.ToString()} , Start: {((camStep5) this).StartValue.ToString()} , Dis: {((camStep5) this).Distance.ToString()}";
  }
}
