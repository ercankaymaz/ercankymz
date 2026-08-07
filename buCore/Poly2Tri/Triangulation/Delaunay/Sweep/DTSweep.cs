// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Delaunay.Sweep.DTSweep
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using System.Collections.Generic;

#nullable disable
namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public static class DTSweep
{
  public static void Triangulate(DTSweepContext tcx)
  {
    tcx.CreateAdvancingFront();
    DTSweep.smethod_0(tcx);
    DTSweep.smethod_1((TriangulationContext) tcx);
    if (tcx.TriangulationMode == TriangulationMode.Polygon)
    {
      Class30.smethod_24(tcx);
    }
    else
    {
      Class30.smethod_245(tcx);
      if (tcx.TriangulationMode == TriangulationMode.Constrained)
        tcx.FinalizeTriangulation();
      else
        tcx.FinalizeTriangulation();
    }
  }

  private static void smethod_0(DTSweepContext dtsweepContext_0)
  {
    List<TriangulationPoint> points = dtsweepContext_0.Points;
    for (int index = 1; index < points.Count; ++index)
    {
      TriangulationPoint triangulationPoint_0 = points[index];
      AdvancingFrontNode advancingFrontNode_0 = Class30.smethod_201(dtsweepContext_0, triangulationPoint_0);
      if (index != 295)
        ;
      if ((advancingFrontNode_0 == null ? 0 : (triangulationPoint_0.HasEdges ? 1 : 0)) != 0)
      {
        foreach (DTSweepConstraint edge in triangulationPoint_0.Edges)
        {
          if (dtsweepContext_0.IsDebugEnabled)
            dtsweepContext_0.DebugContext.ActiveConstraint = edge;
          Class30.smethod_135(dtsweepContext_0, edge, advancingFrontNode_0);
        }
      }
    }
  }

  private static void smethod_1(TriangulationContext triangulationContext_0)
  {
    foreach (DelaunayTriangle triangle in triangulationContext_0.Triangles)
    {
      for (int index = 0; index < 3; ++index)
      {
        if (!triangle.GetConstrainedEdgeCCW(triangle.Points[index]) && triangle.GetEdgeCCW(triangle.Points[index], out DTSweepConstraint _))
          triangle.MarkConstrainedEdge((index + 2) % 3);
      }
    }
  }
}
