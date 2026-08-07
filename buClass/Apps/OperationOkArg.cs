// Decompiled with JetBrains decompiler
// Type: buClass.Apps.OperationOkArg
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

public class OperationOkArg
{
  public bool Updating = false;
  public bool Copy = false;
  public bool Reset = false;
  public bool Save = false;
  public bool JobUpdate = false;
  public bool DontAddOP = false;
  public List<List<eEntities>> Entities = new List<List<eEntities>>();

  public OperationOkArg()
  {
  }

  public OperationOkArg(bool updating, bool copy, bool reset, bool save, bool jobupdate)
  {
    this.Updating = updating;
    this.Copy = copy;
    this.Reset = reset;
    this.Save = save;
    this.JobUpdate = jobupdate;
  }

  public OperationOkArg(OperationOkArg data)
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
}
