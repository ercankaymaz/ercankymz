// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Delaunay.Sweep.DTSweepDebugContext
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

#nullable disable
namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class DTSweepDebugContext : TriangulationDebugContext
{
  public DelaunayTriangle PrimaryTriangle { get; set; }

  public DelaunayTriangle SecondaryTriangle { get; set; }

  public TriangulationPoint ActivePoint { get; set; }

  public AdvancingFrontNode ActiveNode { get; set; }

  public DTSweepConstraint ActiveConstraint { get; set; }

  public bool IsDebugContext => true;

  public override void Clear()
  {
    this.PrimaryTriangle = (DelaunayTriangle) null;
    this.SecondaryTriangle = (DelaunayTriangle) null;
    this.ActivePoint = (TriangulationPoint) null;
    this.ActiveNode = (AdvancingFrontNode) null;
    this.ActiveConstraint = (DTSweepConstraint) null;
  }
}
