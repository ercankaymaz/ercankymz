// Decompiled with JetBrains decompiler
// Type: buClass.eDimDiametric
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class eDimDiametric : eDimension
{
  public Pnt3D StartPoint = new Pnt3D();
  public Pnt3D EndPoint = new Pnt3D();
  public Pnt3D SetPoint = new Pnt3D();
  public double Diameter = 0.0;

  public eDimDiametric()
  {
  }

  public eDimDiametric(
    Pnt3D CenterPoint,
    double Diameter,
    Pnt3D StartPoint,
    Pnt3D EndPoint,
    Pnt3D SetPoint)
  {
    this.CenterPoint = new Pnt3D(CenterPoint);
    this.Diameter = Diameter;
    this.SetPoint = new Pnt3D(SetPoint);
    this.StartPoint = new Pnt3D(StartPoint);
    this.EndPoint = new Pnt3D(EndPoint);
    this.Update();
  }

  public eDimDiametric(
    Pnt3D CenterPoint,
    double Diameter,
    Pnt3D StartPoint,
    Pnt3D EndPoint,
    Pnt3D SetPoint,
    float Thickness,
    Color Clr)
  {
    this.CenterPoint = new Pnt3D(CenterPoint);
    this.Diameter = Diameter;
    this.StartPoint = new Pnt3D(StartPoint);
    this.EndPoint = new Pnt3D(EndPoint);
    this.SetPoint = new Pnt3D(SetPoint);
    this.dispThickness = Thickness;
    this.dispColor = Clr;
    this.Update();
  }

  public eDimDiametric(eEntities ent)
  {
    if (!(ent.GetType() == typeof (eDimDiametric)))
      return;
    this.StartPoint = new Pnt3D(((eDimDiametric) ent).StartPoint);
    this.EndPoint = new Pnt3D(((eDimDiametric) ent).EndPoint);
    this.CenterPoint = new Pnt3D(((ePlaneEntities) ent).CenterPoint);
    this.Diameter = ((eDimDiametric) ent).Diameter;
    this.SetPoint = new Pnt3D(((eDimDiametric) ent).SetPoint);
    this.TextHeight = ((eDimension) ent).TextHeight;
    this.DimData = new DimensionData(((eDimension) ent).DimData);
    eEntities.CopyBase(ent, (eEntities) this);
    this.Update();
  }

  public static eEntities DecodeDimDiameter(List<string> Codes)
  {
    eDimDiametric RefObject = new eDimDiametric();
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
    return $"eDimDiametric - Center Pnt : {this.CenterPoint.ToString(3)} - Dia: {this.Diameter.ToString("f3")} - Set Pnt : {this.SetPoint.ToString(3)}";
  }
}
