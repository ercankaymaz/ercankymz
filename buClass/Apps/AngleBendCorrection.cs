// Decompiled with JetBrains decompiler
// Type: buClass.Apps.AngleBendCorrection
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Reflection;

#nullable disable
namespace buClass.Apps;

public class AngleBendCorrection
{
  public double Angle;
  public double LimitDegree;
  public double LowPositiveRatio;
  public double LowNegativeRatio;
  public double HighPositiveRatio;
  public double HighNegativeRatio;

  public AngleBendCorrection()
  {
  }

  public AngleBendCorrection(
    double Angle_,
    double LimitDegree_,
    double LowPositiveRatio_,
    double LowNegativeRatio_,
    double HighPositiveRatio_,
    double HighNegativeRatio_)
  {
    this.Angle = Angle_;
    this.LimitDegree = LimitDegree_;
    this.LowPositiveRatio = LowPositiveRatio_;
    this.LowNegativeRatio = LowNegativeRatio_;
    this.HighPositiveRatio = HighPositiveRatio_;
    this.HighNegativeRatio = HighNegativeRatio_;
  }

  public AngleBendCorrection(AngleBendCorrection data)
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
    return $"Ang: {this.Angle.ToString("f2")} - Limit: {this.LimitDegree.ToString("f2")} - Low Rt+: {this.LowPositiveRatio.ToString("f4")} - Low Rt-: {this.LowNegativeRatio.ToString("f4")} - High Rt+: {this.HighPositiveRatio.ToString("f4")} - High Rt-: {this.HighNegativeRatio.ToString("f4")}";
  }
}
