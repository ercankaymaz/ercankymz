// Decompiled with JetBrains decompiler
// Type: buClass.PointsToEntitiesPar
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class PointsToEntitiesPar : buSerilization
{
  public double AngleLimit = 170.0;
  public double LengthFilter = 0.0;
  public double LengthDifferanceLimit = 1.5;
  public double RadiusDifferanceWithPreRadius = 3.0;
  public bool CircleToArc = true;

  public PointsToEntitiesPar()
  {
  }

  public PointsToEntitiesPar(double angleLimit, double lengthFilter, double lengthDiffLimit)
  {
    this.AngleLimit = angleLimit;
    this.LengthDifferanceLimit = lengthDiffLimit;
    this.LengthFilter = lengthFilter;
  }

  public PointsToEntitiesPar(PointsToEntitiesPar data)
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
}
