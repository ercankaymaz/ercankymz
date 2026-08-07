// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MachineSimulation
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

#nullable disable
namespace buEyeBaseVer5;

public class MachineSimulation
{
  public Point3D MaxPoint;
  public Vector3D Delta;
  public static byte f00065F;

  public MachineSimulation()
  {
    ((CreateModelProperties) this).pntBase = new Point3D();
    ((CreateModelProperties) this).pntPre = new Point3D();
    ((CreateModelProperties) this).pntNext = new Point3D();
    ((CreateModelProperties) this).pntNormal = new Pnt6D();
    ((CreateModelProperties) this).pntTangent = new Pnt6D();
    ((CreateModelProperties) this).entNormal = (Entity) null;
    ((CreateModelProperties) this).entTangent = (Entity) null;
    ((CreateModelProperties) this).entContour = (Entity) null;
    ((CreateModelProperties) this).entLeadIn = (Entity) null;
    ((CreateModelProperties) this).entLeadOut = (Entity) null;
    ((CreateModelProperties) this).entSafeIn = (Entity) null;
    ((CreateModelProperties) this).entSafeOut = (Entity) null;
    ((EyeCreateProps) this).vecNormal = new Vector3D();
    ((EyeCreateProps) this).Enable = true;
    ((EyeCreateProps) this).isLast = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
