// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ToolCheckOption
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ToolCheckOption : buSerilization5
{
  public string ToolNotchName;
  public string ToolAuxName;

  public void NotchHorizontalTypeCamMoveCalc(
    ToolBase5 Tool,
    ref ProfileOperation P,
    ref camTpPoint CP,
    ref List<Point3D> PL,
    double XStart,
    double XEnd,
    double YPos,
    double ZSafe,
    double ZVal)
  {
    TpPnt9D tpPnt9D1 = new TpPnt9D(new Pnt6D(XStart, YPos, ZSafe + ((ToolGeometry5) Tool).Geometry.Diameter / 2.0, 90.0, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid, 0);
    ((TpArcData) tpPnt9D1).P9.A = 90.0;
    tpPnt9D1.Type = 0;
    tpPnt9D1.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Rapid;
    tpPnt9D1.MoveType = CamMoveType.G0;
    CP.Points.Add(tpPnt9D1);
    PL.Add(new Point3D(((TpArcData) tpPnt9D1).P9.X, ((TpArcData) tpPnt9D1).P9.Y, ((TpArcData) tpPnt9D1).P9.Z - ((ToolGeometry5) Tool).Geometry.Diameter / 2.0));
    TpPnt9D tpPnt9D2 = new TpPnt9D(new Pnt6D(XStart, YPos, ZVal + ((ToolGeometry5) Tool).Geometry.Diameter / 2.0, 90.0, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge, 1);
    tpPnt9D2.Type = 1;
    tpPnt9D2.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Plunge;
    tpPnt9D2.MoveType = CamMoveType.Plunge;
    tpPnt9D2.PlungeAxis = "Z";
    tpPnt9D2.LeaveAxis = "Z";
    tpPnt9D2.PlungeAxisMovement = true;
    CP.Points.Add(tpPnt9D2);
    PL.Add(new Point3D(((TpArcData) tpPnt9D2).P9.X, ((TpArcData) tpPnt9D2).P9.Y, ((TpArcData) tpPnt9D2).P9.Z - ((ToolGeometry5) Tool).Geometry.Diameter / 2.0));
    TpPnt9D tpPnt9D3 = new TpPnt9D(new Pnt6D(XEnd, YPos, ZVal + ((ToolGeometry5) Tool).Geometry.Diameter / 2.0, 90.0, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed, 1);
    tpPnt9D3.Type = 1;
    tpPnt9D3.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds.Feed;
    tpPnt9D3.MoveType = CamMoveType.G1;
    CP.Points.Add(tpPnt9D3);
    PL.Add(new Point3D(((TpArcData) tpPnt9D3).P9.X, ((TpArcData) tpPnt9D3).P9.Y, ((TpArcData) tpPnt9D3).P9.Z - ((ToolGeometry5) Tool).Geometry.Diameter / 2.0));
    TpPnt9D tpPnt9D4 = new TpPnt9D(new Pnt6D(XEnd, YPos, ZSafe + ((ToolGeometry5) Tool).Geometry.Diameter / 2.0, 90.0, 0.0, 0.0), ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParNotch.Speeds).Leave, 0);
    tpPnt9D4.Type = 0;
    tpPnt9D4.MoveType = CamMoveType.G0;
    tpPnt9D4.PlungeAxis = "Z";
    tpPnt9D4.LeaveAxis = "Z";
    CP.Points.Add(tpPnt9D4);
    PL.Add(new Point3D(((TpArcData) tpPnt9D4).P9.X, ((TpArcData) tpPnt9D4).P9.Y, ((TpArcData) tpPnt9D4).P9.Z - ((ToolGeometry5) Tool).Geometry.Diameter / 2.0));
  }

  public void NotchHorizontalTypeMillingCamMoveCalc(
    ToolBase5 Tool,
    ref ProfileOperation P,
    ref camTpPoint CP,
    ref List<Point3D> PL,
    double XStart,
    double XEnd,
    double YStart,
    double YEnd,
    double ZSafe,
    double ZVal)
  {
    TpPnt9D tpPnt9D1 = new TpPnt9D(new Pnt6D(XStart, YStart, ZSafe, 0.0, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParMilling.Speeds.Rapid, 0);
    ((TpArcData) tpPnt9D1).P9.A = 0.0;
    tpPnt9D1.Type = 0;
    tpPnt9D1.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParMilling.Speeds.Rapid;
    tpPnt9D1.MoveType = CamMoveType.G0;
    CP.Points.Add(tpPnt9D1);
    PL.Add(new Point3D(((TpArcData) tpPnt9D1).P9.X, ((TpArcData) tpPnt9D1).P9.Y, ((TpArcData) tpPnt9D1).P9.Z));
    TpPnt9D tpPnt9D2 = new TpPnt9D(new Pnt6D(XStart, YStart, ZVal, 0.0, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParMilling.Speeds.Plunge, 1);
    tpPnt9D2.Type = 1;
    tpPnt9D2.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParMilling.Speeds.Plunge;
    tpPnt9D2.MoveType = CamMoveType.Plunge;
    tpPnt9D2.PlungeAxis = "Z";
    tpPnt9D2.LeaveAxis = "Z";
    tpPnt9D2.PlungeAxisMovement = true;
    CP.Points.Add(tpPnt9D2);
    PL.Add(new Point3D(((TpArcData) tpPnt9D2).P9.X, ((TpArcData) tpPnt9D2).P9.Y, ((TpArcData) tpPnt9D2).P9.Z));
    TpPnt9D tpPnt9D3 = new TpPnt9D(new Pnt6D(XStart, YEnd, ZVal, 0.0, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParMilling.Speeds.Feed, 1);
    tpPnt9D3.Type = 1;
    tpPnt9D3.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParMilling.Speeds.Feed;
    tpPnt9D3.MoveType = CamMoveType.G1;
    CP.Points.Add(tpPnt9D3);
    PL.Add(new Point3D(((TpArcData) tpPnt9D3).P9.X, ((TpArcData) tpPnt9D3).P9.Y, ((TpArcData) tpPnt9D3).P9.Z));
    TpPnt9D tpPnt9D4 = new TpPnt9D(new Pnt6D(XStart, YEnd, ZSafe, 0.0, 0.0, 0.0), ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParMilling.Speeds).Leave, 0);
    tpPnt9D4.Type = 0;
    tpPnt9D4.MoveType = CamMoveType.G0;
    tpPnt9D4.PlungeAxis = "Z";
    tpPnt9D4.LeaveAxis = "Z";
    CP.Points.Add(tpPnt9D4);
    PL.Add(new Point3D(((TpArcData) tpPnt9D4).P9.X, ((TpArcData) tpPnt9D4).P9.Y, ((TpArcData) tpPnt9D4).P9.Z));
    TpPnt9D tpPnt9D5 = new TpPnt9D(new Pnt6D(XEnd, YStart, ZSafe, 0.0, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParMilling.Speeds.Rapid, 0);
    ((TpArcData) tpPnt9D5).P9.A = 0.0;
    tpPnt9D5.Type = 0;
    tpPnt9D5.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParMilling.Speeds.Rapid;
    tpPnt9D5.MoveType = CamMoveType.G0;
    CP.Points.Add(tpPnt9D5);
    PL.Add(new Point3D(((TpArcData) tpPnt9D5).P9.X, ((TpArcData) tpPnt9D5).P9.Y, ((TpArcData) tpPnt9D5).P9.Z));
    TpPnt9D tpPnt9D6 = new TpPnt9D(new Pnt6D(XEnd, YStart, ZVal, 0.0, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParMilling.Speeds.Plunge, 1);
    tpPnt9D6.Type = 1;
    tpPnt9D6.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParMilling.Speeds.Plunge;
    tpPnt9D6.MoveType = CamMoveType.Plunge;
    tpPnt9D6.PlungeAxis = "Z";
    tpPnt9D6.LeaveAxis = "Z";
    tpPnt9D6.PlungeAxisMovement = true;
    CP.Points.Add(tpPnt9D6);
    PL.Add(new Point3D(((TpArcData) tpPnt9D6).P9.X, ((TpArcData) tpPnt9D6).P9.Y, ((TpArcData) tpPnt9D6).P9.Z));
    TpPnt9D tpPnt9D7 = new TpPnt9D(new Pnt6D(XEnd, YEnd, ZVal, 0.0, 0.0, 0.0), ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParMilling.Speeds.Feed, 1);
    tpPnt9D7.Type = 1;
    tpPnt9D7.Feed = ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParMilling.Speeds.Feed;
    tpPnt9D7.MoveType = CamMoveType.G1;
    CP.Points.Add(tpPnt9D7);
    PL.Add(new Point3D(((TpArcData) tpPnt9D7).P9.X, ((TpArcData) tpPnt9D7).P9.Y, ((TpArcData) tpPnt9D7).P9.Z - ((ToolGeometry5) Tool).Geometry.Diameter / 2.0));
    TpPnt9D tpPnt9D8 = new TpPnt9D(new Pnt6D(XEnd, YEnd, ZSafe, 0.0, 0.0, 0.0), ((buEyeBaseVer5.camSpeedsEnable) ((ProfileArray) ((ProfileRuntimeSettings) P).OperationData).CamParMilling.Speeds).Leave, 0);
    tpPnt9D8.Type = 0;
    tpPnt9D8.MoveType = CamMoveType.G0;
    tpPnt9D8.PlungeAxis = "Z";
    tpPnt9D8.LeaveAxis = "Z";
    CP.Points.Add(tpPnt9D8);
    PL.Add(new Point3D(((TpArcData) tpPnt9D8).P9.X, ((TpArcData) tpPnt9D8).P9.Y, ((TpArcData) tpPnt9D8).P9.Z - ((ToolGeometry5) Tool).Geometry.Diameter / 2.0));
  }

  public ProfileNotchLocationType GetNotchLocationType(ShapeRuntimeData Par)
  {
    return ((dynamicInfo) Par).NotchOPType != ProfileNotchOperationType.Side ? ((dynamicInfo) Par).NotchLengthLocation : ((dynamicInfo) Par).NotchSideLocation;
  }
}
