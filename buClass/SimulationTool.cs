// Decompiled with JetBrains decompiler
// Type: buClass.SimulationTool
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class SimulationTool : buSerilization
{
  public bool Visible = false;
  public double Diameter = 10.0;
  public double Length = 50.0;
  public double Thickness = 4.0;
  public double TangentAngle = 0.0;
  public Pnt3D Coordinate = new Pnt3D();
  public Color Color = Color.Gray;
  public Color BorderColor = Color.DarkGray;
  public SimulationToolType Type = SimulationToolType.Milling;
  public LeftMiddleRightLocationType Orientation = LeftMiddleRightLocationType.Middle;

  public SimulationTool()
  {
  }

  public SimulationTool(SimulationTool data)
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
}
