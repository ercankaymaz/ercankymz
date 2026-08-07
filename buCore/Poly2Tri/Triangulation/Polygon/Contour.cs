// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Polygon.Contour
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Triangulation.Sets;
using Poly2Tri.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Poly2Tri.Triangulation.Polygon;

public class Contour : 
  Point2DList,
  IEnumerable,
  IEnumerable<TriangulationPoint>,
  IList<TriangulationPoint>,
  ITriangulatable,
  ICollection<TriangulationPoint>
{
  internal readonly List<Contour> list_0 = new List<Contour>();
  internal ITriangulatable parent = (ITriangulatable) null;

  public TriangulationPoint this[int index]
  {
    get => this.MPoints[index] as TriangulationPoint;
    set => this.MPoints[index] = (Point2D) value;
  }

  public IList<DelaunayTriangle> Triangles
  {
    get => throw new NotImplementedException("PolyHole.Triangles should never get called");
  }

  public TriangulationMode TriangulationMode => this.parent.TriangulationMode;

  public bool DisplayFlipX
  {
    get => this.parent.DisplayFlipX;
    set
    {
    }
  }

  public bool DisplayFlipY
  {
    get => this.parent.DisplayFlipY;
    set
    {
    }
  }

  public float DisplayRotate
  {
    get => this.parent.DisplayRotate;
    set
    {
    }
  }

  public double Precision
  {
    get => this.parent.Precision;
    set
    {
    }
  }

  public double MinX => this.BoundingBox.MinX;

  public double MaxX => this.BoundingBox.MaxX;

  public double MinY => this.BoundingBox.MinY;

  public double MaxY => this.BoundingBox.MaxY;

  public Rect2D Bounds => this.BoundingBox;

  public Contour(ITriangulatable parent) => this.parent = parent;

  public Contour(
    ITriangulatable parent,
    IList<TriangulationPoint> points,
    Point2DList.WindingOrderType windingOrder)
  {
    this.parent = parent;
    this.method_5(points, windingOrder);
  }

  IEnumerator<TriangulationPoint> IEnumerable<TriangulationPoint>.GetEnumerator()
  {
    return this.MPoints.Cast<TriangulationPoint>().GetEnumerator();
  }

  public int IndexOf(TriangulationPoint p) => this.MPoints.IndexOf((Point2D) p);

  public void Add(TriangulationPoint p) => this.Add((Point2D) p, -1, true);

  protected override void Add(Point2D p, int idx, bool bCalcWindingOrderAndEpsilon)
  {
    TriangulationPoint p1 = !(p is TriangulationPoint) ? new TriangulationPoint(p.X, p.Y) : p as TriangulationPoint;
    if (idx < 0)
      this.MPoints.Add((Point2D) p1);
    else
      this.MPoints.Insert(idx, (Point2D) p1);
    this.BoundingBox = this.BoundingBox.AddPoint((Point2D) p1);
    if (!bCalcWindingOrderAndEpsilon)
      return;
    if (this.WindingOrder == Point2DList.WindingOrderType.Unknown)
      this.WindingOrder = this.CalculateWindingOrder();
    this.Epsilon = this.CalculateEpsilon();
  }

  protected override void AddRange(
    IEnumerator<Point2D> iter,
    Point2DList.WindingOrderType windingOrder)
  {
    if (iter == null)
      return;
    if ((this.WindingOrder != Point2DList.WindingOrderType.Unknown ? 0 : (this.Count == 0 ? 1 : 0)) != 0)
      this.WindingOrder = windingOrder;
    bool flag1 = this.WindingOrder != Point2DList.WindingOrderType.Unknown && windingOrder != Point2DList.WindingOrderType.Unknown && this.WindingOrder != windingOrder;
    bool flag2 = true;
    int count = this.MPoints.Count;
    iter.Reset();
    while (iter.MoveNext())
    {
      TriangulationPoint triangulationPoint = !(iter.Current is TriangulationPoint) ? new TriangulationPoint(iter.Current.X, iter.Current.Y) : iter.Current as TriangulationPoint;
      if (!flag2)
      {
        flag2 = true;
        this.MPoints.Add((Point2D) triangulationPoint);
      }
      else if (flag1)
        this.MPoints.Insert(count, (Point2D) triangulationPoint);
      else
        this.MPoints.Add((Point2D) triangulationPoint);
      this.BoundingBox = this.BoundingBox.AddPoint(iter.Current);
    }
    if ((this.WindingOrder != Point2DList.WindingOrderType.Unknown ? 0 : (windingOrder == Point2DList.WindingOrderType.Unknown ? 1 : 0)) != 0)
      this.WindingOrder = this.CalculateWindingOrder();
    this.Epsilon = this.CalculateEpsilon();
  }

  private void method_5(
    IList<TriangulationPoint> ilist_0,
    Point2DList.WindingOrderType windingOrderType_1)
  {
    if ((ilist_0 == null ? 1 : (ilist_0.Count < 1 ? 1 : 0)) != 0)
      return;
    if ((this.WindingOrder != Point2DList.WindingOrderType.Unknown ? 0 : (this.Count == 0 ? 1 : 0)) != 0)
      this.WindingOrder = windingOrderType_1;
    int count = ilist_0.Count;
    bool flag = this.WindingOrder != Point2DList.WindingOrderType.Unknown && windingOrderType_1 != Point2DList.WindingOrderType.Unknown && this.WindingOrder != windingOrderType_1;
    for (int index1 = 0; index1 < count; ++index1)
    {
      int index2 = index1;
      if (flag)
        index2 = ilist_0.Count - index1 - 1;
      this.Add((Point2D) ilist_0[index2], -1, false);
    }
    if (this.WindingOrder == Point2DList.WindingOrderType.Unknown)
      this.WindingOrder = this.CalculateWindingOrder();
    this.Epsilon = this.CalculateEpsilon();
  }

  public void Insert(int idx, TriangulationPoint p) => this.Add((Point2D) p, idx, true);

  public bool Remove(TriangulationPoint p) => this.Remove((Point2D) p);

  public bool Contains(TriangulationPoint p) => this.MPoints.Contains((Point2D) p);

  public void CopyTo(TriangulationPoint[] array, int arrayIndex)
  {
    int num = Math.Min(this.Count, array.Length - arrayIndex);
    for (int index = 0; index < num; ++index)
      array[arrayIndex + index] = this.MPoints[index] as TriangulationPoint;
  }

  public int GetNumHoles(bool parentIsHole)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Contour.Class2 class2 = new Contour.Class2();
    // ISSUE: reference to a compiler-generated field
    class2.bool_0 = parentIsHole;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    return (class2.bool_0 ? 0 : 1) + this.list_0.Sum<Contour>(new Func<Contour, int>(class2.method_0));
  }

  public void GetActualHoles(bool parentIsHole, ref List<Contour> holes)
  {
    if (parentIsHole)
      holes.Add(this);
    foreach (Contour contour in this.list_0)
      contour.GetActualHoles(!parentIsHole, ref holes);
  }

  public List<Contour>.Enumerator GetHoleEnumerator() => this.list_0.GetEnumerator();

  public void InitializeHoles(ConstrainedPointSet cps)
  {
    Contour.InitializeHoles(this.list_0, (ITriangulatable) this, cps);
    foreach (Contour contour in this.list_0)
      contour.InitializeHoles(cps);
  }

  public static void InitializeHoles(
    List<Contour> holes,
    ITriangulatable parent,
    ConstrainedPointSet cps)
  {
    int count1 = holes.Count;
    for (int index1 = 0; index1 < count1; ++index1)
    {
      int index2 = index1 + 1;
      while (index2 < count1)
      {
        if (PolygonUtil.PolygonsAreSame2D((IList<Point2D>) holes[index1], (IList<Point2D>) holes[index2]))
        {
          holes.RemoveAt(index2);
          --count1;
        }
        else
          ++index2;
      }
    }
    int index3 = 0;
    while (index3 < count1)
    {
      bool flag = true;
      int index4 = index3 + 1;
      while (index4 < count1)
      {
        if (PolygonUtil.PolygonContainsPolygon((IList<Point2D>) holes[index3], holes[index3].Bounds, (IList<Point2D>) holes[index4], holes[index4].Bounds, false))
        {
          Class30.smethod_183(holes[index3], holes[index4]);
          holes.RemoveAt(index4);
          --count1;
        }
        else if (!PolygonUtil.PolygonContainsPolygon((IList<Point2D>) holes[index4], holes[index4].Bounds, (IList<Point2D>) holes[index3], holes[index3].Bounds, false))
        {
          if (PolygonUtil.PolygonsIntersect2D((IList<Point2D>) holes[index3], holes[index3].Bounds, (IList<Point2D>) holes[index4], holes[index4].Bounds))
          {
            PolygonOperationContext ctx = new PolygonOperationContext();
            if (ctx.Init(PolygonUtil.PolyOperation.Union | PolygonUtil.PolyOperation.Intersect, (Point2DList) holes[index3], (Point2DList) holes[index4]))
            {
              Point2DList l = PolygonUtil.PolygonOperation(ctx) == PolygonUtil.PolyUnionError.None ? ctx.Union : throw new Exception("PolygonOperation had an error!");
              Point2DList intersect = ctx.Intersect;
              Contour contour = new Contour(parent);
              contour.AddRange(l);
              contour.WindingOrder = Point2DList.WindingOrderType.AntiClockwise;
              int num1 = Class30.smethod_130(holes[index3]);
              for (int int_0 = 0; int_0 < num1; ++int_0)
                Class30.smethod_183(contour, Class30.smethod_127(int_0, holes[index3]));
              int num2 = Class30.smethod_130(holes[index4]);
              for (int int_0 = 0; int_0 < num2; ++int_0)
                Class30.smethod_183(contour, Class30.smethod_127(int_0, holes[index4]));
              Contour contour_1 = new Contour((ITriangulatable) contour);
              contour_1.AddRange(intersect);
              contour_1.WindingOrder = Point2DList.WindingOrderType.AntiClockwise;
              Class30.smethod_183(contour, contour_1);
              holes[index3] = contour;
              holes.RemoveAt(index4);
              --count1;
              index4 = index3 + 1;
            }
            else
            {
              if (ctx.Error != PolygonUtil.PolyUnionError.Poly1InsidePoly2)
                throw new Exception("PolygonOperationContext.Init had an error during initialization");
              Class30.smethod_183(holes[index4], holes[index3]);
              holes.RemoveAt(index3);
              --count1;
              flag = false;
              break;
            }
          }
          else
            ++index4;
        }
        else
        {
          Class30.smethod_183(holes[index4], holes[index3]);
          holes.RemoveAt(index3);
          --count1;
          flag = false;
          break;
        }
      }
      if (flag)
        ++index3;
    }
    int count2 = holes.Count;
    for (int index5 = 0; index5 < count2; ++index5)
    {
      int count3 = holes[index5].Count;
      for (int index6 = 0; index6 < count3; ++index6)
      {
        int index7 = holes[index5].NextIndex(index6);
        uint contraintCode = TriangulationConstraint.CalculateContraintCode(holes[index5][index6], holes[index5][index7]);
        TriangulationConstraint tc;
        if (!cps.TryGetConstraint(contraintCode, out tc))
        {
          tc = new TriangulationConstraint((Point2D) holes[index5][index6], (Point2D) holes[index5][index7]);
          cps.AddConstraint(tc);
        }
        if ((int) holes[index5][index6].VertexCode == (int) tc.P.VertexCode)
          holes[index5][index6] = tc.P;
        else if ((int) holes[index5][index7].VertexCode == (int) tc.P.VertexCode)
          holes[index5][index7] = tc.P;
        if ((int) holes[index5][index6].VertexCode == (int) tc.Q.VertexCode)
          holes[index5][index6] = tc.Q;
        else if ((int) holes[index5][index7].VertexCode == (int) tc.Q.VertexCode)
          holes[index5][index7] = tc.Q;
      }
    }
  }

  public void Prepare(TriangulationContext tcx)
  {
    throw new NotImplementedException("PolyHole.Prepare should never get called");
  }

  public void AddTriangle(DelaunayTriangle t)
  {
    throw new NotImplementedException("PolyHole.AddTriangle should never get called");
  }

  public void AddTriangles(IEnumerable<DelaunayTriangle> list)
  {
    throw new NotImplementedException("PolyHole.AddTriangles should never get called");
  }

  public void ClearTriangles()
  {
    throw new NotImplementedException("PolyHole.ClearTriangles should never get called");
  }

  public Point2D FindPointInContour()
  {
    Point2D pointInContour;
    if (this.Count < 3)
    {
      pointInContour = (Point2D) null;
    }
    else
    {
      Point2D centroid = this.GetCentroid();
      if (Class30.smethod_120(centroid, this))
      {
        pointInContour = centroid;
      }
      else
      {
        Random random = new Random();
        do
        {
          centroid.X = random.NextDouble() * (this.MaxX - this.MinX) + this.MinX;
          centroid.Y = random.NextDouble() * (this.MaxY - this.MinY) + this.MinY;
        }
        while (!Class30.smethod_120(centroid, this));
        pointInContour = centroid;
      }
    }
    return pointInContour;
  }
}
