// Decompiled with JetBrains decompiler
// Type: buClass.camStep
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class camStep : buSerilization
{
  public bool Enable = false;
  public double StartValue = 20.0;
  public double EndValue = 0.0;
  public double Distance = 10.0;
  public int Count = 1;
  public double Step = 2.0;
  public double MoveUp = 1.0;
  public bool MoveUpEnable = false;
  public CamMoveUpType MoveUpType = CamMoveUpType.Absolute;
  public CamStepType StepType = CamStepType.StartToDistanceByCount;
  public CamMachiningSequenceType Sequence = CamMachiningSequenceType.Region;
  public static List<string> Captions = new List<string>();

  public camStep()
  {
  }

  public camStep(
    bool enable,
    double startValue,
    double endValue,
    double distance,
    int count,
    double step,
    CamStepType type)
  {
    this.Enable = enable;
    this.StartValue = startValue;
    this.EndValue = endValue;
    this.Distance = distance;
    this.Count = count;
    this.Step = step;
    this.StepType = type;
  }

  public camStep(camStep step)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) step, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields != null)
    {
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        string name = fields[index].Name;
        object obj = fields[index].GetValue(CopiedClass);
        fields[index].SetValue((object) this, obj);
      }
    }
  }

  public override string ToString()
  {
    return $"{this.Enable.ToString()} , Cnt: {this.Count.ToString()} , Start: {this.StartValue.ToString()} , Dis: {this.Distance.ToString()}";
  }
}
