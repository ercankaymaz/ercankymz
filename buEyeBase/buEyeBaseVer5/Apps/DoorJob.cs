// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DoorJob
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DoorJob : buSerilization5
{
  public double infoDepth;
  public double infoHeadRadius;
  public int infoSide;
  public int infoDegree;
  public double infoDirection;
  public Point3D infoBasePoint;
  public entitySplineType CurveType;
  public double camFeedrate;
  public int Sequence;
  public tuftingStitchModeType tuftingMode;
  public double tuftingPileHeight;
  public double tuftingStitchLength;

  public DoorJob(IntPoint pt)
  {
    ((DoorRuntimeSettings) this).X = pt.X;
    ((DoorRuntimeSettings) this).Y = pt.Y;
    ((DoorRuntimeSettings) this).Z = pt.Z;
  }

  public static bool operator ==(IntPoint a, IntPoint b) => a.X == b.X && a.Y == b.Y;

  public static bool operator !=(IntPoint a, IntPoint b) => a.X != b.X || a.Y != b.Y;
}
