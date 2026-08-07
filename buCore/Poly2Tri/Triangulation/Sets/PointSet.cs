// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Sets.PointSet
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
namespace Poly2Tri.Triangulation.Sets;

public class PointSet : 
  Point2DList,
  IEnumerable,
  IEnumerable<TriangulationPoint>,
  IList<TriangulationPoint>,
  ITriangulatable,
  ICollection<TriangulationPoint>
{
  private readonly Dictionary<uint, TriangulationPoint> dictionary_0 = new Dictionary<uint, TriangulationPoint>();
  private double double_1 = 3.0;

  public IList<DelaunayTriangle> Triangles { get; private set; }

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

  public virtual TriangulationMode TriangulationMode => TriangulationMode.Unconstrained;

  public TriangulationPoint this[int index]
  {
    get => this.MPoints[index] as TriangulationPoint;
    set => this.MPoints[index] = (Point2D) value;
  }

  protected PointSet(IEnumerable<TriangulationPoint> bounds)
  {
    foreach (TriangulationPoint bound in bounds)
    {
      this.Add(bound, -1, false);
      this.BoundingBox = this.BoundingBox.AddPoint((Point2D) bound);
    }
    this.Epsilon = this.CalculateEpsilon();
    this.WindingOrder = Point2DList.WindingOrderType.Unknown;
  }

  IEnumerator<TriangulationPoint> IEnumerable<TriangulationPoint>.GetEnumerator()
  {
    return this.MPoints.Cast<TriangulationPoint>().GetEnumerator();
  }

  public int IndexOf(TriangulationPoint p) => this.MPoints.IndexOf((Point2D) p);

  public override void Add(Point2D p) => this.Add(p as TriangulationPoint, -1, false);

  public virtual void Add(TriangulationPoint p) => this.Add(p, -1, false);

  protected override void Add(Point2D p, int idx, bool constrainToBounds)
  {
    this.Add(p as TriangulationPoint, idx, constrainToBounds);
  }

  protected bool Add(TriangulationPoint p, int idx, bool constrainToBounds)
  {
    bool flag;
    if (p == null)
    {
      flag = false;
    }
    else
    {
      if (constrainToBounds)
        this.ConstrainPointToBounds(p);
      if (this.dictionary_0.ContainsKey(p.VertexCode))
      {
        flag = true;
      }
      else
      {
        this.dictionary_0.Add(p.VertexCode, p);
        if (idx < 0)
          this.MPoints.Add((Point2D) p);
        else
          this.MPoints.Insert(idx, (Point2D) p);
        flag = true;
      }
    }
    return flag;
  }

  protected override void AddRange(
    IEnumerator<Point2D> iter,
    Point2DList.WindingOrderType windingOrder)
  {
    if (iter == null)
      return;
    iter.Reset();
    while (iter.MoveNext())
      this.Add(iter.Current);
  }

  public virtual bool AddRange(IEnumerable<TriangulationPoint> points)
  {
    bool flag = true;
    foreach (TriangulationPoint point in points)
      flag = this.Add(point, -1, false) & flag;
    return flag;
  }

  protected bool TryGetPoint(double x, double y, out TriangulationPoint p)
  {
    return this.dictionary_0.TryGetValue(TriangulationPoint.CreateVertexCode(x, y, this.Precision), out p);
  }

  public void Insert(int idx, TriangulationPoint item) => this.MPoints.Insert(idx, (Point2D) item);

  public override bool Remove(Point2D p) => this.MPoints.Remove(p);

  public bool Remove(TriangulationPoint p) => this.MPoints.Remove((Point2D) p);

  public override void RemoveAt(int idx)
  {
    if ((idx < 0 ? 1 : (idx >= this.Count ? 1 : 0)) != 0)
      return;
    this.MPoints.RemoveAt(idx);
  }

  public bool Contains(TriangulationPoint p) => this.MPoints.Contains((Point2D) p);

  public void CopyTo(TriangulationPoint[] array, int arrayIndex)
  {
    int num = Math.Min(this.Count, array.Length - arrayIndex);
    for (int index = 0; index < num; ++index)
      array[arrayIndex + index] = this.MPoints[index] as TriangulationPoint;
  }

  protected bool ConstrainPointToBounds(Point2D p)
  {
    double x = p.X;
    double y = p.Y;
    p.X = Math.Max(this.MinX, p.X);
    p.X = Math.Min(this.MaxX, p.X);
    p.Y = Math.Max(this.MinY, p.Y);
    p.Y = Math.Min(this.MaxY, p.Y);
    return p.X != x || p.Y != y;
  }

  protected internal bool ConstrainPointToBounds(TriangulationPoint p)
  {
    double x = p.X;
    double y = p.Y;
    p.X = Math.Max(this.MinX, p.X);
    p.X = Math.Min(this.MaxX, p.X);
    p.Y = Math.Max(this.MinY, p.Y);
    p.Y = Math.Min(this.MaxY, p.Y);
    return p.X != x || p.Y != y;
  }

  public virtual void AddTriangle(DelaunayTriangle t) => this.Triangles.Add(t);

  public void AddTriangles(IEnumerable<DelaunayTriangle> list)
  {
    foreach (DelaunayTriangle t in list)
      this.AddTriangle(t);
  }

  public void ClearTriangles() => this.Triangles.Clear();

  protected virtual bool Initialize() => true;

  public virtual void Prepare(TriangulationContext tcx)
  {
    if (this.Triangles == null)
      this.Triangles = (IList<DelaunayTriangle>) new List<DelaunayTriangle>(this.Count);
    else
      this.Triangles.Clear();
    tcx.Points.AddRange((IEnumerable<TriangulationPoint>) this);
  }
}
