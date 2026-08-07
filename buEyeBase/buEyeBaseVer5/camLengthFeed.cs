// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camLengthFeed
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class camLengthFeed : buSerilization5
{
  public List<Entity> OtherEntities;
  public List<Entity> AllEntities;
  public List<buEntity> G0Entities;

  public camLengthFeed(CamEntitiesTobuEntities data)
  {
    ((CamStock) this).G1Entities = new List<buEntity>();
    ((CamStock) this).LeaveEntities = new List<buEntity>();
    ((CamStock) this).PlungeEntities = new List<buEntity>();
    ((CamStock) this).LeadInEntities = new List<buEntity>();
    ((CamStock) this).LeadOutEntities = new List<buEntity>();
    ((CamStock) this).MarkEntities = new List<buEntity>();
    ((CamStock) this).OtherEntities = new List<buEntity>();
    ((RegenResolutionData) this).AllEntities = new List<buEntity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
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
    buRadialDim.Copy(((camLengthFeed) data).G0Entities, ref this.G0Entities);
    buRadialDim.Copy(((CamStock) data).G1Entities, ref ((CamStock) this).G1Entities);
    buRadialDim.Copy(((CamStock) data).LeaveEntities, ref ((CamStock) this).LeaveEntities);
    buRadialDim.Copy(((CamStock) data).PlungeEntities, ref ((CamStock) this).PlungeEntities);
    buRadialDim.Copy(((CamStock) data).LeadInEntities, ref ((CamStock) this).LeadInEntities);
    buRadialDim.Copy(((CamStock) data).LeadOutEntities, ref ((CamStock) this).LeadOutEntities);
    buRadialDim.Copy(((CamStock) data).MarkEntities, ref ((CamStock) this).MarkEntities);
    buRadialDim.Copy(((CamStock) data).OtherEntities, ref ((CamStock) this).OtherEntities);
  }

  public camLengthFeed()
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
  }

  public camLengthFeed(bool G0, bool G1, bool Leave, bool Plunge)
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
  }

  public camLengthFeed(bool G0, bool G1, bool Leave, bool Plunge, bool G1Original)
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
  }
}
