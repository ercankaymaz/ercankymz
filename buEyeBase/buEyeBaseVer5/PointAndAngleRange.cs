// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.PointAndAngleRange
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
public class PointAndAngleRange : buSerilization5
{
  public double BMaxLimit;
  public double CMinLimit;
  public double CMaxLimit;
  public bool FindMaxX;

  public PointAndAngleRange(Pnt6D Pnt)
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
    ((MeshToSurfacePointsSettings) this).X = Pnt.X;
    ((MeshToSurfacePointsSettings) this).Y = Pnt.Y;
    ((MeshToSurfacePointsSettings) this).Z = Pnt.Z;
    ((MeshToSurfacePointsSettings) this).A = Pnt.A;
    ((MeshToSurfacePointsSettings) this).B = Pnt.B;
    ((MeshToSurfacePointsSettings) this).C = Pnt.C;
  }

  public PointAndAngleRange(Pnt9D Pnt)
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
    ((MeshToSurfacePointsSettings) this).X = Pnt.X;
    ((MeshToSurfacePointsSettings) this).Y = Pnt.Y;
    ((MeshToSurfacePointsSettings) this).Z = Pnt.Z;
    ((MeshToSurfacePointsSettings) this).A = Pnt.A;
    ((MeshToSurfacePointsSettings) this).B = Pnt.B;
    ((MeshToSurfacePointsSettings) this).C = Pnt.C;
  }

  public PointAndAngleRange(Pnt9DCam Pnt)
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
    ((MeshToSurfacePointsSettings) this).X = Pnt.P9.X;
    ((MeshToSurfacePointsSettings) this).Y = Pnt.P9.Y;
    ((MeshToSurfacePointsSettings) this).Z = Pnt.P9.Z;
    ((MeshToSurfacePointsSettings) this).A = Pnt.P9.A;
    ((MeshToSurfacePointsSettings) this).B = Pnt.P9.B;
    ((MeshToSurfacePointsSettings) this).C = Pnt.P9.C;
    ((MeshToSurfacePointsSettings) this).FeedRate = Pnt.Feed;
    ((MeshToSurfacePointsCalculations) this).SpindleRpm = Pnt.SpindleSpeed;
    ((MeshToSurfacePointsCalculations) this).ToolNo = Pnt.ToolNo;
  }

  public PointAndAngleRange(Pnt3D Pnt)
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
    ((MeshToSurfacePointsSettings) this).X = Pnt.X;
    ((MeshToSurfacePointsSettings) this).Y = Pnt.Y;
    ((MeshToSurfacePointsSettings) this).Z = Pnt.Z;
    ((MeshToSurfacePointsSettings) this).A = 0.0;
    ((MeshToSurfacePointsSettings) this).B = 0.0;
    ((MeshToSurfacePointsSettings) this).C = 0.0;
  }
}
