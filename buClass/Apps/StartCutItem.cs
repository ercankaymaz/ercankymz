// Decompiled with JetBrains decompiler
// Type: buClass.Apps.StartCutItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class StartCutItem : buSerilization
{
  public double ExtractXPosition = 0.0;
  public ToolBase ToolStartCut = new ToolBase();
  public List<Pnt3D> CamPoints = new List<Pnt3D>();

  public StartCutItem()
  {
  }

  public StartCutItem(StartCutItem data)
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
    this.ToolStartCut = new ToolBase(data.ToolStartCut);
    this.CamPoints = new List<Pnt3D>();
    for (int index = 0; index <= data.CamPoints.Count - 1; ++index)
      this.CamPoints.Add(new Pnt3D(data.CamPoints[index]));
  }

  public override string ToString()
  {
    return $"Extract X : {this.ExtractXPosition.ToString("f2")} - T: {this.ToolStartCut.Data.No.ToString()}";
  }
}
