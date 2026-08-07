// Decompiled with JetBrains decompiler
// Type: buClass.eBSpline
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

public class eBSpline : eCurveEntities
{
  public int Order = 0;
  public entityBSplineType BType = entityBSplineType.BSplineQuadratic;
  public List<double> Weigth = new List<double>();
  public double dt = 0.05;

  public eBSpline()
  {
  }

  public eBSpline(List<Pnt3D> Points, bool Closed_, entityBSplineType Type_)
  {
    this.ControlPoints.Clear();
    for (int index = 0; index <= Points.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(Points[index]));
    this.BType = Type_;
    this.bClosed = Closed_;
    this.dt = buSystem.EntitiesResolution.dt;
    this.Update();
  }

  public eBSpline(List<Pnt3D> Points, bool Closed_, entityBSplineType Type_, double dt_)
  {
    this.ControlPoints.Clear();
    for (int index = 0; index <= Points.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(Points[index]));
    this.BType = Type_;
    this.bClosed = Closed_;
    this.dt = dt_;
    this.Update();
  }

  public eBSpline(
    List<Pnt3D> Points,
    float Thickness,
    Color EntColor,
    bool Closed_,
    entityBSplineType Type_)
  {
    this.ControlPoints.Clear();
    for (int index = 0; index <= Points.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(Points[index]));
    this.dispThickness = Thickness;
    this.dispColor = EntColor;
    this.BType = Type_;
    this.bClosed = Closed_;
    this.dt = buSystem.EntitiesResolution.dt;
    this.Update();
  }

  public eBSpline(
    List<Pnt3D> Points,
    float Thickness,
    Color EntColor,
    bool Closed_,
    entityBSplineType Type_,
    double dt_)
  {
    this.ControlPoints.Clear();
    for (int index = 0; index <= Points.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(Points[index]));
    this.dispThickness = Thickness;
    this.dispColor = EntColor;
    this.BType = Type_;
    this.bClosed = Closed_;
    this.dt = dt_;
    this.Update();
  }

  public eBSpline(
    List<Pnt3D> Points,
    float Thickness,
    Color EntColor,
    entityBSplineType Type_,
    int Order_,
    List<double> Weigths_)
  {
    this.ControlPoints.Clear();
    for (int index = 0; index <= Points.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(Points[index]));
    this.Weigth = new List<double>();
    for (int index = 0; index <= Weigths_.Count - 1; ++index)
      this.Weigth.Add(Weigths_[index]);
    this.dispThickness = Thickness;
    this.dispColor = EntColor;
    this.BType = Type_;
    this.Order = Order_;
    this.dt = buSystem.EntitiesResolution.dt;
    this.Update();
  }

  public eBSpline(List<Pnt3D> Points, entityBSplineType Type_, int Order_, List<double> Weigths_)
  {
    this.ControlPoints.Clear();
    for (int index = 0; index <= Points.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(Points[index]));
    this.Weigth = new List<double>();
    for (int index = 0; index <= Weigths_.Count - 1; ++index)
      this.Weigth.Add(Weigths_[index]);
    this.BType = Type_;
    this.dt = buSystem.EntitiesResolution.dt;
    this.Order = Order_;
    this.Update();
  }

  public eBSpline(eEntities Ent)
  {
    if (!(Ent.GetType() == typeof (eBSpline)))
      return;
    for (int index = 0; index <= ((eCurveEntities) Ent).ControlPoints.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(((eCurveEntities) Ent).ControlPoints[index]));
    this.Weigth = new List<double>();
    for (int index = 0; index <= ((eBSpline) Ent).Weigth.Count - 1; ++index)
      this.Weigth.Add(((eBSpline) Ent).Weigth[index]);
    this.bClosed = Ent.bClosed;
    this.StartPoint = Pnt3D.Copy(((eCurveEntities) Ent).StartPoint);
    this.EndPoint = Pnt3D.Copy(((eCurveEntities) Ent).EndPoint);
    this.Order = ((eBSpline) Ent).Order;
    this.BType = ((eBSpline) Ent).BType;
    this.dt = ((eBSpline) Ent).dt;
    eEntities.CopyBase(Ent, (eEntities) this);
    this.Update();
  }

  public static eEntities DecodeBSpline(List<string> Codes)
  {
    eBSpline RefObject = new eBSpline();
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
    return $"eBSpline - Count : {this.ControlPoints.Count.ToString()} - Order : {this.Order.ToString("f3")} - BType : {this.BType.ToString("")}";
  }
}
