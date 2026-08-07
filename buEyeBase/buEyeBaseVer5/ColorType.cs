// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ColorType
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ColorType : buSerilization5
{
  public Entity entityBall;
  public Point3D pntPlane;

  public ColorType()
  {
    ((ShapeRuntimeData) this).Sequence = -1;
    ((ShapeRuntimeData) this).pntFound = new Point3D();
    ((ShapeRuntimeData) this).FoundLocation = StartEndType.Start;
    ((ShapeRuntimeData) this).FoundDistance = 0.0;
    ((ShapeRuntimeData) this).isPointCatch = false;
    ((ShapeRuntimeData) this).isPointCatchAnyWay = false;
    ((ShapeRuntimeData) this).isPointCatchCamSelected = false;
    ((ShapeRuntimeData) this).pntCatch = new Point3D();
    ((ShapeRuntimeData) this).pntCatchCamSelected = new Point3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ColorType()
  {
    ((ShapeRuntimeData) this).MirrorData = (ShapeMirror) new GCodeConverter();
    ((ShapeRuntimeData) this).ArrayData = (ShapeArray) new ColorDrawType();
    ((ShapeRuntimeData) this).RotateDegree = 0.0;
    ((ShapeRuntimeData) this).HorizontanAngle = 0.0;
    ((ShapeRuntimeData) this).VerticalAngle = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ColorType(ShapeEdit data)
  {
    ((ShapeRuntimeData) this).MirrorData = (ShapeMirror) new GCodeConverter();
    ((ShapeRuntimeData) this).ArrayData = (ShapeArray) new ColorDrawType();
    ((ShapeRuntimeData) this).RotateDegree = 0.0;
    ((ShapeRuntimeData) this).HorizontanAngle = 0.0;
    ((ShapeRuntimeData) this).VerticalAngle = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    ((ShapeRuntimeData) this).MirrorData = (ShapeMirror) new GCodePoint5(((ShapeRuntimeData) data).MirrorData);
    ((ShapeRuntimeData) this).ArrayData = (ShapeArray) new GCodeConverter(((ShapeRuntimeData) data).ArrayData);
  }

  public void MmToInch()
  {
    ((ShapeRuntimeData) ((ShapeRuntimeData) this).ArrayData).LineerXDistance = Math.Round(((ShapeRuntimeData) ((ShapeRuntimeData) this).ArrayData).LineerXDistance * buSystem.MmToInchRatio, 5);
    ((ShapeRuntimeData) ((ShapeRuntimeData) this).ArrayData).LineerYDistance = Math.Round(((ShapeRuntimeData) ((ShapeRuntimeData) this).ArrayData).LineerYDistance * buSystem.MmToInchRatio, 5);
    ((ShapeRuntimeData) ((ShapeRuntimeData) this).MirrorData).MirrorDistance = Math.Round(((ShapeRuntimeData) ((ShapeRuntimeData) this).MirrorData).MirrorDistance * buSystem.MmToInchRatio, 5);
  }
}
