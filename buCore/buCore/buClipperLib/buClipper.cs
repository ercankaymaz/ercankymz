// Decompiled with JetBrains decompiler
// Type: buCore.buClipperLib.buClipper
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns1;
using ns10;
using ns2;
using ns3;
using ns6;
using ns7;
using ns9;
using System.Collections.Generic;

#nullable disable
namespace buCore.buClipperLib;

public class buClipper : buClipperBase
{
  private static string string_0 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";
  private static string string_1 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";
  public const int ioReverseSolution = 1;
  public const int ioStrictlySimple = 2;
  public const int ioPreserveCollinear = 4;
  internal ClipType clipType_0;
  internal Class25 class25_0;
  internal Class22 class22_1;
  internal List<IntersectNode> list_2;
  internal IComparer<IntersectNode> icomparer_0;
  private bool bool_3;
  internal PolyFillType polyFillType_0;
  internal PolyFillType polyFillType_1;
  internal List<Class28> list_3;
  internal List<Class28> list_4;
  internal bool bool_4;

  public buClipper.ZFillCallback ZFillFunction { get; set; }

  public buClipper(int InitOptions = 0)
  {
    this.class24_0 = (Class24) null;
    this.class25_0 = (Class25) null;
    this.class22_0 = (Class22) null;
    this.class22_1 = (Class22) null;
    this.list_2 = new List<IntersectNode>();
    this.icomparer_0 = (IComparer<IntersectNode>) new MyIntersectNodeSort();
    this.bool_3 = false;
    this.bool_4 = false;
    this.list_1 = new List<Class26>();
    this.list_3 = new List<Class28>();
    this.list_4 = new List<Class28>();
    this.ReverseSolution = (1 & InitOptions) != 0;
    this.StrictlySimple = (2 & InitOptions) != 0;
    this.PreserveCollinear = (4 & InitOptions) != 0;
    this.ZFillFunction = (buClipper.ZFillCallback) null;
  }

  public bool ReverseSolution { get; set; }

  public bool StrictlySimple { get; set; }

  public bool Execute(ClipType clipType, List<List<IntPoint>> solution, PolyFillType FillType = PolyFillType.pftEvenOdd)
  {
    return this.Execute(clipType, solution, FillType, FillType);
  }

  public bool Execute(ClipType clipType, PolyTree polytree, PolyFillType FillType = PolyFillType.pftEvenOdd)
  {
    return this.Execute(clipType, polytree, FillType, FillType);
  }

  public bool Execute(
    ClipType clipType,
    List<List<IntPoint>> solution,
    PolyFillType subjFillType,
    PolyFillType clipFillType)
  {
    bool flag1;
    if (this.bool_3)
    {
      flag1 = false;
    }
    else
    {
      if (this.bool_1)
        throw new Exception0("Error: PolyTree struct is needed for open path clipping.");
      this.bool_3 = true;
      solution.Clear();
      this.polyFillType_1 = subjFillType;
      this.polyFillType_0 = clipFillType;
      this.clipType_0 = clipType;
      this.bool_4 = false;
      bool flag2;
      try
      {
        if (flag2 = this.method_0())
          Class30.smethod_118(this, solution);
      }
      finally
      {
        Class30.smethod_133(this);
        this.bool_3 = false;
      }
      flag1 = flag2;
    }
    return flag1;
  }

  public bool Execute(
    ClipType clipType,
    PolyTree polytree,
    PolyFillType subjFillType,
    PolyFillType clipFillType)
  {
    bool flag1;
    if (this.bool_3)
    {
      flag1 = false;
    }
    else
    {
      this.bool_3 = true;
      this.polyFillType_1 = subjFillType;
      this.polyFillType_0 = clipFillType;
      this.clipType_0 = clipType;
      this.bool_4 = true;
      bool flag2;
      try
      {
        if (flag2 = this.method_0())
          Class30.smethod_145(polytree, this);
      }
      finally
      {
        Class30.smethod_133(this);
        this.bool_3 = false;
      }
      flag1 = flag2;
    }
    return flag1;
  }

  private bool method_0()
  {
    try
    {
      this.vmethod_0();
      this.class22_1 = (Class22) null;
      this.class25_0 = (Class25) null;
      long long_0_1;
      if (!Class30.smethod_54((buClipperBase) this, ref long_0_1))
        return false;
      Class30.smethod_159(this, long_0_1);
      long long_0_2;
      while ((Class30.smethod_54((buClipperBase) this, ref long_0_2) ? 1 : (Class30.smethod_17((buClipperBase) this) ? 1 : 0)) != 0)
      {
        Class30.smethod_163(this);
        this.list_4.Clear();
        if (!Class30.smethod_203(long_0_2, this))
          return false;
        Class30.smethod_95(this, long_0_2);
        long_0_1 = long_0_2;
        Class30.smethod_159(this, long_0_1);
      }
      foreach (Class26 class26_0 in this.list_1)
      {
        if ((class26_0.class27_0 == null ? 1 : (class26_0.bool_1 ? 1 : 0)) == 0 && (class26_0.bool_0 ^ this.ReverseSolution) == Class30.smethod_142(this, class26_0) > 0.0)
          Class30.smethod_242(class26_0.class27_0, this);
      }
      Class30.smethod_60(this);
      foreach (Class26 class26_0 in this.list_1)
      {
        if (class26_0.class27_0 != null)
        {
          if (class26_0.bool_1)
            Class30.smethod_2(this, class26_0);
          else
            Class30.smethod_90(this, class26_0);
        }
      }
      if (this.StrictlySimple)
        Class30.smethod_155(this);
      return true;
    }
    finally
    {
      this.list_3.Clear();
      this.list_4.Clear();
    }
  }

  public static void ReversePaths(List<List<IntPoint>> polys)
  {
    foreach (List<IntPoint> poly in polys)
      poly.Reverse();
  }

  public static bool Orientation(List<IntPoint> poly) => buClipper.Area(poly) >= 0.0;

  public static int PointInPolygon(IntPoint pt, List<IntPoint> path)
  {
    int num1 = 0;
    int count = path.Count;
    int num2;
    if (count < 3)
    {
      num2 = 0;
    }
    else
    {
      IntPoint intPoint1 = path[0];
      for (int index = 1; index <= count; ++index)
      {
        IntPoint intPoint2 = index == count ? path[0] : path[index];
        if (intPoint2.Y != pt.Y || (intPoint2.X == pt.X ? 1 : (intPoint1.Y != pt.Y ? 0 : (intPoint2.X > pt.X == intPoint1.X < pt.X ? 1 : 0))) == 0)
        {
          if (intPoint1.Y < pt.Y != intPoint2.Y < pt.Y)
          {
            if (intPoint1.X >= pt.X)
            {
              if (intPoint2.X > pt.X)
              {
                num1 = 1 - num1;
              }
              else
              {
                double num3 = (double) (intPoint1.X - pt.X) * (double) (intPoint2.Y - pt.Y) - (double) (intPoint2.X - pt.X) * (double) (intPoint1.Y - pt.Y);
                if (num3 != 0.0)
                {
                  if (num3 > 0.0 == intPoint2.Y > intPoint1.Y)
                    num1 = 1 - num1;
                }
                else
                {
                  num2 = -1;
                  goto label_21;
                }
              }
            }
            else if (intPoint2.X > pt.X)
            {
              double num4 = (double) (intPoint1.X - pt.X) * (double) (intPoint2.Y - pt.Y) - (double) (intPoint2.X - pt.X) * (double) (intPoint1.Y - pt.Y);
              if (num4 != 0.0)
              {
                if (num4 > 0.0 == intPoint2.Y > intPoint1.Y)
                  num1 = 1 - num1;
              }
              else
              {
                num2 = -1;
                goto label_21;
              }
            }
          }
          intPoint1 = intPoint2;
        }
        else
        {
          num2 = -1;
          goto label_21;
        }
      }
      num2 = num1;
    }
label_21:
    return num2;
  }

  internal void method_1(Class26 class26_0, Class26 class26_1)
  {
    foreach (Class26 class26_2 in this.list_1)
    {
      Class26 class26_3 = Class30.smethod_281(class26_2.class26_0);
      if ((class26_2.class27_0 == null ? 0 : (class26_3 == class26_0 ? 1 : 0)) != 0 && Class30.smethod_167(class26_2.class27_0, class26_1.class27_0))
        class26_2.class26_0 = class26_1;
    }
  }

  internal void method_2(Class26 class26_0, Class26 class26_1)
  {
    Class26 class260 = class26_1.class26_0;
    foreach (Class26 class26_2 in this.list_1)
    {
      if ((class26_2.class27_0 == null || class26_2 == class26_1 ? 1 : (class26_2 == class26_0 ? 1 : 0)) == 0)
      {
        Class26 class26_3 = Class30.smethod_281(class26_2.class26_0);
        if ((class26_3 == class260 || class26_3 == class26_0 ? 0 : (class26_3 != class26_1 ? 1 : 0)) == 0)
        {
          if (Class30.smethod_167(class26_2.class27_0, class26_0.class27_0))
            class26_2.class26_0 = class26_0;
          else if (Class30.smethod_167(class26_2.class27_0, class26_1.class27_0))
            class26_2.class26_0 = class26_1;
          else if ((class26_2.class26_0 == class26_0 ? 1 : (class26_2.class26_0 == class26_1 ? 1 : 0)) != 0)
            class26_2.class26_0 = class260;
        }
      }
    }
  }

  internal void method_3(Class26 class26_0, Class26 class26_1)
  {
    foreach (Class26 class26_2 in this.list_1)
    {
      Class26 class26_3 = Class30.smethod_281(class26_2.class26_0);
      if ((class26_2.class27_0 == null ? 0 : (class26_3 == class26_0 ? 1 : 0)) != 0)
        class26_2.class26_0 = class26_1;
    }
  }

  public static double Area(List<IntPoint> poly)
  {
    int count = poly.Count;
    double num1;
    if (count < 3)
    {
      num1 = 0.0;
    }
    else
    {
      double num2 = 0.0;
      int index1 = 0;
      int index2 = count - 1;
      for (; index1 < count; ++index1)
      {
        num2 += ((double) poly[index2].X + (double) poly[index1].X) * ((double) poly[index2].Y - (double) poly[index1].Y);
        index2 = index1;
      }
      num1 = -num2 * 0.5;
    }
    return num1;
  }

  public static List<List<IntPoint>> SimplifyPolygon(List<IntPoint> poly, PolyFillType fillType = PolyFillType.pftEvenOdd)
  {
    List<List<IntPoint>> solution = new List<List<IntPoint>>();
    buClipper buClipper = new buClipper();
    buClipper.StrictlySimple = true;
    buClipper.AddPath(poly, PolyType.ptSubject, true);
    buClipper.Execute(ClipType.ctUnion, solution, fillType, fillType);
    return solution;
  }

  public static List<List<IntPoint>> SimplifyPolygons(
    List<List<IntPoint>> polys,
    PolyFillType fillType = PolyFillType.pftEvenOdd)
  {
    List<List<IntPoint>> solution = new List<List<IntPoint>>();
    buClipper buClipper = new buClipper();
    buClipper.StrictlySimple = true;
    buClipper.AddPaths(polys, PolyType.ptSubject, true);
    buClipper.Execute(ClipType.ctUnion, solution, fillType, fillType);
    return solution;
  }

  public static List<IntPoint> CleanPolygon(List<IntPoint> path, double distance = 1.415)
  {
    int capacity = path.Count;
    List<IntPoint> intPointList1;
    if (capacity == 0)
    {
      intPointList1 = new List<IntPoint>();
    }
    else
    {
      Class27[] class27Array = new Class27[capacity];
      for (int index = 0; index < capacity; ++index)
        class27Array[index] = new Class27();
      for (int index = 0; index < capacity; ++index)
      {
        class27Array[index].intPoint_0 = path[index];
        class27Array[index].class27_0 = class27Array[(index + 1) % capacity];
        class27Array[index].class27_0.class27_1 = class27Array[index];
        class27Array[index].int_0 = 0;
      }
      double double_0 = distance * distance;
      Class27 class27_0 = class27Array[0];
      while ((class27_0.int_0 != 0 ? 0 : (class27_0.class27_0 != class27_0.class27_1 ? 1 : 0)) != 0)
      {
        if (Class30.smethod_196(class27_0.intPoint_0, class27_0.class27_1.intPoint_0, double_0))
        {
          class27_0 = Class30.smethod_247(class27_0);
          --capacity;
        }
        else if (Class30.smethod_196(class27_0.class27_1.intPoint_0, class27_0.class27_0.intPoint_0, double_0))
        {
          Class30.smethod_247(class27_0.class27_0);
          class27_0 = Class30.smethod_247(class27_0);
          capacity -= 2;
        }
        else if (Class30.smethod_23(class27_0.class27_1.intPoint_0, class27_0.intPoint_0, class27_0.class27_0.intPoint_0, double_0))
        {
          class27_0 = Class30.smethod_247(class27_0);
          --capacity;
        }
        else
        {
          class27_0.int_0 = 1;
          class27_0 = class27_0.class27_0;
        }
      }
      if (capacity < 3)
        capacity = 0;
      List<IntPoint> intPointList2 = new List<IntPoint>(capacity);
      for (int index = 0; index < capacity; ++index)
      {
        intPointList2.Add(class27_0.intPoint_0);
        class27_0 = class27_0.class27_0;
      }
      intPointList1 = intPointList2;
    }
    return intPointList1;
  }

  public static List<List<IntPoint>> CleanPolygons(List<List<IntPoint>> polys, double distance = 1.415)
  {
    List<List<IntPoint>> intPointListList = new List<List<IntPoint>>(polys.Count);
    for (int index = 0; index < polys.Count; ++index)
      intPointListList.Add(buClipper.CleanPolygon(polys[index], distance));
    return intPointListList;
  }

  internal static List<List<IntPoint>> smethod_0(
    List<IntPoint> list_5,
    List<IntPoint> list_6,
    bool bool_7,
    bool bool_8)
  {
    int num = bool_8 ? 1 : 0;
    int count1 = list_5.Count;
    int count2 = list_6.Count;
    List<List<IntPoint>> intPointListList1 = new List<List<IntPoint>>(count2);
    if (bool_7)
    {
      for (int index = 0; index < count2; ++index)
      {
        List<IntPoint> intPointList = new List<IntPoint>(count1);
        foreach (IntPoint intPoint in list_5)
          intPointList.Add(new IntPoint(list_6[index].X + intPoint.X, list_6[index].Y + intPoint.Y));
        intPointListList1.Add(intPointList);
      }
    }
    else
    {
      for (int index = 0; index < count2; ++index)
      {
        List<IntPoint> intPointList = new List<IntPoint>(count1);
        foreach (IntPoint intPoint in list_5)
          intPointList.Add(new IntPoint(list_6[index].X - intPoint.X, list_6[index].Y - intPoint.Y));
        intPointListList1.Add(intPointList);
      }
    }
    List<List<IntPoint>> intPointListList2 = new List<List<IntPoint>>((count2 + num) * (count1 + 1));
    for (int index1 = 0; index1 < count2 - 1 + num; ++index1)
    {
      for (int index2 = 0; index2 < count1; ++index2)
      {
        List<IntPoint> poly = new List<IntPoint>(4);
        poly.Add(intPointListList1[index1 % count2][index2 % count1]);
        poly.Add(intPointListList1[(index1 + 1) % count2][index2 % count1]);
        poly.Add(intPointListList1[(index1 + 1) % count2][(index2 + 1) % count1]);
        poly.Add(intPointListList1[index1 % count2][(index2 + 1) % count1]);
        if (!buClipper.Orientation(poly))
          poly.Reverse();
        intPointListList2.Add(poly);
      }
    }
    return intPointListList2;
  }

  public static List<List<IntPoint>> MinkowskiSum(
    List<IntPoint> pattern,
    List<IntPoint> path,
    bool pathIsClosed)
  {
    List<List<IntPoint>> intPointListList = buClipper.smethod_0(pattern, path, true, pathIsClosed);
    buClipper buClipper = new buClipper();
    buClipper.AddPaths(intPointListList, PolyType.ptSubject, true);
    buClipper.Execute(ClipType.ctUnion, intPointListList, PolyFillType.pftNonZero, PolyFillType.pftNonZero);
    return intPointListList;
  }

  public static List<List<IntPoint>> MinkowskiSum(
    List<IntPoint> pattern,
    List<List<IntPoint>> paths,
    bool pathIsClosed)
  {
    List<List<IntPoint>> solution = new List<List<IntPoint>>();
    buClipper buClipper = new buClipper();
    for (int index = 0; index < paths.Count; ++index)
    {
      List<List<IntPoint>> ppg = buClipper.smethod_0(pattern, paths[index], true, pathIsClosed);
      buClipper.AddPaths(ppg, PolyType.ptSubject, true);
      if (pathIsClosed)
      {
        List<IntPoint> path = paths[index];
        List<IntPoint> pg = Class30.smethod_261(pattern[0], path);
        buClipper.AddPath(pg, PolyType.ptClip, true);
      }
    }
    buClipper.Execute(ClipType.ctUnion, solution, PolyFillType.pftNonZero, PolyFillType.pftNonZero);
    return solution;
  }

  public static List<List<IntPoint>> MinkowskiDiff(List<IntPoint> poly1, List<IntPoint> poly2)
  {
    List<List<IntPoint>> intPointListList = buClipper.smethod_0(poly1, poly2, false, true);
    buClipper buClipper = new buClipper();
    buClipper.AddPaths(intPointListList, PolyType.ptSubject, true);
    buClipper.Execute(ClipType.ctUnion, intPointListList, PolyFillType.pftNonZero, PolyFillType.pftNonZero);
    return intPointListList;
  }

  public static List<List<IntPoint>> PolyTreeToPaths(PolyTree polytree)
  {
    List<List<IntPoint>> list_5 = new List<List<IntPoint>>();
    list_5.Capacity = polytree.Total;
    buClipper.smethod_1((PolyNode) polytree, buClipper.Enum4.const_0, list_5);
    return list_5;
  }

  internal static void smethod_1(
    PolyNode polyNode_0,
    buClipper.Enum4 enum4_0,
    List<List<IntPoint>> list_5)
  {
    bool flag = true;
    switch (enum4_0)
    {
      case buClipper.Enum4.const_1:
        return;
      case buClipper.Enum4.const_2:
        flag = !polyNode_0.IsOpen;
        break;
    }
    if (polyNode_0.list_0.Count > 0 & flag)
      list_5.Add(polyNode_0.list_0);
    foreach (PolyNode child in polyNode_0.Childs)
      buClipper.smethod_1(child, enum4_0, list_5);
  }

  public static List<List<IntPoint>> OpenPathsFromPolyTree(PolyTree polytree)
  {
    List<List<IntPoint>> intPointListList = new List<List<IntPoint>>();
    intPointListList.Capacity = polytree.ChildCount;
    for (int index = 0; index < polytree.ChildCount; ++index)
    {
      if (polytree.Childs[index].IsOpen)
        intPointListList.Add(polytree.Childs[index].list_0);
    }
    return intPointListList;
  }

  public static List<List<IntPoint>> ClosedPathsFromPolyTree(PolyTree polytree)
  {
    List<List<IntPoint>> list_5 = new List<List<IntPoint>>();
    list_5.Capacity = polytree.Total;
    buClipper.smethod_1((PolyNode) polytree, buClipper.Enum4.const_2, list_5);
    return list_5;
  }

  public delegate void ZFillCallback(
    IntPoint bot1,
    IntPoint top1,
    IntPoint bot2,
    IntPoint top2,
    ref IntPoint pt);

  internal enum Enum4
  {
    const_0,
    const_1,
    const_2,
  }
}
