// Decompiled with JetBrains decompiler
// Type: buClass.Apps.BendingParameter
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class BendingParameter : buSerilization
{
  public string Name = "";
  public double PtValue = 2.0;
  public double OverrideUp = 100.0;
  public double OverrideDown = 100.0;
  public double Override18mmUp = 100.0;
  public double Override18mmDown = 100.0;
  public double Override15mmUp = 100.0;
  public double Override15mmDown = 100.0;
  public double Override12mmUp = 100.0;
  public double Override12mmDown = 100.0;
  public double BridgeOffset = 0.0;
  public double BendingXDistance = 0.0;
  public double DiskCircumfarance = 0.0;
  public double BroachBendingOVerride = 100.0;
  public List<BendingParameterItem> CornerItems = new List<BendingParameterItem>();
  public List<RadiusParameterItem> RadiusItems = new List<RadiusParameterItem>();

  public BendingParameter()
  {
  }

  public BendingParameter(BendingParameter data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
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
    this.CornerItems.Clear();
    this.RadiusItems.Clear();
    for (int index = 0; index <= data.CornerItems.Count - 1; ++index)
      this.CornerItems.Add(new BendingParameterItem(data.CornerItems[index]));
    for (int index = 0; index <= data.RadiusItems.Count - 1; ++index)
      this.RadiusItems.Add(new RadiusParameterItem(data.RadiusItems[index]));
  }

  public override string ToString()
  {
    return $"{this.Name.ToString()} ; Pt : {this.PtValue.ToString()} ; OverrideUp : {this.OverrideUp.ToString()} ; OverrideDown : {this.OverrideDown.ToString()}";
  }
}
