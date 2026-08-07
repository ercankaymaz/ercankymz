// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Polygon.PolygonOperationContext
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using Poly2Tri.Utility;
using System;
using System.Collections.Generic;

#nullable disable
namespace Poly2Tri.Triangulation.Polygon;

public class PolygonOperationContext
{
  public PolygonUtil.PolyOperation Operations;
  public Point2DList OriginalPolygon2;
  public Point2DList Poly1;
  public Point2DList Poly2;
  public List<EdgeIntersectInfo> Intersections;
  public int StartingIndex;
  public PolygonUtil.PolyUnionError Error;
  public List<int> Poly1VectorAngles;
  public List<int> Poly2VectorAngles;
  public Dictionary<uint, Point2DList> Output = new Dictionary<uint, Point2DList>();

  public Point2DList Union
  {
    get
    {
      Point2DList union;
      if (!this.Output.TryGetValue(1U, out union))
      {
        union = new Point2DList();
        this.Output.Add(1U, union);
      }
      return union;
    }
  }

  public Point2DList Intersect
  {
    get
    {
      Point2DList intersect;
      if (!this.Output.TryGetValue(2U, out intersect))
      {
        intersect = new Point2DList();
        this.Output.Add(2U, intersect);
      }
      return intersect;
    }
  }

  public Point2DList Subtract
  {
    get
    {
      Point2DList subtract;
      if (!this.Output.TryGetValue(4U, out subtract))
      {
        subtract = new Point2DList();
        this.Output.Add(4U, subtract);
      }
      return subtract;
    }
  }

  public void Clear()
  {
    this.Operations = PolygonUtil.PolyOperation.None;
    this.OriginalPolygon2 = (Point2DList) null;
    this.Poly1 = (Point2DList) null;
    this.Poly2 = (Point2DList) null;
    this.Intersections = (List<EdgeIntersectInfo>) null;
    this.StartingIndex = -1;
    this.Error = PolygonUtil.PolyUnionError.None;
    this.Poly1VectorAngles = (List<int>) null;
    this.Poly2VectorAngles = (List<int>) null;
    this.Output = new Dictionary<uint, Point2DList>();
  }

  public bool Init(
    PolygonUtil.PolyOperation operations,
    Point2DList polygon1,
    Point2DList polygon2)
  {
    this.Clear();
    this.Operations = operations;
    this.OriginalPolygon2 = polygon2;
    this.Poly1 = new Point2DList(polygon1)
    {
      WindingOrder = Point2DList.WindingOrderType.AntiClockwise
    };
    this.Poly2 = new Point2DList(polygon2)
    {
      WindingOrder = Point2DList.WindingOrderType.AntiClockwise
    };
    Point2DList poly1 = this.Poly1;
    Point2DList poly2 = this.Poly2;
    ref List<EdgeIntersectInfo> local = ref this.Intersections;
    bool flag1;
    if (!Class30.smethod_238(poly2, poly1, out local))
    {
      this.Error = PolygonUtil.PolyUnionError.NoIntersections;
      flag1 = false;
    }
    else
    {
      int count = this.Intersections.Count;
      for (int index1 = 0; index1 < count; ++index1)
      {
        for (int index2 = index1 + 1; index2 < count; ++index2)
        {
          if ((!this.Intersections[index1].EdgeOne.EdgeStart.Equals(this.Intersections[index2].EdgeOne.EdgeStart) ? 0 : (this.Intersections[index1].EdgeOne.EdgeEnd.Equals(this.Intersections[index2].EdgeOne.EdgeEnd) ? 1 : 0)) != 0)
            this.Intersections[index2].EdgeOne.EdgeStart = this.Intersections[index1].IntersectionPoint;
          if ((!this.Intersections[index1].EdgeTwo.EdgeStart.Equals(this.Intersections[index2].EdgeTwo.EdgeStart) ? 0 : (this.Intersections[index1].EdgeTwo.EdgeEnd.Equals(this.Intersections[index2].EdgeTwo.EdgeEnd) ? 1 : 0)) != 0)
            this.Intersections[index2].EdgeTwo.EdgeStart = this.Intersections[index1].IntersectionPoint;
        }
      }
      foreach (EdgeIntersectInfo intersection in this.Intersections)
      {
        if (!this.Poly1.Contains(intersection.IntersectionPoint))
          this.Poly1.Insert(this.Poly1.IndexOf(intersection.EdgeOne.EdgeStart) + 1, intersection.IntersectionPoint);
        if (!this.Poly2.Contains(intersection.IntersectionPoint))
          this.Poly2.Insert(this.Poly2.IndexOf(intersection.EdgeTwo.EdgeStart) + 1, intersection.IntersectionPoint);
      }
      this.Poly1VectorAngles = new List<int>();
      for (int index = 0; index < this.Poly2.Count; ++index)
        this.Poly1VectorAngles.Add(-1);
      this.Poly2VectorAngles = new List<int>();
      for (int index = 0; index < this.Poly1.Count; ++index)
        this.Poly2VectorAngles.Add(-1);
      int index3 = 0;
      do
      {
        bool flag2 = PolygonOperationContext.PointInPolygonAngle(this.Poly1[index3], this.Poly2);
        this.Poly2VectorAngles[index3] = flag2 ? 1 : 0;
        if (!flag2)
          index3 = this.Poly1.NextIndex(index3);
        else
          goto label_29;
      }
      while (index3 != 0);
      goto label_30;
label_29:
      this.StartingIndex = index3;
label_30:
      if (this.StartingIndex == -1)
      {
        this.Error = PolygonUtil.PolyUnionError.Poly1InsidePoly2;
        flag1 = false;
      }
      else
        flag1 = true;
    }
    return flag1;
  }

  public static bool PointInPolygonAngle(Point2D point, Point2DList polygon)
  {
    double num = 0.0;
    for (int index = 0; index < polygon.Count; ++index)
    {
      Point2D p1 = polygon[index] - point;
      Point2D p2 = polygon[polygon.NextIndex(index)] - point;
      num += PolygonOperationContext.VectorAngle(p1, p2);
    }
    return Math.Abs(num) >= Math.PI;
  }

  public static double VectorAngle(Point2D p1, Point2D p2)
  {
    double num1 = Math.Atan2(p1.Y, p1.X);
    double num2 = Math.Atan2(p2.Y, p2.X) - num1;
    while (num2 > Math.PI)
      num2 -= 2.0 * Math.PI;
    while (num2 < -1.0 * Math.PI)
      num2 += 2.0 * Math.PI;
    return num2;
  }
}
