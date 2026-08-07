// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperationCut
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class ProfileOperationCut : ProfileOperation
{
  public bool DeletePartAfterImport;
  public bool SavePartsBeforeDeleted;
  public double ConnectTolerance;
  public double PartRotateStep;

  public ProfileOperationCut(buNestingSheetAddData data)
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

  static ProfileOperationCut() => GProfileOperation.Captions = new List<string>();

  public ProfileOperationCut()
  {
    this.Width = 200.0;
    this.Height = 100.0;
    this.Thickness = 10.0;
    this.Quantity = 1;
    this.Priority = 10;
    this.Rotation = nestPartRotateType.Increment90;
    this.AdditionalRotation = 0.0;
    this.Mirror = false;
    this.Name = "Part";
    this.ItemNo = "";
    this.SalesNo = "";
    this.Other = "";
    this.Aux = "";
    this.UserData = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
