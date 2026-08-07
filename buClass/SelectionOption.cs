// Decompiled with JetBrains decompiler
// Type: buClass.SelectionOption
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class SelectionOption : buSerilization
{
  public bool Point = true;
  public bool Line = true;
  public bool Polyline = true;
  public bool Circle = true;
  public bool Arc = true;
  public bool Ellipse = true;
  public bool EllipseArc = true;
  public bool CompositeCurve = true;
  public bool Curve = true;
  public bool Text = true;
  public bool Picture = true;
  public bool Mesh = true;
  public bool Surface = true;
  public bool Brep = true;
  public bool Dimension = true;
  public bool CompositeCurveToEntity = true;
  public bool CircleToArc = false;
  public bool CircleTo4Arc = false;
  public bool SplitArcIfGreatThen180 = false;
  public bool OnlyClosedShapes = false;
  public int MinVerticeCount = 0;
  public double SplitArcIfGreatThenValue = 0.0;
  public double MinSingleEntityLength = 0.0;

  public SelectionOption()
  {
  }

  public SelectionOption(SelectedEntities data)
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

  public SelectionOption(bool AllSelected)
  {
    this.Arc = AllSelected;
    this.Brep = AllSelected;
    this.Circle = AllSelected;
    this.CompositeCurve = AllSelected;
    this.Curve = AllSelected;
    this.Dimension = AllSelected;
    this.Ellipse = AllSelected;
    this.EllipseArc = AllSelected;
    this.Line = AllSelected;
    this.Mesh = AllSelected;
    this.Picture = AllSelected;
    this.Point = AllSelected;
    this.Polyline = AllSelected;
    this.Surface = AllSelected;
    this.Text = AllSelected;
  }

  public SelectionOption(
    bool Wire,
    bool Solid,
    bool Dimension,
    bool Text,
    bool Point,
    bool Picture)
  {
    this.Arc = Wire;
    this.Brep = Solid;
    this.Circle = Wire;
    this.CompositeCurve = Wire;
    this.Curve = Wire;
    this.Dimension = Dimension;
    this.Ellipse = Wire;
    this.EllipseArc = Wire;
    this.Line = Wire;
    this.Mesh = Solid;
    this.Picture = Picture;
    this.Point = Point;
    this.Polyline = Wire;
    this.Surface = Solid;
    this.Text = Text;
  }

  public SelectionOption(
    bool Wire,
    bool Solid,
    bool Dimension,
    bool Text,
    bool Point,
    bool Picture,
    bool circletoArc,
    bool circleto4Arc,
    bool splitArcIfGreatThen180)
  {
    this.Arc = Wire;
    this.Brep = Solid;
    this.Circle = Wire;
    this.CompositeCurve = Wire;
    this.Curve = Wire;
    this.Dimension = Dimension;
    this.Ellipse = Wire;
    this.EllipseArc = Wire;
    this.Line = Wire;
    this.Mesh = Solid;
    this.Picture = Picture;
    this.Point = Point;
    this.Polyline = Wire;
    this.Surface = Solid;
    this.Text = Text;
    this.CircleToArc = circletoArc;
    this.CircleTo4Arc = circleto4Arc;
    this.SplitArcIfGreatThen180 = splitArcIfGreatThen180;
  }
}
