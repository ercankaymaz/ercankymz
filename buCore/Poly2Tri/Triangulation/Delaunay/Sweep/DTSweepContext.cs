// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Delaunay.Sweep.DTSweepContext
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using Poly2Tri.Utility;
using System.Collections.Generic;

#nullable disable
namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class DTSweepContext : TriangulationContext
{
  public AdvancingFront Front;
  public readonly DTSweepBasin Basin = new DTSweepBasin();
  public readonly DTSweepEdgeEvent EdgeEvent = new DTSweepEdgeEvent();
  private readonly DTSweepPointComparator dtsweepPointComparator_0 = new DTSweepPointComparator();

  public override TriangulationAlgorithm Algorithm => TriangulationAlgorithm.DTSweep;

  public DTSweepContext()
    : base((TriangulationDebugContext) new DTSweepDebugContext())
  {
  }

  public DTSweepDebugContext DebugContext => (DTSweepDebugContext) base.DebugContext;

  public void RemoveFromList(DelaunayTriangle triangle) => this.Triangles.Remove(triangle);

  public void MeshClean(DelaunayTriangle triangle) => Class30.smethod_215(triangle, this);

  public AdvancingFrontNode LocateNode(TriangulationPoint point) => this.Front.LocateNode(point);

  public void CreateAdvancingFront()
  {
    // ISSUE: reference to a compiler-generated method
    // ISSUE: reference to a compiler-generated method
    DelaunayTriangle delaunayTriangle = new DelaunayTriangle(this.Points[0], this.method_2(), this.method_0());
    this.Triangles.Add(delaunayTriangle);
    AdvancingFrontNode head = new AdvancingFrontNode(delaunayTriangle.Points[1])
    {
      Triangle = delaunayTriangle
    };
    AdvancingFrontNode advancingFrontNode = new AdvancingFrontNode(delaunayTriangle.Points[0])
    {
      Triangle = delaunayTriangle
    };
    AdvancingFrontNode tail = new AdvancingFrontNode(delaunayTriangle.Points[2]);
    this.Front = new AdvancingFront(head, tail)
    {
      Head = {
        Next = advancingFrontNode
      }
    };
    advancingFrontNode.Next = this.Front.Tail;
    advancingFrontNode.Prev = this.Front.Head;
    this.Front.Tail.Prev = advancingFrontNode;
  }

  public void MapTriangleToNodes(DelaunayTriangle t)
  {
    for (int index = 0; index < 3; ++index)
    {
      if (t.Neighbors[index] == null)
      {
        AdvancingFrontNode advancingFrontNode = this.Front.LocatePoint(t.PointCWFrom(t.Points[index]));
        if (advancingFrontNode != null)
          advancingFrontNode.Triangle = t;
      }
    }
  }

  public override void PrepareTriangulation(ITriangulatable t)
  {
    base.PrepareTriangulation(t);
    double x;
    double num1 = x = this.Points[0].X;
    double y;
    double num2 = y = this.Points[0].Y;
    foreach (TriangulationPoint point in this.Points)
    {
      if (point.X > num1)
        num1 = point.X;
      if (point.X < x)
        x = point.X;
      if (point.Y > num2)
        num2 = point.Y;
      if (point.Y < y)
        y = point.Y;
    }
    double num3 = 0.30000001192092896 * (num1 - x);
    double num4 = 0.30000001192092896 * (num2 - y);
    TriangulationPoint triangulationPoint_2_1 = new TriangulationPoint(num1 + num3, y - num4);
    TriangulationPoint triangulationPoint_2_2 = new TriangulationPoint(x - num3, y - num4);
    // ISSUE: reference to a compiler-generated method
    this.method_1(triangulationPoint_2_1);
    // ISSUE: reference to a compiler-generated method
    this.method_3(triangulationPoint_2_2);
    this.Points.Sort((IComparer<TriangulationPoint>) this.dtsweepPointComparator_0);
  }

  public void FinalizeTriangulation()
  {
    this.Triangulatable.AddTriangles((IEnumerable<DelaunayTriangle>) this.Triangles);
    this.Triangles.Clear();
  }

  public override DTSweepConstraint NewConstraint(TriangulationPoint a, TriangulationPoint b)
  {
    return new DTSweepConstraint((Point2D) a, (Point2D) b);
  }
}
