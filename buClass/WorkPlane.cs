// Decompiled with JetBrains decompiler
// Type: buClass.WorkPlane
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class WorkPlane : buSerilization
{
  public planeType PlaneType = planeType.XY;
  public planeNames PlaneName = planeNames.Top;
  public int PerpendicularAxisDirection = 1;
  public Pnt3D BasePoint = new Pnt3D();
  public Pnt3D MiddlePoint = new Pnt3D();
  public Pnt3D TipPoint = new Pnt3D();
  public Vec3D Normalies = new Vec3D();
  public OrientationAngle Angles = new OrientationAngle();
  public Quad3D Quad = new Quad3D();
  public bool isReverse = false;
  public bool isSlope = false;
  public bool isCircular = false;
  public bool UseCenterPoint = false;
  public double Lenght = 0.0;
  public double BaseAngle = 0.0;
  public double CircularAngle = 0.0;
  public Vec3D DeltaLenght = new Vec3D();
  public List<eEntities> PlaneEntites = new List<eEntities>();
  public List<Pnt3D> BoxPoints = new List<Pnt3D>();

  public WorkPlane()
  {
    this.PlaneType = planeType.XY;
    this.PerpendicularAxisDirection = 1;
    this.Normalies = new Vec3D(0.0, 0.0, 1.0);
    this.BasePoint = new Pnt3D();
  }

  public WorkPlane(planeType type, int perperdicularaxisdir)
  {
    this.PlaneType = type;
    this.PerpendicularAxisDirection = perperdicularaxisdir;
    if (this.PlaneType == planeType.XY)
      this.Normalies = this.PerpendicularAxisDirection < 0 ? new Vec3D(0.0, 0.0, -1.0) : new Vec3D(0.0, 0.0, 1.0);
    if (this.PlaneType == planeType.XZ)
      this.Normalies = this.PerpendicularAxisDirection < 0 ? new Vec3D(0.0, -1.0, 0.0) : new Vec3D(0.0, 1.0, 0.0);
    if (this.PlaneType != planeType.YZ)
      return;
    this.Normalies = this.PerpendicularAxisDirection < 0 ? new Vec3D(-1.0, 0.0, 0.0) : new Vec3D(1.0, 0.0, 0.0);
  }

  public WorkPlane(Vec3D Normalies)
  {
    this.PlaneType = WorkPlane.checkPlane(Normalies);
    this.Normalies = new Vec3D(Normalies);
    this.BasePoint = new Pnt3D();
  }

  public WorkPlane(WorkPlane data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    this.Angles = new OrientationAngle(data.Angles);
    this.Quad = new Quad3D(data.Quad);
    this.PlaneEntites.Clear();
    eEntities.CopyEntities(data.PlaneEntites, ref this.PlaneEntites);
    this.BoxPoints.Clear();
    Pnt3D.Copy(data.BoxPoints, ref this.BoxPoints);
  }

  public static bool isPlaneXY(WorkPlane plane)
  {
    return plane.PlaneType == planeType.XY | plane.PlaneType == planeType.YX;
  }

  public static bool isPlaneXZ(WorkPlane plane)
  {
    return plane.PlaneType == planeType.XZ | plane.PlaneType == planeType.ZX;
  }

  public static bool isPlaneYZ(WorkPlane plane)
  {
    return plane.PlaneType == planeType.YZ | plane.PlaneType == planeType.ZY;
  }

  public static planeType checkPlane(Vec3D Normalies)
  {
    if (Normalies.X == 0.0 & Normalies.Y == 0.0 & Normalies.Z == 1.0)
      return planeType.XY;
    if (Normalies.X == 0.0 & Normalies.Y == 0.0 & Normalies.Z == -1.0)
      return planeType.YX;
    if (Normalies.X == 1.0 & Normalies.Y == 0.0 & Normalies.Z == 0.0)
      return planeType.YZ;
    if (Normalies.X == -1.0 & Normalies.Y == 0.0 & Normalies.Z == 0.0)
      return planeType.ZY;
    if (Normalies.X == 0.0 & Normalies.Y == -1.0 & Normalies.Z == 0.0)
      return planeType.XZ;
    return Normalies.X == 0.0 & Normalies.Y == 1.0 & Normalies.Z == 0.0 ? planeType.ZX : planeType.Angle;
  }

  public static WorkPlane Copy(WorkPlane basePlane)
  {
    WorkPlane copiedPlane = new WorkPlane();
    WorkPlane.Copy(basePlane, ref copiedPlane);
    return copiedPlane;
  }

  public static void Copy(WorkPlane basePlane, ref WorkPlane copiedPlane)
  {
    copiedPlane = new WorkPlane(basePlane);
  }

  public static WorkPlane XY() => new WorkPlane();

  public static WorkPlane XZ() => new WorkPlane(new Vec3D(0.0, -1.0, 0.0));

  public static WorkPlane YZ() => new WorkPlane(new Vec3D(1.0, 0.0, 0.0));

  public override string ToString()
  {
    return $"Type : {this.PlaneType.ToString()} , Direction : {this.PerpendicularAxisDirection.ToString()}";
  }
}
