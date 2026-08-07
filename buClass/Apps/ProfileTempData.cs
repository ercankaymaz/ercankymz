// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ProfileTempData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class ProfileTempData : buSerilization
{
  public List<Pnt3D> SortedEntitiesPoints = new List<Pnt3D>();
  public List<Pnt3D> SortedAndScaledEntitiesPoints = new List<Pnt3D>();
  public List<Pnt3D> SortedAndScaledAndRotatedEntitiesPoints = new List<Pnt3D>();
  public List<Pnt3D> ScaledEntitiesPoints = new List<Pnt3D>();
  public List<eEntities> SortedEntities = new List<eEntities>();
  public List<eEntities> SortedAndScaledEntities = new List<eEntities>();
  public List<eEntities> SortedAndScaledAndRotaredEntities = new List<eEntities>();
  public List<List<Pnt3D>> SortedEntitiesPointsList = new List<List<Pnt3D>>();
  public List<List<Pnt3D>> SortedAndScaledEntitiesPointsList = new List<List<Pnt3D>>();
  public List<List<Pnt3D>> SortedAndScaledAndRotatedEntitiesPointsList = new List<List<Pnt3D>>();
  public List<List<Pnt3D>> ScaledEntitiesPointsList = new List<List<Pnt3D>>();
  public List<List<eEntities>> SortedEntitiesList = new List<List<eEntities>>();
  public List<List<eEntities>> SortedAndScaledEntitiesList = new List<List<eEntities>>();
  public List<List<eEntities>> SortedAndScaledAndRotatedEntitiesList = new List<List<eEntities>>();
  public static List<string> Captions = new List<string>();

  public ProfileTempData()
  {
  }

  public ProfileTempData(ProfileTempData data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
  }

  public override string ToString()
  {
    return "SortedEntitiesPoints : " + this.SortedEntitiesPoints.Count.ToString();
  }
}
