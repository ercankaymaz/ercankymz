// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buClipperLib.DoublePoint
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

#nullable disable
namespace buEyeBaseVer5.buClipperLib;

public struct DoublePoint
{
  public Mesh.natureType MeshNature;
  public Mesh.edgeStyleType EdgeStyle;

  public DoublePoint(double x1, double y1, double x2, double y2)
  {
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXItem&) ref this).\u0001 = 50.0;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXItem&) ref this).\u0001 = entitySortDirection.Normal;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXItem&) ref this).\u0001 = -1;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXCAM&) ref this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Line) ref this).\u002Ector(x1, y1, x2, y2);
  }

  public DoublePoint(Plane sketchPlane, double x1, double y1, double x2, double y2)
  {
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXItem&) ref this).\u0001 = 50.0;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXItem&) ref this).\u0001 = entitySortDirection.Normal;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXItem&) ref this).\u0001 = -1;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXCAM&) ref this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Line) ref this).\u002Ector(sketchPlane, x1, y1, x2, y2);
  }

  public DoublePoint(double x1, double y1, double z1, double x2, double y2, double z2)
  {
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXItem&) ref this).\u0001 = 50.0;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXItem&) ref this).\u0001 = entitySortDirection.Normal;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXItem&) ref this).\u0001 = -1;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    // ISSUE: reference to a compiler-generated field
    (^(Router3AXCAM&) ref this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Line) ref this).\u002Ector(x1, y1, z1, x2, y2, z2);
  }
}
