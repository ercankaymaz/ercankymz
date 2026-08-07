// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.RoboticSurfacePoint
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class RoboticSurfacePoint : buSerilization5
{
  public string Command;
  public List<double> Clampers;
  public static byte f0005E0;
  public bool Found;
  public bool Enable;
  public bool SnapFound;
  public bool OrthoFound;
  public bool OsnapFound;
  public bool TrackFound;
  public bool OverFound;
  public Point3D Point;
  public osnapType Type;
  public osnapMethodType Method;
  public int UnderEntityIndex;
  public double Width;

  public override string ToString()
  {
    return $"XPosition: {((MeshToSurfacePointsSettings) this).XPosition.ToString("f3")} , Used: {((MeshToSurfacePointsSettings) this).Used.ToString()}";
  }

  public static void Copy(List<Clamper> RefClamper, ref List<Clamper> CopiedClamper)
  {
    CopiedClamper.Clear();
    CopiedClamper = new List<Clamper>();
    for (int index = 0; index <= RefClamper.Count - 1; ++index)
    {
      Clamper CopiedClamper1 = (Clamper) new MeshToSurfacePointsSettings();
      RoboticSurfacePoint.Copy(RefClamper[index], ref CopiedClamper1);
      CopiedClamper.Add(CopiedClamper1);
    }
  }

  public static void Copy(Clamper RefClamper, ref Clamper CopiedClamper)
  {
    CopiedClamper = (Clamper) new MeshToSurfacePointsCalculations(RefClamper);
  }

  public abstract void m000258();
}
