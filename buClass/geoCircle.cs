// Decompiled with JetBrains decompiler
// Type: buClass.geoCircle
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class geoCircle : geoEntity
{
  public Pnt3D CenterPoint = new Pnt3D();
  public double Radius = 0.0;

  public geoCircle()
  {
  }

  public geoCircle(geoCircle circle)
  {
    this.CenterPoint = new Pnt3D(circle.CenterPoint);
    this.Radius = circle.Radius;
    this.Layer = circle.Layer;
    this.Mode = circle.Mode;
    this.ToolNo = circle.ToolNo;
    this.Tag = circle.Tag;
    this.Color = circle.Color;
    this.Index = circle.Index;
    this.Thickness = circle.Thickness;
    this.Direction = circle.Direction;
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, 0.0, 360.0, buStatics.ArcVerticeCountByResolution(this.Radius, 0.0, 360.0, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
    this.TypeDefination = circle.TypeDefination;
    this.isText = circle.isText;
  }

  public geoCircle(double X1, double Y1, double Radius)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = X1;
    pnt3D.Y = Y1;
    pnt3D.Z = 0.0;
    this.CenterPoint = pnt3D;
    this.Radius = Radius;
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, 0.0, 360.0, buStatics.ArcVerticeCountByResolution(this.Radius, 0.0, 360.0, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
  }

  public geoCircle(double X1, double Y1, double Z1, double Radius)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = X1;
    pnt3D.Y = Y1;
    pnt3D.Z = Z1;
    this.CenterPoint = pnt3D;
    this.Radius = Radius;
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, 0.0, 360.0, buStatics.ArcVerticeCountByResolution(this.Radius, 0.0, 360.0, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
  }

  public geoCircle(Pnt3D Center, double Radius)
  {
    Pnt3D pnt3D = new Pnt3D();
    this.CenterPoint = Center;
    this.Radius = Radius;
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, 0.0, 360.0, buStatics.ArcVerticeCountByResolution(this.Radius, 0.0, 360.0, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
  }

  public geoCircle(Pnt3D Center, double Radius, WorkPlane Plane)
  {
    this.CenterPoint = new Pnt3D(Center);
    this.Radius = Radius;
    this.Plane = new WorkPlane(Plane);
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, 0.0, 360.0, buStatics.ArcVerticeCountByResolution(this.Radius, 0.0, 360.0, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
  }

  public geoCircle(Pnt3D Center, double Radius, WorkPlane Plane, int layer)
  {
    this.CenterPoint = new Pnt3D(Center);
    this.Radius = Radius;
    this.Plane = new WorkPlane(Plane);
    this.Layer = layer;
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, 0.0, 360.0, buStatics.ArcVerticeCountByResolution(this.Radius, 0.0, 360.0, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
  }

  public geoCircle(Pnt3D Center, double Radius, WorkPlane Plane, Color color, double thickness)
  {
    this.CenterPoint = new Pnt3D(Center);
    this.Radius = Radius;
    this.Thickness = thickness;
    this.Color = color;
    this.Plane = new WorkPlane(Plane);
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, 0.0, 360.0, buStatics.ArcVerticeCountByResolution(this.Radius, 0.0, 360.0, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
  }

  public geoCircle(PointF Center, double Radius)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = (double) Center.X;
    pnt3D.Y = (double) Center.Y;
    pnt3D.Z = 0.0;
    this.CenterPoint = pnt3D;
    this.Radius = Radius;
    this.Vertice.Clear();
    buStatics.ArcToLineerByCount(this.CenterPoint, this.Radius, 0.0, 360.0, buStatics.ArcVerticeCountByResolution(this.Radius, 0.0, 360.0, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
  }

  public override string ToString()
  {
    return $"Circle - Center : {this.CenterPoint.ToString()} , Rad : {this.Radius.ToString()}";
  }
}
