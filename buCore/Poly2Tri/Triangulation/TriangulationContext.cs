// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.TriangulationContext
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Triangulation.Delaunay.Sweep;
using System.Collections.Generic;

#nullable disable
namespace Poly2Tri.Triangulation;

public abstract class TriangulationContext
{
  public readonly List<DelaunayTriangle> Triangles = new List<DelaunayTriangle>();
  public readonly List<TriangulationPoint> Points = new List<TriangulationPoint>(200);

  protected TriangulationDebugContext DebugContext { get; private set; }

  public bool IsDebugEnabled { get; protected set; }

  public TriangulationMode TriangulationMode { get; private set; }

  public ITriangulatable Triangulatable { get; private set; }

  public abstract TriangulationAlgorithm Algorithm { get; }

  protected TriangulationContext(TriangulationDebugContext debug) => this.DebugContext = debug;

  public virtual void PrepareTriangulation(ITriangulatable t)
  {
    this.Triangulatable = t;
    this.TriangulationMode = t.TriangulationMode;
    t.Prepare(this);
  }

  public abstract DTSweepConstraint NewConstraint(TriangulationPoint a, TriangulationPoint b);
}
