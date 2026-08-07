// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileJob
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileJob : buSerilization5
{
  public const DrillItemType Junktion = ; // Unable to render the field
  public const DrillItemType Profile = ; // Unable to render the field
  public const DrillItemType Text = ; // Unable to render the field

  public void IncreaseSheetUsedCountByID(ref List<buNestingSheet> Sheets, int ID)
  {
    try
    {
      for (int index = 0; index <= Sheets.Count - 1; ++index)
      {
        if (((ProfileItemCalc) Sheets[index]).ID == ID)
        {
          buNestingSheet buNestingSheet = Sheets[index];
          ((ProfileItemCalc) buNestingSheet).Used = ((ProfileItemCalc) buNestingSheet).Used + 1;
          ((ProfileItemCalc) Sheets[index]).Remain = ((ProfileItem) ((ProfileItemCalc) Sheets[index]).MaterialData).Quantity - ((ProfileItemCalc) Sheets[index]).Used;
        }
      }
    }
    catch (Exception ex)
    {
      string str = "ID:00400003";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void IncreasePartUsedCountByID(ref List<buNestingPart> Parts, int ID)
  {
    try
    {
      for (int index = 0; index <= Parts.Count - 1; ++index)
      {
        if (((ProfileOperation) Parts[index]).ID == ID)
        {
          buNestingPart buNestingPart = Parts[index];
          ((ProfileOperation) buNestingPart).Nested = ((ProfileOperation) buNestingPart).Nested + 1;
          ((ProfileOperation) Parts[index]).Remain = ((ProfileOperation) ((ProfileOperation) Parts[index]).PartData).Quantity - ((ProfileOperation) Parts[index]).Nested;
        }
      }
    }
    catch (Exception ex)
    {
      string str = "ID:00400004";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void ResetNestedCountAtPartLis(ref List<buNestingPart> Parts)
  {
    try
    {
      for (int index = 0; index <= Parts.Count - 1; ++index)
      {
        ((ProfileOperation) Parts[index]).Remain = ((ProfileOperation) ((ProfileOperation) Parts[index]).PartData).Quantity;
        ((ProfileOperation) Parts[index]).Nested = 0;
      }
    }
    catch (Exception ex)
    {
      string str = "ID:00400005";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void ResetNestedCountAtSheetLis(ref List<buNestingSheet> Sheets)
  {
    try
    {
      for (int index = 0; index <= Sheets.Count - 1; ++index)
      {
        ((ProfileItemCalc) Sheets[index]).Remain = ((ProfileItem) ((ProfileItemCalc) Sheets[index]).MaterialData).Quantity;
        ((ProfileItemCalc) Sheets[index]).Used = 0;
      }
    }
    catch (Exception ex)
    {
      string str = "ID:00400006";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void SheeatArea(buNestedSheet Sheet, LengthUnit Unit, ref double Area)
  {
    try
    {
      double num1 = 0.0;
      double num2 = 1.0;
      switch (Unit)
      {
        case LengthUnit.mm:
          num2 = 1.0;
          break;
        case LengthUnit.cm:
          num2 = 100.0;
          break;
        case LengthUnit.dm:
          num2 = 10000.0;
          break;
        case LengthUnit.m:
          num2 = 1000000.0;
          break;
        case LengthUnit.dam:
          num2 = 100000000.0;
          break;
        case LengthUnit.hm:
          num2 = 10000000000.0;
          break;
        case LengthUnit.km:
          num2 = 1000000000000.0;
          break;
      }
      if (((F_AnalyseResult) buCall.\u0001).IsClosed(((\u0084.\u0001) ((ProfileOperationDataNotch) Sheet).EntitiesGroup.Outside).Points))
        num1 = buCall.\u0001.PolygonArea(((\u0084.\u0001) ((ProfileOperationDataNotch) Sheet).EntitiesGroup.Outside).Points, Plane.XY);
      Area = num1 / num2;
    }
    catch (Exception ex)
    {
      string str = "ID:00400007";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void PartArea(buNestedPart Part, LengthUnit Unit, bool OnlyOutter, ref double Area)
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
      if (((F_AnalyseResult) buCall.\u0001).IsClosed(((\u0084.\u0001) ((ProfileOperationDataText) Part).EntitiesGroup.Outside).Points))
        num1 = buCall.\u0001.PolygonArea(((\u0084.\u0001) ((ProfileOperationDataText) Part).EntitiesGroup.Outside).Points, Plane.XY);
      else if (((F_AnalyseResult) buCall.\u0001).isEntitiesClosed(((\u0084.\u0001) ((ProfileOperationDataText) Part).EntitiesGroup.Outside).Entities))
      {
        List<Point3D> Points = new List<Point3D>();
        buCall.\u0001.EntitiesToPointsWithCamDirection(((\u0084.\u0001) ((ProfileOperationDataText) Part).EntitiesGroup.Outside).Entities, ref Points);
        num1 = buCall.\u0001.PolygonArea(Points, Plane.XY);
      }
      if (((ProfileOperationDataText) Part).EntitiesGroup.Inside != null)
      {
        for (int index = 0; index <= ((ProfileOperationDataText) Part).EntitiesGroup.Inside.Count - 1; ++index)
        {
          if (((\u0084.\u0001) ((ProfileOperationDataText) Part).EntitiesGroup.Inside[index]).Points != null)
          {
            if (((F_AnalyseResult) buCall.\u0001).IsClosed(((\u0084.\u0001) ((ProfileOperationDataText) Part).EntitiesGroup.Inside[index]).Points))
              num2 += buCall.\u0001.PolygonArea(((\u0084.\u0001) ((ProfileOperationDataText) Part).EntitiesGroup.Inside[index]).Points, Plane.XY);
            else if (((F_AnalyseResult) buCall.\u0001).isEntitiesClosed(((\u0084.\u0001) ((ProfileOperationDataText) Part).EntitiesGroup.Inside[index]).Entities))
            {
              List<Point3D> Points = new List<Point3D>();
              buCall.\u0001.EntitiesToPointsWithCamDirection(((\u0084.\u0001) ((ProfileOperationDataText) Part).EntitiesGroup.Inside[index]).Entities, ref Points);
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
}
