// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Polygon.PolygonUtil
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using Poly2Tri.Triangulation.Util;
using Poly2Tri.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Poly2Tri.Triangulation.Polygon;

public static class PolygonUtil
{
  public static Point2DList.WindingOrderType CalculateWindingOrder(IList<Point2D> l)
  {
    double num1 = 0.0;
    for (int index1 = 0; index1 < l.Count; ++index1)
    {
      int index2 = (index1 + 1) % l.Count;
      num1 = num1 + l[index1].X * l[index2].Y - l[index1].Y * l[index2].X;
    }
    double num2 = num1 / 2.0;
    return num2 >= 0.0 ? (num2 <= 0.0 ? Point2DList.WindingOrderType.Unknown : Point2DList.WindingOrderType.AntiClockwise) : Point2DList.WindingOrderType.Clockwise;
  }

  public static bool PolygonsAreSame2D(IList<Point2D> poly1, IList<Point2D> poly2)
  {
    int count1 = poly1.Count;
    int count2 = poly2.Count;
    bool flag1;
    if (count1 != count2)
    {
      flag1 = false;
    }
    else
    {
      Point2D point2D = new Point2D(0.0, 0.0);
      for (int index1 = 0; index1 < count2; ++index1)
      {
        point2D.Set(poly1[0].X, poly1[0].Y);
        point2D.Subtract(poly2[index1]);
        if (point2D.MagnitudeSquared() < 0.0001)
        {
          int num = index1;
          bool flag2 = false;
          bool flag3;
          do
          {
            flag3 = true;
            int index2 = 1;
            while (true)
            {
              if (index2 < count1)
              {
                if (!flag2)
                {
                  ++index1;
                }
                else
                {
                  --index1;
                  if (index1 < 0)
                    index1 = count2 - 1;
                }
                point2D.Set(poly1[index2].X, poly1[index2].Y);
                point2D.Subtract(poly2[index1 % count2]);
                if (point2D.MagnitudeSquared() < 0.0001)
                  ++index2;
                else
                  break;
              }
              else
                goto label_17;
            }
            if (!flag2)
            {
              index1 = num;
              flag2 = true;
              flag3 = false;
            }
            else
              goto label_20;
label_17:;
          }
          while (!flag3);
          flag1 = true;
          goto label_21;
label_20:
          flag1 = false;
          goto label_21;
        }
      }
      flag1 = false;
    }
label_21:
    return flag1;
  }

  public static bool PointInPolygon2D(IList<Point2D> polygon, Point2D p)
  {
    bool flag1;
    if ((polygon == null ? 1 : (polygon.Count < 3 ? 1 : 0)) != 0)
    {
      flag1 = false;
    }
    else
    {
      int count = polygon.Count;
      Point2D point2D1 = polygon[count - 1];
      bool flag2 = point2D1.Y >= p.Y;
      bool flag3 = false;
      for (int index = 0; index < count; ++index)
      {
        Point2D point2D2 = polygon[index];
        bool flag4 = point2D2.Y >= p.Y;
        if (flag2 != flag4 && (point2D2.Y - p.Y) * (point2D1.X - point2D2.X) >= (point2D2.X - p.X) * (point2D1.Y - point2D2.Y) == flag4)
          flag3 = !flag3;
        flag2 = flag4;
        point2D1 = point2D2;
      }
      flag1 = flag3;
    }
    return flag1;
  }

  public static bool PolygonsIntersect2D(
    IList<Point2D> poly1,
    Rect2D boundRect1,
    IList<Point2D> poly2,
    Rect2D boundRect2)
  {
    bool flag;
    if ((poly1 == null || poly1.Count < 3 || boundRect1.IsEmpty || poly2 == null || poly2.Count < 3 ? 1 : (boundRect2.IsEmpty ? 1 : 0)) != 0)
      flag = false;
    else if (!boundRect1.Intersects(boundRect2))
    {
      flag = false;
    }
    else
    {
      double epsilon = Math.Max(Math.Min(boundRect1.Width, boundRect2.Width) * (1.0 / 1000.0), 1E-12);
      int count1 = poly1.Count;
      int count2 = poly2.Count;
      for (int index1 = 0; index1 < count1; ++index1)
      {
        int index2 = index1 + 1;
        if (index2 == count1)
          index2 = 0;
        for (int index3 = 0; index3 < count2; ++index3)
        {
          int index4 = index3 + 1;
          if (index4 == count2)
            index4 = 0;
          Point2D pIntersectionPt = (Point2D) null;
          if (TriangulationUtil.LinesIntersect2D(poly1[index1], poly1[index2], poly2[index3], poly2[index4], ref pIntersectionPt, epsilon))
          {
            flag = true;
            goto label_17;
          }
        }
      }
      flag = false;
    }
label_17:
    return flag;
  }

  public static bool PolygonContainsPolygon(
    IList<Point2D> poly1,
    Rect2D boundRect1,
    IList<Point2D> poly2,
    Rect2D boundRect2,
    bool runIntersectionTest = true)
  {
    bool flag;
    if ((poly1 == null || poly1.Count < 3 || poly2 == null ? 1 : (poly2.Count < 3 ? 1 : 0)) != 0)
    {
      flag = false;
    }
    else
    {
      if (runIntersectionTest)
      {
        if (poly1.Count == poly2.Count && PolygonUtil.PolygonsAreSame2D(poly1, poly2))
        {
          flag = false;
          goto label_8;
        }
        if (PolygonUtil.PolygonsIntersect2D(poly1, boundRect1, poly2, boundRect2))
        {
          flag = false;
          goto label_8;
        }
      }
      flag = PolygonUtil.PointInPolygon2D(poly1, poly2[0]);
    }
label_8:
    return flag;
  }

  public static void ClipPolygonToPolygon(
    IList<Point2D> poly,
    IList<Point2D> clipPoly,
    out List<Point2D> outPoly)
  {
    outPoly = (List<Point2D>) null;
    if ((poly == null || poly.Count < 3 || clipPoly == null ? 1 : (clipPoly.Count < 3 ? 1 : 0)) != 0)
      return;
    outPoly = new List<Point2D>((IEnumerable<Point2D>) poly);
    int count = clipPoly.Count;
    int index1 = count - 1;
    for (int index2 = 0; index2 < count; ++index2)
    {
      Point2D point2D_1 = clipPoly[index1];
      Point2D point2D_0 = clipPoly[index2];
      List<Point2D> list_0;
      Class30.smethod_290((IList<Point2D>) outPoly, point2D_0, ref list_0, point2D_1);
      outPoly.Clear();
      outPoly.AddRange((IEnumerable<Point2D>) list_0);
      index1 = index2;
    }
  }

  public static PolygonUtil.PolyUnionError PolygonUnion(
    Point2DList polygon1,
    Point2DList polygon2,
    out Point2DList union)
  {
    PolygonOperationContext polygonOperationContext_0 = new PolygonOperationContext();
    polygonOperationContext_0.Init(PolygonUtil.PolyOperation.Union, polygon1, polygon2);
    PolygonUtil.smethod_0(polygonOperationContext_0);
    union = polygonOperationContext_0.Union;
    return polygonOperationContext_0.Error;
  }

  private static void smethod_0(PolygonOperationContext polygonOperationContext_0)
  {
    Point2DList union = polygonOperationContext_0.Union;
    if (polygonOperationContext_0.StartingIndex == -1)
    {
      switch (polygonOperationContext_0.Error)
      {
        case PolygonUtil.PolyUnionError.NoIntersections:
          return;
        case PolygonUtil.PolyUnionError.Poly1InsidePoly2:
          union.AddRange(polygonOperationContext_0.OriginalPolygon2);
          return;
        case PolygonUtil.PolyUnionError.InfiniteLoop:
          return;
      }
    }
    Point2DList polygon = polygonOperationContext_0.Poly1;
    Point2DList point2Dlist = polygonOperationContext_0.Poly2;
    List<int> intList = polygonOperationContext_0.Poly1VectorAngles;
    Point2D p = polygonOperationContext_0.Poly1[polygonOperationContext_0.StartingIndex];
    int index1 = polygonOperationContext_0.StartingIndex;
    int num = -1;
    union.Clear();
    do
    {
      union.Add(polygon[index1]);
      foreach (EdgeIntersectInfo intersection in polygonOperationContext_0.Intersections)
      {
        if (polygon[index1].Equals(intersection.IntersectionPoint, polygon.Epsilon))
        {
          int index2 = point2Dlist.IndexOf(intersection.IntersectionPoint);
          int index3 = point2Dlist.NextIndex(index2);
          Point2D point = point2Dlist[index3];
          bool flag;
          if (intList[index3] == -1)
          {
            flag = PolygonOperationContext.PointInPolygonAngle(point, polygon);
            intList[index3] = flag ? 1 : 0;
          }
          else
            flag = intList[index3] == 1;
          if (!flag)
          {
            if (polygon == polygonOperationContext_0.Poly1)
            {
              polygon = polygonOperationContext_0.Poly2;
              intList = polygonOperationContext_0.Poly2VectorAngles;
              point2Dlist = polygonOperationContext_0.Poly1;
              if (num < 0)
                num = index2;
            }
            else
            {
              polygon = polygonOperationContext_0.Poly1;
              intList = polygonOperationContext_0.Poly1VectorAngles;
              point2Dlist = polygonOperationContext_0.Poly2;
            }
            index1 = index2;
            break;
          }
        }
      }
      index1 = polygon.NextIndex(index1);
      if (polygon == polygonOperationContext_0.Poly1)
      {
        if (index1 == 0)
          break;
      }
      else if ((num < 0 ? 0 : (index1 == num ? 1 : 0)) != 0)
        break;
    }
    while ((!polygon[index1].Equals(p) ? 0 : (union.Count <= polygonOperationContext_0.Poly1.Count + polygonOperationContext_0.Poly2.Count ? 1 : 0)) != 0);
    if (union.Count <= polygonOperationContext_0.Poly1.Count + polygonOperationContext_0.Poly2.Count)
      return;
    polygonOperationContext_0.Error = PolygonUtil.PolyUnionError.InfiniteLoop;
  }

  public static PolygonUtil.PolyUnionError PolygonIntersect(
    Point2DList polygon1,
    Point2DList polygon2,
    out Point2DList intersectOut)
  {
    PolygonOperationContext polygonOperationContext_0 = new PolygonOperationContext();
    polygonOperationContext_0.Init(PolygonUtil.PolyOperation.Intersect, polygon1, polygon2);
    PolygonUtil.smethod_1(polygonOperationContext_0);
    intersectOut = polygonOperationContext_0.Intersect;
    return polygonOperationContext_0.Error;
  }

  private static void smethod_1(PolygonOperationContext polygonOperationContext_0)
  {
    Point2DList intersect = polygonOperationContext_0.Intersect;
    if (polygonOperationContext_0.StartingIndex == -1)
    {
      switch (polygonOperationContext_0.Error)
      {
        case PolygonUtil.PolyUnionError.NoIntersections:
          return;
        case PolygonUtil.PolyUnionError.Poly1InsidePoly2:
          intersect.AddRange(polygonOperationContext_0.OriginalPolygon2);
          return;
        case PolygonUtil.PolyUnionError.InfiniteLoop:
          return;
      }
    }
    Point2DList polygon = polygonOperationContext_0.Poly1;
    Point2DList point2Dlist = polygonOperationContext_0.Poly2;
    List<int> intList = polygonOperationContext_0.Poly1VectorAngles;
    int index1 = polygonOperationContext_0.Poly1.IndexOf(polygonOperationContext_0.Intersections[0].IntersectionPoint);
    Point2D p = polygonOperationContext_0.Poly1[index1];
    int num1 = index1;
    int num2 = -1;
    intersect.Clear();
    while (!intersect.Contains(polygon[index1]))
    {
      intersect.Add(polygon[index1]);
      foreach (EdgeIntersectInfo intersection in polygonOperationContext_0.Intersections)
      {
        if (polygon[index1].Equals(intersection.IntersectionPoint, polygon.Epsilon))
        {
          int index2 = point2Dlist.IndexOf(intersection.IntersectionPoint);
          int index3 = point2Dlist.NextIndex(index2);
          Point2D point = point2Dlist[index3];
          bool flag;
          if (intList[index3] == -1)
          {
            flag = PolygonOperationContext.PointInPolygonAngle(point, polygon);
            intList[index3] = flag ? 1 : 0;
          }
          else
            flag = intList[index3] == 1;
          if (flag)
          {
            if (polygon == polygonOperationContext_0.Poly1)
            {
              polygon = polygonOperationContext_0.Poly2;
              intList = polygonOperationContext_0.Poly2VectorAngles;
              point2Dlist = polygonOperationContext_0.Poly1;
              if (num2 < 0)
                num2 = index2;
            }
            else
            {
              polygon = polygonOperationContext_0.Poly1;
              intList = polygonOperationContext_0.Poly1VectorAngles;
              point2Dlist = polygonOperationContext_0.Poly2;
            }
            index1 = index2;
            break;
          }
        }
      }
      index1 = polygon.NextIndex(index1);
      if (polygon == polygonOperationContext_0.Poly1)
      {
        if (index1 == num1)
          break;
      }
      else if ((num2 < 0 ? 0 : (index1 == num2 ? 1 : 0)) != 0)
        break;
      if ((!polygon[index1].Equals(p) ? 0 : (intersect.Count <= polygonOperationContext_0.Poly1.Count + polygonOperationContext_0.Poly2.Count ? 1 : 0)) == 0)
        break;
    }
    if (intersect.Count <= polygonOperationContext_0.Poly1.Count + polygonOperationContext_0.Poly2.Count)
      return;
    polygonOperationContext_0.Error = PolygonUtil.PolyUnionError.InfiniteLoop;
  }

  public static PolygonUtil.PolyUnionError PolygonSubtract(
    Point2DList polygon1,
    Point2DList polygon2,
    out Point2DList subtract)
  {
    PolygonOperationContext polygonOperationContext_0 = new PolygonOperationContext();
    polygonOperationContext_0.Init(PolygonUtil.PolyOperation.Subtract, polygon1, polygon2);
    PolygonUtil.smethod_2(polygonOperationContext_0);
    subtract = polygonOperationContext_0.Subtract;
    return polygonOperationContext_0.Error;
  }

  private static void smethod_2(PolygonOperationContext polygonOperationContext_0)
  {
    Point2DList subtract = polygonOperationContext_0.Subtract;
    if (polygonOperationContext_0.StartingIndex == -1)
    {
      switch (polygonOperationContext_0.Error)
      {
        case PolygonUtil.PolyUnionError.NoIntersections:
        case PolygonUtil.PolyUnionError.Poly1InsidePoly2:
        case PolygonUtil.PolyUnionError.InfiniteLoop:
          return;
      }
    }
    Point2DList polygon = polygonOperationContext_0.Poly1;
    Point2DList point2Dlist = polygonOperationContext_0.Poly2;
    List<int> intList = polygonOperationContext_0.Poly1VectorAngles;
    Point2D p = polygonOperationContext_0.Poly1[polygonOperationContext_0.StartingIndex];
    int index1 = polygonOperationContext_0.StartingIndex;
    subtract.Clear();
    bool flag1 = true;
    do
    {
      subtract.Add(polygon[index1]);
      foreach (EdgeIntersectInfo intersection in polygonOperationContext_0.Intersections)
      {
        if (polygon[index1].Equals(intersection.IntersectionPoint, polygon.Epsilon))
        {
          int index2 = point2Dlist.IndexOf(intersection.IntersectionPoint);
          if (flag1)
          {
            int index3 = point2Dlist.PreviousIndex(index2);
            Point2D point = point2Dlist[index3];
            bool flag2;
            if (intList[index3] == -1)
            {
              flag2 = PolygonOperationContext.PointInPolygonAngle(point, polygon);
              intList[index3] = flag2 ? 1 : 0;
            }
            else
              flag2 = intList[index3] == 1;
            if (flag2)
            {
              if (polygon == polygonOperationContext_0.Poly1)
              {
                polygon = polygonOperationContext_0.Poly2;
                intList = polygonOperationContext_0.Poly2VectorAngles;
                point2Dlist = polygonOperationContext_0.Poly1;
              }
              else
              {
                polygon = polygonOperationContext_0.Poly1;
                intList = polygonOperationContext_0.Poly1VectorAngles;
                point2Dlist = polygonOperationContext_0.Poly2;
              }
              index1 = index2;
              flag1 = false;
              break;
            }
          }
          else
          {
            int index4 = point2Dlist.NextIndex(index2);
            Point2D point = point2Dlist[index4];
            bool flag3;
            if (intList[index4] == -1)
            {
              flag3 = PolygonOperationContext.PointInPolygonAngle(point, polygon);
              intList[index4] = flag3 ? 1 : 0;
            }
            else
              flag3 = intList[index4] == 1;
            if (!flag3)
            {
              if (polygon == polygonOperationContext_0.Poly1)
              {
                polygon = polygonOperationContext_0.Poly2;
                intList = polygonOperationContext_0.Poly2VectorAngles;
                point2Dlist = polygonOperationContext_0.Poly1;
              }
              else
              {
                polygon = polygonOperationContext_0.Poly1;
                intList = polygonOperationContext_0.Poly1VectorAngles;
                point2Dlist = polygonOperationContext_0.Poly2;
              }
              index1 = index2;
              flag1 = true;
              break;
            }
          }
        }
      }
      index1 = flag1 ? polygon.NextIndex(index1) : polygon.PreviousIndex(index1);
    }
    while ((!polygon[index1].Equals(p) ? 0 : (subtract.Count <= polygonOperationContext_0.Poly1.Count + polygonOperationContext_0.Poly2.Count ? 1 : 0)) != 0);
    if (subtract.Count <= polygonOperationContext_0.Poly1.Count + polygonOperationContext_0.Poly2.Count)
      return;
    polygonOperationContext_0.Error = PolygonUtil.PolyUnionError.InfiniteLoop;
  }

  public static PolygonUtil.PolyUnionError PolygonOperation(
    PolygonUtil.PolyOperation operations,
    Point2DList polygon1,
    Point2DList polygon2,
    out Dictionary<uint, Point2DList> results)
  {
    PolygonOperationContext ctx = new PolygonOperationContext();
    ctx.Init(operations, polygon1, polygon2);
    results = ctx.Output;
    return PolygonUtil.PolygonOperation(ctx);
  }

  public static PolygonUtil.PolyUnionError PolygonOperation(PolygonOperationContext ctx)
  {
    if ((ctx.Operations & PolygonUtil.PolyOperation.Union) == PolygonUtil.PolyOperation.Union)
      PolygonUtil.smethod_0(ctx);
    if ((ctx.Operations & PolygonUtil.PolyOperation.Intersect) == PolygonUtil.PolyOperation.Intersect)
      PolygonUtil.smethod_1(ctx);
    if ((ctx.Operations & PolygonUtil.PolyOperation.Subtract) == PolygonUtil.PolyOperation.Subtract)
      PolygonUtil.smethod_2(ctx);
    return ctx.Error;
  }

  public static IEnumerable<Point2DList> SplitComplexPolygon(Point2DList verts, double epsilon)
  {
    int count1 = verts.Count;
    List<SplitComplexPolygonNode> list = verts.Select<Point2D, SplitComplexPolygonNode>((Func<Point2D, SplitComplexPolygonNode>) (point2D_0 => new SplitComplexPolygonNode(new Point2D(point2D_0.X, point2D_0.Y)))).ToList<SplitComplexPolygonNode>();
    for (int index1 = 0; index1 < verts.Count; ++index1)
    {
      int index2 = index1 == count1 - 1 ? 0 : index1 + 1;
      int index3 = index1 == 0 ? count1 - 1 : index1 - 1;
      list[index1].AddConnection(list[index2]);
      list[index1].AddConnection(list[index3]);
    }
    int count2 = list.Count;
    bool flag1 = true;
label_30:
    while (flag1)
    {
      flag1 = false;
      int index4 = 0;
      while (true)
      {
        if ((flag1 ? 0 : (index4 < count2 ? 1 : 0)) != 0)
        {
          for (int index5 = 0; (flag1 ? 0 : (index5 < list[index4].NumConnected ? 1 : 0)) != 0; ++index5)
          {
            for (int index6 = 0; (flag1 ? 0 : (index6 < count2 ? 1 : 0)) != 0; ++index6)
            {
              if ((index6 == index4 ? 1 : (list[index6] == list[index4][index5] ? 1 : 0)) == 0)
              {
                for (int index7 = 0; (flag1 ? 0 : (index7 < list[index6].NumConnected ? 1 : 0)) != 0; ++index7)
                {
                  if ((list[index6][index7] == list[index4][index5] ? 1 : (list[index6][index7] == list[index4] ? 1 : 0)) == 0)
                  {
                    Point2D pIntersectionPt = new Point2D();
                    if (TriangulationUtil.LinesIntersect2D(list[index4].Position, list[index4][index5].Position, list[index6].Position, list[index6][index7].Position, true, true, true, ref pIntersectionPt, epsilon))
                    {
                      flag1 = true;
                      SplitComplexPolygonNode toMe = new SplitComplexPolygonNode(pIntersectionPt);
                      int index8 = list.IndexOf(toMe);
                      if ((index8 < 0 ? 0 : (index8 < list.Count ? 1 : 0)) != 0)
                      {
                        toMe = list[index8];
                      }
                      else
                      {
                        list.Add(toMe);
                        count2 = list.Count;
                      }
                      SplitComplexPolygonNode complexPolygonNode1 = list[index4];
                      SplitComplexPolygonNode complexPolygonNode2 = list[index4][index5];
                      SplitComplexPolygonNode complexPolygonNode3 = list[index6];
                      SplitComplexPolygonNode complexPolygonNode4 = list[index6][index7];
                      complexPolygonNode2.RemoveConnection(complexPolygonNode1);
                      complexPolygonNode1.RemoveConnection(complexPolygonNode2);
                      complexPolygonNode4.RemoveConnection(complexPolygonNode3);
                      complexPolygonNode3.RemoveConnection(complexPolygonNode4);
                      if (!toMe.Position.Equals(complexPolygonNode1.Position, epsilon))
                      {
                        toMe.AddConnection(complexPolygonNode1);
                        complexPolygonNode1.AddConnection(toMe);
                      }
                      if (!toMe.Position.Equals(complexPolygonNode3.Position, epsilon))
                      {
                        toMe.AddConnection(complexPolygonNode3);
                        complexPolygonNode3.AddConnection(toMe);
                      }
                      if (!toMe.Position.Equals(complexPolygonNode2.Position, epsilon))
                      {
                        toMe.AddConnection(complexPolygonNode2);
                        complexPolygonNode2.AddConnection(toMe);
                      }
                      if (!toMe.Position.Equals(complexPolygonNode4.Position, epsilon))
                      {
                        toMe.AddConnection(complexPolygonNode4);
                        complexPolygonNode4.AddConnection(toMe);
                      }
                    }
                  }
                }
              }
            }
          }
          ++index4;
        }
        else
          goto label_30;
      }
    }
    bool flag2 = true;
    int num1 = count2;
    double num2 = epsilon * epsilon;
    while (flag2)
    {
      flag2 = false;
      for (int index9 = 0; index9 < count2; ++index9)
      {
        if (list[index9].NumConnected != 0)
        {
          for (int index10 = index9 + 1; index10 < count2; ++index10)
          {
            if (list[index10].NumConnected != 0 && (list[index9].Position - list[index10].Position).MagnitudeSquared() <= num2)
            {
              if (num1 <= 3)
                throw new Exception("Eliminated so many duplicate points that resulting polygon has < 3 vertices!");
              --num1;
              flag2 = true;
              SplitComplexPolygonNode toMe1 = list[index9];
              SplitComplexPolygonNode fromMe = list[index10];
              int numConnected = fromMe.NumConnected;
              for (int index11 = 0; index11 < numConnected; ++index11)
              {
                SplitComplexPolygonNode toMe2 = fromMe[index11];
                if (toMe2 != toMe1)
                {
                  toMe1.AddConnection(toMe2);
                  toMe2.AddConnection(toMe1);
                }
                toMe2.RemoveConnection(fromMe);
              }
              fromMe.ClearConnections();
              list.RemoveAt(index10);
              --count2;
            }
          }
        }
      }
    }
    double num3 = double.MaxValue;
    double num4 = double.MinValue;
    int index12 = -1;
    for (int index13 = 0; index13 < count2; ++index13)
    {
      if ((list[index13].Position.Y >= num3 ? 0 : (list[index13].NumConnected > 1 ? 1 : 0)) != 0)
      {
        num3 = list[index13].Position.Y;
        index12 = index13;
        num4 = list[index13].Position.X;
      }
      else if ((list[index13].Position.Y != num3 || list[index13].Position.X <= num4 ? 0 : (list[index13].NumConnected > 1 ? 1 : 0)) != 0)
      {
        index12 = index13;
        num4 = list[index13].Position.X;
      }
    }
    Point2D incomingDir = new Point2D(1.0, 0.0);
    List<Point2D> ienumerable_0 = new List<Point2D>();
    SplitComplexPolygonNode complexPolygonNode5 = list[index12];
    SplitComplexPolygonNode complexPolygonNode6 = complexPolygonNode5;
    SplitComplexPolygonNode rightestConnection = complexPolygonNode5.GetRightestConnection(incomingDir);
    if (rightestConnection == (SplitComplexPolygonNode) null)
      return Class30.smethod_16((IEnumerable<Point2D>) verts);
    ienumerable_0.Add(complexPolygonNode6.Position);
    while (rightestConnection != complexPolygonNode6)
    {
      if (ienumerable_0.Count > 4 * count2)
        throw new Exception("nodes should never be visited four times apiece (proof?), so we've probably hit a loop...crap");
      ienumerable_0.Add(rightestConnection.Position);
      SplitComplexPolygonNode incoming = complexPolygonNode5;
      complexPolygonNode5 = rightestConnection;
      rightestConnection = complexPolygonNode5.GetRightestConnection(incoming);
      if (rightestConnection == (SplitComplexPolygonNode) null)
        return Class30.smethod_16((IEnumerable<Point2D>) ienumerable_0);
    }
    return ienumerable_0.Count < 1 ? Class30.smethod_16((IEnumerable<Point2D>) verts) : Class30.smethod_16((IEnumerable<Point2D>) ienumerable_0);
  }

  public enum PolyUnionError
  {
    None,
    NoIntersections,
    Poly1InsidePoly2,
    InfiniteLoop,
  }

  [Flags]
  public enum PolyOperation : uint
  {
    None = 0,
    Union = 1,
    Intersect = 2,
    Subtract = 4,
  }
}
