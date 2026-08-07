// Decompiled with JetBrains decompiler
// Type: buClass.ToolGroup
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ToolGroup : buSerilization
{
  public List<ToolBase> Tools = new List<ToolBase>();
  public string GroupName = nameof (Tools);

  public ToolGroup()
  {
  }

  public ToolGroup(ToolGroup Data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) Data, ref CopiedClass);
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
    this.Tools.Clear();
    for (int index = 0; index <= Data.Tools.Count - 1; ++index)
      this.Tools.Add(new ToolBase(Data.Tools[index]));
  }
}
