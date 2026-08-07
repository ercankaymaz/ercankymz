// Decompiled with JetBrains decompiler
// Type: buClass.eCircle
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class eCircle : ePlaneEntities
{
  public double Radius = 0.0;

  public eCircle()
  {
  }

  public eCircle(Pnt3D CenterPoint, double Radius, WorkPlane Plane)
  {
    this.CenterPoint = new Pnt3D(CenterPoint);
    this.Radius = Radius;
    this.Plane = new WorkPlane(Plane);
    this.Update();
  }

  public eCircle(Pnt3D CenterPoint, double Radius, WorkPlane Plane, float Thickness, Color Color)
  {
    this.CenterPoint = new Pnt3D(CenterPoint);
    this.Radius = Radius;
    this.dispThickness = Thickness;
    this.dispColor = Color;
    this.Plane = new WorkPlane(Plane);
    this.Update();
  }

  public eCircle(eEntities ent)
  {
    if (!(ent.GetType() == typeof (eCircle)))
      return;
    this.CenterPoint = new Pnt3D(((ePlaneEntities) ent).CenterPoint);
    this.Radius = ((eCircle) ent).Radius;
    this.Plane = new WorkPlane(((ePlaneEntities) ent).Plane);
    this.Update();
    eEntities.CopyBase(ent, (eEntities) this);
  }

  public static eEntities DecodeCircle(List<string> Codes)
  {
    eCircle RefObject = new eCircle();
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
    return $"eCircle - CP : {this.CenterPoint.ToString(3)} - Rad : {this.Radius.ToString("f3")}";
  }
}
