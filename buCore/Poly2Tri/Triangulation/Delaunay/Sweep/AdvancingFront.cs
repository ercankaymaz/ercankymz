// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Delaunay.Sweep.AdvancingFront
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using System;
using System.Text;

#nullable disable
namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class AdvancingFront
{
  public AdvancingFrontNode Head;
  public AdvancingFrontNode Tail;
  internal AdvancingFrontNode head;

  public AdvancingFront(AdvancingFrontNode head, AdvancingFrontNode tail)
  {
    this.Head = head;
    this.Tail = tail;
    this.head = head;
  }

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    for (AdvancingFrontNode advancingFrontNode = this.Head; advancingFrontNode != this.Tail; advancingFrontNode = advancingFrontNode.Next)
      stringBuilder.Append(advancingFrontNode.Point.X).Append("->");
    stringBuilder.Append(this.Tail.Point.X);
    return stringBuilder.ToString();
  }

  public AdvancingFrontNode LocateNode(TriangulationPoint point)
  {
    return Class30.smethod_175(this, point.X);
  }

  public AdvancingFrontNode LocatePoint(TriangulationPoint point)
  {
    double x1 = point.X;
    AdvancingFrontNode advancingFrontNode = this.head;
    double x2 = advancingFrontNode.Point.X;
    if (x1 == x2)
    {
      if (!point.Equals(advancingFrontNode.Point))
      {
        if (point.Equals(advancingFrontNode.Prev.Point))
        {
          advancingFrontNode = advancingFrontNode.Prev;
        }
        else
        {
          if (!point.Equals(advancingFrontNode.Next.Point))
            throw new Exception("Failed to find Node for given afront point");
          advancingFrontNode = advancingFrontNode.Next;
        }
      }
    }
    else if (x1 < x2)
    {
      while ((advancingFrontNode = advancingFrontNode.Prev) != null && !point.Equals(advancingFrontNode.Point))
        ;
    }
    else
    {
      while ((advancingFrontNode = advancingFrontNode.Next) != null && !point.Equals(advancingFrontNode.Point))
        ;
    }
    this.head = advancingFrontNode;
    return advancingFrontNode;
  }
}
