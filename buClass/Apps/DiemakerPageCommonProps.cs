// Decompiled with JetBrains decompiler
// Type: buClass.Apps.DiemakerPageCommonProps
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class DiemakerPageCommonProps : buSerilization
{
  public bool SplitJobEnable = false;
  public int SplitFrom = 0;
  public int SplitTo = 0;
  public int MachineIndex = 0;

  public DiemakerPageCommonProps()
  {
  }

  public DiemakerPageCommonProps(DiemakerPageCommonProps data)
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
    return $"Split : {this.SplitJobEnable.ToString()} - SplitFrom : {this.SplitFrom.ToString()} - SplitTo : {this.SplitTo.ToString()} - MachineIndex : {this.MachineIndex.ToString()}";
  }
}
