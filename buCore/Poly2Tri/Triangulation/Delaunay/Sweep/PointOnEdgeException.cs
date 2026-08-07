// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Delaunay.Sweep.PointOnEdgeException
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;

#nullable disable
namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class PointOnEdgeException : NotImplementedException
{
  public TriangulationPoint A { get; set; }

  public TriangulationPoint B { get; set; }

  public TriangulationPoint C { get; set; }

  public PointOnEdgeException(
    string message,
    TriangulationPoint a,
    TriangulationPoint b,
    TriangulationPoint c)
    : base(message)
  {
    this.A = a;
    this.B = b;
    this.C = c;
  }
}
