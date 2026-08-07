// Decompiled with JetBrains decompiler
// Type: buClass.LibraryGroup
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class LibraryGroup
{
  public string Name = "";
  public int Index = 0;
  public int TypeIndex = 0;
  public List<int> EntityID = new List<int>();
  public List<eEntities> GroupEntities = new List<eEntities>();
  public LibraryItem Items = new LibraryItem();
  public camBase CamOperation = new camBase();
  public ToolBase Tool = new ToolBase();
  public object Data = (object) null;

  public LibraryGroup()
  {
  }

  public LibraryGroup(LibraryGroup data)
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
    this.CamOperation = new camBase(data.CamOperation);
    this.Tool = new ToolBase(data.Tool);
    this.GroupEntities.Clear();
    this.GroupEntities = new List<eEntities>();
    eEntities.CopyEntities(data.GroupEntities, ref this.GroupEntities);
  }
}
