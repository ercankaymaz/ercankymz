// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buClipperLib.IntRect
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

#nullable disable
namespace buEyeBaseVer5.buClipperLib;

public struct IntRect
{
  public Point3D QuadrantPoint;
  public Point3D Origin;
  public double Height;
  public Plane Plane;

  public IntRect(Point2D min, Point2D max)
  {
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXCAM&) ref this).\u0001 = 0.0;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXCAM&) ref this).\u0001 = -1;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXCAM&) ref this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((LinearPath) ref this).\u002Ector(min, max);
  }

  public IntRect(Plane sketchPlane, params Point2D[] points)
  {
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXCAM&) ref this).\u0001 = 0.0;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXCAM&) ref this).\u0001 = -1;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXCAM&) ref this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((LinearPath) ref this).\u002Ector(sketchPlane, points);
  }
}
