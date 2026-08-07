// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.CamStock
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class CamStock : buSerilization5
{
  public List<buEntity> G1Entities;
  public List<buEntity> LeaveEntities;
  public List<buEntity> PlungeEntities;
  public List<buEntity> LeadInEntities;
  public List<buEntity> LeadOutEntities;
  public List<buEntity> MarkEntities;
  public List<buEntity> OtherEntities;

  public CamStock(
    bool G0,
    bool G1,
    bool Leave,
    bool Plunge,
    bool G1Original,
    bool leadin,
    bool leadout)
  {
    ((RegenResolutionData) this).G0EntitiesEnable = false;
    ((Point3DList) this).G1EntitiesEnable = false;
    ((Point3DList) this).LeaveEntitiesEnable = false;
    ((Pnt6DList) this).PlungeEntitiesEnable = false;
    ((Pnt6DList) this).LeadInEntitiesEnable = false;
    ((ToolGroup5) this).LeadOutEntitiesEnable = false;
    ((ToolGroup5) this).MarkEntitiesEnable = false;
    ((ToolBase5) this).OtherEntitiesEnable = false;
    ((ToolBase5) this).AllAsSingle = false;
    ((ToolBase5) this).G1EntitiesFromOriginal = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((RegenResolutionData) this).G0EntitiesEnable = G0;
    ((Point3DList) this).G1EntitiesEnable = G1;
    ((Point3DList) this).LeaveEntitiesEnable = Leave;
    ((Pnt6DList) this).PlungeEntitiesEnable = Plunge;
    ((ToolBase5) this).G1EntitiesFromOriginal = G1Original;
    ((Pnt6DList) this).LeadInEntitiesEnable = leadin;
    ((ToolGroup5) this).LeadOutEntitiesEnable = leadout;
  }

  public CamStock(CamEntitiesToEntitiesOption data)
  {
    ((RegenResolutionData) this).G0EntitiesEnable = false;
    ((Point3DList) this).G1EntitiesEnable = false;
    ((Point3DList) this).LeaveEntitiesEnable = false;
    ((Pnt6DList) this).PlungeEntitiesEnable = false;
    ((Pnt6DList) this).LeadInEntitiesEnable = false;
    ((ToolGroup5) this).LeadOutEntitiesEnable = false;
    ((ToolGroup5) this).MarkEntitiesEnable = false;
    ((ToolBase5) this).OtherEntitiesEnable = false;
    ((ToolBase5) this).AllAsSingle = false;
    ((ToolBase5) this).G1EntitiesFromOriginal = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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

  public CamStock()
  {
    ((ToolBase5) this).RefEntity = (buEntity) new buMultilineText();
    ((ToolBase5) this).PointTangentAngle = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public CamStock(LeadInOutEntitiesProps data)
  {
    ((ToolBase5) this).RefEntity = (buEntity) new buMultilineText();
    ((ToolBase5) this).PointTangentAngle = 0.0;
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

  static CamStock() => ToolBase5.Captions = new List<string>();
}
