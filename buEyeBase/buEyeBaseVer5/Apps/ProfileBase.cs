// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileBase
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileBase : buSerilization5
{
  public const DrillItemType Contouring = ; // Unable to render the field
  public const DrillItemType Contour = ; // Unable to render the field
  [SpecialName]
  public int value__;
  public const DrillCNCMode Fast = ; // Unable to render the field
  public const DrillCNCMode Plunge = ; // Unable to render the field
  public const DrillCNCMode Z1NoOffset = ; // Unable to render the field
  public const DrillCNCMode Z2NoOffset = ; // Unable to render the field

  public void PartArea(buNestingPart Part, LengthUnit Unit, bool OnlyOutter, ref double Area)
  {
    try
    {
      double num1 = 0.0;
      double num2 = 0.0;
      double num3 = 1.0;
      switch (Unit)
      {
        case LengthUnit.mm:
          num3 = 1.0;
          break;
        case LengthUnit.cm:
          num3 = 100.0;
          break;
        case LengthUnit.dm:
          num3 = 10000.0;
          break;
        case LengthUnit.m:
          num3 = 1000000.0;
          break;
        case LengthUnit.dam:
          num3 = 100000000.0;
          break;
        case LengthUnit.hm:
          num3 = 10000000000.0;
          break;
        case LengthUnit.km:
          num3 = 1000000000000.0;
          break;
      }
      if (((F_AnalyseResult) buCall.\u0001).IsClosed(((\u0084.\u0001) ((ProfileOperationRectangle) Part).EntitiesGroup.Outside).Points))
        num1 = buCall.\u0001.PolygonArea(((\u0084.\u0001) ((ProfileOperationRectangle) Part).EntitiesGroup.Outside).Points, Plane.XY);
      else if (((F_AnalyseResult) buCall.\u0001).isEntitiesClosed(((\u0084.\u0001) ((ProfileOperationRectangle) Part).EntitiesGroup.Outside).Entities))
      {
        List<Point3D> Points = new List<Point3D>();
        buCall.\u0001.EntitiesToPointsWithCamDirection(((\u0084.\u0001) ((ProfileOperationRectangle) Part).EntitiesGroup.Outside).Entities, ref Points);
        num1 = buCall.\u0001.PolygonArea(Points, Plane.XY);
      }
      if (((ProfileOperationRectangle) Part).EntitiesGroup.Inside != null)
      {
        for (int index = 0; index <= ((ProfileOperationRectangle) Part).EntitiesGroup.Inside.Count - 1; ++index)
        {
          if (((\u0084.\u0001) ((ProfileOperationRectangle) Part).EntitiesGroup.Inside[index]).Points != null)
          {
            if (((F_AnalyseResult) buCall.\u0001).IsClosed(((\u0084.\u0001) ((ProfileOperationRectangle) Part).EntitiesGroup.Inside[index]).Points))
              num2 += buCall.\u0001.PolygonArea(((\u0084.\u0001) ((ProfileOperationRectangle) Part).EntitiesGroup.Inside[index]).Points, Plane.XY);
            else if (((F_AnalyseResult) buCall.\u0001).isEntitiesClosed(((\u0084.\u0001) ((ProfileOperationRectangle) Part).EntitiesGroup.Inside[index]).Entities))
            {
              List<Point3D> Points = new List<Point3D>();
              buCall.\u0001.EntitiesToPointsWithCamDirection(((\u0084.\u0001) ((ProfileOperationRectangle) Part).EntitiesGroup.Inside[index]).Entities, ref Points);
              num2 += buCall.\u0001.PolygonArea(Points, Plane.XY);
            }
          }
        }
      }
      Area = num1 / num3 - num2 / num3;
      if (Area < 0.0)
        ;
    }
    catch (Exception ex)
    {
      string str = "ID:00400007";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void NestedPartsBoxAreaFromNestedSheet(
    buNestedSheet Sheet,
    ref Point3D pntMin,
    ref Point3D pntMax)
  {
    try
    {
      List<buEntity> refEntities = new List<buEntity>();
      for (int index1 = 0; index1 <= ((ProfileOperationDataNotch) Sheet).Parts.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ((\u0084.\u0001) ((ProfileOperationDataText) ((ProfileOperationDataNotch) Sheet).Parts[index1]).EntitiesGroup.Outside).Entities.Count - 1; ++index2)
          refEntities.Add(((\u0084.\u0001) ((ProfileOperationDataText) ((ProfileOperationDataNotch) Sheet).Parts[index1]).EntitiesGroup.Outside).Entities[index2]);
      }
      pntMin = new Point3D();
      pntMax = new Point3D();
      buCall.\u0001.BoxSizeCalculate(refEntities, ref pntMin, ref pntMax);
    }
    catch (Exception ex)
    {
      string str = "ID:00400008";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void NestedPartToEntity(
    buNestedPart Part,
    ref List<Entity> partEntities,
    ref List<List<Entity>> innerEntities,
    ref List<List<Entity>> auxEntities)
  {
    List<Entity> entityList = new List<Entity>();
    partEntities.Clear();
    partEntities = new List<Entity>();
    for (int index = 0; index <= ((\u0084.\u0001) ((ProfileOperationDataText) Part).EntitiesGroup.Outside).Entities.Count - 1; ++index)
    {
      Entity copiedEntity = (Entity) null;
      buAngularDim.Copy(((\u0084.\u0001) ((ProfileOperationDataText) Part).EntitiesGroup.Outside).Entities[index], ref copiedEntity);
      partEntities.Add(copiedEntity);
    }
    innerEntities.Clear();
    innerEntities = new List<List<Entity>>();
    if ((((ProfileOperationDataText) Part).EntitiesGroup.Inside == null ? 0 : (((ProfileOperationDataText) Part).EntitiesGroup.Inside.Count > 0 ? 1 : 0)) != 0)
    {
      for (int index = 0; index <= ((\u0084.\u0001) ((ProfileOperationDataText) Part).EntitiesGroup.Inside[index]).Entities.Count - 1; ++index)
      {
        List<Entity> copiedEntities = new List<Entity>();
        buDiametricDim.Copy(((\u0084.\u0001) ((ProfileOperationDataText) Part).EntitiesGroup.Inside[index]).Entities, ref copiedEntities);
        innerEntities.Add(copiedEntities);
      }
    }
    auxEntities.Clear();
    auxEntities = new List<List<Entity>>();
    if ((((ProfileOperationDataText) Part).EntitiesGroup.OpenEntities == null ? 0 : (((ProfileOperationDataText) Part).EntitiesGroup.OpenEntities.Count > 0 ? 1 : 0)) == 0)
      return;
    for (int index = 0; index <= ((ProfileOperationDataText) Part).EntitiesGroup.OpenEntities.Count - 1; ++index)
    {
      List<Entity> copiedEntities = new List<Entity>();
      buDiametricDim.Copy(((\u0084.\u0001) ((ProfileOperationDataText) Part).EntitiesGroup.OpenEntities[index]).Entities, ref copiedEntities);
      auxEntities.Add(copiedEntities);
    }
  }

  public void NestedPartToEntity(
    buNestedPart Part,
    bool isSolid,
    bool OnlyOutterSolid,
    ref List<Entity> calcEntities)
  {
    calcEntities = new List<Entity>();
    buDiametricDim.Copy(((ProfileOperationDataText) Part).EntitiesGroup, ref calcEntities, Solid: true, Text: true);
  }

  public void NestedPartToCutterEntity(
    buNestedPart Part,
    double DrillMainDiameter,
    double DrillAuxDiameter,
    ref CutterIsoEntities Entities,
    ref CutterIsoError Error)
  {
    List<Entity> entityList = new List<Entity>();
    int num = (int) MessageBox.Show("NotReady");
  }
}
