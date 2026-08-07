// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Delaunay.Sweep.DTSweepConstraint
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using Poly2Tri.Utility;

#nullable disable
namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class DTSweepConstraint : TriangulationConstraint
{
  public DTSweepConstraint(Point2D p1, Point2D p2)
    : base(p1, p2)
  {
    this.Q.AddEdge(this);
  }
}
