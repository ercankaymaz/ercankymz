// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.RegenResolutionData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class RegenResolutionData : buSerilization5
{
  public List<buEntity> AllEntities;
  public bool G0EntitiesEnable;

  public RegenResolutionData()
  {
    ((ToolBase5) this).MinRadius = 0.0;
    ((ToolBase5) this).MaxRadius = 0.0;
    ((ToolBase5) this).Feed = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public RegenResolutionData(double minrad, double maxrad, double feed)
  {
    ((ToolBase5) this).MinRadius = 0.0;
    ((ToolBase5) this).MaxRadius = 0.0;
    ((ToolBase5) this).Feed = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((ToolBase5) this).MinRadius = minrad;
    ((ToolBase5) this).MaxRadius = maxrad;
    ((ToolBase5) this).Feed = feed;
  }

  public RegenResolutionData(camRadiusFeed data)
  {
    ((ToolBase5) this).MinRadius = 0.0;
    ((ToolBase5) this).MaxRadius = 0.0;
    ((ToolBase5) this).Feed = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }
}
