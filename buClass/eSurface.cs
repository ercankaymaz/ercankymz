// Decompiled with JetBrains decompiler
// Type: buClass.eSurface
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class eSurface : eEntities
{
  public SurfaceType SurfType = SurfaceType.ByTriangle;
  public List<List<Pnt3D>> XDirectionPoints = (List<List<Pnt3D>>) null;
  public List<List<Pnt3D>> YDirectionPoints = (List<List<Pnt3D>>) null;
  public List<Pnt3D> BorderPoints = (List<Pnt3D>) null;
  public List<Pnt3D> ContourPoints = (List<Pnt3D>) null;
  public List<Pnt3D> OutsidePoints = (List<Pnt3D>) null;
  public List<List<Pnt3D>> InsidePoints = (List<List<Pnt3D>>) null;
  public Vec3D SurfDirection = new Vec3D();
  public double SurfHeight = 10.0;
  public double SurfLength = 100.0;
  public List<TriangleIndex> TriIndex = new List<TriangleIndex>();

  public eSurface() => this.Triangles = new List<Triangle3D>();

  public eSurface(eEntities ent)
  {
    this.SurfLength = ((eSurface) ent).SurfLength;
    this.SurfHeight = ((eSurface) ent).SurfHeight;
    this.SurfDirection = new Vec3D(((eSurface) ent).SurfDirection);
    this.TriIndex.Clear();
    for (int index = 0; index <= ((eSurface) ent).TriIndex.Count - 1; ++index)
      this.TriIndex.Add(new TriangleIndex(((eSurface) ent).TriIndex[index]));
    if (!(ent.GetType() == typeof (eSurface)))
      return;
    if (ent.Triangles != null)
    {
      if (this.Triangles == null)
        this.Triangles = new List<Triangle3D>();
      this.Triangles.Clear();
      this.Triangles = new List<Triangle3D>();
      for (int index = 0; index <= ent.Triangles.Count - 1; ++index)
      {
        this.Triangles.Add(new Triangle3D(ent.Triangles[index]));
        this.Vertice.Add(new Pnt3D(this.Triangles[index].FirstPoint));
        this.Vertice.Add(new Pnt3D(this.Triangles[index].SecondPoint));
        this.Vertice.Add(new Pnt3D(this.Triangles[index].ThirdPoint));
      }
    }
    if (((eSurface) ent).ContourPoints != null)
    {
      if (this.ContourPoints == null)
        this.ContourPoints = new List<Pnt3D>();
      this.ContourPoints.Clear();
      this.ContourPoints = new List<Pnt3D>();
      for (int index = 0; index <= ((eSurface) ent).ContourPoints.Count - 1; ++index)
        this.ContourPoints.Add(new Pnt3D(((eSurface) ent).ContourPoints[index]));
    }
    if (((eSurface) ent).BorderPoints != null)
    {
      if (this.BorderPoints == null)
        this.BorderPoints = new List<Pnt3D>();
      this.BorderPoints.Clear();
      this.BorderPoints = new List<Pnt3D>();
      for (int index = 0; index <= ((eSurface) ent).BorderPoints.Count - 1; ++index)
        this.BorderPoints.Add(new Pnt3D(((eSurface) ent).BorderPoints[index]));
    }
    if (((eSurface) ent).XDirectionPoints != null)
    {
      if (this.XDirectionPoints == null)
        this.XDirectionPoints = new List<List<Pnt3D>>();
      this.XDirectionPoints.Clear();
      this.XDirectionPoints = new List<List<Pnt3D>>();
      for (int index = 0; index <= ((eSurface) ent).XDirectionPoints.Count - 1; ++index)
      {
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        Pnt3D.Copy(((eSurface) ent).XDirectionPoints[index], ref CopiedPnt);
        this.XDirectionPoints.Add(CopiedPnt);
      }
    }
    if (((eSurface) ent).YDirectionPoints != null)
    {
      if (this.YDirectionPoints == null)
        this.YDirectionPoints = new List<List<Pnt3D>>();
      this.YDirectionPoints.Clear();
      this.YDirectionPoints = new List<List<Pnt3D>>();
      for (int index = 0; index <= ((eSurface) ent).YDirectionPoints.Count - 1; ++index)
      {
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        Pnt3D.Copy(((eSurface) ent).YDirectionPoints[index], ref CopiedPnt);
        this.YDirectionPoints.Add(CopiedPnt);
      }
    }
    if (((eSurface) ent).InsidePoints != null)
    {
      if (this.InsidePoints == null)
        this.InsidePoints = new List<List<Pnt3D>>();
      this.InsidePoints.Clear();
      this.InsidePoints = new List<List<Pnt3D>>();
      for (int index = 0; index <= ((eSurface) ent).InsidePoints.Count - 1; ++index)
      {
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        Pnt3D.Copy(((eSurface) ent).InsidePoints[index], ref CopiedPnt);
        this.InsidePoints.Add(CopiedPnt);
      }
    }
    eEntities.CopyBase(ent, (eEntities) this);
    this.Update();
  }

  public eSurface(List<Triangle3D> triangles)
  {
    if (this.Triangles == null)
      this.Triangles = new List<Triangle3D>();
    this.Triangles = new List<Triangle3D>();
    this.Vertice.Clear();
    for (int index = 0; index <= triangles.Count - 1; ++index)
    {
      this.Triangles.Add(new Triangle3D(triangles[index]));
      this.Vertice.Add(new Pnt3D(triangles[index].FirstPoint));
      this.Vertice.Add(new Pnt3D(triangles[index].SecondPoint));
      this.Vertice.Add(new Pnt3D(triangles[index].ThirdPoint));
    }
    this.SurfType = SurfaceType.ByTriangle;
    this.Update();
  }

  public eSurface(List<Triangle3D> triangles, Color Color)
  {
    if (this.Triangles == null)
      this.Triangles = new List<Triangle3D>();
    this.Triangles = new List<Triangle3D>();
    for (int index = 0; index <= triangles.Count - 1; ++index)
    {
      this.Triangles.Add(new Triangle3D(triangles[index]));
      this.Vertice.Add(new Pnt3D(triangles[index].FirstPoint));
      this.Vertice.Add(new Pnt3D(triangles[index].SecondPoint));
      this.Vertice.Add(new Pnt3D(triangles[index].ThirdPoint));
    }
    this.dispColor = Color;
    this.SurfType = SurfaceType.ByTriangle;
    this.Update();
  }

  public eSurface(List<TriangleIndex> trianglesindex, List<Pnt3D> vertices, Color Color)
  {
    if (this.Triangles == null)
      this.Triangles = new List<Triangle3D>();
    this.Triangles = new List<Triangle3D>();
    for (int index = 0; index <= trianglesindex.Count - 1; ++index)
      this.TriIndex.Add(new TriangleIndex(trianglesindex[index]));
    for (int index = 0; index <= vertices.Count - 1; ++index)
      this.Vertice.Add(new Pnt3D(vertices[index]));
    this.dispColor = Color;
    this.SurfType = SurfaceType.ByTriangle;
  }

  public eSurface(
    List<Triangle3D> triangles,
    List<List<Pnt3D>> xDirectionPoints,
    List<List<Pnt3D>> yDirectionPoints,
    List<Pnt3D> borderPoints)
  {
    if (this.Triangles == null)
      this.Triangles = new List<Triangle3D>();
    this.Triangles = new List<Triangle3D>();
    for (int index = 0; index <= triangles.Count - 1; ++index)
    {
      this.Triangles.Add(new Triangle3D(triangles[index]));
      this.Vertice.Add(new Pnt3D(this.Triangles[index].FirstPoint));
      this.Vertice.Add(new Pnt3D(this.Triangles[index].SecondPoint));
      this.Vertice.Add(new Pnt3D(this.Triangles[index].ThirdPoint));
    }
    this.XDirectionPoints = new List<List<Pnt3D>>();
    for (int index = 0; index <= xDirectionPoints.Count - 1; ++index)
    {
      List<Pnt3D> CopiedPnt = new List<Pnt3D>();
      Pnt3D.Copy(xDirectionPoints[index], ref CopiedPnt);
      this.XDirectionPoints.Add(CopiedPnt);
    }
    this.YDirectionPoints = new List<List<Pnt3D>>();
    for (int index = 0; index <= yDirectionPoints.Count - 1; ++index)
    {
      List<Pnt3D> CopiedPnt = new List<Pnt3D>();
      Pnt3D.Copy(yDirectionPoints[index], ref CopiedPnt);
      this.YDirectionPoints.Add(CopiedPnt);
    }
    this.SurfType = SurfaceType.ByGrid;
    this.BorderPoints = new List<Pnt3D>();
    Pnt3D.Copy(borderPoints, ref this.BorderPoints);
    this.Update();
  }

  public eSurface(
    List<Triangle3D> triangles,
    List<List<Pnt3D>> xDirectionPoints,
    List<List<Pnt3D>> yDirectionPoints,
    List<Pnt3D> borderPoints,
    Color Color)
  {
    if (this.Triangles == null)
      this.Triangles = new List<Triangle3D>();
    this.Triangles = new List<Triangle3D>();
    for (int index = 0; index <= triangles.Count - 1; ++index)
    {
      this.Triangles.Add(new Triangle3D(triangles[index]));
      this.Vertice.Add(new Pnt3D(this.Triangles[index].FirstPoint));
      this.Vertice.Add(new Pnt3D(this.Triangles[index].SecondPoint));
      this.Vertice.Add(new Pnt3D(this.Triangles[index].ThirdPoint));
    }
    this.XDirectionPoints = new List<List<Pnt3D>>();
    for (int index = 0; index <= xDirectionPoints.Count - 1; ++index)
    {
      List<Pnt3D> CopiedPnt = new List<Pnt3D>();
      Pnt3D.Copy(xDirectionPoints[index], ref CopiedPnt);
      this.XDirectionPoints.Add(CopiedPnt);
    }
    this.YDirectionPoints = new List<List<Pnt3D>>();
    for (int index = 0; index <= yDirectionPoints.Count - 1; ++index)
    {
      List<Pnt3D> CopiedPnt = new List<Pnt3D>();
      Pnt3D.Copy(yDirectionPoints[index], ref CopiedPnt);
      this.YDirectionPoints.Add(CopiedPnt);
    }
    this.SurfType = SurfaceType.ByGrid;
    this.BorderPoints = new List<Pnt3D>();
    Pnt3D.Copy(borderPoints, ref this.BorderPoints);
    this.dispColor = Color;
    this.Update();
  }

  public eSurface(
    List<Triangle3D> triangles,
    List<Pnt3D> contourPoints,
    double surflength,
    Vec3D surfdirection)
  {
    if (this.Triangles == null)
      this.Triangles = new List<Triangle3D>();
    this.Triangles = new List<Triangle3D>();
    for (int index = 0; index <= triangles.Count - 1; ++index)
    {
      this.Triangles.Add(new Triangle3D(triangles[index]));
      this.Vertice.Add(new Pnt3D(this.Triangles[index].FirstPoint));
      this.Vertice.Add(new Pnt3D(this.Triangles[index].SecondPoint));
      this.Vertice.Add(new Pnt3D(this.Triangles[index].ThirdPoint));
    }
    if (this.ContourPoints == null)
      this.ContourPoints = new List<Pnt3D>();
    this.ContourPoints = new List<Pnt3D>();
    Pnt3D.Copy(contourPoints, ref this.ContourPoints);
    this.SurfLength = surflength;
    this.SurfDirection = new Vec3D(surfdirection);
    this.SurfType = SurfaceType.ByExtrudeWithVector;
    this.Update();
  }

  public eSurface(TriangulationPoints TP, double surfheight)
  {
    if (this.Triangles == null)
      this.Triangles = new List<Triangle3D>();
    this.Triangles.Clear();
    this.Triangles = new List<Triangle3D>();
    for (int index = 0; index <= TP.Triangles.Count - 1; ++index)
      this.Triangles.Add(new Triangle3D(TP.Triangles[index]));
    if (this.OutsidePoints == null)
      this.OutsidePoints = new List<Pnt3D>();
    if (this.InsidePoints == null)
      this.InsidePoints = new List<List<Pnt3D>>();
    this.OutsidePoints.Clear();
    this.OutsidePoints = new List<Pnt3D>();
    Pnt3D.Copy(TP.Points, ref this.OutsidePoints);
    this.InsidePoints.Clear();
    this.InsidePoints = new List<List<Pnt3D>>();
    Pnt3D.Copy(TP.Holes, ref this.InsidePoints);
    this.SurfHeight = surfheight;
    this.SurfType = SurfaceType.ByPlane;
    this.Update();
  }

  public eSurface(
    List<Pnt3D> outter,
    List<List<Pnt3D>> inner,
    List<Triangle3D> triangles,
    double surfheight)
  {
    if (this.Triangles == null)
      this.Triangles = new List<Triangle3D>();
    this.Triangles.Clear();
    this.Triangles = new List<Triangle3D>();
    for (int index = 0; index <= triangles.Count - 1; ++index)
      this.Triangles.Add(new Triangle3D(triangles[index]));
    if (this.OutsidePoints == null)
      this.OutsidePoints = new List<Pnt3D>();
    if (this.InsidePoints == null)
      this.InsidePoints = new List<List<Pnt3D>>();
    this.OutsidePoints.Clear();
    this.OutsidePoints = new List<Pnt3D>();
    Pnt3D.Copy(outter, ref this.OutsidePoints);
    this.InsidePoints.Clear();
    this.InsidePoints = new List<List<Pnt3D>>();
    Pnt3D.Copy(inner, ref this.InsidePoints);
    this.SurfHeight = surfheight;
    this.Update();
  }

  public static eSurface DecodeSurface(List<string> Codes)
  {
    eSurface RefObject = new eSurface();
    List<cParameter> Vars = new List<cParameter>();
    buSerilization.GetClassVariableValuesFromStringCodes(Codes, (object) RefObject, ref Vars);
    if (Vars.Count > 0)
    {
      object ObjPar = (object) RefObject;
      buSerilization.SetClassVariables(ref ObjPar, Vars);
    }
    RefObject.Update();
    return RefObject;
  }
}
