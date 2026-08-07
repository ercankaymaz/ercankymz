// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Polygon.EdgeIntersectInfo
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using Poly2Tri.Utility;

#nullable disable
namespace Poly2Tri.Triangulation.Polygon;

public class EdgeIntersectInfo
{
  public EdgeIntersectInfo(Edge edgeOne, Edge edgeTwo, Point2D intersectionPoint)
  {
    this.EdgeOne = edgeOne;
    this.EdgeTwo = edgeTwo;
    this.IntersectionPoint = intersectionPoint;
  }

  public Edge EdgeOne { get; private set; }

  public Edge EdgeTwo { get; private set; }

  public Point2D IntersectionPoint { get; private set; }
}
