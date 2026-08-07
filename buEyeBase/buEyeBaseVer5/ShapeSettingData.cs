// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ShapeSettingData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ShapeSettingData : buSerilization5
{
  public Point3D FirstPoint;

  public abstract void m0002D9();

  public ShapeSettingData()
  {
    ((SortResolutionSet) this).Solid = false;
    ((SortPointClickData) this).SingX = 1.0;
    ((SortPointClickData) this).SingY = 1.0;
    ((SortPointClickData) this).SingZ = 1.0;
    ((SortPointClickData) this).RegenDeviation = 0.01;
    ((SortPointClickData) this).DepthOffset = 0.0;
    ((SortPointClickData) this).StartOffset = 0.0;
    ((SortPointClickData) this).SolidTolerance = 0.01;
    ((SortPointClickResult) this).LayerName = "";
    ((SortPointClickResult) this).SolidColor = Color.Green;
    ((SortPointClickResult) this).SolidDisableColor = Color.Gray;
    ((SortbuSettings) this).WireColor = Color.Black;
    ((SortbuSettings) this).entitiesCurve = (List<buEntity>) null;
    ((SortbuSettings) this).entitiesCurveList = (List<EntitiesList>) null;
    ((SortbuSettings) this).entitiesEngraving = (List<Entity>) null;
    ((SortbuFilter) this).DepthLevel = new List<double>();
    ((SortbuFilter) this).Size = new SizeObject();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ShapeSettingData(ShapeCreateParameters box)
  {
    ((SortResolutionSet) this).Solid = false;
    ((SortPointClickData) this).SingX = 1.0;
    ((SortPointClickData) this).SingY = 1.0;
    ((SortPointClickData) this).SingZ = 1.0;
    ((SortPointClickData) this).RegenDeviation = 0.01;
    ((SortPointClickData) this).DepthOffset = 0.0;
    ((SortPointClickData) this).StartOffset = 0.0;
    ((SortPointClickData) this).SolidTolerance = 0.01;
    ((SortPointClickResult) this).LayerName = "";
    ((SortPointClickResult) this).SolidColor = Color.Green;
    ((SortPointClickResult) this).SolidDisableColor = Color.Gray;
    ((SortbuSettings) this).WireColor = Color.Black;
    ((SortbuSettings) this).entitiesCurve = (List<buEntity>) null;
    ((SortbuSettings) this).entitiesCurveList = (List<EntitiesList>) null;
    ((SortbuSettings) this).entitiesEngraving = (List<Entity>) null;
    ((SortbuFilter) this).DepthLevel = new List<double>();
    ((SortbuFilter) this).Size = new SizeObject();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) box, ref CopiedClass);
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
    buFile5.Copy(((SortbuFilter) box).DepthLevel, ref ((SortbuFilter) this).DepthLevel);
  }
}
