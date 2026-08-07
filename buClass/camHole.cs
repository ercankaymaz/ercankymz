// Decompiled with JetBrains decompiler
// Type: buClass.camHole
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class camHole : buSerilization
{
  public double StartHeight = 100.0;
  public double EndHeight = 80.0;
  public double DownStep = 2.0;
  public double UpStep = 1.0;
  public grindingHoleType HoleType = grindingHoleType.UpDownByStep;
  public static List<string> Captions = new List<string>();

  public camHole()
  {
  }

  public camHole(camHole distance)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) distance, ref CopiedClass);
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
    return $"StartHeight: {this.StartHeight.ToString()} , EndHeight: {this.EndHeight.ToString()} , DownStep: {this.DownStep.ToString()} , HoleType: {this.HoleType.ToString()}";
  }
}
