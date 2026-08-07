// Decompiled with JetBrains decompiler
// Type: buClass.PocketPoints
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class PocketPoints : buSerilization
{
  public List<List<Pnt3D>> Pockets = new List<List<Pnt3D>>();

  public PocketPoints()
  {
  }

  public PocketPoints(PocketPoints PocketPointspoints)
  {
    for (int index1 = 0; index1 <= PocketPointspoints.Pockets.Count - 1; ++index1)
    {
      List<Pnt3D> pnt3DList = new List<Pnt3D>();
      for (int index2 = 0; index2 <= PocketPointspoints.Pockets[index1].Count - 1; ++index2)
        pnt3DList.Add(new Pnt3D(PocketPointspoints.Pockets[index1][index2]));
      this.Pockets.Add(pnt3DList);
    }
  }

  public PocketPoints(List<List<Pnt3D>> points)
  {
    for (int index1 = 0; index1 <= points.Count - 1; ++index1)
    {
      List<Pnt3D> pnt3DList = new List<Pnt3D>();
      for (int index2 = 0; index2 <= points[index1].Count - 1; ++index2)
        pnt3DList.Add(new Pnt3D(points[index1][index2]));
      this.Pockets.Add(pnt3DList);
    }
  }

  public override string ToString() => "Pockets: " + this.Pockets.Count.ToString();
}
