// Decompiled with JetBrains decompiler
// Type: buClass.geoQuad
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class geoQuad : geoEntity
{
  public Pnt3D FirstPoint = new Pnt3D();
  public Pnt3D SecondPoint = new Pnt3D();
  public Pnt3D ThirdPoint = new Pnt3D();
  public Pnt3D FourthPoint = new Pnt3D();

  public geoQuad()
  {
  }

  public geoQuad(geoQuad quad)
  {
    this.FirstPoint = new Pnt3D(quad.FirstPoint);
    this.SecondPoint = new Pnt3D(quad.SecondPoint);
    this.ThirdPoint = new Pnt3D(quad.ThirdPoint);
    this.FourthPoint = new Pnt3D(quad.FourthPoint);
    this.Layer = quad.Layer;
    this.Mode = quad.Mode;
    this.ToolNo = quad.ToolNo;
    this.Tag = quad.Tag;
    this.Color = quad.Color;
    this.Index = quad.Index;
    this.Vertice.Clear();
    this.Vertice.Add(new Pnt3D(this.FirstPoint));
    this.Vertice.Add(new Pnt3D(this.SecondPoint));
    this.Vertice.Add(new Pnt3D(this.ThirdPoint));
    this.Vertice.Add(new Pnt3D(this.FourthPoint));
    this.TypeDefination = quad.TypeDefination;
    this.isText = quad.isText;
  }

  public geoQuad(
    double X1,
    double Y1,
    double X2,
    double Y2,
    double X3,
    double Y3,
    double X4,
    double Y4)
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
    pnt3D.X = X4;
    pnt3D.Y = Y4;
    pnt3D.Z = 0.0;
    this.FourthPoint = pnt3D;
    this.Vertice.Clear();
    this.Vertice.Add(new Pnt3D(this.FirstPoint));
    this.Vertice.Add(new Pnt3D(this.SecondPoint));
    this.Vertice.Add(new Pnt3D(this.ThirdPoint));
    this.Vertice.Add(new Pnt3D(this.FourthPoint));
  }

  public geoQuad(
    double X1,
    double Y1,
    double Z1,
    double X2,
    double Y2,
    double Z2,
    double X3,
    double Y3,
    double Z3,
    double X4,
    double Y4,
    double Z4)
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
    pnt3D.X = X4;
    pnt3D.Y = Y4;
    pnt3D.Z = Z4;
    this.FourthPoint = pnt3D;
    this.Vertice.Clear();
    this.Vertice.Add(new Pnt3D(this.FirstPoint));
    this.Vertice.Add(new Pnt3D(this.SecondPoint));
    this.Vertice.Add(new Pnt3D(this.ThirdPoint));
    this.Vertice.Add(new Pnt3D(this.FourthPoint));
  }

  public geoQuad(Pnt3D First, Pnt3D Second, Pnt3D Third, Pnt3D Fourth)
  {
    this.FirstPoint = First;
    this.SecondPoint = Second;
    this.ThirdPoint = Third;
    this.FourthPoint = Fourth;
    this.Vertice.Clear();
    this.Vertice.Add(new Pnt3D(this.FirstPoint));
    this.Vertice.Add(new Pnt3D(this.SecondPoint));
    this.Vertice.Add(new Pnt3D(this.ThirdPoint));
    this.Vertice.Add(new Pnt3D(this.FourthPoint));
  }

  public geoQuad(Pnt3D First, Pnt3D Second, Pnt3D Third, Pnt3D Fourth, int layer)
  {
    this.FirstPoint = First;
    this.SecondPoint = Second;
    this.ThirdPoint = Third;
    this.FourthPoint = Fourth;
    this.Layer = layer;
    this.Vertice.Clear();
    this.Vertice.Add(new Pnt3D(this.FirstPoint));
    this.Vertice.Add(new Pnt3D(this.SecondPoint));
    this.Vertice.Add(new Pnt3D(this.ThirdPoint));
    this.Vertice.Add(new Pnt3D(this.FourthPoint));
  }

  public geoQuad(PointF First, PointF Second, PointF Third, PointF Fourth)
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
    pnt3D.X = (double) Fourth.X;
    pnt3D.Y = (double) Fourth.Y;
    pnt3D.Z = 0.0;
    this.FourthPoint = pnt3D;
    this.Vertice.Clear();
    this.Vertice.Add(new Pnt3D(this.FirstPoint));
    this.Vertice.Add(new Pnt3D(this.SecondPoint));
    this.Vertice.Add(new Pnt3D(this.ThirdPoint));
    this.Vertice.Add(new Pnt3D(this.FourthPoint));
  }

  public override string ToString()
  {
    return $"({this.FirstPoint.X.ToString("f3")} , {this.FirstPoint.Y.ToString("f3")} , {this.FirstPoint.Z.ToString("f3")}) - ({this.SecondPoint.X.ToString("f3")} , {this.SecondPoint.Y.ToString("f3")} , {this.SecondPoint.Z.ToString("f3")}) - ({this.ThirdPoint.X.ToString("f3")} , {this.ThirdPoint.Y.ToString("f3")} , {this.ThirdPoint.Z.ToString("f3")}) - ({this.FourthPoint.X.ToString("f3")} , {this.FourthPoint.Y.ToString("f3")} , {this.FourthPoint.Z.ToString("f3")})";
  }
}
