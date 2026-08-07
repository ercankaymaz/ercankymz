// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.GCodePoint5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class GCodePoint5 : buSerilization5
{
  public int SubIndex;
  public Entity SelectedEntity;
  public Entity SelectedSubEntity;
  public List<Entity> SelectedLinearPaths;
  public List<List<Point3D>> SelectedVertices;
  public Point3D BoxMin;
  public Point3D BoxMax;
  public Point3D pntClick;
  public Point3D pntClickEntityOver;
  public List<Point3D> EntitiesBoxPointList;
  public SelectionAlingmentPoints AlingPoints;
  public static byte f000870;
  public List<Point3D> MovePoints;
  public List<Point3D> TipPoints;
  public List<Point3D> BoxSizePoints;
  public List<Point3D> RotatePoints;
  public object Object;
  public string Explanation;

  public GCodePoint5(ShapeMirror data)
  {
    ((ShapeRuntimeData) this).MirrorEnable = false;
    ((ShapeRuntimeData) this).MirrorAxis = MirrorAxisXYType.X;
    ((ShapeRuntimeData) this).MirrorLocation = MinCenterMaxType.Min;
    ((ShapeRuntimeData) this).MirrorDistance = 0.0;
    ((ShapeRuntimeData) this).MirrorMode = MirrorModeType.FromCenter;
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
    return $"Enable :{((ShapeRuntimeData) this).MirrorEnable.ToString()} , Axis : {((ShapeRuntimeData) this).MirrorAxis.ToString()} , Location : {((ShapeRuntimeData) this).MirrorLocation.ToString()} , Mode : {((ShapeRuntimeData) this).MirrorMode.ToString()}";
  }

  public abstract void m00030E();
}
