// Decompiled with JetBrains decompiler
// Type: buClass.EntityResolution
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class EntityResolution : buSerilization
{
  public double GeometricLength = 0.5;
  public int GeometricCount = 20;
  public double LnRatio = 200.0;
  public double dt = 0.05;
  public EntityResolutionType ResolutionTypes = EntityResolutionType.ByLnRadius;
  public int MinPointCount = 50;
  public static List<string> Captions = new List<string>();

  public EntityResolution()
  {
    this.GeometricLength = 0.1;
    this.GeometricCount = 50;
    this.LnRatio = 100.0;
    this.dt = 0.05;
    this.ResolutionTypes = EntityResolutionType.ByLnRadius;
  }

  public EntityResolution(EntityResolutionType type)
  {
    this.GeometricLength = 0.1;
    this.GeometricCount = 50;
    this.LnRatio = 100.0;
    this.dt = 0.05;
    this.ResolutionTypes = type;
  }

  public EntityResolution(EntityResolution Props)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) Props, ref CopiedClass);
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

  public EntityResolution(
    double geometricLength,
    int geometricCount,
    double lnRatio,
    EntityResolutionType type,
    int minCount = 50)
  {
    this.GeometricLength = geometricLength;
    this.GeometricCount = geometricCount;
    this.LnRatio = lnRatio;
    this.ResolutionTypes = type;
    this.MinPointCount = minCount;
  }

  public override string ToString()
  {
    return $"{this.ResolutionTypes.ToString()} ; Len: {this.GeometricLength.ToString()} ; Cnt: {this.GeometricCount.ToString()} ; Ln: {this.LnRatio.ToString()} ; dt: {this.dt.ToString()}";
  }
}
