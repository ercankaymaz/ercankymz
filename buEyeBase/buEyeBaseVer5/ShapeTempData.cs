// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ShapeTempData
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
public class ShapeTempData : buSerilization5
{
  public bool ManuelDepthEnable;
  public bool EachLayer;

  public ShapeTempData(SortFilter data)
  {
    ((SortbuFilter) this).NotSelectEntities = new List<Entity>();
    ((SortbuOptions) this).SelectableEntities = new List<Entity>();
    ((SortbuOptions) this).NotSelectIndex = new List<int>();
    ((SortbuOptions) this).SelectableIndex = new List<int>();
    ((SortbuOptions) this).NotSelectColor = new List<Color>();
    ((SortbuOptions) this).SelectableColor = new List<Color>();
    ((SortbuOptions) this).MostClosestType = MostClosestPointType.OnlyNotCamSelectedEntities;
    ((SortbuOptions) this).UsePointEntities = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
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
    ((SortbuOptions) this).NotSelectColor = new List<Color>();
    for (int index = 0; index <= ((SortbuOptions) data).NotSelectColor.Count - 1; ++index)
      ((SortbuOptions) this).NotSelectColor.Add(((SortbuOptions) data).NotSelectColor[index]);
    ((SortbuOptions) this).SelectableColor = new List<Color>();
    for (int index = 0; index <= ((SortbuOptions) data).SelectableColor.Count - 1; ++index)
      ((SortbuOptions) this).SelectableColor.Add(((SortbuOptions) data).SelectableColor[index]);
    ((SortbuOptions) this).NotSelectIndex = new List<int>();
    for (int index = 0; index <= ((SortbuOptions) data).NotSelectIndex.Count - 1; ++index)
      ((SortbuOptions) this).NotSelectIndex.Add(((SortbuOptions) data).NotSelectIndex[index]);
    ((SortbuOptions) this).SelectableIndex = new List<int>();
    for (int index = 0; index <= ((SortbuOptions) data).SelectableIndex.Count - 1; ++index)
      ((SortbuOptions) this).SelectableIndex.Add(((SortbuOptions) data).SelectableIndex[index]);
    ((SortbuFilter) this).NotSelectEntities = new List<Entity>();
    for (int index = 0; index <= ((SortbuFilter) data).NotSelectEntities.Count - 1; ++index)
      ((SortbuFilter) this).NotSelectEntities.Add((Entity) ((SortbuFilter) data).NotSelectEntities[index].Clone());
    ((SortbuOptions) this).SelectableEntities = new List<Entity>();
    for (int index = 0; index <= ((SortbuOptions) data).SelectableEntities.Count - 1; ++index)
      ((SortbuOptions) this).SelectableEntities.Add((Entity) ((SortbuOptions) data).SelectableEntities[index].Clone());
  }

  public ShapeTempData()
  {
    ((SortbuOptions) this).Resolution = 0.001;
    ((SortbuOptions) this).UsePlane = false;
    ((SortbuOptions) this).UseCamSelectedProps = false;
    ((SortbuOptions) this).UseEntitySelectedProps = false;
    ((SortbuOptions) this).UseStopPoint = false;
    ((SortbuOptions) this).isFirstPointCatchFromStartPointForDrawSequence = false;
    ((SortbuOptions) this).WhenFoundClosedCurveThenFinish = false;
    ((SortbuOptions) this).StartPoint = new Point3D();
    ((SortbuOptions) this).EndPoint = new Point3D();
    ((SortbuOptions) this).StopPoint = (Point3D) null;
    ((SortbuOptions) this).ConstantPoint = new Point3D();
    ((SortbuOptions) this).AlwaysUseZeroPointAfterJump = false;
    ((SortbuOptions) this).If2PointAtFirstPointUseSecondOne = false;
    ((SortbuOptions) this).IntersectionRules = SortingIntersectionRulesType.LowerIndex;
    ((SortbuOptions) this).NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
    ((SortbuOptions) this).FirstRules = SortingFirstCatchRulesType.LowerIndex;
    ((SortbuOptions) this).AngleLimitation = false;
    ((SortbuOptions) this).UseBoxBoundingForMinMax = false;
    ((SortbuOptions) this).AngleMinLimit = -360.0;
    ((SortbuCamData) this).AngleMaxLimit = 360.0;
    ((SortbuResult) this).ClickList = new List<Point3D>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ShapeTempData(SortOptions data)
  {
    ((SortbuOptions) this).Resolution = 0.001;
    ((SortbuOptions) this).UsePlane = false;
    ((SortbuOptions) this).UseCamSelectedProps = false;
    ((SortbuOptions) this).UseEntitySelectedProps = false;
    ((SortbuOptions) this).UseStopPoint = false;
    ((SortbuOptions) this).isFirstPointCatchFromStartPointForDrawSequence = false;
    ((SortbuOptions) this).WhenFoundClosedCurveThenFinish = false;
    ((SortbuOptions) this).StartPoint = new Point3D();
    ((SortbuOptions) this).EndPoint = new Point3D();
    ((SortbuOptions) this).StopPoint = (Point3D) null;
    ((SortbuOptions) this).ConstantPoint = new Point3D();
    ((SortbuOptions) this).AlwaysUseZeroPointAfterJump = false;
    ((SortbuOptions) this).If2PointAtFirstPointUseSecondOne = false;
    ((SortbuOptions) this).IntersectionRules = SortingIntersectionRulesType.LowerIndex;
    ((SortbuOptions) this).NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
    ((SortbuOptions) this).FirstRules = SortingFirstCatchRulesType.LowerIndex;
    ((SortbuOptions) this).AngleLimitation = false;
    ((SortbuOptions) this).UseBoxBoundingForMinMax = false;
    ((SortbuOptions) this).AngleMinLimit = -360.0;
    ((SortbuCamData) this).AngleMaxLimit = 360.0;
    ((SortbuResult) this).ClickList = new List<Point3D>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
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
    if (((SortbuOptions) data).StartPoint != (Point3D) null)
      ((SortbuOptions) this).StartPoint = new Point3D(((SortbuOptions) data).StartPoint.X, ((SortbuOptions) data).StartPoint.Y, ((SortbuOptions) data).StartPoint.Z);
    if (((SortbuOptions) data).EndPoint != (Point3D) null)
      ((SortbuOptions) this).EndPoint = new Point3D(((SortbuOptions) data).EndPoint.X, ((SortbuOptions) data).EndPoint.Y, ((SortbuOptions) data).EndPoint.Z);
    if (((SortbuOptions) data).StopPoint != (Point3D) null)
      ((SortbuOptions) this).StopPoint = new Point3D(((SortbuOptions) data).StopPoint.X, ((SortbuOptions) data).StopPoint.Y, ((SortbuOptions) data).StopPoint.Z);
    if (((SortbuOptions) data).ConstantPoint != (Point3D) null)
      ((SortbuOptions) this).ConstantPoint = new Point3D(((SortbuOptions) data).ConstantPoint.X, ((SortbuOptions) data).ConstantPoint.Y, ((SortbuOptions) data).ConstantPoint.Z);
    ((SortbuResult) this).ClickList = new List<Point3D>();
    for (int index = 0; index <= ((SortbuResult) data).ClickList.Count - 1; ++index)
      ((SortbuResult) this).ClickList.Add(new Point3D(((SortbuResult) data).ClickList[index].X, ((SortbuResult) data).ClickList[index].Y, ((SortbuResult) data).ClickList[index].Z));
  }
}
