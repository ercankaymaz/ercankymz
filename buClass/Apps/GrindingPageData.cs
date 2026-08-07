// Decompiled with JetBrains decompiler
// Type: buClass.Apps.GrindingPageData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class GrindingPageData : buSerilization
{
  public List<GrindingPin> Pins = new List<GrindingPin>();
  public List<GrindingVacuum> Vacuums = new List<GrindingVacuum>();

  public GrindingPageData()
  {
  }

  public GrindingPageData(GrindingPageData data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
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
    this.Pins = new List<GrindingPin>();
    for (int index = 0; index <= data.Pins.Count - 1; ++index)
      this.Pins.Add(new GrindingPin(data.Pins[index]));
    this.Vacuums = new List<GrindingVacuum>();
    for (int index = 0; index <= data.Vacuums.Count - 1; ++index)
      this.Vacuums.Add(new GrindingVacuum(data.Vacuums[index]));
  }
}
