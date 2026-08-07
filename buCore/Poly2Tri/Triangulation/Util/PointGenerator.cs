// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Triangulation.Util.PointGenerator
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Poly2Tri.Triangulation.Util;

public class PointGenerator
{
  private static readonly Random random_0 = new Random();

  public static List<TriangulationPoint> UniformDistribution(int n, double scale)
  {
    List<TriangulationPoint> triangulationPointList = new List<TriangulationPoint>();
    for (int index = 0; index < n; ++index)
      triangulationPointList.Add(new TriangulationPoint(scale * (0.5 - PointGenerator.random_0.NextDouble()), scale * (0.5 - PointGenerator.random_0.NextDouble())));
    return triangulationPointList;
  }

  public static List<TriangulationPoint> UniformGrid(int n, double scale)
  {
    double num1 = scale / (double) n;
    double num2 = 0.5 * scale;
    List<TriangulationPoint> triangulationPointList = new List<TriangulationPoint>();
    for (int index1 = 0; index1 < n + 1; ++index1)
    {
      double x = num2 - (double) index1 * num1;
      for (int index2 = 0; index2 < n + 1; ++index2)
        triangulationPointList.Add(new TriangulationPoint(x, num2 - (double) index2 * num1));
    }
    return triangulationPointList;
  }
}
