// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Utility.Point2DList
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using Poly2Tri.Triangulation;
using Poly2Tri.Triangulation.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace Poly2Tri.Utility;

public class Point2DList : IEnumerable, IEnumerable<Point2D>, IList<Point2D>, ICollection<Point2D>
{
  public const double LINEAR_SLOP = 0.005;
  protected readonly List<Point2D> MPoints = new List<Point2D>();
  private Point2DList.WindingOrderType windingOrderType_0 = Point2DList.WindingOrderType.Unknown;
  private Rect2D rect2D_0 = new Rect2D();

  public Rect2D BoundingBox
  {
    get => this.rect2D_0;
    protected set => this.rect2D_0 = value;
  }

  public Point2DList.WindingOrderType WindingOrder
  {
    get => this.windingOrderType_0;
    set
    {
      if (this.windingOrderType_0 == Point2DList.WindingOrderType.Unknown)
        this.windingOrderType_0 = this.CalculateWindingOrder();
      if ((value == this.windingOrderType_0 ? 0 : (value != Point2DList.WindingOrderType.Unknown ? 1 : 0)) != 0)
        this.MPoints.Reverse();
      this.windingOrderType_0 = value;
    }
  }

  public double Epsilon { get; protected set; }

  public Point2D this[int index]
  {
    get => this.MPoints[index];
    set => this.MPoints[index] = value;
  }

  public int Count => this.MPoints.Count;

  public virtual bool IsReadOnly => false;

  public Point2DList() => this.Epsilon = 1E-12;

  private Point2DList(int int_0)
    : this()
  {
    this.MPoints.Capacity = int_0;
  }

  public Point2DList(Point2DList l)
    : this()
  {
    int count = l.Count;
    for (int index = 0; index < count; ++index)
      this.MPoints.Add(l[index]);
    this.rect2D_0 = l.BoundingBox;
    this.Epsilon = l.Epsilon;
    this.windingOrderType_0 = l.WindingOrder;
  }

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; index < this.Count; ++index)
    {
      stringBuilder.Append((object) this[index]);
      if (index < this.Count - 1)
        stringBuilder.Append(" ");
    }
    return stringBuilder.ToString();
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return (IEnumerator) ((IEnumerable<Point2D>) this).GetEnumerator();
  }

  IEnumerator<Point2D> IEnumerable<Point2D>.GetEnumerator()
  {
    return (IEnumerator<Point2D>) this.MPoints.GetEnumerator();
  }

  public void Clear()
  {
    this.MPoints.Clear();
    this.rect2D_0 = new Rect2D();
    this.Epsilon = 1E-12;
    this.windingOrderType_0 = Point2DList.WindingOrderType.Unknown;
  }

  public int IndexOf(Point2D p) => this.MPoints.IndexOf(p);

  public virtual void Add(Point2D p) => this.Add(p, -1, true);

  protected virtual void Add(Point2D p, int idx, bool bCalcWindingOrderAndEpsilon)
  {
    if (idx < 0)
      this.MPoints.Add(p);
    else
      this.MPoints.Insert(idx, p);
    this.BoundingBox = this.BoundingBox.AddPoint(p);
    if (!bCalcWindingOrderAndEpsilon)
      return;
    if (this.windingOrderType_0 == Point2DList.WindingOrderType.Unknown)
      this.windingOrderType_0 = this.CalculateWindingOrder();
    this.Epsilon = this.CalculateEpsilon();
  }

  public void AddRange(Point2DList l)
  {
    this.AddRange((IEnumerator<Point2D>) l.MPoints.GetEnumerator(), l.WindingOrder);
  }

  public void AddRange(IEnumerable<Point2D> items)
  {
    this.AddRange(items.GetEnumerator(), Point2DList.WindingOrderType.Unknown);
  }

  protected virtual void AddRange(
    IEnumerator<Point2D> iter,
    Point2DList.WindingOrderType windingOrder)
  {
    if (iter == null)
      return;
    if ((this.windingOrderType_0 != Point2DList.WindingOrderType.Unknown ? 0 : (this.Count == 0 ? 1 : 0)) != 0)
      this.windingOrderType_0 = windingOrder;
    bool flag1 = this.WindingOrder != Point2DList.WindingOrderType.Unknown && windingOrder != Point2DList.WindingOrderType.Unknown && this.WindingOrder != windingOrder;
    bool flag2 = true;
    int count = this.MPoints.Count;
    iter.Reset();
    while (iter.MoveNext())
    {
      if (!flag2)
      {
        flag2 = true;
        this.MPoints.Add(iter.Current);
      }
      else if (flag1)
        this.MPoints.Insert(count, iter.Current);
      else
        this.MPoints.Add(iter.Current);
      this.BoundingBox = this.BoundingBox.AddPoint(iter.Current);
    }
    if ((this.windingOrderType_0 != Point2DList.WindingOrderType.Unknown ? 0 : (windingOrder == Point2DList.WindingOrderType.Unknown ? 1 : 0)) != 0)
      this.windingOrderType_0 = this.CalculateWindingOrder();
    this.Epsilon = this.CalculateEpsilon();
  }

  public virtual void Insert(int idx, Point2D item) => this.Add(item, idx, true);

  public virtual bool Remove(Point2D p)
  {
    bool flag;
    if (this.MPoints.Remove(p))
    {
      this.method_0();
      this.Epsilon = this.CalculateEpsilon();
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  public virtual void RemoveAt(int idx)
  {
    if ((idx < 0 ? 1 : (idx >= this.Count ? 1 : 0)) != 0)
      return;
    this.MPoints.RemoveAt(idx);
    this.method_0();
    this.Epsilon = this.CalculateEpsilon();
  }

  public void RemoveRange(int idxStart, int count)
  {
    if ((idxStart < 0 ? 1 : (idxStart >= this.Count ? 1 : 0)) != 0 || count == 0)
      return;
    this.MPoints.RemoveRange(idxStart, count);
    this.method_0();
    this.Epsilon = this.CalculateEpsilon();
  }

  public bool Contains(Point2D p) => this.MPoints.Contains(p);

  public void CopyTo(Point2D[] array, int arrayIndex)
  {
    int num = Math.Min(this.Count, array.Length - arrayIndex);
    for (int index = 0; index < num; ++index)
      array[arrayIndex + index] = this.MPoints[index];
  }

  private void method_0()
  {
    this.rect2D_0 = new Rect2D();
    foreach (Point2D mpoint in this.MPoints)
      this.BoundingBox = this.BoundingBox.AddPoint(mpoint);
  }

  public double CalculateEpsilon()
  {
    Rect2D boundingBox = this.BoundingBox;
    double width = boundingBox.Width;
    boundingBox = this.BoundingBox;
    double height = boundingBox.Height;
    return Math.Max(Math.Min(width, height) * (1.0 / 1000.0), 1E-12);
  }

  public Point2DList.WindingOrderType CalculateWindingOrder()
  {
    double num = this.method_1();
    return num >= 0.0 ? (num <= 0.0 ? Point2DList.WindingOrderType.Unknown : Point2DList.WindingOrderType.AntiClockwise) : Point2DList.WindingOrderType.Clockwise;
  }

  public int NextIndex(int index) => index != this.Count - 1 ? index + 1 : 0;

  public int PreviousIndex(int index) => index != 0 ? index - 1 : this.Count - 1;

  private double method_1()
  {
    double num = 0.0;
    for (int index1 = 0; index1 < this.Count; ++index1)
    {
      int index2 = (index1 + 1) % this.Count;
      num = num + this[index1].X * this[index2].Y - this[index1].Y * this[index2].X;
    }
    return num / 2.0;
  }

  private double method_2()
  {
    double num1 = 0.0;
    for (int index1 = 0; index1 < this.Count; ++index1)
    {
      int index2 = (index1 + 1) % this.Count;
      num1 = num1 + this[index1].X * this[index2].Y - this[index1].Y * this[index2].X;
    }
    double num2 = num1 / 2.0;
    return num2 < 0.0 ? -num2 : num2;
  }

  public Point2D GetCentroid()
  {
    Point2D point2D1 = new Point2D();
    double num1 = 0.0;
    Point2D point2D2 = new Point2D();
    for (int index = 0; index < this.Count; ++index)
    {
      Point2D point2D3 = point2D2;
      Point2D point2D4 = this[index];
      Point2D point2D5 = index + 1 < this.Count ? this[index + 1] : this[0];
      double num2 = 0.5 * Point2D.Cross(point2D4 - point2D3, point2D5 - point2D3);
      num1 += num2;
      point2D1 += num2 * (1.0 / 3.0) * (point2D3 + point2D4 + point2D5);
    }
    return point2D1 * (1.0 / num1);
  }

  public void Translate(Point2D vector)
  {
    for (int index = 0; index < this.Count; ++index)
      this[index] += vector;
  }

  public void Scale(Point2D value)
  {
    for (int index = 0; index < this.Count; ++index)
      this[index] *= value;
  }

  public void Rotate(double radians)
  {
    double num1 = Math.Cos(radians);
    double num2 = Math.Sin(radians);
    foreach (Point2D mpoint in this.MPoints)
    {
      double x = mpoint.X;
      mpoint.X = x * num1 - mpoint.Y * num2;
      mpoint.Y = x * num2 + mpoint.Y * num1;
    }
  }

  private bool method_3()
  {
    bool flag;
    if (this.Count < 3)
    {
      flag = false;
    }
    else
    {
      for (int index1 = 0; index1 < this.Count; ++index1)
      {
        int index2 = this.PreviousIndex(index1);
        if (!this.MPoints[index2].Equals(this.MPoints[index1], this.Epsilon))
        {
          if (TriangulationUtil.Orient2d(this.MPoints[this.PreviousIndex(index2)], this.MPoints[index2], this.MPoints[index1]) == Orientation.Collinear)
          {
            flag = true;
            goto label_10;
          }
        }
        else
        {
          flag = true;
          goto label_10;
        }
      }
      flag = false;
    }
label_10:
    return flag;
  }

  public bool IsConvex()
  {
    bool flag1 = false;
    bool flag2;
    for (int index1 = 0; index1 < this.Count; ++index1)
    {
      int index2 = index1 == 0 ? this.Count - 1 : index1 - 1;
      int index3 = index1;
      int index4 = index1 == this.Count - 1 ? 0 : index1 + 1;
      double num1 = this[index3].X - this[index2].X;
      double num2 = this[index3].Y - this[index2].Y;
      double num3 = this[index4].X - this[index3].X;
      double num4 = this[index4].Y - this[index3].Y;
      bool flag3 = num1 * num4 - num3 * num2 >= 0.0;
      if (index1 == 0)
        flag1 = flag3;
      else if (flag1 != flag3)
      {
        flag2 = false;
        goto label_8;
      }
    }
    flag2 = true;
label_8:
    return flag2;
  }

  private bool method_4()
  {
    bool flag;
    for (int index1 = 0; index1 < this.Count; ++index1)
    {
      int index2 = this.NextIndex(index1);
      for (int index3 = index1 + 1; index3 < this.Count; ++index3)
      {
        int index4 = this.NextIndex(index3);
        Point2D pIntersectionPt = (Point2D) null;
        if (TriangulationUtil.LinesIntersect2D(this.MPoints[index1], this.MPoints[index2], this.MPoints[index3], this.MPoints[index4], ref pIntersectionPt, this.Epsilon))
        {
          flag = false;
          goto label_9;
        }
      }
    }
    flag = true;
label_9:
    return flag;
  }

  public Point2DList.PolygonError CheckPolygon()
  {
    Point2DList.PolygonError polygonError1 = Point2DList.PolygonError.None;
    Point2DList.PolygonError polygonError2;
    if ((this.Count < 3 ? 1 : (this.Count > 100000 ? 1 : 0)) != 0)
    {
      polygonError2 = polygonError1 | Point2DList.PolygonError.NotEnoughVertices;
    }
    else
    {
      if (this.method_3())
        polygonError1 |= Point2DList.PolygonError.Degenerate;
      if (!this.method_4())
        polygonError1 |= Point2DList.PolygonError.NotSimple;
      if (this.method_2() < 1E-12)
        polygonError1 |= Point2DList.PolygonError.AreaTooSmall;
      if ((polygonError1 & Point2DList.PolygonError.NotSimple) != Point2DList.PolygonError.NotSimple)
      {
        bool flag = false;
        if (this.WindingOrder == Point2DList.WindingOrderType.Clockwise)
        {
          this.WindingOrder = Point2DList.WindingOrderType.AntiClockwise;
          flag = true;
        }
        Point2D[] point2DArray = new Point2D[this.Count];
        Point2DList point2Dlist = new Point2DList(this.Count);
        for (int index1 = 0; index1 < this.Count; ++index1)
        {
          point2Dlist.Add(new Point2D(this[index1].X, this[index1].Y));
          int index2 = index1;
          int index3 = this.NextIndex(index1);
          Point2D lhs = new Point2D(this[index3].X - this[index2].X, this[index3].Y - this[index2].Y);
          point2DArray[index1] = Point2D.Perpendicular(lhs, 1.0);
          point2DArray[index1].Normalize();
        }
        for (int index4 = 0; index4 < this.Count; ++index4)
        {
          int index5 = this.PreviousIndex(index4);
          if ((double) Math.Abs((float) Math.Asin(MathUtil.Clamp(Point2D.Cross(point2DArray[index5], point2DArray[index4]), -1.0, 1.0))) <= 1.0 / (90.0 * Math.PI))
          {
            polygonError1 |= Point2DList.PolygonError.SidesTooCloseToParallel;
            break;
          }
        }
        if (flag)
          this.WindingOrder = Point2DList.WindingOrderType.Clockwise;
      }
      polygonError2 = polygonError1;
    }
    return polygonError2;
  }

  public static string GetErrorString(Point2DList.PolygonError error)
  {
    StringBuilder stringBuilder = new StringBuilder(256 /*0x0100*/);
    if (error == Point2DList.PolygonError.None)
    {
      stringBuilder.AppendFormat("No errors.\n");
    }
    else
    {
      if ((error & Point2DList.PolygonError.NotEnoughVertices) == Point2DList.PolygonError.NotEnoughVertices)
        stringBuilder.AppendFormat("NotEnoughVertices: must have between 3 and {0} vertices.\n", (object) 100000);
      if ((error & Point2DList.PolygonError.NotConvex) == Point2DList.PolygonError.NotConvex)
        stringBuilder.AppendFormat("NotConvex: Polygon is not convex.\n");
      if ((error & Point2DList.PolygonError.NotSimple) == Point2DList.PolygonError.NotSimple)
        stringBuilder.AppendFormat("NotSimple: Polygon is not simple (i.e. it intersects itself).\n");
      if ((error & Point2DList.PolygonError.AreaTooSmall) == Point2DList.PolygonError.AreaTooSmall)
        stringBuilder.AppendFormat("AreaTooSmall: Polygon's area is too small.\n");
      if ((error & Point2DList.PolygonError.SidesTooCloseToParallel) == Point2DList.PolygonError.SidesTooCloseToParallel)
        stringBuilder.AppendFormat("SidesTooCloseToParallel: Polygon's sides are too close to parallel.\n");
      if ((error & Point2DList.PolygonError.TooThin) == Point2DList.PolygonError.TooThin)
        stringBuilder.AppendFormat("TooThin: Polygon is too thin or core shape generation would move edge past centroid.\n");
      if ((error & Point2DList.PolygonError.Degenerate) == Point2DList.PolygonError.Degenerate)
        stringBuilder.AppendFormat("Degenerate: Polygon is degenerate (contains collinear points or duplicate coincident points).\n");
      if ((error & Point2DList.PolygonError.Unknown) == Point2DList.PolygonError.Unknown)
        stringBuilder.AppendFormat("Unknown: Unknown Polygon error!.\n");
    }
    return stringBuilder.ToString();
  }

  public void RemoveDuplicateNeighborPoints()
  {
    int count = this.Count;
    int num1 = count - 1;
    int num2 = 0;
    while ((count <= 1 ? 0 : (num2 < count ? 1 : 0)) != 0)
    {
      if (this.MPoints[num1].Equals(this.MPoints[num2]))
      {
        this.MPoints.RemoveAt(Math.Max(num1, num2));
        --count;
        if (num1 >= count)
          num1 = count - 1;
      }
      else
      {
        num1 = this.NextIndex(num1);
        ++num2;
      }
    }
  }

  public void Simplify(double bias = 0.0)
  {
    if (this.Count < 3)
      return;
    int num1 = 0;
    int count = this.Count;
    double num2 = bias * bias;
    while ((num1 >= count ? 0 : (count >= 3 ? 1 : 0)) != 0)
    {
      int index1 = this.PreviousIndex(num1);
      int index2 = this.NextIndex(num1);
      Point2D pa = this[index1];
      Point2D pb = this[num1];
      Point2D pc = this[index2];
      if ((pa - pb).MagnitudeSquared() <= num2)
      {
        this.RemoveAt(num1);
        --count;
      }
      else if (TriangulationUtil.Orient2d(pa, pb, pc) == Orientation.Collinear)
      {
        this.RemoveAt(num1);
        --count;
      }
      else
        ++num1;
    }
  }

  public void MergeParallelEdges(double tolerance)
  {
    if (this.Count <= 3)
      return;
    bool[] flagArray = new bool[this.Count];
    int count = this.Count;
    for (int index1 = 0; index1 < this.Count; ++index1)
    {
      int index2 = index1 == 0 ? this.Count - 1 : index1 - 1;
      int index3 = index1;
      int index4 = index1 == this.Count - 1 ? 0 : index1 + 1;
      double num1 = this[index3].X - this[index2].X;
      double num2 = this[index3].Y - this[index2].Y;
      double num3 = this[index4].Y - this[index3].X;
      double num4 = this[index4].Y - this[index3].Y;
      double num5 = Math.Sqrt(num1 * num1 + num2 * num2);
      double num6 = Math.Sqrt(num3 * num3 + num4 * num4);
      if ((num5 <= 0.0 || num6 <= 0.0 ? (count > 3 ? 1 : 0) : 0) != 0)
      {
        flagArray[index1] = true;
        --count;
      }
      double num7 = num1 / num5;
      double num8 = num2 / num5;
      double num9 = num3 / num6;
      double num10 = num4 / num6;
      double num11 = num7 * num10 - num9 * num8;
      double num12 = num7 * num9 + num8 * num10;
      if ((Math.Abs(num11) >= tolerance || num12 <= 0.0 ? 0 : (count > 3 ? 1 : 0)) != 0)
      {
        flagArray[index1] = true;
        --count;
      }
      else
        flagArray[index1] = false;
    }
    if ((count == this.Count ? 1 : (count == 0 ? 1 : 0)) != 0)
      return;
    int num = 0;
    Point2DList point2Dlist = new Point2DList(this);
    this.Clear();
    for (int index = 0; index < point2Dlist.Count; ++index)
    {
      if ((flagArray[index] || count == 0 ? 1 : (num == count ? 1 : 0)) == 0)
      {
        if (num < count)
        {
          this.MPoints.Add(point2Dlist[index]);
          this.BoundingBox = this.BoundingBox.AddPoint(point2Dlist[index]);
          ++num;
        }
        else
          throw new Exception($"Point2DList::MergeParallelEdges - currIndex[ {num.ToString()}] >= newNVertices[{count.ToString()}]");
      }
    }
    this.windingOrderType_0 = this.CalculateWindingOrder();
    this.Epsilon = this.CalculateEpsilon();
  }

  public void ProjectToAxis(Point2D axis, out double min, out double max)
  {
    double num1 = Point2D.Dot(axis, this[0]);
    min = num1;
    max = num1;
    for (int index = 0; index < this.Count; ++index)
    {
      double num2 = Point2D.Dot(this[index], axis);
      if (num2 < min)
        min = num2;
      else if (num2 > max)
        max = num2;
    }
  }

  public enum WindingOrderType
  {
    Clockwise = 0,
    AntiClockwise = 1,
    Default = 1,
    Unknown = 2,
  }

  [Flags]
  public enum PolygonError : uint
  {
    None = 0,
    NotEnoughVertices = 1,
    NotConvex = 2,
    NotSimple = 4,
    AreaTooSmall = 8,
    SidesTooCloseToParallel = 16, // 0x00000010
    TooThin = 32, // 0x00000020
    Degenerate = 64, // 0x00000040
    Unknown = 1073741824, // 0x40000000
  }
}
