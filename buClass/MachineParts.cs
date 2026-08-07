// Decompiled with JetBrains decompiler
// Type: buClass.MachineParts
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class MachineParts : buSerilization
{
  public KinematicBase Kinematic = new KinematicBase();
  public ToolBase ToolData = new ToolBase();
  public List<KinematicItem> MovingParts = new List<KinematicItem>();

  public MachineParts()
  {
  }

  public MachineParts(MachineParts data)
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
    this.ToolData = new ToolBase(data.ToolData);
    this.Kinematic = new KinematicBase(data.Kinematic);
    this.MovingParts.Clear();
    for (int index = 0; index <= data.MovingParts.Count - 1; ++index)
      this.MovingParts.Add(new KinematicItem(data.MovingParts[index]));
  }
}
