// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ContourPoints5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ContourPoints5 : buSerilization5
{
  public bool isInside;
  public bool CheckIsClosedContour;

  public static void Copy(
    List<Pnt3D> pts,
    OrientationAngle Orientation,
    ref List<Pnt6DSimMove> CopiedPnt)
  {
    CopiedPnt.Clear();
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add((Pnt6DSimMove) new PointAndIndex(new Pnt3D(pts[index]), new OrientationAngle(Orientation)));
  }

  public static void Add(List<Pnt6DSimMove> pts, ref List<Pnt6DSimMove> CopiedPnt)
  {
    for (int index = 0; index < pts.Count; ++index)
      CopiedPnt.Add(PointABC.Copy(pts[index]));
  }

  public static void Add(List<Pnt6DSimMove> pts, ref List<List<Pnt6DSimMove>> CopiedPnt)
  {
    List<Pnt6DSimMove> CopiedPnt1 = new List<Pnt6DSimMove>();
    PointABC.Copy(pts, ref CopiedPnt1);
    CopiedPnt.Add(CopiedPnt1);
  }

  public static void Add(
    List<List<Pnt6DSimMove>> SourceList,
    ref List<List<Pnt6DSimMove>> TargetList)
  {
    try
    {
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
      {
        List<Pnt6DSimMove> CopiedPnt = new List<Pnt6DSimMove>();
        PointABC.Copy(SourceList[index], ref CopiedPnt);
        TargetList.Add(CopiedPnt);
      }
    }
    catch (Exception ex)
    {
    }
  }

  public override string ToString()
  {
    string str1 = $"X:{((MeshToSurfacePointsSettings) this).X.ToString("f4")}; Y:{((MeshToSurfacePointsSettings) this).Y.ToString("f4")}; Z:{((MeshToSurfacePointsSettings) this).Z.ToString("f4")}; A:{((MeshToSurfacePointsSettings) this).A.ToString("f4")}; B:{((MeshToSurfacePointsSettings) this).B.ToString("f4")}; C:{((MeshToSurfacePointsSettings) this).C.ToString("f4")}; F:{((MeshToSurfacePointsSettings) this).FeedRate.ToString("f2")}; S:{((MeshToSurfacePointsCalculations) this).SpindleRpm.ToString("f2")}; T:{((MeshToSurfacePointsCalculations) this).ToolNo.ToString("f0")}";
    string str2 = !((MeshToSurfacePointsCalculations) this).isMCode ? $"{str1} ; G: {((MeshToSurfacePointsCalculations) this).GCode.ToString()}" : $"{str1} ; M: {((MeshToSurfacePointsCalculations) this).MCode.ToString()}";
    if (((MeshToSurfacePointsCalculations) this).Index >= 0)
      str2 = $"{str2} ; Index: {((MeshToSurfacePointsCalculations) this).Index.ToString()}";
    if ((((RoboticSurfacePoint) this).Clampers == null ? 0 : (((RoboticSurfacePoint) this).Clampers.Count > 0 ? 1 : 0)) != 0)
      str2 = $"{str2} ; Clmaps: {((RoboticSurfacePoint) this).Clampers.Count.ToString()}";
    return str2;
  }
}
