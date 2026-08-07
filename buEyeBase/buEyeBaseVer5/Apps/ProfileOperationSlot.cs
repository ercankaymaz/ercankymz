// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationSlot
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileOperationSlot : ProfileOperation
{
  public static byte f00427E;
  public double PartsSpace;
  public int Multiply;

  public ProfileOperationSlot(buNestingSheetSettings data)
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
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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

  static ProfileOperationSlot() => GProfileOperation.Captions = new List<string>();

  public ProfileOperationSlot()
  {
    ((GProfileOperation) this).UseColorForSelection = false;
    ((GProfileOperation) this).SelectionColor = Color.Black;
    ((GProfileOperation) this).DeleteSelectedEntities = true;
    ((GProfileOperation) this).Thickness = 10.0;
    ((GProfileOperation) this).Quantity = 1;
    ((GProfileOperation) this).Name = "Sheet";
    ((GProfileOperation) this).AddUselessEntities = true;
    ((GProfileOperation) this).LastSheetWidth = 1000.0;
    ((GProfileOperation) this).LastSheetHeight = 500.0;
    ((GProfileOperation) this).LastSheetQuantity = 10;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
