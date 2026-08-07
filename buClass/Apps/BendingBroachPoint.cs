// Decompiled with JetBrains decompiler
// Type: buClass.Apps.BendingBroachPoint
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class BendingBroachPoint : BendingItem
{
  public double A = 0.0;
  public UpDownLeftRightDirectionType Direction = UpDownLeftRightDirectionType.Up;

  public BendingBroachPoint()
  {
  }

  public BendingBroachPoint(BendingBroachPoint data)
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

  public BendingBroachPoint(double x) => this.X = x;

  public BendingBroachPoint(double x, UpDownLeftRightDirectionType dir, double a)
  {
    this.X = x;
    this.Direction = dir;
    this.A = a;
  }

  public override string ToString()
  {
    return $"Broach->   X: {this.X.ToString()}  A: {this.A.ToString()} ; Dir: {this.Direction.ToString()} , Part Index: {this.PartIndex.ToString()}";
  }
}
