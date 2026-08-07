// Decompiled with JetBrains decompiler
// Type: buClass.DistanceData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class DistanceData : buSerilization
{
  public double Length = 0.0;
  public double dX = 0.0;
  public double dY = 0.0;
  public double dZ = 0.0;
  public double AngleXY = 0.0;
  public double AngleXZ = 0.0;
  public double AngleYZ = 0.0;

  public DistanceData()
  {
  }

  public DistanceData(DistanceData data)
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

  public override string ToString()
  {
    return $"Length :{this.Length.ToString()} - dX : {this.dX.ToString()} - dY : {this.dY.ToString()} - dZ : {this.dZ.ToString()}";
  }
}
