// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Polygon.PolygonPoint
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

#nullable disable
namespace Poly2Tri.Triangulation.Polygon;

public class PolygonPoint(double x, double y) : TriangulationPoint(x, y)
{
  public PolygonPoint Next { get; set; }

  public PolygonPoint Previous { get; set; }
}
