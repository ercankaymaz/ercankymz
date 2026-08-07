// Decompiled with JetBrains decompiler
// Type: buClass.Apps.CreasingCornerItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class CreasingCornerItem : buSerilization
{
  public bool LeftEnable;
  public double LeftWidth;
  public double LeftHeight;
  public Pnt3D LeftExtractPosition = new Pnt3D();
  public ToolBase LeftTool = new ToolBase();
  public List<Pnt3D> LeftCamPoints = new List<Pnt3D>();
  public bool RightEnable;
  public double RightWidth;
  public double RightHeight;
  public Pnt3D RightExtractPosition = new Pnt3D();
  public ToolBase RightTool = new ToolBase();
  public List<Pnt3D> RightCamPoints = new List<Pnt3D>();

  public CreasingCornerItem()
  {
  }

  public CreasingCornerItem(
    bool LeftEnable_,
    double LeftWidth_,
    double LeftHeight_,
    Pnt3D LeftExtractPosition_,
    bool RightEnable_,
    double RightWidth_,
    double RightHeight_,
    Pnt3D RightExtractPosition_)
  {
    this.LeftEnable = LeftEnable_;
    this.LeftWidth = LeftWidth_;
    this.LeftHeight = LeftHeight_;
    this.LeftExtractPosition = LeftExtractPosition_;
    this.RightEnable = RightEnable_;
    this.RightWidth = RightWidth_;
    this.RightHeight = RightHeight_;
    this.RightExtractPosition = RightExtractPosition_;
  }

  public CreasingCornerItem(CreasingCornerItem data)
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
    return $"LeftEnable : {this.LeftEnable.ToString()} ; RightEnable : {this.RightEnable.ToString()}";
  }
}
