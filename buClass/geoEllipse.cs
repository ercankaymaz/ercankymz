// Decompiled with JetBrains decompiler
// Type: buClass.geoEllipse
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class geoEllipse : geoEntity
{
  public Pnt3D CenterPoint = new Pnt3D();
  public double MajorRadius = 0.0;
  public double MinorRadius = 0.0;
  public double Angle = 0.0;

  public geoEllipse()
  {
  }

  public geoEllipse(geoEllipse ellipse)
  {
    this.CenterPoint = new Pnt3D(ellipse.CenterPoint);
    this.MajorRadius = ellipse.MajorRadius;
    this.MinorRadius = ellipse.MinorRadius;
    this.Angle = ellipse.Angle;
    this.Layer = ellipse.Layer;
    this.Mode = ellipse.Mode;
    this.ToolNo = ellipse.ToolNo;
    this.Tag = ellipse.Tag;
    this.Color = ellipse.Color;
    this.Index = ellipse.Index;
    this.Thickness = ellipse.Thickness;
    this.Direction = ellipse.Direction;
    this.Vertice.Clear();
    buStatics.EllipseToLineerByCount(this.CenterPoint, this.MajorRadius, this.MinorRadius, this.Angle, buStatics.EllipseVerticeCountByResolution(this.MajorRadius, this.MinorRadius, buSystem.EntitiesResolution), this.Plane, ref this.Vertice);
    this.TypeDefination = ellipse.TypeDefination;
    this.isText = ellipse.isText;
  }

  public geoEllipse(double X1, double Y1, double MajorRadius, double MinorRadius, double Angle)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = X1;
    pnt3D.Y = Y1;
    pnt3D.Z = 0.0;
    this.CenterPoint = pnt3D;
    this.MajorRadius = MajorRadius;
    this.MinorRadius = MinorRadius;
    this.Angle = Angle;
    this.Vertice.Clear();
    int Count = buStatics.EllipseVerticeCountByResolution(this.MajorRadius, this.MinorRadius, buSystem.EntitiesResolution);
    buStatics.EllipseToLineerByCount(this.CenterPoint, this.MajorRadius, this.MinorRadius, Angle, Count, this.Plane, ref this.Vertice);
  }

  public geoEllipse(
    double X1,
    double Y1,
    double Z1,
    double MajorRadius,
    double MinorRadius,
    double Angle)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = X1;
    pnt3D.Y = Y1;
    pnt3D.Z = Z1;
    this.CenterPoint = pnt3D;
    this.MajorRadius = MajorRadius;
    this.MinorRadius = MinorRadius;
    this.Angle = Angle;
    this.Vertice.Clear();
    int Count = buStatics.EllipseVerticeCountByResolution(this.MajorRadius, this.MinorRadius, buSystem.EntitiesResolution);
    buStatics.EllipseToLineerByCount(this.CenterPoint, this.MajorRadius, this.MinorRadius, Angle, Count, this.Plane, ref this.Vertice);
  }

  public geoEllipse(Pnt3D Center, double MajorRadius, double MinorRadius, double Angle)
  {
    Pnt3D pnt3D = new Pnt3D();
    this.CenterPoint = Center;
    this.MajorRadius = MajorRadius;
    this.MinorRadius = MinorRadius;
    this.Angle = Angle;
    this.Vertice.Clear();
    int Count = buStatics.EllipseVerticeCountByResolution(this.MajorRadius, this.MinorRadius, buSystem.EntitiesResolution);
    buStatics.EllipseToLineerByCount(this.CenterPoint, this.MajorRadius, this.MinorRadius, Angle, Count, this.Plane, ref this.Vertice);
  }

  public geoEllipse(
    Pnt3D Center,
    double MajorRadius,
    double MinorRadius,
    double Angle,
    WorkPlane Plane)
  {
    this.CenterPoint = new Pnt3D(Center);
    this.MajorRadius = MajorRadius;
    this.MinorRadius = MinorRadius;
    this.Angle = Angle;
    this.Plane = new WorkPlane(Plane);
    this.Vertice.Clear();
    int Count = buStatics.EllipseVerticeCountByResolution(this.MajorRadius, this.MinorRadius, buSystem.EntitiesResolution);
    buStatics.EllipseToLineerByCount(this.CenterPoint, this.MajorRadius, this.MinorRadius, Angle, Count, this.Plane, ref this.Vertice);
  }

  public geoEllipse(
    Pnt3D Center,
    double MajorRadius,
    double MinorRadius,
    double Angle,
    WorkPlane Plane,
    int layer)
  {
    this.CenterPoint = new Pnt3D(Center);
    this.MajorRadius = MajorRadius;
    this.MinorRadius = MinorRadius;
    this.Angle = Angle;
    this.Plane = new WorkPlane(Plane);
    this.Layer = layer;
    this.Vertice.Clear();
    int Count = buStatics.EllipseVerticeCountByResolution(this.MajorRadius, this.MinorRadius, buSystem.EntitiesResolution);
    buStatics.EllipseToLineerByCount(this.CenterPoint, this.MajorRadius, this.MinorRadius, Angle, Count, this.Plane, ref this.Vertice);
  }

  public geoEllipse(
    Pnt3D Center,
    double MajorRadius,
    double MinorRadius,
    double Angle,
    WorkPlane Plane,
    Color color,
    double thickness)
  {
    this.CenterPoint = new Pnt3D(Center);
    this.MajorRadius = MajorRadius;
    this.MinorRadius = MinorRadius;
    this.Angle = Angle;
    this.Thickness = thickness;
    this.Color = color;
    this.Plane = new WorkPlane(Plane);
    this.Vertice.Clear();
    int Count = buStatics.EllipseVerticeCountByResolution(this.MajorRadius, this.MinorRadius, buSystem.EntitiesResolution);
    buStatics.EllipseToLineerByCount(this.CenterPoint, this.MajorRadius, this.MinorRadius, Angle, Count, this.Plane, ref this.Vertice);
  }

  public geoEllipse(PointF Center, double MajorRadius, double MinorRadius, double Angle)
  {
    Pnt3D pnt3D = new Pnt3D();
    pnt3D.X = (double) Center.X;
    pnt3D.Y = (double) Center.Y;
    pnt3D.Z = 0.0;
    this.CenterPoint = pnt3D;
    this.MajorRadius = MajorRadius;
    this.MinorRadius = MinorRadius;
    this.Angle = Angle;
    this.Vertice.Clear();
    int Count = buStatics.EllipseVerticeCountByResolution(this.MajorRadius, this.MinorRadius, buSystem.EntitiesResolution);
    buStatics.EllipseToLineerByCount(this.CenterPoint, this.MajorRadius, this.MinorRadius, Angle, Count, this.Plane, ref this.Vertice);
  }

  public override string ToString()
  {
    return $"Ellipse - Center : {this.CenterPoint.ToString()} , Maj Rad : {this.MajorRadius.ToString()} , Min Rad : {this.MinorRadius.ToString()} , Angle : {this.Angle.ToString()}";
  }
}
