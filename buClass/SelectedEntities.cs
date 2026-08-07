// Decompiled with JetBrains decompiler
// Type: buClass.SelectedEntities
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class SelectedEntities : buSerilization
{
  public List<Selection> SelectedList = new List<Selection>();
  public List<List<Selection>> SelectedListArr = new List<List<Selection>>();
  public AlingmentPoints AlingPoints = new AlingmentPoints();
  public List<eEntities> SelectableEntities = new List<eEntities>();
  public SelectedPointOfEntity ClickPointOfEntity = new SelectedPointOfEntity();
  public Pnt3D pntMin = new Pnt3D();
  public Pnt3D pntMax = new Pnt3D();

  public SelectedEntities()
  {
  }

  public SelectedEntities(SelectedEntities data)
  {
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
    this.ClickPointOfEntity = new SelectedPointOfEntity(data.ClickPointOfEntity);
    this.AlingPoints = new AlingmentPoints(data.AlingPoints);
    this.SelectedList.Clear();
    this.SelectedList = new List<Selection>();
    for (int index = 0; index <= data.SelectedList.Count - 1; ++index)
      this.SelectedList.Add(new Selection(data.SelectedList[index]));
    this.SelectableEntities.Clear();
    this.SelectableEntities = new List<eEntities>();
    for (int index = 0; index <= data.SelectableEntities.Count - 1; ++index)
    {
      eEntities eEntities = new eEntities();
      eEntities.CopyEntity(data.SelectableEntities[index]);
      this.SelectableEntities.Add(eEntities);
    }
  }
}
