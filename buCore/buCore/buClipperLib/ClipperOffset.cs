// Decompiled with JetBrains decompiler
// Type: buCore.buClipperLib.ClipperOffset
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using System.Collections.Generic;

#nullable disable
namespace buCore.buClipperLib;

public class ClipperOffset
{
  private static string string_0 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";
  private static string string_1 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";
  internal List<List<IntPoint>> list_0;
  internal List<IntPoint> list_1;
  internal List<IntPoint> list_2;
  internal List<DoublePoint> list_3 = new List<DoublePoint>();
  internal double double_0;
  internal double double_1;
  internal double double_2;
  internal double double_3;
  internal double double_4;
  internal double double_5;
  internal IntPoint intPoint_0;
  internal PolyNode polyNode_0 = new PolyNode();

  public double ArcTolerance { get; set; }

  public double MiterLimit { get; set; }

  public ClipperOffset(double miterLimit = 2.0, double arcTolerance = 0.25)
  {
    this.MiterLimit = miterLimit;
    this.ArcTolerance = arcTolerance;
    this.intPoint_0.X = -1L;
  }

  public void Clear()
  {
    this.polyNode_0.Childs.Clear();
    this.intPoint_0.X = -1L;
  }

  public void AddPath(List<IntPoint> path, JoinType joinType, EndType endType)
  {
    int index1 = path.Count - 1;
    if (index1 < 0)
      return;
    PolyNode polyNode_1 = new PolyNode();
    polyNode_1.joinType_0 = joinType;
    polyNode_1.endType_0 = endType;
    if ((endType == EndType.etClosedLine ? 1 : (endType == EndType.etClosedPolygon ? 1 : 0)) != 0)
    {
      while ((index1 <= 0 ? 0 : (path[0] == path[index1] ? 1 : 0)) != 0)
        --index1;
    }
    polyNode_1.list_0.Capacity = index1 + 1;
    polyNode_1.list_0.Add(path[0]);
    int index2 = 0;
    int num = 0;
    for (int index3 = 1; index3 <= index1; ++index3)
    {
      if (polyNode_1.list_0[index2] != path[index3])
      {
        ++index2;
        polyNode_1.list_0.Add(path[index3]);
        if ((path[index3].Y > polyNode_1.list_0[num].Y ? 1 : (path[index3].Y != polyNode_1.list_0[num].Y ? 0 : (path[index3].X < polyNode_1.list_0[num].X ? 1 : 0))) != 0)
          num = index2;
      }
    }
    if ((endType != EndType.etClosedPolygon ? 0 : (index2 < 2 ? 1 : 0)) != 0)
      return;
    Class30.smethod_212(this.polyNode_0, polyNode_1);
    if (endType != 0)
      return;
    if (this.intPoint_0.X < 0L)
    {
      this.intPoint_0 = new IntPoint((long) (this.polyNode_0.ChildCount - 1), (long) num);
    }
    else
    {
      IntPoint intPoint = this.polyNode_0.Childs[(int) this.intPoint_0.X].list_0[(int) this.intPoint_0.Y];
      if ((polyNode_1.list_0[num].Y > intPoint.Y ? 1 : (polyNode_1.list_0[num].Y != intPoint.Y ? 0 : (polyNode_1.list_0[num].X < intPoint.X ? 1 : 0))) == 0)
        return;
      this.intPoint_0 = new IntPoint((long) (this.polyNode_0.ChildCount - 1), (long) num);
    }
  }

  public void AddPaths(List<List<IntPoint>> paths, JoinType joinType, EndType endType)
  {
    foreach (List<IntPoint> path in paths)
      this.AddPath(path, joinType, endType);
  }

  public void Execute(ref List<List<IntPoint>> solution, double delta)
  {
    solution.Clear();
    Class30.smethod_152(this);
    Class30.smethod_141(this, delta);
    buClipper buClipper = new buClipper();
    buClipper.AddPaths(this.list_0, PolyType.ptSubject, true);
    if (delta > 0.0)
    {
      buClipper.Execute(ClipType.ctUnion, solution, PolyFillType.pftPositive, PolyFillType.pftPositive);
    }
    else
    {
      IntRect bounds = buClipperBase.GetBounds(this.list_0);
      buClipper.AddPath(new List<IntPoint>(4)
      {
        new IntPoint(bounds.left - 10L, bounds.bottom + 10L),
        new IntPoint(bounds.right + 10L, bounds.bottom + 10L),
        new IntPoint(bounds.right + 10L, bounds.top - 10L),
        new IntPoint(bounds.left - 10L, bounds.top - 10L)
      }, PolyType.ptSubject, true);
      buClipper.ReverseSolution = true;
      buClipper.Execute(ClipType.ctUnion, solution, PolyFillType.pftNegative, PolyFillType.pftNegative);
      if (solution.Count <= 0)
        return;
      solution.RemoveAt(0);
    }
  }

  public void Execute(ref PolyTree solution, double delta)
  {
    solution.Clear();
    Class30.smethod_152(this);
    Class30.smethod_141(this, delta);
    buClipper buClipper = new buClipper();
    buClipper.AddPaths(this.list_0, PolyType.ptSubject, true);
    if (delta > 0.0)
    {
      buClipper.Execute(ClipType.ctUnion, solution, PolyFillType.pftPositive, PolyFillType.pftPositive);
    }
    else
    {
      IntRect bounds = buClipperBase.GetBounds(this.list_0);
      buClipper.AddPath(new List<IntPoint>(4)
      {
        new IntPoint(bounds.left - 10L, bounds.bottom + 10L),
        new IntPoint(bounds.right + 10L, bounds.bottom + 10L),
        new IntPoint(bounds.right + 10L, bounds.top - 10L),
        new IntPoint(bounds.left - 10L, bounds.top - 10L)
      }, PolyType.ptSubject, true);
      buClipper.ReverseSolution = true;
      buClipper.Execute(ClipType.ctUnion, solution, PolyFillType.pftNegative, PolyFillType.pftNegative);
      if ((solution.ChildCount != 1 ? 0 : (solution.Childs[0].ChildCount > 0 ? 1 : 0)) != 0)
      {
        PolyNode child = solution.Childs[0];
        solution.Childs.Capacity = child.ChildCount;
        solution.Childs[0] = child.Childs[0];
        solution.Childs[0].polyNode_0 = (PolyNode) solution;
        for (int index = 1; index < child.ChildCount; ++index)
          Class30.smethod_212((PolyNode) solution, child.Childs[index]);
      }
      else
        solution.Clear();
    }
  }
}
