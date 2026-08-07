// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.CreateModelProperties
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class CreateModelProperties : buSerilization5
{
  public double FindCorrectPosMoveStep;
  public int FindCorrectPosIterationCount;
  public Pnt6D normalPoint;
  public Pnt6D tangentPoint;
  public Entity normalEntities;
  public Entity tangentEntities;
  public Entity LeadInEntities;
  public Entity LeadOutEntities;
  public Entity SafeInEntities;
  public Entity SafeOutEntities;
  public Vector3D NormalVector;
  public Vector3D TangentVector;
  public Point3D pntBase;
  public Point3D pntPre;
  public Point3D pntNext;
  public Pnt6D pntNormal;
  public Pnt6D pntTangent;
  public Entity entNormal;
  public Entity entTangent;
  public Entity entContour;
  public Entity entLeadIn;
  public Entity entLeadOut;
  public Entity entSafeIn;
  public Entity entSafeOut;

  public override string ToString()
  {
    // ISSUE: explicit non-virtual call
    return $"{__nonvirtual (((Point3D) this).ToString())} | {((AlingmentPoints3D) this).Type.ToString()}";
  }

  public abstract void m000281();

  public CreateModelProperties()
  {
    ((AlingmentPoints3D) this).Pnt = new Point3D();
    ((AlingmentPoints3D) this).Index = -1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
