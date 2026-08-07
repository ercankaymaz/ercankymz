// Decompiled with JetBrains decompiler
// Type: buClass.eEllipse
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class eEllipse : ePlaneEntities
{
  public double MajorRadius = 0.0;
  public double MinorRadius = 0.0;
  public double Angle = 0.0;

  public eEllipse()
  {
  }

  public eEllipse(
    Pnt3D CenterPoint,
    double MajorRadius,
    double MinorRadius,
    double Angle,
    WorkPlane Plane)
  {
    this.CenterPoint = new Pnt3D(CenterPoint);
    this.MajorRadius = MajorRadius;
    this.MinorRadius = MinorRadius;
    this.Angle = Angle;
    this.Plane = new WorkPlane(Plane);
    this.Update();
  }

  public eEllipse(
    Pnt3D CenterPoint,
    double MajorRadius,
    double MinorRadius,
    double Angle,
    WorkPlane Plane,
    float Thickness,
    Color Color)
  {
    this.CenterPoint = new Pnt3D(CenterPoint);
    this.MajorRadius = MajorRadius;
    this.MinorRadius = MinorRadius;
    this.Angle = Angle;
    this.Plane = new WorkPlane(Plane);
    this.dispThickness = Thickness;
    this.dispColor = Color;
    this.Update();
  }

  public eEllipse(eEntities ent)
  {
    if (!(ent.GetType() == typeof (eEllipse)))
      return;
    this.CenterPoint = new Pnt3D(((ePlaneEntities) ent).CenterPoint);
    this.MajorRadius = ((eEllipse) ent).MajorRadius;
    this.MinorRadius = ((eEllipse) ent).MinorRadius;
    this.Angle = ((eEllipse) ent).Angle;
    this.Plane = new WorkPlane(((ePlaneEntities) ent).Plane);
    eEntities.CopyBase(ent, (eEntities) this);
    this.Update();
  }

  public static eEntities DecodeEllipse(List<string> Codes)
  {
    eEllipse RefObject = new eEllipse();
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
    return $"eEllipse - CP : {this.CenterPoint.ToString(3)} - Major Rad : {this.MajorRadius.ToString("f3")} - Minor Rad : {this.MinorRadius.ToString("f3")} - Angle : {this.Angle.ToString("f3")}";
  }
}
