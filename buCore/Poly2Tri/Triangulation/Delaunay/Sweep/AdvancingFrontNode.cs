// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Delaunay.Sweep.AdvancingFrontNode
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

#nullable disable
namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class AdvancingFrontNode
{
  public AdvancingFrontNode Next;
  public AdvancingFrontNode Prev;
  public readonly double Value;
  public readonly TriangulationPoint Point;
  public DelaunayTriangle Triangle;

  public AdvancingFrontNode(TriangulationPoint point)
  {
    this.Point = point;
    this.Value = point.X;
  }

  public bool HasNext => this.Next != null;

  public bool HasPrev => this.Prev != null;
}
