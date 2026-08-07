// Decompiled with JetBrains decompiler
// Type: buClass.Apps.BendingBridgePoint
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class BendingBridgePoint : BendingItem
{
  public double Z = 0.0;
  public double Height = 0.0;
  public double Width = 0.0;

  public BendingBridgePoint()
  {
  }

  public BendingBridgePoint(BendingBridgePoint data)
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

  public BendingBridgePoint(double x, double z)
  {
    this.X = x;
    this.Z = z;
  }

  public override string ToString()
  {
    return $"Bridge->   X: {this.X.ToString()} ; Z: {this.Z.ToString()} , Part Index: {this.PartIndex.ToString()}";
  }
}
