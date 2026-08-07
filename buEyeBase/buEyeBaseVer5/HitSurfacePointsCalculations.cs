// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.HitSurfacePointsCalculations
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5;

public class HitSurfacePointsCalculations : buSerilization5
{
  public Color Color;
  public List<Point3D> CatchBasePoints;
  public Point3D EntityPoint;

  public override string ToString()
  {
    return $"XY: {((MeshToSurfacePointsSettings) this).AngleXY.ToString("f3")} XZ: {((MeshToSurfacePointsSettings) this).AngleXZ.ToString("f3")} YZ: {((MeshToSurfacePointsSettings) this).AngleYZ.ToString("f3")}";
  }

  public abstract void m00025C();
}
