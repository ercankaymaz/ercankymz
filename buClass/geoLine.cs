// Decompiled with JetBrains decompiler
// Type: buClass.geoLine
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class geoLine : geoEntity
{
  public Pnt3D StartPoint = new Pnt3D();
  public Pnt3D EndPoint = new Pnt3D();

  public geoLine()
  {
  }

  public geoLine(geoLine Line)
  {
    this.StartPoint = new Pnt3D(Line.StartPoint);
    this.EndPoint = new Pnt3D(Line.EndPoint);
    this.Layer = Line.Layer;
    this.Mode = Line.Mode;
    this.ToolNo = Line.ToolNo;
    this.Tag = Line.Tag;
    this.Color = Line.Color;
    this.Thickness = Line.Thickness;
    this.Index = Line.Index;
    this.Direction = Line.Direction;
    this.Vertice.Clear();
    this.Vertice.Add(new Pnt3D(this.StartPoint));
    this.Vertice.Add(new Pnt3D(this.EndPoint));
    this.TypeDefination = Line.TypeDefination;
    this.isText = Line.isText;
  }

  public geoLine(double X1, double Y1, double X2, double Y2)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = X1;
    pnt3D.Y = Y1;
    pnt3D.Z = 0.0;
    this.StartPoint = pnt3D;
    pnt3D.X = X2;
    pnt3D.Y = Y2;
    pnt3D.Z = 0.0;
    this.EndPoint = pnt3D;
    this.Vertice.Add(new Pnt3D(this.StartPoint));
    this.Vertice.Add(new Pnt3D(this.EndPoint));
  }

  public geoLine(double X1, double Y1, double Z1, double X2, double Y2, double Z2)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = X1;
    pnt3D.Y = Y1;
    pnt3D.Z = Z1;
    this.StartPoint = pnt3D;
    pnt3D.X = X2;
    pnt3D.Y = Y2;
    pnt3D.Z = Z2;
    this.EndPoint = pnt3D;
    this.Vertice.Add(new Pnt3D(this.StartPoint));
    this.Vertice.Add(new Pnt3D(this.EndPoint));
  }

  public geoLine(Pnt3D First, Pnt3D Second)
  {
    this.StartPoint = new Pnt3D(First);
    this.EndPoint = new Pnt3D(Second);
    this.Vertice.Add(new Pnt3D(this.StartPoint));
    this.Vertice.Add(new Pnt3D(this.EndPoint));
  }

  public geoLine(Pnt3D First, Pnt3D Second, Color color, double thickness)
  {
    this.StartPoint = new Pnt3D(First);
    this.EndPoint = new Pnt3D(Second);
    this.Color = color;
    this.Thickness = thickness;
    this.Vertice.Add(new Pnt3D(this.StartPoint));
    this.Vertice.Add(new Pnt3D(this.EndPoint));
  }

  public geoLine(Pnt3D First, Pnt3D Second, Color color)
  {
    this.StartPoint = new Pnt3D(First);
    this.EndPoint = new Pnt3D(Second);
    this.Color = color;
    this.Vertice.Add(new Pnt3D(this.StartPoint));
    this.Vertice.Add(new Pnt3D(this.EndPoint));
  }

  public geoLine(PointF First, PointF Second)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = (double) First.X;
    pnt3D.Y = (double) First.Y;
    pnt3D.Z = 0.0;
    this.StartPoint = pnt3D;
    pnt3D.X = (double) Second.X;
    pnt3D.Y = (double) Second.Y;
    pnt3D.Z = 0.0;
    this.EndPoint = pnt3D;
    this.Vertice.Add(new Pnt3D(this.StartPoint));
    this.Vertice.Add(new Pnt3D(this.EndPoint));
  }

  public geoLine(Pnt3D First, Pnt3D Second, int layer)
  {
    this.StartPoint = new Pnt3D(First);
    this.EndPoint = new Pnt3D(Second);
    this.Layer = layer;
    this.Vertice.Add(new Pnt3D(this.StartPoint));
    this.Vertice.Add(new Pnt3D(this.EndPoint));
  }

  public override string ToString()
  {
    return $"[X:{this.StartPoint.X.ToString("f3")} Y:{this.StartPoint.Y.ToString("f3")} Z:{this.StartPoint.Z.ToString("f3")}] ; [X:{this.EndPoint.X.ToString("f3")} Y:{this.EndPoint.Y.ToString("f3")} Z:{this.EndPoint.Z.ToString("f3")}]";
  }
}
