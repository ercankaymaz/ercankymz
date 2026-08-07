// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.ITriangulatable
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using Poly2Tri.Triangulation.Delaunay;
using Poly2Tri.Utility;
using System.Collections.Generic;

#nullable disable
namespace Poly2Tri.Triangulation;

public interface ITriangulatable
{
  IList<DelaunayTriangle> Triangles { get; }

  TriangulationMode TriangulationMode { get; }

  bool DisplayFlipX { get; set; }

  bool DisplayFlipY { get; set; }

  float DisplayRotate { get; set; }

  double Precision { get; set; }

  double MinX { get; }

  double MaxX { get; }

  double MinY { get; }

  double MaxY { get; }

  Rect2D Bounds { get; }

  void Prepare(TriangulationContext tcx);

  void AddTriangle(DelaunayTriangle t);

  void AddTriangles(IEnumerable<DelaunayTriangle> list);

  void ClearTriangles();
}
