// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.PointsList
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
public class PointsList : buSerilization5
{
  public bool isFirst;

  public PointsList(
    double x,
    double y,
    double z,
    double a,
    double b,
    double c,
    double f,
    double t,
    double s,
    Pnt3D offset,
    int index,
    string toolname)
  {
    ((MeshToSurfacePointsCalculations) this).Offset = new Point3D();
    ((MeshToSurfacePointsCalculations) this).GCode = -1;
    ((MeshToSurfacePointsCalculations) this).Index = -1;
    ((MeshToSurfacePointsCalculations) this).isMCode = false;
    ((MeshToSurfacePointsCalculations) this).MCode = -1;
    ((MeshToSurfacePointsCalculations) this).Aux1 = 0.0;
    ((MeshToSurfacePointsCalculations) this).Aux2 = 0.0;
    ((RoboticSurfacePoint) this).Command = "";
    ((RoboticSurfacePoint) this).Clampers = (List<double>) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((MeshToSurfacePointsSettings) this).X = x;
    ((MeshToSurfacePointsSettings) this).Y = y;
    ((MeshToSurfacePointsSettings) this).Z = z;
    ((MeshToSurfacePointsSettings) this).A = a;
    ((MeshToSurfacePointsSettings) this).B = b;
    ((MeshToSurfacePointsSettings) this).C = c;
    ((MeshToSurfacePointsSettings) this).FeedRate = f;
    ((MeshToSurfacePointsCalculations) this).SpindleRpm = s;
    ((MeshToSurfacePointsCalculations) this).ToolNo = t;
    ((MeshToSurfacePointsCalculations) this).Offset = new Point3D(offset.X, offset.Y, offset.Z);
    ((MeshToSurfacePointsCalculations) this).Index = index;
    ((MeshToSurfacePointsCalculations) this).ToolName = toolname;
  }

  public PointsList(double x, double y, double z)
  {
    ((MeshToSurfacePointsCalculations) this).Offset = new Point3D();
    ((MeshToSurfacePointsCalculations) this).GCode = -1;
    ((MeshToSurfacePointsCalculations) this).Index = -1;
    ((MeshToSurfacePointsCalculations) this).isMCode = false;
    ((MeshToSurfacePointsCalculations) this).MCode = -1;
    ((MeshToSurfacePointsCalculations) this).Aux1 = 0.0;
    ((MeshToSurfacePointsCalculations) this).Aux2 = 0.0;
    ((RoboticSurfacePoint) this).Command = "";
    ((RoboticSurfacePoint) this).Clampers = (List<double>) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    ((MeshToSurfacePointsSettings) this).X = x;
    ((MeshToSurfacePointsSettings) this).Y = y;
    ((MeshToSurfacePointsSettings) this).Z = z;
    ((MeshToSurfacePointsSettings) this).A = 0.0;
    ((MeshToSurfacePointsSettings) this).B = 0.0;
    ((MeshToSurfacePointsSettings) this).C = 0.0;
  }

  public override int GetHashCode() => base.GetHashCode();
}
