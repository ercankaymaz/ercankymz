// Decompiled with JetBrains decompiler
// Type: buClass.Apps.BendingTrimcutPoint
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class BendingTrimcutPoint : BendingItem
{
  public double W = 0.0;
  public double C = 0.0;
  public int Closed = 0;
  public bool TrimcutPress = false;
  public UpDownType Direction = UpDownType.Up;
  public TrimcutSequence Sequence = TrimcutSequence.Start;

  public BendingTrimcutPoint()
  {
  }

  public BendingTrimcutPoint(BendingTrimcutPoint data)
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

  public BendingTrimcutPoint(double x, UpDownType dir, TrimcutSequence sequence)
  {
    this.X = x;
    this.Direction = dir;
    this.Sequence = sequence;
  }

  public override string ToString()
  {
    return $"Trimcut->   X: {this.X.ToString()} ; Dir: {this.Direction.ToString()} , Part Index: {this.PartIndex.ToString()}";
  }
}
