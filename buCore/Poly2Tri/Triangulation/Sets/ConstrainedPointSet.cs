// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Sets.ConstrainedPointSet
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Triangulation.Polygon;
using Poly2Tri.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Poly2Tri.Triangulation.Sets;

public class ConstrainedPointSet : PointSet
{
  internal readonly Dictionary<uint, TriangulationConstraint> dictionary_1 = new Dictionary<uint, TriangulationConstraint>();
  private readonly List<Contour> list_0 = new List<Contour>();

  public override TriangulationMode TriangulationMode => TriangulationMode.Constrained;

  public ConstrainedPointSet(IEnumerable<TriangulationPoint> bounds)
    : base(bounds)
  {
    this.method_6();
  }

  public ConstrainedPointSet(
    IEnumerable<TriangulationPoint> bounds,
    IEnumerable<TriangulationConstraint> constraints)
    : base(bounds)
  {
    this.method_6();
    Class30.smethod_200(this, constraints);
  }

  public ConstrainedPointSet(IList<TriangulationPoint> bounds, ICollection<int> indices)
    : base((IEnumerable<TriangulationPoint>) bounds)
  {
    this.method_6();
    List<TriangulationConstraint> ienumerable_0 = new List<TriangulationConstraint>();
    for (int index = 0; index < indices.Count; index += 2)
    {
      TriangulationConstraint triangulationConstraint = new TriangulationConstraint((Point2D) bounds[index], (Point2D) bounds[index + 1]);
      ienumerable_0.Add(triangulationConstraint);
    }
    Class30.smethod_200(this, (IEnumerable<TriangulationConstraint>) ienumerable_0);
  }

  private void method_6()
  {
    TriangulationPoint p1;
    if (!this.TryGetPoint(this.MinX, this.MinY, out p1))
    {
      p1 = new TriangulationPoint(this.MinX, this.MinY);
      this.Add(p1);
    }
    TriangulationPoint p2;
    if (!this.TryGetPoint(this.MaxX, this.MinY, out p2))
    {
      p2 = new TriangulationPoint(this.MaxX, this.MinY);
      this.Add(p2);
    }
    TriangulationPoint p3;
    if (!this.TryGetPoint(this.MaxX, this.MaxY, out p3))
    {
      p3 = new TriangulationPoint(this.MaxX, this.MaxY);
      this.Add(p3);
    }
    TriangulationPoint p4;
    if (!this.TryGetPoint(this.MinX, this.MaxY, out p4))
    {
      p4 = new TriangulationPoint(this.MinX, this.MaxY);
      this.Add(p4);
    }
    this.AddConstraint(new TriangulationConstraint((Point2D) p1, (Point2D) p2));
    this.AddConstraint(new TriangulationConstraint((Point2D) p2, (Point2D) p3));
    this.AddConstraint(new TriangulationConstraint((Point2D) p3, (Point2D) p4));
    this.AddConstraint(new TriangulationConstraint((Point2D) p4, (Point2D) p1));
  }

  public override void Add(Point2D p) => this.Add(p as TriangulationPoint, -1, true);

  public override void Add(TriangulationPoint p) => this.Add(p, -1, true);

  public override bool AddRange(IEnumerable<TriangulationPoint> points)
  {
    bool flag = true;
    foreach (TriangulationPoint point in points)
      flag = this.Add(point, -1, true) & flag;
    return flag;
  }

  public bool AddHole(List<TriangulationPoint> points)
  {
    bool flag1;
    if (points == null)
    {
      flag1 = false;
    }
    else
    {
      List<Contour> contourList = new List<Contour>();
      int index1 = 0;
      Contour contour1 = new Contour((ITriangulatable) this, (IList<TriangulationPoint>) points, Point2DList.WindingOrderType.Unknown);
      contourList.Add(contour1);
      if (this.MPoints.Count > 1)
      {
        int count = contourList[index1].Count;
        for (int index2 = 0; index2 < count; ++index2)
          this.ConstrainPointToBounds(contourList[index1][index2]);
      }
      while (index1 < contourList.Count)
      {
        contourList[index1].RemoveDuplicateNeighborPoints();
        contourList[index1].WindingOrder = Point2DList.WindingOrderType.AntiClockwise;
        bool flag2 = true;
        Point2DList.PolygonError polygonError = contourList[index1].CheckPolygon();
        while ((!flag2 ? 0 : (polygonError > Point2DList.PolygonError.None ? 1 : 0)) != 0)
        {
          if ((polygonError & Point2DList.PolygonError.NotEnoughVertices) == Point2DList.PolygonError.NotEnoughVertices)
            flag2 = false;
          else if ((polygonError & Point2DList.PolygonError.NotSimple) == Point2DList.PolygonError.NotSimple)
          {
            IEnumerable<Point2DList> point2Dlists = PolygonUtil.SplitComplexPolygon((Point2DList) contourList[index1], contourList[index1].Epsilon);
            contourList.RemoveAt(index1);
            foreach (Point2DList l in point2Dlists)
            {
              Contour contour2 = new Contour((ITriangulatable) this);
              contour2.AddRange(l);
              contourList.Add(contour2);
            }
            polygonError = contourList[index1].CheckPolygon();
          }
          else if ((polygonError & Point2DList.PolygonError.Degenerate) == Point2DList.PolygonError.Degenerate)
          {
            contourList[index1].Simplify(this.Epsilon);
            polygonError = contourList[index1].CheckPolygon();
          }
          else if (((polygonError & Point2DList.PolygonError.AreaTooSmall) == Point2DList.PolygonError.AreaTooSmall || (polygonError & Point2DList.PolygonError.SidesTooCloseToParallel) == Point2DList.PolygonError.SidesTooCloseToParallel || (polygonError & Point2DList.PolygonError.TooThin) == Point2DList.PolygonError.TooThin ? 1 : ((polygonError & Point2DList.PolygonError.Unknown) == Point2DList.PolygonError.Unknown ? 1 : 0)) != 0)
            flag2 = false;
        }
        if ((flag2 ? 0 : (contourList[index1].Count != 2 ? 1 : 0)) != 0)
          contourList.RemoveAt(index1);
        else
          ++index1;
      }
      bool flag3 = true;
      int index3 = 0;
      while (index3 < contourList.Count)
      {
        int count = contourList[index3].Count;
        if (count < 2)
        {
          ++index3;
          flag3 = false;
        }
        else
        {
          if (count == 2)
          {
            TriangulationConstraint tc;
            if (!this.dictionary_1.TryGetValue(TriangulationConstraint.CalculateContraintCode(contourList[index3][0], contourList[index3][1]), out tc))
            {
              tc = new TriangulationConstraint((Point2D) contourList[index3][0], (Point2D) contourList[index3][1]);
              this.AddConstraint(tc);
            }
          }
          else
          {
            Contour contour3 = new Contour((ITriangulatable) this, (IList<TriangulationPoint>) contourList[index3], Point2DList.WindingOrderType.Unknown);
            contour3.WindingOrder = Point2DList.WindingOrderType.AntiClockwise;
            this.list_0.Add(contour3);
          }
          ++index3;
        }
      }
      flag1 = flag3;
    }
    return flag1;
  }

  public void AddConstraint(TriangulationConstraint tc)
  {
    if ((tc == null || tc.P == null ? 1 : (tc.Q == null ? 1 : 0)) != 0 || this.dictionary_1.ContainsKey(tc.ConstraintCode))
      return;
    TriangulationPoint p;
    if (this.TryGetPoint(tc.P.X, tc.P.Y, out p))
      tc.P = p;
    else
      this.Add(tc.P);
    if (this.TryGetPoint(tc.Q.X, tc.Q.Y, out p))
      tc.Q = p;
    else
      this.Add(tc.Q);
    this.dictionary_1.Add(tc.ConstraintCode, tc);
  }

  public bool TryGetConstraint(uint constraintCode, out TriangulationConstraint tc)
  {
    return this.dictionary_1.TryGetValue(constraintCode, out tc);
  }

  public int GetNumConstraints() => this.dictionary_1.Count;

  public Dictionary<uint, TriangulationConstraint>.Enumerator GetConstraintEnumerator()
  {
    return this.dictionary_1.GetEnumerator();
  }

  public int GetNumHoles()
  {
    return this.list_0.Sum<Contour>((Func<Contour, int>) (contour_0 => contour_0.GetNumHoles(false)));
  }

  public Contour GetHole(int idx)
  {
    return (idx < 0 ? 1 : (idx >= this.list_0.Count ? 1 : 0)) == 0 ? this.list_0[idx] : (Contour) null;
  }

  public int GetActualHoles(out List<Contour> holes)
  {
    holes = new List<Contour>();
    foreach (Contour contour in this.list_0)
      contour.GetActualHoles(false, ref holes);
    return holes.Count;
  }

  private void method_7()
  {
    Contour.InitializeHoles(this.list_0, (ITriangulatable) this, this);
    foreach (Contour contour in this.list_0)
      contour.InitializeHoles(this);
  }

  protected override bool Initialize()
  {
    this.method_7();
    return base.Initialize();
  }

  public override void Prepare(TriangulationContext tcx)
  {
    if (!this.Initialize())
      return;
    base.Prepare(tcx);
    Dictionary<uint, TriangulationConstraint>.Enumerator enumerator = this.dictionary_1.GetEnumerator();
    while (enumerator.MoveNext())
    {
      TriangulationConstraint triangulationConstraint = enumerator.Current.Value;
      tcx.NewConstraint(triangulationConstraint.P, triangulationConstraint.Q);
    }
  }

  public override void AddTriangle(DelaunayTriangle t) => this.Triangles.Add(t);
}
