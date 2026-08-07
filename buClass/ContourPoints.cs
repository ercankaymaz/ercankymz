// Decompiled with JetBrains decompiler
// Type: buClass.ContourPoints
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class ContourPoints : buSerilization
{
  public List<Pnt3D> Outter = new List<Pnt3D>();
  public List<List<Pnt3D>> Holes = new List<List<Pnt3D>>();

  public ContourPoints()
  {
  }

  public ContourPoints(ContourPoints contourpoints)
  {
    for (int index = 0; index <= contourpoints.Outter.Count - 1; ++index)
      this.Outter.Add(new Pnt3D(contourpoints.Outter[index]));
    for (int index1 = 0; index1 <= contourpoints.Holes.Count - 1; ++index1)
    {
      List<Pnt3D> pnt3DList = new List<Pnt3D>();
      for (int index2 = 0; index2 <= contourpoints.Holes[index1].Count - 1; ++index2)
        pnt3DList.Add(new Pnt3D(contourpoints.Holes[index1][index2]));
      this.Holes.Add(pnt3DList);
    }
  }

  public ContourPoints(TriangulationPoints tiranglepoints)
  {
    for (int index = 0; index <= tiranglepoints.Points.Count - 1; ++index)
      this.Outter.Add(new Pnt3D(tiranglepoints.Points[index]));
    for (int index1 = 0; index1 <= tiranglepoints.Holes.Count - 1; ++index1)
    {
      List<Pnt3D> pnt3DList = new List<Pnt3D>();
      for (int index2 = 0; index2 <= tiranglepoints.Holes[index1].Count - 1; ++index2)
        pnt3DList.Add(new Pnt3D(tiranglepoints.Holes[index1][index2]));
      this.Holes.Add(pnt3DList);
    }
  }

  public ContourPoints(List<Pnt3D> outter, List<List<Pnt3D>> holes)
  {
    for (int index = 0; index <= outter.Count - 1; ++index)
      this.Outter.Add(new Pnt3D(outter[index]));
    for (int index1 = 0; index1 <= holes.Count - 1; ++index1)
    {
      List<Pnt3D> pnt3DList = new List<Pnt3D>();
      for (int index2 = 0; index2 <= holes[index1].Count - 1; ++index2)
        pnt3DList.Add(new Pnt3D(holes[index1][index2]));
      this.Holes.Add(pnt3DList);
    }
  }

  public ContourPoints(List<Pnt3D> outter)
  {
    for (int index = 0; index <= outter.Count - 1; ++index)
      this.Outter.Add(new Pnt3D(outter[index]));
    this.Holes = new List<List<Pnt3D>>();
  }

  public override string ToString()
  {
    int count = this.Outter.Count;
    string str1 = count.ToString();
    count = this.Holes.Count;
    string str2 = count.ToString();
    return $"Out Count: {str1} - Hole Count: {str2}";
  }
}
