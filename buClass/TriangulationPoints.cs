// Decompiled with JetBrains decompiler
// Type: buClass.TriangulationPoints
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class TriangulationPoints : buSerilization
{
  public List<Pnt3D> Points = new List<Pnt3D>();
  public List<Triangle3D> Triangles = new List<Triangle3D>();
  public List<List<Pnt3D>> Holes = new List<List<Pnt3D>>();

  public TriangulationPoints()
  {
  }

  public TriangulationPoints(TriangulationPoints triangulationpoints)
  {
    triangulationpoints.Points = new List<Pnt3D>();
    for (int index = 0; index <= triangulationpoints.Points.Count - 1; ++index)
      this.Points.Add(new Pnt3D(triangulationpoints.Points[index]));
    triangulationpoints.Holes = new List<List<Pnt3D>>();
    for (int index1 = 0; index1 <= triangulationpoints.Holes.Count - 1; ++index1)
    {
      List<Pnt3D> pnt3DList = new List<Pnt3D>();
      for (int index2 = 0; index2 <= triangulationpoints.Holes[index1].Count - 1; ++index2)
        pnt3DList.Add(new Pnt3D(triangulationpoints.Holes[index1][index2]));
      this.Holes.Add(pnt3DList);
    }
    triangulationpoints.Triangles = new List<Triangle3D>();
    for (int index = 0; index <= triangulationpoints.Triangles.Count - 1; ++index)
      this.Triangles.Add(new Triangle3D(triangulationpoints.Triangles[index]));
  }
}
