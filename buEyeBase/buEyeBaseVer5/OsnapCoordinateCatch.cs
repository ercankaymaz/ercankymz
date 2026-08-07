// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.OsnapCoordinateCatch
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

public class OsnapCoordinateCatch
{
  public static byte f00059D;
  public Point3D OffsetXYZ;
  public OrientationAngle OffsetABC;
  public Point3D RotateCenterOffsetOfA;
  public Point3D RotateCenterOffsetOfB;
  public Point3D RotateCenterOffsetOfC;
  public Point3D MovePartRuntimeOffset;
  public Length3D DistanceCenterOfAC;
  public Length3D DistanceCenterOfAB;
  public Length3D DistanceCenterOfBC;
  public Point3D CalcOffsetXYZ;
  public double ZDistanceForA0AtC0;
  public double ZDistanceForA0AtC90;
  public double ZDistanceForA0AtC180;
  public double ZDistanceForA0AtC270;
  public double ZDistanceForA45AtC0;
  public double ZDistanceForA45AtC90;
  public double ZDistanceForA45AtC180;
  public double ZDistanceForA45AtC270;

  public OsnapCoordinateCatch(MachineDefPart item)
  {
    ((Pnt6DSimMove) this).PartName = "Part";
    ((Pnt6DSimMove) this).PartFileName = Application.StartupPath;
    ((Pnt6DSimMove) this).isMoveable = true;
    ((Pnt6DSimMove) this).isBelongToBody = false;
    ((Pnt6DSimMove) this).Tag = "";
    ((Pnt6DSimMove) this).No = -1;
    ((Pnt6DSimMove) this).MoveAxisPermision = new AxesEnable(true, true, true, false, false, false);
    ((Pnt6DSimMove) this).Entities = new List<Entity>();
    ((Pnt6DSimMove) this).Color = Color.Gray;
    ((Pnt6DSimMove) this).PositionBaseOffset = new Point3D();
    ((Pnt6DSimMove) this).PositionAuxOffset = new Point3D();
    ((Pnt6DSimMove) this).RotationDistance = 0.0;
    ((Pnt6DSimMove) this).Stroke = 0.0;
    ((Pnt6DSimMove) this).RotationCenter = new Point3D();
    ((Pnt6DSimMove) this).Transparency = (int) byte.MaxValue;
    ((Pnt6DSimMove) this).AddAsMesh = false;
    ((Pnt6DSimMove) this).PartType = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((Pnt6DSimMove) this).PartName = ((Pnt6DSimMove) item).PartName;
    ((Pnt6DSimMove) this).Color = ((Pnt6DSimMove) item).Color;
    ((Pnt6DSimMove) this).Entities = new List<Entity>();
    buVector5.CopyEntities(((Pnt6DSimMove) item).Entities, ref ((Pnt6DSimMove) this).Entities);
  }

  public override string ToString()
  {
    return $"{((Pnt6DSimMove) this).PartFileName} - {((Pnt6DSimMove) this).MoveAxisPermision.ToString()}";
  }
}
