// Decompiled with JetBrains decompiler
// Type: buClass.eEllipseArc
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class eEllipseArc : eEllipse
{
  public double StartAngle = 0.0;
  public double EndAngle = 0.0;
  public Pnt3D StartPoint = new Pnt3D();
  public Pnt3D EndPoint = new Pnt3D();

  public eEllipseArc()
  {
  }

  public eEllipseArc(
    Pnt3D CenterPoint,
    double MajorRadius,
    double MinorRadius,
    double StartAngle,
    double EndAngle,
    double Angle,
    WorkPlane Plane)
  {
    this.CenterPoint = new Pnt3D(CenterPoint);
    this.MajorRadius = MajorRadius;
    this.MinorRadius = MinorRadius;
    this.StartAngle = StartAngle;
    this.EndAngle = EndAngle;
    this.Angle = Angle;
    this.Plane = new WorkPlane(Plane);
    this.Update();
  }

  public eEllipseArc(
    Pnt3D CenterPoint,
    double MajorRadius,
    double MinorRadius,
    double StartAngle,
    double EndAngle,
    double Angle,
    WorkPlane Plane,
    float Thickness,
    Color Color)
  {
    this.CenterPoint = new Pnt3D(CenterPoint);
    this.MajorRadius = MajorRadius;
    this.MinorRadius = MinorRadius;
    this.StartAngle = StartAngle;
    this.EndAngle = EndAngle;
    this.Angle = Angle;
    this.Plane = new WorkPlane(Plane);
    this.dispThickness = Thickness;
    this.dispColor = Color;
    this.Update();
  }

  public eEllipseArc(eEntities ent)
  {
    if (!(ent.GetType() == typeof (eEllipseArc)))
      return;
    this.CenterPoint = new Pnt3D(((ePlaneEntities) ent).CenterPoint);
    this.MajorRadius = ((eEllipse) ent).MajorRadius;
    this.MinorRadius = ((eEllipse) ent).MinorRadius;
    this.StartAngle = ((eEllipseArc) ent).StartAngle;
    this.EndAngle = ((eEllipseArc) ent).EndAngle;
    this.Angle = ((eEllipse) ent).Angle;
    this.Plane = new WorkPlane(((ePlaneEntities) ent).Plane);
    eEntities.CopyBase(ent, (eEntities) this);
    this.Update();
  }

  public static eEntities DecodeEllipseArc(List<string> Codes)
  {
    eEllipseArc RefObject = new eEllipseArc();
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
    return $"eEllipseArc - CP : {this.CenterPoint.ToString(3)} - Major Rad : {this.MajorRadius.ToString("f3")} - Minor Rad : {this.MinorRadius.ToString("f3")} - SA : {this.StartAngle.ToString("f3")} - EA : {this.EndAngle.ToString("f3")} - Angle : {this.Angle.ToString("f3")}";
  }
}
