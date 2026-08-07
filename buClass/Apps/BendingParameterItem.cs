// Decompiled with JetBrains decompiler
// Type: buClass.Apps.BendingParameterItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class BendingParameterItem : buSerilization
{
  public double PositivePosition = 0.0;
  public double NegativePosition = 0.0;
  public double Angle = 0.0;

  public BendingParameterItem()
  {
  }

  public BendingParameterItem(double angle, double posposition, double negposition)
  {
    this.Angle = angle;
    this.PositivePosition = posposition;
    this.NegativePosition = negposition;
  }

  public BendingParameterItem(BendingParameterItem data)
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
    return $"Angle : {this.Angle.ToString()} ; PositivePosition (+) : {this.PositivePosition.ToString()} ; NegativePosition (-) : {this.NegativePosition.ToString()}";
  }
}
