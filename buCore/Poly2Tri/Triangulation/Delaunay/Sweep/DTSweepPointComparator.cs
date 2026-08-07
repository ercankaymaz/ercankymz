// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Delaunay.Sweep.DTSweepPointComparator
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System.Collections.Generic;

#nullable disable
namespace Poly2Tri.Triangulation.Delaunay.Sweep;

public class DTSweepPointComparator : IComparer<TriangulationPoint>
{
  public int Compare(TriangulationPoint p1, TriangulationPoint p2)
  {
    return p1.Y >= p2.Y ? (p1.Y <= p2.Y ? (p1.X >= p2.X ? (p1.X <= p2.X ? 0 : 1) : -1) : 1) : -1;
  }
}
