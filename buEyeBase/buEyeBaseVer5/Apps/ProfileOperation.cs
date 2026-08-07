// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileOperation
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buCore;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileOperation : buSerilization5
{
  public double Width;
  public double Height;
  public double Thickness;
  public int Quantity;
  public int Priority;
  public nestPartRotateType Rotation;
  public double AdditionalRotation;
  public bool Mirror;
  public string Name;
  public string ItemNo;
  public string SalesNo;
  public string Other;
  public string Aux;
  public double UserData;
  public static List<string> Captions;
  public static byte f00425E;
  public buNestingPartData PartData;
  public double RotateDegree;
  public double Area;
  public double PartDistance;
  public double Price;
  public double PrecutWidth;
  public double PrecutHeight;
  public int Nested;
  public int Remain;
  public int ID;
  public string Explanation;
  public string Aux;
  public string Material;
  public string Code;
  public string FileName;
  public string Referance;
  public bool CanRotate;
  public bool Enable;
  public bool UseInnersAsHolePartInPart;
  public bool EdgeLeft;
  public bool EdgeRight;
  public bool EdgeTop;
  public bool EdgeBottom;
  public bool Selected;
  public double EdgeLeftThickness;

  public void OpenNesting(
    string FileName,
    ref List<buNestingPart> Parts,
    ref List<buNestingSheet> Sheets,
    ref buNestedResult Result,
    ref buNestingVar Parameters)
  {
    ArrayList StringList = new ArrayList();
    buFile.OpenFromFile(FileName, ref StringList);
    Parts.Clear();
    Parts = new List<buNestingPart>();
    Sheets.Clear();
    Sheets = new List<buNestingSheet>();
    ProfileOperationCircle.Decode(StringList, ref Sheets);
    ProfileOperationHole.Decode(StringList, ref Parts);
    buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) ((ProfileSupportBlock) Parameters).AddMaterial);
    buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) ((ProfileSupportBlock) Parameters).AddPart);
    buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) ((ProfileSupportBlock) Parameters).MaterailSettings);
    buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) ((ProfileSupportBlock) Parameters).PartSettings);
    buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) ((ProfileMultiply) Parameters).ResultSettings);
    buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) ((ProfileSupportBlock) Parameters).Settings);
    Result = (buNestedResult) new ProfileOperationPolygon();
    ProfileOperationData.Decode(StringList, ref Result);
  }

  public void SetNestingCustomDataOfEntity(ref Entity refEntity)
  {
    if (refEntity.EntityData != null)
    {
      if (refEntity.EntityData is CustomData)
      {
        ((CutterRuntimeSettings) refEntity.EntityData).set_typeDefination(entityTypeDefination.Nesting);
      }
      else
      {
        CustomData customData = (CustomData) new ClipperOffset();
        ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.Nesting);
        refEntity.EntityData = (object) customData;
      }
    }
    else
    {
      CustomData customData = (CustomData) new ClipperOffset();
      ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.Nesting);
      refEntity.EntityData = (object) customData;
    }
  }

  static ProfileOperation() => ProfileItem.NestedAllResults = new List<buNestedResult>();

  public ProfileOperation()
  {
    ((ProfileItem) this).Width = 200.0;
    ((ProfileItem) this).Height = 100.0;
    ((ProfileItem) this).Thickness = 10.0;
    ((ProfileItem) this).Quantity = 1;
    ((ProfileItem) this).Name = "Sheet";
    ((ProfileItem) this).ItemNo = "";
    ((ProfileItem) this).SalesNo = "";
    ((ProfileItem) this).Other = "";
    ((ProfileItem) this).Aux = "";
    ((ProfileItemCalc) this).UserData = 0.0;
    ((ProfileItemCalc) this).Tool = (ToolBase5) new ToolGeometry5();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ProfileOperation(buNestingSheetData data)
  {
    ((ProfileItem) this).Width = 200.0;
    ((ProfileItem) this).Height = 100.0;
    ((ProfileItem) this).Thickness = 10.0;
    ((ProfileItem) this).Quantity = 1;
    ((ProfileItem) this).Name = "Sheet";
    ((ProfileItem) this).ItemNo = "";
    ((ProfileItem) this).SalesNo = "";
    ((ProfileItem) this).Other = "";
    ((ProfileItem) this).Aux = "";
    ((ProfileItemCalc) this).UserData = 0.0;
    ((ProfileItemCalc) this).Tool = (ToolBase5) new ToolGeometry5();
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

  public override string ToString()
  {
    return $"W: {((ProfileItem) this).Width.ToString()} , H: {((ProfileItem) this).Height.ToString()} , Qt: {((ProfileItem) this).Quantity.ToString()}";
  }

  static ProfileOperation() => ProfileItemCalc.Captions = new List<string>();

  public ProfileOperation()
  {
    ((ProfileItemCalc) this).MaterialData = (buNestingSheetData) new ProfileOperation();
    ((ProfileItemCalc) this).Area = 0.0;
    ((ProfileItemCalc) this).Cost = 0.0;
    ((ProfileItemCalc) this).Used = 0;
    ((ProfileItemCalc) this).Remain = 0;
    ((ProfileItemCalc) this).ID = 0;
    ((ProfileItemCalc) this).Aux = "";
    ((ProfileItemCalc) this).FileName = "";
    ((ProfileItemCalc) this).Enable = true;
    ((ProfileItemCalc) this).Remarks = "";
    ((ProfileItemCalc) this).Referance = "";
    ((ProfileItemCalc) this).TrimWidth = 0.0;
    ((ProfileItemCalc) this).TrimHeight = 0.0;
    ((ProfileItemCalc) this).Type = nestMaterialType.Rectangle;
    ((ProfileItemCalc) this).EntitiesGroup = new buEntitiesGroup();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ProfileOperation(buNestingSheet data)
  {
    ((ProfileItemCalc) this).MaterialData = (buNestingSheetData) new ProfileOperation();
    ((ProfileItemCalc) this).Area = 0.0;
    ((ProfileItemCalc) this).Cost = 0.0;
    ((ProfileItemCalc) this).Used = 0;
    ((ProfileItemCalc) this).Remain = 0;
    ((ProfileItemCalc) this).ID = 0;
    ((ProfileItemCalc) this).Aux = "";
    ((ProfileItemCalc) this).FileName = "";
    ((ProfileItemCalc) this).Enable = true;
    ((ProfileItemCalc) this).Remarks = "";
    ((ProfileItemCalc) this).Referance = "";
    ((ProfileItemCalc) this).TrimWidth = 0.0;
    ((ProfileItemCalc) this).TrimHeight = 0.0;
    ((ProfileItemCalc) this).Type = nestMaterialType.Rectangle;
    ((ProfileItemCalc) this).EntitiesGroup = new buEntitiesGroup();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
    ((ProfileItemCalc) this).EntitiesGroup = new buEntitiesGroup(((ProfileItemCalc) data).EntitiesGroup);
    ((ProfileItemCalc) this).MaterialData = (buNestingSheetData) new ProfileOperation(((ProfileItemCalc) data).MaterialData);
  }

  public override string ToString()
  {
    return $"W: {((ProfileItem) ((ProfileItemCalc) this).MaterialData).Width.ToString()} , H: {((ProfileItem) ((ProfileItemCalc) this).MaterialData).Height.ToString()} , Qt: {((ProfileItem) ((ProfileItemCalc) this).MaterialData).Quantity.ToString()} , Nested: {((ProfileItemCalc) this).Used.ToString()}";
  }

  public static void Copy(buNestingSheet Base, ref buNestingSheet Copied)
  {
    Copied = (buNestingSheet) new ProfileOperation(Base);
  }
}
