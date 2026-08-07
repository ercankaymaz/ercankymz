// Decompiled with JetBrains decompiler
// Type: buClass.Apps.BendingPunchPoint
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class BendingPunchPoint : BendingItem
{
  public double Z = 0.0;

  public BendingPunchPoint()
  {
  }

  public BendingPunchPoint(BendingPunchPoint data)
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

  public BendingPunchPoint(double x, double z)
  {
    this.X = x;
    this.Z = z;
  }

  public override string ToString()
  {
    return $"Punch->   X: {this.X.ToString()} ; Z: {this.Z.ToString()} , Part Index: {this.PartIndex.ToString()}";
  }
}
