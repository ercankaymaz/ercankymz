// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SewingVertex
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Geometry;
using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SewingVertex : buSerilization5
{
  public bool CurveDelete;
  public bool DimensionDelete;
  public bool RegionDelete;
  public bool PictureDelete;
  public bool TextDelete;
  public bool MeshDelete;
  public bool BrepDelete;

  public SewingVertex(MoveEventFormVars data)
  {
    ((MirrorEventFormVars) this).Alignment = ContentAlignment.BottomLeft;
    ((MirrorEventFormVars) this).CatchPoint = new Point3D();
    ((MirrorEventFormVars) this).ShowZ = true;
    ((MirrorEventFormVars) this).ShowAligment = true;
    ((EntityShapeInfo) this).isCoordinateMode = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public SewingVertex()
  {
    ((EntityShapeInfo) this).Alignment = ContentAlignment.BottomLeft;
    ((EntityShapeInfo) this).Ratio = new Point3D();
    ((EntityShapeInfo) this).ShowAligment = true;
    ((EntityShapeInfo) this).isLengthMode = true;
    ((EntityShapeInfo) this).KeepRatio = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public SewingVertex(ScaleEventFormVars data)
  {
    ((EntityShapeInfo) this).Alignment = ContentAlignment.BottomLeft;
    ((EntityShapeInfo) this).Ratio = new Point3D();
    ((EntityShapeInfo) this).ShowAligment = true;
    ((EntityShapeInfo) this).isLengthMode = true;
    ((EntityShapeInfo) this).KeepRatio = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public SewingVertex()
  {
    ((EntityShapeInfo) this).LineEnable = true;
    ((EntityShapeInfo) this).PolylineEnable = true;
    ((EntityShapeInfo) this).CircleEnable = true;
    ((EntityShapeInfo) this).ArcEnable = true;
    ((EntityShapeInfo) this).EllipseEnable = true;
    ((EntityShapeInfo) this).CompositeCurveEnable = true;
    ((EntityShapeInfo) this).CurveEnable = true;
    ((EntityShapeInfo) this).LineLength = 10.0;
    ((EditorCustomData) this).PolylineLength = 10.0;
    ((EditorCustomData) this).CircleLength = 10.0;
    ((SketchAnalyseData) this).ArcLength = 10.0;
    ((SketchAnalyseData) this).EllipseLength = 10.0;
    ((SketchAnalyseSetData) this).CompositeCurveLength = 10.0;
    ((SewingInfo) this).CurveLength = 10.0;
    ((SewingInfo) this).ConvertAllToPolyline = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public SewingVertex(DevideEventFormVars data)
  {
    ((EntityShapeInfo) this).LineEnable = true;
    ((EntityShapeInfo) this).PolylineEnable = true;
    ((EntityShapeInfo) this).CircleEnable = true;
    ((EntityShapeInfo) this).ArcEnable = true;
    ((EntityShapeInfo) this).EllipseEnable = true;
    ((EntityShapeInfo) this).CompositeCurveEnable = true;
    ((EntityShapeInfo) this).CurveEnable = true;
    ((EntityShapeInfo) this).LineLength = 10.0;
    ((EditorCustomData) this).PolylineLength = 10.0;
    ((EditorCustomData) this).CircleLength = 10.0;
    ((SketchAnalyseData) this).ArcLength = 10.0;
    ((SketchAnalyseData) this).EllipseLength = 10.0;
    ((SketchAnalyseSetData) this).CompositeCurveLength = 10.0;
    ((SewingInfo) this).CurveLength = 10.0;
    ((SewingInfo) this).ConvertAllToPolyline = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public SewingVertex()
  {
    ((SewingInfo) this).PointDelete = false;
    ((SewingInfo) this).PolylinDelete = false;
    ((SewingInfo) this).LineDelete = false;
    ((SewingInfo) this).CircleDelete = false;
    ((SewingInfo) this).ArcDelete = false;
    ((SewingInfo) this).EllipseDelete = false;
    ((SewingInfo) this).EllipseArcDelete = false;
    ((SewingInfo) this).CompositeCurveDelete = false;
    this.CurveDelete = false;
    this.DimensionDelete = false;
    this.RegionDelete = false;
    this.PictureDelete = false;
    this.TextDelete = false;
    this.MeshDelete = false;
    this.BrepDelete = false;
    ((SewingCode) this).SurfaceDelete = false;
    ((SewingCode) this).SolidDelete = false;
    ((SewingCode) this).HatchDelete = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
