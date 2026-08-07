// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.AlingmentPoints3D
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
public class AlingmentPoints3D : buSerilization5
{
  public double DistanceToPoint;
  public osnapType Type;
  public string EntName;
  public bool Enable;
  public string LayerName;
  public string OtherEntName;
  public static byte f0005F9;
  public Point3D Pnt;
  public int Index;
  public static byte f0005FC;
  public double AMinLimit;
  public double AMaxLimit;
  public double BMinLimit;

  public AlingmentPoints3D()
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
  }

  public AlingmentPoints3D(Pnt6DSimMove Pnt)
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
    ((MeshToSurfacePointsSettings) this).X = ((MeshToSurfacePointsSettings) Pnt).X;
    ((MeshToSurfacePointsSettings) this).Y = ((MeshToSurfacePointsSettings) Pnt).Y;
    ((MeshToSurfacePointsSettings) this).Z = ((MeshToSurfacePointsSettings) Pnt).Z;
    ((MeshToSurfacePointsSettings) this).A = ((MeshToSurfacePointsSettings) Pnt).A;
    ((MeshToSurfacePointsSettings) this).B = ((MeshToSurfacePointsSettings) Pnt).B;
    ((MeshToSurfacePointsSettings) this).C = ((MeshToSurfacePointsSettings) Pnt).C;
    ((MeshToSurfacePointsSettings) this).R = ((MeshToSurfacePointsSettings) Pnt).R;
    ((MeshToSurfacePointsSettings) this).FeedRate = ((MeshToSurfacePointsSettings) Pnt).FeedRate;
    ((MeshToSurfacePointsCalculations) this).SpindleRpm = ((MeshToSurfacePointsCalculations) Pnt).SpindleRpm;
    ((MeshToSurfacePointsCalculations) this).ToolNo = ((MeshToSurfacePointsCalculations) Pnt).ToolNo;
    ((MeshToSurfacePointsCalculations) this).ToolName = ((MeshToSurfacePointsCalculations) Pnt).ToolName;
    ((MeshToSurfacePointsCalculations) this).Offset = new Point3D(((MeshToSurfacePointsCalculations) Pnt).Offset.X, ((MeshToSurfacePointsCalculations) Pnt).Offset.Y, ((MeshToSurfacePointsCalculations) Pnt).Offset.Z);
    ((MeshToSurfacePointsCalculations) this).Index = ((MeshToSurfacePointsCalculations) Pnt).Index;
    ((MeshToSurfacePointsCalculations) this).isMCode = ((MeshToSurfacePointsCalculations) Pnt).isMCode;
    ((MeshToSurfacePointsCalculations) this).MCode = ((MeshToSurfacePointsCalculations) Pnt).MCode;
    ((MeshToSurfacePointsCalculations) this).GCode = ((MeshToSurfacePointsCalculations) Pnt).GCode;
    ((MeshToSurfacePointsCalculations) this).Aux1 = ((MeshToSurfacePointsCalculations) Pnt).Aux1;
    ((MeshToSurfacePointsCalculations) this).Aux2 = ((MeshToSurfacePointsCalculations) Pnt).Aux2;
    if (((RoboticSurfacePoint) Pnt).Clampers == null)
      return;
    ((RoboticSurfacePoint) this).Clampers = new List<double>();
    for (int index = 0; index <= ((RoboticSurfacePoint) Pnt).Clampers.Count - 1; ++index)
      ((RoboticSurfacePoint) this).Clampers.Add(((RoboticSurfacePoint) Pnt).Clampers[index]);
  }
}
