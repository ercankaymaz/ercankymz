// Decompiled with JetBrains decompiler
// Type: buClass.camStepEnable
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class camStepEnable : buSerilization
{
  public bool StartValue = true;
  public bool EndValue = true;
  public bool Distance = false;
  public bool Count = true;
  public bool Step = false;
  public bool Type = true;
  public bool MoveUp = false;
  public bool MoveUpType = false;
  public bool Sequence = false;
  public static List<string> Captions = new List<string>();

  public camStepEnable()
  {
  }

  public camStepEnable(
    bool startval,
    bool endvalue,
    bool distance,
    bool count,
    bool step,
    bool type)
  {
    this.StartValue = startval;
    this.EndValue = endvalue;
    this.Distance = distance;
    this.Count = count;
    this.Step = step;
    this.Type = type;
  }

  public camStepEnable(
    bool startval,
    bool endvalue,
    bool distance,
    bool count,
    bool step,
    bool type,
    bool moveup,
    bool moveuptype,
    bool sequence)
  {
    this.StartValue = startval;
    this.EndValue = endvalue;
    this.Distance = distance;
    this.Count = count;
    this.Step = step;
    this.Type = type;
    this.MoveUp = moveup;
    this.MoveUpType = moveuptype;
    this.Sequence = sequence;
  }

  public camStepEnable(camStepEnable Data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) Data, ref CopiedClass);
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
    return $"StartValue: {this.StartValue.ToString()} , EndValue: {this.EndValue.ToString()} , Distance: {this.Distance.ToString()} , Count: {this.Count.ToString()} , Step: {this.Step.ToString()} , Type: {this.Type.ToString()}";
  }
}
