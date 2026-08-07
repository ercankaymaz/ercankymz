// Decompiled with JetBrains decompiler
// Type: buClass.geoTriangle
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class geoTriangle : geoEntity
{
  public Pnt3D FirstPoint = new Pnt3D();
  public Pnt3D SecondPoint = new Pnt3D();
  public Pnt3D ThirdPoint = new Pnt3D();

  public geoTriangle()
  {
  }

  public geoTriangle(geoTriangle Tri)
  {
    this.FirstPoint = new Pnt3D(Tri.FirstPoint);
    this.SecondPoint = new Pnt3D(Tri.SecondPoint);
    this.ThirdPoint = new Pnt3D(Tri.ThirdPoint);
    this.Layer = Tri.Layer;
    this.Mode = Tri.Mode;
    this.ToolNo = Tri.ToolNo;
    this.Tag = Tri.Tag;
    this.Color = Tri.Color;
    this.Index = Tri.Index;
    this.Vertice.Clear();
    this.Vertice.Add(new Pnt3D(this.FirstPoint));
    this.Vertice.Add(new Pnt3D(this.SecondPoint));
    this.Vertice.Add(new Pnt3D(this.ThirdPoint));
    this.TypeDefination = Tri.TypeDefination;
    this.isText = Tri.isText;
  }

  public geoTriangle(double X1, double Y1, double X2, double Y2, double X3, double Y3)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = X1;
    pnt3D.Y = Y1;
    pnt3D.Z = 0.0;
    this.FirstPoint = pnt3D;
    pnt3D.X = X2;
    pnt3D.Y = Y2;
    pnt3D.Z = 0.0;
    this.SecondPoint = pnt3D;
    pnt3D.X = X3;
    pnt3D.Y = Y3;
    pnt3D.Z = 0.0;
    this.ThirdPoint = pnt3D;
    this.Vertice.Clear();
    this.Vertice.Add(new Pnt3D(this.FirstPoint));
    this.Vertice.Add(new Pnt3D(this.SecondPoint));
    this.Vertice.Add(new Pnt3D(this.ThirdPoint));
  }

  public geoTriangle(
    double X1,
    double Y1,
    double Z1,
    double X2,
    double Y2,
    double Z2,
    double X3,
    double Y3,
    double Z3)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = X1;
    pnt3D.Y = Y1;
    pnt3D.Z = Z1;
    this.FirstPoint = pnt3D;
    pnt3D.X = X2;
    pnt3D.Y = Y2;
    pnt3D.Z = Z2;
    this.SecondPoint = pnt3D;
    pnt3D.X = X3;
    pnt3D.Y = Y3;
    pnt3D.Z = Z3;
    this.ThirdPoint = pnt3D;
    this.Vertice.Clear();
    this.Vertice.Add(new Pnt3D(this.FirstPoint));
    this.Vertice.Add(new Pnt3D(this.SecondPoint));
    this.Vertice.Add(new Pnt3D(this.ThirdPoint));
  }

  public geoTriangle(Pnt3D First, Pnt3D Second, Pnt3D Third)
  {
    this.FirstPoint = First;
    this.SecondPoint = Second;
    this.ThirdPoint = Third;
    this.Vertice.Clear();
    this.Vertice.Add(new Pnt3D(this.FirstPoint));
    this.Vertice.Add(new Pnt3D(this.SecondPoint));
    this.Vertice.Add(new Pnt3D(this.ThirdPoint));
  }

  public geoTriangle(Pnt3D First, Pnt3D Second, Pnt3D Third, int layer)
  {
    this.FirstPoint = First;
    this.SecondPoint = Second;
    this.ThirdPoint = Third;
    this.Layer = layer;
    this.Vertice.Clear();
    this.Vertice.Add(new Pnt3D(this.FirstPoint));
    this.Vertice.Add(new Pnt3D(this.SecondPoint));
    this.Vertice.Add(new Pnt3D(this.ThirdPoint));
  }

  public geoTriangle(PointF First, PointF Second, PointF Third)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = (double) First.X;
    pnt3D.Y = (double) First.Y;
    pnt3D.Z = 0.0;
    this.FirstPoint = pnt3D;
    pnt3D.X = (double) Second.X;
    pnt3D.Y = (double) Second.Y;
    pnt3D.Z = 0.0;
    this.SecondPoint = pnt3D;
    pnt3D.X = (double) Third.X;
    pnt3D.Y = (double) Third.Y;
    pnt3D.Z = 0.0;
    this.ThirdPoint = pnt3D;
    this.Vertice.Clear();
    this.Vertice.Add(new Pnt3D(this.FirstPoint));
    this.Vertice.Add(new Pnt3D(this.SecondPoint));
    this.Vertice.Add(new Pnt3D(this.ThirdPoint));
  }

  public override string ToString()
  {
    return $"[X:{this.FirstPoint.X.ToString("f3")} Y:{this.FirstPoint.Y.ToString("f3")} Z:{this.FirstPoint.Z.ToString("f3")}] ; [X:{this.SecondPoint.X.ToString("f3")} Y:{this.SecondPoint.Y.ToString("f3")} Z:{this.SecondPoint.Z.ToString("f3")}] ; [X:{this.ThirdPoint.X.ToString("f3")} Y:{this.ThirdPoint.Y.ToString("f3")} Z:{this.ThirdPoint.Z.ToString("f3")}]";
  }
}
