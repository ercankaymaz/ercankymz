// Decompiled with JetBrains decompiler
// Type: buClass.geoBSpline
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class geoBSpline : geoEntity
{
  public List<Pnt3D> ControlPoints = new List<Pnt3D>();
  public entityBSplineType BType = entityBSplineType.BSplineQuadratic;
  public double dt = 0.05;
  public bool Closed = false;

  public geoBSpline()
  {
  }

  public geoBSpline(geoBSpline bspline)
  {
    this.Vertice.Clear();
    for (int index = 0; index <= bspline.Vertice.Count - 1; ++index)
      this.Vertice.Add(new Pnt3D(bspline.Vertice[index]));
    this.ControlPoints.Clear();
    for (int index = 0; index <= bspline.ControlPoints.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(bspline.ControlPoints[index]));
    this.Closed = bspline.Closed;
    this.dt = bspline.dt;
    this.BType = bspline.BType;
    this.Layer = bspline.Layer;
    this.Mode = bspline.Mode;
    this.ToolNo = bspline.ToolNo;
    this.Tag = bspline.Tag;
    this.Color = bspline.Color;
    this.Index = bspline.Index;
    this.Thickness = bspline.Thickness;
    this.Direction = bspline.Direction;
    this.TypeDefination = bspline.TypeDefination;
    this.isText = bspline.isText;
  }

  public geoBSpline(List<Pnt3D> controls)
  {
    this.ControlPoints.Clear();
    for (int index = 0; index <= controls.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(controls[index]));
    double dt = buSystem.EntitiesResolution.dt;
    if (this.dt > 0.0)
      dt = this.dt;
    this.Vertice.Clear();
    if (this.BType == entityBSplineType.BSplineCubic)
      buStatics.CreatBSplineCubicUniform(this.ControlPoints, dt, this.Closed, ref this.Vertice);
    if (this.BType == entityBSplineType.BSplineQuadratic)
      buStatics.CreatBSplineQuadraticUniform(this.ControlPoints, dt, this.Closed, ref this.Vertice);
    if (this.BType != entityBSplineType.SplineCubic)
      return;
    buStatics.CreatSplineCubicUniform(this.ControlPoints, dt, ref this.Vertice);
  }

  public geoBSpline(List<Pnt3D> controls, bool closed, entityBSplineType Type)
  {
    this.Closed = closed;
    this.BType = Type;
    this.ControlPoints.Clear();
    for (int index = 0; index <= controls.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(controls[index]));
    double dt = buSystem.EntitiesResolution.dt;
    if (this.dt > 0.0)
      dt = this.dt;
    this.Vertice.Clear();
    if (this.BType == entityBSplineType.BSplineCubic)
      buStatics.CreatBSplineCubicUniform(this.ControlPoints, dt, this.Closed, ref this.Vertice);
    if (this.BType == entityBSplineType.BSplineQuadratic)
      buStatics.CreatBSplineQuadraticUniform(this.ControlPoints, dt, this.Closed, ref this.Vertice);
    if (this.BType != entityBSplineType.SplineCubic)
      return;
    buStatics.CreatSplineCubicUniform(this.ControlPoints, dt, ref this.Vertice);
  }

  public geoBSpline(
    List<Pnt3D> controls,
    bool closed,
    entityBSplineType Type,
    Color color,
    double thickness)
  {
    this.Color = color;
    this.Thickness = thickness;
    this.Closed = closed;
    this.BType = Type;
    this.ControlPoints.Clear();
    for (int index = 0; index <= controls.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(controls[index]));
    double dt = buSystem.EntitiesResolution.dt;
    if (this.dt > 0.0)
      dt = this.dt;
    this.Vertice.Clear();
    if (this.BType == entityBSplineType.BSplineCubic)
      buStatics.CreatBSplineCubicUniform(this.ControlPoints, dt, this.Closed, ref this.Vertice);
    if (this.BType == entityBSplineType.BSplineQuadratic)
      buStatics.CreatBSplineQuadraticUniform(this.ControlPoints, dt, this.Closed, ref this.Vertice);
    if (this.BType != entityBSplineType.SplineCubic)
      return;
    buStatics.CreatSplineCubicUniform(this.ControlPoints, dt, ref this.Vertice);
  }

  public geoBSpline(List<Pnt3D> controls, Color color)
  {
    this.Color = color;
    this.ControlPoints.Clear();
    for (int index = 0; index <= controls.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(controls[index]));
    double dt = buSystem.EntitiesResolution.dt;
    if (this.dt > 0.0)
      dt = this.dt;
    this.Vertice.Clear();
    if (this.BType == entityBSplineType.BSplineCubic)
      buStatics.CreatBSplineCubicUniform(this.ControlPoints, dt, this.Closed, ref this.Vertice);
    if (this.BType == entityBSplineType.BSplineQuadratic)
      buStatics.CreatBSplineQuadraticUniform(this.ControlPoints, dt, this.Closed, ref this.Vertice);
    if (this.BType != entityBSplineType.SplineCubic)
      return;
    buStatics.CreatSplineCubicUniform(this.ControlPoints, dt, ref this.Vertice);
  }

  public geoBSpline(List<Pnt3D> controls, Color color, double thickness)
  {
    this.Color = color;
    this.Thickness = thickness;
    this.ControlPoints.Clear();
    for (int index = 0; index <= controls.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(controls[index]));
    double dt = buSystem.EntitiesResolution.dt;
    if (this.dt > 0.0)
      dt = this.dt;
    this.Vertice.Clear();
    if (this.BType == entityBSplineType.BSplineCubic)
      buStatics.CreatBSplineCubicUniform(this.ControlPoints, dt, this.Closed, ref this.Vertice);
    if (this.BType == entityBSplineType.BSplineQuadratic)
      buStatics.CreatBSplineQuadraticUniform(this.ControlPoints, dt, this.Closed, ref this.Vertice);
    if (this.BType != entityBSplineType.SplineCubic)
      return;
    buStatics.CreatSplineCubicUniform(this.ControlPoints, dt, ref this.Vertice);
  }

  public geoBSpline(List<Pnt3D> controls, int Layer)
  {
    this.ControlPoints.Clear();
    for (int index = 0; index <= controls.Count - 1; ++index)
      this.ControlPoints.Add(new Pnt3D(controls[index]));
    double dt = buSystem.EntitiesResolution.dt;
    if (this.dt > 0.0)
      dt = this.dt;
    this.Vertice.Clear();
    if (this.BType == entityBSplineType.BSplineCubic)
      buStatics.CreatBSplineCubicUniform(this.ControlPoints, dt, this.Closed, ref this.Vertice);
    if (this.BType == entityBSplineType.BSplineQuadratic)
      buStatics.CreatBSplineQuadraticUniform(this.ControlPoints, dt, this.Closed, ref this.Vertice);
    if (this.BType == entityBSplineType.SplineCubic)
      buStatics.CreatSplineCubicUniform(this.ControlPoints, dt, ref this.Vertice);
    this.Layer = Layer;
  }

  public override string ToString()
  {
    if (this.Vertice.Count == 0)
      return "PLine - Count: " + this.Vertice.Count.ToString();
    return $"PLine - Count: {this.Vertice.Count.ToString()} Start: {this.Vertice[0].ToString()} End: {this.Vertice[this.Vertice.Count - 1].ToString()}";
  }
}
