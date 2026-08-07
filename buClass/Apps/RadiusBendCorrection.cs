// Decompiled with JetBrains decompiler
// Type: buClass.Apps.RadiusBendCorrection
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Reflection;

#nullable disable
namespace buClass.Apps;

public class RadiusBendCorrection
{
  public double Radius;
  public double Degree;
  public double PositiveRatio;
  public double NegativeRatio;

  public RadiusBendCorrection()
  {
  }

  public RadiusBendCorrection(
    double Radius_,
    double Degree_,
    double PositiveRatio_,
    double NegativeRatio_)
  {
    this.Radius = Radius_;
    this.Degree = Degree_;
    this.PositiveRatio = PositiveRatio_;
    this.NegativeRatio = NegativeRatio_;
  }

  public RadiusBendCorrection(RadiusBendCorrection data)
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
    return $"Rad: {this.Radius.ToString("f2")} - Degree: {this.Degree.ToString("f2")} - Rt+: {this.PositiveRatio.ToString("f6")} - Rt-: {this.NegativeRatio.ToString("f6")}";
  }
}
