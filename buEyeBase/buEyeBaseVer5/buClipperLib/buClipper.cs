// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buClipperLib.buClipper
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

public class buClipper : buClipperBase
{
  public ShapeLeadInOut LeadInOut;
  public Plane planeOperation;
  public Point3D CornerPoint;
  public Point3D BasePoint;
  public Point3D Offset;
  public Point3D CalculatedPoint;
  public buLinearDim dimHorizontal;
  public buLinearDim dimVertical;
  public Vector3D CornerDirection;
  public List<buEntity> entitiesShape;
  public List<buEntity> entitiesCam;
  public List<buEntity> entitiesDim;
  public List<buEntity> entitiesRef;
  public List<Entity> entitySolid;
  public List<Entity> entityWireframe;
  public List<Clamper> Clampers;
  public List<ShapeMultiCenterData> multiCenter;
  public camTp Cam;
  public camParameters5 CamPar;

  [CompilerGenerated]
  [SpecialName]
  public int get_RefEntity() => ((Router3AXCAM) this).\u0003;

  [CompilerGenerated]
  [SpecialName]
  public void set_RefEntity(int value) => ((Router3AXCAM) this).\u0003 = value;

  [CompilerGenerated]
  [SpecialName]
  public Point3D get_infoBasePoint() => ((Router3AXCAM) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_infoBasePoint(Point3D value) => ((Router3AXCAM) this).\u0001 = value;

  public abstract void m001980();

  public buClipper(Point another)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Point) this).\u002Ector(another);
    if (!(another is buSelectionPoint))
      return;
    this.set_Tags(((buClipper) another).get_Tags());
    this.set_CamID(((buClipper) another).get_CamID());
    this.set_SceneName(((buClipper) another).get_SceneName());
    this.set_EntityName(((buClipper) another).get_EntityName());
    this.set_ActionName(((buClipper) another).get_ActionName());
    this.set_GroupIdIndex(((buClipper) another).get_GroupIdIndex());
    this.set_CamSelected(((buClipper) another).get_CamSelected());
    this.set_OrientationC(((buClipper) another).get_OrientationC());
  }

  public buClipper(Point2D p)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Point) this).\u002Ector(p);
  }

  public buClipper(Point3D p)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Point) this).\u002Ector(p);
  }

  public buClipper(double x, double y)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Point) this).\u002Ector(x, y);
  }

  public buClipper(Point2D p, float size)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Point) this).\u002Ector(p, size);
  }

  public buClipper(Point3D p, float size)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Point) this).\u002Ector(p, size);
  }

  public buClipper(Plane sketchPlane, Point2D p)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Point) this).\u002Ector(sketchPlane, p);
  }

  public buClipper(double x, double y, double z)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Point) this).\u002Ector(x, y, z);
  }

  public buClipper(Plane sketchPlane, double x, double y)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Point) this).\u002Ector(sketchPlane, x, y);
  }

  public buClipper(double x, double y, double z, float size)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCamPlane) this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Point) this).\u002Ector(x, y, z, size);
  }

  public override string ToString()
  {
    // ISSUE: explicit non-virtual call
    return "Point - S " + __nonvirtual (((Point) this).StartPoint).ToString();
  }

  [CompilerGenerated]
  [SpecialName]
  public string get_Tags() => ((Router3AXCAM) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_Tags(string value) => ((Router3AXCAM) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public int get_CamID() => ((Router3AXCAM) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public new void set_CamID(int value) => ((Router3AXCAM) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public new string get_SceneName() => ((Router3AXCAM) this).\u0002;

  [CompilerGenerated]
  [SpecialName]
  public new void set_SceneName(string value) => ((Router3AXCAM) this).\u0002 = value;

  [CompilerGenerated]
  [SpecialName]
  public new string get_EntityName() => ((Router3AXCAM) this).\u0003;

  [CompilerGenerated]
  [SpecialName]
  public new void set_EntityName(string value) => ((Router3AXCAM) this).\u0003 = value;

  [CompilerGenerated]
  [SpecialName]
  public new string get_ActionName() => ((Router3AXCamPlane) this).\u0004;

  [CompilerGenerated]
  [SpecialName]
  public new void set_ActionName(string value) => ((Router3AXCamPlane) this).\u0004 = value;

  [CompilerGenerated]
  [SpecialName]
  public new int get_GroupIdIndex() => ((Router3AXCamPlane) this).\u0002;

  [CompilerGenerated]
  [SpecialName]
  public new void set_GroupIdIndex(int value) => ((Router3AXCamPlane) this).\u0002 = value;

  [CompilerGenerated]
  [SpecialName]
  public bool get_CamSelected() => ((Router3AXCamPlane) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_CamSelected(bool value) => ((Router3AXCamPlane) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public double get_OrientationC() => ((Router3AXCamPlane) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_OrientationC(double value) => ((Router3AXCamPlane) this).\u0001 = value;

  public buClipper.ZFillCallback ZFillFunction
  {
    [CompilerGenerated, SpecialName] get => ((PipeBendTempVars) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((PipeBendTempVars) this).\u0001 = value;
  }

  public bool ReverseSolution
  {
    [CompilerGenerated, SpecialName] get => ((PipeBendTempVars) this).\u0003;
    [CompilerGenerated, SpecialName] set => ((PipeBendTempVars) this).\u0003 = value;
  }

  public bool StrictlySimple
  {
    [CompilerGenerated, SpecialName] get => ((PipeBendTempVars) this).\u0004;
    [CompilerGenerated, SpecialName] set => ((PipeBendTempVars) this).\u0004 = value;
  }

  public delegate void ZFillCallback();

  internal enum \u0001
  {
  }
}
