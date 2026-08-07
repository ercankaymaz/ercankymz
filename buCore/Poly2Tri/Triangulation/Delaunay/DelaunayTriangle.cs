// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Delaunay.DelaunayTriangle
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using Poly2Tri.Triangulation.Delaunay.Sweep;
using Poly2Tri.Utility;
using System;
using System.Collections.Generic;

#nullable disable
namespace Poly2Tri.Triangulation.Delaunay;

public class DelaunayTriangle : IEquatable<DelaunayTriangle>
{
  public FixedArray3<TriangulationPoint> Points;
  public FixedArray3<DelaunayTriangle> Neighbors;
  internal FixedArray3<bool> fixedArray3_0;
  public FixedArray3<bool> EdgeIsDelaunay;

  public FixedArray3<bool> EdgeIsConstrained => this.fixedArray3_0;

  public bool IsInterior { get; set; }

  public DelaunayTriangle(TriangulationPoint p1, TriangulationPoint p2, TriangulationPoint p3)
  {
    this.Points[0] = p1;
    this.Points[1] = p2;
    this.Points[2] = p3;
  }

  public int IndexOf(TriangulationPoint p)
  {
    int num = this.Points.IndexOf(p);
    return num != -1 ? num : throw new Exception("Calling index with a point that doesn't exist in triangle");
  }

  public int IndexCWFrom(TriangulationPoint p) => (this.IndexOf(p) + 2) % 3;

  public bool Contains(TriangulationPoint p) => this.Points.Contains(p);

  public void MarkNeighbor(DelaunayTriangle t)
  {
    bool flag1 = t.Contains(this.Points[0]);
    bool flag2 = t.Contains(this.Points[1]);
    bool flag3 = t.Contains(this.Points[2]);
    if (flag2 & flag3)
    {
      this.Neighbors[0] = t;
      Class30.smethod_263(this.Points[1], this.Points[2], this, t);
    }
    else if (flag1 & flag3)
    {
      this.Neighbors[1] = t;
      Class30.smethod_263(this.Points[0], this.Points[2], this, t);
    }
    else
    {
      if (!(flag1 & flag2))
        throw new Exception("Failed to mark neighbor, doesn't share an edge!");
      this.Neighbors[2] = t;
      Class30.smethod_263(this.Points[0], this.Points[1], this, t);
    }
  }

  public void Clear()
  {
    for (int index = 0; index < 3; ++index)
    {
      DelaunayTriangle neighbor = this.Neighbors[index];
      if (neighbor != null)
        Class30.smethod_114(this, neighbor);
    }
    Class30.smethod_36(this);
    this.Points[0] = this.Points[1] = this.Points[2] = (TriangulationPoint) null;
  }

  public TriangulationPoint OppositePoint(DelaunayTriangle t, TriangulationPoint p)
  {
    return this.PointCWFrom(t.PointCWFrom(p));
  }

  public DelaunayTriangle NeighborCWFrom(TriangulationPoint point)
  {
    return this.Neighbors[(this.Points.IndexOf(point) + 1) % 3];
  }

  public DelaunayTriangle NeighborCCWFrom(TriangulationPoint point)
  {
    return this.Neighbors[(this.Points.IndexOf(point) + 2) % 3];
  }

  public DelaunayTriangle NeighborAcrossFrom(TriangulationPoint point)
  {
    return this.Neighbors[this.Points.IndexOf(point)];
  }

  public TriangulationPoint PointCCWFrom(TriangulationPoint point)
  {
    return this.Points[(this.IndexOf(point) + 1) % 3];
  }

  public TriangulationPoint PointCWFrom(TriangulationPoint point)
  {
    return this.Points[(this.IndexOf(point) + 2) % 3];
  }

  public void Legalize(TriangulationPoint oPoint, TriangulationPoint nPoint)
  {
    Class30.smethod_162(this);
    this.Points[Class30.smethod_233(oPoint, this)] = nPoint;
  }

  public override string ToString()
  {
    return $"{this.Points[0]?.ToString()},{this.Points[1]?.ToString()},{this.Points[2]?.ToString()}";
  }

  public void MarkNeighborEdges()
  {
    for (int index = 0; index < 3; ++index)
    {
      if ((!this.EdgeIsConstrained[index] ? 0 : (this.Neighbors[index] != null ? 1 : 0)) != 0)
        this.Neighbors[index].MarkConstrainedEdge(this.Points[(index + 1) % 3], this.Points[(index + 2) % 3]);
    }
  }

  public void MarkEdge(DelaunayTriangle triangle)
  {
    for (int index = 0; index < 3; ++index)
    {
      if (this.EdgeIsConstrained[index])
        triangle.MarkConstrainedEdge(this.Points[(index + 1) % 3], this.Points[(index + 2) % 3]);
    }
  }

  public void MarkEdge(IEnumerable<DelaunayTriangle> tList)
  {
    foreach (DelaunayTriangle t in tList)
    {
      for (int index = 0; index < 3; ++index)
      {
        if (t.EdgeIsConstrained[index])
          this.MarkConstrainedEdge(t.Points[(index + 1) % 3], t.Points[(index + 2) % 3]);
      }
    }
  }

  public void MarkConstrainedEdge(int index) => this.fixedArray3_0[index] = true;

  public void MarkConstrainedEdge(DTSweepConstraint edge)
  {
    this.MarkConstrainedEdge(edge.P, edge.Q);
  }

  public void MarkConstrainedEdge(TriangulationPoint p, TriangulationPoint q)
  {
    int index = this.EdgeIndex(p, q);
    if (index == -1)
      return;
    this.fixedArray3_0[index] = true;
  }

  public double Area()
  {
    return Math.Abs((this.Points[0].X - this.Points[1].X) * (this.Points[2].Y - this.Points[1].Y) * 0.5);
  }

  public TriangulationPoint Centroid()
  {
    return new TriangulationPoint((this.Points[0].X + this.Points[1].X + this.Points[2].X) / 3.0, (this.Points[0].Y + this.Points[1].Y + this.Points[2].Y) / 3.0);
  }

  public int EdgeIndex(TriangulationPoint p1, TriangulationPoint p2)
  {
    int num1 = this.Points.IndexOf(p1);
    int num2 = this.Points.IndexOf(p2);
    bool flag1 = num1 == 0 || num2 == 0;
    bool flag2 = num1 == 1 || num2 == 1;
    bool flag3 = num1 == 2 || num2 == 2;
    return !(flag2 & flag3) ? (!(flag1 & flag3) ? (!(flag1 & flag2) ? -1 : 2) : 1) : 0;
  }

  public bool GetConstrainedEdgeCCW(TriangulationPoint p)
  {
    return this.EdgeIsConstrained[(this.IndexOf(p) + 2) % 3];
  }

  public bool GetConstrainedEdgeCW(TriangulationPoint p)
  {
    return this.EdgeIsConstrained[(this.IndexOf(p) + 1) % 3];
  }

  public bool GetConstrainedEdgeAcross(TriangulationPoint p)
  {
    return this.EdgeIsConstrained[this.IndexOf(p)];
  }

  public void SetConstrainedEdgeCCW(TriangulationPoint p, bool ce)
  {
    Class30.smethod_253((this.IndexOf(p) + 2) % 3, this, ce);
  }

  public void SetConstrainedEdgeCW(TriangulationPoint p, bool ce)
  {
    Class30.smethod_253((this.IndexOf(p) + 1) % 3, this, ce);
  }

  public void SetConstrainedEdgeAcross(TriangulationPoint p, bool ce)
  {
    Class30.smethod_253(this.IndexOf(p), this, ce);
  }

  public bool GetDelaunayEdgeCCW(TriangulationPoint p)
  {
    return this.EdgeIsDelaunay[(this.IndexOf(p) + 2) % 3];
  }

  public bool GetDelaunayEdgeCW(TriangulationPoint p)
  {
    return this.EdgeIsDelaunay[(this.IndexOf(p) + 1) % 3];
  }

  public bool GetDelaunayEdgeAcross(TriangulationPoint p) => this.EdgeIsDelaunay[this.IndexOf(p)];

  public void SetDelaunayEdgeCCW(TriangulationPoint p, bool ce)
  {
    this.EdgeIsDelaunay[(this.IndexOf(p) + 2) % 3] = ce;
  }

  public void SetDelaunayEdgeCW(TriangulationPoint p, bool ce)
  {
    this.EdgeIsDelaunay[(this.IndexOf(p) + 1) % 3] = ce;
  }

  public void SetDelaunayEdgeAcross(TriangulationPoint p, bool ce)
  {
    this.EdgeIsDelaunay[this.IndexOf(p)] = ce;
  }

  public bool GetEdgeCCW(TriangulationPoint p, out DTSweepConstraint edge)
  {
    int int_0 = (this.IndexOf(p) + 2) % 3;
    return Class30.smethod_280(ref edge, this, int_0);
  }

  public bool GetEdgeCW(TriangulationPoint p, out DTSweepConstraint edge)
  {
    int int_0 = (this.IndexOf(p) + 1) % 3;
    return Class30.smethod_280(ref edge, this, int_0);
  }

  public bool GetEdgeAcross(TriangulationPoint p, out DTSweepConstraint edge)
  {
    int int_0 = this.IndexOf(p);
    return Class30.smethod_280(ref edge, this, int_0);
  }

  public bool Equals(DelaunayTriangle other) => this == other;
}
