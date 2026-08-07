// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.CamDraws
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class CamDraws
{
  public static byte f00008D;
  public drawPropertiesType CamMarkDraw;
  public drawPropertiesType CamG0Draw;
  public drawPropertiesType CamG1Draw;
  public drawPropertiesType CamPlungeDraw;
  public drawPropertiesType CamLeaveDraw;
  public drawPropertiesType CamLeadinDraw;
  public drawPropertiesType CamLeadOutDraw;

  public void CalculatePointsWithKinematic(
    Pnt6D refPoint,
    KinematicBase5 Kinematic,
    ToolBase5 Tool,
    ref Pnt6D calcPoint)
  {
    try
    {
      double ToolLength = ((ToolGeometry5) Tool).Geometry.Diameter / 2.0;
      OrientationAngle Orientation = new OrientationAngle(refPoint.A, refPoint.B, refPoint.C);
      calcPoint = new Pnt6D();
      Point3D point3D = F_NotchEdit.ToPoint3D(refPoint);
      ((buConversion5) buCall.\u0001).ForwardKinematix5Ax(ToolLength, Kinematic, Orientation, point3D, ref calcPoint);
      calcPoint.Z = calcPoint.Z + ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfC.Z - ((OsnapCoordinateCatch) Kinematic).RotateCenterOffsetOfA.Z;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }
}
