// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.SewingPickType
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingPickType : buSerilization5
{
  public int SimStep;
  public static int StepZ;
  public static double MedianRadius;
  public static int PipeExecStep;
  public static int OffsetX;

  public void RotatePointAtBackPlane(
    ref List<Point3D> PL,
    Point3D refPoint,
    Point3D calcPoint,
    double MaterialDepth,
    double MaterialHeight,
    double Angle)
  {
    Point3D CenterPoint = new Point3D(0.0, MaterialHeight, MaterialDepth);
    Point3D point3D = F_NotchEdit.ToPoint3D(calcPoint);
    buCall.\u0001.Rotate(CenterPoint, -Angle, Plane.YZ, ref point3D);
    buCall.\u0001.Rotate(CenterPoint, -Angle, Plane.YZ, ref PL);
    double dZ = refPoint.Z - point3D.Z;
    double dY = dZ * Math.Tan(buString5.DegreeToRadian(Angle));
    buCall.\u0001.Move(0.0, dY, dZ, ref PL);
  }

  static SewingPickType()
  {
    FoamRuntimeSettings.LangDoorStatus = new List<string>();
    FoamRuntimeSettings.LangDoorMessage = new List<string>();
    FoamRuntimeSettings.LangDoorCaptions = new List<string>();
    FoamRuntimeSettings.LangDoorCommands = new List<string>();
    FoamRuntimeSettings.varTemps = (DoorTempVars) new SewingSettings();
    FoamRuntimeSettings.varDoorSettings = (DoorSettings) new SewingSelectedPoint();
    FoamRuntimeSettings.varDoorRunSettings = (DoorRuntimeSettings) new SewingSelectedPoint();
  }

  public SewingPickType()
  {
    ((FoamRuntimeSettings) this).Name = "Job";
    ((FoamRuntimeSettings) this).GCode = "";
    ((FoamRuntimeSettings) this).Items = new List<buShape>();
    ((FoamRuntimeSettings) this).Codes = new List<string>();
    ((FoamRuntimeSettings) this).Cams = new List<camTp>();
    ((FoamRuntimeSettings) this).ErrorCodes = new List<string>();
    ((FoamRuntimeSettings) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((FoamRuntimeSettings) this).TotalCount = 1;
    ((FoamRuntimeSettings) this).Used = 0;
    ((FoamRuntimeSettings) this).isSorted = false;
    ((FoamRuntimeSettings) this).panelEntity = (Entity) null;
    ((FoamRuntimeSettings) this).panelEntity2 = (Entity) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
