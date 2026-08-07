// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Polygon.Polygon
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Poly2Tri.Triangulation.Polygon;

public class Polygon : 
  Point2DList,
  IEnumerable,
  IEnumerable<TriangulationPoint>,
  IList<TriangulationPoint>,
  ITriangulatable,
  ICollection<TriangulationPoint>
{
  private readonly Dictionary<uint, TriangulationPoint> dictionary_0 = new Dictionary<uint, TriangulationPoint>();
  private List<DelaunayTriangle> list_0;
  private double double_1 = 3.0;
  private PolygonPoint polygonPoint_0;

  public IList<TriangulationPoint> Points => (IList<TriangulationPoint>) this;

  public IList<DelaunayTriangle> Triangles => (IList<DelaunayTriangle>) this.list_0;

  public TriangulationMode TriangulationMode => TriangulationMode.Polygon;

  public string FileName { get; set; }

  public bool DisplayFlipX { get; set; }

  public bool DisplayFlipY { get; set; }

  public float DisplayRotate { get; set; }

  public double Precision
  {
    get => this.double_1;
    set => this.double_1 = value;
  }

  public double MinX => this.BoundingBox.MinX;

  public double MaxX => this.BoundingBox.MaxX;

  public double MinY => this.BoundingBox.MinY;

  public double MaxY => this.BoundingBox.MaxY;

  public Rect2D Bounds => this.BoundingBox;

  public TriangulationPoint this[int index]
  {
    get => this.MPoints[index] as TriangulationPoint;
    set => this.MPoints[index] = (Point2D) value;
  }

  private Polygon(IList<PolygonPoint> ilist_0)
  {
    if (ilist_0.Count < 3)
      throw new ArgumentException("List has fewer than 3 points", "points");
    this.method_7(ilist_0, Point2DList.WindingOrderType.Unknown);
  }

  public Polygon(IEnumerable<PolygonPoint> points)
    : this((IList<PolygonPoint>) ((object) (points as IList<PolygonPoint>) ?? (object) points.ToArray<PolygonPoint>()))
  {
  }

  public Polygon(params PolygonPoint[] points)
    : this((IList<PolygonPoint>) points)
  {
  }

  IEnumerator<TriangulationPoint> IEnumerable<TriangulationPoint>.GetEnumerator()
  {
    return this.MPoints.Cast<TriangulationPoint>().GetEnumerator();
  }

  public int IndexOf(TriangulationPoint p) => this.MPoints.IndexOf((Point2D) p);

  public override void Add(Point2D p) => this.Add(p, -1, true);

  public void Add(TriangulationPoint p) => this.Add((Point2D) p, -1, true);

  public void Add(PolygonPoint p) => this.Add((Point2D) p, -1, true);

  protected override void Add(Point2D p, int idx, bool bCalcWindingOrderAndEpsilon)
  {
    if (!(p is TriangulationPoint triangulationPoint) || this.dictionary_0.ContainsKey(triangulationPoint.VertexCode))
      return;
    this.dictionary_0.Add(triangulationPoint.VertexCode, triangulationPoint);
    base.Add(p, idx, bCalcWindingOrderAndEpsilon);
    if (!(p is PolygonPoint polygonPoint))
      return;
    polygonPoint.Previous = this.polygonPoint_0;
    if (this.polygonPoint_0 != null)
    {
      polygonPoint.Next = this.polygonPoint_0.Next;
      this.polygonPoint_0.Next = polygonPoint;
    }
    this.polygonPoint_0 = polygonPoint;
  }

  private void method_7(
    IList<PolygonPoint> ilist_0,
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

  public void AddRange(IList<TriangulationPoint> points, Point2DList.WindingOrderType windingOrder)
  {
    if ((points == null ? 1 : (points.Count < 1 ? 1 : 0)) != 0)
      return;
    if ((this.WindingOrder != Point2DList.WindingOrderType.Unknown ? 0 : (this.Count == 0 ? 1 : 0)) != 0)
      this.WindingOrder = windingOrder;
    int count = points.Count;
    bool flag = this.WindingOrder != Point2DList.WindingOrderType.Unknown && windingOrder != Point2DList.WindingOrderType.Unknown && this.WindingOrder != windingOrder;
    for (int index1 = 0; index1 < count; ++index1)
    {
      int index2 = index1;
      if (flag)
        index2 = points.Count - index1 - 1;
      this.Add((Point2D) points[index2], -1, false);
    }
    if (this.WindingOrder == Point2DList.WindingOrderType.Unknown)
      this.WindingOrder = this.CalculateWindingOrder();
    this.Epsilon = this.CalculateEpsilon();
  }

  public void Insert(int idx, TriangulationPoint p) => this.Add((Point2D) p, idx, true);

  public bool Remove(TriangulationPoint p) => this.Remove((Point2D) p);

  public void RemovePoint(PolygonPoint p)
  {
    PolygonPoint next = p.Next;
    PolygonPoint previous = p.Previous;
    previous.Next = next;
    next.Previous = previous;
    this.MPoints.Remove((Point2D) p);
    this.BoundingBox = new Rect2D();
    foreach (Point2D mpoint in this.MPoints)
      this.BoundingBox = this.BoundingBox.AddPoint(mpoint);
  }

  public bool Contains(TriangulationPoint p) => this.MPoints.Contains((Point2D) p);

  public void CopyTo(TriangulationPoint[] array, int arrayIndex)
  {
    int num = Math.Min(this.Count, array.Length - arrayIndex);
    for (int index = 0; index < num; ++index)
      array[arrayIndex + index] = this.MPoints[index] as TriangulationPoint;
  }

  public void AddHole(Poly2Tri.Triangulation.Polygon.Polygon poly)
  {
    // ISSUE: reference to a compiler-generated method
    if (this.method_5() == null)
    {
      // ISSUE: reference to a compiler-generated method
      this.method_6(new List<Poly2Tri.Triangulation.Polygon.Polygon>());
    }
    // ISSUE: reference to a compiler-generated method
    this.method_5().Add(poly);
  }

  public void AddTriangle(DelaunayTriangle t) => this.list_0.Add(t);

  public void AddTriangles(IEnumerable<DelaunayTriangle> list) => this.list_0.AddRange(list);

  public void ClearTriangles()
  {
    if (this.list_0 == null)
      return;
    this.list_0.Clear();
  }

  public bool IsPointInside(TriangulationPoint p)
  {
    return PolygonUtil.PointInPolygon2D((IList<Point2D>) this, (Point2D) p);
  }

  public void Prepare(TriangulationContext tcx)
  {
    if (this.list_0 == null)
      this.list_0 = new List<DelaunayTriangle>(this.MPoints.Count);
    else
      this.list_0.Clear();
    for (int index = 0; index < this.MPoints.Count - 1; ++index)
      tcx.NewConstraint(this[index], this[index + 1]);
    tcx.NewConstraint(this[0], this[this.Count - 1]);
    tcx.Points.AddRange((IEnumerable<TriangulationPoint>) this);
    // ISSUE: reference to a compiler-generated method
    if (this.method_5() == null)
      return;
    // ISSUE: reference to a compiler-generated method
    foreach (Poly2Tri.Triangulation.Polygon.Polygon collection in this.method_5())
    {
      for (int index = 0; index < collection.MPoints.Count - 1; ++index)
        tcx.NewConstraint(collection[index], collection[index + 1]);
      tcx.NewConstraint(collection[0], collection[collection.Count - 1]);
      tcx.Points.AddRange((IEnumerable<TriangulationPoint>) collection);
    }
  }
}
