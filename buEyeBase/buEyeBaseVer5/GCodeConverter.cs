// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.GCodeConverter
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class GCodeConverter : buSerilization5
{
  public double Thickness;
  public double Angle;
  public double AngleOffset;
  public int Index;
  public ProfilePlaneDef PlaneType;
  public static byte f000858;
  public List<buEntity> entitiesPoint;
  public List<buEntity> entitiesCurve;
  public List<buEntity> entitiesText;
  public List<buEntity> entitiesSolid;
  public List<buEntity> entitiesDimension;
  public List<buEntity> entitiesImage;
  public List<SelectionEntity> Selections;
  public Point3D SelectionBoxMin;
  public Point3D SelectionBoxMid;
  public Point3D SelectionBoxMax;
  public List<Point3D> ClickList;
  public int Index;

  public GCodeConverter(ShapeArray data)
  {
    ((ShapeRuntimeData) this).CircularEnable = false;
    ((ShapeRuntimeData) this).CircularCount = 1;
    ((ShapeRuntimeData) this).CircularAngle = 45.0;
    ((ShapeRuntimeData) this).LineerEnable = false;
    ((ShapeRuntimeData) this).LineerXCount = 1;
    ((ShapeRuntimeData) this).LineerXDistance = 100.0;
    ((ShapeRuntimeData) this).LineerYCount = 1;
    ((ShapeRuntimeData) this).LineerYDistance = 100.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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

  public override string ToString()
  {
    string str;
    if (((ShapeRuntimeData) this).LineerEnable & ((ShapeRuntimeData) this).CircularEnable)
      str = $"Lineer: {((ShapeRuntimeData) this).LineerEnable.ToString()} , Circular: {((ShapeRuntimeData) this).CircularEnable.ToString()}";
    else if (((ShapeRuntimeData) this).LineerEnable & !((ShapeRuntimeData) this).CircularEnable)
      str = $"Lineer: {((ShapeRuntimeData) this).LineerEnable.ToString()} , X Dis: {((ShapeRuntimeData) this).LineerXDistance.ToString("f2")} , X Cnt: {((ShapeRuntimeData) this).LineerXCount.ToString("f2")} , Y Dis: {((ShapeRuntimeData) this).LineerYDistance.ToString("f2")} , Y Cnt: {((ShapeRuntimeData) this).LineerYCount.ToString("f2")}";
    else if (((ShapeRuntimeData) this).CircularEnable & !((ShapeRuntimeData) this).LineerEnable)
      str = $"Circular: {((ShapeRuntimeData) this).CircularEnable.ToString()} , Angle: {((ShapeRuntimeData) this).CircularAngle.ToString("f2")} , Cnt: {((ShapeRuntimeData) this).CircularCount.ToString()}";
    else
      str = $"Lineer: {((ShapeRuntimeData) this).LineerEnable.ToString()} , Circular: {((ShapeRuntimeData) this).CircularEnable.ToString()}";
    return str;
  }

  public abstract void m00030A();

  public GCodeConverter()
  {
    ((ShapeRuntimeData) this).MirrorEnable = false;
    ((ShapeRuntimeData) this).MirrorAxis = MirrorAxisXYType.X;
    ((ShapeRuntimeData) this).MirrorLocation = MinCenterMaxType.Min;
    ((ShapeRuntimeData) this).MirrorDistance = 0.0;
    ((ShapeRuntimeData) this).MirrorMode = MirrorModeType.FromCenter;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
