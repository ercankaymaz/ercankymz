// Decompiled with JetBrains decompiler
// Type: buClass.geoArc
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class geoArc : geoEntity
{
  public Pnt3D StartPoint = new Pnt3D();
  public Pnt3D EndPoint = new Pnt3D();
  public Pnt3D CenterPoint = new Pnt3D();
  public double Radius = 0.0;
  public double SweepAngle = 0.0;
  public double StartAngle = 0.0;
  public double EndAngle = 0.0;
  public bool Reverse = false;
  public bool isCW = false;

  public geoArc()
  {
  }

  public geoArc(geoArc arc)
  {
    this.CenterPoint = new Pnt3D(arc.CenterPoint);
    this.Radius = arc.Radius;
    this.StartAngle = arc.StartAngle;
    this.EndAngle = arc.EndAngle;
    this.Reverse = arc.Reverse;
    this.Layer = arc.Layer;
    this.Mode = arc.Mode;
    this.ToolNo = arc.ToolNo;
    this.Tag = arc.Tag;
    this.Color = arc.Color;
    this.Index = arc.Index;
    this.Thickness = arc.Thickness;
    this.Direction = arc.Direction;
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, this.StartAngle, this.EndAngle, buStatics.ArcVerticeCountByResolution(this.Radius, this.StartAngle, this.EndAngle, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
    this.TypeDefination = arc.TypeDefination;
    this.isText = arc.isText;
  }

  public geoArc(double X1, double Y1, double Rad, double StartAng, double EndAng)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = X1;
    pnt3D.Y = Y1;
    pnt3D.Z = 0.0;
    this.CenterPoint = pnt3D;
    this.Radius = Rad;
    this.StartAngle = StartAng;
    this.EndAngle = EndAng;
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, this.StartAngle, this.EndAngle, buStatics.ArcVerticeCountByResolution(this.Radius, this.StartAngle, this.EndAngle, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
  }

  public geoArc(double X1, double Y1, double Z1, double Rad, double StartAng, double EndAng)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = X1;
    pnt3D.Y = Y1;
    pnt3D.Z = Z1;
    this.CenterPoint = pnt3D;
    this.Radius = Rad;
    this.StartAngle = StartAng;
    this.EndAngle = EndAng;
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, this.StartAngle, this.EndAngle, buStatics.ArcVerticeCountByResolution(this.Radius, this.StartAngle, this.EndAngle, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
  }

  public geoArc(Pnt3D Center, double Rad, double StartAng, double EndAng)
  {
    Pnt3D pnt3D = new Pnt3D();
    this.CenterPoint = Center;
    this.Radius = Rad;
    this.StartAngle = StartAng;
    this.EndAngle = EndAng;
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, this.StartAngle, this.EndAngle, buStatics.ArcVerticeCountByResolution(this.Radius, this.StartAngle, this.EndAngle, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
  }

  public geoArc(Pnt3D Center, double Rad, double StartAng, double EndAng, WorkPlane Plane)
  {
    Pnt3D pnt3D = new Pnt3D();
    this.CenterPoint = Center;
    this.Radius = Rad;
    this.StartAngle = StartAng;
    this.EndAngle = EndAng;
    this.Plane = new WorkPlane(Plane);
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, this.StartAngle, this.EndAngle, buStatics.ArcVerticeCountByResolution(this.Radius, this.StartAngle, this.EndAngle, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
  }

  public geoArc(
    Pnt3D Center,
    double Rad,
    double StartAng,
    double EndAng,
    WorkPlane Plane,
    Color color,
    double thickness)
  {
    Pnt3D pnt3D = new Pnt3D();
    this.CenterPoint = Center;
    this.Radius = Rad;
    this.StartAngle = StartAng;
    this.EndAngle = EndAng;
    this.Color = color;
    this.Thickness = thickness;
    this.Plane = new WorkPlane(Plane);
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, this.StartAngle, this.EndAngle, buStatics.ArcVerticeCountByResolution(this.Radius, this.StartAngle, this.EndAngle, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
  }

  public geoArc(
    Pnt3D Center,
    double Rad,
    double StartAng,
    double EndAng,
    WorkPlane Plane,
    int Layer)
  {
    Pnt3D pnt3D = new Pnt3D();
    this.CenterPoint = Center;
    this.Radius = Rad;
    this.StartAngle = StartAng;
    this.EndAngle = EndAng;
    this.Layer = Layer;
    this.Plane = new WorkPlane(Plane);
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, this.StartAngle, this.EndAngle, buStatics.ArcVerticeCountByResolution(this.Radius, this.StartAngle, this.EndAngle, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
  }

  public geoArc(PointF Center, double Rad, double StartAng, double EndAng)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = (double) Center.X;
    pnt3D.Y = (double) Center.Y;
    pnt3D.Z = 0.0;
    this.CenterPoint = pnt3D;
    this.Radius = Rad;
    this.StartAngle = StartAng;
    this.EndAngle = EndAng;
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, this.StartAngle, this.EndAngle, buStatics.ArcVerticeCountByResolution(this.Radius, this.StartAngle, this.EndAngle, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
  }

  public geoArc(Pnt3D FirstPoint, Pnt3D SecondPoint, Pnt3D ThirdPoint, WorkPlane Plane)
  {
    Pnt3D Center = new Pnt3D();
    double StartAngle = 0.0;
    double EndAngle = 0.0;
    double Radius = 0.0;
    List<Pnt3D> Vertices = new List<Pnt3D>();
    buStatics.Arc3Point(FirstPoint, SecondPoint, ThirdPoint, Plane, ref Center, ref Radius, ref StartAngle, ref EndAngle, ref Vertices);
    this.CenterPoint = new Pnt3D(Center);
    this.Radius = Radius;
    this.StartAngle = StartAngle;
    this.EndAngle = EndAngle;
    this.Plane = new WorkPlane(Plane);
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, this.StartAngle, this.EndAngle, buStatics.ArcVerticeCountByResolution(this.Radius, this.StartAngle, this.EndAngle, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
  }

  public override string ToString()
  {
    return $"Arc - Center : {this.CenterPoint.ToString()} , Rad : {this.Radius.ToString()} , SA : {this.StartAngle.ToString()} , EA : {this.EndAngle.ToString()} , Reverse : {this.Reverse.ToString()}";
  }
}
