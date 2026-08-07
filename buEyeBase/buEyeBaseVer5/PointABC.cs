// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.PointABC
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class PointABC : buSerilization5
{
  public bool isFirstEachSegment;
  public bool isLast;
  public bool isLastEachSegment;

  public static Pnt6DSimMove Copy(Pnt6DSimMove P) => (Pnt6DSimMove) new AlingmentPoints3D(P);

  public static Pnt6DSimMove[] Copy(Pnt6DSimMove[] pts)
  {
    Pnt6DSimMove[] pnt6DsimMoveArray = new Pnt6DSimMove[pts.Length];
    for (int index = 0; index < pts.Length; ++index)
      pnt6DsimMoveArray[index] = PointABC.Copy(pts[index]);
    return pnt6DsimMoveArray;
  }

  public static List<Pnt6DSimMove> Copy(List<Pnt6DSimMove> pts)
  {
    List<Pnt6DSimMove> pnt6DsimMoveList = new List<Pnt6DSimMove>();
    for (int index = 0; index < pts.Count; ++index)
      pnt6DsimMoveList.Add(PointABC.Copy(pts[index]));
    return pnt6DsimMoveList;
  }

  public static void Copy(List<Pnt6DSimMove> pts, ref List<Pnt6DSimMove> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add((Pnt6DSimMove) new AlingmentPoints3D(PointABC.Copy(pts[index])));
  }
}
