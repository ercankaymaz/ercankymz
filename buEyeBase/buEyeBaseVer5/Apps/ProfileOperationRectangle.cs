// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationRectangle
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileOperationRectangle : ProfileOperation
{
  public double EdgeTopThickness;
  public double EdgeBottomThickness;
  public nestMaterialType Type;
  public buEntitiesGroup EntitiesGroup;
  public new static List<string> Captions;

  static ProfileOperationRectangle() => ProfileItemCalc.Captions = new List<string>();

  public ProfileOperationRectangle()
  {
    ((ProfileItemCalc) this).CornerType = nestCorner.LeftBottom;
    ((ProfileItemCalc) this).Direction = nestDirection.XDirection;
    ((GProfileOperationGroup) this).Algorithm = nestAlgorithm.TrueShape;
    ((GProfileOperationGroup) this).RectangleMarginLeft = 0.5;
    ((GProfileOperation) this).RectangleMarginRight = 0.5;
    ((GProfileOperation) this).RectangleMarginTop = 0.5;
    ((GProfileOperation) this).RectangleMarginBottom = 0.5;
    ((GProfileOperation) this).IrregularMargin = 0.5;
    ((GProfileOperation) this).DeleteSheetAfterImport = false;
    ((GProfileOperation) this).SaveSheetsBeforeDeleted = false;
    ((GProfileOperation) this).UseSmallAreaFirst = true;
    ((GProfileOperation) this).DefaultSheetName = "Sheet";
    ((GProfileOperation) this).AddAutoSheetQuantityIfAvailable = true;
    ((GProfileOperation) this).AddAutoSheetNameIfAvailable = true;
    ((GProfileOperation) this).AutoSheetNameRef = "Name";
    ((GProfileOperation) this).AutoSheetQuantityRef = "Quantity";
    ((GProfileOperation) this).AutoSheetNameEquality = ":";
    ((GProfileOperation) this).AutoSheetQuantityEquality = ":";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
