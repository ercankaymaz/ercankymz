// Decompiled with JetBrains decompiler
// Type: buClass.MinMidMaxRange
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Reflection;

#nullable disable
namespace buClass;

public class MinMidMaxRange : buSerilization
{
  public double Min = 0.0;
  public double Max = 0.0;
  public double Mid = 0.0;
  public double Range = 0.0;

  public MinMidMaxRange()
  {
  }

  public MinMidMaxRange(double min, double mid, double max, double range)
  {
    this.Min = min;
    this.Mid = mid;
    this.Max = max;
    this.Range = range;
  }

  public MinMidMaxRange(MinMidMaxRange data)
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
    return $"Min: {this.Min.ToString("f2")} - Mid: {this.Mid.ToString("f2")} - Max: {this.Max.ToString("f2")} - Range: {this.Range.ToString("f2")}";
  }
}
