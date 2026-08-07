// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.EntitiesGroup
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class EntitiesGroup : buSerilization5
{
  public Point3D pntMax;
  public Point3D pntCurrent;

  public EntitiesGroup(pageInfo Data)
  {
    ((screenInfo) this).EntitiesBoxSize = new Point3D();
    // ISSUE: explicit constructor call
    base.\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) Data, ref CopiedClass);
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

  public EntitiesGroup()
  {
    ((screenInfo) this).pntMin = new Point3D();
    this.pntMax = new Point3D();
    this.pntCurrent = new Point3D();
    ((buEntitiesGroup) this).ScreenSize = new Length3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
