// Decompiled with JetBrains decompiler
// Type: Poly2Tri.P2T
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using Poly2Tri.Triangulation;
using System.Collections.Generic;

#nullable disable
namespace Poly2Tri;

public static class P2T
{
  public static void Triangulate(IEnumerable<Poly2Tri.Triangulation.Polygon.Polygon> polygons)
  {
    foreach (ITriangulatable polygon in polygons)
      P2T.Triangulate(polygon);
  }

  public static void Triangulate(ITriangulatable t, TriangulationAlgorithm algorithm = TriangulationAlgorithm.DTSweep)
  {
    TriangulationContext triangulationContext_0 = Class30.smethod_75(algorithm);
    triangulationContext_0.PrepareTriangulation(t);
    Class30.smethod_285(triangulationContext_0);
  }
}
