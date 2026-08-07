// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.SewingOffsetOptions
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingOffsetOptions : buSerilization5
{
  public string pathFromFile;
  public LengthUnit UnitLength;
  public SpeedUnit UnitSpeed;
  public static byte f003C79;
  public string pathPipeBendJob;

  public int JobImageIndex(buShape Item)
  {
    return !(Item.GetType() == typeof (buShapeCircle)) ? (!(Item.GetType() == typeof (buShapeRectangle)) ? (!(Item.GetType() == typeof (buShapeEllipse)) ? (!(Item.GetType() == typeof (buShapeKeyHole)) ? (!(Item.GetType() == typeof (buShapePolygon)) ? (!(Item.GetType() == typeof (buShapeSlot)) ? (!(Item.GetType() == typeof (buShapeFreeDraw)) ? -1 : 2) : 6) : 4) : 3) : 1) : 5) : 0;
  }

  public void RotatePointAtFrontPlane(
    ref List<Point3D> PL,
    Point3D refPoint,
    Point3D calcPoint,
    double MaterialDepth,
    double Angle)
  {
    Point3D CenterPoint = new Point3D(0.0, 0.0, MaterialDepth);
    Point3D point3D = F_NotchEdit.ToPoint3D(calcPoint);
    buCall.\u0001.Rotate(CenterPoint, Angle, Plane.YZ, ref point3D);
    buCall.\u0001.Rotate(CenterPoint, Angle, Plane.YZ, ref PL);
    double dZ = refPoint.Z - point3D.Z;
    double num = dZ * Math.Tan(buString5.DegreeToRadian(Angle));
    buCall.\u0001.Move(0.0, -num, dZ, ref PL);
  }
}
