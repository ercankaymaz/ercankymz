// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buClipperLib.IntPoint
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.buClipperLib;

public struct IntPoint
{
  public Point3D ExtLine2;
  public Point3D DimLinePosition;
  public Point3D InsertionPoint;

  [CompilerGenerated]
  [SpecialName]
  public int get_GroupIdIndex() => (^(Router3AXCAM&) ref this).\u0002;

  [CompilerGenerated]
  [SpecialName]
  public void set_GroupIdIndex(int value) => (^(Router3AXCAM&) ref this).\u0002 = value;

  [CompilerGenerated]
  [SpecialName]
  public bool get_CamSelected() => (^(Router3AXCAM&) ref this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_CamSelected(bool value) => (^(Router3AXCAM&) ref this).\u0001 = value;

  public abstract void m001963();

  public IntPoint(LinearPath another)
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
    ((LinearPath) ref this).\u002Ector(another);
    if (!(another is buLinearPathArrow))
      return;
    ((\u0012.\u0002) ref this).set_Tags(((\u0080.\u0001) another).get_Tags());
    ((\u0012.\u0001) ref this).set_DirArrowDistances(((\u0018.\u0001) another).get_DirArrowDistances());
    ((buClipperBase) ref this).set_CamID(((\u0081.\u0001) another).get_CamID());
    ((buClipperBase) ref this).set_SceneName(((buClipperBase) another).get_SceneName());
    ((buClipperBase) ref this).set_EntityName(((buClipperBase) another).get_EntityName());
    ((buClipperBase) ref this).set_ActionName(((buClipperBase) another).get_ActionName());
    ((buClipperBase) ref this).set_GroupIdIndex(((buClipperBase) another).get_GroupIdIndex());
    ((buClipper) ref this).set_RefEntity(((buClipper) another).get_RefEntity());
    if (!(((buClipper) another).get_infoBasePoint() != (Point3D) null))
      return;
    ((buClipper) ref this).set_infoBasePoint((Point3D) ((buClipper) another).get_infoBasePoint().Clone());
  }

  public IntPoint(List<Point3D> points)
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
    ((LinearPath) ref this).\u002Ector((ICollection<Point3D>) points);
  }

  public IntPoint(params Point3D[] points)
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
    ((LinearPath) ref this).\u002Ector(points);
  }
}
