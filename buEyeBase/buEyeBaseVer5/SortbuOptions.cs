// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortbuOptions
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SortbuOptions : buSerilization5
{
  public List<Entity> SelectableEntities;
  public List<int> NotSelectIndex;
  public List<int> SelectableIndex;
  public List<Color> NotSelectColor;
  public List<Color> SelectableColor;
  public MostClosestPointType MostClosestType;
  public bool UsePointEntities;
  public double Resolution;
  public bool UsePlane;
  public bool UseCamSelectedProps;
  public bool UseEntitySelectedProps;
  public bool UseStopPoint;
  public bool isFirstPointCatchFromStartPointForDrawSequence;
  public bool WhenFoundClosedCurveThenFinish;
  public Point3D StartPoint;
  public Point3D EndPoint;
  public Point3D StopPoint;
  public Point3D ConstantPoint;
  public bool AlwaysUseZeroPointAfterJump;
  public bool If2PointAtFirstPointUseSecondOne;
  public SortingIntersectionRulesType IntersectionRules;
  public SortingNextGroupFindRulesType NextGroupRules;
  public SortingFirstCatchRulesType FirstRules;
  public bool AngleLimitation;
  public bool UseBoxBoundingForMinMax;
  public double AngleMinLimit;

  public SortbuOptions()
  {
    ((FlatViewSettings) this).MinPoint = new Point3D();
    ((FlatViewSettings) this).MidPoint = new Point3D();
    ((MachineSimulation) this).MaxPoint = new Point3D();
    ((MachineSimulation) this).Delta = new Vector3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public SortbuOptions(BoxSize5 box)
  {
    ((FlatViewSettings) this).MinPoint = new Point3D();
    ((FlatViewSettings) this).MidPoint = new Point3D();
    ((MachineSimulation) this).MaxPoint = new Point3D();
    ((MachineSimulation) this).Delta = new Vector3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) box, ref CopiedClass);
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
}
