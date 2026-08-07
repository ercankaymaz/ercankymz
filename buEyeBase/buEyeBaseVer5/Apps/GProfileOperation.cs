// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.GProfileOperation
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buCore;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class GProfileOperation : buSerilization5
{
  public double RectangleMarginRight;
  public double RectangleMarginTop;
  public double RectangleMarginBottom;
  public double IrregularMargin;
  public bool DeleteSheetAfterImport;
  public bool SaveSheetsBeforeDeleted;
  public bool UseSmallAreaFirst;
  public string DefaultSheetName;
  public bool AddAutoSheetQuantityIfAvailable;
  public bool AddAutoSheetNameIfAvailable;
  public string AutoSheetNameRef;
  public string AutoSheetQuantityRef;
  public string AutoSheetNameEquality;
  public string AutoSheetQuantityEquality;
  public static List<string> Captions;
  public static byte f004242;
  public bool UseColorForSelection;
  public Color SelectionColor;
  public bool DeleteSelectedEntities;
  public double Thickness;
  public int Quantity;
  public string Name;
  public bool AddUselessEntities;
  public double LastSheetWidth;
  public double LastSheetHeight;
  public int LastSheetQuantity;
  public static List<string> Captions;
  public static byte f00424E;

  public void SheetRectangle(double Width, double Height, ref buNestingSheet Sheet)
  {
    buEntity rectangleEntity = (buEntity) null;
    buCall.\u0001.DrawRectangle(new Point3D(), Width, Height, Plane.XY, ref rectangleEntity);
    ((ProfileItemCalc) Sheet).EntitiesGroup = new buEntitiesGroup();
    ((\u0084.\u0001) ((ProfileItemCalc) Sheet).EntitiesGroup.Outside).Entities.Add(rectangleEntity);
    ((\u0084.\u0001) ((ProfileItemCalc) Sheet).EntitiesGroup.Outside).Points = new List<Point3D>();
    buCall.\u0001.EntitiesToPointsWithCamDirection(((\u0084.\u0001) ((ProfileItemCalc) Sheet).EntitiesGroup.Outside).Entities, ref ((\u0084.\u0001) ((ProfileItemCalc) Sheet).EntitiesGroup.Outside).Points);
    Entity entSurface = (Entity) null;
    buCall.\u0001.surfaceFromOutterInner(((ProfileItemCalc) Sheet).EntitiesGroup, 0.2, ref entSurface);
    if (entSurface == null)
      return;
    ((DimensionGroup) ((ProfileItemCalc) Sheet).EntitiesGroup).Solid = (buEntityList) new buArcCam();
    buEntity copiedEntity = (buEntity) null;
    buAngularDim.Copy(entSurface, ref copiedEntity);
    if (copiedEntity == null)
      return;
    ((\u0084.\u0001) ((DimensionGroup) ((ProfileItemCalc) Sheet).EntitiesGroup).Solid).Entities.Add(copiedEntity);
  }

  public void PartRectangle(double Width, double Height, ref buNestingPart Part)
  {
    buEntity rectangleEntity = (buEntity) null;
    buCall.\u0001.DrawRectangle(new Point3D(), Width, Height, Plane.XY, ref rectangleEntity);
    ((ProfileOperationRectangle) Part).EntitiesGroup = new buEntitiesGroup();
    ((\u0084.\u0001) ((ProfileOperationRectangle) Part).EntitiesGroup.Outside).Entities.Add(rectangleEntity);
    ((\u0084.\u0001) ((ProfileOperationRectangle) Part).EntitiesGroup.Outside).Points = new List<Point3D>();
    buCall.\u0001.EntitiesToPointsWithCamDirection(((\u0084.\u0001) ((ProfileOperationRectangle) Part).EntitiesGroup.Outside).Entities, ref ((\u0084.\u0001) ((ProfileOperationRectangle) Part).EntitiesGroup.Outside).Points);
    Entity entSurface = (Entity) null;
    buCall.\u0001.surfaceFromOutterInner(((ProfileOperationRectangle) Part).EntitiesGroup, 0.2, ref entSurface);
    if (entSurface == null)
      return;
    ((DimensionGroup) ((ProfileOperationRectangle) Part).EntitiesGroup).Solid = (buEntityList) new buArcCam();
    buEntity copiedEntity = (buEntity) null;
    buAngularDim.Copy(entSurface, ref copiedEntity);
    if (copiedEntity == null)
      return;
    ((\u0084.\u0001) ((DimensionGroup) ((ProfileOperationRectangle) Part).EntitiesGroup).Solid).Entities.Add(copiedEntity);
  }

  public void SaveNesting(string FileName, List<buNestingPart> Parts, List<buNestingSheet> Sheets)
  {
    this.SaveNesting(FileName, Parts, Sheets, (buNestedResult) null, (buNestingVar) null);
  }

  public void SaveNesting(
    string FileName,
    List<buNestingPart> Parts,
    List<buNestingSheet> Sheets,
    buNestingVar Parameters)
  {
    this.SaveNesting(FileName, Parts, Sheets, (buNestedResult) null, Parameters);
  }

  public void SaveNesting(
    string FileName,
    List<buNestingPart> Parts,
    List<buNestingSheet> Sheets,
    buNestedResult Result,
    buNestingVar Parameters)
  {
    ArrayList StringList = new ArrayList();
    if (Sheets != null)
    {
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Nestings Sheets");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) ProfileOperationCircle.ToDef(Sheets, 2).ToArray());
    }
    if (Parts != null)
    {
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Nestings Parts");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) ProfileOperationEllipse.ToDef(Parts, 2).ToArray());
    }
    if (Parameters != null)
    {
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Nesting Settings");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) ((ProfileSupportBlock) Parameters).AddMaterial.ToDefAll("", 2, (SerilizationMode5) 1));
      StringList.AddRange((ICollection) ((ProfileSupportBlock) Parameters).AddPart.ToDefAll("", 2, (SerilizationMode5) 1));
      StringList.AddRange((ICollection) ((ProfileSupportBlock) Parameters).MaterailSettings.ToDefAll("", 2, (SerilizationMode5) 1));
      StringList.AddRange((ICollection) ((ProfileSupportBlock) Parameters).PartSettings.ToDefAll("", 2, (SerilizationMode5) 1));
      StringList.AddRange((ICollection) ((ProfileMultiply) Parameters).ResultSettings.ToDefAll("", 2, (SerilizationMode5) 1));
      StringList.AddRange((ICollection) ((ProfileSupportBlock) Parameters).Settings.ToDefAll("", 2, (SerilizationMode5) 1));
    }
    if (Result != null)
    {
      StringList.Add((object) " ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Nesting Results");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.AddRange((ICollection) ProfileOperationData.ToDef(Result, 2));
    }
    if (StringList.Count <= 0)
      return;
    buFile.SaveToFile(StringList, FileName);
  }

  public void OpenNesting(
    string FileName,
    ref List<buNestingPart> Parts,
    ref List<buNestingSheet> Sheets)
  {
    buNestedResult Result = (buNestedResult) new ProfileOperationPolygon();
    buNestingVar Parameters = (buNestingVar) new ProfileOperationDataBarel();
    ((ProfileOperation) this).OpenNesting(FileName, ref Parts, ref Sheets, ref Result, ref Parameters);
  }

  public void OpenNesting(
    string FileName,
    ref List<buNestingPart> Parts,
    ref List<buNestingSheet> Sheets,
    ref buNestingVar Parameters)
  {
    buNestedResult Result = (buNestedResult) new ProfileOperationPolygon();
    ((ProfileOperation) this).OpenNesting(FileName, ref Parts, ref Sheets, ref Result, ref Parameters);
  }
}
