// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buClipperLib.IntersectNode
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

#nullable disable
namespace buEyeBaseVer5.buClipperLib;

public class IntersectNode
{
  public Point3D pntMassCenter;
  public string GroupInfo;
  public double Depth;

  public IntersectNode(Plane plane, Point2D min, Point2D max)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0001 = 0.0;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((LinearPath) this).\u002Ector(plane, min, max);
  }
}
