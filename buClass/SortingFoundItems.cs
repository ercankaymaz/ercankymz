// Decompiled with JetBrains decompiler
// Type: buClass.SortingFoundItems
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class SortingFoundItems : buSerilization
{
  public int Index = -1;
  public camPathDirectionType Direction = camPathDirectionType.Normal;
  public Pnt3D RefPoint = new Pnt3D();
  public Pnt3D NextPoint = new Pnt3D();
  public eEntities Entity = new eEntities();

  public SortingFoundItems()
  {
  }

  public SortingFoundItems(SortingFoundItems data)
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
    this.Entity = new eEntities();
    this.Entity = eEntities.CopyEntity(data.Entity);
  }

  public override string ToString()
  {
    return $"{this.Index.ToString()} - {this.Direction.ToString()} - {this.Entity.ToString()}";
  }
}
