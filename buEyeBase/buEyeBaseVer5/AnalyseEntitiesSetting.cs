// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.AnalyseEntitiesSetting
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class AnalyseEntitiesSetting : buSerilization5
{
  public Point3D BasePointOfEntity;
  public int ReSizedEntityIndex;
  public int ReSizedEntitySubIndex;
  public string SelectedEntities;
  public static byte f000509;
  public int Sequence;
  public int OriginalEntityIndex;
  public int InsideIndex;
  public int EntityIndex;
  public int EntitySubIndex;
  public int RefIndex;

  public AnalyseEntitiesSetting(EntityInfo data)
  {
    ((AnalyseEntitiesResult) this).CamIndex = -1;
    ((AnalyseEntitiesResult) this).CamSelected = false;
    ((AnalyseEntitiesResultError) this).CamSelectedCount = 0;
    ((AnalyseEntitiesResultError) this).CamSelectable = true;
    ((AnalyseEntitiesResultError) this).CamPlungeAxis = (string) null;
    ((AnalyseEntitiesResultError) this).CamLeaveAxis = (string) null;
    ((AnalyseEntitiesResultError) this).CamSpeed = 0.0;
    ((AnalyseEntitiesResultError) this).PlungeSpeed = 0.0;
    ((AnalyseEntitiesResultError) this).SpindleSpeed = 0.0;
    ((DirectionArrowSetting) this).Enable = true;
    ((DirectionArrowSetting) this).Calculated = false;
    ((DirectionArrowSetting) this).Selectable = true;
    ((DirectionArrowSetting) this).DontUseForCalculation = false;
    ((DirectionArrowSetting) this).isUpperEntity = false;
    ((EntityDataSet) this).CamID = -1;
    ((EntityDataSet) this).ItemID = -1;
    ((EntityDataSet) this).EdgeID = -1;
    ((EntityDataSet) this).CamToolNo = 1;
    ((EntityDataSet) this).EntityName = (string) null;
    ((EntityDataSet) this).CamCode = (string) null;
    ((EntityDataSet) this).ID = (string) null;
    ((EntityDataSet) this).Tags = (string) null;
    ((EntityDataSet) this).Data = (string) null;
    ((EntityDataSet) this).AuxVal = 0.0;
    ((EntityDataSet) this).Length = 0.0;
    ((EntityDataSet) this).Radius = 0.0;
    ((EntityDataSet) this).Offset = (Point3D) null;
    ((EntityDataSet) this).OffsetABC = (PointABC) null;
    ((EntityDataSet) this).OffsetAngle = (OrientationAngle) null;
    ((EntityDataSet) this).Commands = (List<string>) null;
    ((EntityDataSet) this).Options = (List<string>) null;
    ((EntityDataSet) this).OrjType = entityOriginalType.None;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
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
    if (((EntityDataSet) data).Offset != (Point3D) null)
      ((EntityDataSet) this).Offset = new Point3D(((EntityDataSet) data).Offset.X, ((EntityDataSet) data).Offset.Y, ((EntityDataSet) data).Offset.Z);
    if (((EntityDataSet) data).OffsetABC != null)
      ((EntityDataSet) this).OffsetABC = (PointABC) new SortAskMe(((ViewportSettings) ((EntityDataSet) data).OffsetABC).A, ((ViewportSettings) ((EntityDataSet) data).OffsetABC).B, ((ViewportSettings) ((EntityDataSet) data).OffsetABC).C);
    if (((EntityDataSet) data).Commands != null)
    {
      ((EntityDataSet) this).Commands = new List<string>();
      ((EntityDataSet) this).Commands.AddRange((IEnumerable<string>) ((EntityDataSet) data).Commands);
    }
    if (((EntityDataSet) data).Options == null)
      return;
    ((EntityDataSet) this).Options = new List<string>();
    ((EntityDataSet) this).Options.AddRange((IEnumerable<string>) ((EntityDataSet) data).Options);
  }

  public override string ToString()
  {
    string str1 = "";
    if (this.Sequence >= 0)
      str1 = $"{str1}Seq: {this.Sequence.ToString()}";
    if (this.OriginalEntityIndex >= 0)
      str1 = str1.Length <= 0 ? $"{str1}OrjEntIndex: {this.OriginalEntityIndex.ToString()}" : $"{str1} , OrjEntIndex: {this.OriginalEntityIndex.ToString()}";
    if (this.RefIndex >= 0)
      str1 = str1.Length <= 0 ? $"{str1}RefIndex: {this.RefIndex.ToString()}" : $"{str1} , RefIndex: {this.RefIndex.ToString()}";
    if (this.EntityIndex >= 0)
      str1 = str1.Length <= 0 ? $"{str1}EntIndex: {this.EntityIndex.ToString()}" : $"{str1} , EntIndex: {this.EntityIndex.ToString()}";
    if (this.EntitySubIndex >= 0)
      str1 = str1.Length <= 0 ? $"{str1}EntSubIndex: {this.EntitySubIndex.ToString()}" : $"{str1} , EntSubIndex: {this.EntitySubIndex.ToString()}";
    if (((AnalyseEntitiesResult) this).CamIndex >= 0)
      str1 = str1.Length <= 0 ? $"{str1}CamIndex: {((AnalyseEntitiesResult) this).CamIndex.ToString()}" : $"{str1} , CamIndex: {((AnalyseEntitiesResult) this).CamIndex.ToString()}";
    if (((EntityDataSet) this).CamID >= 0)
      str1 = str1.Length <= 0 ? $"{str1}CamID: {((EntityDataSet) this).CamID.ToString()}" : $"{str1} , CamID: {((EntityDataSet) this).CamID.ToString()}";
    string str2 = str1.Length <= 0 ? $"{str1}Cam Selected: {((AnalyseEntitiesResult) this).CamSelected.ToString()}" : $"{str1} , Cam Selected: {((AnalyseEntitiesResult) this).CamSelected.ToString()}";
    if (!((DirectionArrowSetting) this).Enable)
      str2 = str2.Length <= 0 ? $"{str2}Enable: {((DirectionArrowSetting) this).Enable.ToString()}" : $"{str2} , Enable: {((DirectionArrowSetting) this).Enable.ToString()}";
    if (((EntityDataSet) this).AuxVal != 0.0)
      str2 = str2.Length <= 0 ? $"{str2}Val: {((EntityDataSet) this).AuxVal.ToString()}" : $"{str2} , Val: {((EntityDataSet) this).AuxVal.ToString()}";
    if (((EntityDataSet) this).Offset != (Point3D) null)
    {
      if (str2.Length > 0)
        str2 = $"{str2} , Offset: ({((EntityDataSet) this).Offset.X.ToString()} , {((EntityDataSet) this).Offset.Y.ToString()} , {((EntityDataSet) this).Offset.Z.ToString()})";
      else
        str2 = $"{str2}Offset: ({((EntityDataSet) this).Offset.X.ToString()} , {((EntityDataSet) this).Offset.Y.ToString()} , {((EntityDataSet) this).Offset.Z.ToString()})";
    }
    if (((EntityDataSet) this).OffsetABC != null)
    {
      if (str2.Length > 0)
        str2 = $"{str2} , OffsetABC: ({((ViewportSettings) ((EntityDataSet) this).OffsetABC).A.ToString()} , {((ViewportSettings) ((EntityDataSet) this).OffsetABC).B.ToString()} , {((ViewportSettings) ((EntityDataSet) this).OffsetABC).C.ToString()})";
      else
        str2 = $"{str2}OffsetABC: ({((ViewportSettings) ((EntityDataSet) this).OffsetABC).A.ToString()} , {((ViewportSettings) ((EntityDataSet) this).OffsetABC).B.ToString()} , {((ViewportSettings) ((EntityDataSet) this).OffsetABC).C.ToString()})";
    }
    if (((EntityDataSet) this).OrjType != 0)
      str2 = $"{str2} Orj: {((EntityDataSet) this).OrjType.ToString()}";
    return str2;
  }

  public abstract void m000202();
}
