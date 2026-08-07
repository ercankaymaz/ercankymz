// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Util.PolygonGenerator
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using Poly2Tri.Triangulation.Polygon;
using System;

#nullable disable
namespace Poly2Tri.Triangulation.Util;

public class PolygonGenerator
{
  private static readonly Random random_0 = new Random();

  public static Poly2Tri.Triangulation.Polygon.Polygon RandomCircleSweep(
    double scale,
    int vertexCount)
  {
    double num1 = scale / 4.0;
    PolygonPoint[] polygonPointArray = new PolygonPoint[vertexCount];
    for (int index = 0; index < vertexCount; ++index)
    {
      do
      {
        double num2 = index % 250 != 0 ? (index % 50 != 0 ? num1 + 25.0 * scale / (double) vertexCount * (0.5 - PolygonGenerator.random_0.NextDouble()) : num1 + scale / 5.0 * (0.5 - PolygonGenerator.random_0.NextDouble())) : num1 + scale / 2.0 * (0.5 - PolygonGenerator.random_0.NextDouble());
        double num3 = num2 > scale / 2.0 ? scale / 2.0 : num2;
        num1 = num3 < scale / 10.0 ? scale / 10.0 : num3;
      }
      while ((num1 < scale / 10.0 ? 1 : (num1 > scale / 2.0 ? 1 : 0)) != 0);
      PolygonPoint polygonPoint = new PolygonPoint(num1 * Math.Cos(2.0 * Math.PI * (double) index / (double) vertexCount), num1 * Math.Sin(2.0 * Math.PI * (double) index / (double) vertexCount));
      polygonPointArray[index] = polygonPoint;
    }
    return new Poly2Tri.Triangulation.Polygon.Polygon(polygonPointArray);
  }

  public static Poly2Tri.Triangulation.Polygon.Polygon RandomCircleSweep2(
    double scale,
    int vertexCount)
  {
    double num1 = scale / 4.0;
    PolygonPoint[] polygonPointArray = new PolygonPoint[vertexCount];
    for (int index = 0; index < vertexCount; ++index)
    {
      do
      {
        double num2 = num1 + scale / 5.0 * (0.5 - PolygonGenerator.random_0.NextDouble());
        double num3 = num2 > scale / 2.0 ? scale / 2.0 : num2;
        num1 = num3 < scale / 10.0 ? scale / 10.0 : num3;
      }
      while ((num1 < scale / 10.0 ? 1 : (num1 > scale / 2.0 ? 1 : 0)) != 0);
      PolygonPoint polygonPoint = new PolygonPoint(num1 * Math.Cos(2.0 * Math.PI * (double) index / (double) vertexCount), num1 * Math.Sin(2.0 * Math.PI * (double) index / (double) vertexCount));
      polygonPointArray[index] = polygonPoint;
    }
    return new Poly2Tri.Triangulation.Polygon.Polygon(polygonPointArray);
  }
}
