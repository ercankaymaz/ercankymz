// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.EntitiesList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class EntitiesList : buSerilization5
{
  public bool isOutside;

  public static void Copy(List<Pnt3D> pts, ref List<Pnt6DSimMove> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add((Pnt6DSimMove) new PointAndAngleRange(pts[index]));
  }

  public static void Copy(List<List<Pnt6DSimMove>> pts, ref List<List<Pnt6DSimMove>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<Pnt6DSimMove> pnt6DsimMoveList1 = new List<Pnt6DSimMove>();
      List<Pnt6DSimMove> pnt6DsimMoveList2 = PointABC.Copy(pts[index]);
      CopiedPnt.Add(pnt6DsimMoveList2);
    }
  }

  public static void Copy(List<List<Pnt3D>> pts, ref List<List<Pnt6DSimMove>> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
    {
      List<Pnt6DSimMove> CopiedPnt1 = new List<Pnt6DSimMove>();
      EntitiesList.Copy(pts[index], ref CopiedPnt1);
      CopiedPnt.Add(CopiedPnt1);
    }
  }
}
