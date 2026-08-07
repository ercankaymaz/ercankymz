// Decompiled with JetBrains decompiler
// Type: buClass.BarrelDrawVar
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class BarrelDrawVar : buSerilization
{
  public double HeadRadius = 19.0;
  public double TaleRadius = 10.0;
  public double Length = 40.0;
  public double Heigth = 10.0;
  public double Angle = 0.0;
  public bool Reverse = false;
  public static List<string> Captions = new List<string>();

  public BarrelDrawVar()
  {
  }

  public BarrelDrawVar(BarrelDrawVar data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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

  public BarrelDrawVar(
    double headradius,
    double taleradius,
    double length,
    double height,
    bool reverse,
    WorkPlane plane)
  {
    this.HeadRadius = headradius;
    this.TaleRadius = taleradius;
    this.Length = length;
    this.Heigth = height;
    this.Reverse = reverse;
  }

  public override string ToString()
  {
    return $"Head Rad: {this.HeadRadius.ToString()} , Tale Rad: {this.TaleRadius.ToString()}";
  }
}
