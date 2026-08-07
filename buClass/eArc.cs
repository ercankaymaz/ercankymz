// Decompiled with JetBrains decompiler
// Type: buClass.eArc
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class eArc : eCircle
{
  public Pnt3D StartPoint = new Pnt3D();
  public Pnt3D MiddlePoint = new Pnt3D();
  public Pnt3D EndPoint = new Pnt3D();
  public double StartAngle = 0.0;
  public double EndAngle = 0.0;

  public eArc()
  {
  }

  public eArc(
    Pnt3D CenterPoint,
    double Radius,
    double StartAngle,
    double EndAngle,
    WorkPlane Plane)
  {
    this.CenterPoint = new Pnt3D(CenterPoint);
    this.Radius = Radius;
    this.StartAngle = StartAngle;
    this.EndAngle = EndAngle;
    this.Plane = new WorkPlane(Plane);
    this.Update();
  }

  public eArc(
    Pnt3D CenterPoint,
    double Radius,
    double StartAngle,
    double EndAngle,
    WorkPlane Plane,
    float Thickness,
    Color Color)
  {
    this.CenterPoint = new Pnt3D(CenterPoint);
    this.Radius = Radius;
    this.StartAngle = StartAngle;
    this.EndAngle = EndAngle;
    this.dispThickness = Thickness;
    this.dispColor = Color;
    this.Plane = new WorkPlane(Plane);
    this.Update();
  }

  public eArc(Pnt3D FirstPoint, Pnt3D SecondPoint, Pnt3D ThirdPoint, WorkPlane Plane)
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
    this.Plane = Plane;
    this.Update();
  }

  public eArc(eEntities ent)
  {
    if (!(ent.GetType() == typeof (eArc)))
      return;
    this.CenterPoint = new Pnt3D(((ePlaneEntities) ent).CenterPoint);
    this.Radius = ((eCircle) ent).Radius;
    this.StartAngle = ((eArc) ent).StartAngle;
    this.EndAngle = ((eArc) ent).EndAngle;
    this.StartPoint = ((eArc) ent).StartPoint;
    this.MiddlePoint = ((eArc) ent).MiddlePoint;
    this.EndPoint = ((eArc) ent).EndPoint;
    this.Plane = new WorkPlane(((ePlaneEntities) ent).Plane);
    eEntities.CopyBase(ent, (eEntities) this);
    this.Update();
  }

  public static eEntities DecodeArc(List<string> Codes)
  {
    eArc RefObject = new eArc();
    List<cParameter> Vars = new List<cParameter>();
    buSerilization.GetClassVariableValuesFromStringCodes(Codes, (object) RefObject, ref Vars);
    if (Vars.Count > 0)
    {
      object ObjPar = (object) RefObject;
      buSerilization.SetClassVariables(ref ObjPar, Vars);
    }
    RefObject.Update();
    return (eEntities) RefObject;
  }

  public override string ToString()
  {
    return $"eArc - CP : {this.CenterPoint.ToString(3)} - Rad : {this.Radius.ToString("f3")} - SA : {this.StartAngle.ToString("f3")} - EA : {this.EndAngle.ToString("f3")}";
  }
}
