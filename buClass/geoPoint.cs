// Decompiled with JetBrains decompiler
// Type: buClass.geoPoint
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class geoPoint : geoEntity
{
  public Pnt3D StartPoint = new Pnt3D();

  public geoPoint()
  {
  }

  public geoPoint(geoPoint Pnt)
  {
    this.StartPoint = new Pnt3D(Pnt.StartPoint);
    this.Layer = Pnt.Layer;
    this.Mode = Pnt.Mode;
    this.ToolNo = Pnt.ToolNo;
    this.Tag = Pnt.Tag;
    this.Color = Pnt.Color;
    this.Thickness = Pnt.Thickness;
    this.Index = Pnt.Index;
    this.Vertice.Clear();
    this.Vertice.Add(new Pnt3D(this.StartPoint));
    this.TypeDefination = Pnt.TypeDefination;
    this.isText = Pnt.isText;
  }

  public geoPoint(double X1, double Y1)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = X1;
    pnt3D.Y = Y1;
    pnt3D.Z = 0.0;
    this.StartPoint = pnt3D;
    this.Vertice.Add(new Pnt3D(this.StartPoint));
  }

  public geoPoint(double X1, double Y1, double Z1)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = X1;
    pnt3D.Y = Y1;
    pnt3D.Z = Z1;
    this.StartPoint = pnt3D;
    this.Vertice.Add(new Pnt3D(this.StartPoint));
  }

  public geoPoint(Pnt3D First)
  {
    this.StartPoint = new Pnt3D(First);
    this.Vertice.Add(new Pnt3D(this.StartPoint));
  }

  public geoPoint(Pnt3D First, Color color, double thickness)
  {
    this.StartPoint = new Pnt3D(First);
    this.Color = color;
    this.Vertice.Add(new Pnt3D(this.StartPoint));
  }

  public geoPoint(Pnt3D First, int layer)
  {
    this.StartPoint = new Pnt3D(First);
    this.Layer = layer;
    this.Vertice.Add(new Pnt3D(this.StartPoint));
  }

  public geoPoint(PointF First)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = (double) First.X;
    pnt3D.Y = (double) First.Y;
    pnt3D.Z = 0.0;
    this.StartPoint = pnt3D;
    this.Vertice.Add(new Pnt3D(this.StartPoint));
  }

  public override string ToString()
  {
    return $"[X:{this.StartPoint.X.ToString("f3")} Y:{this.StartPoint.Y.ToString("f3")} Z:{this.StartPoint.Z.ToString("f3")}]";
  }
}
