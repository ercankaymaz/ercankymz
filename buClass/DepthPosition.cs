// Decompiled with JetBrains decompiler
// Type: buClass.DepthPosition
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class DepthPosition : buSerilization
{
  public double Depth = 0.0;
  public double Position = 0.0;
  public List<List<Pnt3D>> BasePoints = new List<List<Pnt3D>>();
  public List<List<Pnt3D>> EventPoints = new List<List<Pnt3D>>();
  public bool StepEnable = false;
  public double StepDistance = 1.0;

  public DepthPosition()
  {
  }

  public DepthPosition(double depth, double position)
  {
    this.Depth = depth;
    this.Position = position;
  }

  public DepthPosition(double depth, double position, bool stepenable, double stepdis)
  {
    this.Depth = depth;
    this.Position = position;
    this.StepEnable = stepenable;
    this.StepDistance = stepdis;
  }

  public DepthPosition(DepthPosition data)
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
    this.BasePoints.Clear();
    Pnt3D.Copy(data.BasePoints, ref this.BasePoints);
    this.EventPoints.Clear();
    Pnt3D.Copy(data.EventPoints, ref this.EventPoints);
  }

  public override string ToString()
  {
    return $"Depth: {this.Depth.ToString()} - Position: {this.Position.ToString()}";
  }
}
