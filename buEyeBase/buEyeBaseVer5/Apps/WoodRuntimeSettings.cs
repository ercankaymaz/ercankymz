// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.WoodRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class WoodRuntimeSettings : buSerilization5
{
  public double VShapeAngleWidth;
  public double VShapeAngleRoughDepth;
  public double VShapeAngleFinishDepth;
  public double VShapeAngleRoughVel;
  public double VShapeAngleFinishVel;

  public void SetNotchOnContour(
    List<Entity> NotchEntities,
    List<Entity> OutterEntities,
    bool VNotch,
    bool INotch,
    ref List<List<Entity>> calcEntities)
  {
    List<Entity> BaseRefEntities = new List<Entity>();
    List<Entity> entityList = new List<Entity>();
    for (int index1 = 0; index1 <= OutterEntities.Count - 1; ++index1)
    {
      ICurve outterEntity = OutterEntities[index1] as ICurve;
      List<Point3D> point3DList1 = new List<Point3D>();
      List<Point3D> points = new List<Point3D>();
      for (int index2 = 0; index2 <= NotchEntities.Count - 1; ++index2)
      {
        bool flag = true;
        if (((CutterRuntimeSettings) NotchEntities[index2].EntityData).get_infoString() == nameof (INotch) & !INotch)
          flag = false;
        if (((CutterRuntimeSettings) NotchEntities[index2].EntityData).get_infoString() == nameof (VNotch) & !VNotch)
          flag = false;
        if (flag)
        {
          Point3D point3D1 = F_NotchEdit.ToPoint3D(((ICurve) NotchEntities[index2]).StartPoint);
          Point3D point3D2 = F_NotchEdit.ToPoint3D(((ICurve) NotchEntities[index2]).EndPoint);
          if (((F_AnalyseSettings) buCall.\u0001).isPointInsideEntity(outterEntity, point3D1, buSystem.resolutionCompare) & ((F_AnalyseSettings) buCall.\u0001).isPointInsideEntity(outterEntity, point3D2, buSystem.resolutionCompare))
          {
            List<Point3D> point3DList2 = new List<Point3D>();
            points.Add(F_NotchEdit.ToPoint3D(point3D1));
            points.Add(F_NotchEdit.ToPoint3D(point3D2));
            point3DList1.Add(F_NotchEdit.ToPoint3D(point3D1));
            point3DList1.Add(F_NotchEdit.ToPoint3D(point3D1));
          }
          else if (((F_AnalyseSettings) buCall.\u0001).isPointInsideEntity(outterEntity, point3D1, buSystem.resolutionCompare))
          {
            List<Point3D> point3DList3 = new List<Point3D>();
            points.Add(F_NotchEdit.ToPoint3D(point3D1));
          }
          else if (((F_AnalyseSettings) buCall.\u0001).isPointInsideEntity(outterEntity, point3D2, buSystem.resolutionCompare))
          {
            List<Point3D> point3DList4 = new List<Point3D>();
            points.Add(F_NotchEdit.ToPoint3D(point3D2));
          }
        }
      }
      if (points.Count > 0)
      {
        ICurve[] segments = (ICurve[]) null;
        outterEntity.SplitBy((IList<Point3D>) points, out segments);
        if (segments != null)
        {
          for (int index3 = 0; index3 <= segments.Length - 1; ++index3)
          {
            for (int index4 = NotchEntities.Count - 1; index4 >= 0; --index4)
            {
              ICurve notchEntity = NotchEntities[index4] as ICurve;
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              if (buConversion5.\u003C\u003Ec.EQ(segments[index3].StartPoint, notchEntity.StartPoint, 0.01) & buConversion5.\u003C\u003Ec.EQ(segments[index3].EndPoint, notchEntity.EndPoint, 0.01))
              {
                segments[index3] = (ICurve) buVector5.CopyEntities(NotchEntities[index4]);
                NotchEntities.RemoveAt(index4);
              }
              else
              {
                // ISSUE: reference to a compiler-generated method
                // ISSUE: reference to a compiler-generated method
                if (buConversion5.\u003C\u003Ec.EQ(segments[index3].EndPoint, notchEntity.StartPoint, 0.01) & buConversion5.\u003C\u003Ec.EQ(segments[index3].StartPoint, notchEntity.EndPoint, 0.01))
                {
                  segments[index3] = (ICurve) buVector5.CopyEntities(NotchEntities[index4]);
                  NotchEntities.RemoveAt(index4);
                }
              }
            }
          }
          if (NotchEntities.Count > 0)
          {
            for (int index5 = NotchEntities.Count - 1; index5 >= 0; --index5)
              BaseRefEntities.Add(buVector5.CopyEntities(NotchEntities[index5]));
            for (int index6 = 0; index6 <= segments.Length - 1; ++index6)
              BaseRefEntities.Add(buVector5.CopyEntities((Entity) segments[index6]));
          }
          else
          {
            for (int index7 = 0; index7 <= segments.Length - 1; ++index7)
              BaseRefEntities.Add(buVector5.CopyEntities((Entity) segments[index7]));
          }
        }
        else
          entityList.Add(buVector5.CopyEntities(OutterEntities[index1]));
      }
      else
        entityList.Add(buVector5.CopyEntities(OutterEntities[index1]));
    }
    if (entityList.Count > 0)
    {
      calcEntities.Clear();
      calcEntities = new List<List<Entity>>();
      calcEntities.Add(entityList);
    }
    else
    {
      if (BaseRefEntities.Count <= 0)
        return;
      SortSettings Settings = (SortSettings) new ShapeRuntimeData();
      SortResult Result = (SortResult) new CurveToSurfaceSettingsType();
      List<Entity> SortedEntities = new List<Entity>();
      ((SortbuOptions) ((SortbuFilter) Settings).Option).IntersectionRules = SortingIntersectionRulesType.LowerIndex;
      ((SortbuOptions) ((SortbuFilter) Settings).Option).NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
      calcEntities.Clear();
      calcEntities = new List<List<Entity>>();
      buCall.\u0001.SortEntitiesByRefPoint(((ICurve) OutterEntities[0]).StartPoint, ref BaseRefEntities, Settings, ref SortedEntities, ref Result);
      buCall.\u0001.EntitiesSplitByUpperLine(SortedEntities, ref calcEntities);
    }
  }
}
