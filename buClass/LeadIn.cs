// Decompiled with JetBrains decompiler
// Type: buClass.LeadIn
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class LeadIn : buSerilization
{
  public bool Enable = false;
  public double TangentAngle = 90.0;
  public LeadInOutType LeadType = LeadInOutType.Arc;
  public double ArcRadius = 10.0;
  public double ArcSweepAngle = 90.0;
  public double Length = 10.0;
  public double ExtendLength = 0.0;
  public ClockDirectionType ClockDir = ClockDirectionType.CW;
  public static List<string> Captions = new List<string>();

  public LeadIn()
  {
  }

  public LeadIn(bool enable, double tangentAngle, LeadInOutType type, double len)
  {
    this.Enable = enable;
    this.TangentAngle = tangentAngle;
    this.LeadType = type;
    this.Length = len;
  }

  public LeadIn(
    bool enable,
    double tangentAngle,
    LeadInOutType type,
    double len,
    double arcRad,
    double arcSweepAng)
  {
    this.Enable = enable;
    this.TangentAngle = tangentAngle;
    this.LeadType = type;
    this.Length = len;
    this.ArcRadius = arcRad;
    this.ArcSweepAngle = arcSweepAng;
  }

  public LeadIn(LeadIn data)
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
    return $"{this.Enable.ToString()} ; {this.LeadType.ToString()} ; Ang: {this.TangentAngle.ToString()} ; Len: {this.Length.ToString()}";
  }
}
