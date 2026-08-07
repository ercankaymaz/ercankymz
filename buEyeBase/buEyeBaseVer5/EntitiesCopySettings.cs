// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.EntitiesCopySettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class EntitiesCopySettings : buSerilization5
{
  public Point3D EndPoint;
  public static byte f000539;
  public string Char;
  public int Index;
  public List<buEntity> CharEntities;
  public static byte f00053D;
  public bool FindProblems;
  public bool FixProblems;
  public bool isSameMoreThanOneCheck;
  public bool isEntityLengthSmall;
  public bool isSmallGap;
  public bool isClosedEntities;
  public bool IntersectionEntities;
  public double SmallGapMinDistance;
  public double SmallGapMaxDistance;
  public double EntityLengthLimit;
  public double IntersectionGap;

  public override string ToString()
  {
    return $"{((EntityDataSet) this).StartPoint.ToString()} - W: {((EntityDataSet) this).Width.ToString()} - H: {((EntityDataSet) this).Height.ToString()}";
  }

  public abstract void m000213();

  public EntitiesCopySettings()
  {
    ((EntityDataSet) this).StartPoint = new Point3D();
    this.EndPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public EntitiesCopySettings(Line2D data)
  {
    ((EntityDataSet) this).StartPoint = new Point3D();
    this.EndPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((EntityDataSet) this).StartPoint = new Point3D(((EntityDataSet) data).StartPoint.X, ((EntityDataSet) data).StartPoint.Y, ((EntityDataSet) data).StartPoint.Z);
    this.EndPoint = new Point3D(((EntitiesCopySettings) data).EndPoint.X, ((EntitiesCopySettings) data).EndPoint.Y, ((EntitiesCopySettings) data).EndPoint.Z);
  }
}
