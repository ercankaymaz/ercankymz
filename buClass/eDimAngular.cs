// Decompiled with JetBrains decompiler
// Type: buClass.eDimAngular
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class eDimAngular : eDimension
{
  public Pnt3D StartPoint = new Pnt3D();
  public Pnt3D EndPoint = new Pnt3D();
  public Pnt3D QuadrantPoint = new Pnt3D();
  public Pnt3D SetPoint = new Pnt3D();
  public Line3D FirstLine = new Line3D();
  public Line3D SecondLine = new Line3D();
  public bool IsArc = false;

  public eDimAngular()
  {
  }

  public eDimAngular(
    Pnt3D StartPoint,
    Pnt3D EndPoint,
    Pnt3D CenterPoint,
    Pnt3D QuadrantPoint,
    Pnt3D SetPoint,
    Line3D FirstLine,
    Line3D SecondLine,
    bool IsArc)
  {
    this.StartPoint = new Pnt3D(StartPoint);
    this.EndPoint = new Pnt3D(EndPoint);
    this.CenterPoint = new Pnt3D(CenterPoint);
    this.SetPoint = new Pnt3D(SetPoint);
    this.QuadrantPoint = new Pnt3D(QuadrantPoint);
    this.FirstLine = new Line3D(FirstLine);
    this.SecondLine = new Line3D(SecondLine);
    this.IsArc = IsArc;
    this.Update();
  }

  public eDimAngular(
    Pnt3D StartPoint,
    Pnt3D EndPoint,
    Pnt3D CenterPoint,
    Pnt3D QuadrantPoint,
    Pnt3D SetPoint,
    Line3D FirstLine,
    Line3D SecondLine,
    bool IsArc,
    float Thickness,
    Color Clr)
  {
    this.StartPoint = new Pnt3D(StartPoint);
    this.EndPoint = new Pnt3D(EndPoint);
    this.SetPoint = new Pnt3D(SetPoint);
    this.CenterPoint = new Pnt3D(CenterPoint);
    this.QuadrantPoint = new Pnt3D(QuadrantPoint);
    this.FirstLine = new Line3D(FirstLine);
    this.SecondLine = new Line3D(SecondLine);
    this.dispThickness = Thickness;
    this.dispColor = Clr;
    this.IsArc = IsArc;
    this.Update();
  }

  public eDimAngular(eEntities ent)
  {
    if (!(ent.GetType() == typeof (eDimAngular)))
      return;
    this.StartPoint = new Pnt3D(((eDimAngular) ent).StartPoint);
    this.EndPoint = new Pnt3D(((eDimAngular) ent).EndPoint);
    this.SetPoint = new Pnt3D(((eDimAngular) ent).SetPoint);
    this.CenterPoint = new Pnt3D(((ePlaneEntities) ent).CenterPoint);
    this.QuadrantPoint = new Pnt3D(((eDimAngular) ent).QuadrantPoint);
    this.FirstLine = new Line3D(((eDimAngular) ent).FirstLine);
    this.SecondLine = new Line3D(((eDimAngular) ent).SecondLine);
    this.TextHeight = ((eDimension) ent).TextHeight;
    this.DimData = new DimensionData(((eDimension) ent).DimData);
    this.IsArc = ((eDimAngular) ent).IsArc;
    eEntities.CopyBase(ent, (eEntities) this);
    this.Update();
  }

  public static eEntities DecodeDimLinear(List<string> Codes)
  {
    eDimAngular RefObject = new eDimAngular();
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
    return $"eDimAngular - SP : {this.StartPoint.ToString(3)} - EP : {this.EndPoint.ToString(3)} - Set Pnt : {this.SetPoint.ToString(3)} - QuadrantPoint : {this.QuadrantPoint.ToString()} - IsArc : {this.IsArc.ToString()}";
  }
}
