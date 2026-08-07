// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camRadiusFeed
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
public class camRadiusFeed : buSerilization5
{
  public List<Entity> LeadInEntities;
  public List<Entity> LeadOutEntities;
  public List<Entity> MarkEntities;

  public camRadiusFeed(CamEntitiesToEntities data)
  {
    ((CamEntitiesToEntitiesOption) this).G0Entities = new List<Entity>();
    ((CamEntitiesToEntitiesOption) this).G1Entities = new List<Entity>();
    ((CamEntitiesToEntitiesOption) this).LeaveEntities = new List<Entity>();
    ((CamEntitiesToEntitiesOption) this).PlungeEntities = new List<Entity>();
    ((CamEntitiesToEntitiesOption) this).LeadInEntities = new List<Entity>();
    ((CamEntitiesToEntitiesOption) this).LeadOutEntities = new List<Entity>();
    ((CamEntitiesToEntitiesOption) this).MarkEntities = new List<Entity>();
    ((CamEntitiesToEntitiesOption) this).OtherEntities = new List<Entity>();
    ((CamEntitiesToEntitiesOption) this).AllEntities = new List<Entity>();
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
    buVector5.CopyEntities(((CamEntitiesToEntitiesOption) data).G0Entities, ref ((CamEntitiesToEntitiesOption) this).G0Entities);
    buVector5.CopyEntities(((CamEntitiesToEntitiesOption) data).G1Entities, ref ((CamEntitiesToEntitiesOption) this).G1Entities);
    buVector5.CopyEntities(((CamEntitiesToEntitiesOption) data).LeaveEntities, ref ((CamEntitiesToEntitiesOption) this).LeaveEntities);
    buVector5.CopyEntities(((CamEntitiesToEntitiesOption) data).PlungeEntities, ref ((CamEntitiesToEntitiesOption) this).PlungeEntities);
    buVector5.CopyEntities(((CamEntitiesToEntitiesOption) data).LeadInEntities, ref ((CamEntitiesToEntitiesOption) this).LeadInEntities);
    buVector5.CopyEntities(((CamEntitiesToEntitiesOption) data).LeadOutEntities, ref ((CamEntitiesToEntitiesOption) this).LeadOutEntities);
    buVector5.CopyEntities(((CamEntitiesToEntitiesOption) data).MarkEntities, ref ((CamEntitiesToEntitiesOption) this).MarkEntities);
    buVector5.CopyEntities(((CamEntitiesToEntitiesOption) data).OtherEntities, ref ((CamEntitiesToEntitiesOption) this).OtherEntities);
  }

  public camRadiusFeed()
  {
    ((CamEntitiesToEntitiesOption) this).G0Entities = new List<Entity>();
    ((LeadInOutEntitiesProps) this).G1Entities = new List<Entity>();
    ((LeadInOutEntitiesProps) this).LeaveEntities = new List<Entity>();
    ((LeadInOutEntitiesProps) this).PlungeEntities = new List<Entity>();
    this.LeadInEntities = new List<Entity>();
    this.LeadOutEntities = new List<Entity>();
    this.MarkEntities = new List<Entity>();
    ((camLengthFeed) this).OtherEntities = new List<Entity>();
    ((camLengthFeed) this).AllEntities = new List<Entity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public camRadiusFeed(CamEntitiesToGEntities data)
  {
    ((CamEntitiesToEntitiesOption) this).G0Entities = new List<Entity>();
    ((LeadInOutEntitiesProps) this).G1Entities = new List<Entity>();
    ((LeadInOutEntitiesProps) this).LeaveEntities = new List<Entity>();
    ((LeadInOutEntitiesProps) this).PlungeEntities = new List<Entity>();
    this.LeadInEntities = new List<Entity>();
    this.LeadOutEntities = new List<Entity>();
    this.MarkEntities = new List<Entity>();
    ((camLengthFeed) this).OtherEntities = new List<Entity>();
    ((camLengthFeed) this).AllEntities = new List<Entity>();
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
    buVector5.CopyEntities(((CamEntitiesToEntitiesOption) data).G0Entities, ref ((CamEntitiesToEntitiesOption) this).G0Entities);
    buVector5.CopyEntities(((LeadInOutEntitiesProps) data).G1Entities, ref ((LeadInOutEntitiesProps) this).G1Entities);
    buVector5.CopyEntities(((LeadInOutEntitiesProps) data).LeaveEntities, ref ((LeadInOutEntitiesProps) this).LeaveEntities);
    buVector5.CopyEntities(((LeadInOutEntitiesProps) data).PlungeEntities, ref ((LeadInOutEntitiesProps) this).PlungeEntities);
    buVector5.CopyEntities(((camRadiusFeed) data).LeadInEntities, ref this.LeadInEntities);
    buVector5.CopyEntities(((camRadiusFeed) data).LeadOutEntities, ref this.LeadOutEntities);
    buVector5.CopyEntities(((camRadiusFeed) data).MarkEntities, ref this.MarkEntities);
    buVector5.CopyEntities(((camLengthFeed) data).OtherEntities, ref ((camLengthFeed) this).OtherEntities);
  }

  public camRadiusFeed()
  {
    ((camLengthFeed) this).G0Entities = new List<buEntity>();
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
  }
}
