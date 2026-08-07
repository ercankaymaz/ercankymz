// Decompiled with JetBrains decompiler
// Type: buClass.Apps.DiemakerRuntimeSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class DiemakerRuntimeSettings : buSerilization
{
  public List<MachineType> MachineTypes = new List<MachineType>();
  public int SelectedMachine = 0;

  public DiemakerRuntimeSettings()
  {
  }

  public DiemakerRuntimeSettings(DiemakerRuntimeSettings data)
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
    this.MachineTypes.Clear();
    for (int index = 0; index <= data.MachineTypes.Count - 1; ++index)
      this.MachineTypes.Add(new MachineType(data.MachineTypes[index]));
  }

  public static void Copy(DiemakerRuntimeSettings Source, ref DiemakerRuntimeSettings Target)
  {
    Target = new DiemakerRuntimeSettings(Source);
  }

  public override string ToString() => "Sel Machine : " + this.SelectedMachine.ToString();
}
