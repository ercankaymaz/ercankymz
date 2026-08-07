// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ShapeCreateParameters
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ShapeCreateParameters : buSerilization5
{
  public int OrigineSize;
  public string OriginString;
  public int Width;
  public int Height;
  public static byte f000693;
  public bool ShowCoordinateSystemIcon;
  public bool ShowOrigineIcon;
  public bool ShowOrigineCaption;
  public bool MovePositionEnable;
  public bool ShowCubeIcon;
  public bool ShowToolbar;
  public bool ShowGrid;
  public bool ZoomReverse;
  public bool View2D;
  public int OrigineSize;
  public double GridStepX;
  public double GridStepY;

  public abstract void m000299();

  public ShapeCreateParameters()
  {
    ((ViewportSettings) this).refPoint = new Point3D();
    ((ViewportSettings) this).Index = -1;
    ((ViewportSettings) this).DomainValue = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ShapeCreateParameters(Point3D refPnt, int Indx)
  {
    ((ViewportSettings) this).refPoint = new Point3D();
    ((ViewportSettings) this).Index = -1;
    ((ViewportSettings) this).DomainValue = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((ViewportSettings) this).refPoint = new Point3D(refPnt.X, refPnt.Y, refPnt.Z);
    ((ViewportSettings) this).Index = Indx;
  }
}
