// Decompiled with JetBrains decompiler
// Type: buClass.eDimRadial
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class eDimRadial : eDimension
{
  public Pnt3D StartPoint = new Pnt3D();
  public Pnt3D EndPoint = new Pnt3D();
  public Pnt3D SetPoint = new Pnt3D();
  public double Radius = 0.0;

  public eDimRadial()
  {
  }

  public eDimRadial(
    Pnt3D CenterPoint,
    double Radius,
    Pnt3D StartPoint,
    Pnt3D EndPoint,
    Pnt3D SetPoint)
  {
    this.CenterPoint = new Pnt3D(CenterPoint);
    this.StartPoint = new Pnt3D(StartPoint);
    this.EndPoint = new Pnt3D(EndPoint);
    this.Radius = Radius;
    this.SetPoint = new Pnt3D(SetPoint);
    this.Update();
  }

  public eDimRadial(
    Pnt3D CenterPoint,
    double Radius,
    Pnt3D StartPoint,
    Pnt3D EndPoint,
    Pnt3D SetPoint,
    float Thickness,
    Color Clr)
  {
    this.StartPoint = new Pnt3D(StartPoint);
    this.EndPoint = new Pnt3D(EndPoint);
    this.CenterPoint = new Pnt3D(CenterPoint);
    this.Radius = Radius;
    this.SetPoint = new Pnt3D(SetPoint);
    this.dispThickness = Thickness;
    this.dispColor = Clr;
    this.Update();
  }

  public eDimRadial(eEntities ent)
  {
    if (!(ent.GetType() == typeof (eDimRadial)))
      return;
    this.StartPoint = new Pnt3D(((eDimRadial) ent).StartPoint);
    this.EndPoint = new Pnt3D(((eDimRadial) ent).EndPoint);
    this.CenterPoint = new Pnt3D(((ePlaneEntities) ent).CenterPoint);
    this.Radius = ((eDimRadial) ent).Radius;
    this.SetPoint = new Pnt3D(((eDimRadial) ent).SetPoint);
    this.TextHeight = ((eDimension) ent).TextHeight;
    this.DimData = new DimensionData(((eDimension) ent).DimData);
    eEntities.CopyBase(ent, (eEntities) this);
    this.Update();
  }

  public static eEntities DecodeDimRadial(List<string> Codes)
  {
    eDimRadial RefObject = new eDimRadial();
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
    return $"eDimRadius - Center Pnt : {this.CenterPoint.ToString(3)} - Rad: {this.Radius.ToString("f3")} - Set Pnt : {this.SetPoint.ToString(3)}";
  }
}
