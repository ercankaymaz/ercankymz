// Decompiled with JetBrains decompiler
// Type: buClass.CounterItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CounterItem : buSerilization
{
  public string Name = "";
  public string Address = "";
  public double ActualCount = 0.0;
  public double PreviousCount = 0.0;
  public double Limit = 0.0;
  public double TotalCount = 0.0;
  public bool isValueTime = false;
  public DateTime ResetDate = DateTime.Now;
  public static List<string> Captions = new List<string>();

  public CounterItem()
  {
  }

  public CounterItem(string Name) => this.Name = Name;

  public CounterItem(CounterItem item)
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

  public override string ToString() => $"{this.Address} : {this.ActualCount.ToString()}";
}
