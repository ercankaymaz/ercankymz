// Decompiled with JetBrains decompiler
// Type: buClass.Grid
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class Grid : buSerilization
{
  public bool Visible = false;
  public bool AutoSize = false;
  public bool AutoPlane = false;
  public bool AlwaysBehind = true;
  public Pnt2D MinimumValue = new Pnt2D(-100.0, -100.0);
  public Pnt2D MaximumValue = new Pnt2D(-100.0, -100.0);
  public double Step = 10.0;
  public int MajorLineSteps = 5;
  public Color LineColor = Color.LightGray;
  public Color MajorLineColor = Color.LightGray;
  public Color AxisXColor = Color.Gray;
  public Color AxisYColor = Color.Gray;
  public Color BorderColor = Color.LightGray;
  public Color FillColor = Color.LightGray;
  public bool GridStepFromSnapXValue = true;
  public bool Lighting = true;

  public Grid()
  {
  }

  public Grid(Grid data)
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
    return $"Visible : {this.Visible.ToString()} ;  Step : {this.Step.ToString()}";
  }
}
