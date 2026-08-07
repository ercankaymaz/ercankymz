// Decompiled with JetBrains decompiler
// Type: buClass.LeadInOutEnable
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class LeadInOutEnable : buSerilization
{
  public bool TangentAngle = true;
  public bool LeadType = true;
  public bool ArcRadius = true;
  public bool ArcSweepAngle = true;
  public bool Length = true;
  public static List<string> Captions = new List<string>();

  public LeadInOutEnable()
  {
  }

  public LeadInOutEnable(
    bool tangentangle,
    bool leadtype,
    bool arcradius,
    bool arcsweepang,
    bool length)
  {
    this.TangentAngle = tangentangle;
    this.LeadType = leadtype;
    this.ArcRadius = arcradius;
    this.ArcSweepAngle = arcsweepang;
    this.Length = length;
  }

  public LeadInOutEnable(LeadInOutEnable Data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) Data, ref CopiedClass);
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
    return $"LeadType: {this.LeadType.ToString()} , Length: {this.Length.ToString()} , TangentAngle: {this.TangentAngle.ToString()} , ArcRadius: {this.ArcRadius.ToString()} , ArcSweepAngle: {this.ArcSweepAngle.ToString()}";
  }
}
