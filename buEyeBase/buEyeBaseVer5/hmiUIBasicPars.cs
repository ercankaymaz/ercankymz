// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.hmiUIBasicPars
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
public class hmiUIBasicPars : buSerilization
{
  public bool CurveAsFitSpline;
  public bool AciColors;
  public bool Purge;

  public override string ToString() => "Index: " + ((GCodeConverter) this).Index.ToString();

  public abstract void m000341();

  public hmiUIBasicPars()
  {
    ((GCodePoint5) this).MovePoints = new List<Point3D>();
    ((GCodePoint5) this).TipPoints = new List<Point3D>();
    ((GCodePoint5) this).BoxSizePoints = new List<Point3D>();
    ((GCodePoint5) this).RotatePoints = new List<Point3D>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
