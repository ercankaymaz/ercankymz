// Decompiled with JetBrains decompiler
// Type: buClass.ToolLimits
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ToolLimits : buSerilization
{
  public Pnt6D AxesMinLimits = new Pnt6D(0.0, 0.0, 0.0, -360.0, -360.0, -360.0);
  public Pnt6D AxesMaxLimits = new Pnt6D(0.0, 0.0, 0.0, 360.0, 360.0, 360.0);
  public bool PlaneTop = false;
  public bool PlaneBottom = false;
  public bool PlaneFront = false;
  public bool PlaneBack = false;
  public bool PlaneLeft = false;
  public bool PlaneRight = false;
  public bool PlaneAll = true;
  public bool PlaneSlope = false;
  public bool RotationA = false;
  public bool RotationB = false;
  public bool RotationC = false;

  public ToolLimits()
  {
  }

  public ToolLimits(ToolLimits cam)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) cam, ref CopiedClass);
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
    return $"PlaneAll: {this.PlaneAll.ToString()} - PlaneTop: {this.PlaneTop.ToString()} - PlaneLeft: {this.PlaneLeft.ToString()} - PlaneRight: {this.PlaneRight.ToString()}";
  }
}
