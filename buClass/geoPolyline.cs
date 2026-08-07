// Decompiled with JetBrains decompiler
// Type: buClass.geoPolyline
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class geoPolyline : geoEntity
{
  public geoPolyline()
  {
  }

  public geoPolyline(geoPolyline pline)
  {
    this.Vertice.Clear();
    for (int index = 0; index <= pline.Vertice.Count - 1; ++index)
      this.Vertice.Add(new Pnt3D(pline.Vertice[index]));
    this.Layer = pline.Layer;
    this.Mode = pline.Mode;
    this.ToolNo = pline.ToolNo;
    this.Tag = pline.Tag;
    this.Color = pline.Color;
    this.Index = pline.Index;
    this.Thickness = pline.Thickness;
    this.Direction = pline.Direction;
    this.TypeDefination = pline.TypeDefination;
    this.isText = pline.isText;
  }

  public geoPolyline(List<Pnt3D> vertice)
  {
    this.Vertice.Clear();
    for (int index = 0; index <= vertice.Count - 1; ++index)
      this.Vertice.Add(new Pnt3D(vertice[index]));
  }

  public geoPolyline(List<Pnt3D> vertice, Color color)
  {
    this.Vertice.Clear();
    this.Color = color;
    for (int index = 0; index <= vertice.Count - 1; ++index)
      this.Vertice.Add(new Pnt3D(vertice[index]));
  }

  public geoPolyline(List<Pnt3D> vertice, Color color, double thickness)
  {
    this.Vertice.Clear();
    this.Color = color;
    this.Thickness = thickness;
    for (int index = 0; index <= vertice.Count - 1; ++index)
      this.Vertice.Add(new Pnt3D(vertice[index]));
  }

  public geoPolyline(List<Pnt3D> vertice, int Layer)
  {
    this.Vertice.Clear();
    for (int index = 0; index <= vertice.Count - 1; ++index)
      this.Vertice.Add(new Pnt3D(vertice[index]));
    this.Layer = Layer;
  }

  public override string ToString()
  {
    if (this.Vertice.Count == 0)
      return "PLine - Count: " + this.Vertice.Count.ToString();
    return $"PLine - Count: {this.Vertice.Count.ToString()} Start: {this.Vertice[0].ToString()} End: {this.Vertice[this.Vertice.Count - 1].ToString()}";
  }
}
