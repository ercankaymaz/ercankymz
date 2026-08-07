// Decompiled with JetBrains decompiler
// Type: buClass.WatchItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class WatchItem : buSerilization
{
  public string Name = "";
  public string NameShort = "";
  public string Explanation = "";
  public string Program = "";
  public string Task = "";
  public double Value = 0.0;
  public string ValueString = "";
  public double MaxValue = double.MinValue;
  public double MinValue = double.MaxValue;
  public double AvarageValue = 0.0;
  public string NewValue = "";
  public int Counter = 0;
  public string Status = "";
  public bool CommStatus = false;
  public bool UseJustName = false;
  public VariableType VarType = VariableType.LREAL;
  public static List<string> Captions = new List<string>();

  public WatchItem()
  {
  }

  public WatchItem(string Name) => this.Name = Name;

  public WatchItem(WatchItem item)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) item, ref CopiedClass);
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

  public override string ToString() => this.Name;
}
