// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Edge
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using Poly2Tri.Utility;

#nullable disable
namespace Poly2Tri.Triangulation;

public class Edge
{
  public Point2D EdgeStart { get; set; }

  public Point2D EdgeEnd { get; set; }

  public Edge()
  {
    this.EdgeStart = (Point2D) null;
    this.EdgeEnd = (Point2D) null;
  }

  public Edge(Point2D edgeStart, Point2D edgeEnd)
  {
    this.EdgeStart = edgeStart;
    this.EdgeEnd = edgeEnd;
  }
}
